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
                Smartdesk.Functions.SqlDeleteKeyIn("AsteCauzioni",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("AsteCauzioni");
            }
            switch (strSorgente)
            {
                case "scheda-aste":
                    strRedirect = "/admin/app/aste/scheda-aste.aspx?Aste_Ky=" + strAste_Ky;
                    break;
                case "elenco-aste":
                    strRedirect = "/admin/view.aspx?CoreModules_Ky=5&CoreEntities_Ky=60&CoreGrids_Ky=50&Aste_Ky=" + strAste_Ky;
                    break;
                case "elenco-cauzioni":
                    strRedirect = "/admin/app/aste/elenco-astecauzioni.aspx?CoreModules_Ky=5&CoreEntities_Ky=62&CoreGrids_Ky=52&Aste_Ky=" + strAste_Ky;
                    break;
                case "scheda-cauzioni":
                    strRedirect = "/admin/app/aste/scheda-astecauzioni.aspx?Aste_Ky=" + strAste_Ky;
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
