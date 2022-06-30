using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strKy = "";
    public string strTicket_Ky = "";
    public DataTable dtAzienda;
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        
        

        strWHERENet="Aziende_Ky=1";
        strORDERNet = "Aziende_Ky";
        strFROMNet = "Aziende_Vw";
        dtAzienda = new DataTable("Azienda");
        dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
        strTicket_Ky = Request["Ticket_Ky"];
        Response.Write("ticket:" + strTicket_Ky + "<br>");
        strKy = Smartdesk.Functions.SqlWriteKey("Attivita");
        sendEmail();
        Response.Redirect("/area-clienti/app/ticket/scheda-ticket.aspx?salvato=salvato&Ticket_Ky=" + strTicket_Ky + "&Attivita_Ky=" + strKy);
    }
    
    public Boolean sendEmail(){
        string strFROM="";
        string strTO="";
        string strEmailAnagrafica="";
        string strServerSMTP="";
        string strServerSMTPUser="";
        string strServerSMTPPassword="";
        string strServerSMTPPorta="";
        string strServerSMTPSSL="";
        string strHtml = "";
        DataTable dtCoreModulesOptionsValue;
        DataTable dtTicket;
        DataTable dtAttivita;
        
        strWHERENet="CoreModulesOptions_Code='core.serversmpt'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTP=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptuser'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPUser=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptpassword'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPPassword=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptport'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPPorta=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptssl'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPSSL=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
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

        strWHERENet="Ticket_Ky=" + strTicket_Ky;
        strORDERNet = "Ticket_Ky";
        strFROMNet = "Ticket_Vw";
        dtTicket = new DataTable("Ticket");
        dtTicket = Smartdesk.Sql.getTablePage(strFROMNet, null, "Ticket_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtTicket.Rows.Count>0){
            strEmailAnagrafica=dtTicket.Rows[0]["Anagrafiche_EmailContatti"].ToString();
        }            

        strWHERENet="Attivita_Ky=" + strKy;
        strORDERNet = "Attivita_Ky";
        strFROMNet = "Attivita_Vw";
        dtAttivita = new DataTable("Attivita");
        dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

        strHtml="<html><head><style>*{font-size:14px;font-family: 'Google Sans', Roboto;} h1{font-size:26px;font-weight:700;padding:0;margin:0;} h2{font-size:18px;font-weight:700;padding:0;margin:0;} table{border-collapse: collapse;}</style></head><body>";
        strHtml+="<h1 style=\"color:green;margin:5px 0;\">Ticket aggiornato</h1>";
        strHtml+="<p>Puoi consultare lo storico del ticket alla tua area riservata al seguente indirizzo:&nbsp;<a href=\"https://" + Request.Url.Host + "/area-clienti/\">" + Request.Url.Host + "/area-clienti/</a></p>";
        strHtml+="<h2>Dati del ticket</h2>";
        strHtml+="<p>" + dtAttivita.Rows[0]["Attivita_Descrizione"].ToString() + "</p>";

        Response.Write("Email anagrafica:" + strEmailAnagrafica + "<br>");
        Response.Write("From:" + strFROM + "<br>");
        Response.Write("To:" + strTO + "<br>");
        Response.Write("SMTP:" + strServerSMTP + "<br>");
        Response.Write("porta:" + strServerSMTPPorta + "<br>");
        Response.Write("username:" + strServerSMTPUser + "<br>");
        Response.Write("password:" + strServerSMTPPassword + "<br>");
        Response.Write("ssl:" + strServerSMTPSSL + "<br>");

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
    		mail.From = new System.Net.Mail.MailAddress(strEmailAnagrafica);
    		mail.To.Add(new System.Net.Mail.MailAddress(strTO));
    		mail.Bcc.Add(new System.Net.Mail.MailAddress(strEmailAnagrafica));
    		mail.Subject = "Ticket aggiornato";
    		mail.Body = strHtml;
    		mail.IsBodyHtml = true;
    		System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(strServerSMTP, Convert.ToInt32(strServerSMTPPorta));
    		System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(strServerSMTPUser, strServerSMTPPassword);
    		client.UseDefaultCredentials = false;
    		client.Credentials = mailAuthentication;
    		client.EnableSsl = Convert.ToBoolean(strServerSMTPSSL);
    		client.Send(mail);
        return true;
    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App) //#bp
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }

}
