using System;
using System.Collections.Generic;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      string strRedirect = Smartdesk.Current.LoginPageRoot;
      bool boolAjax = false;
        if (Smartdesk.Login.Verify)
        {
          Dictionary<string, object> frm = new Dictionary<string, object>();
      	if (Smartdesk.Current.Request("AnagraficheLog_Default") == "") frm.Add("AnagraficheLog_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("AnagraficheLog", frm);
            strRedirect = "/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=27&CoreGrids_Ky=31";
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
