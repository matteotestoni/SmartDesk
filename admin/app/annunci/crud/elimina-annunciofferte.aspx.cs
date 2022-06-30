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
                Smartdesk.Functions.SqlDeleteKeyIn("AnnunciOfferte",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("AnnunciOfferte");
            }
            strAste_Ky =  Request["Aste_Ky"];
            strSorgente = Request["sorgente"];
            switch (strSorgente)
            {
              case "scheda-aste":
                  strRedirect="/admin/app/aste/scheda-aste.aspx?salvato=salvato&Aste_Ky=" + strAste_Ky;
                  break;
              case "scheda-asta":
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
                      
