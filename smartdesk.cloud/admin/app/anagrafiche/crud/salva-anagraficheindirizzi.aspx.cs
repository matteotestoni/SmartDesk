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
            strSorgente = Smartdesk.Current.Form("sorgente");
            Dictionary<string, object> frm = new Dictionary<string, object>();
            if (Smartdesk.Current.Request("AnagraficheIndirizzi_DefaultFatturazione") == "") frm.Add("AnagraficheIndirizzi_DefaultFatturazione", false);
            if (Smartdesk.Current.Request("AnagraficheIndirizzi_DefaultSpedizione") == "") frm.Add("AnagraficheIndirizzi_DefaultSpedizione", false);
            strKy = Smartdesk.Functions.SqlWriteKey("AnagraficheIndirizzi", frm);
            switch (strSorgente)
            {
                case "scheda-anagrafiche":
                    strRedirect="/admin/form.aspx?CoreModules_Ky=1&CoreEntities_Ky=26&CoreForms_Ky=107&salvato=salvato&AnagraficheIndirizzi_Ky=" + strKy;
                    strRedirect="/admin/goto-form.aspx?CoreEntities_Ky=162&salvato=salvato&AnagraficheIndirizzi_Ky=" + strKy + "&Anagrafiche_Ky=" + strAnagrafiche_Ky + "#tabs-indirizzi";
                    break;
                default:
                    strRedirect = "/admin/form.aspx?CoreModules_Ky=1&CoreEntities_Ky=26&CoreForms_Ky=107&salvato=salvato&AnagraficheIndirizzi_Ky=" + strKy;
                    strRedirect="/admin/goto-form.aspx?CoreEntities_Ky=162&salvato=salvato&AnagraficheIndirizzi_Ky=" + strKy + "&Anagrafiche_Ky=" + strAnagrafiche_Ky + "#tabs-indirizzi";
                    break;
            }

        }
        Response.Redirect(strRedirect);
    }
}
