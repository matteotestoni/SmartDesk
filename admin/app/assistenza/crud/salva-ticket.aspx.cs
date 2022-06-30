using System;

  public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e){
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify){
            strRedirect = "/admin/form.aspx?CoreModules_Ky=32&CoreEntities_Ky=221&CoreGrids_Ky=231&CoreForms_Ky=147&salvato=salvato&Ticket_Ky=" + Smartdesk.Functions.SqlWriteKey("Ticket");
        }
        Response.Redirect(strRedirect);
    }
}
