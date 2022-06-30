using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      string strRedirect = Smartdesk.Current.LoginPageRoot;
      string strAnnunci_Ky = "";
      string strAste_Ky = "";
      string strSorgente = "";
      bool boolAjax = false;

        if (Smartdesk.Login.Verify)
        {
            strSorgente = Request["sorgente"];
            strAste_Ky = Smartdesk.Current.Request("Aste_Ky");
            strAnnunci_Ky = Smartdesk.Current.Request("Annunci_Ky");
            strKy = Smartdesk.Functions.SqlWriteKey("AnnunciOfferte");
            strRedirect = "/admin/app/annunci/scheda-annunciofferte.aspx?salvato=salvato&AnnunciOfferte_Ky=" + strKy + "&Annunci_Ky=" + strAnnunci_Ky + "&Aste_Ky=" + strAste_Ky;
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
