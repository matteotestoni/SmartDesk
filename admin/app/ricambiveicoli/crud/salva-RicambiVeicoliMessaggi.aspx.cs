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
      	if (Smartdesk.Current.Request("RicambiVeicoliMessaggi_Default") == "") frm.Add("RicambiVeicoliMessaggi_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("RicambiVeicoliMessaggi", frm);
            strRedirect = "/admin/view.aspx?CoreModules_Ky=25&CoreEntities_Ky=155&CoreGrids_Ky=122";
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
