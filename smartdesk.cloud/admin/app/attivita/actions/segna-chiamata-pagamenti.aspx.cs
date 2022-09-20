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
          if (strDocumenti_Ky==null || strDocumenti_Ky.Length<1){
            strDocumenti_Ky="null"; 
          }
          strAnagrafiche_Ky = Smartdesk.Current.Request("Anagrafiche_Ky");
          if (strAnagrafiche_Ky==null || strAnagrafiche_Ky.Length<1){
            strAnagrafiche_Ky="null"; 
          }
          aggiornaPromemoria(strPagamenti_Ky);
          strSorgente=Smartdesk.Current.Request("sorgente");
		      switch (strSorgente){
            case "scheda-anagrafiche":
              Response.Redirect("/admin/goto-form.aspx?CoreEntities_Ky=162&salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky);
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
            
      strSQL = "UPDATE Pagamenti SET Pagamenti_NumeroChiamate=Pagamenti_NumeroChiamate+1,Pagamenti_UltimoPromemoria=GETDATE() WHERE Pagamenti_Ky=" + strPagamenti_Ky_par;
      //Response.Write(strSQL);
      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

	  strSQL = "INSERT INTO Attivita";
      strSQL += "([Attivita_Descrizione]";
      strSQL += ",[Attivita_Inizio]";
      strSQL += ",[Attivita_Scadenza]";
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
      strSQL += ",GETDATE()";
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
      Response.Write(strSQL);
      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
    	return true;
    } 
}
