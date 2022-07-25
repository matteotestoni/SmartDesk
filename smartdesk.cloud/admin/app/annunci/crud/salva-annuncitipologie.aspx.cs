using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
            strKy = Smartdesk.Functions.SqlWriteKey("AnnunciTipologie");
            strRedirect = "/admin/view.aspx?CoreModules_Ky=3&CoreEntities_Ky=59&CoreGrids_Ky=49";
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
