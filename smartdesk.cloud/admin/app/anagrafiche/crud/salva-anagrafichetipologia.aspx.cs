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
            strKy = Smartdesk.Functions.SqlWriteKey("AnagraficheTipologia");
            strRedirect = "/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=22&CoreGrids_Ky=5";
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
