using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify){
            strKy = Smartdesk.Functions.SqlWriteKey("AsteEsperimentiEsiti");
            strRedirect = "/admin/view.aspx?CoreModules_Ky=5&CoreEntities_Ky=67&CoreGrids_Ky=55";
            Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}