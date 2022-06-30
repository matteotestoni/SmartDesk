using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
          strKy = Smartdesk.Functions.SqlWriteKey("LeadTag");
          strRedirect = "/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=192&CoreGrids_Ky=200";
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}