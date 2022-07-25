using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
            strKy = Smartdesk.Functions.SqlWriteKey("VeicoliCarrozzeria");
            strRedirect = "/admin/form.aspx?CoreModules_Ky=29&CoreEntities_Ky=112&CoreGrids_Ky=133&custom=0&azione=edit&VeicoliCarrozzeria_Ky=" + strKy;
	        	Response.Redirect(strRedirect);
        }else{
          	Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}