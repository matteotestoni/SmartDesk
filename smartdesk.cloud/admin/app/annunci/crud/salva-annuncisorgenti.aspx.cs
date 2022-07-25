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
            if (Smartdesk.Current.Request("AnnunciSorgenti_Default") == "") frm.Add("AnnunciSorgenti_Default", false);
            if (Smartdesk.Current.Request("AnnunciSorgenti_Attivo") == "") frm.Add("AnnunciSorgenti_Attivo", false);
            strKy = Smartdesk.Functions.SqlWriteKey("AnnunciSorgenti", frm);
            if (Smartdesk.Current.Request("AnnunciSorgenti_Default") == "True" || Smartdesk.Current.Request("AnnunciSorgenti_Default").Equals(true))
            {
                strSQL = "UPDATE AnnunciSorgenti SET AnnunciSorgenti_Default=0 WHERE AnnunciSorgenti_Ky<>" + strKy;
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }


            strRedirect = "/admin/view.aspx?CoreModules_Ky=3&CoreEntities_Ky=213&CoreGrids_Ky=222";
            Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
