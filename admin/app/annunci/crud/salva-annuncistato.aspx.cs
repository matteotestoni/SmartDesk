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
          if (Smartdesk.Current.Request("AnnunciStato_PubblicaWEB") == "") frm.Add("AnnunciStato_PubblicaWEB", false);
          strKy = Smartdesk.Functions.SqlWriteKey("AnnunciStato", frm);
          strRedirect = "/admin/view.aspx?CoreModules_Ky=3&CoreEntities_Ky=57&CoreGrids_Ky=47";
          Response.Redirect(strRedirect);
      }
      Response.Redirect(strRedirect);
    }
}
