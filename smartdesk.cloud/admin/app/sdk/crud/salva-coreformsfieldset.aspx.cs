using System;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{

    protected void Page_Load(object sender, EventArgs e)
    {
    	string strKy="";

      if (Smartdesk.Login.Verify){
        Dictionary<string, object> frm = new Dictionary<string, object>();
		strKy = Smartdesk.Functions.SqlWriteKey("CoreFormsFieldset",frm);
		Response.Redirect("/admin/app/sdk/scheda-CoreForms.aspx?salvato=salvato&CoreForms_Ky=" + Request["CoreForms_Ky"]);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

}
