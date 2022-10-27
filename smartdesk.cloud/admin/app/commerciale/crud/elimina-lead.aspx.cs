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
                Smartdesk.Functions.SqlDeleteKeyIn("Lead",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("Lead");
            }
						switch (strSorgente)
            {
                case "assegna-lead":
                    strRedirect = "/admin/app/commerciale/assegna-lead.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198";
                    break;
                default:
                    strRedirect="/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175";
                    break;
            }
        	  Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}
