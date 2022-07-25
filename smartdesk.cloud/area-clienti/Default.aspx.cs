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
	  if (Request.Cookies["rswcrm-cliente"]!=null){
          strWHERENet = "Anagrafiche_Ky =" + Smartdesk.Session.CurrentUser.ToString();
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
            Response.Redirect("/area-clienti/home.aspx");
          }else{
            boolAdmin=false;
            Response.Redirect("/area-clienti/login.aspx");
          }
      }else{
        Response.Redirect("/area-clienti/login.aspx");
      }
    }    
    
    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App)
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}
