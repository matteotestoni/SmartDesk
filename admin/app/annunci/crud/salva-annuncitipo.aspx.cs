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
            if (Smartdesk.Current.Request("AnnunciTipo_Default") == "") frm.Add("AnnunciTipo_Default", false);
            if (Smartdesk.Current.Request("AnnunciTipo_Attivo") == "") frm.Add("AnnunciTipo_Attivo", false);
            strKy = Smartdesk.Functions.SqlWriteKey("AnnunciTipo", frm);
            if (Smartdesk.Current.Request("AnnunciTipo_Default") == "True" || Smartdesk.Current.Request("AnnunciTipo_Default").Equals(true))
            {
                strSQL = "UPDATE AnnunciTipo SET AnnunciTipo_Default=0 WHERE AnnunciTipo_Ky<>" + strKy;
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }


            strRedirect = "/admin/view.aspx?CoreModules_Ky=3&CoreEntities_Ky=58&CoreGrids_Ky=48";
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
