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
      	if (Smartdesk.Current.Request("TicketMessaggi_Default") == "") frm.Add("TicketMessaggi_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("TicketMessaggi", frm);
            strRedirect = "/admin/view.aspx?CoreModules_Ky=32&CoreEntities_Ky=222&CoreGrids_Ky=232";
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
