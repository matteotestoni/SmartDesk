using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSQL = "";
        if (Smartdesk.Login.Verify)
        {
			Dictionary<string, object> frm = new Dictionary<string, object>();
			if (Smartdesk.Current.Request("AsteNatura_Default") == "") frm.Add("AsteNatura_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("AsteNatura", frm);
			if (Smartdesk.Current.Request("AsteNatura_Default")=="True" || Smartdesk.Current.Request("AsteNatura_Default").Equals(true)){
		        strSQL = "UPDATE AsteNatura SET AsteNatura_Default=0 WHERE AsteNatura_Ky<>" + strKy;
		        //Response.Write()
				new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
			}
            strRedirect = "/admin/view.aspx?CoreModules_Ky=5&CoreEntities_Ky=68&CoreGrids_Ky=56";
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}