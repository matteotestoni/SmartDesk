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
      	  if (Smartdesk.Current.Request("Recensioni_Approvata") == "") frm.Add("Recensioni_Approvata", false);
          strKy = Smartdesk.Functions.SqlWriteKey("Recensioni", frm);
          strRedirect = "/admin/view.aspx?CoreModules_Ky=31&CoreEntities_Ky=211&CoreGrids_Ky=219";
          Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
