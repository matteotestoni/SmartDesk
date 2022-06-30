using System;
using System.Data;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      string strSQL = "";
      string strRedirect = Smartdesk.Current.LoginPageRoot;
      if (Smartdesk.Login.Verify){
  		  Dictionary<string, object> frm = new Dictionary<string, object>();
  		  if (Smartdesk.Current.Request("OpportunitaSorgenti_Predefinita") == "") frm.Add("OpportunitaSorgenti_Predefinita", false);
  		  if (Smartdesk.Current.Request("OpportunitaSorgenti_Attiva") == "") frm.Add("OpportunitaSorgenti_Attiva", false);
        strKy = Smartdesk.Functions.SqlWriteKey("OpportunitaSorgenti", frm);
            if (Smartdesk.Current.Request("OpportunitaSorgenti_Predefinita")=="on" || Smartdesk.Current.Request("OpportunitaSorgenti_Predefinita")=="True" || Smartdesk.Current.Request("OpportunitaSorgenti_Predefinita").Equals(true)){
		        strSQL = "UPDATE OpportunitaSorgenti SET OpportunitaSorgenti_Predefinita=0 WHERE OpportunitaSorgenti_Ky<>" + strKy;
		        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
			}
        strRedirect = "/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=139&CoreGrids_Ky=108";
        Response.Redirect(strRedirect);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
	  }
    }
}