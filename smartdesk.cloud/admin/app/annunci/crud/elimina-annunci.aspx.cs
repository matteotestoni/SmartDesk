using System;
public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        string strAste_Ky="";

        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("Annunci",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("Annunci");
            }
            strAste_Ky =  Smartdesk.Current.Form("Aste_Ky");
            strSorgente = Smartdesk.Current.Form("sorgente");
            switch (strSorgente)
            {
              case "scheda-aste":
                  strRedirect="/admin/app/aste/scheda-aste.aspx?salvato=salvato&Aste_Ky=" + strAste_Ky;
                  break;
              case "elenco-annunci":
                  strRedirect = "/admin/app/annunci/elenco-annunci.aspx?CoreModules_Ky=3&CoreEntities_Ky=48&CoreGrids_Ky=42&salvato=salvato";
                  break;
              default:
                  strRedirect="/admin/app/annunci/elenco-annunci.aspx?CoreModules_Ky=3&CoreEntities_Ky=48&CoreGrids_Ky=42&";
                  break;
            }
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}
                      
