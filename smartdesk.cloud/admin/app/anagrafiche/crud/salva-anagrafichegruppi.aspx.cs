using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      string strSQL = "";
      string strRedirect = Smartdesk.Current.LoginPageRoot;
      bool boolAjax = false;
        if (Smartdesk.Login.Verify)
        {
      			Dictionary<string, object> frm = new Dictionary<string, object>();
      			if (Smartdesk.Current.Request("AnagraficheGruppi_Default") == "") frm.Add("AnagraficheGruppi_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("AnagraficheGruppi", frm);
    				if (Smartdesk.Current.Request("AnagraficheGruppi_Default")=="True" || Smartdesk.Current.Request("AnagraficheGruppi_Default").Equals(true)){
              strSQL = "UPDATE AnagraficheGruppi SET AnagraficheGruppi_Default=0 WHERE AnagraficheGruppi_Ky<>" + strKy;
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
    				}
            strRedirect = "/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=132&CoreGrids_Ky=35";
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
