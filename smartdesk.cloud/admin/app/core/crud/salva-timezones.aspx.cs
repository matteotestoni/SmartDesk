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
           strKy = Smartdesk.Functions.SqlWriteKey("TimeZones");
	          switch (strSorgente){
	            case "scheda-timezones":
	              strRedirect= "/admin/form.aspx?CoreModules_Ky=12&CoreEntities_Ky=6&CoreGrids_Ky=7&CoreForms_Ky=11&custom=0&azione=edit&TimeZones_Ky=" + strKy;
                break;
	            default:
	              strRedirect= "/admin/form.aspx?CoreModules_Ky=12&CoreEntities_Ky=6&CoreGrids_Ky=7&CoreForms_Ky=11&custom=0&azione=edit&TimeZones_Ky=" + strKy;
	              break;
	          }
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}