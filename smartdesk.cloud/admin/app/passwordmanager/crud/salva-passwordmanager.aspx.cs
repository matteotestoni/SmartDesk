using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        if (Smartdesk.Login.Verify)
        {
            strKy = Smartdesk.Functions.SqlWriteKey("Passwordmanager");
            switch (strSorgente)
            {
                case "scheda-anagrafiche":
                    strRedirect = "/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=" + Smartdesk.Current.Request("Anagrafiche_Ky"); ;
                    break;
                case "scheda-passwordmanager":
                    strRedirect = "/admin/form.aspx?CoreModules_Ky=30&CoreEntities_Ky=166&CoreForms_Ky=74&salvato=salvato&Passwordmanager_Ky=" + strKy;
                    break;
                case "scheda-sitiweb":
                    strRedirect = "/admin/app/sitiweb/scheda-sitiweb.aspx?salvato=salvato&SitiWeb_Ky=" + Smartdesk.Current.Request("SitiWeb_Ky"); ;
                    break;
                default:
                    strRedirect = "/admin/form.aspx?CoreModules_Ky=30&CoreEntities_Ky=166&CoreForms_Ky=74&salvato=salvato&Passwordmanager_Ky=" + strKy;
                    break;
            }
            Response.Redirect(strRedirect);

        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}
