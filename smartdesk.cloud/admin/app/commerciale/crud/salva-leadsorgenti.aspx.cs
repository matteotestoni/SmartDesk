using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
          strKy = Smartdesk.Functions.SqlWriteKey("LeadSorgenti");
          strRedirect = "/admin/form.aspx?CoreModules_Ky=20&CoreEntities_Ky=182&CoreGrids_Ky=172&CoreForms_Ky=67&custom=0&azione=edit&LeadSorgenti_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}
