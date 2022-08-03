using System;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{

public int intNumRecords = 0;
public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
public string strLogin="";
public DataTable dtLogin;
public bool boolAdmin = false;
public DataTable dtPagamentiFuturi;
public DataTable dtPagamentiScaduti;
public int intAnagrafiche_Ky = 0;
public string strFROMNet = "";
public string strORDERNet = "";
public string strWHERENet = "";
public int intAnno = 0;
public int intMese = 0;
public DateTime dt;
public string strFirma = "";
public string strTipo = "";


    protected void Page_Load(object sender, EventArgs e)
    {
    	inviaPromemoriaPEC(Smartdesk.Functions.getOption("pagamenti.frompec"),"prova pec 2", "prova pec 2","");
    }    

    public bool inviaPromemoriaPEC(string strMailTO,string strMailSubject,string strMailBody, string strAttach){
        string strFROM="";
        string strServerSMTP="";
        string strServerSMTPUser="";
        string strServerSMTPPassword="";
        string strServerSMTPPorta="";
        string strServerSMTPSSL="";
        DataTable dtCoreModulesOptionsValue;
        
        strWHERENet="CoreModulesOptions_Code='core.serversmptpec'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTP=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptpecuser'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPUser=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptpecpassword'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPPassword=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptpecport'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPPorta=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptpecssl'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPSSL=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            

        strWHERENet="CoreModulesOptions_Code='pagamenti.frompec'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strFROM=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.From = new System.Net.Mail.MailAddress(strFROM);
        mail.To.Add(new System.Net.Mail.MailAddress(strMailTO));
        mail.Subject = strMailSubject;
        mail.Body = strMailBody;
        if (strAttach != null && strAttach.Length > 0)
        {
          mail.Attachments.Add(new System.Net.Mail.Attachment(strAttach));
        }
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = System.Net.Mail.MailPriority.High;
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(strServerSMTP,Convert.ToInt32(strServerSMTPPorta));
        System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(strServerSMTPUser, strServerSMTPPassword);
        client.UseDefaultCredentials = false;
        client.Credentials = mailAuthentication;
    		client.EnableSsl = Convert.ToBoolean(strServerSMTPSSL);
        client.Send(mail);
        return true;       
    }
}
