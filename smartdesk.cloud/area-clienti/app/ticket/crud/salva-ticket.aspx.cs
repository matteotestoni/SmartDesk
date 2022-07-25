using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page {
    
    
    public int intNumRecords = 0;
    public string strKy = "";
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public string strTicket_Ky = "";
    public DataTable dtAzienda;
    public string strAzione = "";

    protected void Page_Load(object sender, EventArgs e){
        
        
        strAzione=Request["azione"];
        strKy = Smartdesk.Functions.SqlWriteKey("Ticket");
        strTicket_Ky=strKy;
        strWHERENet="Aziende_Ky=1";
        strORDERNet = "Aziende_Ky";
        strFROMNet = "Aziende_Vw";
        dtAzienda = new DataTable("Azienda");
        dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
        sendEmail();
        Response.Redirect("/area-clienti/app/ticket/ticket-inviato.aspx?salvato=salvato&Ticket_Ky=" + strKy);
    }

    public Boolean sendEmail(){
        string strFROM="";
        string strTO="";
        string strEmailAnagrafica="";
        string strHtml = "";
        string strMessage = "";
        DataTable dtCoreModulesOptionsValue;
        DataTable dtTicket;

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
        strWHERENet="CoreModulesOptions_Code='ticket.messagenewticket'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strMessage=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            

        strWHERENet="Ticket_Ky=" + strTicket_Ky;
        strORDERNet = "Ticket_Ky";
        strFROMNet = "Ticket_Vw";
        dtTicket = new DataTable("Ticket");
        dtTicket = Smartdesk.Sql.getTablePage(strFROMNet, null, "Ticket_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtTicket.Rows.Count>0){
            strEmailAnagrafica=dtTicket.Rows[0]["Anagrafiche_EmailContatti"].ToString();
        }            

    	  strHtml="<html><head><style>*{font-size:14px;font-family: 'Google Sans', Roboto;} h1{font-size:26px;font-weight:700;padding:0;margin:0;} h2{font-size:18px;font-weight:700;padding:0;margin:0;} table{border-collapse: collapse;}</style></head><body>";
        strMessage=strMessage.Replace();
        strHtml+=strMessage;
    	  strHtml+="<h2 style=\"color:green;margin:5px 0;\">Ticket aggiornato</h2>";
    	  strHtml+="<p>Puoi consultare lo storico del ticket alla tua area riservata al seguente indirizzo: <a href=\"https://" + Request.Url.Host + "/area-clienti/\">" + Request.Url.Host + "/area-clienti/</a></p>";

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.From = new System.Net.Mail.MailAddress(strEmailAnagrafica);
        mail.To.Add(new System.Net.Mail.MailAddress(strTO));
        mail.Bcc.Add(new System.Net.Mail.MailAddress(strEmailAnagrafica));
        mail.Subject = "Ticket aggiornato";
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
