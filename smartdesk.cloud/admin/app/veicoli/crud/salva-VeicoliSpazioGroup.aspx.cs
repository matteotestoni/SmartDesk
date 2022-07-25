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
      	  if (Smartdesk.Current.Request("Nuovo") == "") frm.Add("Nuovo", false);
      	  if (Smartdesk.Current.Request("agenzia_esiste") == "") frm.Add("agenzia_esiste", false);
          strKy = Smartdesk.Functions.SqlWriteKey("VeicoliSpazioGroup", frm);
          strRedirect = "/admin/view.aspx?CoreModules_Ky=29&CoreEntities_Ky=128&CoreGrids_Ky=149";
          Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
