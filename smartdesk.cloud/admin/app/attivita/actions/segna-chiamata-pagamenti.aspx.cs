using System;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    
    
    public int intNumRecords = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strAnagrafiche_Ky = "";
    public string strFROMNet = "";
    public DateTime dt;
    
    public string strPagamenti_Ky="";
    public string strDocumenti_Ky="";
    public string strSorgente="";
    public DataTable dtLogin;

    protected void Page_Load(object sender, EventArgs e)
    {
      
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
          strPagamenti_Ky = Smartdesk.Current.Request("Pagamenti_Ky");
          strDocumenti_Ky = Smartdesk.Current.Request("Documenti_Ky");
          strAnagrafiche_Ky = Smartdesk.Current.Request("Anagrafiche_Ky");
          aggiornaPromemoria(strPagamenti_Ky);
          strSorgente=Smartdesk.Current.Request("sorgente");
		  switch (strSorgente){
            case "scheda-anagrafiche":
              Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky);
              break;
            case "elenco-pagamenti":
          	  Response.Redirect("/admin/app/pagamenti/elenco-pagamenti.aspx?salvato=salvato" + "&Anagrafiche_Ky=" + strAnagrafiche_Ky);            
              break;
            case "home":
          	  Response.Redirect("/admin/home.aspx?salvato=salvato" + "&Anagrafiche_Ky=" + strAnagrafiche_Ky);            
              break;
           default:
          	  Response.Redirect("/admin/app/pagamenti/elenco-pagamenti.aspx?salvato=salvato" + "&Anagrafiche_Ky=" + strAnagrafiche_Ky);            
              break;
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageBack +"?errore=datinoninseriti");
      }
    }    

    
    public bool aggiornaPromemoria(string strPagamenti_Ky_par){
      string strSQL="";
      SqlDataAdapter da = new SqlDataAdapter();
      SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
      SqlCommand cm = new SqlCommand();
      
      strSQL = "UPDATE Pagamenti SET Pagamenti_NumeroChiamate=Pagamenti_NumeroChiamate+1,Pagamenti_UltimoPromemoria=GETDATE() WHERE Pagamenti_Ky=" + strPagamenti_Ky_par;
      //Response.Write(strSQL);
      cm.CommandText = strSQL;
      cm.CommandType = CommandType.Text;
      cm.Connection = cn;
      cm.CommandTimeout = 300;
      da.SelectCommand = cm;
      cn.Open();
      cm.ExecuteNonQuery();

	  strSQL = "INSERT INTO Attivita";
      strSQL += "([Attivita_Descrizione]";
      strSQL += ",[Attivita_Inizio]";
      strSQL += ",[Attivita_OraInizio]";
      strSQL += ",[Attivita_Scadenza]";
      strSQL += ",[Attivita_OraScadenza]";
      strSQL += ",[Attivita_Chiusura]";
      strSQL += ",[Anagrafiche_Ky]";
      strSQL += ",[AttivitaTipo_Ky]";
      strSQL += ",[Attivita_Completo]";
      strSQL += ",[Utenti_Ky]";
      strSQL += ",[Priorita_Ky]";
      strSQL += ",[Pagamenti_Ky]";
      strSQL += ",[Documenti_Ky]";
      strSQL += ",[Attivita_Ore]";
      strSQL += ",[Attivita_Trasferta]";
      strSQL += ",[Attivita_Km]";
      strSQL += ",[Attivita_RimborsoKm]";
      strSQL += ",[Attivita_SpeseKm]";
      strSQL += ",[Attivita_SpeseAutostrada]";
      strSQL += ",[Attivita_SpeseParcheggi]";
      strSQL += ",[Attivita_SpesePasti]";
      strSQL += ",[Attivita_SpeseMezziPubblici]";
      strSQL += ",[Attivita_SpeseTotali]";
      strSQL += ",[AttivitaSettore_Ky])";
      strSQL += " VALUES";
      strSQL += "('sollecito telefonico pagamento'";
      strSQL += ",GETDATE()";
      strSQL += ",CONVERT (time, SYSDATETIME())";
      strSQL += ",GETDATE()";
      strSQL += ",CONVERT (time, SYSDATETIME())";
      strSQL += ",GETDATE()";
      strSQL += "," + strAnagrafiche_Ky;
      strSQL += ",3";
      strSQL += ",1";
      strSQL += "," +Smartdesk.Session.CurrentUser.ToString();
      strSQL += ",1";
      strSQL += "," +strPagamenti_Ky;
      strSQL += "," +strDocumenti_Ky;
      strSQL += ",0.25";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",3)";
      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
      cn.Close();
    	return true;
    } 

    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
