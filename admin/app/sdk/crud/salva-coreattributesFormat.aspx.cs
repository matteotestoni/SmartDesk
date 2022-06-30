using System;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{

    protected void Page_Load(object sender, EventArgs e)
    {
    	string strKy="";
      if (Smartdesk.Login.Verify){
        Dictionary<string, object> frm = new Dictionary<string, object>();
			strKy = Smartdesk.Functions.SqlWriteKey("CoreAttributesFormat", frm);
			Response.Redirect("/admin/view.aspx?CoreModules_Ky=26&CoreEntities_Ky=179&CoreGrids_Ky=169&CoreAttributesFormat_Ky=" + strKy);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

}
