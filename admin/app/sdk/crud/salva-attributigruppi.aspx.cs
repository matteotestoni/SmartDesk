using System;

  public partial class _Default : System.Web.UI.Page 
	{
    public string strAzione = "";
    public string strAttributiGruppi_Ky = "";
    public int intNumRecords = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (Smartdesk.Login.Verify){
        strAzione = Request["azione"];
        strAttributiGruppi_Ky = Smartdesk.Functions.SqlWriteKey("AttributiGruppi");
        Response.Redirect("/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=217&CoreGrids_Ky=226&CoreForms_Ky=138&custom=0&azione=edit&zzsalvato=salvato&AttributiGruppi_Ky=" + strAttributiGruppi_Ky);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

}
