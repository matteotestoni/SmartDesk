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
        
        
        
        strH1="Aggiornamento DB";         
        //vecchio framework   
        strSQL="DROP TABLE IF EXISTS frkApplications;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS frkFields;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS frkForms;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS frkFormsCreate;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS frkFormsDesign;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS frkLanguages;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS frkLog;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS frkMenu;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS frkMenuPanels;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS frkReports;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS frkReportsRecordset;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS frkResources;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS frkView;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS frkViewFields;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS frkViewFilter;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS frkWhere;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS frkWhereDesign;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP VIEW IF EXISTS frkForms_Vw;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP VIEW IF EXISTS frkLog_Vw;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP VIEW IF EXISTS frkViewFields_Vw;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP VIEW IF EXISTS frkWhereDesign_Vw;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        //Core   
        strSQL="ALTER TABLE UtentiGruppi DROP COLUMN IF EXISTS UtentiGruppi_Contratti;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        //Contratti   
        strSQL="DROP TABLE IF EXISTS Contratti;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP TABLE IF EXISTS ContrattiStato;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP VIEW IF EXISTS Contratti_Totali_Vw;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP VIEW IF EXISTS Contratti_Vw;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        //Anagrafiche   
        strSQL="ALTER TABLE AnagraficheProdotti DROP COLUMN IF EXISTS Contratti_Ky;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE AnagraficheServizi DROP COLUMN IF EXISTS Contratti_Ky;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        //Produzione   
        strSQL="ALTER TABLE Attivita DROP COLUMN IF EXISTS Contratti_Ky;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Commesse DROP COLUMN IF EXISTS Contratti_Ky;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Commesse DROP COLUMN IF EXISTS Persone_Ky;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        //Documenti   
        strSQL="ALTER TABLE Documenti DROP COLUMN IF EXISTS Contratti_Ky;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        //Note   
        strSQL="ALTER TABLE Note DROP COLUMN IF EXISTS Contratti_Ky;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        //Commerciale   
        strSQL="ALTER TABLE Lead DROP COLUMN IF EXISTS Contratti_Ky;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Opportunita DROP COLUMN IF EXISTS Contratti_Ky;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE PreventiviAuto DROP COLUMN IF EXISTS PreventiviAuto_Accessori;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE PreventiviAuto DROP COLUMN IF EXISTS PreventiviAuto_IVA;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE PreventiviAuto DROP COLUMN IF EXISTS PreventiviAuto_Pagamento;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Opportunita DROP COLUMN IF EXISTS Persone_Ky;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP VIEW IF EXISTS Lead_Giornalieri_Vw;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="DROP VIEW IF EXISTS PreventiviAuto_Giornalieri_Vw;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        //Amministrazione  
        strSQL="ALTER TABLE Pagamenti DROP COLUMN IF EXISTS Contratti_Ky;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        //Assistenza  
        strSQL="ALTER TABLE Ticket DROP COLUMN IF EXISTS Contratti_Ky;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Spese DROP COLUMN IF EXISTS Contratti_Ky;";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE FormsFields DROP COLUMN IF EXISTS FormsFields_Tipo;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE CentridiCR DROP COLUMN IF EXISTS Persone_Ky;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE CMSBlocchi DROP COLUMN IF EXISTS Persone_Ky;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE CMSContenuti DROP COLUMN IF EXISTS Persone_Ky;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE CMSGallerie DROP COLUMN IF EXISTS Persone_Ky;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE CMSLink DROP COLUMN IF EXISTS Persone_Ky;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE CMSSlide DROP COLUMN IF EXISTS Persone_Ky;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Faq DROP COLUMN IF EXISTS Persone_Ky;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Immobili DROP COLUMN IF EXISTS Persone_Ky;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE ImmobiliSincro DROP COLUMN IF EXISTS Persone_Ky;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Opportunita DROP COLUMN IF EXISTS Persone_Ky;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Aziende DROP COLUMN IF EXISTS Aziende_Indirizzo;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Aziende DROP COLUMN IF EXISTS Aziende_CAP;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Aziende DROP COLUMN IF EXISTS Aziende_Comune;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Aziende DROP COLUMN IF EXISTS Aziende_Provincia;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Aziende DROP COLUMN IF EXISTS Aziende_IndirizzoOperativa;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Aziende DROP COLUMN IF EXISTS Aziende_CAPOperativa;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Aziende DROP COLUMN IF EXISTS Aziende_ComuneOperativa;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Aziende DROP COLUMN IF EXISTS Aziende_ProvinciaOperativa;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Officina DROP COLUMN IF EXISTS Officina_Preparatore;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Officina DROP COLUMN IF EXISTS Officina_Contenuti;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Officina DROP COLUMN IF EXISTS Officina_Elaborazioni;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="ALTER TABLE Officina DROP COLUMN IF EXISTS Officina_Marchiature;";  
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'dbo.AggregatedCounter', N'U') IS NOT NULL DROP TABLE [dbo].[AggregatedCounter];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'dbo.Counter', N'U') IS NOT NULL DROP TABLE [dbo].[Counter];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'dbo.Hash', N'U') IS NOT NULL DROP TABLE [dbo].[Hash];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'dbo.Job', N'U') IS NOT NULL DROP TABLE [dbo].[Job];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'dbo.JobParameter', N'U') IS NOT NULL DROP TABLE [dbo].[JobParameter];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'dbo.JobQueue', N'U') IS NOT NULL DROP TABLE [dbo].[JobQueue];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'dbo.List', N'U') IS NOT NULL DROP TABLE [dbo].[List];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'dbo.Schema', N'U') IS NOT NULL DROP TABLE [dbo].[Schema];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'dbo.Server', N'U') IS NOT NULL DROP TABLE [dbo].[Server];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'dbo.Set', N'U') IS NOT NULL DROP TABLE [dbo].[Set];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'dbo.State', N'U') IS NOT NULL DROP TABLE [dbo].[State];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'HangFire.AggregatedCounter', N'U') IS NOT NULL DROP TABLE [HangFire].[AggregatedCounter];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'HangFire.Counter', N'U') IS NOT NULL DROP TABLE [HangFire].[Counter];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'HangFire.Hash', N'U') IS NOT NULL DROP TABLE [HangFire].[Hash];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'HangFire.Job', N'U') IS NOT NULL DROP TABLE [HangFire].[Job];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'HangFire.JobParameter', N'U') IS NOT NULL DROP TABLE [HangFire].[JobParameter];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'HangFire.JobQueue', N'U') IS NOT NULL DROP TABLE [HangFire].[JobQueue];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'HangFire.List', N'U') IS NOT NULL DROP TABLE [HangFire].[List];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'HangFire.Schema', N'U') IS NOT NULL DROP TABLE [HangFire].[Schema];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'HangFire.Server', N'U') IS NOT NULL DROP TABLE [HangFire].[Server];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'HangFire.Set', N'U') IS NOT NULL DROP TABLE [HangFire].[Set];";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL="IF OBJECT_ID(N'HangFire.State', N'U') IS NOT NULL DROP TABLE [HangFire].[State];";
 }    
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
