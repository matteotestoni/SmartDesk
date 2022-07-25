using System;
using System.Data;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    public bool fCaricato = false;
    public string strAzione = "";
    public string strWHERENet = "";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public DataTable dtAliquoteIVA;
    public int intNumRecords = 0;
    public DataTable dtLogin;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      string strSQL = "";     
      bool boolAjax = false;
      string strFunzione = "";

      if (Smartdesk.Login.Verify){
        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());        
				strAzione = Request["azione"];
				Dictionary<string, object> frm = new Dictionary<string, object>();
				if (Smartdesk.Current.Request("AliquoteIVA_Predefinita") == "") frm.Add("AliquoteIVA_Predefinita", false);
			  Smartdesk.Amministrazione.AliquoteIVA_BeforeSave();
		    strKy = Smartdesk.Functions.SqlWriteKey("AliquoteIVA", frm);
				strFunzione=Smartdesk.Amministrazione.AliquoteIVA_AfterSave(strKy);
 	      Response.Redirect("/admin/view.aspx?CoreModules_Ky=2&CoreEntities_Ky=32&CoreGrids_Ky=37");
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
