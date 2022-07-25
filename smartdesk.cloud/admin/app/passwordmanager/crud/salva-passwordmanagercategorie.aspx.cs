using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
            strKy = Smartdesk.Functions.SqlWriteKey("PasswordmanagerCategorie");
            strRedirect = "/admin/form.aspx?CoreModules_Ky=30&CoreEntities_Ky=167&CoreGrids_Ky=154&CoreForms_Ky=61&custom=0&azione=edit&salvato=salvato&PasswordmanagerCategorie_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}