using System;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    public string strAnagrafiche_Ky="";
    public string strSitiWeb_Ky="";
    public string strAzione = "";
    public string strSorgente="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strRedirect = Smartdesk.Current.LoginPageRoot;
      string strKy = "";
      bool boolAjax = false;

        if (Smartdesk.Login.Verify)
        {
            strAnagrafiche_Ky =  Smartdesk.Current.Form("Anagrafiche_Ky");
            strSitiWeb_Ky = Smartdesk.Current.Form("SitiWeb_Ky");
            strSorgente = Smartdesk.Current.Form("sorgente");
            Dictionary<string, object> frm = new Dictionary<string, object>();
            if (Smartdesk.Current.Request("AnagraficheContatti_PEC") == "") frm.Add("AnagraficheContatti_PEC", false);
            if (Smartdesk.Current.Request("AnagraficheContatti_Stampa") == "") frm.Add("AnagraficheContatti_Stampa", false);
            strKy = Smartdesk.Functions.SqlWriteKey("AnagraficheContatti", frm);
            switch (strSorgente)
            {
                case "scheda-anagrafiche":
                    strRedirect="/admin/app/anagrafiche/scheda-anagrafiche.aspx?salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky;
                    break;
                case "scheda-sitoweb":
                    strRedirect = "/admin/app/sitiweb/scheda-sitiweb.aspx?salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky + "&SitiWeb_Ky=" + strSitiWeb_Ky;
                    break;
                case "scheda-sitiweb":
                    strRedirect = "/admin/app/sitiweb/scheda-sitiweb.aspx?salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky + "&SitiWeb_Ky=" + strSitiWeb_Ky;
                    break;
                default:
                    strRedirect = "/admin/app/anagrafiche/scheda-anagrafiche.aspx?salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky;
                    break;
            }

        }
        Response.Redirect(strRedirect);
    }
}
