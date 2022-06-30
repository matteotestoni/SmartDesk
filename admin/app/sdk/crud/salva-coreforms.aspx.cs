using System;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{

    protected void Page_Load(object sender, EventArgs e)
    {
    	string strKy="";

      if (Smartdesk.Login.Verify){
        Dictionary<string, object> frm = new Dictionary<string, object>();
        if (Smartdesk.Current.Request("CoreForms_Default") == "") frm.Add("CoreForms_Default", false);
        if (Smartdesk.Current.Request("CoreForms_Custom") == "") frm.Add("CoreForms_Custom", false);
		strKy = Smartdesk.Functions.SqlWriteKey("CoreForms",frm);
		Response.Redirect("/admin/app/sdk/scheda-CoreForms.aspx?salvato=salvato&CoreModules_Ky=" + Request["CoreModules_Ky"] + "&CoreForms_Ky=" + strKy);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

}
