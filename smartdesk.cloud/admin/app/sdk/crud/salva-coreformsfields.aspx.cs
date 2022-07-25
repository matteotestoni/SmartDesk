using System;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{

    protected void Page_Load(object sender, EventArgs e)
    {
    	string strKy="";

      if (Smartdesk.Login.Verify){
        Dictionary<string, object> frm = new Dictionary<string, object>();
        if (Smartdesk.Current.Request("CoreFormsFields_Hidden") == "") frm.Add("CoreFormsFields_Hidden", false);
				strKy = Smartdesk.Functions.SqlWriteKey("CoreFormsFields",frm);
				Response.Redirect("/admin/app/sdk/scheda-CoreForms.aspx?salvato=salvato&CoreModules_Ky=" + Request["CoreModules_Ky"] + "&CoreForms_Ky=" + Request["CoreForms_Ky"] + "#CoreFormsFields");
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

}
