using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("CMSTags",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("CMSTags");
            }
            strRedirect="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=104&CoreGrids_Ky=87&eliminato=eliminato";
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}