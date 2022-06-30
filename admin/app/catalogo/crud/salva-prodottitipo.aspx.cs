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
			if (Smartdesk.Current.Request("ProdottiTipo_Attivo") == "") frm.Add("ProdottiTipo_Attivo", false);
            strKy = Smartdesk.Functions.SqlWriteKey("ProdottiTipo");
            strRedirect = "/admin/form.aspx?CoreModules_Ky=8&CoreEntities_Ky=93&CoreGrids_Ky=76&CoreForms_Ky=193&custom=0&azione=edit&sorgente=elenco-prodottitipo&salvato=salvato&ProdottiTipo_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}