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
                Smartdesk.Functions.SqlDeleteKeyIn("attivitasettore",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("attivitasettore");
            }
            strRedirect="/admin/view.aspx?CoreModules_Ky=6&CoreEntities_Ky=80&CoreGrids_Ky=63";
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}