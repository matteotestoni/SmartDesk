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
			if (Smartdesk.Current.Request("ProdottiVisibilita_Attivo") == "") frm.Add("ProdottiVisibilita_Attivo", false);
            strKy = Smartdesk.Functions.SqlWriteKey("ProdottiVisibilita");
            strRedirect = "/admin/form.aspx?CoreModules_Ky=8&CoreEntities_Ky=94&CoreGrids_Ky=77&salvato=salvato&ProdottiVisibilita_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}