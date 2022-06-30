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
      	  if (Smartdesk.Current.Request("Socialchannelstype_Attivo") == "") frm.Add("Socialchannelstype_Attivo", false);
          strKy = Smartdesk.Functions.SqlWriteKey("Socialchannelstype", frm);
          strRedirect = "/admin/view.aspx?CoreModules_Ky=31&CoreEntities_Ky=191&CoreGrids_Ky=182";
          Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
