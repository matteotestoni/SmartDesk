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
            if (Smartdesk.Current.Request("VeicoliCategoria_Attiva") == "") frm.Add("VeicoliCategoria_Attiva", false);
            strKy = Smartdesk.Functions.SqlWriteKey("VeicoliCategoria", frm);
            strRedirect = "/admin/form.aspx?CoreModules_Ky=29&CoreEntities_Ky=113&CoreGrids_Ky=134&CoreForms_Ky=79&custom=0&azione=edit&VeicoliCategoria_Ky=1" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}