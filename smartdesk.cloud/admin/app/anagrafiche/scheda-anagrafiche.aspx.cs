using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page {
      public int intNumRecords = 0;
      public int i = 0;
      public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo ("it-IT");
      public string strLogin = "";
      public DataTable dtLogin;
      public bool boolAdmin = false;
      public bool boolWysiwyg = false;
      public bool boolCambioForm = false;
      public DataTable dtAnagrafiche;
      public DataTable dtAnagraficheIndirizzi;
      public DataTable dtAnagraficheContatti;
      public DataTable dtAnagraficheServiziAttivi;
      public DataTable dtAnagraficheServiziChiusi;
      public DataTable dtAnagraficheProdotti;
      public DataTable dtAttivitaDaFare;
      public DataTable dtAttivitaCompletateTecniche;
      public DataTable dtAttivitaCompletateAmministrative;
      public DataTable dtAttivitaCompletateCommerciali;
      public DataTable dtCoreFormsGrid;
      public string strFormUrl = "";
      public DataTable dtCurrentCoreForms;
      public DataTable dtCoreForms;
      public DataTable dtCoreFormsRelations;
      public DataTable dtCurrentCoreGrids;
      public DataTable dtCoreEntities;
      public DataTable dtCoreEntitiesGrid;
      public DataTable dtCoreModules;
      public DataTable dtCoreModulesGrid;
      public DataTable dtCoreModulesJoin;
      public DataTable dtCoreGridsButtons;
      public DataTable dtCoreGridsColumns;
      public string strViewUrl = "";
      public DataTable dtFormsData;
      public DataTable dtGridData;
      public DataTable dtGridDataChildren;
      public string strPaginationId = "";
      public string strPathWhere = "";
      public int intRecxPag = 30;
      public int intPage = 0;
      public int intNumPagine=1;
      public DataTable dtOfficina;
      public DataTable dtDocumenti;
      public DataTable dtCommesse;
      public DataTable dtAnnunci;
      public DataTable dtSpese;
      public DataTable dtTicket;
      public DataTable dtPagamenti;
      public DataTable dtPagamentiRicevuti;
      public DataTable dtPagamentiDaFare;
      public DataTable dtNote;
      public DataTable dtSitiWeb;
      public DataTable dtPasswordmanager;
      public DataTable dtFormsAvanzamento;
      public DataTable dtTemp;
      public DataTable dtAnagraficheCategorie;
      public DataTable dtAnagraficheTag;
      public DataTable dtAttributi;
      public DataTable dtAttributiOpzioni;
      public int intAnagrafiche_Ky = 0;
      public string strFROMNet = "";
      public string strH1 = "Scheda anagrafica";
      public string strAzione = "modifica";
      public string strCheckPartitaIVA = "";
      public string strCheckCodiceFiscale = "";
      public decimal decTot = 0;
      public decimal decTotQta = 0;
      public int intYear;
      public int intMonth;
      public int intAnno;
      public int intDocumenti_Ky = 0;
      public decimal decTotServizi = 0;
      public decimal decTotIVA = 0;
      public decimal decTotOre = 0;
      public string strAnagrafiche_Ky = "";
      public string strWHERENet = "";
      public string strORDERNet = "";
      public DataTable dtRegioni;
      public DataTable dtProvince;
      public DataTable dtComuni;
      public string strFieldValue = "";
      public string strRenderer = "";
      public string strUtentiGruppi_Ky = "";
      public int intCoreForms_Ky = 145;
      public int intCoreEntities_Ky = 162;
      public int intCoreModules_Ky = 1;

      protected void Page_Load (object sender, EventArgs e) {
          string strWHEREPermessi = "";
          
          strAnagrafiche_Ky = Smartdesk.Current.QueryString ("Anagrafiche_Ky");
          //Response.Write(Smartdesk.Anagrafiche.CoreModules_Ky);
          //Response.Write(Smartdesk.Functions.getOption("core.serversmpt"));
          if (Smartdesk.Login.Verify) {
              dtLogin = Smartdesk.Data.Read ("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString ());
              if (dtLogin.Rows.Count > 0) {
                  boolAdmin = (dtLogin.Rows[0]["Utenti_Admin"]).Equals (true);
                  boolCambioForm = (dtLogin.Rows[0]["Utenti_CambioForm"]).Equals (true);
  	              boolWysiwyg=(dtLogin.Rows[0]["Utenti_Wysiwyg"]).Equals(true);
                  strAzione = Request["azione"];
                  strUtentiGruppi_Ky=dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();

                  strWHERENet = "(CoreForms_Ky=" + intCoreForms_Ky + ")";
                  strFROMNet = "CoreForms_Vw";
                  strORDERNet = "CoreForms_Ky";
                  dtCurrentCoreForms = new DataTable ("CurrentCoreForms");
                  dtCurrentCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreForms_Ky", strWHERENet, strORDERNet, 1, 1, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                  strWHERENet = "(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreEntities_Ky=" + intCoreEntities_Ky + ")";
                  strFROMNet = "UsergroupsForms_Vw";
                  strORDERNet = "CoreForms_Ky";
                  dtCoreForms = new DataTable ("CoreForms");
                  dtCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsForms_Ky", strWHERENet, strORDERNet, 1, 2000, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                  strWHERENet = "(CoreEntities_Ky=" + intCoreEntities_Ky + ")";
                  strFROMNet = "CoreEntities_Vw";
                  strORDERNet = "CoreEntities_Ky";
                  dtCoreEntities = new DataTable ("CoreEntities");
                  dtCoreEntities = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1, 2000, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                  strWHERENet = "(CoreForms_Ky=" + intCoreForms_Ky + ")";
                  strFROMNet = "CoreFormsRelations";
                  strORDERNet = "CoreFormsRelations_Order, CoreFormsRelations_Ky";
                  dtCoreFormsRelations = new DataTable ("CoreFormsRelations");
                  dtCoreFormsRelations = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsRelations_Ky", strWHERENet, strORDERNet, 1, 2000, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                  //tabelle base
                  strWHERENet = "";
                  strORDERNet = "AnagraficheTag_Tag";
                  strFROMNet = "AnagraficheTag";
                  dtAnagraficheTag = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheTag_Ky", strWHERENet, strORDERNet, 1, 1000, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                  if (strAzione != "new") {
                      dtAnagrafiche = Smartdesk.Data.Read ("Anagrafiche_Vw", "Anagrafiche_Ky", strAnagrafiche_Ky);
                      dtFormsData = dtAnagrafiche;
                      strH1 = Smartdesk.Data.Field (dtAnagrafiche, "Anagrafiche_RagioneSociale");
                      checkPermessi (Smartdesk.Data.Field (dtAnagrafiche, "Utenti_Ky"), Smartdesk.Data.Field (dtAnagrafiche, "UtentiGruppi_Ky"));

                      //regioni
                      if (dtAnagrafiche.Rows[0]["Nazioni_Ky"].ToString () != "") {
                          strWHERENet = "Nazioni_Ky=" + dtAnagrafiche.Rows[0]["Nazioni_Ky"].ToString ();
                      } else {
                          strWHERENet = "";
                      }
                      strORDERNet = "Regioni_Regione";
                      strFROMNet = "Regioni";
                      dtRegioni = Smartdesk.Sql.getTablePage(strFROMNet, null, "Regioni_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      //province
                      if (dtAnagrafiche.Rows[0]["Regioni_Ky"].ToString () != "") {
                          strWHERENet = "Regioni_Ky=" + dtAnagrafiche.Rows[0]["Regioni_Ky"].ToString ();
                      } else {
                          strWHERENet = "";
                      }
                      strORDERNet = "Province_Provincia";
                      strFROMNet = "Province";
                      dtProvince = Smartdesk.Sql.getTablePage(strFROMNet, null, "Province_Ky", strWHERENet, strORDERNet, 1, 200, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      //Comuni
                      if (dtAnagrafiche.Rows[0]["Province_Ky"].ToString () != "") {
                          strWHERENet = "Province_Ky=" + dtAnagrafiche.Rows[0]["Province_Ky"].ToString ();
                      } else {
                          if (dtAnagrafiche.Rows[0]["Regioni_Ky"].ToString () != "") {
                              strWHERENet = "Regioni_Ky=" + dtAnagrafiche.Rows[0]["Regioni_Ky"].ToString ();
                          } else {
                              if (dtAnagrafiche.Rows[0]["Nazioni_Ky"].ToString () != "") {
                                  strWHERENet = "Nazioni_Ky=" + dtAnagrafiche.Rows[0]["Nazioni_Ky"].ToString ();
                              } else {
                                  strWHERENet = "";
                              }
                          }
                      }
                      //Response.Write(strWHERENet + ">>");
                      strORDERNet = "Comuni_Comune";
                      strFROMNet = "Comuni_Vw";
                      dtComuni = Smartdesk.Sql.getTablePage(strFROMNet, null, "Comuni_Ky", strWHERENet, strORDERNet, 1, 400, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      if (boolAdmin == false) {
                          switch (dtLogin.Rows[0]["UtentiGruppi_AnagraficheQuali"].ToString ()) {
                              case "1":
                                  strWHEREPermessi = "";
                                  break;
                              case "2":
                                  strWHEREPermessi = "UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString ();
                                  break;
                              case "3":
                                  strWHEREPermessi = "Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString ();
                                  break;
                          }
                      }

                      if (Smartdesk.Functions.ControllaPartitaIva (dtAnagrafiche.Rows[0]["Anagrafiche_PartitaIVA"].ToString ())) {
                          strCheckPartitaIVA = "<span class=\"label success\">Corretta</span>";
                      } else {
                          strCheckPartitaIVA = "<span class=\"label alert animate__animated animate__headShake animate__infinite infinite\">Errore di validazione</span>";
                      }
                      if (dtAnagrafiche.Rows[0]["Anagrafiche_CodiceFiscale"].ToString ().Length > 0) {
                          if (Smartdesk.Functions.ControllaCodiceFiscale (dtAnagrafiche.Rows[0]["Anagrafiche_CodiceFiscale"].ToString ())) {
                              strCheckCodiceFiscale = "<span class=\"label success\">Corretto</span>";
                          } else {
                              strCheckCodiceFiscale = "<span class=\"label alert animate__animated animate__headShake animate__infinite infinite\">Errore di validazione</span>";
                          }
                      }

                      //spese
                      strWHERENet = "Anagrafiche_ClienteKy=" + strAnagrafiche_Ky;
                      strORDERNet = "Spese_Ky";
                      strFROMNet = "Spese_Vw";
                      dtSpese = Smartdesk.Sql.getTablePage(strFROMNet, null, "Spese_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      
                      //ticket
                      strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky;
                      strORDERNet = "Ticket_Ky";
                      strFROMNet = "Ticket_Vw";
                      dtTicket = Smartdesk.Sql.getTablePage(strFROMNet, null, "Ticket_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      
                      //contatti
                      dtAnagraficheIndirizzi = Smartdesk.Data.Read ("AnagraficheIndirizzi", "Anagrafiche_Ky", strAnagrafiche_Ky);
                      //contatti
                      if (dtLogin.Rows[0]["UtentiGruppi_AnagraficheContatti"].Equals(true) && dtLogin.Rows[0]["UtentiGruppi_AnagraficheContatti"].Equals (true) && strAzione != "new") {
                          dtAnagraficheContatti = Smartdesk.Data.Read ("AnagraficheContatti_Vw", "Anagrafiche_Ky", strAnagrafiche_Ky);
                      }
                      //servizi
                      if (dtLogin.Rows[0]["UtentiGruppi_Servizi"].Equals(true)) {
                          strWHERENet = "(AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) And Anagrafiche_Ky=" + strAnagrafiche_Ky;
                          strORDERNet = "AnagraficheServizi_Scadenza ASC, Servizi_Ky ASC";
                          strFROMNet = "AnagraficheServizi_Vw";
                          //dtAnagraficheServiziAttivi = new DataTable("AnagraficheServiziAttivi");
                          dtAnagraficheServiziAttivi = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                          strWHERENet = "(AnagraficheServizi_Chiuso=1) And Anagrafiche_Ky=" + strAnagrafiche_Ky;
                          strORDERNet = "AnagraficheServizi_Scadenza ASC";
                          strFROMNet = "AnagraficheServizi_Vw";
                          // dtAnagraficheServiziChiusi = new DataTable("AnagraficheServiziChiusi");
                          dtAnagraficheServiziChiusi = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      }
                      //prodotti
                      if (dtLogin.Rows[0]["UtentiGruppi_Catalogo"].Equals(true)) {
                          strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky;
                          strORDERNet = "AnagraficheProdotti_Ky ASC";
                          strFROMNet = "AnagraficheProdotti_Vw";
                          dtAnagraficheProdotti = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheProdotti_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      }
                      //attivita
                      if (dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)) {
                          strWHERENet = "Attivita_Completo<>'si' AND Anagrafiche_Ky=" + strAnagrafiche_Ky;
                          if (strWHEREPermessi.Length > 0) {
                              if (strWHERENet.Length > 0) {
                                  strWHERENet = strWHERENet + " And " + strWHEREPermessi;
                              } else {
                                  strWHERENet = strWHEREPermessi;
                              }
                          }
                          strORDERNet = "Attivita_Scadenza DESC, Attivita_Ky";
                          strFROMNet = "Attivita_Vw";
                          dtAttivitaDaFare = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                          strWHERENet = "AttivitaSettore_Ky=1 AND Attivita_Completo='si' AND Anagrafiche_Ky=" + strAnagrafiche_Ky;
                          if (strWHEREPermessi.Length > 0) {
                              if (strWHERENet.Length > 0) {
                                  strWHERENet = strWHERENet + " And " + strWHEREPermessi;
                              } else {
                                  strWHERENet = strWHEREPermessi;
                              }
                          }
                          strORDERNet = "Attivita_Scadenza DESC, Attivita_Ky";
                          strFROMNet = "Attivita_Vw";
                          dtAttivitaCompletateTecniche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                          strWHERENet = "AttivitaSettore_Ky=3 AND Attivita_Completo='si' AND Anagrafiche_Ky=" + strAnagrafiche_Ky;
                          if (strWHEREPermessi.Length > 0) {
                              if (strWHERENet.Length > 0) {
                                  strWHERENet = strWHERENet + " And " + strWHEREPermessi;
                              } else {
                                  strWHERENet = strWHEREPermessi;
                              }
                          }
                          strORDERNet = "Attivita_Scadenza DESC, Attivita_Ky";
                          strFROMNet = "Attivita_Vw";
                          dtAttivitaCompletateAmministrative = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                          strWHERENet = "AttivitaSettore_Ky=2 AND Attivita_Completo='si' AND Anagrafiche_Ky=" + strAnagrafiche_Ky;
                          if (strWHEREPermessi.Length > 0) {
                              if (strWHERENet.Length > 0) {
                                  strWHERENet = strWHERENet + " And " + strWHEREPermessi;
                              } else {
                                  strWHERENet = strWHEREPermessi;
                              }
                          }
                          strORDERNet = "Attivita_Scadenza DESC, Attivita_Ky";
                          strFROMNet = "Attivita_Vw";
                          dtAttivitaCompletateCommerciali = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                      }
                      //documenti
                      if (dtLogin.Rows[0]["UtentiGruppi_Vendite"].Equals(true) || dtLogin.Rows[0]["UtentiGruppi_Preventivi"].Equals(true)) {
                          strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky;
                          if (strWHEREPermessi.Length > 0) {
                              if (strWHERENet.Length > 0) {
                                  strWHERENet = strWHERENet + " And " + strWHEREPermessi;
                              } else {
                                  strWHERENet = strWHEREPermessi;
                              }
                          }
                          strORDERNet = "Documenti_Data DESC, Documenti_Numero DESC";
                          strFROMNet = "Documenti_Vw";
                          dtDocumenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      }
                      if (dtLogin.Rows[0]["UtentiGruppi_Produzione"].Equals (true)) {
                          //Commesse
                          strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky;
                          if (strWHEREPermessi.Length > 0) {
                              if (strWHERENet.Length > 0) {
                                  strWHERENet = strWHERENet + " And " + strWHEREPermessi;
                              } else {
                                  strWHERENet = strWHEREPermessi;
                              }
                          }
                          strORDERNet = "Commesse_Data DESC";
                          strFROMNet = "Commesse_Vw";
                          dtCommesse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      }
                      //pagamenti
                      if (dtLogin.Rows[0]["UtentiGruppi_Pagamenti"].Equals (true)) {
                          strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky + " And Pagamenti_Pagato<>'si' And PagamentiTipo_Ky=1";
                          strORDERNet = "Pagamenti_Data";
                          strFROMNet = "Pagamenti_Vw";
                          dtPagamenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                          strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky + " And Year(Pagamenti_Data)>(YEAR(GETDATE())-5) And Pagamenti_Pagato='si' And PagamentiTipo_Ky=1";
                          strORDERNet = "Pagamenti_Data DESC";
                          strFROMNet = "Pagamenti_Vw";
                          dtPagamentiRicevuti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                          strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky + " And PagamentiTipo_Ky=2";
                          strORDERNet = "Pagamenti_Data";
                          strFROMNet = "Pagamenti_Vw";
                          dtPagamentiDaFare = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      }

                      if (dtLogin.Rows[0]["UtentiGruppi_Annunci"].Equals (true)) {
                          strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky;
                          strORDERNet = "Annunci_Ky DESC";
                          strFROMNet = "Annunci_Vw";
                          dtAnnunci = Smartdesk.Sql.getTablePage(strFROMNet, null, "Annunci_Ky", strWHERENet, strORDERNet, 1, 5, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                      }

                      //SitiWeb
                      if (dtLogin.Rows[0]["UtentiGruppi_SitiWeb"].Equals(true)) {
                          strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky;
                          if (strWHEREPermessi.Length > 0) {
                              if (strWHERENet.Length > 0) {
                                  strWHERENet = strWHERENet + " And " + strWHEREPermessi;
                              } else {
                                  strWHERENet = strWHEREPermessi;
                              }
                          }
                          strORDERNet = "SitiWeb_Dominio";
                          strFROMNet = "SitiWeb_Vw";
                          dtSitiWeb = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWeb_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                          strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky;
                          if (strWHEREPermessi.Length > 0) {
                              if (strWHERENet.Length > 0) {
                                  strWHERENet = strWHERENet + " And " + strWHEREPermessi;
                              } else {
                                  strWHERENet = strWHEREPermessi;
                              }
                          }
                          strORDERNet = "Passwordmanager_Titolo";
                          strFROMNet = "Passwordmanager_Vw";
                          dtPasswordmanager = Smartdesk.Sql.getTablePage(strFROMNet, null, "Passwordmanager_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      }

                      if (dtLogin.Rows[0]["UtentiGruppi_Forms"].Equals(true)) {
                          strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky;
                          strORDERNet = "Forms_Ky DESC, FormsAvanzamento_Data DESC";
                          strFROMNet = "FormsAvanzamento_Vw";
                          dtFormsAvanzamento = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsAvanzamento_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      }

                      if (dtLogin.Rows[0]["UtentiGruppi_Note"].Equals(true)) {
                          //note
                          strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky;
                          if (strWHEREPermessi.Length > 0) {
                              if (strWHERENet.Length > 0) {
                                  strWHERENet = strWHERENet + " And " + strWHEREPermessi;
                              } else {
                                  strWHERENet = strWHEREPermessi;
                              }
                          }
                          strORDERNet = "Note_Data";
                          strFROMNet = "Note_Vw";
                          dtNote = Smartdesk.Sql.getTablePage(strFROMNet, null, "Note_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      }

                      //officina
                      strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky;
                      if (strWHEREPermessi.Length > 0) {
                          if (strWHERENet.Length > 0) {
                              strWHERENet = strWHERENet + " And " + strWHEREPermessi;
                          } else {
                              strWHERENet = strWHEREPermessi;
                          }
                      }
                      strORDERNet = "Officina_Ky DESC";
                      strFROMNet = "Officina_Vw";
                      dtOfficina = Smartdesk.Sql.getTablePage(strFROMNet, null, "Officina_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                      //attributi in base alla categoria
                      /*
                      strWHERENet = "AnagraficheCategorie_Ky=" + GetFieldValue(dtAnagrafiche, "AnagraficheCategorie_Ky");
                      strORDERNet = "AnagraficheCategorie_Ky";
                      strFROMNet = "AnagraficheCategorie";
                      dtAnagraficheCategorie = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheCategorie_Ky", strWHERENet, strORDERNet, 1, 1, Smartdesk.Config.Sql.ConnectionReadOnly);
                      if (GetFieldValue(dtAnagraficheCategorie, "AnagraficheCategorie_Attributi").Length>0){
                          strWHERENet = "(Attributi_Anagrafiche=1 AND Attributi_Ky IN (" + GetFieldValue(dtAnagraficheCategorie, "AnagraficheCategorie_Attributi") + "))";
                      }else{
                      }*/
                      strWHERENet = "Attributi_Anagrafiche=1";
                      strORDERNet = "Attributi_Ky";
                      strFROMNet = "Attributi_Vw";
                      dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                  } else {
                      strWHERENet = "Attributi_Anagrafiche=1";
                      strORDERNet = "Attributi_Ky";
                      strFROMNet = "Attributi_Vw";
                      dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 100, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      strH1 = "Nuova angrafica";
                  }
              } else {
                  Response.Redirect (Smartdesk.Current.LoginPageRoot);
              }
          } else {
              Response.Redirect (Smartdesk.Current.LoginPageRoot);
          }
      }

      public bool checkPermessi (string strUtenti_Ky, string strUtentiGruppi_Ky) {
          bool boolReturn = false;
          if (dtLogin.Rows[0]["UtentiGruppi_Anagrafiche"].Equals (true)) {
              switch (dtLogin.Rows[0]["UtentiGruppi_AnagraficheQuali"].ToString ()) {
                  case "2":
                      //se non il mio gruppo non ho il permesso
                      if (strUtentiGruppi_Ky != dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString ()) {
                          Response.Redirect ("/admin/403.aspx");
                      }
                      break;
                  case "3":
                      //se non mio non ho il permesso
                      if (strUtenti_Ky != dtLogin.Rows[0]["Utenti_Ky"].ToString ()) {
                          Response.Redirect ("/admin/403.aspx");
                      }
                      break;
              }
              boolReturn = true;
          } else {
              boolReturn = false;
              Response.Redirect ("/admin/403.aspx");
          }
          return boolReturn;
      }

      public String GetTipoRinnovo (string strRinnovoIn) {
          string strRinnovoOut = "";
          if (strRinnovoIn != null) {
              switch (strRinnovoIn) {
                  case "0":
                      strRinnovoOut = "no rinnovo";
                      break;
                  case "1":
                      strRinnovoOut = "mensile";
                      break;
                  case "2":
                      strRinnovoOut = "bimestrale";
                      break;
                  case "3":
                      strRinnovoOut = "ogni 3 mesi";
                      break;
                  case "4":
                      strRinnovoOut = "ogni 4 mesi";
                      break;
                  case "5":
                      strRinnovoOut = "ogni 5 mesi";
                      break;
                  case "6":
                      strRinnovoOut = "ogni 6 mesi";
                      break;
                  case "7":
                      strRinnovoOut = "ogni 7 mesi";
                      break;
                  case "8":
                      strRinnovoOut = "ogni 8 mesi";
                      break;
                  case "9":
                      strRinnovoOut = "ogni 9 mesi";
                      break;
                  case "10":
                      strRinnovoOut = "ogni 10 mesi";
                      break;
                  case "11":
                      strRinnovoOut = "ogni 11 mesi";
                      break;
                  case "12":
                      strRinnovoOut = "annuale";
                      break;
              }
          } else {
              strRinnovoOut = "";
          }
          return strRinnovoOut;

      }

      public String GetDefaultValue (string strField) {
          string strValore = "";
          switch (strField) {
              case "Conti_Ky":
                  dtTemp = new DataTable ("Temp");
                  dtTemp = Smartdesk.Sql.getTablePage("Conti", null, "Conti_Ky", "Conti_Default=1", "Conti_Ky", 1, 1, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtTemp.Rows.Count > 0) {
                      strValore = dtTemp.Rows[0]["Conti_Ky"].ToString ();
                  } else {
                      strValore = "";
                  }
                  break;
              case "AliquoteIVA_Ky":
                  dtTemp = new DataTable ("Temp");
                  dtTemp = Smartdesk.Sql.getTablePage("AliquoteIVA", null, "AliquoteIVA_Ky", "AliquoteIVA_Predefinita=1", "AliquoteIVA_Ky", 1, 1, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtTemp.Rows.Count > 0) {
                      strValore = dtTemp.Rows[0]["AliquoteIVA_Ky"].ToString ();
                  } else {
                      strValore = "";
                  }
                  break;
              case "PagamentiCondizioni_Ky":
                  dtTemp = new DataTable ("Temp");
                  dtTemp = Smartdesk.Sql.getTablePage("PagamentiCondizioni", null, "PagamentiCondizioni_Ky", "PagamentiCondizioni_Predefinita=1", "PagamentiCondizioni_Ky", 1, 1, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtTemp.Rows.Count > 0) {
                      strValore = dtTemp.Rows[0]["PagamentiCondizioni_Ky"].ToString ();
                  } else {
                      strValore = "";
                  }
                  break;
              case "PagamentiMetodo_Ky":
                  dtTemp = new DataTable ("Temp");
                  dtTemp = Smartdesk.Sql.getTablePage("PagamentiMetodo", null, "PagamentiMetodo_Ky", "PagamentiMetodo_Default=1", "PagamentiMetodo_Ky", 1, 1, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtTemp.Rows.Count > 0) {
                      strValore = dtTemp.Rows[0]["PagamentiMetodo_Ky"].ToString ();
                  } else {
                      strValore = "";
                  }
                  break;
              case "SpedizioniTipo_Ky":
                  strValore = "1";
                  break;
          }
          return strValore;
      }

      public String GetFieldValue (DataTable dtTabella, string strField) {
          string strValore = "";
          if (strAzione == "new") {
              strValore = GetDefaultValue (strField);
          } else {
              strValore = Smartdesk.Data.Field (dtTabella, strField);
          }
          return strValore;
      }

      public Boolean GetCheckValue (DataTable dtTabella, string strField) {
          Boolean boolValore = false;
          if (strAzione == "new") {
              boolValore = false;
          } else {
              boolValore = Smartdesk.Data.FieldBool (dtTabella, strField);
          }
          return boolValore;
      }

      public String GetLock () {
          string strValore = "";
          if (strAzione != "new") {
              if (dtAnagrafiche.Rows[0]["Anagrafiche_Lock"].Equals (true)) {
                  strValore = " disabled=\"disabled\"";
              }
          }
          return strValore;
      }

      public string render(string strRenderer, DataTable drDati, int intRow){
        string strReturn="";
        string strColumn="";
        string strField="";
        string strData="";
        strReturn=strRenderer;
        foreach(DataColumn dataColumn in drDati.Columns)
        {
          strColumn="[" + dataColumn.ColumnName  + "]";
          strField=dataColumn.ColumnName;
          strData=drDati.Rows[intRow][strField].ToString();
          strReturn=strReturn.Replace(strColumn,strData);
          //strReturn+=strColumn + "-" + strField + "-" + strData + "|";
        }
        return strReturn;
      }  

      public string getLabel(DataRow drDati){
        string strReturn="";
        if (drDati["CoreGridsColumns_Label"].ToString().Length>0){
           strReturn=drDati["CoreGridsColumns_Label"].ToString();
        }else{
          strReturn=drDati["CoreAttributes_Title"].ToString();
        }
        return strReturn;
      }  
  }
