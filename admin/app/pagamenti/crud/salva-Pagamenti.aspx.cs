using System;
using System.Collections.Generic;
public partial class _Default : System.Web.UI.Page
{

  public string strAnagrafiche_Ky;
  public string strDocumenti_Ky;
  public string strSpese_Ky;
  protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        if (Smartdesk.Login.Verify){
          Dictionary<string, object> frm = new Dictionary<string, object>();
      	    if (Smartdesk.Current.Request("Pagamenti_Default") == "") frm.Add("Pagamenti_Default", false);
            if (Smartdesk.Current.Request("Pagamenti_Pagato") == "") frm.Add("Pagamenti_Pagato", false);
            strSorgente=Smartdesk.Current.Request("sorgente");
            strKy = Smartdesk.Functions.SqlWriteKey("Pagamenti", frm);
            switch (strSorgente){
              case "scheda-anagrafiche":
                Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky);
                break;
              case "scheda-documenti":
                Response.Redirect("/admin/app/documenti/scheda-documenti.aspx?salvato=salvato&Documenti_Ky=" + strDocumenti_Ky + "&Anagrafiche_Ky=" + strAnagrafiche_Ky);
                break;
              case "scheda-spese":
                Response.Redirect("/admin/app/amministrazione/scheda-spese.aspx?CoreModules_Ky=2&CoreEntities_Ky=1&salvato=salvato&Spese_Ky=" + strSpese_Ky + "&Anagrafiche_Ky=" + strAnagrafiche_Ky);
                break;
          		case "elenco-pagamenti":
                strRedirect = "/admin/view.aspx?CoreModules_Ky=21&CoreEntities_Ky=75&CoreGrids_Ky=110";
           			break;
          		case "scheda-anagrafica":
                strRedirect = "/admin/view.aspx?CoreModules_Ky=21&CoreEntities_Ky=75&CoreGrids_Ky=110";
           			break;
              default:
                strRedirect = "/admin/view.aspx?CoreModules_Ky=21&CoreEntities_Ky=75&CoreGrids_Ky=110";
           			break;
            }
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
