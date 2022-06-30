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
		    if (Smartdesk.Current.Request("SitiWeb_SEO") == "") frm.Add("SitiWeb_SEO", false);
            strKy = Smartdesk.Functions.SqlWriteKey("SitiWeb",frm);
            strRedirect = "/admin/app/sitiweb/scheda-sitiweb.aspx?salvato=salvato&SitiWeb_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}