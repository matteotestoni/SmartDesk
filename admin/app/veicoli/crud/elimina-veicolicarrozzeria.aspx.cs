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
                Smartdesk.Functions.SqlDeleteKeyIn("VeicoliCarrozzeria",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("VeicoliCarrozzeria");
            }
            strRedirect="/admin/app/veicoli/elenco-veicolicarrozzeria.aspx";
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}