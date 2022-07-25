using System;
using System.Data;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{

    protected void Page_Load(object sender, EventArgs e)
    {
    	string strKy="";
    	string strAjax="";

      if (Smartdesk.Login.Verify){
    		Dictionary<string, object> frm = new Dictionary<string, object>();
    		strKy = Smartdesk.Functions.SqlWriteKey("CoreModulesOptionsValue");
        strAjax = Request["ajax"];
        if (Convert.ToBoolean(strAjax)==true){
          Response.Write("ok");
        }else{
          Response.Redirect("/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=230&CoreGrids_Ky=242&CoreForms_Ky=164&custom=0&azione=edit&salvato=salvato&CoreModulesOptionsValue_Ky=" + strKy);        
        }
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

}
