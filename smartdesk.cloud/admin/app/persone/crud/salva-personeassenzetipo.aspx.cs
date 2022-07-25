using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
            strKy = Smartdesk.Functions.SqlWriteKey("PersoneAssenzeTipo");
            strRedirect = "/admin/form.aspx?CoreModules_Ky=22&CoreEntities_Ky=40&CoreGrids_Ky=116&CoreForms_Ky=113&azione=edit&PersoneAssenzeTipo_Ky=" + strKy;
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}