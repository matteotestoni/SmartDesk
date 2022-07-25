using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      string strRedirect = Smartdesk.Current.LoginPageRoot;
      bool boolAjax = false;
        if (Smartdesk.Login.Verify)
        {
            strKy = Smartdesk.Functions.SqlWriteKey("AnagraficheProdotti");
            strRedirect = "/admin/form.aspx?CoreModules_Ky=1&CoreEntities_Ky=226&CoreGrids_Ky=238&CoreForms_Ky=162&salvato=salvato&AnagraficheProdotti_Ky=" + strKy;
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
