using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
      	string strNote_Ky = "";
      	string strAnagrafiche_Ky = "";
      	string strCommesse_Ky = "";
      	string strAttivita_Ky = "";
       	string strDocumenti_Ky = "";
       	string strUtenti_Ky = "";
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

        if (Smartdesk.Login.Verify){
            strNote_Ky = Smartdesk.Current.Request("Note_Ky");
            strCommesse_Ky = Smartdesk.Current.Request("Commesse_Ky");
            strAnagrafiche_Ky = Smartdesk.Current.Request("Anagrafiche_Ky");
            strAttivita_Ky = Smartdesk.Current.Request("Attivita_Ky");
            strDocumenti_Ky = Smartdesk.Current.Request("Documenti_Ky");
            strUtenti_Ky = Smartdesk.Current.Request("Utenti_Ky");
            strSorgente = Smartdesk.Current.Request("sorgente");
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("Note",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("Note");
            }
            switch (strSorgente)
            {
                case "calendario":
                    strRedirect="calendario.aspx#tabs-4";
                    break;
                case "prospetto":
                    strRedirect="attivita-da-fare.aspx?Utenti_Ky=" + strUtenti_Ky + "&Commesse_Ky" + strCommesse_Ky;
                    break;
                case "scheda-anagrafiche":
                    strRedirect="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=" + strAnagrafiche_Ky;
                    break;
                case "elenco-note":
                    strRedirect="/admin/view.aspx?CoreModules_Ky=19&CoreEntities_Ky=161&CoreGrids_Ky=106&Anagrafiche_Ky=" + strAnagrafiche_Ky + "&Commesse_Ky" + strCommesse_Ky;
                    break;
                case "scheda-nota":
                    strRedirect="/admin/view.aspx?CoreModules_Ky=19&CoreEntities_Ky=161&CoreGrids_Ky=106&Anagrafiche_Ky=" + strAnagrafiche_Ky + "&Commesse_Ky" + strCommesse_Ky;
                    break;
                case "scheda-commessa":
                    strRedirect="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=" + strCommesse_Ky;
                    break;
                case "scheda-attivita":
                    strRedirect="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=" + strAttivita_Ky;
                    break;
                case "scheda-persona":
                    strRedirect="admin/form.aspx?CoreModules_Ky=22&CoreEntities_Ky=38&CoreGrids_Ky=114&CoreForms_Ky=144&custom=0&azione=edit&Utenti_Ky=" + strUtenti_Ky;
                    break;
                case "scheda-documenti":
                    strRedirect="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=" + strDocumenti_Ky;
                    break;
            }
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}
