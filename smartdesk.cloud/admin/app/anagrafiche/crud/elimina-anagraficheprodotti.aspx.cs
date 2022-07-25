using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        string strAnagrafiche_Ky = "";

        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("AnagraficheProdotti",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("AnagraficheProdotti");
            }
            strAnagrafiche_Ky = Smartdesk.Current.Request("Anagrafiche_Ky");
            switch (strSorgente)
            {
                case "scheda-anagrafiche":
                    Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky);
                    break;
                default:
                    Response.Redirect("/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=226&CoreGrids_Ky=238");
                    break;
            }
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}
