using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public int j = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public string strSitiWebLog_Descrizione="";
    public DataTable dtSitiWeb;
    public DataTable dtSitiWebLog;
    public DataTable dtSitiWebPageSpeedLog;
    public DataTable dtPasswordmanager;
    public DataTable dtAnagraficheContatti;
    public DataTable dtAnagrafica;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "Sito";
    public string strAzione = "";
    
    public string strScoreDesktop = "";
    public string strScoreMobile = "";
    public string strAnagrafiche_Ky = "";
    public string strAnagrafiche_RagioneSociale = "";
    public string strWHERENet="";
    public string strORDERNet="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            strH1="Scheda Sito Web";
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strAzione = Request["azione"];
            if (strAzione!="new"){
                strAzione = "modifica";
    	  	  	dtSitiWeb = Smartdesk.Data.Read("SitiWeb_Vw", "SitiWeb_Ky",Smartdesk.Current.QueryString("SitiWeb_Ky"));
	            //log
							strWHERENet="SitiWeb_Url='" + GetFieldValue(dtSitiWeb, "SitiWeb_Url") + "'";
	            strORDERNet = "SitiWebLog_Descrizione ASC, SitiWebLog_Data ASC, SitiWebLog_Ky DESC";
	            strFROMNet = "SitiWebLog";
	            dtSitiWebLog = new DataTable("SitiWebLog");
	            dtSitiWebLog = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWebLog_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                //log pagespeed
                strWHERENet = "SitiWeb_Ky=" + GetFieldValue(dtSitiWeb, "SitiWeb_Ky");
                strORDERNet = "SitiWebPageSpeedLog_Data DESC, SitiWeb_Url";
                strFROMNet = "SitiWebPageSpeedLog";
                dtSitiWebPageSpeedLog = new DataTable("SitiWebPageSpeedLog");
                dtSitiWebPageSpeedLog = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWebPageSpeedLog_Ky", strWHERENet, strORDERNet, 1, 30,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                //contatti
                if (dtSitiWeb.Rows[i]["Anagrafiche_Ky"].ToString().Length>0){
  				  			strWHERENet="Anagrafiche_Ky=" + dtSitiWeb.Rows[i]["Anagrafiche_Ky"].ToString() + " AND SitiWeb_Ky=" + Smartdesk.Current.Request("SitiWeb_Ky");
  	              strORDERNet = "AnagraficheContatti_Email";
  	              strFROMNet = "AnagraficheContatti_Vw";
  	              dtAnagraficheContatti = new DataTable("AnagraficheContatti");
  	              dtAnagraficheContatti = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheContatti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              	}

                //password
                if (dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString().Length>0){
  				  			strWHERENet="SitiWeb_Ky=" + dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString();
  	              strORDERNet = "PasswordManager_Ky DESC";
  	              strFROMNet = "PasswordManager_Vw";
  	              dtPasswordmanager = new DataTable("Passwordmanager");
  	              dtPasswordmanager = Smartdesk.Sql.getTablePage(strFROMNet, null, "Passwordmanager_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              	}

	          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    
    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        strValore = Smartdesk.Data.Field (dtTabella, strField);
      }
      return strValore;

    }
    
    public Boolean GetCheckValue(string strField)
    {
      Boolean boolValore=false;
      if (strAzione=="new"){
        boolValore=false;
      }else{
        if (dtSitiWeb.Rows[0][strField].Equals(true)){
          boolValore=true;
        }
      }
      return boolValore;
    }

    public String GetDefaultValue(string strField)
    {
        string strValore = "";
        switch (strField)
        {
					case "Anagrafiche_Ky":
		  			strAnagrafiche_Ky = Smartdesk.Current.Request("Anagrafiche_Ky");
            if (strAnagrafiche_Ky!=null && strAnagrafiche_Ky.Length>0){
              strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
              strORDERNet = "Anagrafiche_Ky";
              strFROMNet = "Anagrafiche";
              dtAnagrafica = new DataTable("Anagrafica");
              dtAnagrafica = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              strAnagrafiche_RagioneSociale=dtAnagrafica.Rows[0]["Anagrafiche_RagioneSociale"].ToString();
              strValore=strAnagrafiche_Ky;
            }
						break;
					case "Anagrafiche_RagioneSociale":
						strValore=strAnagrafiche_RagioneSociale;
						break;
        }
        return strValore;
    }
}
