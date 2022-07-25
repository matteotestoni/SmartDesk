using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
    	string strAnagrafiche_Ky="";
    	string strCommesse_Ky = "";
    	string strAttivita_Ky = "";
    	string strDocumenti_Ky = "";
    	string strSorgente = Smartdesk.Current.Request("sorgente");
        if (Smartdesk.Login.Verify)
        {
	        strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
	        strCommesse_Ky=Smartdesk.Current.Request("Commesse_Ky");
	        strAttivita_Ky=Request["Attivita_Ky"];
	        strDocumenti_Ky=Request["Documenti_Ky"];
            strKy = Smartdesk.Functions.SqlWriteKey("Note");
	          switch (strSorgente){
	            case "scheda-anagrafiche":
	              strRedirect="/admin/app/anagrafiche/scheda-anagrafiche.aspx?salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky;
	              break;
	            case "scheda-commessa":
	              strRedirect="/admin/app/progetti/scheda-commesse.aspx?salvato=salvato&Commesse_Ky=" + strCommesse_Ky + "&Anagrafiche_Ky=" + strAnagrafiche_Ky;
	              break;
	            case "scheda-nota":
	              strRedirect="/admin/form.aspx?CoreModules_Ky=19&CoreEntities_Ky=161&CoreGrids_Ky=106&CoreForms_Ky=126&salvato=salvato&Note_Ky=" + strKy;
	              break;
	            case "scheda-documenti":
	              strRedirect="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&salvato=salvato&Documenti_Ky=" + strDocumenti_Ky + "&Note_Ky=" + strKy;
	              break;
	            default:
	              strRedirect="/admin/form.aspx?CoreModules_Ky=19&CoreEntities_Ky=161&CoreGrids_Ky=106&CoreForms_Ky=126&salvato=salvato&Note_Ky=" + strKy;
	              break;
	          }
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}
