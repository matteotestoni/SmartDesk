using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strAste_Ky = Smartdesk.Current.Request("Aste_Ky");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("AsteProxyBid",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("AsteProxyBid");
            }
            switch (strSorgente)
            {
                case "scheda-aste":
                    strRedirect = "/admin/app/aste/scheda-aste.aspx?Aste_Ky=" + strAste_Ky;
                    break;
                case "scheda-asta":
                    strRedirect = "/admin/app/aste/scheda-aste.aspx?Aste_Ky=" + strAste_Ky;
                    break;
                default:
                    strRedirect = "/admin/home.aspx";
                    break;
            }
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}