using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e){
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        string strCoreForms_Ky = Smartdesk.Current.Request("CoreForms_Ky");
        string strCoreEntities_Ky = Smartdesk.Current.Request("CoreEntities_Ky");
        string strCoreModules_Ky = Smartdesk.Current.Request("CoreModules_Ky");
        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("UsergroupsForms",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("UsergroupsForms");
            }
            switch (strSorgente)
            {
                case "scheda-coreforms":
                    strRedirect = "/admin/app/sdk/scheda-CoreForms.aspx?CoreForms_Ky=" + strCoreForms_Ky + "&CoreModules_Ky=" + strCoreModules_Ky + "&CoreEntities_Ky=" + strCoreEntities_Ky;
                    break;
                default:
                    strRedirect="/admin/view.aspx?CoreModules_Ky=26&CoreEntities_Ky=250&CoreGrids_Ky=271";
                    break;
            }
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}
