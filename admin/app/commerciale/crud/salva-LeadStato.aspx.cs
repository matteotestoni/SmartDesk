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
      	  if (Smartdesk.Current.Request("LeadStato_Default") == "") frm.Add("LeadStato_Default", false);
      	  if (Smartdesk.Current.Request("LeadStato_Aperta") == "") frm.Add("LeadStato_Aperta", false);
      	  if (Smartdesk.Current.Request("LeadStato_Chiusa") == "") frm.Add("LeadStato_Chiusa", false);
          strKy = Smartdesk.Functions.SqlWriteKey("LeadStato", frm);
          strRedirect = "/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=181&CoreGrids_Ky=171";
          Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
