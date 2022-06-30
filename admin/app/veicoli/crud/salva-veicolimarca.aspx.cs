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
			    if (Smartdesk.Current.Request("VeicoliMarca_Importante") == "") frm.Add("VeicoliMarca_Importante", false);
	        strKy = Smartdesk.Functions.SqlWriteKey("VeicoliMarca",frm);
	        strRedirect = "/admin/app/veicoli/scheda-veicolimarca.aspx?salvato=salvato&VeicoliMarca_Ky=" + strKy;
		      Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}