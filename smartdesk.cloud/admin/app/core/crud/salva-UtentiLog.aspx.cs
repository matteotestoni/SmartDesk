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
          strKy = Smartdesk.Functions.SqlWriteKey("UtentiLog", frm);
          strRedirect = "/admin/view.aspx?CoreModules_Ky=12&CoreEntities_Ky=165&CoreGrids_Ky=22";
          Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
