using System;
using System.Net.Mail;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{    
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    
    static bool mailSent = false;
    public DataTable dtAnagrafiche;
    public int intNumRecords = 0;
    public string strWHERENet = "";
	public string strAnagrafiche_Ky = "";

    protected void Page_Load(object sender, EventArgs e){
      
      strAnagrafiche_Ky = Request["Anagrafiche_Ky"];
      strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky;
      dtAnagrafiche = new DataTable("Anagrafiche");
      dtAnagrafiche = Smartdesk.Sql.getTablePage("Anagrafiche", null, "Anagrafiche_Ky", strWHERENet, "Anagrafiche_EmailContatti", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      if (dtAnagrafiche.Rows.Count>0){
        inviaContatto();
        Response.Redirect("/contatto-annuncio-inviato.aspx");
      }
    }

    public bool inviaContatto()
    {
        string strNome = "";
        string strTelefono = "";
        string strEmail = "";
        string strMessaggio = "";
		string strConsenso = "";
		string strAnnunci_Ky = "";
		string strProteggi = "";
        
        strNome = Request["nome"];
        strTelefono = Request["telefono"];
        strEmail = Request["email"];
        strMessaggio = Request["messaggio"];
        strConsenso = Request["consenso"];
        strAnnunci_Ky = Request["Annunci_Ky"];
        strProteggi = Request["proteggi"];
		
        bool output = false;
        string strHTML="";
        string strCorpo="";
        string strTo = dtAnagrafiche.Rows[0]["Anagrafiche_EmailContatti"].ToString();
        string strFrom = "noreply@astebusiness.it";
        string strSubject = "[ASTEBUSINESS] Contatto dal sito";
        strCorpo ="<table width='100%' border='0' cellpadding='2' cellspacing='1' bgcolor='#000000'>";
        strCorpo +="<tr><td bgcolor=\"#FFFFFF\">";
  	    strCorpo += "<b>Nome e Cognome:</b> " + strNome + "<br />";
        strCorpo += "<b>Telefono:</b> " + strTelefono + "<br />";
        strCorpo += "<b>Email:</b> " + strEmail + "<br />";
        strCorpo += "<b>Messaggio:</b> " + strMessaggio + "<br />";
        strCorpo +="</td></tr></table>";
        strHTML +="<HTML>";
        strHTML +="<head>";
        strHTML +="<meta http-equiv=\"Content-Type\" content=\"text/HTML; charset=iso-8859-15\">";
        strHTML +="<title>astebusiness.it</title><style>";
        strHTML +="a.arancio:link, a.arancio:visited { color: #ff7300; font-weight: bold; text-decoration: none }";
        strHTML +="a.arancio:hover { color: #000000; font-weight: bold; text-decoration: none }";
        strHTML +="a.bianco:link, a.bianco:visited { color: #FFFFFF; font-weight: bold; text-decoration: none }";
        strHTML +="a.bianco:hover { color: #ff7300; font-weight: bold; text-decoration: none }";
        strHTML +="a.nero:link, a.nero:visited { color: #000000; text-decoration: none; font-size:10px }";
        strHTML +="a.nero:hover { color: #ff7300; text-decoration: none; font-size:10px }";
        strHTML +="</style>";
        strHTML +="</head>";
        strHTML +="<body link=\"#0066CC\" vlink=\"#0066CC\" alink=\"#0066CC\">";
        strHTML +="<font color=\"#555555\" size=\"2\" face=\"Verdana, Arial, Helvetica, sans-serif\">";
        strHTML +=strCorpo;
        strHTML +="</font>";
        strHTML +="</body>";
        strHTML +="</HTML>";
        string strBody = strHTML;
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.From = new MailAddress(strFrom);
        mail.To.Add(new MailAddress(strTo));
      	mail.Bcc.Add(new System.Net.Mail.MailAddress(Smartdesk.Functions.getOption("core.webmasteremail")));
        mail.Subject = strSubject;
        mail.Body = strBody;
        mail.IsBodyHtml = true;
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(Smartdesk.Functions.getOption("core.serversmpt"),Convert.ToInt32(Smartdesk.Functions.getOption("core.serversmptport")));
        client.Port=Convert.ToInt32(Smartdesk.Functions.getOption("core.serversmptport"));
        System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(Smartdesk.Functions.getOption("core.serversmptuser"), Smartdesk.Functions.getOption("core.serversmptpassword"));
        client.UseDefaultCredentials = false;
        client.Credentials = mailAuthentication;
        client.EnableSsl = Convert.ToBoolean(Smartdesk.Functions.getOption("core.serversmptssl"));
        client.Send(mail);
        output=true;
        return output;
    }
}
