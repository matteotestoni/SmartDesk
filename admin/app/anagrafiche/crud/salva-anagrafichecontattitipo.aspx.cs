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
    				if (Smartdesk.Current.Request("AnagraficheContattiTipo_Default") == "") frm.Add("AnagraficheContattiTipo_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("AnagraficheContattiTipo",frm);
            strRedirect = "/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=25&CoreGrids_Ky=29";
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
