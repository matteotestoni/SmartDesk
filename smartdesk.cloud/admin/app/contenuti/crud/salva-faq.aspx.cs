using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
    	string strAnagrafiche_Ky="";
    	string strProdotti_Ky = "";
    	string strProdottiCategorie_Ky = "";
    	string strSorgente = Smartdesk.Current.Request("sorgente");
        if (Smartdesk.Login.Verify)
        {
	        strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
			strProdotti_Ky=Smartdesk.Current.Request("Prodotti_Ky");
	        strProdottiCategorie_Ky=Smartdesk.Current.Request("ProdottiCategorie_Ky");
            Dictionary<string, object> frm = new Dictionary<string, object>();
            if (Smartdesk.Current.Request("Faq_PubblicaWEB") == "") frm.Add("Faq_PubblicaWEB", false);
            strKy = Smartdesk.Functions.SqlWriteKey("Faq",frm);
	          switch (strSorgente){
	            case "scheda-anagrafiche":
	              strRedirect="/admin/app/anagrafiche/scheda-anagrafiche.aspx?salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky;
	              break;
	            case "scheda-prodotti":
	              strRedirect="/admin/app/catalogo/scheda-prodotti.aspx?salvato=salvato&Prodotti_Ky=" + strProdotti_Ky + "&Anagrafiche_Ky=" + strAnagrafiche_Ky;
	              break;
	            case "scheda-prodotticategorie":
	              strRedirect="/admin/app/catalogo/scheda-prodotticategorie.aspx?salvato=salvato&ProdottiCategorie_Ky=" + strProdottiCategorie_Ky + "&Anagrafiche_Ky=" + strAnagrafiche_Ky;
	              break;
	            case "scheda-faq":
	              strRedirect="/admin/form.aspx?CoreModules_Ky=9&CoreEntities_Ky=73&CoreGrids_Ky=94&CoreForms_Ky=103&custom=0&azione=edit&salvato=salvato&Faq_Ky=" + strKy;
	              break;
	            default:
	              strRedirect="/admin/form.aspx?CoreModules_Ky=9&CoreEntities_Ky=73&CoreGrids_Ky=94&CoreForms_Ky=103&custom=0&azione=edit&salvato=salvato&Faq_Ky=" + strKy;
	              break;
	          }
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}