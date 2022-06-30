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
					if (Smartdesk.Current.Request("Veicoli_PubblicaWEB") == "") frm.Add("Veicoli_PubblicaWEB", false);
					if (Smartdesk.Current.Request("Veicoli_Premium") == "") frm.Add("Veicoli_Premium", false);
					if (Smartdesk.Current.Request("Veicoli_Inevidenza") == "") frm.Add("Veicoli_Inevidenza", false);
					if (Smartdesk.Current.Request("Veicoli_Prime") == "") frm.Add("Veicoli_Prime", false);
					if (Smartdesk.Current.Request("Veicoli_LastMinute") == "") frm.Add("Veicoli_LastMinute", false);
          strKy = Smartdesk.Functions.SqlWriteKey("Veicoli",frm);
          strRedirect = "/admin/app/veicoli/scheda-veicoli.aspx?salvato=salvato&Veicoli_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}