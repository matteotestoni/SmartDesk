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
            if (Smartdesk.Current.Request("Forms_PubblicaWEB") == "") frm.Add("Forms_PubblicaWEB", false);
            if (Smartdesk.Current.Request("Forms_Disattiva") == "") frm.Add("Forms_Disattiva", false);
            strKy = Smartdesk.Functions.SqlWriteKey("Forms", frm);
            strRedirect = "/admin/form.aspx?CoreModules_Ky=16&CoreEntities_Ky=146&CoreForms_Ky=151&salvato=salvato&Forms_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}