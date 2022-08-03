using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    public string strAzione = "";
    public string strKy = "";
    
    
    public string strWHERENet = "";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public DataTable dtAziende;
    public int intNumRecords = 0;
    public DataTable dtLogin;
    public string strAziende_Ky = "";
    public string strSorgente="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strRedirect = Smartdesk.Current.LoginPageRoot;
      
      
	  
      if (Smartdesk.Login.Verify){
        strSorgente = Smartdesk.Current.Form("sorgente");
		    dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());        
		    strAzione = Request["azione"];
        strAziende_Ky = Request["Aziende_Ky"];
		    strKy = Smartdesk.Functions.SqlWriteKey("AziendeSediOrari");
        switch (strSorgente)
        {
            case "scheda-aziende":
                strRedirect = "/admin/app/core/scheda-azienda.aspx?salvato=salvato&AziendeSediOrari_Ky=" + strKy + "&Aziende_Ky=" + strAziende_Ky;
                break;
            default:
                strRedirect = "/admin/app/core/scheda-azienda.aspx?salvato=salvato&AziendeSediOrari_Ky=" + strKy + "&Aziende_Ky=" + strAziende_Ky;
                break;
        }
        Response.Redirect(strRedirect);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
