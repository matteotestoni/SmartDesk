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
          strKy = Smartdesk.Functions.SqlWriteKey("AsteProxyBid", frm);
          strRedirect = "/admin/view.aspx?CoreModules_Ky=5&CoreEntities_Ky=69&CoreGrids_Ky=57";
          Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
