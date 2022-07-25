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
			if (Smartdesk.Current.Request("ProdottiDisponibilita_Default") == "") frm.Add("ProdottiDisponibilita_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("ProdottiDisponibilita",frm);
      			if (Smartdesk.Current.Request("ProdottiDisponibilita_Default")=="True" || Smartdesk.Current.Request("ProdottiDisponibilita_Default").Equals(true)){
      		        strSQL = "UPDATE ProdottiDisponibilita SET ProdottiDisponibilita_Default=0 WHERE ProdottiDisponibilita_Ky<>" + strKy;
      		        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
      			}
            strRedirect = "/admin/app/catalogo/scheda-ProdottiDisponibilita.aspx?salvato=salvato&ProdottiDisponibilita_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}