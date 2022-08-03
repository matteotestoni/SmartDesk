using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    public int intNumRecords = 0;
    public string strAnagrafiche_Ky = "";
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public string strAnagraficheProdotti_Ky = "";    
    public DataTable dtAzienda;

    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        
        strAnagrafiche_Ky=(FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-cliente"].Value)).UserData;
  	    if (strAnagrafiche_Ky!=null){
            Dictionary<string, object> frm = new Dictionary<string, object>();
            if (Smartdesk.Current.Request("Anagrafiche_Privacy") == "") frm.Add("Anagrafiche_Privacy", false);
            if (Smartdesk.Current.Request("Anagrafiche_Newsletter") == "") frm.Add("Anagrafiche_Newsletter", false);
            strKy = Smartdesk.Functions.SqlWriteKey("AnagraficheProdotti");
            strAnagraficheProdotti_Ky=strKy;
            strWHERENet="Aziende_Ky=1";
            strORDERNet = "Aziende_Ky";
            strFROMNet = "Aziende_Vw";
            dtAzienda = new DataTable("Azienda");
            dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
            sendEmail();
            Response.Redirect("/area-clienti/home.aspx");
        }else{
            Response.Redirect("/area-clienti/login.aspx");
        }
    }

    public Boolean sendEmail(){
        string strFROM="";
        string strTO="";
        string strEmailAnagrafica="";
        string strHtml = "";
        DataTable dtCoreModulesOptionsValue;
        DataTable dtAnagraficheProdotti;

        dtCoreModulesOptionsValue = new DataTable("Options");
        strWHERENet="CoreModulesOptions_Code='ticket.emailfrom'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strFROM=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='ticket.emailto'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strTO=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            

        strWHERENet="AnagraficheProdotti_Ky=" + strAnagraficheProdotti_Ky;
        strORDERNet = "AnagraficheProdotti_Ky";
        strFROMNet = "AnagraficheProdotti_Vw";
        dtAnagraficheProdotti = new DataTable("Ticket");
        dtAnagraficheProdotti = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheProdotti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtAnagraficheProdotti.Rows.Count>0){
            strEmailAnagrafica=dtAnagraficheProdotti.Rows[0]["Anagrafiche_EmailContatti"].ToString();
        }            

    	  strHtml="<html><head><style>*{font-size:14px;font-family: 'Google Sans', Roboto;} h1{font-size:26px;font-weight:700;padding:0;margin:0;} h2{font-size:18px;font-weight:700;padding:0;margin:0;} table{border-collapse: collapse;}</style></head><body>";
    	  strHtml+="<h2 style=\"color:green;margin:5px 0;\">Nuovo prodotto aggiornato per cliente</h2>";
    	  strHtml+="<p>" + dtAnagraficheProdotti.Rows[0]["Anagrafiche_RagioneSociale"].ToString() + " ha aggiornato i suoi prodotti</p>";

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
  		mail.From = new System.Net.Mail.MailAddress(strEmailAnagrafica);
  		mail.To.Add(new System.Net.Mail.MailAddress(strTO));
  		mail.Subject = "Prodotti anagrafica aggiornati";
  		mail.Body = strHtml;
  		mail.IsBodyHtml = true;
  		System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(dtAzienda.Rows[0]["Aziende_ServerSMTP"].ToString(), Convert.ToInt32(dtAzienda.Rows[0]["Aziende_ServerSMTPPorta"].ToString()));
  		System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(dtAzienda.Rows[0]["Aziende_ServerSMTPUtente"].ToString(), dtAzienda.Rows[0]["Aziende_ServerSMTPPassword"].ToString());
  		client.UseDefaultCredentials = false;
  		client.Credentials = mailAuthentication;
  		client.EnableSsl = (bool)dtAzienda.Rows[0]["Aziende_ServerSMTPSSL"];
  		client.Send(mail);
        return true;
    }
}
