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
                Smartdesk.Functions.SqlDeleteKeyIn("Files",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("Files");
            }
            strSorgente = Smartdesk.Current.Request("sorgente");
            switch (strSorgente)
            {
                case "scheda-aste":
                    strRedirect = "/admin/app/aste/scheda-aste.aspx?salvato=salvato&Aste_Ky=" + Smartdesk.Current.Request("Aste_Ky");
                    break;
                case "scheda-annunci":
                    strRedirect="/admin/app/annunci/scheda-annunci.aspx?Annunci_Ky=" + Smartdesk.Current.Request("Annunci_Ky");
                    break;
                case "scheda-files":
                    strRedirect = "/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=224&CoreGrids_Ky=236&salvato=salvato";
                    break;
                case "elenco-files":
                    strRedirect = "/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=224&CoreGrids_Ky=236&salvato=salvato";
                    break;
                default:
                    strRedirect = "/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=224&CoreGrids_Ky=236&salvato=salvato";
                    break;
            }
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}