using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
          strKy = Smartdesk.Functions.SqlWriteKey("LeadTipo");
          strRedirect = "/admin/form.aspx?CoreModules_Ky=20&CoreEntities_Ky=180&CoreGrids_Ky=170&CoreForms_Ky=96&custom=0&azione=edit&LeadTipo_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}