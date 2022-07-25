using System;
using System.Data;

  public partial class _Default : System.Web.UI.Page 
	{
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public string strComuniZone_Ky="";
    public string strComuni_Ky="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          strComuni_Ky=Smartdesk.Current.Request("Comuni_Ky");
          strComuniZone_Ky=Smartdesk.Current.Request("ComuniZone_Ky");
          strSQL = "DELETE FROM ComuniZone WHERE ComuniZone_Ky=" + strComuniZone_Ky;
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
          Response.Redirect("/admin/form.aspx?CoreModules_Ky=12&CoreEntities_Ky=8&CoreGrids_Ky=9&CoreForms_Ky=131&&azione=edit&salvato=salvato&Comuni_Ky=" + strComuni_Ky);
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
