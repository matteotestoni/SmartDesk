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
          if (Smartdesk.Current.Request("LeadCategorie_Default") == "") frm.Add("LeadCategorie_Default", false);
          if (Smartdesk.Current.Request("LeadCategorie_Attiva") == "") frm.Add("LeadCategorie_Attiva", false);
          strKy = Smartdesk.Functions.SqlWriteKey("LeadCategorie", frm);
          strRedirect = "/admin/form.aspx?CoreModules_Ky=20&CoreEntities_Ky=204&CoreForms_Ky=116&custom=0&azione=edit&LeadCategorie_Ky=" + strKy;
	      Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}