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
      	if (Smartdesk.Current.Request("RicambiVeicoli_Default") == "") frm.Add("RicambiVeicoli_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("RicambiVeicoli", frm);
            strRedirect = "/admin/view.aspx?CoreModules_Ky=25&CoreEntities_Ky=153&CoreGrids_Ky=120";
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
