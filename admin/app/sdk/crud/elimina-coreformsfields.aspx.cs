using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        string strCoreFormsFields_Ky = Smartdesk.Current.Request("CoreFormsFields_Ky");
        string strCoreForms_Ky = Smartdesk.Current.Request("CoreForms_Ky");
        string strCoreModules_Ky = Smartdesk.Current.Request("CoreModules_Ky");

        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("CoreFormsFields",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("CoreFormsFields");
            }
            strRedirect="/admin/app/sdk/scheda-CoreForms.aspx?CoreForms_Ky=" + strCoreForms_Ky + "&CoreModules_Ky=" + strCoreModules_Ky + "#CoreFormsFields";
        		Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}
