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
            strKy = Smartdesk.Functions.SqlWriteKey("RecensioniTipo");
            strRedirect = "/admin/form.aspx?CoreModules_Ky=8&CoreEntities_Ky=212&CoreGrids_Ky=220&CoreForms_Ky=125&custom=0&salvato=salvato&RecensioniTipo_Ky=" + strKy;
	          Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}