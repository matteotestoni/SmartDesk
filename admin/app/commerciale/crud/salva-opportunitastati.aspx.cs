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
            if (Smartdesk.Current.Request("OpportunitaStati_Aperta") == "") frm.Add("OpportunitaStati_Aperta", false);
            if (Smartdesk.Current.Request("OpportunitaStati_Chiusa") == "") frm.Add("OpportunitaStati_Chiusa", false);
            strKy = Smartdesk.Functions.SqlWriteKey("OpportunitaStati", frm);
            strRedirect = "/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=140&CoreGrids_Ky=109";
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}