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
			if (Smartdesk.Current.Request("ProdottiMateriale_Default") == "") frm.Add("ProdottiMateriale_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("ProdottiMateriale");
			if (Smartdesk.Current.Request("ProdottiMateriale_Default")=="True" || Smartdesk.Current.Request("ProdottiMateriale_Default").Equals(true)){
		        strSQL = "UPDATE ProdottiMateriale SET ProdottiMateriale_Default=0 WHERE ProdottiMateriale_Ky<>" + strKy;
		        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
			}
            strRedirect = "/admin/view.aspx?CoreModules_Ky=8&CoreEntities_Ky=90&CoreGrids_Ky=73";
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}