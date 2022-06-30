using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("Passwordmanager",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("Passwordmanager");
            }
            switch (strSorgente)
            {
                case "scheda-anagrafiche":
                    strRedirect = "/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=" + Smartdesk.Current.Request("Anagrafiche_Ky"); ;
                    break;
                default:
                    strRedirect = "/admin/view.aspx?CoreModules_Ky=30&CoreEntities_Ky=166&CoreGrids_Ky=153";
                    break;
            }

        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}
