using System;
using System.Data;

  public partial class _Default : System.Web.UI.Page 
	{
    public string strAzione = "";
    
    public DataTable dtProvince;
    public int intNumRecords = 0;
    public DataTable dtLogin;
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      string strRegioni_Ky = "";
      
	  
      if (Smartdesk.Login.Verify){
		dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());       
		strAzione = Request["azione"];
		strRegioni_Ky=Request["Regioni_Ky"];
        strKy = Smartdesk.Functions.SqlWriteKey("Province");
		Response.Redirect("/admin/form.aspx?CoreModules_Ky=12&CoreEntities_Ky=7&CoreGrids_Ky=8&CoreForms_Ky=155&salvato=salvato&azione=edit&Regioni_Ky=" + strRegioni_Ky + " &Province_Ky=" + strKy);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
