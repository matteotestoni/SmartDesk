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
            if (Smartdesk.Current.Request("AttivitaStati_Aperta") == "") frm.Add("AttivitaStati_Aperta", false);
            if (Smartdesk.Current.Request("AttivitaStati_Chiusa") == "") frm.Add("AttivitaStati_Chiusa", false);
            strKy = Smartdesk.Functions.SqlWriteKey("AttivitaStati", frm);
            strRedirect = "/admin/view.aspx?CoreModules_Ky=6&CoreEntities_Ky=81&CoreGrids_Ky=64";
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}