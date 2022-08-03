using System;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;  
    public string strUrl="";
    public string strErrore="";
    
    public string strHome="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";

	  
	  
      strErrore=Smartdesk.Current.Request("errore");
      if (Request.Cookies["rswcrm"]!=null){
		  
          strWHERENet = "Utenti_Ky =" + Smartdesk.Session.CurrentUser.ToString();
          strORDERNet = "Utenti_Ky";
          strFROMNet = "Utenti_Vw";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            tracciaLogin(Smartdesk.Session.CurrentUser.ToString());
            strHome="/admin/" + dtLogin.Rows[0]["UtentiGruppi_Home"].ToString();
            Response.Redirect(strHome);
          }else{
            boolAdmin=false;
            Response.Redirect("login.aspx");
          }
      }else{
        Response.Redirect("login.aspx");
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
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
    }
}
