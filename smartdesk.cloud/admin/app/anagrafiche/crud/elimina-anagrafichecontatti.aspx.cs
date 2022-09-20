using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
	    string strAnagrafiche_Ky = "";
	    string strSitiWeb_Ky = "";
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");


        if (Smartdesk.Login.Verify)
        {
            strAnagrafiche_Ky = Smartdesk.Current.Request("Anagrafiche_Ky");
            strSitiWeb_Ky = Smartdesk.Current.Request("SitiWeb_Ky");
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("AnagraficheContatti",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("AnagraficheContatti");
            }
            switch (strSorgente)
            {
	              case "scheda-anagrafiche":
	                  strRedirect="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=" + strAnagrafiche_Ky + "&salvato=salvato";
	                  break;
	              case "scheda-sitoweb":
	                  strRedirect="/admin/app/sitiweb/scheda-sitiweb.aspx?SitiWeb_Ky=" + strSitiWeb_Ky + "&salvato=salvato";
	                  break;
	              case "scheda-sitiweb":
	                  strRedirect="/admin/app/sitiweb/scheda-sitiweb.aspx?SitiWeb_Ky=" + strSitiWeb_Ky + "&salvato=salvato";
	                  break;
            }
	        Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}
