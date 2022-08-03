using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;


public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public bool boolCambioForm = false;
    public DataTable dtCoreForms;
    public DataTable dtCoreEntities;
    public DataTable dtFormsData;
    public DataTable dtOpportunita;
    public DataTable dtOpportunitaStati;
    public DataTable dtAttivitaTipo;
    public DataTable dtAttivitaDaFare;
    public DataTable dtAttivitaCompletate;
    public DataTable dtUtenti;
    public DataTable dtDocumenti;
    public DataTable dtPreventiviAuto;
    public DataTable dtCurrentCoreForms;
    public string strFROMNet = "";
    public string strH1 = "Commerciale > Scheda trattativa";
    public string strAzione = "modifica";
    
    public string strAnagrafiche_Ky = "";
    public string strAnagrafiche_RagioneSociale = "";
    public DataTable dtTemp;
    public string strSorgente = "";
    public int intAnagrafiche_Ky = 0;
    public string strOpportunita_Ky = "";
    public decimal decTot=0; 
    public decimal decTotQta=0; 
    public string strUtentiGruppi_Ky = "";
    public int intCoreEntities_Ky = 138;
    public int intCoreModules_Ky = 20;
    public int intCoreForms_Ky = 90;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          boolCambioForm = (dtLogin.Rows[0]["Utenti_CambioForm"]).Equals (true);
      	  strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
          strUtentiGruppi_Ky=dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
      	  strOpportunita_Ky=Smartdesk.Current.Request("Opportunita_Ky");
          strAzione = Request["azione"];
          strSorgente=Smartdesk.Current.Request("sorgente");

          strWHERENet = "(CoreForms_Ky=" + intCoreForms_Ky + ")";
          strFROMNet = "CoreForms_Vw";
          strORDERNet = "CoreForms_Ky";
          dtCurrentCoreForms = new DataTable ("CurrentCoreForms");
          dtCurrentCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreForms_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          strWHERENet = "(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreEntities_Ky=" + intCoreEntities_Ky + ")";
          strFROMNet = "UsergroupsForms_Vw";
          strORDERNet = "CoreForms_Ky";
          dtCoreForms = new DataTable ("CoreForms");
          dtCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsForms_Ky", strWHERENet, strORDERNet, 1, 2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          strWHERENet = "(CoreEntities_Ky=" + dtCurrentCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + ")";
          strFROMNet = "CoreEntities_Vw";
          strORDERNet = "CoreEntities_Ky";
          dtCoreEntities = new DataTable ("CoreEntities");
          dtCoreEntities = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1, 2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          strWHERENet="Utenti_Attivo=1";
          strORDERNet = "Utenti_Nome, Utenti_Cognome";
          strFROMNet = "Utenti";
          dtUtenti = new DataTable("Utenti");
          dtUtenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (strAzione!="new"){
              strAzione = "modifica";
    	  	  	dtOpportunita = Smartdesk.Data.Read("Opportunita_Vw", "Opportunita_Ky",Smartdesk.Current.QueryString("Opportunita_Ky"));
              dtFormsData = dtOpportunita;

        			strAnagrafiche_Ky=dtOpportunita.Rows[0]["Anagrafiche_Ky"].ToString();
        			strAnagrafiche_RagioneSociale=dtOpportunita.Rows[0]["Anagrafiche_RagioneSociale"].ToString();
                  
                strWHERENet = "";
                strORDERNet = "OpportunitaStati_Ordine, OpportunitaStati_Ky DESC";
                strFROMNet = "OpportunitaStati";
                dtOpportunitaStati = new DataTable("OpportunitaStati");
                dtOpportunitaStati = Smartdesk.Sql.getTablePage(strFROMNet, null, "OpportunitaStati_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                
                //documenti
                strWHERENet="Opportunita_Ky=" + Smartdesk.Current.Request("Opportunita_Ky");
                strORDERNet = "Documenti_Ky Desc";
                strFROMNet = "Documenti_Vw";
                dtDocumenti = new DataTable("Documenti");
                dtDocumenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                
                //preventivi auto
                strWHERENet="Opportunita_Ky=" + Smartdesk.Current.Request("Opportunita_Ky");
                strORDERNet = "PreventiviAuto_Ky Desc";
                strFROMNet = "PreventiviAuto_Vw";
                dtPreventiviAuto = new DataTable("PreventiviAuto");
                dtPreventiviAuto = Smartdesk.Sql.getTablePage(strFROMNet, null, "PreventiviAuto_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                //attività
                if (dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){
                  strWHERENet="AttivitaTipo_Attiva=1";
                  strORDERNet = "AttivitaTipo_Ordine, AttivitaTipo_Ky DESC";
                  strFROMNet = "AttivitaTipo";
                  dtAttivitaTipo = new DataTable("AttivitaTipo");
                  dtAttivitaTipo = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttivitaTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  
                  strWHERENet="Attivita_Completo<>'si' AND Opportunita_Ky=" + Smartdesk.Current.Request("Opportunita_Ky");
                  strORDERNet = "Attivita_Scadenza DESC, Attivita_Ky";
                  strFROMNet = "Attivita_Vw";
                  dtAttivitaDaFare = new DataTable("AttivitaDaFare");
                  dtAttivitaDaFare = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  
		          strWHERENet="Attivita_Completo='si' AND Opportunita_Ky=" + Smartdesk.Current.Request("Opportunita_Ky");
                  strORDERNet = "Attivita_Scadenza DESC, Attivita_Ky";
                  strFROMNet = "Attivita_Vw";
                  dtAttivitaCompletate = new DataTable("AttivitaCompletate");
                  dtAttivitaCompletate = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                }            
			
    			}else{
    				if (strAnagrafiche_Ky!=null && strAnagrafiche_Ky.Length>0){
    					strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
              strORDERNet = "Anagrafiche_Ky";
              strFROMNet = "Anagrafiche";
              dtTemp = new DataTable("Anagrafiche");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    					strAnagrafiche_RagioneSociale=dtTemp.Rows[0]["Anagrafiche_RagioneSociale"].ToString();
    				}
    			}            
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public String GetDefaultValue(string strField)
    {
      string strValore="";
      switch (strField){
				case "Anagrafiche_Ky":
					strValore=strAnagrafiche_Ky;
					break;
				case "Opportunita_ValoreMin":
					strValore="0";
					break;
				case "Opportunita_ValoreMax":
					strValore="0";
					break;
				case "Anagrafiche_RagioneSociale":
					strValore=strAnagrafiche_RagioneSociale;
					break;
				case "Opportunita_Data":
					strValore=DateTime.Now.ToString("d");
					break;
				case "Opportunita_Data_IT":
					strValore=DateTime.Now.ToString("d");
					break;
				case "OpportunitaStati_Ky":
					strValore="5";
					break;
			}
      return strValore;
    }

    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        strValore=dtTabella.Rows[0][strField].ToString();
      }
      return strValore;
    }
    
    public Boolean GetCheckValue(DataTable dtTabella, string strField)
    {
      Boolean boolValore=false;
      if (strAzione=="new"){
        boolValore=false;
      }else{
        if (dtTabella.Rows[0][strField].Equals(true)){
          boolValore=true;
        }
      }
      return boolValore;
    }
}
