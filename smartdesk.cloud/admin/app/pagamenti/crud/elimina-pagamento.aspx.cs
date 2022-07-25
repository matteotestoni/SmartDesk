using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
     		string strPagamenti_Ky="";
      	string strAnagrafiche_Ky="";
      	string strSpese_Ky="";
      	string strDocumenti_Ky="";
      	string strCommesse_Ky="";
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

		
		if (Smartdesk.Login.Verify){
            strPagamenti_Ky=Smartdesk.Current.Request("Pagamenti_Ky");
            strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
            strDocumenti_Ky=Smartdesk.Current.Request("Documenti_Ky");
            strCommesse_Ky=Smartdesk.Current.Request("Commesse_Ky");
            strSpese_Ky=Smartdesk.Current.Request("Spese_Ky");
      		strSorgente=Smartdesk.Current.Request("sorgente");
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("Pagamenti",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("Pagamenti");
            }
            switch (strSorgente){
          		case "scheda-documenti":
            		strRedirect="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=" + strDocumenti_Ky;
           			break;
          		case "scheda-commessa":
            		strRedirect="/admin/app/progetti/scheda-commesse.aspx?Commesse_Ky=" + strCommesse_Ky;
            		break;
            	case "scheda-anagrafiche":
            		strRedirect="/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky;
            		break;
              	case "scheda-spese":
                	strRedirect="/admin/app/amministrazione/scheda-spese.aspx?CoreModules_Ky=2&CoreEntities_Ky=1&Spese_Ky=" + strSpese_Ky;
                	break;
              	case "elenco-pagamenti":
                	strRedirect="/admin/app/pagmenti/elenco-pagamenti.aspx";
                	break;
              	case "elenco-pagamenti-fatti":
                	strRedirect="/admin/view.aspx?CoreModules_Ky=21&CoreEntities_Ky=75&CoreGrids_Ky=159";
                	break;
              	case "elenco-pagamenti-ricevuti":
                	strRedirect="/admin/view.aspx?CoreModules_Ky=21&CoreEntities_Ky=75&CoreGrids_Ky=233";
                	break;
              	case "elenco-pagamenti-da-fare":
                	strRedirect="/admin/app/pagmenti/elenco-pagamenti-da-fare.aspx";
                	break;
	        }
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}
