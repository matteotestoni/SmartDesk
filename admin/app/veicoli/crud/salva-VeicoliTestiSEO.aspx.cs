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
					if (Smartdesk.Current.Request("VeicoliTestiSEO_Ecologiche") == "") frm.Add("VeicoliTestiSEO_Ecologiche", false);
					if (Smartdesk.Current.Request("VeicoliTestiSEO_Topcar") == "") frm.Add("VeicoliTestiSEO_Topcar", false);
					if (Smartdesk.Current.Request("VeicoliTestiSEO_Neopatentati") == "") frm.Add("VeicoliTestiSEO_Neopatentati", false);
          strKy = Smartdesk.Functions.SqlWriteKey("VeicoliTestiSEO",frm);
          strRedirect = "/admin/form.aspx?CoreModules_Ky=29&CoreEntities_Ky=214&CoreGrids_Ky=223&CoreForms_Ky=132&custom=0&azione=edit&VeicoliTestiSEO_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}
