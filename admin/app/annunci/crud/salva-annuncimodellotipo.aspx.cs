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
            strKy = Smartdesk.Functions.SqlWriteKey("AnnunciModelloTipo");
            strRedirect = "/admin/view.aspx?CoreModules_Ky=3&CoreEntities_Ky=55&CoreGrids_Ky=46";
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
