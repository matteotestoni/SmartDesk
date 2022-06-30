using System;
using System.Configuration;
using System.Web;
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
    public DataTable dtPriorita;
    public string strAzione = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());       
	  	  strKy = Smartdesk.Functions.SqlWriteKey("Priorita");
          Response.Redirect("/admin/view.aspx?CoreModules_Ky=12&CoreEntities_Ky=10&CoreGrids_Ky=11");
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
     
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
