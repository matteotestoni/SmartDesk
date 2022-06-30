using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        string strCoreGridsButtons_Ky = Smartdesk.Current.Request("CoreGridsButtons_Ky");
        string strCoreGrids_Ky = Smartdesk.Current.Request("CoreGrids_Ky");
        string strCoreModules_Ky = Smartdesk.Current.Request("CoreModules_Ky");

        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("CoreGridsButtons",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("CoreGridsButtons");
            }
            strRedirect="/admin/app/sdk/scheda-CoreGrids.aspx?CoreGrids_Ky=" + strCoreGrids_Ky + "&CoreModules_Ky=" + strCoreModules_Ky;
        		Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}