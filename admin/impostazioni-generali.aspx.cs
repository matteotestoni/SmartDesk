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
    public string strAzione = "modifica";
    
    public string strH1 = "Impostazioni";
    public DataTable dtCoreModules;
    public DataTable dtCoreGrids;
    public string strActive="";
    public string strWHERE="";

    protected void Page_Load(object sender, EventArgs e)
    {
		
      //verifico se ho fatto login		
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strAzione = Request["azione"];
          dtCoreModules = Smartdesk.Sql.getTablePage("CoreModules", null, "CoreModules_Ky", "", "CoreModules_Order", 1, 500,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
