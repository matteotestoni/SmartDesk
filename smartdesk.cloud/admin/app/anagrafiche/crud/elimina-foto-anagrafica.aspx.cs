using System;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
	public string strAnagrafiche_Ky = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSQL = "";
        if (Smartdesk.Login.Verify)
        {
            strAnagrafiche_Ky = Smartdesk.Current.Request("Anagrafiche_Ky");
            strSQL = "UPDATE Anagrafiche SET Anagrafiche_Logo=null WHERE Anagrafiche_Ky=" + strAnagrafiche_Ky;
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strRedirect="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=" + strAnagrafiche_Ky;
			Response.Redirect(strRedirect);
        }
        else
        {
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}
