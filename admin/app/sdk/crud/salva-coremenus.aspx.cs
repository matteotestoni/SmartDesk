using System;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{

    protected void Page_Load(object sender, EventArgs e)
    {
    	string strKy="";

      if (Smartdesk.Login.Verify){
        Dictionary<string, object> frm = new Dictionary<string, object>();
		strKy = Smartdesk.Functions.SqlWriteKey("CoreMenus");
		Response.Redirect("/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=227&CoreGrids_Ky=239&CoreForms_Ky=160&salvato=salvato&CoreMenus_Ky=" + strKy);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

}
