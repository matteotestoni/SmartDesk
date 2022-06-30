using System;

  public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e){
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify){
            strRedirect = "/admin/form.aspx?CoreModules_Ky=32&CoreEntities_Ky=219&CoreGrids_Ky=229&CoreForms_Ky=146&salvato=salvato&TicketCategorie_Ky=" + Smartdesk.Functions.SqlWriteKey("TicketCategorie");
        }
        Response.Redirect(strRedirect);
    }
}
