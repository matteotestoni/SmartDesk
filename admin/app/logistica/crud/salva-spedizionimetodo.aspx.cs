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
			if (Smartdesk.Current.Request("SpedizioniMetodo_Default") == "") frm.Add("SpedizioniMetodo_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("SpedizioniMetodo", frm);
			if (Smartdesk.Current.Request("SpedizioniMetodo_Default")=="True" || Smartdesk.Current.Request("SpedizioniMetodo_Default").Equals(true)){
		        strSQL = "UPDATE SpedizioniMetodo SET SpedizioniMetodo_Default=0 WHERE SpedizioniMetodo_Ky<>" + strKy;
				new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
			}
            strRedirect = "/admin/view.aspx?CoreModules_Ky=18&CoreEntities_Ky=134&CoreGrids_Ky=101";
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}