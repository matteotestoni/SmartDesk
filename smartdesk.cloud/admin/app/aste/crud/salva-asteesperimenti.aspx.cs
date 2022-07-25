using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strAste_Ky = "";
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
            strAste_Ky =  Smartdesk.Current.Form("Aste_Ky");
            strKy = Smartdesk.Functions.SqlWriteKey("AsteEsperimenti");
            strRedirect = "/admin/app/aste/scheda-aste.aspx?salvato=salvato&Aste_Ky=" + strAste_Ky + "&AsteEsperimenti_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}
