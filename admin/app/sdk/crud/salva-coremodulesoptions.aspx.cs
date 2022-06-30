using System;
using System.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{

    public int intNumRecords = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
    	string strKy="";
      string strWHERENet = "";
      string strORDERNet = "";
      string strFROMNet = "";
      DataTable dtCoreModulesOptionsValue;
      DataTable dtCoreModulesOptions;
        string strSQL="";

      if (Smartdesk.Login.Verify){
    		Dictionary<string, object> frm = new Dictionary<string, object>();
    		strKy = Smartdesk.Functions.SqlWriteKey("CoreModulesOptions");
        
        strWHERENet="CoreModulesOptions_Ky=" + strKy;
        strORDERNet = "CoreModulesOptions_Ky";
        strFROMNet = "CoreModulesOptions";          
        dtCoreModulesOptions = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptions_Ky", strWHERENet, strORDERNet, 1, 1, Smartdesk.Config.Sql.ConnectionReadOnly);

        strWHERENet="CoreModulesOptions_Code='" + dtCoreModulesOptions.Rows[0]["CoreModulesOptions_Code"].ToString() + "'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";          
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1, Smartdesk.Config.Sql.ConnectionReadOnly);
        if (dtCoreModulesOptionsValue.Rows.Count<1){
          strSQL="INSERT INTO CoreModulesOptionsValue (CoreModulesOptions_Code,CoreModulesOptionsValue_Value) VALUES ('" + dtCoreModulesOptions.Rows[0]["CoreModulesOptions_Code"].ToString() + "','')";
          //Response.Write(strSQL);
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        }


    		Response.Redirect("/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=229&CoreGrids_Ky=241&CoreForms_Ky=163&custom=0&azione=edit&salvato=salvato&CoreModulesOptions_Ky=" + strKy);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
