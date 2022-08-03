using System;
using System.Data;

  public partial class _Default : System.Web.UI.Page 
	{
    public bool fCaricato = false;
    public string strAzione = "";
    
    
    public string strWHERENet = "";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public DataTable dtBlacklistEmail;
    public int intNumRecords = 0;
    public DataTable dtLogin;
    
    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      
      
	  
      if (Smartdesk.Login.Verify){
        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());        
		    strAzione = Request["azione"];
        strKy = Smartdesk.Functions.SqlWriteKey("BlacklistEmail");
	      Response.Redirect("/admin/view.aspx?CoreModules_Ky=12&CoreEntities_Ky=21&CoreGrids_Ky=20");
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
