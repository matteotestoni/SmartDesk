using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strPersone_Ky="";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
            strPersone_Ky = Smartdesk.Current.Request("Persone_Ky");
            strKy = Smartdesk.Functions.SqlWriteKey("PersoneAssenze");
            strRedirect = "/admin/app/persone/elenco-personeassenze.aspx?salvato=salvato&PersoneAssenze_Ky=" + strKy + "&Persone_Ky=" + strPersone_Ky;
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}