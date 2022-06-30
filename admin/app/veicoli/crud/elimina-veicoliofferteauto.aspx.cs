using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        string strVeicoliOfferte_Ky=Smartdesk.Current.Request("VeicoliOfferte_Ky");

        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("VeicoliOfferteAuto",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("VeicoliOfferteAuto");
            }
            strRedirect="/admin/app/veicoli/scheda-VeicoliOfferte.aspx?custom=1&azione=edit&VeicoliOfferte_Ky=" + strVeicoliOfferte_Ky;
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}