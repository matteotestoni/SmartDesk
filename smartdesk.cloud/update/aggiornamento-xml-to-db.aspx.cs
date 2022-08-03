using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

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
    public DataTable dtCoreModulesOptions;
    public DataTable dtCoreModulesOptionsValue;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strRisultato = "";
    public string strTemp = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string strDirectory="";
        string strSQL="";
        string strWHERENet = "";
        string strORDERNet = "";
        SqlConnection conn;
        SqlCommand cmd;
        
            strH1="Aggiornamento da XML a DB";
            strRisultato += "<h2>Fase 1: Aggiornamento campi mancanti da XML a DB da cartella /admin/SqlDB/</h2>";
            strRisultato += Smartdesk.Functions.ManutenzioneAddFieldDBToXML();
            strRisultato += "<h2>Fase 2: Aggiornamento Viste da XML a DB da cartella /admin/SqlDB/</h2>";
            strRisultato += Smartdesk.Functions.ManutenzioneAddViewXMLTotDB();
            strRisultato += "<h2>Fase 3: creazione tabelle in  /uploads/</h2>";
            strDirectory=Server.MapPath("/uploads/allegati-prodotti/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-utenti/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-anagrafiche/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-annunci/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-annuncicategorie/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-aste/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-astecategorie/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-aziende/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-contenuti/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-persone/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-popup/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-prodotti/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-prodotticategorie/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-produttori/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-slide/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-providers/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/files/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-ads/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-sondaggi/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/uploads/foto-veicoliofferte/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/var/SqlTemp/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/var/cache/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/var/cache/json");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/var/log/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/var/import/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }
            strDirectory=Server.MapPath("/var/export/");
            strRisultato += strDirectory + "<br>";
            if(!Directory.Exists(strDirectory))
            {
                Directory.CreateDirectory(strDirectory);
            }

            strRisultato += "<h2>Fase 4: sistemazione dati</h2>";
            
            strSQL="UPDATE CoreEntities SET CoreEntities_CustomDelete=0 WHERE CoreEntities_CustomDelete Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE CoreEntities SET CoreEntities_CustomSave=0 WHERE CoreEntities_CustomSave Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE CoreModulesOptions SET CoreModulesOptions_Type='checkbox' WHERE CoreModulesOptions_Type='boolean'";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_Admin=1 WHERE UtentiGruppi_Ky=1";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_AmministrazioneQuali=1 WHERE UtentiGruppi_AmministrazioneQuali Is Null Or UtentiGruppi_AmministrazioneQuali=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_AnnunciQuali=1 WHERE UtentiGruppi_AnnunciQuali Is Null Or UtentiGruppi_AnnunciQuali=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_AssistenzaQuali=1 WHERE UtentiGruppi_AssistenzaQuali Is Null Or UtentiGruppi_AssistenzaQuali=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_AsteQuali=1 WHERE UtentiGruppi_AsteQuali Is Null Or UtentiGruppi_AsteQuali=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_AttivitaQuali=1 WHERE UtentiGruppi_AttivitaQuali Is Null Or UtentiGruppi_AttivitaQuali=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_AutomotiveQuali=1 WHERE UtentiGruppi_AutomotiveQuali Is Null Or UtentiGruppi_AutomotiveQuali=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_CommercialeQuali=1 WHERE UtentiGruppi_CommercialeQuali Is Null Or UtentiGruppi_CommercialeQuali=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_PersoneQuali=1 WHERE UtentiGruppi_PersoneQuali Is Null Or UtentiGruppi_PersoneQuali=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_ProgettiQuali=1 WHERE UtentiGruppi_ProgettiQuali Is Null Or UtentiGruppi_ProgettiQuali=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_Progetti=0 WHERE UtentiGruppi_Progetti Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_CoreQuali=1 WHERE UtentiGruppi_CoreQuali Is Null Or UtentiGruppi_CoreQuali=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_FormsQuali=1 WHERE UtentiGruppi_FormsQuali Is Null Or UtentiGruppi_FormsQuali=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_ImmobiliQuali=1 WHERE UtentiGruppi_ImmobiliQuali Is Null Or UtentiGruppi_ImmobiliQuali=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_LogisticaQuali=1 WHERE UtentiGruppi_LogisticaQuali Is Null Or UtentiGruppi_LogisticaQuali=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_NoteQuali=1 WHERE UtentiGruppi_NoteQuali Is Null Or UtentiGruppi_NoteQuali=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_MarketingQuali=1 WHERE UtentiGruppi_MarketingQuali Is Null Or UtentiGruppi_MarketingQuali=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_OfficinaQuali=1 WHERE UtentiGruppi_OfficinaQuali Is Null Or UtentiGruppi_OfficinaQuali=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

             /*
           strSQL="UPDATE UtentiGruppi SET UtentiGruppi_AnagraficheQuali=1 WHERE UtentiGruppi_AnagraficheQuali Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_CatalogoQuali=1 WHERE UtentiGruppi_CatalogoQuali Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_VenditeQuali=1 WHERE UtentiGruppi_VenditeQuali Is Null;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_ProduzioneQuali=1 WHERE UtentiGruppi_ProduzioneQuali Is Null;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_PersonaleQuali=1 WHERE UtentiGruppi_PersonaleQuali Is Null;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_PersonaleAssenzeQuali=1 WHERE UtentiGruppi_PersonaleAssenzeQuali Is Null;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_CommercialeQuali=1 WHERE UtentiGruppi_CommercialeQuali Is Null;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_AssistenzaQuali=1 WHERE UtentiGruppi_AssistenzaQuali Is Null;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_AutomotiveQuali=1 WHERE UtentiGruppi_AutomotiveQuali Is Null;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_AttivitaQuali=1 WHERE UtentiGruppi_AttivitaQuali Is Null;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_PasswordmanagerQuali=1 WHERE UtentiGruppi_PasswordmanagerQuali Is Null;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_Passwordmanager=0 WHERE UtentiGruppi_Passwordmanager Is Null;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_PreventiviAuto=0 WHERE UtentiGruppi_PreventiviAuto Is Null;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_Recensioni=0 WHERE UtentiGruppi_Recensioni Is Null;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_Eventi=0 WHERE UtentiGruppi_Eventi Is Null;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_Knowledgebase=0 WHERE UtentiGruppi_Knowledgebase Is Null;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            */

            /*
            strSQL="DELETE FROM SitiWebLog WHERE SitiWebLog_Descrizione='Google Page Rank';";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="DELETE FROM SitiWebLog WHERE SitiWeb_Ky Is Null;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="DELETE FROM SitiWebPageSpeedLog WHERE SitiWeb_Ky Is Null;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            */

            strSQL="DELETE FROM CoreAttributes WHERE CoreEntities_Ky=42 Or CoreEntities_Ky=43;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="DELETE FROM CoreGrids WHERE CoreEntities_Ky=42 Or CoreEntities_Ky=43;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="DELETE FROM CoreGridsColumns WHERE CoreGrids_Ky=88 Or CoreGrids_Ky=89;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            strSQL="DELETE FROM CoreForms WHERE CoreEntities_Ky=42 Or CoreEntities_Ky=43 Or CoreForms_Ky=45;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="DELETE FROM CoreFormsFields WHERE CoreForms_Ky=45;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            
            strSQL="DROP TABLE IF EXISTS Contratti;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="DROP TABLE IF EXISTS ContrattiStato;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="DROP VIEW IF EXISTS Contratti_Totali_Vw;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="DROP VIEW IF EXISTS Contratti_Vw;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            
            strSQL="UPDATE PagamentiMetodo SET PagamentiMetodo_Titolo=PagamentiMetodo_Descrizione WHERE PagamentiMetodo_Titolo Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE CommesseStato SET CommesseStato_Titolo=CommesseStato_Descrizione WHERE CommesseStato_Titolo Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);           
            strSQL= "UPDATE CoreGrids SET CoreGrids_Rows=30 WHERE CoreGrids_Rows Is Null OR CoreGrids_Rows=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL = "UPDATE Utenti SET Lingue_Ky=1 WHERE Lingue_Ky Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE VeicoliMarca SET VeicoliMarca_MesiGaranzia=24 WHERE VeicoliMarca_MesiGaranzia Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE VeicoliMarca SET VeicoliMarca_Robots='index,follow' WHERE VeicoliMarca_Robots Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE VeicoliMarca SET VeicoliMarca_Description=VeicoliMarca_Title WHERE VeicoliMarca_Description Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE VeicoliCategoria SET VeicoliCategoria_Titolo=VeicoliCategoria_Descrizione WHERE VeicoliCategoria_Titolo Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE OpportunitaSorgenti set OpportunitaSorgenti_Attiva=1 where OpportunitaSorgenti_Attiva Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Utenti set Utenti_Colore='#000000' where Utenti_Colore Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE ProdottiCategorie SET ProdottiCategorie_Title=ProdottiCategorie_Titolo WHERE ProdottiCategorie_Title Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE ProdottiCategorie SET ProdottiCategorie_Title=ProdottiCategorie_Titolo WHERE ProdottiCategorie_Title Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE ProdottiCategorie SET ProdottiCategorie_Description=ProdottiCategorie_Descrizione WHERE ProdottiCategorie_Description Is Null AND ProdottiCategorie_Descrizione Is Not Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE ProdottiCategorie SET ProdottiCategorie_Description=ProdottiCategorie_Titolo WHERE ProdottiCategorie_Description Is Null AND ProdottiCategorie_Descrizione Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE ProdottiCategorie SET ProdottiCategorie_Padre=0 WHERE ProdottiCategorie_Padre Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE ProdottiCategorie SET ProdottiCategorie_Ordine=ProdottiCategorie_Ky WHERE ProdottiCategorie_Ordine Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Anagrafiche SET PagamentiMetodo_Ky=1 WHERE PagamentiMetodo_Ky Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Anagrafiche SET Nazioni_Ky=105 WHERE Nazioni_Ky Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE AnagraficheTipologia SET AnagraficheTipologia_Ordine=AnagraficheTipologia_Ky WHERE AnagraficheTipologia_Ordine Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE AnnunciCategorie SET AnnunciCategorie_Padre=0 WHERE AnnunciCategorie_Padre Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE OpportunitaStati SET OpportunitaStati_Ordine=OpportunitaStati_Ky WHERE OpportunitaStati_Ordine Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Prodotti SET Prodotti_Video1=Null WHERE Len(LTRIM(RTRIM(Prodotti_Video1)))<1";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Prodotti SET Prodotti_Video2=Null WHERE Len(LTRIM(RTRIM(Prodotti_Video2)))<1";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Prodotti SET Prodotti_Video3=Null WHERE Len(LTRIM(RTRIM(Prodotti_Video3)))<1";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Prodotti SET Prodotti_Video4=Null WHERE Len(LTRIM(RTRIM(Prodotti_Video4)))<1";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Prodotti SET Prodotti_Video5=Null WHERE Len(LTRIM(RTRIM(Prodotti_Video5)))<1";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Prodotti SET Prodotti_Gruppo=Null WHERE Len(LTRIM(RTRIM(Prodotti_Gruppo)))<1";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Prodotti SET Prodotti_Packaging=Null WHERE Len(LTRIM(RTRIM(Prodotti_Packaging)))<1";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE ProdottiCategorie SET ProdottiCategorie_InSitemap=1 WHERE ProdottiCategorie_InSitemap Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Anagrafiche SET Conti_Ky=1 WHERE Conti_Ky Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Pagamenti SET Conti_Ky=1 WHERE Conti_Ky Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Persone SET Conti_Ky=1 WHERE Conti_Ky Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Spese SET Conti_Ky=1 WHERE Conti_Ky Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Persone SET TimeZones_Ky=464 WHERE TimeZones_Ky Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Utenti SET TimeZones_Ky=464 WHERE TimeZones_Ky Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Anagrafiche set PagamentiCondizioni_Ky=2 WHERE PagamentiCondizioni_Ky Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Anagrafiche set SpedizioniTipo_Ky=1 WHERE SpedizioniTipo_Ky Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Anagrafiche SET CentridiCR_Ky=Spese.CentridiCR_Ky FROM Anagrafiche INNER JOIN Spese ON Spese.Anagrafiche_Ky = Anagrafiche.Anagrafiche_Ky WHERE Anagrafiche.CentridiCR_Ky Is Null";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            
            strSQL="UPDATE Nazioni set Nazioni_UE=0";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Nazioni set Nazioni_UE=1 WHERE Nazioni_Codice IN ('AT','BE','BG','CY','HR','DK','EE','FI','FR','DE','GB','EL','IE','IT','LV','LT','LU','MT','NL','PL','PT','CZ','SK','RO','SI','ES','SE','HU')";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE CMSContenuti SET CMSContenuti_Robots='index,follow' WHERE CMSContenuti_Robots Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE ServiziCategorie SET ServiziCategorie_Titolo=ServiziCategorie_Descrizione WHERE ServiziCategorie_Titolo Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            strSQL="UPDATE Aste SET Aste_Robots='index,follow' WHERE Aste_Robots Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Annunci SET Annunci_Robots='index,follow' WHERE Annunci_Robots Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Prodotti SET Prodotti_Robots='index,follow' WHERE Prodotti_Robots Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE ProdottiCategorie SET ProdottiCategorie_Robots='index,follow' WHERE ProdottiCategorie_Robots Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
		      	strSQL="UPDATE Servizi SET Servizi_Robots='index,follow' WHERE Servizi_Robots Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE ServiziCategorie SET ServiziCategorie_Robots='index,follow' WHERE ServiziCategorie_Robots Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Annunci SET Annunci_Cerco=0 WHERE Annunci_Cerco Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Annunci SET Annunci_Offro=1 WHERE Annunci_Offro Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Aste SET AsteNatura_Ky=1 WHERE AsteNatura_Ky Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Aste SET Aste_CommissioniTipo=1 WHERE Aste_CommissioniTipo Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Ore SET Ore_Disabilita=0 WHERE Ore_Disabilita Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE AttivitaTipo SET AttivitaTipo_Attiva=1 WHERE AttivitaTipo_Attiva Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE AttivitaSettore SET AttivitaSettore_Attiva=1 WHERE AttivitaSettore_Attiva Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE Utenti SET Utenti_Wysiwyg=1 WHERE Utenti_Wysiwyg Is Null";            
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE VeicoliMarca set VeicoliMarca_Titolo=VeicoliMarca_Descrizione WHERE VeicoliMarca_Titolo Is Null";  
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE VeicoliMarca set VeicoliMarca_Title=VeicoliMarca_Titolo WHERE VeicoliMarca_Title Is Null";  
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE VeicoliModello set VeicoliModello_Titolo=VeicoliModello_Descrizione WHERE VeicoliModello_Titolo Is Null";  
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE VeicoliModello set VeicoliModello_Title=VeicoliModello_Titolo WHERE VeicoliModello_Title Is Null";  
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE VeicoliModello set VeicoliModello_UrlKey=VeicoliModello_DescrizioneHTML WHERE VeicoliModello_UrlKey Is Null";  
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="UPDATE VeicoliModello set VeicoliModello_Dismesso=0 WHERE VeicoliModello_Dismesso Is Null";  
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            
            strSQL="UPDATE VeicoliCarrozzeria set VeicoliTipo_Ky=1 WHERE VeicoliTipo_Ky Is Null";  
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            strSQL="UPDATE Opportunita SET OpportunitaStati_Ky=3 WHERE OpportunitaStati_Ky Is Null;";  
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            strRisultato += "<h2>Fase 5: Dati di default</h2>";
            strRisultato += "1 - Catalogo: tipo recensioni<br>";
            strWHERENet="";
            strORDERNet = "RecensioniTipo_Ky";
            strFROMNet = "RecensioniTipo";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "RecensioniTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){
              strSQL="SET IDENTITY_INSERT RecensioniTipo ON;";
                strSQL+="INSERT RecensioniTipo (RecensioniTipo_Ky, RecensioniTipo_Titolo, RecensioniTipo_UserInsert, RecensioniTipo_UserUpdate, RecensioniTipo_UserDelete, RecensioniTipo_DateInsert, RecensioniTipo_DateUpdate, RecensioniTipo_DateDelete) VALUES (1, N'Amministratore', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT RecensioniTipo (RecensioniTipo_Ky, RecensioniTipo_Titolo, RecensioniTipo_UserInsert, RecensioniTipo_UserUpdate, RecensioniTipo_UserDelete, RecensioniTipo_DateInsert, RecensioniTipo_DateUpdate, RecensioniTipo_DateDelete) VALUES (2, N'Ospite', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT RecensioniTipo (RecensioniTipo_Ky, RecensioniTipo_Titolo, RecensioniTipo_UserInsert, RecensioniTipo_UserUpdate, RecensioniTipo_UserDelete, RecensioniTipo_DateInsert, RecensioniTipo_DateUpdate, RecensioniTipo_DateDelete) VALUES (3, N'Utente', 0, NULL, NULL, GETDATE(), NULL, NULL);";
              strSQL+="SET IDENTITY_INSERT RecensioniTipo OFF;";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
            
            strRisultato += "2 - Catalogo: visibilit&agrave; prodotti<br>";
            strWHERENet="";
            strORDERNet = "ProdottiVisibilita_Ky";
            strFROMNet = "ProdottiVisibilita";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "ProdottiVisibilita_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){
              strSQL="SET IDENTITY_INSERT ProdottiVisibilita ON;";
              strSQL+="INSERT ProdottiVisibilita (ProdottiVisibilita_Ky, ProdottiVisibilita_Titolo, ProdottiVisibilita_Default, ProdottiVisibilita_Codice, ProdottiVisibilita_Ordine, ProdottiVisibilita_UserInsert, ProdottiVisibilita_UserUpdate, ProdottiVisibilita_UserDelete, ProdottiVisibilita_DateInsert, ProdottiVisibilita_DateUpdate, ProdottiVisibilita_DateDelete) VALUES (1, N'Ovunque', 1, N'4', NULL, 0, NULL, NULL, GETDATE(), NULL, NULL)";
              strSQL+="INSERT ProdottiVisibilita (ProdottiVisibilita_Ky, ProdottiVisibilita_Titolo, ProdottiVisibilita_Default, ProdottiVisibilita_Codice, ProdottiVisibilita_Ordine, ProdottiVisibilita_UserInsert, ProdottiVisibilita_UserUpdate, ProdottiVisibilita_UserDelete, ProdottiVisibilita_DateInsert, ProdottiVisibilita_DateUpdate, ProdottiVisibilita_DateDelete) VALUES (2, N'Catalogo', 0, N'2', NULL, 0, NULL, NULL, GETDATE(), NULL, NULL)";
              strSQL+="INSERT ProdottiVisibilita (ProdottiVisibilita_Ky, ProdottiVisibilita_Titolo, ProdottiVisibilita_Default, ProdottiVisibilita_Codice, ProdottiVisibilita_Ordine, ProdottiVisibilita_UserInsert, ProdottiVisibilita_UserUpdate, ProdottiVisibilita_UserDelete, ProdottiVisibilita_DateInsert, ProdottiVisibilita_DateUpdate, ProdottiVisibilita_DateDelete) VALUES (3, N'Ricerca', 0, N'3', NULL, 0, NULL, NULL, GETDATE(), NULL, NULL)";
              strSQL+="INSERT ProdottiVisibilita (ProdottiVisibilita_Ky, ProdottiVisibilita_Titolo, ProdottiVisibilita_Default, ProdottiVisibilita_Codice, ProdottiVisibilita_Ordine, ProdottiVisibilita_UserInsert, ProdottiVisibilita_UserUpdate, ProdottiVisibilita_UserDelete, ProdottiVisibilita_DateInsert, ProdottiVisibilita_DateUpdate, ProdottiVisibilita_DateDelete) VALUES (4, N'Non visibile', 0, N'1', NULL, 0, NULL, GETDATE(), NULL, NULL, NULL)";
              strSQL+="SET IDENTITY_INSERT ProdottiVisibilita OFF;";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "3 - Aste: tipo<br>";
            strWHERENet="";
            strORDERNet = "AsteTipo_Ky";
            strFROMNet = "AsteTipo";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AsteTipo_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){
              strSQL="SET IDENTITY_INSERT AsteTipo ON;";
                strSQL+="INSERT AsteTipo (AsteTipo_Ky, AsteTipo_Titolo, AsteTipo_Default) VALUES (1, N'Privata', 0);";
                strSQL+="INSERT AsteTipo (AsteTipo_Ky, AsteTipo_Titolo, AsteTipo_Default) VALUES (2, N'Concorsuale', 1);";
              strSQL+="SET IDENTITY_INSERT AsteTipo OFF;";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }		            

            strRisultato += "4 - Aste: natura<br>";
            strWHERENet="";
            strORDERNet = "AsteNatura_Ky";
            strFROMNet = "AsteNatura";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AsteNatura_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){
              strSQL="SET IDENTITY_INSERT AsteNatura ON;";
                strSQL+="INSERT AsteNatura (AsteNatura_Ky, AsteNatura_Titolo, AsteNatura_Icona, AsteNatura_Default) VALUES (1, N'Mobiliare', N'fa-duotone fa-plane', 1);";
                strSQL+="INSERT AsteNatura (AsteNatura_Ky, AsteNatura_Titolo, AsteNatura_Icona, AsteNatura_Default) VALUES (2, N'Immobiliare', N'fa-duotone fa-building', 0);";
              strSQL+="SET IDENTITY_INSERT AsteNatura OFF;";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }		            

            strRisultato += "5 - Aste: vendita<br>";
            strWHERENet="";
            strORDERNet = "AsteVendita_Ky";
            strFROMNet = "AsteVendita";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AsteVendita_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){
              strSQL="SET IDENTITY_INSERT AsteVendita ON;";
                strSQL+="INSERT AsteVendita (AsteVendita_Ky, AsteVendita_Titolo, AsteVendita_Icona, AsteVendita_Default) VALUES (1, N'Vendita sincrona telematica', N'fa-duotone fa-sync', 1);";
                strSQL+="INSERT AsteVendita (AsteVendita_Ky, AsteVendita_Titolo, AsteVendita_Icona, AsteVendita_Default) VALUES (2, N'Vendita asincrona', N'fa-duotone fa-clock', 0);";
                strSQL+="INSERT AsteVendita (AsteVendita_Ky, AsteVendita_Titolo, AsteVendita_Icona, AsteVendita_Default) VALUES (3, N'Vendita sincrona mista', N'fa-duotone fa-mix', 0);";
              strSQL+="SET IDENTITY_INSERT AsteVendita OFF;";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }	

            strRisultato += "6 - Social: tipo canali<br>";
            strWHERENet="";
            strORDERNet = "Socialchannelstype_Ky";
            strFROMNet = "Socialchannelstype";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Socialchannelstype_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){
              strSQL="SET IDENTITY_INSERT Socialchannelstype ON;";
                strSQL+="INSERT Socialchannelstype (Socialchannelstype_Ky,Socialchannelstype_Titolo,Socialchannelstype_Icona,Socialchannelstype_Attivo,Socialchannelstype_UserInsert,Socialchannelstype_UserUpdate,Socialchannelstype_UserDelete,Socialchannelstype_DateInsert,Socialchannelstype_DateUpdate,Socialchannelstype_DateDelete) VALUES (1, N'Facebook', N'fab fa-facebook', 1, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT Socialchannelstype (Socialchannelstype_Ky,Socialchannelstype_Titolo,Socialchannelstype_Icona,Socialchannelstype_Attivo,Socialchannelstype_UserInsert,Socialchannelstype_UserUpdate,Socialchannelstype_UserDelete,Socialchannelstype_DateInsert,Socialchannelstype_DateUpdate,Socialchannelstype_DateDelete) VALUES (2, N'Instagram', N'fab fa-instagram', 1, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT Socialchannelstype (Socialchannelstype_Ky,Socialchannelstype_Titolo,Socialchannelstype_Icona,Socialchannelstype_Attivo,Socialchannelstype_UserInsert,Socialchannelstype_UserUpdate,Socialchannelstype_UserDelete,Socialchannelstype_DateInsert,Socialchannelstype_DateUpdate,Socialchannelstype_DateDelete) VALUES (3, N'Twitter', N'fab fa-twitter', 1, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT Socialchannelstype (Socialchannelstype_Ky,Socialchannelstype_Titolo,Socialchannelstype_Icona,Socialchannelstype_Attivo,Socialchannelstype_UserInsert,Socialchannelstype_UserUpdate,Socialchannelstype_UserDelete,Socialchannelstype_DateInsert,Socialchannelstype_DateUpdate,Socialchannelstype_DateDelete) VALUES (4, N'Linkedin', N'fab fa-linkedin', 1, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT Socialchannelstype (Socialchannelstype_Ky,Socialchannelstype_Titolo,Socialchannelstype_Icona,Socialchannelstype_Attivo,Socialchannelstype_UserInsert,Socialchannelstype_UserUpdate,Socialchannelstype_UserDelete,Socialchannelstype_DateInsert,Socialchannelstype_DateUpdate,Socialchannelstype_DateDelete) VALUES (5, N'Pinterest', N'fab fa-pinterest', 1, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT Socialchannelstype (Socialchannelstype_Ky,Socialchannelstype_Titolo,Socialchannelstype_Icona,Socialchannelstype_Attivo,Socialchannelstype_UserInsert,Socialchannelstype_UserUpdate,Socialchannelstype_UserDelete,Socialchannelstype_DateInsert,Socialchannelstype_DateUpdate,Socialchannelstype_DateDelete) VALUES (6, N'Telegram', N'fab fa-telegram', 1, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT Socialchannelstype (Socialchannelstype_Ky,Socialchannelstype_Titolo,Socialchannelstype_Icona,Socialchannelstype_Attivo,Socialchannelstype_UserInsert,Socialchannelstype_UserUpdate,Socialchannelstype_UserDelete,Socialchannelstype_DateInsert,Socialchannelstype_DateUpdate,Socialchannelstype_DateDelete) VALUES (7, N'Youtube', N'fab fa-youtube', 1, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT Socialchannelstype (Socialchannelstype_Ky,Socialchannelstype_Titolo,Socialchannelstype_Icona,Socialchannelstype_Attivo,Socialchannelstype_UserInsert,Socialchannelstype_UserUpdate,Socialchannelstype_UserDelete,Socialchannelstype_DateInsert,Socialchannelstype_DateUpdate,Socialchannelstype_DateDelete) VALUES (8, N'My Business', N'fa-duotone fa-location-dot-alt', 1, 0, NULL, NULL, GETDATE(), NULL, NULL);";
              strSQL+="SET IDENTITY_INSERT Socialchannelstype OFF;";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "7 - Lead: formula di acquisto<br>";
            strWHERENet="";
            strORDERNet = "LeadFormulaAcquisto_Ky";
            strFROMNet = "LeadFormulaAcquisto";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadFormulaAcquisto_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){
                strSQL="SET IDENTITY_INSERT LeadFormulaAcquisto ON;"; 
                strSQL+="INSERT LeadFormulaAcquisto (LeadFormulaAcquisto_Ky,LeadFormulaAcquisto_Titolo,LeadFormulaAcquisto_Default,LeadFormulaAcquisto_Codice,LeadFormulaAcquisto_Ordine,LeadFormulaAcquisto_UserInsert,LeadFormulaAcquisto_UserUpdate,LeadFormulaAcquisto_UserDelete,LeadFormulaAcquisto_DateInsert,LeadFormulaAcquisto_DateUpdate,LeadFormulaAcquisto_DateDelete) VALUES (1, N'Finanziamento', 1, N'finanziamento', 1, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT LeadFormulaAcquisto (LeadFormulaAcquisto_Ky,LeadFormulaAcquisto_Titolo,LeadFormulaAcquisto_Default,LeadFormulaAcquisto_Codice,LeadFormulaAcquisto_Ordine,LeadFormulaAcquisto_UserInsert,LeadFormulaAcquisto_UserUpdate,LeadFormulaAcquisto_UserDelete,LeadFormulaAcquisto_DateInsert,LeadFormulaAcquisto_DateUpdate,LeadFormulaAcquisto_DateDelete) VALUES (2, N'Noleggio a Lun Termine', 0, N'noleggio_lun_termine', 2, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT LeadFormulaAcquisto (LeadFormulaAcquisto_Ky,LeadFormulaAcquisto_Titolo,LeadFormulaAcquisto_Default,LeadFormulaAcquisto_Codice,LeadFormulaAcquisto_Ordine,LeadFormulaAcquisto_UserInsert,LeadFormulaAcquisto_UserUpdate,LeadFormulaAcquisto_UserDelete,LeadFormulaAcquisto_DateInsert,LeadFormulaAcquisto_DateUpdate,LeadFormulaAcquisto_DateDelete) VALUES (3, N'Leasing', 0, N'leasing', 3, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT LeadFormulaAcquisto (LeadFormulaAcquisto_Ky,LeadFormulaAcquisto_Titolo,LeadFormulaAcquisto_Default,LeadFormulaAcquisto_Codice,LeadFormulaAcquisto_Ordine,LeadFormulaAcquisto_UserInsert,LeadFormulaAcquisto_UserUpdate,LeadFormulaAcquisto_UserDelete,LeadFormulaAcquisto_DateInsert,LeadFormulaAcquisto_DateUpdate,LeadFormulaAcquisto_DateDelete) VALUES (4, N'Contanti', 0, N'contanti', 4, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT LeadFormulaAcquisto (LeadFormulaAcquisto_Ky,LeadFormulaAcquisto_Titolo,LeadFormulaAcquisto_Default,LeadFormulaAcquisto_Codice,LeadFormulaAcquisto_Ordine,LeadFormulaAcquisto_UserInsert,LeadFormulaAcquisto_UserUpdate,LeadFormulaAcquisto_UserDelete,LeadFormulaAcquisto_DateInsert,LeadFormulaAcquisto_DateUpdate,LeadFormulaAcquisto_DateDelete) VALUES (5, N'Altro', 0, N'altro', 5, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="SET IDENTITY_INSERT LeadFormulaAcquisto OFF;";
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "8 - Lead: sorgenti<br>";
            strWHERENet="";
            strORDERNet = "LeadSorgenti_Ky";
            strFROMNet = "LeadSorgenti";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadSorgenti_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT LeadSorgenti ON;"; 
                strSQL+="INSERT LeadSorgenti (LeadSorgenti_Ky,LeadSorgenti_Titolo,LeadSorgenti_Default,LeadSorgenti_Codice,LeadSorgenti_Ordine,LeadSorgenti_UserInsert,LeadSorgenti_UserUpdate,LeadSorgenti_UserDelete,LeadSorgenti_DateInsert,LeadSorgenti_DateUpdate,LeadSorgenti_DateDelete,LeadSorgenti_Icona) VALUES (1, N'Lead incentivanti', 0, N'L', 1, NULL, 2, NULL, GETDATE(), NULL, NULL, NULL);";
                strSQL+="INSERT LeadSorgenti (LeadSorgenti_Ky,LeadSorgenti_Titolo,LeadSorgenti_Default,LeadSorgenti_Codice,LeadSorgenti_Ordine,LeadSorgenti_UserInsert,LeadSorgenti_UserUpdate,LeadSorgenti_UserDelete,LeadSorgenti_DateInsert,LeadSorgenti_DateUpdate,LeadSorgenti_DateDelete,LeadSorgenti_Icona) VALUES (2, N'Richieste clienti', 0, N'R', 2, NULL, NULL, NULL, GETDATE(), NULL, NULL, NULL);";
                strSQL+="INSERT LeadSorgenti (LeadSorgenti_Ky,LeadSorgenti_Titolo,LeadSorgenti_Default,LeadSorgenti_Codice,LeadSorgenti_Ordine,LeadSorgenti_UserInsert,LeadSorgenti_UserUpdate,LeadSorgenti_UserDelete,LeadSorgenti_DateInsert,LeadSorgenti_DateUpdate,LeadSorgenti_DateDelete,LeadSorgenti_Icona) VALUES (3, N'Contatto da iniziative', 0, N'I', 3, NULL, NULL, NULL, GETDATE(), NULL, NULL, NULL);";
                strSQL+="INSERT LeadSorgenti (LeadSorgenti_Ky,LeadSorgenti_Titolo,LeadSorgenti_Default,LeadSorgenti_Codice,LeadSorgenti_Ordine,LeadSorgenti_UserInsert,LeadSorgenti_UserUpdate,LeadSorgenti_UserDelete,LeadSorgenti_DateInsert,LeadSorgenti_DateUpdate,LeadSorgenti_DateDelete,LeadSorgenti_Icona) VALUES (4, N'Autogenerati da trattativa', 0, N'T', 4, NULL, NULL, NULL, GETDATE(), NULL, NULL, NULL);";
                strSQL+="INSERT LeadSorgenti (LeadSorgenti_Ky,LeadSorgenti_Titolo,LeadSorgenti_Default,LeadSorgenti_Codice,LeadSorgenti_Ordine,LeadSorgenti_UserInsert,LeadSorgenti_UserUpdate,LeadSorgenti_UserDelete,LeadSorgenti_DateInsert,LeadSorgenti_DateUpdate,LeadSorgenti_DateDelete,LeadSorgenti_Icona) VALUES (5, N'Contatto da web', 1, N'W', 5, NULL, NULL, NULL, GETDATE(), NULL, NULL, NULL);";
                strSQL+="INSERT LeadSorgenti (LeadSorgenti_Ky,LeadSorgenti_Titolo,LeadSorgenti_Default,LeadSorgenti_Codice,LeadSorgenti_Ordine,LeadSorgenti_UserInsert,LeadSorgenti_UserUpdate,LeadSorgenti_UserDelete,LeadSorgenti_DateInsert,LeadSorgenti_DateUpdate,LeadSorgenti_DateDelete,LeadSorgenti_Icona) VALUES (6, N'Altre fonti', 0, N'E', 6, NULL, NULL, NULL, GETDATE(), NULL, NULL, NULL);";
                strSQL+="INSERT LeadSorgenti (LeadSorgenti_Ky,LeadSorgenti_Titolo,LeadSorgenti_Default,LeadSorgenti_Codice,LeadSorgenti_Ordine,LeadSorgenti_UserInsert,LeadSorgenti_UserUpdate,LeadSorgenti_UserDelete,LeadSorgenti_DateInsert,LeadSorgenti_DateUpdate,LeadSorgenti_DateDelete,LeadSorgenti_Icona) VALUES (7, N'Visita', 0, N'V', 7, NULL, NULL, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT LeadSorgenti (LeadSorgenti_Ky,LeadSorgenti_Titolo,LeadSorgenti_Default,LeadSorgenti_Codice,LeadSorgenti_Ordine,LeadSorgenti_UserInsert,LeadSorgenti_UserUpdate,LeadSorgenti_UserDelete,LeadSorgenti_DateInsert,LeadSorgenti_DateUpdate,LeadSorgenti_DateDelete,LeadSorgenti_Icona) VALUES (8, N'Finanziamento mancante', 0, N'F', 8, NULL, NULL, NULL, GETDATE(), NULL, NULL, NULL);";
                strSQL+="INSERT LeadSorgenti (LeadSorgenti_Ky,LeadSorgenti_Titolo,LeadSorgenti_Default,LeadSorgenti_Codice,LeadSorgenti_Ordine,LeadSorgenti_UserInsert,LeadSorgenti_UserUpdate,LeadSorgenti_UserDelete,LeadSorgenti_DateInsert,LeadSorgenti_DateUpdate,LeadSorgenti_DateDelete,LeadSorgenti_Icona) VALUES (9, N'Finanziamento in scadenza', 0, N'F-SCAD', 9, NULL, NULL, NULL, GETDATE(), NULL, NULL, NULL);";
                strSQL+="INSERT LeadSorgenti (LeadSorgenti_Ky,LeadSorgenti_Titolo,LeadSorgenti_Default,LeadSorgenti_Codice,LeadSorgenti_Ordine,LeadSorgenti_UserInsert,LeadSorgenti_UserUpdate,LeadSorgenti_UserDelete,LeadSorgenti_DateInsert,LeadSorgenti_DateUpdate,LeadSorgenti_DateDelete,LeadSorgenti_Icona) VALUES (10, N'Campagna marketing', 0, N'CM', 10, NULL, NULL, NULL, GETDATE(), NULL, NULL, NULL);";
                strSQL+="INSERT LeadSorgenti (LeadSorgenti_Ky,LeadSorgenti_Titolo,LeadSorgenti_Default,LeadSorgenti_Codice,LeadSorgenti_Ordine,LeadSorgenti_UserInsert,LeadSorgenti_UserUpdate,LeadSorgenti_UserDelete,LeadSorgenti_DateInsert,LeadSorgenti_DateUpdate,LeadSorgenti_DateDelete,LeadSorgenti_Icona) VALUES (11, N'Post Vendita', 0, N'S', 11, NULL, NULL, NULL, GETDATE(), NULL, NULL, NULL);";
                strSQL+="INSERT LeadSorgenti (LeadSorgenti_Ky,LeadSorgenti_Titolo,LeadSorgenti_Default,LeadSorgenti_Codice,LeadSorgenti_Ordine,LeadSorgenti_UserInsert,LeadSorgenti_UserUpdate,LeadSorgenti_UserDelete,LeadSorgenti_DateInsert,LeadSorgenti_DateUpdate,LeadSorgenti_DateDelete,LeadSorgenti_Icona) VALUES (12, N'Assicurazione mancante', 0, N'A', 12, NULL, NULL, NULL, GETDATE(), NULL, NULL, NULL);";
                strSQL+="INSERT LeadSorgenti (LeadSorgenti_Ky,LeadSorgenti_Titolo,LeadSorgenti_Default,LeadSorgenti_Codice,LeadSorgenti_Ordine,LeadSorgenti_UserInsert,LeadSorgenti_UserUpdate,LeadSorgenti_UserDelete,LeadSorgenti_DateInsert,LeadSorgenti_DateUpdate,LeadSorgenti_DateDelete,LeadSorgenti_Icona) VALUES (13, N'Garanzia mancante', 0, N'G', 13, NULL, NULL, NULL, GETDATE(), NULL, NULL, NULL);";
                strSQL+="INSERT LeadSorgenti (LeadSorgenti_Ky,LeadSorgenti_Titolo,LeadSorgenti_Default,LeadSorgenti_Codice,LeadSorgenti_Ordine,LeadSorgenti_UserInsert,LeadSorgenti_UserUpdate,LeadSorgenti_UserDelete,LeadSorgenti_DateInsert,LeadSorgenti_DateUpdate,LeadSorgenti_DateDelete,LeadSorgenti_Icona) VALUES (14, N'Manutenzione mancante', 0, N'M', 14, NULL, NULL, NULL, GETDATE(), NULL, NULL, NULL);";
                strSQL+="SET IDENTITY_INSERT LeadSorgenti OFF;";
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "9 - Lead: stati<br>";
            strWHERENet="";
            strORDERNet = "LeadStato_Ky";
            strFROMNet = "LeadStato";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadStato_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT LeadStato ON;"; 
                strSQL+="INSERT LeadStato (LeadStato_Ky,LeadStato_Titolo,LeadStato_Default,LeadStato_Codice,LeadStato_Colore,LeadStato_Icona,LeadStato_Ordine,LeadStato_UserInsert,LeadStato_UserUpdate,LeadStato_UserDelete,LeadStato_DateInsert,LeadStato_DateUpdate,LeadStato_DateDelete,LeadStato_Aperta,LeadStato_Chiusa,LeadStato_Probabilita) VALUES (1, N'In corso', 1, N'in_corso', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, NULL);";
                strSQL+="INSERT LeadStato (LeadStato_Ky,LeadStato_Titolo,LeadStato_Default,LeadStato_Codice,LeadStato_Colore,LeadStato_Icona,LeadStato_Ordine,LeadStato_UserInsert,LeadStato_UserUpdate,LeadStato_UserDelete,LeadStato_DateInsert,LeadStato_DateUpdate,LeadStato_DateDelete,LeadStato_Aperta,LeadStato_Chiusa,LeadStato_Probabilita) VALUES (2, N'Fallito', 0, N'fallito', NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL);";
                strSQL+="SET IDENTITY_INSERT LeadStato OFF;";
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "10 - Lead: tipo<br>";
            strWHERENet="";
            strORDERNet = "LeadTipo_Ky";
            strFROMNet = "LeadTipo";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadTipo_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT LeadTipo ON;"; 
                strSQL+="INSERT LeadTipo (LeadTipo_Ky,LeadTipo_Titolo,LeadTipo_Default,LeadTipo_Codice,LeadTipo_Ordine,LeadTipo_UserInsert,LeadTipo_UserUpdate,LeadTipo_UserDelete,LeadTipo_DateInsert,LeadTipo_DateUpdate,LeadTipo_DateDelete) VALUES (1, N'Servizi', 0, N'servizi', 1, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT LeadTipo (LeadTipo_Ky,LeadTipo_Titolo,LeadTipo_Default,LeadTipo_Codice,LeadTipo_Ordine,LeadTipo_UserInsert,LeadTipo_UserUpdate,LeadTipo_UserDelete,LeadTipo_DateInsert,LeadTipo_DateUpdate,LeadTipo_DateDelete) VALUES (2, N'Post vendita', 0, N'service', 2, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT LeadTipo (LeadTipo_Ky,LeadTipo_Titolo,LeadTipo_Default,LeadTipo_Codice,LeadTipo_Ordine,LeadTipo_UserInsert,LeadTipo_UserUpdate,LeadTipo_UserDelete,LeadTipo_DateInsert,LeadTipo_DateUpdate,LeadTipo_DateDelete) VALUES (3, N'Test drive', 0, N'test drive', 3, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT LeadTipo (LeadTipo_Ky,LeadTipo_Titolo,LeadTipo_Default,LeadTipo_Codice,LeadTipo_Ordine,LeadTipo_UserInsert,LeadTipo_UserUpdate,LeadTipo_UserDelete,LeadTipo_DateInsert,LeadTipo_DateUpdate,LeadTipo_DateDelete) VALUES (4, N'Ricambi', 0, N'ricambi', 4, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT LeadTipo (LeadTipo_Ky,LeadTipo_Titolo,LeadTipo_Default,LeadTipo_Codice,LeadTipo_Ordine,LeadTipo_UserInsert,LeadTipo_UserUpdate,LeadTipo_UserDelete,LeadTipo_DateInsert,LeadTipo_DateUpdate,LeadTipo_DateDelete) VALUES (5, N'Preventivo', 1, N'preventivo', 5, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT LeadTipo (LeadTipo_Ky,LeadTipo_Titolo,LeadTipo_Default,LeadTipo_Codice,LeadTipo_Ordine,LeadTipo_UserInsert,LeadTipo_UserUpdate,LeadTipo_UserDelete,LeadTipo_DateInsert,LeadTipo_DateUpdate,LeadTipo_DateDelete) VALUES (6, N'Richieste da rivenditori', 0, N'ric_da_rivend', 6, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT LeadTipo (LeadTipo_Ky,LeadTipo_Titolo,LeadTipo_Default,LeadTipo_Codice,LeadTipo_Ordine,LeadTipo_UserInsert,LeadTipo_UserUpdate,LeadTipo_UserDelete,LeadTipo_DateInsert,LeadTipo_DateUpdate,LeadTipo_DateDelete) VALUES (7, N'Varie', 0, N'varie', 7, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT LeadTipo (LeadTipo_Ky,LeadTipo_Titolo,LeadTipo_Default,LeadTipo_Codice,LeadTipo_Ordine,LeadTipo_UserInsert,LeadTipo_UserUpdate,LeadTipo_UserDelete,LeadTipo_DateInsert,LeadTipo_DateUpdate,LeadTipo_DateDelete) VALUES (8, N'NoleggioLT', 0, N'noleggiolt', 8, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT LeadTipo (LeadTipo_Ky,LeadTipo_Titolo,LeadTipo_Default,LeadTipo_Codice,LeadTipo_Ordine,LeadTipo_UserInsert,LeadTipo_UserUpdate,LeadTipo_UserDelete,LeadTipo_DateInsert,LeadTipo_DateUpdate,LeadTipo_DateDelete) VALUES (9, N'Diplomat', 0, N'diplomat', 9, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT LeadTipo (LeadTipo_Ky,LeadTipo_Titolo,LeadTipo_Default,LeadTipo_Codice,LeadTipo_Ordine,LeadTipo_UserInsert,LeadTipo_UserUpdate,LeadTipo_UserDelete,LeadTipo_DateInsert,LeadTipo_DateUpdate,LeadTipo_DateDelete) VALUES (10, N'VIC', 0, N'vic', 10, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="SET IDENTITY_INSERT LeadTipo OFF;";
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "11 - Contenuti: tipo contenuti<br>";

            strSQL="TRUNCATE TABLE CMSContenutiTipo;";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strWHERENet="";
            strORDERNet = "CMSContenutiTipo_Ky";
            strFROMNet = "CMSContenutiTipo";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSContenutiTipo_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT CMSContenutiTipo ON;";
                strSQL+="INSERT CMSContenutiTipo (CMSContenutiTipo_Ky, CMSContenutiTipo_Titolo, CMSContenutiTipo_UrlKey, CMSContenutiTipo_UserInsert, CMSContenutiTipo_UserUpdate, CMSContenutiTipo_UserDelete, CMSContenutiTipo_DateInsert, CMSContenutiTipo_DateUpdate, CMSContenutiTipo_DateDelete) VALUES (1, N'pagine', N'pagine', 1, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT CMSContenutiTipo (CMSContenutiTipo_Ky, CMSContenutiTipo_Titolo, CMSContenutiTipo_UrlKey, CMSContenutiTipo_UserInsert, CMSContenutiTipo_UserUpdate, CMSContenutiTipo_UserDelete, CMSContenutiTipo_DateInsert, CMSContenutiTipo_DateUpdate, CMSContenutiTipo_DateDelete) VALUES (2, N'articoli', N'articoli', 1, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT CMSContenutiTipo (CMSContenutiTipo_Ky, CMSContenutiTipo_Titolo, CMSContenutiTipo_UrlKey, CMSContenutiTipo_UserInsert, CMSContenutiTipo_UserUpdate, CMSContenutiTipo_UserDelete, CMSContenutiTipo_DateInsert, CMSContenutiTipo_DateUpdate, CMSContenutiTipo_DateDelete) VALUES (3, N'404', N'404', 1, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT CMSContenutiTipo (CMSContenutiTipo_Ky, CMSContenutiTipo_Titolo, CMSContenutiTipo_UrlKey, CMSContenutiTipo_UserInsert, CMSContenutiTipo_UserUpdate, CMSContenutiTipo_UserDelete, CMSContenutiTipo_DateInsert, CMSContenutiTipo_DateUpdate, CMSContenutiTipo_DateDelete) VALUES (4, N'500', N'500', 1, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT CMSContenutiTipo (CMSContenutiTipo_Ky, CMSContenutiTipo_Titolo, CMSContenutiTipo_UrlKey, CMSContenutiTipo_UserInsert, CMSContenutiTipo_UserUpdate, CMSContenutiTipo_UserDelete, CMSContenutiTipo_DateInsert, CMSContenutiTipo_DateUpdate, CMSContenutiTipo_DateDelete) VALUES (5, N'privacy', N'privacy', 1, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT CMSContenutiTipo (CMSContenutiTipo_Ky, CMSContenutiTipo_Titolo, CMSContenutiTipo_UrlKey, CMSContenutiTipo_UserInsert, CMSContenutiTipo_UserUpdate, CMSContenutiTipo_UserDelete, CMSContenutiTipo_DateInsert, CMSContenutiTipo_DateUpdate, CMSContenutiTipo_DateDelete) VALUES (6, N'Cookie policy', N'cookie-policy', 1, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT CMSContenutiTipo (CMSContenutiTipo_Ky, CMSContenutiTipo_Titolo, CMSContenutiTipo_UrlKey, CMSContenutiTipo_UserInsert, CMSContenutiTipo_UserUpdate, CMSContenutiTipo_UserDelete, CMSContenutiTipo_DateInsert, CMSContenutiTipo_DateUpdate, CMSContenutiTipo_DateDelete) VALUES (7, N'No cookie', N'no-cookie', 1, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT CMSContenutiTipo (CMSContenutiTipo_Ky, CMSContenutiTipo_Titolo, CMSContenutiTipo_UrlKey, CMSContenutiTipo_UserInsert, CMSContenutiTipo_UserUpdate, CMSContenutiTipo_UserDelete, CMSContenutiTipo_DateInsert, CMSContenutiTipo_DateUpdate, CMSContenutiTipo_DateDelete) VALUES (8, N'home', N'home', 1, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="SET IDENTITY_INSERT CMSContenutiTipo OFF;";
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "12 - Cantieri: stati cantieri<br>";
            strWHERENet="";
            strORDERNet = "CantieriStati_Ky";
            strFROMNet = "CantieriStati";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "CantieriStati_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT CantieriStati ON;"; 
                strSQL+="INSERT CantieriStati (CantieriStati_Ky, CantieriStati_Descrizione, CantieriStati_UserInsert, CantieriStati_UserUpdate, CantieriStati_UserDelete, CantieriStati_DateInsert, CantieriStati_DateUpdate, CantieriStati_DateDelete) VALUES (1, N'In costruzione', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT CantieriStati (CantieriStati_Ky, CantieriStati_Descrizione, CantieriStati_UserInsert, CantieriStati_UserUpdate, CantieriStati_UserDelete, CantieriStati_DateInsert, CantieriStati_DateUpdate, CantieriStati_DateDelete) VALUES (2, N'Progetto', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="SET IDENTITY_INSERT CantieriStati OFF;";
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "13 - Immobili: area<br>";
            strWHERENet="";
            strORDERNet = "ImmobiliArea_Ky";
            strFROMNet = "ImmobiliArea";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "ImmobiliArea_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count<1){                
                strSQL="SET IDENTITY_INSERT ImmobiliArea ON;";
                strSQL+="INSERT ImmobiliArea (ImmobiliArea_Ky, ImmobiliArea_Descrizione, ImmobiliArea_UserInsert, ImmobiliArea_UserUpdate, ImmobiliArea_UserDelete, ImmobiliArea_DateInsert, ImmobiliArea_DateUpdate, ImmobiliArea_DateDelete) VALUES (1, N'Residenziale', NULL, NULL, NULL, NULL, NULL, NULL);";
                strSQL+="INSERT ImmobiliArea (ImmobiliArea_Ky, ImmobiliArea_Descrizione, ImmobiliArea_UserInsert, ImmobiliArea_UserUpdate, ImmobiliArea_UserDelete, ImmobiliArea_DateInsert, ImmobiliArea_DateUpdate, ImmobiliArea_DateDelete) VALUES (2, N'Commerciale', NULL, NULL, NULL, NULL, NULL, NULL);";
                strSQL+="INSERT ImmobiliArea (ImmobiliArea_Ky, ImmobiliArea_Descrizione, ImmobiliArea_UserInsert, ImmobiliArea_UserUpdate, ImmobiliArea_UserDelete, ImmobiliArea_DateInsert, ImmobiliArea_DateUpdate, ImmobiliArea_DateDelete) VALUES (3, N'Attività', NULL, NULL, NULL, NULL, NULL, NULL);";
                strSQL+="INSERT ImmobiliArea (ImmobiliArea_Ky, ImmobiliArea_Descrizione, ImmobiliArea_UserInsert, ImmobiliArea_UserUpdate, ImmobiliArea_UserDelete, ImmobiliArea_DateInsert, ImmobiliArea_DateUpdate, ImmobiliArea_DateDelete) VALUES (4, N'Terreni', NULL, NULL, NULL, NULL, NULL, NULL);";
                strSQL+="INSERT ImmobiliArea (ImmobiliArea_Ky, ImmobiliArea_Descrizione, ImmobiliArea_UserInsert, ImmobiliArea_UserUpdate, ImmobiliArea_UserDelete, ImmobiliArea_DateInsert, ImmobiliArea_DateUpdate, ImmobiliArea_DateDelete) VALUES (5, N'Non abitativo', NULL, NULL, NULL, NULL, NULL, NULL);";
                strSQL+="SET IDENTITY_INSERT ImmobiliArea OFF;";
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "14 - Immobili: categoria<br>";
            strWHERENet="";
            strORDERNet = "ImmobiliCategoria_Ky";
            strFROMNet = "ImmobiliCategoria";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "ImmobiliCategoria_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count<1){                
                strSQL="SET IDENTITY_INSERT ImmobiliCategoria ON;"; 
                strSQL+="INSERT ImmobiliCategoria (ImmobiliCategoria_Ky, ImmobiliCategoria_Descrizione, ImmobiliCategoria_DescrizioneHTML, ImmobiliCategoria_UserInsert, ImmobiliCategoria_UserUpdate, ImmobiliCategoria_UserDelete, ImmobiliCategoria_DateInsert, ImmobiliCategoria_DateUpdate, ImmobiliCategoria_DateDelete) VALUES (1, N'Affitto   ', N'affitto', NULL, NULL, NULL, NULL, NULL, NULL);";
                strSQL+="INSERT ImmobiliCategoria (ImmobiliCategoria_Ky, ImmobiliCategoria_Descrizione, ImmobiliCategoria_DescrizioneHTML, ImmobiliCategoria_UserInsert, ImmobiliCategoria_UserUpdate, ImmobiliCategoria_UserDelete, ImmobiliCategoria_DateInsert, ImmobiliCategoria_DateUpdate, ImmobiliCategoria_DateDelete) VALUES (2, N'Vendita   ', N'vendita', NULL, NULL, NULL, NULL, NULL, NULL);";
                strSQL+="SET IDENTITY_INSERT ImmobiliCategoria OFF;";            
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
 
            strRisultato += "15 - Prodotti: tipo<br>";
            strWHERENet="";
            strORDERNet = "ProdottiTipo_Ky";
            strFROMNet = "ProdottiTipo";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "ProdottiTipo_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT ProdottiTipo ON;"; 
                strSQL+="INSERT ProdottiTipo (ProdottiTipo_Ky,ProdottiTipo_Titolo,ProdottiTipo_Codice,ProdottiTipo_Attivo,ProdottiTipo_UserInsert,ProdottiTipo_UserUpdate,ProdottiTipo_UserDelete,ProdottiTipo_DateInsert,ProdottiTipo_DateUpdate,ProdottiTipo_DateDelete) VALUES (1, N'Semplice', N'simple', 1, NULL, 2, NULL, NULL, CAST(N'2018-02-06T15:11:56.167' AS DateTime), NULL);";
                strSQL+="INSERT ProdottiTipo (ProdottiTipo_Ky,ProdottiTipo_Titolo,ProdottiTipo_Codice,ProdottiTipo_Attivo,ProdottiTipo_UserInsert,ProdottiTipo_UserUpdate,ProdottiTipo_UserDelete,ProdottiTipo_DateInsert,ProdottiTipo_DateUpdate,ProdottiTipo_DateDelete) VALUES (2, N'Raggruppato', N'grouped', 0, NULL, NULL, NULL, NULL, NULL, NULL);";
                strSQL+="INSERT ProdottiTipo (ProdottiTipo_Ky,ProdottiTipo_Titolo,ProdottiTipo_Codice,ProdottiTipo_Attivo,ProdottiTipo_UserInsert,ProdottiTipo_UserUpdate,ProdottiTipo_UserDelete,ProdottiTipo_DateInsert,ProdottiTipo_DateUpdate,ProdottiTipo_DateDelete) VALUES (3, N'Configurabile', N'configurable', 0, NULL, NULL, NULL, NULL, NULL, NULL);";
                strSQL+="INSERT ProdottiTipo (ProdottiTipo_Ky,ProdottiTipo_Titolo,ProdottiTipo_Codice,ProdottiTipo_Attivo,ProdottiTipo_UserInsert,ProdottiTipo_UserUpdate,ProdottiTipo_UserDelete,ProdottiTipo_DateInsert,ProdottiTipo_DateUpdate,ProdottiTipo_DateDelete) VALUES (4, N'Virtuale', N'virtual', 1, NULL, 2, NULL, NULL, CAST(N'2018-02-06T15:09:19.310' AS DateTime), NULL);";
                strSQL+="INSERT ProdottiTipo (ProdottiTipo_Ky,ProdottiTipo_Titolo,ProdottiTipo_Codice,ProdottiTipo_Attivo,ProdottiTipo_UserInsert,ProdottiTipo_UserUpdate,ProdottiTipo_UserDelete,ProdottiTipo_DateInsert,ProdottiTipo_DateUpdate,ProdottiTipo_DateDelete) VALUES (5, N'Bundle', N'bundle', 0, NULL, NULL, NULL, NULL, NULL, NULL);";
                strSQL+="INSERT ProdottiTipo (ProdottiTipo_Ky,ProdottiTipo_Titolo,ProdottiTipo_Codice,ProdottiTipo_Attivo,ProdottiTipo_UserInsert,ProdottiTipo_UserUpdate,ProdottiTipo_UserDelete,ProdottiTipo_DateInsert,ProdottiTipo_DateUpdate,ProdottiTipo_DateDelete) VALUES (6, N'Download', N'downloadable', 0, NULL, NULL, NULL, NULL, NULL, NULL);";
                strSQL+="SET IDENTITY_INSERT ProdottiTipo OFF;";            
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
            
            strRisultato += "16 - Core: Colori<br>";
            strWHERENet="";
            strORDERNet = "Colori_Ky";
            strFROMNet = "Colori";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Colori_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT Colori ON;";   
                strSQL+="INSERT Colori (Colori_Ky,Colori_Titolo,Colori_Ordine,Colori_UserInsert,Colori_UserUpdate,Colori_UserDelete,Colori_DateInsert,Colori_DateUpdate,Colori_DateDelete) VALUES (1, N'bianco', 1, 2, 2, NULL, CAST(N'2018-10-01T14:55:41.280' AS DateTime), CAST(N'2018-10-01T14:55:41.280' AS DateTime), NULL);";
                strSQL+="INSERT Colori (Colori_Ky,Colori_Titolo,Colori_Ordine,Colori_UserInsert,Colori_UserUpdate,Colori_UserDelete,Colori_DateInsert,Colori_DateUpdate,Colori_DateDelete) VALUES (2, N'nero', 2, 2, 2, NULL, CAST(N'2018-10-01T14:56:05.610' AS DateTime), CAST(N'2018-10-01T14:56:05.610' AS DateTime), NULL);";
                strSQL+="INSERT Colori (Colori_Ky,Colori_Titolo,Colori_Ordine,Colori_UserInsert,Colori_UserUpdate,Colori_UserDelete,Colori_DateInsert,Colori_DateUpdate,Colori_DateDelete) VALUES (3, N'rosso', 3, 2, 2, NULL, CAST(N'2019-03-28T10:28:15.600' AS DateTime), CAST(N'2019-03-28T10:28:21.320' AS DateTime), NULL);";
                strSQL+="INSERT Colori (Colori_Ky,Colori_Titolo,Colori_Ordine,Colori_UserInsert,Colori_UserUpdate,Colori_UserDelete,Colori_DateInsert,Colori_DateUpdate,Colori_DateDelete) VALUES (4, N'giallo', 4, 2, 2, NULL, CAST(N'2019-03-28T10:29:30.310' AS DateTime), CAST(N'2019-03-28T10:29:37.013' AS DateTime), NULL);";  
                strSQL+="INSERT Colori (Colori_Ky,Colori_Titolo,Colori_Ordine,Colori_UserInsert,Colori_UserUpdate,Colori_UserDelete,Colori_DateInsert,Colori_DateUpdate,Colori_DateDelete) VALUES (5, N'viola', 5, 2, 2, NULL, CAST(N'2019-03-28T10:29:44.750' AS DateTime), CAST(N'2019-03-28T10:29:44.750' AS DateTime), NULL);"; 
                strSQL+="INSERT Colori (Colori_Ky,Colori_Titolo,Colori_Ordine,Colori_UserInsert,Colori_UserUpdate,Colori_UserDelete,Colori_DateInsert,Colori_DateUpdate,Colori_DateDelete) VALUES (6, N'rosa', 6, 2, 2, NULL, CAST(N'2019-03-28T10:29:51.377' AS DateTime), CAST(N'2019-03-28T10:29:51.377' AS DateTime), NULL);";
                strSQL+="INSERT Colori (Colori_Ky,Colori_Titolo,Colori_Ordine,Colori_UserInsert,Colori_UserUpdate,Colori_UserDelete,Colori_DateInsert,Colori_DateUpdate,Colori_DateDelete) VALUES (7, N'grigio', 7, 2, 2, NULL, CAST(N'2019-03-28T10:30:03.690' AS DateTime), CAST(N'2019-03-28T10:30:03.690' AS DateTime), NULL);";
                strSQL+="SET IDENTITY_INSERT Colori OFF;";                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
                    
            strRisultato += "17 - Core: Lingue<br>";
            strWHERENet="";
            strORDERNet = "Lingue_Ky";
            strFROMNet = "Lingue";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lingue_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT Lingue ON;";   
                strSQL+="INSERT Lingue (Lingue_Ky, Lingue_Codice, Lingue_Titolo, Lingue_UserInsert, Lingue_UserUpdate, Lingue_UserDelete, Lingue_DateInsert, Lingue_DateUpdate, Lingue_DateDelete, Divise_Ky, Lingue_Ordine) VALUES (1, N'it_IT', N'italiano IT', NULL, 2, NULL, NULL, CAST(N'2020-07-02T15:03:54.937' AS DateTime), NULL, 64, 1)";
                strSQL+="INSERT Lingue (Lingue_Ky, Lingue_Codice, Lingue_Titolo, Lingue_UserInsert, Lingue_UserUpdate, Lingue_UserDelete, Lingue_DateInsert, Lingue_DateUpdate, Lingue_DateDelete, Divise_Ky, Lingue_Ordine) VALUES (2, N'en_US', N'inglese US', NULL, 2, NULL, NULL, CAST(N'2018-06-29T16:15:21.523' AS DateTime), NULL, 43, 2)";
                strSQL+="INSERT Lingue (Lingue_Ky, Lingue_Codice, Lingue_Titolo, Lingue_UserInsert, Lingue_UserUpdate, Lingue_UserDelete, Lingue_DateInsert, Lingue_DateUpdate, Lingue_DateDelete, Divise_Ky, Lingue_Ordine) VALUES (3, N'en_GB', N'inglese GB', NULL, 2, NULL, NULL, CAST(N'2018-06-29T16:15:01.630' AS DateTime), NULL, 64, 3)";
                strSQL+="INSERT Lingue (Lingue_Ky, Lingue_Codice, Lingue_Titolo, Lingue_UserInsert, Lingue_UserUpdate, Lingue_UserDelete, Lingue_DateInsert, Lingue_DateUpdate, Lingue_DateDelete, Divise_Ky, Lingue_Ordine) VALUES (5, N'fr_FR', N'francese FR', NULL, 2, NULL, NULL, CAST(N'2019-03-28T10:43:49.953' AS DateTime), NULL, 64, 5)";
                strSQL+="SET IDENTITY_INSERT Lingue OFF;";                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
                    
            strRisultato += "18 - Core: Priorita<br>";
            strWHERENet="";
            strORDERNet = "Priorita_Ky";
            strFROMNet = "Priorita";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Priorita_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT Priorita ON;";   
                strSQL+="INSERT Priorita (Priorita_Ky, Priorita_Descrizione, Priorita_Colore, Priorita_Icona, Priorita_Ordine, Priorita_UserInsert, Priorita_UserUpdate, Priorita_UserDelete, Priorita_DateInsert, Priorita_DateUpdate, Priorita_DateDelete) VALUES (1, N'Bassa', N'#ffffff', N'', 1, 0, NULL, NULL, GETDATE(), NULL, NULL)";
                strSQL+="INSERT Priorita (Priorita_Ky, Priorita_Descrizione, Priorita_Colore, Priorita_Icona, Priorita_Ordine, Priorita_UserInsert, Priorita_UserUpdate, Priorita_UserDelete, Priorita_DateInsert, Priorita_DateUpdate, Priorita_DateDelete) VALUES (2, N'Normale', N'#ffffff', N'', 2, 0, NULL, NULL, GETDATE(), NULL, NULL)";
                strSQL+="INSERT Priorita (Priorita_Ky, Priorita_Descrizione, Priorita_Colore, Priorita_Icona, Priorita_Ordine, Priorita_UserInsert, Priorita_UserUpdate, Priorita_UserDelete, Priorita_DateInsert, Priorita_DateUpdate, Priorita_DateDelete) VALUES (3, N'Urgente', N'#f04124', N'fa-duotone fa-exclamation-triangle', 3, 0, NULL, NULL, GETDATE(), NULL, NULL)";
                strSQL+="SET IDENTITY_INSERT Priorita OFF;";                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
                    
            strRisultato += "19 - Core: Titoli<br>";
            strWHERENet="";
            strORDERNet = "Titoli_Ky";
            strFROMNet = "Titoli";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Titoli_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT Titoli ON;";   
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (2, N'Arch.', NULL, 2, NULL, NULL, CAST(N'2019-03-28T12:33:29.650' AS DateTime), NULL, N'N');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (3, N'Avv.', NULL, NULL, NULL, NULL, NULL, NULL, N'N');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (4, N'Cap.', NULL, NULL, NULL, NULL, NULL, NULL, N'N');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (5, N'Col.', NULL, NULL, NULL, NULL, NULL, NULL, N'N');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (6, N'Comm.', NULL, NULL, NULL, NULL, NULL, NULL, N'N');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (7, N'Dott.', NULL, NULL, NULL, NULL, NULL, NULL, N'M');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (8, N'Dott.ssa', NULL, NULL, NULL, NULL, NULL, NULL, N'F');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (9, N'Generale', NULL, NULL, NULL, NULL, NULL, NULL, N'N');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (10, N'Geom.', NULL, NULL, NULL, NULL, NULL, NULL, N'N');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (11, N'Ill.mo', NULL, NULL, NULL, NULL, NULL, NULL, N'M');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (12, N'Ing.', NULL, NULL, NULL, NULL, NULL, NULL, N'N');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (13, N'Mons.', NULL, NULL, NULL, NULL, NULL, NULL, N'M');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (14, N'On.le', NULL, NULL, NULL, NULL, NULL, NULL, N'N');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (15, N'p.a.', NULL, NULL, NULL, NULL, NULL, NULL, N'N');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (16, N'p.c.', NULL, NULL, NULL, NULL, NULL, NULL, N'N');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (17, N'p.e.', NULL, NULL, NULL, NULL, NULL, NULL, N'N');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (18, N'p.i.', NULL, NULL, NULL, NULL, NULL, NULL, N'N');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (19, N'Prof.', NULL, NULL, NULL, NULL, NULL, NULL, N'N');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (20, N'Rag.', NULL, NULL, NULL, NULL, NULL, NULL, N'N');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (21, N'Sig.', NULL, NULL, NULL, NULL, NULL, NULL, N'M');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (22, N'Sig.ina', NULL, NULL, NULL, NULL, NULL, NULL, N'F');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (23, N'Sig.ra', NULL, NULL, NULL, NULL, NULL, NULL, N'F');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (24, N'Spettabile', NULL, NULL, NULL, NULL, NULL, NULL, N'N');";
                strSQL+="INSERT Titoli (Titoli_Ky, Titoli_Descrizione, Titoli_UserInsert, Titoli_UserUpdate, Titoli_UserDelete, Titoli_DateInsert, Titoli_DateUpdate, Titoli_DateDelete, Titoli_Genere) VALUES (25, N'Ten. Col', NULL, NULL, NULL, NULL, NULL, NULL, N'N');";
                strSQL+="SET IDENTITY_INSERT Titoli OFF;";                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
                    
            strRisultato += "20 - Core: UtentiTipo<br>";
            strWHERENet="";
            strORDERNet = "UtentiTipo_Ky";
            strFROMNet = "UtentiTipo";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "UtentiTipo_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT UtentiTipo ON;";   
                strSQL+="INSERT UtentiTipo (UtentiTipo_Ky, UtentiTipo_Descrizione, UtentiTipo_UserInsert, UtentiTipo_UserUpdate, UtentiTipo_UserDelete, UtentiTipo_DateInsert, UtentiTipo_DateUpdate, UtentiTipo_DateDelete) VALUES (1, N'interno', 2, 2, NULL, CAST(N'2017-05-30T11:27:20.477' AS DateTime), CAST(N'2017-05-30T11:32:56.610' AS DateTime), NULL);";
                strSQL+="INSERT UtentiTipo (UtentiTipo_Ky, UtentiTipo_Descrizione, UtentiTipo_UserInsert, UtentiTipo_UserUpdate, UtentiTipo_UserDelete, UtentiTipo_DateInsert, UtentiTipo_DateUpdate, UtentiTipo_DateDelete) VALUES (2, N'Esterno', 2, 2, NULL, CAST(N'2017-12-12T16:21:20.557' AS DateTime), CAST(N'2017-12-12T16:21:20.557' AS DateTime), NULL);";
                strSQL+="SET IDENTITY_INSERT UtentiTipo OFF;";                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "21 - Ticket: TicketStati<br>";
            strWHERENet="";
            strORDERNet = "TicketStati_Ky";
            strFROMNet = "TicketStati";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "TicketStati_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT TicketStati ON;";   
                strSQL+="INSERT TicketStati (TicketStati_Ky, TicketStati_Titolo, TicketStati_UserInsert, TicketStati_UserUpdate, TicketStati_UserDelete, TicketStati_DateInsert, TicketStati_DateUpdate, TicketStati_DateDelete) VALUES (1, N'In lavorazione', 2, 2, NULL, CAST(N'2021-02-17T12:18:59.670' AS DateTime), CAST(N'2021-02-17T12:18:59.670' AS DateTime), NULL);";
                strSQL+="INSERT TicketStati (TicketStati_Ky, TicketStati_Titolo, TicketStati_UserInsert, TicketStati_UserUpdate, TicketStati_UserDelete, TicketStati_DateInsert, TicketStati_DateUpdate, TicketStati_DateDelete) VALUES (2, N'Chiuso', 2, 2, NULL, CAST(N'2021-02-17T12:20:41.480' AS DateTime), CAST(N'2021-02-17T12:20:41.480' AS DateTime), NULL);";
                strSQL+="SET IDENTITY_INSERT TicketStati OFF;";                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "22 - Core: CoreMenusMenuType<br>";
            strWHERENet="";
            strORDERNet = "CoreMenusMenuType_Ky";
            strFROMNet = "CoreMenusMenuType";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreMenusMenuType_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT CoreMenusMenuType ON;";   
                strSQL+="INSERT CoreMenusMenuType (CoreMenusMenuType_Ky, CoreMenusMenuType_Title, CoreMenusMenuType_UserInsert, CoreMenusMenuType_UserUpdate, CoreMenusMenuType_UserDelete, CoreMenusMenuType_DateInsert, CoreMenusMenuType_DateUpdate, CoreMenusMenuType_DateDelete) VALUES (1, N'Grid', 2, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT CoreMenusMenuType (CoreMenusMenuType_Ky, CoreMenusMenuType_Title, CoreMenusMenuType_UserInsert, CoreMenusMenuType_UserUpdate, CoreMenusMenuType_UserDelete, CoreMenusMenuType_DateInsert, CoreMenusMenuType_DateUpdate, CoreMenusMenuType_DateDelete) VALUES (2, N'Form', 2, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT CoreMenusMenuType (CoreMenusMenuType_Ky, CoreMenusMenuType_Title, CoreMenusMenuType_UserInsert, CoreMenusMenuType_UserUpdate, CoreMenusMenuType_UserDelete, CoreMenusMenuType_DateInsert, CoreMenusMenuType_DateUpdate, CoreMenusMenuType_DateDelete) VALUES (3, N'Custom Url', 2, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="SET IDENTITY_INSERT CoreMenusMenuType OFF;";                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "23 - Officina: Preparatori<br>";
            strWHERENet="";
            strORDERNet = "OfficinaPreparatori_Ky";
            strFROMNet = "OfficinaPreparatori";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "OfficinaPreparatori_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT OfficinaPreparatori ON;";   
                strSQL+="INSERT OfficinaPreparatori (OfficinaPreparatori_Ky, OfficinaPreparatori_Nominativo, OfficinaPreparatori_Ordine, OfficinaPreparatori_Colore, OfficinaPreparatori_Icona, OfficinaPreparatori_UserInsert, OfficinaPreparatori_UserUpdate, OfficinaPreparatori_UserDelete, OfficinaPreparatori_DateInsert, OfficinaPreparatori_DateUpdate, OfficinaPreparatori_DateDelete) VALUES (1, N'Paolo', 1, N'#ff0000', N'fa-duotone fa-user', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaPreparatori (OfficinaPreparatori_Ky, OfficinaPreparatori_Nominativo, OfficinaPreparatori_Ordine, OfficinaPreparatori_Colore, OfficinaPreparatori_Icona, OfficinaPreparatori_UserInsert, OfficinaPreparatori_UserUpdate, OfficinaPreparatori_UserDelete, OfficinaPreparatori_DateInsert, OfficinaPreparatori_DateUpdate, OfficinaPreparatori_DateDelete) VALUES (2, N'Giacomo', 2, N'#00ff00', N'fa-duotone fa-user', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="SET IDENTITY_INSERT OfficinaPreparatori OFF;";                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "24 - Officina: Orari<br>";
            strWHERENet="";
            strORDERNet = "OfficinaOrari_Ky";
            strFROMNet = "OfficinaOrari";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "OfficinaOrari_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT OfficinaOrari ON;";   
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (1, N'09:00', 1, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (2, N'09:15', 2, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (3, N'09:30', 3, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (4, N'09:45', 4, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (5, N'10:00', 5, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (6, N'10:15', 6, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (7, N'10:30', 7, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (8, N'10:45', 8, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (9, N'11:00', 9, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (10, N'11:15', 10, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (11, N'11:30', 11, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (12, N'11:45', 12, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (13, N'12:00', 13, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (14, N'12:15', 14, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (15, N'12:30', 15, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (16, N'15:00', 16, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (17, N'15:15', 17, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (18, N'15:30', 18, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (19, N'15:45', 19, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (20, N'16:00', 20, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (21, N'16:15', 21, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (22, N'16:30', 22, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (23, N'16:45', 23, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (24, N'17:00', 24, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (25, N'17:15', 25, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (26, N'17:30', 26, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (27, N'17:45', 27, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (28, N'18:00', 28, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (29, N'18:15', 29, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (30, N'18:30', 30, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (31, N'18:45', 31, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (32, N'19:00', 32, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (33, N'19:15', 33, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaOrari (OfficinaOrari_Ky, OfficinaOrari_Orario, OfficinaOrari_Ordine, OfficinaOrari_Colore, OfficinaOrari_Icona, OfficinaOrari_UserInsert, OfficinaOrari_UserUpdate, OfficinaOrari_UserDelete, OfficinaOrari_DateInsert, OfficinaOrari_DateUpdate, OfficinaOrari_DateDelete) VALUES (34, N'19:30', 34, N'#00FF00', 'fa-duotone fa-clock', 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="SET IDENTITY_INSERT OfficinaOrari OFF;";
                //Response.Write(strSQL);                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
            
            strRisultato += "25 - Officina: Tipo auto<br>";
            strWHERENet="";
            strORDERNet = "OfficinaTipoauto_Ky";
            strFROMNet = "OfficinaTipoauto";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "OfficinaTipoauto_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT OfficinaTipoauto ON;";   
                strSQL+="INSERT OfficinaTipoauto (OfficinaTipoauto_Ky,OfficinaTipoauto_Titolo,OfficinaTipoauto_Colore,OfficinaTipoauto_Icona,OfficinaTipoauto_Ordine,OfficinaTipoauto_UserInsert,OfficinaTipoauto_UserUpdate,OfficinaTipoauto_UserDelete,OfficinaTipoauto_DateInsert,OfficinaTipoauto_DateUpdate,OfficinaTipoauto_DateDelete) VALUES (1, N'Auto nuova', N'#ff0000', N'fa-duotone fa-car', 1, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaTipoauto (OfficinaTipoauto_Ky,OfficinaTipoauto_Titolo,OfficinaTipoauto_Colore,OfficinaTipoauto_Icona,OfficinaTipoauto_Ordine,OfficinaTipoauto_UserInsert,OfficinaTipoauto_UserUpdate,OfficinaTipoauto_UserDelete,OfficinaTipoauto_DateInsert,OfficinaTipoauto_DateUpdate,OfficinaTipoauto_DateDelete) VALUES (2, N'Auto usata', N'#00ff00', N'fa-duotone fa-car', 2, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="INSERT OfficinaTipoauto (OfficinaTipoauto_Ky,OfficinaTipoauto_Titolo,OfficinaTipoauto_Colore,OfficinaTipoauto_Icona,OfficinaTipoauto_Ordine,OfficinaTipoauto_UserInsert,OfficinaTipoauto_UserUpdate,OfficinaTipoauto_UserDelete,OfficinaTipoauto_DateInsert,OfficinaTipoauto_DateUpdate,OfficinaTipoauto_DateDelete) VALUES (3, N'Auto km0', N'#0000ff', N'fa-duotone fa-car', 3, 0, NULL, NULL, GETDATE(), NULL, NULL);";
                strSQL+="SET IDENTITY_INSERT OfficinaTipoauto OFF;";                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
            
            strRisultato += "26 - Officina: Stati<br>";
            strWHERENet="";
            strORDERNet = "OfficinaStati_Ky";
            strFROMNet = "OfficinaStati";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "OfficinaStati_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT OfficinaStati ON;";   
                  strSQL+="INSERT OfficinaStati (OfficinaStati_Ky,OfficinaStati_Titolo,OfficinaStati_Colore,OfficinaStati_Icona,OfficinaStati_Aperta,OfficinaStati_Chiusa,OfficinaStati_Ordine,OfficinaStati_UserInsert,OfficinaStati_UserUpdate,OfficinaStati_UserDelete,OfficinaStati_DateInsert,OfficinaStati_DateUpdate,OfficinaStati_DateDelete) VALUES (1, N'Da preparare', N'#ff0000', N'fa-duotone fa-folder-open', 1, 0, 1, 2, 2, NULL,GETDATE(), GETDATE(), NULL)";
                  strSQL+="INSERT OfficinaStati (OfficinaStati_Ky,OfficinaStati_Titolo,OfficinaStati_Colore,OfficinaStati_Icona,OfficinaStati_Aperta,OfficinaStati_Chiusa,OfficinaStati_Ordine,OfficinaStati_UserInsert,OfficinaStati_UserUpdate,OfficinaStati_UserDelete,OfficinaStati_DateInsert,OfficinaStati_DateUpdate,OfficinaStati_DateDelete) VALUES (2, N'In lavorazione', N'#ffff00', N'fa-duotone fa-wrench', 1, 0, 2, 2, 2, NULL, GETDATE(), GETDATE(), NULL)";
                  strSQL+="INSERT OfficinaStati (OfficinaStati_Ky,OfficinaStati_Titolo,OfficinaStati_Colore,OfficinaStati_Icona,OfficinaStati_Aperta,OfficinaStati_Chiusa,OfficinaStati_Ordine,OfficinaStati_UserInsert,OfficinaStati_UserUpdate,OfficinaStati_UserDelete,OfficinaStati_DateInsert,OfficinaStati_DateUpdate,OfficinaStati_DateDelete) VALUES (3, N'Pronta', N'#63ca4e', N'fa-duotone fa-car', 1, 0, 3, 2, 2, NULL, GETDATE(), GETDATE(), NULL)";
                  strSQL+="INSERT OfficinaStati (OfficinaStati_Ky,OfficinaStati_Titolo,OfficinaStati_Colore,OfficinaStati_Icona,OfficinaStati_Aperta,OfficinaStati_Chiusa,OfficinaStati_Ordine,OfficinaStati_UserInsert,OfficinaStati_UserUpdate,OfficinaStati_UserDelete,OfficinaStati_DateInsert,OfficinaStati_DateUpdate,OfficinaStati_DateDelete) VALUES (4, N'Consegnata', N'#00ff1e', N'fa-duotone fa-folder', 0, 1, 4, 2, 2, NULL, GETDATE(), GETDATE(), NULL)";
                strSQL+="SET IDENTITY_INSERT OfficinaStati OFF;";                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
            
            strRisultato += "27 - Tipo di campi sui sondaggi<br>";
            strWHERENet="";
            strORDERNet = "FormsFieldsTipo_Ky";
            strFROMNet = "FormsFieldsTipo";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsFieldsTipo_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="";   
                  strSQL+="INSERT FormsFieldsTipo (FormsFieldsTipo_Ky, FormsFieldsTipo_Titolo, FormsFieldsTipo_Icona, FormsFieldsTipo_Ordine, FormsFieldsTipo_UserInsert, FormsFieldsTipo_UserUpdate, FormsFieldsTipo_UserDelete, FormsFieldsTipo_DateInsert, FormsFieldsTipo_DateUpdate, FormsFieldsTipo_DateDelete) VALUES (1, N'Casella di testo', N'fa-duotone fa-input-text', 1, NULL, NULL, NULL, NULL, NULL, NULL);";
                  strSQL+="INSERT FormsFieldsTipo (FormsFieldsTipo_Ky, FormsFieldsTipo_Titolo, FormsFieldsTipo_Icona, FormsFieldsTipo_Ordine, FormsFieldsTipo_UserInsert, FormsFieldsTipo_UserUpdate, FormsFieldsTipo_UserDelete, FormsFieldsTipo_DateInsert, FormsFieldsTipo_DateUpdate, FormsFieldsTipo_DateDelete) VALUES (2, N'Checkbox', N'fa-duotone fa-square-check', 2, NULL, NULL, NULL, NULL, NULL, NULL);";
                  strSQL+="INSERT FormsFieldsTipo (FormsFieldsTipo_Ky, FormsFieldsTipo_Titolo, FormsFieldsTipo_Icona, FormsFieldsTipo_Ordine, FormsFieldsTipo_UserInsert, FormsFieldsTipo_UserUpdate, FormsFieldsTipo_UserDelete, FormsFieldsTipo_DateInsert, FormsFieldsTipo_DateUpdate, FormsFieldsTipo_DateDelete) VALUES (3, N'Radio', N'fa-duotone fa-list-radio', 3, NULL, NULL, NULL, NULL, NULL, NULL);";
                  strSQL+="INSERT FormsFieldsTipo (FormsFieldsTipo_Ky, FormsFieldsTipo_Titolo, FormsFieldsTipo_Icona, FormsFieldsTipo_Ordine, FormsFieldsTipo_UserInsert, FormsFieldsTipo_UserUpdate, FormsFieldsTipo_UserDelete, FormsFieldsTipo_DateInsert, FormsFieldsTipo_DateUpdate, FormsFieldsTipo_DateDelete) VALUES (4, N'TextArea (area di testo)', N'fa-duotone fa-text', 4, NULL, NULL, NULL, NULL, NULL, NULL);";
                  strSQL+="INSERT FormsFieldsTipo (FormsFieldsTipo_Ky, FormsFieldsTipo_Titolo, FormsFieldsTipo_Icona, FormsFieldsTipo_Ordine, FormsFieldsTipo_UserInsert, FormsFieldsTipo_UserUpdate, FormsFieldsTipo_UserDelete, FormsFieldsTipo_DateInsert, FormsFieldsTipo_DateUpdate, FormsFieldsTipo_DateDelete) VALUES (5, N'Etichetta', N'fa-duotone fa-tag', 5, NULL, NULL, NULL, NULL, NULL, NULL);";
                  strSQL+="INSERT FormsFieldsTipo (FormsFieldsTipo_Ky, FormsFieldsTipo_Titolo, FormsFieldsTipo_Icona, FormsFieldsTipo_Ordine, FormsFieldsTipo_UserInsert, FormsFieldsTipo_UserUpdate, FormsFieldsTipo_UserDelete, FormsFieldsTipo_DateInsert, FormsFieldsTipo_DateUpdate, FormsFieldsTipo_DateDelete) VALUES (6, N'Titolo', N'fa-duotone fa-heading', 6, NULL, NULL, NULL, NULL, NULL, NULL);";
                strSQL+="";                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
            
            strRisultato += "28 - FilesTipo<br>";
            strWHERENet="";
            strORDERNet = "FilesTipo_Ky";
            strFROMNet = "FilesTipo";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "FilesTipo_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT FilesTipo ON;";   
                strSQL+="INSERT FilesTipo (FilesTipo_Ky,FilesTipo_Titolo) VALUES (1, N'jpg');";
                strSQL+="INSERT FilesTipo (FilesTipo_Ky,FilesTipo_Titolo) VALUES (2, N'pdf');";
                strSQL+="SET IDENTITY_INSERT FilesTipo OFF;";                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
            
            strRisultato += "29 - Tipo progetti<br>";
            strWHERENet="";
            strORDERNet = "CommesseTipo_Ky";
            strFROMNet = "CommesseTipo";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "CommesseTipo_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT CommesseTipo ON;";   
                strSQL+="INSERT CommesseTipo (CommesseTipo_Ky,CommesseTipo_Titolo,CommesseTipo_Icona) VALUES (1, 'Progetto', 'fa-duotone fa-building');";
                strSQL+="INSERT CommesseTipo (CommesseTipo_Ky,CommesseTipo_Titolo,CommesseTipo_Icona) VALUES (2, 'Contratto ad ore', 'fa-duotone fa-clock');";
                strSQL+="SET IDENTITY_INSERT CommesseTipo OFF;";                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "30 - Utente bot<br>";
            strWHERENet="Utenti_Ky=0";
            strORDERNet = "Utenti_Ky";
            strFROMNet = "Utenti";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT Utenti ON;";   
                strSQL+="INSERT Utenti (Utenti_Ky,Utenti_Nominativo,Utenti_Nome,Utenti_Admin,Utenti_UserInsert,Utenti_DateInsert) VALUES (0, 'bot', 'bot',1,0,GETDATE());";
                strSQL+="SET IDENTITY_INSERT Utenti OFF;";                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "31 - CoreEmailTemplate<br>";
            strWHERENet="";
            strORDERNet = "CoreEmailTemplate_Ky";
            strFROMNet = "CoreEmailTemplate";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEmailTemplate_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT CoreEmailTemplate ON;";   
                strSQL+="INSERT CoreEmailTemplate (CoreEmailTemplate_Ky, CoreEmailTemplate_Codice, CoreEmailTemplate_Titolo, CoreEmailTemplate_Descrizione, CoreEmailTemplate_Subject, CoreEmailTemplate_SenderName, CoreEmailTemplate_MailText, Lingue_Ky, CoreEmailTemplate_UserInsert, CoreEmailTemplate_UserUpdate, CoreEmailTemplate_UserDelete, CoreEmailTemplate_DateInsert, CoreEmailTemplate_DateUpdate, CoreEmailTemplate_DateDelete) VALUES (1, N'officinareviewrequest', N'Richiesta recensione officina', N'Richiesta recensione officina', N'Lascia la tua recensione sulla tua esperienza con noi', N'Recensioni', N'<p>Gentile <strong>Officina_Nominativo</strong>,</p><p>ti ringraziamo per il Tuo acquisto di <strong>Officina_Vettura</strong> di colore<strong> Officina_Colore </strong>e per la fiducia che ci hai accordato.</p><p>Ti richiediamo gentilmente di dedicarci ancora 2 minuti del Tuo prezioso tempo per richiederTi una&nbsp; valutazione del nostro operato indicando 5 stelle se &egrave; soddisfatto del nostro servizio,&nbsp;ci vorranno solo pochi minuti e per noi sarebbe un grande aiuto!</p><p>Per lasciare la recensione clicca qui:&nbsp;<a href=\"https://g.page/r/CY7tJaCwAKsxEB0/review\" target=\"_blank\">https://g.page/r/CY7tJaCwAKsxEB0/review</a></p><p>Ti ricordiamo che siamo sempre a Tua completa disposizione per qualsiasi sua necessit&agrave; e/o informazione.</p><p>Grazie.</p><p>&nbsp;</p>', 1, 2, 2, NULL, CAST(N'2022-05-30T17:21:30.920' AS DateTime), CAST(N'2022-05-31T12:43:06.147' AS DateTime), NULL)";
                strSQL+="SET IDENTITY_INSERT CoreEmailTemplate OFF;";                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "32 - PreventiviAutoStati<br>";
            strWHERENet="";
            strORDERNet = "PreventiviAutoStati_Ky";
            strFROMNet = "PreventiviAutoStati";
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "PreventiviAutoStati_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtTemp.Rows.Count==0){                
                strSQL="SET IDENTITY_INSERT PreventiviAutoStati ON;";   
                strSQL+="INSERT PreventiviAutoStati ([PreventiviAutoStati_Ky], [PreventiviAutoStati_Titolo], [PreventiviAutoStati_Colore], [PreventiviAutoStati_Icona], [PreventiviAutoStati_Ordine], [PreventiviAutoStati_UserInsert], [PreventiviAutoStati_UserUpdate], [PreventiviAutoStati_UserDelete], [PreventiviAutoStati_DateInsert], [PreventiviAutoStati_DateUpdate], [PreventiviAutoStati_DateDelete]) VALUES (1, N'Esito positivo', N'#43ac6a', N'fa-duotone fa-square-check', 1, 0, NULL, NULL, GETDATE(), NULL, NULL)";
                strSQL+="INSERT PreventiviAutoStati ([PreventiviAutoStati_Ky], [PreventiviAutoStati_Titolo], [PreventiviAutoStati_Colore], [PreventiviAutoStati_Icona], [PreventiviAutoStati_Ordine], [PreventiviAutoStati_UserInsert], [PreventiviAutoStati_UserUpdate], [PreventiviAutoStati_UserDelete], [PreventiviAutoStati_DateInsert], [PreventiviAutoStati_DateUpdate], [PreventiviAutoStati_DateDelete]) VALUES (2, N'Esito negativo', N'#000000', N'fa-duotone fa-xmark', 2, 0, NULL, NULL, GETDATE(), NULL, NULL)";
                strSQL+="SET IDENTITY_INSERT PreventiviAutoStati OFF;";                 
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

            strRisultato += "<h2>Fase 6: Opzioni</h2>";
            strWHERENet="";
            strORDERNet = "CoreModulesOptions_Ky";
            strFROMNet = "CoreModulesOptions";
            dtCoreModulesOptions = new DataTable("CoreModulesOptions");
            dtCoreModulesOptions = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptions_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            conn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
            conn.Open();
            for (int i = 0; i < dtCoreModulesOptions.Rows.Count; i++){
                strWHERENet="CoreModulesOptions_Code='" + dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Code"].ToString() + "'";
                strORDERNet = "CoreModulesOptionsValue_Ky";
                strFROMNet = "CoreModulesOptionsValue";          
                dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtCoreModulesOptionsValue.Rows.Count<1){
                  strSQL="INSERT INTO CoreModulesOptionsValue (CoreModulesOptions_Code,CoreModulesOptionsValue_Value) VALUES ('" + dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Code"].ToString() + "','')";
                  //Response.Write(strSQL);
                  new SqlCommand(strSQL, conn).ExecuteNonQuery();
                }
            }
            
            strSQL="UPDATE CoreModules set CoreModules_Icon=REPLACE(CoreModules_Icon, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE CoreModules set CoreModules_Icon=REPLACE(CoreModules_Icon, 'far ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE CoreModules set CoreModules_Icon=REPLACE(CoreModules_Icon, 'fab ','fa-brands ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            
            strSQL="UPDATE CoreEntities set CoreEntities_Icon=REPLACE(CoreEntities_Icon, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE CoreEntities set CoreEntities_Icon=REPLACE(CoreEntities_Icon, 'far ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE CoreEntities set CoreEntities_Icon=REPLACE(CoreEntities_Icon, 'fab ','fa-brands ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();

            strSQL="UPDATE AnnunciStato set AnnunciStato_Icona=REPLACE(AnnunciStato_Icona, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AnnunciStato set AnnunciStato_Icona=REPLACE(AnnunciStato_Icona, 'far ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AnnunciStato set AnnunciStato_Icona=REPLACE(AnnunciStato_Icona, 'fab ','fa-brands ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();

            strSQL="UPDATE AsteEsperimentiEsiti set AsteEsperimentiEsiti_Icona=REPLACE(AsteEsperimentiEsiti_Icona, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AsteEsperimentiEsiti set AsteEsperimentiEsiti_Icona=REPLACE(AsteEsperimentiEsiti_Icona, 'far ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AsteEsperimentiEsiti set AsteEsperimentiEsiti_Icona=REPLACE(AsteEsperimentiEsiti_Icona, 'fab ','fa-brands ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();

            strSQL="UPDATE AsteNatura set AsteNatura_Icona=REPLACE(AsteNatura_Icona, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AsteNatura set AsteNatura_Icona=REPLACE(AsteNatura_Icona, 'far ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AsteNatura set AsteNatura_Icona=REPLACE(AsteNatura_Icona, 'fab ','fa-brands ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();

            strSQL="UPDATE AsteCategorie set AsteCategorie_Icona=REPLACE(AsteCategorie_Icona, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AsteCategorie set AsteCategorie_Icona=REPLACE(AsteCategorie_Icona, 'far ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AsteCategorie set AsteCategorie_Icona=REPLACE(AsteCategorie_Icona, 'fab ','fa-brands ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();

            strSQL="UPDATE AsteVendita set AsteVendita_Icona=REPLACE(AsteVendita_Icona, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AsteVendita set AsteVendita_Icona=REPLACE(AsteVendita_Icona, 'far ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AsteVendita set AsteVendita_Icona=REPLACE(AsteVendita_Icona, 'fab ','fa-brands ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            
            strSQL="UPDATE Socialchannelstype set Socialchannelstype_Icona=REPLACE(Socialchannelstype_Icona, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE Socialchannelstype set Socialchannelstype_Icona=REPLACE(Socialchannelstype_Icona, 'far ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE Socialchannelstype set Socialchannelstype_Icona=REPLACE(Socialchannelstype_Icona, 'fab ','fa-brands ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();

            strSQL="UPDATE CoreFormsTabs set CoreFormsTabs_Icon=REPLACE(CoreFormsTabs_Icon, 'fas ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE CoreFormsTabs set CoreFormsTabs_Icon=REPLACE(CoreFormsTabs_Icon, 'far ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE CoreFormsTabs set CoreFormsTabs_Icon=REPLACE(CoreFormsTabs_Icon, 'fab ','fa-brands ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE CoreAttributesType set CoreAttributesType_Icon=REPLACE(CoreAttributesType_Icon, 'fab ','fa-brands ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE CoreAttributesType set CoreAttributesType_Icon=REPLACE(CoreAttributesType_Icon, 'fas ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE CoreAttributesType set CoreAttributesType_Icon=REPLACE(CoreAttributesType_Icon, 'far ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();

            strSQL="UPDATE PagamentiMetodo set PagamentiMetodo_Icona=REPLACE(PagamentiMetodo_Icona, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AttivitaTipo set AttivitaTipo_Icona=REPLACE(AttivitaTipo_Icona, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AttivitaSettore set AttivitaSettore_Icona=REPLACE(AttivitaSettore_Icona, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AttivitaStati set AttivitaStati_Icona=REPLACE(AttivitaStati_Icona, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AttributiTipo set AttributiTipo_Icona=REPLACE(AttributiTipo_Icona, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE CommesseStato set CommesseStato_Icona=REPLACE(CommesseStato_Icona, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE OfficinaStati set OfficinaStati_Icona=REPLACE(OfficinaStati_Icona, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE OpportunitaStati set OpportunitaStati_Icona=REPLACE(OpportunitaStati_Icona, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE SitiWebTipo set SitiWebTipo_Icona=REPLACE(SitiWebTipo_Icona, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE SitiWebTipo set SitiWebTipo_Icona=REPLACE(SitiWebTipo_Icona, 'fab ','fa-brands ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE TicketStati set TicketStati_Icona=REPLACE(TicketStati_Icona, 'fas ','fa-duotone ')";
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE VeicoliTipo set VeicoliTipo_Icona=REPLACE(VeicoliTipo_Icona, 'fas ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE PasswordmanagerCategorie set PasswordmanagerCategorie_Icona=REPLACE(PasswordmanagerCategorie_Icona, 'fas ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE PasswordmanagerCategorie set PasswordmanagerCategorie_Icona=REPLACE(PasswordmanagerCategorie_Icona, 'far ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE PasswordmanagerCategorie set PasswordmanagerCategorie_Icona=REPLACE(PasswordmanagerCategorie_Icona, 'fab ','fa-brands ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE Priorita set Priorita_Icona=REPLACE(Priorita_Icona, 'fas ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE Priorita set Priorita_Icona=REPLACE(Priorita_Icona, 'far ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE Priorita set Priorita_Icona=REPLACE(Priorita_Icona, 'fab ','fa-brands ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AttivitaSettore set AttivitaSettore_Icona=REPLACE(AttivitaSettore_Icona, 'fas ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AttivitaSettore set AttivitaSettore_Icona=REPLACE(AttivitaSettore_Icona, 'far ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AttivitaSettore set AttivitaSettore_Icona=REPLACE(AttivitaSettore_Icona, 'fab ','fa-brands ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AttivitaTipo set AttivitaTipo_Icona=REPLACE(AttivitaTipo_Icona, 'fas ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AttivitaTipo set AttivitaTipo_Icona=REPLACE(AttivitaTipo_Icona, 'far ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE AttivitaTipo set AttivitaTipo_Icona=REPLACE(AttivitaTipo_Icona, 'fab ','fa-brands ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE CampagneStrategie set CampagneStrategie_Icona=REPLACE(CampagneStrategie_Icona, 'fas ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE CampagneStrategie set CampagneStrategie_Icona=REPLACE(CampagneStrategie_Icona, 'far ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE CampagneStrategie set CampagneStrategie_Icona=REPLACE(CampagneStrategie_Icona, 'fab ','fa-brands ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE LeadSorgenti set LeadSorgenti_Icona=REPLACE(LeadSorgenti_Icona, 'fas ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE LeadSorgenti set LeadSorgenti_Icona=REPLACE(LeadSorgenti_Icona, 'far ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE LeadSorgenti set LeadSorgenti_Icona=REPLACE(LeadSorgenti_Icona, 'fab ','fa-brands ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();

            strSQL="UPDATE OpportunitaSorgenti set OpportunitaSorgenti_Icona=REPLACE(OpportunitaSorgenti_Icona, 'fas ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE OpportunitaSorgenti set OpportunitaSorgenti_Icona=REPLACE(OpportunitaSorgenti_Icona, 'far ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE OpportunitaSorgenti set OpportunitaSorgenti_Icona=REPLACE(OpportunitaSorgenti_Icona, 'fab ','fa-brands ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();

            strSQL="UPDATE CoreMenusMenu set CoreMenusMenu_Icon=REPLACE(CoreMenusMenu_Icon, 'fas ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE CoreMenusMenu set CoreMenusMenu_Icon=REPLACE(CoreMenusMenu_Icon, 'far ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE CoreMenusMenu set CoreMenusMenu_Icon=REPLACE(CoreMenusMenu_Icon, 'fab ','fa-brands ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();

            strSQL="UPDATE VeicoliTipo set VeicoliTipo_Icona=REPLACE(VeicoliTipo_Icona, 'fas ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE VeicoliTipo set VeicoliTipo_Icona=REPLACE(VeicoliTipo_Icona, 'far ','fa-duotone ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE VeicoliTipo set VeicoliTipo_Icona=REPLACE(VeicoliTipo_Icona, 'fab ','fa-brands ')";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();

            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_Officina=0 WHERE UtentiGruppi_Officina Is Null;";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_Assistenza=0 WHERE UtentiGruppi_Assistenza Is Null;";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE UtentiGruppi SET UtentiGruppi_Knowledgebase=0 WHERE UtentiGruppi_Knowledgebase Is Null;";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();

            strSQL="UPDATE Utenti SET Utenti_CambioGrid=1 WHERE Utenti_CambioGrid Is Null;";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
            strSQL="UPDATE Utenti SET Utenti_CambioForm=1 WHERE Utenti_CambioForm Is Null;";            
            new SqlCommand(strSQL, conn).ExecuteNonQuery();

   }    
}
