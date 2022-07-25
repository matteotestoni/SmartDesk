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
			if (Smartdesk.Current.Request("ProdottiApplicazioni_Default") == "") frm.Add("ProdottiApplicazioni_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("ProdottiApplicazioni", frm);
			if (Smartdesk.Current.Request("ProdottiApplicazioni_Default")=="True" || Smartdesk.Current.Request("ProdottiApplicazioni_Default").Equals(true)){
		        strSQL = "UPDATE ProdottiApplicazioni SET ProdottiApplicazioni_Default=0 WHERE ProdottiApplicazioni_Ky<>" + strKy;
		        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
			}
            strRedirect = "/admin/app/catalogo/scheda-prodottiapplicazioni.aspx?salvato=salvato&ProdottiApplicazioni_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}