using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string strKy = "";
		string strSQL = "";
		string strRedirect = Smartdesk.Current.LoginPageRoot;
		if (Smartdesk.Login.Verify)
		{
		Dictionary<string, object> frm = new Dictionary<string, object>();
		if (Smartdesk.Current.Request("PagamentiCondizioni_Predefinita") == "") frm.Add("PagamentiCondizioni_Predefinita", false);
		    strKy = Smartdesk.Functions.SqlWriteKey("PagamentiCondizioni",frm);
		    strRedirect = "/admin/view.aspx?CoreModules_Ky=21&CoreEntities_Ky=76&CoreGrids_Ky=111";
			if (Smartdesk.Current.Request("PagamentiCondizioni_Predefinita")=="True" || Smartdesk.Current.Request("PagamentiCondizioni_Predefinita").Equals(true)){
		        strSQL = "UPDATE PagamentiCondizioni SET PagamentiCondizioni_Predefinita=0 WHERE PagamentiCondizioni_Ky<>" + strKy;
		        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
			}
		  Response.Redirect(strRedirect);
		}else{
		  Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}