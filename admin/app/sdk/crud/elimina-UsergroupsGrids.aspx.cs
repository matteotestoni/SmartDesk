using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e){
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        string strCoreGrids_Ky = Smartdesk.Current.Request("CoreGrids_Ky");
        string strCoreEntities_Ky = Smartdesk.Current.Request("CoreEntities_Ky");
        string strCoreModules_Ky = Smartdesk.Current.Request("CoreModules_Ky");
        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("UsergroupsGrids",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("UsergroupsGrids");
            }
            switch (strSorgente)
            {
                case "scheda-coregrids":
                    strRedirect = "/admin/app/sdk/scheda-CoreGrids.aspx?CoreGrids_Ky=" + strCoreGrids_Ky + "&CoreModules_Ky=" + strCoreModules_Ky + "&CoreEntities_Ky=" + strCoreEntities_Ky;
                    break;
                default:
                    //strRedirect="/admin/view.aspx?CoreModules_Ky=26&CoreEntities_Ky=251&CoreGrids_Ky=272";
                    break;
            }
        	  Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}
