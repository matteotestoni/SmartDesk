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
      	if (Smartdesk.Current.Request("RicambiVeicoliTipologie_Default") == "") frm.Add("RicambiVeicoliTipologie_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("RicambiVeicoliTipologie", frm);
            strRedirect = "/admin/view.aspx?CoreModules_Ky=25&CoreEntities_Ky=158&CoreGrids_Ky=124";
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
