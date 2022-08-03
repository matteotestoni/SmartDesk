using System;
using System.Data;
using System.Data.SqlClient;


public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int intNumRecordsSidebar = 0;
    public int intNumRecordsToolbar = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ciit = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo cien = new System.Globalization.CultureInfo("en-US");
    public string strLogin="";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    
    public DataTable dtCMSLink;
    public DataTable dtTemp;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strRisultato = "";
    public string strTemp = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
            strH1="Aggiornamento DB";
            //strRisultato += "<b>Generazioen XML</b><br>";
            //strRisultato +=Smartdesk.Functions.ManutenzioneScaricaTuttoDBToXML();
            strRisultato += "<b>ADD Date/User su tutto le tabelle</b><br>";
            strRisultato += Smartdesk.Functions.ManutenzioneAddDateUserTuttoDBToXML();

            
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
}
