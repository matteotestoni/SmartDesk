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
			if (Smartdesk.Current.Request("ProdottiColore_Default") == "") frm.Add("ProdottiColore_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("ProdottiColore",frm);
      			if (Smartdesk.Current.Request("ProdottiColore_Default")=="True" || Smartdesk.Current.Request("ProdottiColore_Default").Equals(true)){
      		        strSQL = "UPDATE ProdottiColore SET ProdottiColore_Default=0 WHERE ProdottiColore_Ky<>" + strKy;
      		        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
      			}
            strRedirect = "/admin/form.aspx?CoreModules_Ky=8&CoreEntities_Ky=86&CoreForms_Ky=110&salvato=salvato&ProdottiColore_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}