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
			if (Smartdesk.Current.Request("Magazzini_Default") == "") frm.Add("Magazzini_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("Magazzini", frm);
			if (Smartdesk.Current.Request("Magazzini_Default")=="True" || Smartdesk.Current.Request("Magazzini_Default").Equals(true)){
		        strSQL = "UPDATE Magazzini SET Magazzini_Default=0 WHERE Magazzini_Ky<>" + strKy;
		        //Response.Write()
				new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
			}
            strRedirect = "/admin/view.aspx?CoreModules_Ky=18&CoreEntities_Ky=136&CoreGrids_Ky=103";
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}