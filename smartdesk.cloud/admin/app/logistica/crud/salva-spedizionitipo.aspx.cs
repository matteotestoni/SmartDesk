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
			if (Smartdesk.Current.Request("SpedizioniTipo_Default") == "") frm.Add("SpedizioniTipo_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("SpedizioniTipo", frm);
			if (Smartdesk.Current.Request("SpedizioniTipo_Default")=="True" || Smartdesk.Current.Request("SpedizioniTipo_Default").Equals(true)){
		        strSQL = "UPDATE SpedizioniTipo SET SpedizioniTipo_Default=0 WHERE SpedizioniTipo_Ky<>" + strKy;
		        //Response.Write()
				new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
			}
            strRedirect = "/admin/view.aspx?CoreModules_Ky=18&CoreEntities_Ky=133&CoreGrids_Ky=100";
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}