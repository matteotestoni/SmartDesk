using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
    	string strFaq_Ky = "";
    	string strAnagrafiche_Ky = "";
    	string strProdotti_Ky = "";
    	string strProdottiCategorie_Ky = "";
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

        if (Smartdesk.Login.Verify){
            strFaq_Ky = Smartdesk.Current.Request("Faq_Ky");
            strProdotti_Ky = Smartdesk.Current.Request("Prodotti_Ky");
            strProdottiCategorie_Ky = Smartdesk.Current.Request("ProdottiCategorie_Ky");
            strAnagrafiche_Ky = Smartdesk.Current.Request("Anagrafiche_Ky");
            strSorgente = Smartdesk.Current.Request("sorgente");
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("DocumentiCorpo",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("Faq");
            }
            switch (strSorgente)
            {
                case "scheda-anagrafiche":
                    strRedirect="/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky;
                    break;
                case "scheda-faq":
                    strRedirect="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=73&CoreGrids_Ky=94&Anagrafiche_Ky=" + strAnagrafiche_Ky + "&Prodotti_Ky" + strProdotti_Ky + "&ProdottiCategorie_Ky" + strProdottiCategorie_Ky;
                    break;
                case "scheda-prodotti":
                    strRedirect="/admin/app/catalogo/scheda-prodotti.aspx?Prodotti_Ky=" + strProdotti_Ky;
                    break;
                case "scheda-prodotticategorie":
                    strRedirect="/admin/app/catalogo/scheda-prodotticategorie.aspx?ProdottiCategorie_Ky=" + strProdottiCategorie_Ky;
                    break;
            }
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}