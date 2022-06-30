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
			if (Smartdesk.Current.Request("MagazziniCausali_Default") == "") frm.Add("MagazziniCausali_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("MagazziniCausali", frm);
			if (Smartdesk.Current.Request("MagazziniCausali_Default")=="True" || Smartdesk.Current.Request("MagazziniCausali_Default").Equals(true)){
		        strSQL = "UPDATE MagazziniCausali SET MagazziniCausali_Default=0 WHERE MagazziniCausali_Ky<>" + strKy;
		        //Response.Write()
				new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
			}
            strRedirect = "/admin/view.aspx?CoreModules_Ky=18&CoreEntities_Ky=137&CoreGrids_Ky=104";
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}