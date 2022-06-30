using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      string strSQL = "";
      string strRedirect = Smartdesk.Current.LoginPageRoot;
      string strSorgente = Smartdesk.Current.Request("sorgente");
      bool boolAjax = false;
      string strFunzione = "";

        if (Smartdesk.Login.Verify){
      			Dictionary<string, object> frm = new Dictionary<string, object>();
      			if (Smartdesk.Current.Request("Conti_Default") == "") frm.Add("Conti_Default", false);
            strKy = Smartdesk.Functions.SqlWriteKey("Conti",frm);
    				strFunzione=Smartdesk.Amministrazione.Conti_AfterSave(strKy);
	          strRedirect="/admin/view.aspx?CoreModules_Ky=2&CoreEntities_Ky=105&CoreGrids_Ky=40";
	          Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}
