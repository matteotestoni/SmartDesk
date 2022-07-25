using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
            strKy = Smartdesk.Functions.SqlWriteKey("SitiWebTipo");
            strRedirect = "/admin/form.aspx?CoreModules_Ky=27&CoreEntities_Ky=144&CoreGrids_Ky=128&CoreForms_Ky=115&salvato=salvato&SitiWebTipo_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}