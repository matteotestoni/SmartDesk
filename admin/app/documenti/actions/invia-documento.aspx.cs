using System;
using System.Data;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page 
{
    
    
    public DataTable dtLogin;
    public DataTable dtDocumento;
    public bool boolAdmin = false;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public int intNumRecords = 0;
    public int i = 0;
    
    public string strLogin = "";
    public string strPathReport = "";
    public string strPathPDF = "";
    public string strNomePDF = "";
    public string strDocumenti_Ky = "";
    public string strSQL = "";
   
	  public string strA = "";
	  public string strDa = "";
	  public string strAttach = "";
    public string strSubject = "";
    public string strBody = "";


    protected void Page_Load(object sender, EventArgs e){
        
        

        if (Smartdesk.Login.Verify)
        {
            strDocumenti_Ky = Request["Documenti_Ky"];
            dtLogin = Smartdesk.Data.Read("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
            dtDocumento = Smartdesk.Data.Read("Documenti_Vw", "Documenti_Ky", strDocumenti_Ky);
            strAttach = Server.MapPath("/uploads/documenti/" + dtDocumento.Rows[0]["Documenti_PDF"].ToString());

            strDa = Request["Da"];
            strA = Request["A"];
            strSubject = Request["Oggetto"];
            strBody = Request["Corpo"];;
            inviaDocumento(strDa, strA, strSubject, strBody, strAttach);
						Response.Redirect("/admin/app/documenti/scheda-documenti.aspx?Documenti_Ky=" + strDocumenti_Ky);
        }
    }    
    
    public String GetUTF(string strTestoIn)
    {
      string strTestoOut="";
      if (strTestoIn!=null){
        strTestoOut=strTestoIn.Replace(".","").Replace("&","").Replace("snc","").Replace(" ","-").Replace("--","-");
      }else{
        strTestoOut="";
      }
      return strTestoOut;
    }

    public bool inviaDocumento(string strMailFROM, string strMailTO, string strMailSubject, string strMailBody, string strAttach)
    {
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.From = new MailAddress(strMailFROM);
        string[] emails = strMailTO.Split(',');
				foreach (string email in emails)
        {
					mail.To.Add(new MailAddress(email));
        }				
        mail.Bcc.Add(new MailAddress(strMailFROM));
        mail.Subject = strMailSubject;
        mail.Body = strMailBody;
        mail.IsBodyHtml = true;
        if (strAttach != null && strAttach.Length > 0)
        {
            mail.Attachments.Add(new Attachment(strAttach));
        }
        mail.Priority = MailPriority.Normal;
        System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(Smartdesk.Functions.getOption("core.serversmptuser"), Smartdesk.Functions.getOption("core.serversmptpassword"));
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(Smartdesk.Functions.getOption("core.serversmpt"),Smartdesk.Functions.getOption("core.serversmptport"));
        client.Host = Smartdesk.Functions.getOption("core.serversmpt");
        client.Port = Smartdesk.Functions.getOption("core.serversmptport");
        client.UseDefaultCredentials = false;
        client.EnableSsl = Smartdesk.Functions.getOption("core.serversmptssl");
        client.Credentials = mailAuthentication;
        client.Send(mail);
        return true;
    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}

}
