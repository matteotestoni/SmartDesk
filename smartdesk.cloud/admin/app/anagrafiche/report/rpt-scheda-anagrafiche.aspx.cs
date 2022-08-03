using System;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtAnagrafiche;
    public DataTable dtAnagraficheContatti;
    public DataTable dtAnagraficheServizi;
    public DataTable dtAttivita;
    public DataTable dtPagamenti;
    public DataTable dtSitiWeb;
    public DataTable dtAzienda;
    public string strAziende_Ky = "";
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "Scheda anagrafica";
    
    public string strAzione = "modifica";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
            
            strAzione = Request["azione"];
            if (strAzione!="new"){
                    strAzione = "modifica";
				strAziende_Ky="1";            
	             //servizi
	            strWHERENet="Aziende_Ky=" + strAziende_Ky;
	            strORDERNet = "Aziende_Ky";
	            strFROMNet = "Aziende_Vw";
	            dtAzienda = new DataTable("Azienda");
	            dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            


                strWHERENet="Anagrafiche_Ky=" + Smartdesk.Current.Request("Anagrafiche_Ky");
                strORDERNet = "Anagrafiche_Ky";
                strFROMNet = "Anagrafiche_Vw";
                dtAnagrafiche = new DataTable("Anagrafiche");
                dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
                //contatti
                if (dtLogin.Rows[0]["UtentiGruppi_AnagraficheContatti"].Equals(true)){
                  strWHERENet="Anagrafiche_Ky=" + Smartdesk.Current.Request("Anagrafiche_Ky");
                  strORDERNet = "AnagraficheContatti_Ky";
                  strFROMNet = "AnagraficheContatti_Vw";
                  dtAnagraficheContatti = new DataTable("AnagraficheContatti");
                  dtAnagraficheContatti = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheContatti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                }            
                //servizi
                if (dtLogin.Rows[0]["UtentiGruppi_Servizi"].Equals(true)){
                  strWHERENet="Anagrafiche_Ky=" + Smartdesk.Current.Request("Anagrafiche_Ky");
                  strORDERNet = "AnagraficheServizi_Ky";
                  strFROMNet = "AnagraficheServizi_Vw";
                  dtAnagraficheServizi = new DataTable("AnagraficheServizi");
                  dtAnagraficheServizi = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
                }            
                //attività
                if (dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){
                  strWHERENet="Anagrafiche_Ky=" + Smartdesk.Current.Request("Anagrafiche_Ky");
                  strORDERNet = "Attivita_Ky";
                  strFROMNet = "Attivita_Vw";
                  dtAttivita = new DataTable("Attivita");
                  dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                }            
                //pagamenti
                if (dtLogin.Rows[0]["UtentiGruppi_Pagamenti"].Equals(true)){
                  strWHERENet="Anagrafiche_Ky=" + Smartdesk.Current.Request("Anagrafiche_Ky");
                  strORDERNet = "Pagamenti_Data";
                  strFROMNet = "Pagamenti_Vw";
                  dtPagamenti = new DataTable("Pagamenti");
                  dtPagamenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                }   
                //SitiWeb
                if (dtLogin.Rows[0]["UtentiGruppi_SitiWeb"].Equals(true)){
                  
									strWHERENet="Anagrafiche_Ky=" + Smartdesk.Current.Request("Anagrafiche_Ky");
                  strORDERNet = "SitiWeb_Dominio";
                  strFROMNet = "SitiWeb_Vw";
                  dtSitiWeb = new DataTable("SitiWeb");
                  dtSitiWeb = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWeb_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                }   
            }         
          }else{
            Response.Redirect("default.aspx");
          }
      }else{
            Response.Redirect("default.aspx");
      }
    }    
}
