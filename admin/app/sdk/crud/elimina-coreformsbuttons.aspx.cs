using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        string strCoreFormButtons_Ky = Smartdesk.Current.Request("CoreFormButtons_Ky");
        string strCoreForm_Ky = Smartdesk.Current.Request("CoreForm_Ky");
        string strCoreModules_Ky = Smartdesk.Current.Request("CoreModules_Ky");

        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("CoreFormButtons",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("CoreFormButtons");
            }
            strRedirect="/admin/app/sdk/scheda-CoreForm.aspx?CoreForm_Ky=" + strCoreForm_Ky + "&CoreModules_Ky=" + strCoreModules_Ky;
        		Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}