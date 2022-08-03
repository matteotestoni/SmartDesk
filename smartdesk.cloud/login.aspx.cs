using System;
using System.Data;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    public string strConnNet = "";
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin = "";
    public DataTable dtLogin;
    public bool boolLogin = false;
    public bool boolAdmin = false;
    public string strUtentiLogin = "";
    public bool boolSSL = false;
    public string strUrl = "";
    public string strErrore = "";
    public string strIDErrore = "";
    public string strUtenti_Ky = "";
    public string strAziende_Ky = "";
    public string strReturnUrl = "";
    public string strHome = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string strWHERENet = "";
        string strFROMNet = "";
        string strORDERNet = "";

        boolSSL = Request.IsSecureConnection;
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
        strConnNet = Smartdesk.Config.Sql.ConnectionReadOnly;  //Smartdesk.Config.Sql.ConnectionReadOnly;
        strIDErrore = Smartdesk.Current.Request("errore");
        strErrore = Smartdesk.Current.Request("strErrore");
        strReturnUrl = Smartdesk.Current.Request("ReturnUrl");
        if (Context.Request.Cookies.Count > 0)
        {
            if (Context.Request.Cookies["rswcrm"] != null)
            {
                if (Context.Request.Cookies["rswcrm"].Value != null)
                {
                    try
                    {
                        strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm"].Value)).UserData;
                        //Response.Write(strUtentiLogin);
                        strWHERENet = "Utenti_Ky =" + strUtentiLogin;
                        strORDERNet = "Utenti_Ky";
                        strFROMNet = "Utenti_Vw";
                        dtLogin = new DataTable("Login");
                        dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1, 1, strConnNet, out this.intNumRecords);
                        if (dtLogin.Rows.Count > 0)
                        {
                            boolLogin = true;
                            boolAdmin = (dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
                            strUtenti_Ky = dtLogin.Rows[0]["Utenti_Ky"].ToString();
                            FormsAuthentication.SetAuthCookie(strUtenti_Ky, false);
                            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "rswcrm", DateTime.Now, DateTime.Now.AddMinutes(600), true, dtLogin.Rows[0]["Utenti_Ky"].ToString(), FormsAuthentication.FormsCookiePath);
                            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                            System.Web.HttpCookie authCookie = new System.Web.HttpCookie("rswcrm", encryptedTicket);
                            authCookie.Secure = true;
                            Response.Cookies.Add(authCookie);
                            //azienda
                            strAziende_Ky = dtLogin.Rows[0]["Aziende_Ky"].ToString();
                            FormsAuthenticationTicket ticketAzienda = new FormsAuthenticationTicket(1, "rswcrm-az", DateTime.Now, DateTime.Now.AddMinutes(600), true, dtLogin.Rows[0]["Aziende_Ky"].ToString(), FormsAuthentication.FormsCookiePath);
                            string encryptedTicketAzienda = FormsAuthentication.Encrypt(ticketAzienda);
                            System.Web.HttpCookie authCookieAzienda = new System.Web.HttpCookie("rswcrm-az", encryptedTicketAzienda);
                            authCookieAzienda.Secure = true;
                            Response.Cookies.Add(authCookieAzienda);
                            //tracciamento
                            if (strReturnUrl != null && strReturnUrl.Length > 0)
                            {
                                //Response.Redirect(strReturnUrl);
                            }
                            else
                            {
                                strHome = "/admin/" + dtLogin.Rows[0]["UtentiGruppi_Home"].ToString();
                                Response.Redirect(strHome);
                            }
                        }
                        else
                        {
                            strErrore = "Nessun utente con id=" + strUtentiLogin;
                            boolLogin = false;
                            boolAdmin = false;
                        }
                    }
                    catch
                    {
                        strErrore = "Impossibile leggere il cookie";
                        boolLogin = false;
                        boolAdmin = false;
                    }
                }
                else
                {
                    strErrore = "";
                    boolLogin = false;
                }
            }
            else
            {
                strErrore = "";
                boolLogin = false;
            }
        }
        else
        {
            //strErrore = "";
            //boolLogin = false;
        }
    }
}
