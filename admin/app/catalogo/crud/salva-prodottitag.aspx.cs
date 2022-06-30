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
			if (Smartdesk.Current.Request("ProdottiTag_Approvata") == "") frm.Add("ProdottiTag_Approvata", false);
            strKy = Smartdesk.Functions.SqlWriteKey("ProdottiTag", frm);
            strRedirect = "/admin/app/catalogo/scheda-prodottitag.aspx?salvato=salvato&ProdottiTag_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}