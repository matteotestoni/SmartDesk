using System;
using System.Collections.Generic;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strForms_Ky = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
          Dictionary<string, object> frm = new Dictionary<string, object>();
      	  if (Smartdesk.Current.Request("FormsFields_Obbligatorio") == "") frm.Add("FormsFields_Obbligatorio", false);
            strForms_Ky=Request["Forms_Ky"];
            strKy = Smartdesk.Functions.SqlWriteKey("FormsFields", frm);
            strRedirect = "/admin/form.aspx?CoreModules_Ky=16&CoreEntities_Ky=146&CoreGrids_Ky=96&CoreForms_Ky=151&custom=0&azione=edit&Forms_Ky="+ strForms_Ky;
            //strRedirect = "/admin/form.aspx?CoreModules_Ky=16&CoreEntities_Ky=148&CoreGrids_Ky=98&CoreForms_Ky=180&azione=edit&salvato=salvato&FormsFields_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}