using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("SpedizioniTipo",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("SpedizioniTipo");
            }
            strRedirect="/admin/view.aspx?CoreModules_Ky=18&CoreEntities_Ky=133&CoreGrids_Ky=100";
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}