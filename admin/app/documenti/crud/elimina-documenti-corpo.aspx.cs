using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strDocumenti_Ky = Smartdesk.Current.Request("Documenti_Ky");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

        if (Smartdesk.Login.Verify)
        {
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("DocumentiCorpo",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("DocumentiCorpo");
            }
            strRedirect = "/admin/app/documenti/scheda-documenti.aspx?Documenti_Ky=" + strDocumenti_Ky;
	        Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}