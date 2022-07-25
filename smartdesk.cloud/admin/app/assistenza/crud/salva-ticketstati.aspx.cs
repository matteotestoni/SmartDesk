using System;

  public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e){
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify){
            strRedirect = "/admin/form.aspx?CoreModules_Ky=32&CoreEntities_Ky=220&CoreGrids_Ky=230&CoreForms_Ky=148&salvato=salvato&TicketStati_Ky=" + Smartdesk.Functions.SqlWriteKey("TicketStati");
        }
        Response.Redirect(strRedirect);
    }
}
