using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
    	string strRegioni_Ky="";
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

        if (Smartdesk.Login.Verify){
            strRegioni_Ky=Smartdesk.Current.Request("Regioni_Ky");                
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("Province",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("Province");
            }
            strRedirect="/admin/form.aspx?CoreModules_Ky=12&CoreEntities_Ky=7&CoreGrids_Ky=8&CoreForms_Ky=155&salvato=salvato&azione=edit&Regioni_Ky=" + strRegioni_Ky;
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}