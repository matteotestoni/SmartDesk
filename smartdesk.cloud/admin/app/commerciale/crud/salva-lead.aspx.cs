using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strCoreForms_Ky = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
          strCoreForms_Ky=Request["CoreForms_Ky"];
          strKy = Smartdesk.Functions.SqlWriteKey("Lead");
          strRedirect = "/admin/form.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&CoreForms_Ky=" + strCoreForms_Ky  + "&custom=0&azione=edit&Lead_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}
