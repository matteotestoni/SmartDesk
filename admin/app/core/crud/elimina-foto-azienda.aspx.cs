using System;
using System.Data;


  public partial class _Default : System.Web.UI.Page 
	{

    public string strLogin="";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    
    public string strAziende_Ky="";


    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
            if (dtLogin.Rows.Count>0){
                strAziende_Ky=Smartdesk.Current.Request("Aziende_Ky");               
                strSQL = "UPDATE Aziende SET Aziende_Logo=null WHERE Aziende_Ky=" + strAziende_Ky;
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                Response.Redirect("/admin/app/core/scheda-azienda.aspx?Aziende_Ky=" + strAziende_Ky);
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
