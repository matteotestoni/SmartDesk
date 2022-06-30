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
    public DataTable dtAste;
    public DataTable dtAsteEsperimenti;
    public DataTable dtAnnunci;
    public DataTable dtAnnunciOfferte;
    public DataTable dtAsteCauzioni;
    public DataTable dtDocumenti;
    public DataTable dtFiles;
    public DataTable dtAzienda;
    public DataTable dtAnagrafiche;
    public string strAnnunci_Ky = "";
    public string strAste_Ky = "";
    public string strAsteEsperimenti_Ky = "";
    public string strAziende_Ky = "";
    public string strAnagrafiche_Ky = "";
    public string strFROMNet = "";
    public string strH1 = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
				
    //Smartdesk.Session.CurrentUser.ToString()="1";
	if (Smartdesk.Login.Verify){
        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
		boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
		strAnnunci_Ky=Smartdesk.Current.Request("Annunci_Ky");
		if (strAnnunci_Ky==null || strAnnunci_Ky.Length<1){
			strAnnunci_Ky="1";
		}
		strAsteEsperimenti_Ky=Smartdesk.Current.Request("AsteEsperimenti_Ky");
		if (strAsteEsperimenti_Ky==null || strAsteEsperimenti_Ky.Length<1){
			strAsteEsperimenti_Ky="1";
		}
		strAziende_Ky="1";            
		//servizi
		strWHERENet="Aziende_Ky=" + strAziende_Ky;
		strORDERNet = "Aziende_Ky";
		strFROMNet = "Aziende_Vw";
		dtAzienda = new DataTable("Azienda");
		dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

		dtAnnunci = Smartdesk.Data.Read("Annunci_Vw", "Annunci_Ky",strAnnunci_Ky);
		strWHERENet = "Annunci_Ky=" + strAnnunci_Ky;
        strORDERNet = "AnnunciOfferte_Ky DESC";
        strFROMNet = "AnnunciOfferte_Vw";
        dtAnnunciOfferte = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnnunciOfferte_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		strAste_Ky = dtAnnunci.Rows[0]["Aste_Ky"].ToString();
		if (strAste_Ky!=null && strAste_Ky.Length>0){
			dtAste = Smartdesk.Data.Read("Aste_Vw", "Aste_Ky", strAste_Ky );
			dtAsteEsperimenti = Smartdesk.Data.Read("AsteEsperimenti_Vw", "Aste_Ky",strAste_Ky);
			dtAsteCauzioni = Smartdesk.Data.Read("AsteCauzioni_Vw", "Aste_Ky",strAste_Ky);
			strWHERENet = "Chiave_Tabella='Aste' AND Chiave_Ky=" + strAste_Ky;
	        strORDERNet = "Files_Ky";
	        strFROMNet = "Files_Vw";
	        dtFiles = Smartdesk.Sql.getTablePage(strFROMNet, null, "Files_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		}
		strAnagrafiche_Ky=dtAnnunci.Rows[0]["Anagrafiche_Ky"].ToString();
		if (strAste_Ky!=null && strAste_Ky.Length>0){
			dtAnagrafiche = Smartdesk.Data.Read("Anagrafiche_Vw", "Anagrafiche_Ky", strAnagrafiche_Ky );
		}
      
	  
	  }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
