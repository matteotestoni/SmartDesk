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
      	if (Smartdesk.Current.Request("RicambiVeicoliRichieste_Default") == "") frm.Add("RicambiVeicoliRichieste_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("RicambiVeicoliRichieste", frm);
            strRedirect = "/admin/view.aspx?CoreModules_Ky=25&CoreEntities_Ky=159&CoreGrids_Ky=125";
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
