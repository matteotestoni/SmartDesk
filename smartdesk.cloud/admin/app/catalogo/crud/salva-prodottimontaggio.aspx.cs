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
			      if (Smartdesk.Current.Request("ProdottiMontaggio_Default") == "") frm.Add("ProdottiMontaggio_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("ProdottiMontaggio", frm);
      			if (Smartdesk.Current.Request("ProdottiMontaggio_Default")=="True" || Smartdesk.Current.Request("ProdottiMontaggio_Default").Equals(true)){
      		        strSQL = "UPDATE ProdottiMontaggio SET ProdottiMontaggio_Default=0 WHERE ProdottiMontaggio_Ky<>" + strKy;
      		        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
      			}
            strRedirect = "/admin/view.aspx?CoreModules_Ky=8&CoreEntities_Ky=91&CoreGrids_Ky=74";
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}