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
          strKy = Smartdesk.Functions.SqlWriteKey("OfficinaPreparatori", frm);
          strRedirect = "/admin/view.aspx?CoreModules_Ky=33&CoreEntities_Ky=238&CoreGrids_Ky=253";
          Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
