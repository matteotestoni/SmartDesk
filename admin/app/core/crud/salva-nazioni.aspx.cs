using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    string strSorgente = Smartdesk.Current.Request("sorgente");
        string strKy ="";

        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
    		Dictionary<string, object> frm = new Dictionary<string, object>();
    		if (Smartdesk.Current.Request("Nazioni_Fatturazione") == "") frm.Add("Nazioni_Fatturazione", false);
    		if (Smartdesk.Current.Request("Nazioni_Spedizione") == "") frm.Add("Nazioni_Spedizione", false);
            strKy=Smartdesk.Functions.SqlWriteKey("Nazioni", frm);
		    strRedirect="/admin/form.aspx?CoreModules_Ky=12&CoreEntities_Ky=5&CoreGrids_Ky=6&CoreForms_Ky=154&salvato=salvato&azione=edit&Nazioni_Ky=" + strKy;
            Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}
