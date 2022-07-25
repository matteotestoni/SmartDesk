using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
          strKy = Smartdesk.Functions.SqlWriteKey("LeadFormulaAcquisto");
          strRedirect = "/admin/form.aspx?CoreModules_Ky=20&CoreEntities_Ky=184&CoreGrids_Ky=174&CoreForms_Ky=95&custom=0&azione=edit&LeadFormulaAcquisto_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}