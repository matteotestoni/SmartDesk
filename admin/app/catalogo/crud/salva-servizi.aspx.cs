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
            if (Smartdesk.Current.Request("Servizi_PubblicaWEB") == "") frm.Add("Servizi_PubblicaWEB", false);
            if (Smartdesk.Current.Request("Servizi_InVetrina") == "") frm.Add("Servizi_InVetrina", false);
            if (Smartdesk.Current.Request("Servizi_InOfferta") == "") frm.Add("Servizi_InOfferta", false);
            if (Smartdesk.Current.Request("Servizi_InPromozione") == "") frm.Add("Servizi_InPromozione", false);
            if (Smartdesk.Current.Request("Servizi_Outlet") == "") frm.Add("Servizi_Outlet", false);
            strKy = Smartdesk.Functions.SqlWriteKey("Servizi",frm);
            strRedirect = "/admin/app/catalogo/scheda-servizi.aspx?salvato=salvato&Servizi_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}