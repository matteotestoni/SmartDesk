using System;
using System.Data;

public partial class _Default : System.Web.UI.Page {
    public string strAzione = "";
    
    public DataTable dtLingue;
    public int intNumRecords = 0;
    public DataTable dtLogin;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      
	  
      if (Smartdesk.Login.Verify){
        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());        
	      strAzione = Request["azione"];
	  	  strKy = Smartdesk.Functions.SqlWriteKey("Lingue");
		    Response.Redirect("/admin/view.aspx?CoreModules_Ky=12&CoreEntities_Ky=9&CoreGrids_Ky=10");
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
