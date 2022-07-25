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
		    if (Smartdesk.Current.Request("PagamentiMetodo_Default") == "") frm.Add("PagamentiMetodo_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("PagamentiMetodo",frm);
            strRedirect = "/admin/view.aspx?CoreModules_Ky=21&CoreEntities_Ky=77&CoreGrids_Ky=112";
      			if (Smartdesk.Current.Request("PagamentiMetodo_Default")=="True" || Smartdesk.Current.Request("PagamentiMetodo_Default").Equals(true)){
    		        strSQL = "UPDATE PagamentiMetodo SET PagamentiMetodo_Default=0 WHERE PagamentiMetodo_Ky<>" + strKy;
    		        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
      			}
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}