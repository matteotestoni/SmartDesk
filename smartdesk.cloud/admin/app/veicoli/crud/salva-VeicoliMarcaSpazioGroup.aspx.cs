using System;
using System.Collections.Generic;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
          Dictionary<string, object> frm = new Dictionary<string, object>();
          strKy = Smartdesk.Functions.SqlWriteKey("VeicoliMarcaSpazioGroup", frm);
          strRedirect = "/admin/view.aspx?CoreModules_Ky=29&CoreEntities_Ky=120&CoreGrids_Ky=141";
          Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}