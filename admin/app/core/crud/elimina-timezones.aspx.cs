using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
    	string strTimeZones_Ky = "";
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

        if (Smartdesk.Login.Verify){
            strTimeZones_Ky = Smartdesk.Current.Request("TimeZones_Ky");
            strSorgente = Smartdesk.Current.Request("sorgente");
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("DocumentiCorpo",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("TimeZones");
            }
            switch (strSorgente)
            {
                case "scheda-timezones":
                    strRedirect="/admin/view.aspx?CoreModules_Ky=12&CoreEntities_Ky=6&CoreGrids_Ky=7";
                    break;
            }
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}