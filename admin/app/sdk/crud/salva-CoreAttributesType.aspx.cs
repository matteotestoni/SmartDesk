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
          strKy = Smartdesk.Functions.SqlWriteKey("CoreAttributesType", frm);
          strRedirect = "/admin/view.aspx?CoreModules_Ky=26&CoreEntities_Ky=178&CoreGrids_Ky=168";
          Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
