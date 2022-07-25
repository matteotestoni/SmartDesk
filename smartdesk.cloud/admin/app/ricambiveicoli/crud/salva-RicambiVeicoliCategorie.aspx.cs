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
      	if (Smartdesk.Current.Request("RicambiVeicoliCategorie_Default") == "") frm.Add("RicambiVeicoliCategorie_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("RicambiVeicoliCategorie", frm);
            strRedirect = "/admin/view.aspx?CoreModules_Ky=25&CoreEntities_Ky=154&CoreGrids_Ky=121";
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
