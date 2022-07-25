using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public DataTable dtLogin;
    public string strAnagrafiche_Ky="";
    public string strEmail="";
    public string strPassword="";
    public string strErrore="";
    public string strWHERENet="";
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public DataTable dtProdottiVetrina;
    public string strConnNet = "";
    public int intRecxPag = 20;
    public int intNumPagine=1;
    public int i = 0;
    
    protected void Page_Load(object sender, EventArgs e){
        string strFROMNet = "";
        string strORDERNet = "";
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
        
        strEmail=Smartdesk.Current.Request("email");
        strPassword=Smartdesk.Current.Request("password");
        if (strEmail!=null && strPassword!=null){
			        strORDERNet = "Anagrafiche_Ky";
			        strFROMNet = "Anagrafiche";
			        strWHERENet = "Anagrafiche_EmailContatti ='" + strEmail +"'";
			        dtLogin = new DataTable("Anagrafiche");
			        dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			        if (dtLogin.Rows.Count>0){
			          if (dtLogin.Rows[0]["Anagrafiche_Password"].ToString()==strPassword){
			            if (dtLogin.Rows[0]["Anagrafiche_Disdetto"].Equals(false)){
			                strAnagrafiche_Ky = dtLogin.Rows[0]["Anagrafiche_Ky"].ToString();
							FormsAuthentication.SetAuthCookie(strAnagrafiche_Ky, true);
							FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "rswcrm-cliente", DateTime.Now, DateTime.Now.AddMinutes(600), true, strAnagrafiche_Ky, FormsAuthentication.FormsCookiePath);
							string encryptedTicket = FormsAuthentication.Encrypt(ticket);
							System.Web.HttpCookie authCookie = new System.Web.HttpCookie("rswcrm-cliente", encryptedTicket);
							authCookie.Secure = true;
							Response.Cookies.Add(authCookie);
                        	tracciaLogin(strAnagrafiche_Ky);
			                Response.Redirect("/area-clienti/home.aspx");
			            }else{
			              strErrore="Utente non attivo";
						        Response.Redirect("/area-clienti/Default.aspx?errore=nonattivo");
			            }
			          }else{
			            strErrore="Password errata";
						       Response.Redirect("/area-clienti/Default.aspx?errore=passworderrata");
			          }
			        }else{
			          strErrore="Utente inesistente";
						    Response.Redirect("/area-clienti/Default.aspx?errore=nessunutente");
			        }
	   }else{
      		Response.Redirect("/area-clienti/Default.aspx?errore=datinoninseriti");
	   }
    }

    protected void tracciaLogin(string strAnagrafiche_Ky)
    {
        string strSQL = "";
        string strIP = "";
        string strCookie = "";
        string strUserAgent = "";

        strIP = Request.ServerVariables["REMOTE_ADDR"];
        strUserAgent = Request.ServerVariables["HTTP_USER_AGENT"];
        strCookie = Request.ServerVariables["HTTP_COOKIE"];

        strSQL = "INSERT INTO AnagraficheLog (Anagrafiche_Ky, AnagraficheLog_Descrizione, AnagraficheLog_Valore, AnagraficheLog_IP, AnagraficheLog_UserAgent, AnagraficheLog_Cookie, AnagraficheLog_Data, AnagraficheLog_UserInsert,AnagraficheLog_DateInsert) VALUES (" + strAnagrafiche_Ky + ",'login','ok','" + strIP + "', '" + strUserAgent + "', '" + strCookie + "' ,GETDATE(),0,GETDATE())";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
    }

	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
