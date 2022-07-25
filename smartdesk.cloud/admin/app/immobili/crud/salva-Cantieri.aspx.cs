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
      	if (Smartdesk.Current.Request("Cantieri_Default") == "") frm.Add("Cantieri_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("Cantieri", frm);
            strRedirect = "/admin/view.aspx?CoreModules_Ky=17&CoreEntities_Ky=199&CoreGrids_Ky=207";
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
