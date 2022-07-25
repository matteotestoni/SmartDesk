using System;
using System.Collections.Generic;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strSQL = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
          Dictionary<string, object> frm = new Dictionary<string, object>();
      	  if (Smartdesk.Current.Request("CoreEmailQueue_Sent") == "") frm.Add("CoreEmailQueue_Sent", false);
          strKy = Smartdesk.Functions.SqlWriteKey("CoreEmailQueue", frm);
          strRedirect = "/admin/view.aspx?CoreModules_Ky=12&CoreEntities_Ky=253&CoreGrids_Ky=278";
          Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
