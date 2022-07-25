using System;
using System.Collections.Generic;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strSQL = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strCoreForms_Ky = Smartdesk.Current.Request("CoreForms_Ky");
        string strCoreEntities_Ky = Smartdesk.Current.Request("CoreEntities_Ky");
        string strCoreModules_Ky = Smartdesk.Current.Request("CoreModules_Ky");
        if (Smartdesk.Login.Verify)
        {
          Dictionary<string, object> frm = new Dictionary<string, object>();
          strKy = Smartdesk.Functions.SqlWriteKey("UsergroupsForms", frm);
          switch (strSorgente)
          {
            case "scheda-coreforms":
                strRedirect = "/admin/app/sdk/scheda-CoreForms.aspx?CoreForms_Ky=" + strCoreForms_Ky + "&CoreModules_Ky=" + strCoreModules_Ky + "&CoreEntities_Ky=" + strCoreEntities_Ky + "#UsergroupsForms";
                break;
            default:
                strRedirect = "/admin/view.aspx?CoreModules_Ky=26&CoreEntities_Ky=250&CoreGrids_Ky=271";
                break;
          }
          Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
