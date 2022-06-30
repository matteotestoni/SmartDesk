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
			if (Smartdesk.Current.Request("SpedizioniZone_Default") == "") frm.Add("SpedizioniZone_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("SpedizioniZone", frm);
			if (Smartdesk.Current.Request("SpedizioniZone_Default")=="True" || Smartdesk.Current.Request("SpedizioniZone_Default").Equals(true)){
		        strSQL = "UPDATE SpedizioniZone SET SpedizioniZone_Default=0 WHERE SpedizioniZone_Ky<>" + strKy;
		        //Response.Write()
				new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
			}
            strRedirect = "/admin/view.aspx?CoreModules_Ky=18&CoreEntities_Ky=135&CoreGrids_Ky=102";
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}