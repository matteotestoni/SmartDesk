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
          strKy = Smartdesk.Functions.SqlWriteKey("DocumentiCorpo", frm);
          strRedirect = "/admin/view.aspx?CoreModules_Ky=13&CoreEntities_Ky=45&CoreGrids_Ky=91";
          Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
