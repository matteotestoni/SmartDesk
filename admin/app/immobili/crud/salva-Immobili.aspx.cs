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
      	if (Smartdesk.Current.Request("Immobili_Default") == "") frm.Add("Immobili_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("Immobili", frm);
            strRedirect = "/admin/view.aspx?CoreModules_Ky=17&CoreEntities_Ky=170&CoreGrids_Ky=160";
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
