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
    public DataTable dtComuni;
    public int intNumRecords = 0;
    public DataTable dtLogin;
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      
      
	  
      if (Smartdesk.Login.Verify){
         dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());        
		    strAzione = Request["azione"];
	  	  strKy = Smartdesk.Functions.SqlWriteKey("Comuni");
		    Response.Redirect("/admin/form.aspx?CoreModules_Ky=12&CoreEntities_Ky=8&CoreGrids_Ky=9&CoreForms_Ky=131&&azione=edit&salvato=salvato&Comuni_Ky=" + strKy);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
