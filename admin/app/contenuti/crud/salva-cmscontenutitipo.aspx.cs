using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
    	string strSorgente = Smartdesk.Current.Request("sorgente");
        if (Smartdesk.Login.Verify)
        {
            strKy = Smartdesk.Functions.SqlWriteKey("CMSContenutiTipo");
            strRedirect="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=187&CoreGrids_Ky=177";
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}