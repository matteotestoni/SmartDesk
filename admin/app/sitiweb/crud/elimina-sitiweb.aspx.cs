using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
    	string strSitiWeb_Ky="";
    	string strAnagrafiche_Ky="";
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

        if (Smartdesk.Login.Verify){
            strSitiWeb_Ky=Smartdesk.Current.Request("SitiWeb_Ky");
            strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("SitiWeb",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("SitiWeb");
            }
			switch (strSorgente){
			  case "scheda-anagrafiche":
			    strRedirect="/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky;
			    break;
			  case "elenco-sitiweb":
			    strRedirect="/admin/view.aspx?CoreModules_Ky=27&CoreEntities_Ky=142&CoreGrids_Ky=126&Anagrafiche_Ky=" + strAnagrafiche_Ky;
			    break;
			  default:
			    strRedirect="/admin/view.aspx?CoreModules_Ky=27&CoreEntities_Ky=142&CoreGrids_Ky=126";
			    break;
          
          
          
			}
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}