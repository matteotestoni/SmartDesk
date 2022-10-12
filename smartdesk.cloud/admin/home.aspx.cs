using System;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtCMSLink;
    public DataTable dtPagamentiScaduti;
    public DataTable dtPagamentiFuturi;
    public DataTable dtPagamentiDaFare;
    public DataTable dtAttivita;
    public DataTable dtAttivitaCommerciali;
    public DataTable dtAnagraficheServizi;
    public DataTable dtFormsAvanzamento;
    public int intAnagrafiche_Ky = 0;
    public decimal decTot=0; 
    public decimal decTotMese=0; 
    public int intAnno = 0;
    public int intMese = 0;
    public string strColor="";
    public DateTime dt;
    public int intPersone_Ky = 0;
    public int intUtenti_Ky = 0;
    public string strActive=" is-active";
    public string strActiveTab = " is-active";
    public string strH1="Smartdesk > Home";
    public DataTable dtGridData;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";

      if (Context.Request.Cookies["rswcrm"]!=null){
        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
      		if (dtLogin.Rows.Count>0){
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
      			if (dtLogin.Rows[0]["Persone_Ky"]!=DBNull.Value){
      				intPersone_Ky=Convert.ToInt32(dtLogin.Rows[0]["Persone_Ky"]);				
      				intUtenti_Ky=Convert.ToInt32(dtLogin.Rows[0]["Utenti_Ky"]);				
      			}else{
      				intPersone_Ky=0;				
      				intUtenti_Ky=0;
      			}
      			tracciaLogin(Smartdesk.Session.CurrentUser.ToString());
      			dt=DateTime.Now;
      			int intYear=dt.Year;
      			int intMonth=dt.Month+1;

    				strWHERENet="";
    				strFROMNet = "CMSLink_Vw";
    				strORDERNet = "CMSLink_Destinazione ASC";
    				dtCMSLink = new DataTable("CMSLink");
    				dtCMSLink = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSLink_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

      			if (dtLogin.Rows[0]["UtentiGruppi_Servizi"].Equals(true)){
      				//servizi da fatturare
      				strWHERENet="(Anagrafiche_Disdetto!=1 Or Anagrafiche_Disdetto Is Null) And (Month(AnagraficheServizi_Scadenza)<=" + intMonth + ") And (Year(AnagraficheServizi_Scadenza)=" + intYear + ")";
      				//Response.Write(strWHERENet);
      				strFROMNet = "AnagraficheServizi_Vw";
      				strORDERNet = "AnagraficheServizi_Scadenza, Anagrafiche_RagioneSociale ASC";
      				dtAnagraficheServizi = new DataTable("AnagraficheServizi");
      				dtAnagraficheServizi = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      			}            
      			if (dtLogin.Rows[0]["UtentiGruppi_Pagamenti"].Equals(true)){
      				//pagamenti
      				strWHERENet="(Pagamenti_Pagato='no') AND Pagamenti_Data<GETDATE() AND (PagamentiTipo_Ky=1)";
      				strFROMNet = "Pagamenti_Vw";
      				strORDERNet = "Pagamenti_Data";
      				dtPagamentiScaduti = new DataTable("PagamentiScaduti");
      				dtPagamentiScaduti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
      				//pagamenti
      				strWHERENet="(Pagamenti_Pagato='no') AND (Pagamenti_Data>=GETDATE()) AND (Pagamenti_Data<=GETDATE()+40) AND (PagamentiTipo_Ky=1)";
      				strFROMNet = "Pagamenti_Vw";
      				strORDERNet = "Pagamenti_Data";
      				dtPagamentiFuturi = new DataTable("PagamentiFuturi");
      				dtPagamentiFuturi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
      				//pagamenti
      				strWHERENet="(Pagamenti_Pagato='no') AND (Pagamenti_Data<=GETDATE()+40) AND (PagamentiTipo_Ky=2)";
      				strFROMNet = "Pagamenti_Vw";
      				strORDERNet = "Pagamenti_Data";
      				dtPagamentiDaFare = new DataTable("PagamentiDaFare");
      				dtPagamentiDaFare = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
      			}
      			if (dtLogin.Rows[0]["UtentiGruppi_Contenuti"].Equals(true)){
      				//forms
      				strWHERENet="";
      				strFROMNet = "FormsAvanzamento_Vw";
      				strORDERNet = "FormsAvanzamento_Data DESC";
      				dtFormsAvanzamento = new DataTable("FormsAvanzamento");
      				dtFormsAvanzamento = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsAvanzamento_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
      			}
            //attivita
            if (intPersone_Ky>0){
      				strWHERENet="(AttivitaSettore_Ky=2) And (Anagrafiche_Disdetto!=1) And (Attivita_Completo='no') AND (scadenzawhere<=(getdate()+120)) And Persone_Ky=" + intPersone_Ky.ToString();
      			}else{
      				strWHERENet="(AttivitaSettore_Ky=2) And (Anagrafiche_Disdetto!=1) And (Attivita_Completo='no') AND (scadenzawhere<=(getdate()+120))";
      			}
      			//Response.Write(strWHERENet);
            strFROMNet = "Attivita_Vw";
            strORDERNet = "Persone_Cognome, Persone_Nome, Attivita_Scadenza, Anagrafiche_RagioneSociale ASC";
            dtAttivitaCommerciali = new DataTable("AttivitaCommerciali");
            dtAttivitaCommerciali = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageBack +"?utente=" + Smartdesk.Session.CurrentUser.ToString());
          }
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    protected void tracciaLogin(string strUtenti_Ky)
    {
        string strSQL = "";
        string strIP = "";
        string strCookie = "";
        string strUserAgent = "";

        strIP = Request.ServerVariables["REMOTE_ADDR"];
        strUserAgent = Request.ServerVariables["HTTP_USER_AGENT"];
        strCookie = Request.ServerVariables["HTTP_COOKIE"];

        strSQL = "INSERT INTO UtentiLog (Utenti_Ky, UtentiLog_IP, UtentiLog_UserAgent, UtentiLog_Cookie, UtentiLog_Data, UtentiLog_UserInsert,UtentiLog_DateInsert) VALUES (" + strUtenti_Ky + ", '" + strIP + "', '" + strUserAgent + "', '" + strCookie + "' ,GETDATE()," + strUtenti_Ky + ",GETDATE())";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
    }
}
