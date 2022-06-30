using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    
    public string strAnagrafiche_Ky = "";
    public DataTable dtAnagrafica;
    public DataTable dtAzienda;
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public int intNumRecords = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        

        strAnagrafiche_Ky=(FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-cliente"].Value)).UserData;
  	    if (strAnagrafiche_Ky!=null){
            Dictionary<string, object> frm = new Dictionary<string, object>();
            if (Smartdesk.Current.Request("Anagrafiche_Privacy") == "") frm.Add("Anagrafiche_Privacy", false);
            if (Smartdesk.Current.Request("Anagrafiche_Newsletter") == "") frm.Add("Anagrafiche_Newsletter", false);
            strKy = Smartdesk.Functions.SqlWriteKey("Anagrafiche", frm);
            strWHERENet="Anagrafiche_Ky=" + strKy;
            strORDERNet = "Anagrafiche_Ky";
            strFROMNet = "Anagrafiche_Vw";
            dtAnagrafica = new DataTable("Anagrafica");
            dtAnagrafica = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
            strWHERENet="Aziende_Ky=1";
            strORDERNet = "Aziende_Ky";
            strFROMNet = "Aziende_Vw";
            dtAzienda = new DataTable("Azienda");
            dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
            sendEmail();
            Response.Redirect("/area-clienti/app/anagrafiche/profilo.aspx?salvato=salvato&Anagrafiche_Ky=" + strKy);
        }else{
            Response.Redirect("/area-clienti/login.aspx");
        }
    }

    public Boolean sendEmail(){
        string strFROM="";
        string strTO="";
        string strEmailAnagrafica="";
        string strHtml = "";
        string strMessage = "";
        DataTable dtTicket;

        strFROM=dtAzienda.Rows[0]["Aziende_Email"].ToString();
        
        strTO=Smartdesk.Functions.getOption("amministrazione.email");
        strFROM=strTO;

    	  strHtml="<html><head><style>*{font-size:14px;font-family: 'Google Sans', Roboto;} h1{font-size:26px;font-weight:700;padding:0;margin:0;} h2{font-size:18px;font-weight:700;padding:0;margin:0;} table{border-collapse: collapse;}</style></head><body>";
    	  strHtml+="<h1 style=\"color:green;margin:5px 0;\">Cambio dati anagrafica</h1>";
    	  strHtml+="<ul>";
    	  strHtml+="<li>Ragione Sociale: " + dtAnagrafica.Rows[0]["Anagrafiche_RagioneSociale"].ToString() + "</li>";
    	  strHtml+="<li>Indirizzo: " + dtAnagrafica.Rows[0]["Anagrafiche_Indirizzo"].ToString() + "</li>";
    	  strHtml+="<li>Telefono: " + dtAnagrafica.Rows[0]["Anagrafiche_Telefono"].ToString() + "</li>";
    	  strHtml+="<li>Indirizzo: " + dtAnagrafica.Rows[0]["Anagrafiche_Indirizzo"].ToString() + "</li>";
    	  strHtml+="<li>Partita IVA: " + dtAnagrafica.Rows[0]["Anagrafiche_PartitaIVA"].ToString() + "</li>";
    	  strHtml+="<li>Codice Fiscale: " + dtAnagrafica.Rows[0]["Anagrafiche_CodiceFiscale"].ToString() + "</li>";
    	  strHtml+="<li>Email contatti: " + dtAnagrafica.Rows[0]["Anagrafiche_EmailContatti"].ToString() + "</li>";
    	  strHtml+="<li>Email amministrazione: " + dtAnagrafica.Rows[0]["Anagrafiche_EmailAmministrazione"].ToString() + "</li>";
    	  strHtml+="<li>Sito Web: " + dtAnagrafica.Rows[0]["Anagrafiche_SitoWeb"].ToString() + "</li>";
    	  strHtml+="<li>Autorizzazione privacy: " + dtAnagrafica.Rows[0]["Anagrafiche_Privacy"].ToString() + "</li>";
    	  strHtml+="<li>Ricezione newsletter: " + dtAnagrafica.Rows[0]["Anagrafiche_Newsletter"].ToString() + "</li>";
    	  strHtml+="</ul>";
    	  strHtml+="<p>Puoi consultare i dati dell'anagrafica alla tua area riservata al seguente indirizzo: <a href=\"https://" + Request.Url.Host + "/area-clienti/\">" + Request.Url.Host + "/area-clienti/</a></p>";

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.From = new System.Net.Mail.MailAddress(strFROM);
        mail.To.Add(new System.Net.Mail.MailAddress(strTO));
        mail.Subject = "Cambio dati anagrafica";
        mail.Body = strHtml;
        mail.IsBodyHtml = true;
        Response.Write(dtAzienda.Rows[0]["Aziende_ServerSMTP"].ToString() + "<br>");
        Response.Write(dtAzienda.Rows[0]["Aziende_ServerSMTPUtente"].ToString() + "<br>");
        Response.Write(dtAzienda.Rows[0]["Aziende_ServerSMTPPassword"].ToString() + "<br>");
        Response.Write(dtAzienda.Rows[0]["Aziende_ServerSMTPPorta"].ToString() + "<br>");
        Response.Write(dtAzienda.Rows[0]["Aziende_ServerSMTPSSL"].ToString() + "<br>");
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(dtAzienda.Rows[0]["Aziende_ServerSMTP"].ToString(), Convert.ToInt32(dtAzienda.Rows[0]["Aziende_ServerSMTPPorta"].ToString()));
        System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(dtAzienda.Rows[0]["Aziende_ServerSMTPUtente"].ToString(), dtAzienda.Rows[0]["Aziende_ServerSMTPPassword"].ToString());
        client.UseDefaultCredentials = false;
        client.Credentials = mailAuthentication;
        client.EnableSsl = (bool)dtAzienda.Rows[0]["Aziende_ServerSMTPSSL"];
        client.Send(mail);
      return true;
    }
    
    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App) //#bp
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}
