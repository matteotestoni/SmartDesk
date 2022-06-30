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
					if (Smartdesk.Current.Request("VeicoliCarburante_Ecologico") == "") frm.Add("VeicoliCarburante_Ecologico", false);
          strKy = Smartdesk.Functions.SqlWriteKey("VeicoliCarburante",frm);
          strRedirect = "/admin/form.aspx?CoreModules_Ky=29&CoreEntities_Ky=111&CoreGrids_Ky=132&custom=0&azione=edit&VeicoliCarburante_Ky=" + strKy;
        	Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}