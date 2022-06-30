using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    public bool boolAdmin = false;
    public int intNumRecords = 0;
    public DataTable dtUtenti;
    public string strUtenti_Ky = "";
    public string strAziende_Ky = "";
    public string strEmail = "";
    public string strPassword = "";
    public string strErrore = "";
    public string strHome = "";
    public string strWHERENet = "";
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strReturnUrl = "";
    public bool boolSSL = false;
    public bool boolPersistCookie = false;
    public FormsAuthenticationTicket ticket;
    public FormsAuthenticationTicket ticketAzienda;

    protected void Page_Load(object sender, EventArgs e)
    {
        boolSSL = Request.IsSecureConnection;
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
        
        strEmail = Request["email"];
        strPassword = Request["password"];
        strReturnUrl = Request["ReturnUrl"];
        //Response.Write(Request["chkPersistCookie"]);
        if (Request["chkPersistCookie"]!=null && Request["chkPersistCookie"]=="1"){
          boolPersistCookie = true;
        }else{
          boolPersistCookie = false;
        }
        if (strEmail != null && strPassword != null)
        {
            strEmail = StripHTML(strEmail);
            strPassword = StripHTML(strPassword);
            // SQL 
            Smartdesk.Sql sql = new Smartdesk.Sql()
            {
                sqlWhere = { { "Utenti_Email", strEmail } }
            };
            // ADD Where Condiction
            //sql.sqlWhere.Add("Utenti_Email", strEmail);

            // UTENTI 
            Smartdesk.Data Utenti = new Smartdesk.Data()
            {
                Table = Smartdesk.Sql.SQLReadTableViewWhere("Utenti", "Utenti_Vw", sql.sqlWhere)
            };
            if (Utenti.Table.Rows.Count > 0)
            {
                if (Utenti.Field("Utenti_Password") == strPassword)
                {
                    if (Utenti.Field("Utenti_Attivo").Equals("True"))
                    {
                        boolAdmin = (Utenti.Field("Utenti_Admin")).Equals(true);
                        strUtenti_Ky = Utenti.Field("Utenti_Ky");
                        FormsAuthentication.SetAuthCookie(strUtenti_Ky, true, "/admin");
                        if (boolPersistCookie){
                          ticket = new FormsAuthenticationTicket(2, "rswcrm", DateTime.Now, DateTime.Now.AddDays(360), boolPersistCookie, strUtenti_Ky, "/admin");
                        }else{
                          ticket = new FormsAuthenticationTicket(2, "rswcrm", DateTime.Now, DateTime.Now, boolPersistCookie, strUtenti_Ky, "/admin");
                        }
                        string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                        System.Web.HttpCookie authCookie = new System.Web.HttpCookie("rswcrm", encryptedTicket);
                        authCookie.Secure = true;
                        if (boolPersistCookie){
                          authCookie.Expires = DateTime.Now.AddDays(360);
                        }
                        Response.Cookies.Add(authCookie);
                        
                        strAziende_Ky = Utenti.Field("Aziende_Ky");
                        FormsAuthentication.SetAuthCookie(strUtenti_Ky, true, "/area-clienti");
                        if (boolPersistCookie){
                          ticketAzienda = new FormsAuthenticationTicket(2, "rswcrm-az", DateTime.Now, DateTime.Now.AddDays(360), boolPersistCookie, Utenti.Field("Aziende_Ky"), FormsAuthentication.FormsCookiePath);
                        }else{
                          ticketAzienda = new FormsAuthenticationTicket(2, "rswcrm-az", DateTime.Now, DateTime.Now, boolPersistCookie, Utenti.Field("Aziende_Ky"), FormsAuthentication.FormsCookiePath);
                        }
                        string encryptedTicketAzienda = FormsAuthentication.Encrypt(ticketAzienda);
                        System.Web.HttpCookie authCookieAzienda = new System.Web.HttpCookie("rswcrm-az", encryptedTicketAzienda);
                        authCookieAzienda.Secure = true;
                        if (boolPersistCookie){
                          authCookieAzienda.Expires = DateTime.Now.AddDays(360);
                        }
                        Response.Cookies.Add(authCookieAzienda);
                        
                        tracciaLogin(strUtenti_Ky);
                        if (strReturnUrl != null && strReturnUrl.Length > 0)
                        {
                            Response.Redirect(strReturnUrl);
                        }
                        else
                        {
                            strHome = "/admin/" + Utenti.Field("UtentiGruppi_Home").ToString();
                            Response.Redirect(strHome);
                        }
                    }
                    else
                    {
                        strErrore = "Utente inesistente o Password errata o Utente non attivo";
                        Response.Redirect(Smartdesk.Current.LoginPageRoot + "?errore=nonattivo&strErrore=" + strErrore );
                    }
                }
                else
                {
                    strErrore = "Utente inesistente o Password errata o Utente non attivo";
                    Response.Redirect(Smartdesk.Current.LoginPageRoot + "?errore=passworderrata&strErrore=" + strErrore );
                }
            }
            else
            {
                strErrore = "Utente inesistente o Password errata o Utente non attivo";
                Response.Redirect(Smartdesk.Current.LoginPageRoot + "?errore=nessunutente&strErrore="+ strErrore );
            }
        }
        else
        {
            strErrore = "Utente inesistente o Password errata o Utente non attivo";
            Response.Redirect(Smartdesk.Current.LoginPageRoot + "?errore=datinoninseriti&strErrore=" + strErrore);
        }
    }

    protected void tracciaLogin(string strUtenti_Ky)
    {
        string strSQL = "";
        string strIP = "";
        string strCookie = "";
        string strUserAgent = "";

        strIP = Request.ServerVariables["REMOTE_ADDR"];
        strUserAgent = Request.ServerVariables["HTTP_USER_AGENT"];
        strCookie = Request.ServerVariables["HTTP_COOKIE"];

        strSQL = "INSERT INTO UtentiLog (Utenti_Ky, UtentiLog_IP, UtentiLog_UserAgent, UtentiLog_Cookie, UtentiLog_Data, UtentiLog_UserInsert,UtentiLog_DateInsert) VALUES (" + strUtenti_Ky + ", '" + strIP + "', '" + strUserAgent + "', '" + strCookie + "' ,GETDATE()," + strUtenti_Ky + ",GETDATE())";
        Response.Write(strSQL);
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
    }

    public static string StripHTML(string htmlString)
    {
        string strPattern;
        string strReturn;
        if (htmlString != null)
        {
            strPattern = @"<(.|\n)*?>";
            strReturn = Regex.Replace(htmlString, strPattern, string.Empty);
            return strReturn;
        }
        else
        {
            return string.Empty;
        }
    }
}
