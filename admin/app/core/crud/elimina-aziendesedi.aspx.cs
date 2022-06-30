using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strAziende_Ky = Smartdesk.Current.Request("Aziende_Ky");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("AziendeSedi",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("AziendeSedi");
            }
            strRedirect="/admin/view.aspx?CoreModules_Ky=12&CoreEntities_Ky=202&CoreGrids_Ky=210";
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}