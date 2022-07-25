using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strSQL = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
			Dictionary<string, object> frm = new Dictionary<string, object>();
			if (Smartdesk.Current.Request("ProdottiGruppi_Default") == "") frm.Add("ProdottiGruppi_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("ProdottiGruppi", frm);
			if (Smartdesk.Current.Request("ProdottiGruppi_Default")=="True" || Smartdesk.Current.Request("ProdottiGruppi_Default").Equals(true)){
		        strSQL = "UPDATE ProdottiGruppi SET ProdottiGruppi_Default=0 WHERE ProdottiGruppi_Ky<>" + strKy;
		        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
			}
            strRedirect = "/admin/app/catalogo/scheda-prodottigruppi.aspx?salvato=salvato&ProdottiGruppi_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}