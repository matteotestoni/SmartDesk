using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    public string strAzione = "";
    
    
    public string strWHERENet = "";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public DataTable dtComuniZone;
    public int intNumRecords = 0;
    public DataTable dtLogin;
    public string strComuni_Ky="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());        
          strComuni_Ky=Smartdesk.Current.Request("Comuni_Ky");
		  strAzione = Request["azione"];
	  	  strKy = Smartdesk.Functions.SqlWriteKey("ComuniZone");
		  Response.Redirect("/admin/form.aspx?CoreModules_Ky=12&CoreEntities_Ky=8&CoreGrids_Ky=9&CoreForms_Ky=131&&azione=edit&salvato=salvato&Comuni_Ky=" + strComuni_Ky);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
