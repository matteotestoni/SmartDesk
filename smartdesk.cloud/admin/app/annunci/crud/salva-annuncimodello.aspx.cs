using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      string strRedirect = Smartdesk.Current.LoginPageRoot;
   		string strAnnunciMarca_Ky = "";
      bool boolAjax = false;
        if (Smartdesk.Login.Verify)
        {
            strAnnunciMarca_Ky = Smartdesk.Current.Request("AnnunciMarca_Ky");
            strKy = Smartdesk.Functions.SqlWriteKey("AnnunciModello");
            strRedirect = "/admin/app/annunci/scheda-annuncimarca.aspx?salvato=salvato&AnnunciMarca_Ky=" + strAnnunciMarca_Ky + "&AnnunciModello_Ky=" + strKy;
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
