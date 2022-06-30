using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      string strRedirect = Smartdesk.Current.LoginPageRoot;
      bool boolAjax = false;
        if (Smartdesk.Login.Verify)
        {
            strKy = Smartdesk.Functions.SqlWriteKey("AnagraficheCategorie");
            strRedirect = "/admin/form.aspx?CoreModules_Ky=1&CoreEntities_Ky=23&CoreGrids_Ky=27&CoreForms_Ky=108&custom=0&azione=edit&salvato=salvato&AnagraficheCategorie_Ky=" + strKy;
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
