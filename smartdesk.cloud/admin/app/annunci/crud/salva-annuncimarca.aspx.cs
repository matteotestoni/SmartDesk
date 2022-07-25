using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      string strRedirect = Smartdesk.Current.LoginPageRoot;
      bool boolAjax = false;
        if (Smartdesk.Login.Verify)
        {
	        Dictionary<string, object> frm = new Dictionary<string, object>();
	        if (Smartdesk.Current.Request("AnnunciMarca_Importante") == "") frm.Add("AnnunciMarca_Importante", false);
            strKy = Smartdesk.Functions.SqlWriteKey("AnnunciMarca", frm);
            strRedirect = "/admin/app/annunci/scheda-annuncimarca.aspx?salvato=salvato&AnnunciMarca_Ky=" + strKy;
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
