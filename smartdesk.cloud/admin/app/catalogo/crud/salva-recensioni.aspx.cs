using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
            strKy = Smartdesk.Functions.SqlWriteKey("Recensioni");
            strRedirect = "/admin/form.aspx?CoreModules_Ky=8&CoreEntities_Ky=211&CoreGrids_Ky=219&CoreForms_Ky=124&salvato=salvato&Recensioni_Ky=" + strKy;
	          Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}