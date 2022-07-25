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
      	  if (Smartdesk.Current.Request("OfficinaStati_Aperta") == "") frm.Add("OfficinaStati_Aperta", false);
      	  if (Smartdesk.Current.Request("OfficinaStati_Chiusa") == "") frm.Add("OfficinaStati_Chiusa", false);
          strKy = Smartdesk.Functions.SqlWriteKey("OfficinaStati", frm);
          strRedirect = "/admin/view.aspx?CoreModules_Ky=33&CoreEntities_Ky=233&CoreGrids_Ky=246";
          Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
