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
			if (Smartdesk.Current.Request("ProdottiConsegna_Default") == "") frm.Add("ProdottiConsegna_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("ProdottiConsegna");
			if (Smartdesk.Current.Request("ProdottiConsegna_Default")=="True" || Smartdesk.Current.Request("ProdottiConsegna_Default").Equals(true)){
		        strSQL = "UPDATE ProdottiConsegna SET ProdottiConsegna_Default=0 WHERE ProdottiConsegna_Ky<>" + strKy;
		        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
			}
            strRedirect = "/admin/form.aspx?CoreModules_Ky=18&CoreEntities_Ky=87&CoreGrids_Ky=70&CoreForms_Ky=1&salvato=salvato&ProdottiConsegna_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}