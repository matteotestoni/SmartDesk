using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        string strSorgente = "";

        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("Forms",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("Forms");
            }
            strSorgente = Smartdesk.Current.Request("sorgente");
            switch (strSorgente)
            {
                case "scheda-Forms":
                    strRedirect = "/admin/view.aspx?CoreModules_Ky=16&CoreEntities_Ky=146&CoreGrids_Ky=96";
                    break;
                case "elenco-Forms":
                    strRedirect = "/admin/view.aspx?CoreModules_Ky=16&CoreEntities_Ky=146&CoreGrids_Ky=96";
                    break;
                default:
                    strRedirect = "/admin/view.aspx?CoreModules_Ky=16&CoreEntities_Ky=146&CoreGrids_Ky=96";
                    break;
            }
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}