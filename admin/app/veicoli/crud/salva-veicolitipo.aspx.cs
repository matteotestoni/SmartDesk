using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
            strKy = Smartdesk.Functions.SqlWriteKey("VeicoliTipo");
            strRedirect = "/admin/form.aspx?CoreModules_Ky=29&CoreEntities_Ky=129&CoreGrids_Ky=150&custom=0&azione=edit&salvato=salvato&VeicoliTipo_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}
