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
			if (Smartdesk.Current.Request("AsteTipo_Default") == "") frm.Add("AsteTipo_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("AsteTipo", frm);
			if (Smartdesk.Current.Request("AsteTipo_Default")=="True" || Smartdesk.Current.Request("AsteTipo_Default").Equals(true)){
		        strSQL = "UPDATE AsteTipo SET AsteTipo_Default=0 WHERE AsteTipo_Ky<>" + strKy;
		        //Response.Write()
				new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
			}
            strRedirect = "/admin/view.aspx?CoreModules_Ky=5&CoreEntities_Ky=71&CoreGrids_Ky=59";
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}