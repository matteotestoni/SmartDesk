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
			if (Smartdesk.Current.Request("AsteVendita_Default") == "") frm.Add("AsteVendita_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("AsteVendita", frm);
			if (Smartdesk.Current.Request("AsteVendita_Default")=="True" || Smartdesk.Current.Request("AsteVendita_Default").Equals(true)){
		        strSQL = "UPDATE AsteVendita SET AsteVendita_Default=0 WHERE AsteVendita_Ky<>" + strKy;
		        //Response.Write()
				new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
			}
            strRedirect = "/admin/view.aspx?CoreModules_Ky=5&CoreEntities_Ky=72&CoreGrids_Ky=60";
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}