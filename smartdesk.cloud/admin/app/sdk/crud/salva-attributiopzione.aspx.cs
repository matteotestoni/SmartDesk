using System;
using System.Data;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public string strAttributi_Ky="";
    public string strAttributiOpzioni_Ky="";
    public string strAzione = "";
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public string strSorgente="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());        
          strAttributi_Ky=Smartdesk.Current.Request("Attributi_Ky");
          strSorgente=Smartdesk.Current.Request("sorgente");
		  Dictionary<string, object> frm = new Dictionary<string, object>();
		  if (Smartdesk.Current.Request("AttributiOpzioni_Default") == "") frm.Add("AttributiOpzioni_Default", false);
		  strKy = Smartdesk.Functions.SqlWriteKey("AttributiOpzioni", frm);
          Response.Redirect("/admin/app/sdk/scheda-attributi.aspx?salvato=salvato&Attributi_Ky=" + strAttributi_Ky);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
