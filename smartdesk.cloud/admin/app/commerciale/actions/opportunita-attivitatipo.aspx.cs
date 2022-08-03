using System;
using System.Data;
using System.Data.SqlClient;


  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtOpportunitaStati;    
    public string strAnagrafiche_Ky="";
    public string strOpportunita_Ky="";
    public string strAttivitaTipo_Ky="";
    public string strSorgente="";
    public string strAttivita_Descrizione="";
    
    public DataTable dtLogin;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

	  
	  
      if (Smartdesk.Login.Verify){
        dtLogin = Smartdesk.Data.Read("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
		strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
        strOpportunita_Ky=Smartdesk.Current.Request("Opportunita_Ky");
        strAttivitaTipo_Ky=Request["AttivitaTipo_Ky"];
        if (strAttivitaTipo_Ky==null || strAttivitaTipo_Ky.Length<1){
        	strAttivitaTipo_Ky="3";
        }
		strSorgente=Smartdesk.Current.Request("sorgente");
        strAttivita_Descrizione=Request["Attivita_Descrizione"];
        strSQL = "UPDATE Opportunita SET Opportunita_AttivitaCommerciale=GETDATE() WHERE Opportunita_Ky=" + strOpportunita_Ky;
  			//new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL = "UPDATE Anagrafiche SET Anagrafiche_AttivitaCommerciale=GETDATE() WHERE Anagrafiche_Ky=" + strAnagrafiche_Ky;
  			new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        	segnaFattaAttivita();
            switch (strSorgente){
              case "scheda-opportunita":
                Response.Redirect("/admin/app/commerciale/scheda-opportunita.aspx?Opportunita_Ky=" + strOpportunita_Ky);
                break;
              case "elenco-opportunita":
                Response.Redirect("/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=138&CoreGrids_Ky=107");
                break;
              case "elenco-lead":
                Response.Redirect("/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=199");
                break;
            }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    public bool segnaFattaAttivita(){
      string strSQL="";
	  strSQL = "INSERT INTO Attivita";
      strSQL += "([Attivita_Descrizione]";
      strSQL += ",[Attivita_Inizio]";
      strSQL += ",[Attivita_OraInizio]";
      strSQL += ",[Attivita_Scadenza]";
      strSQL += ",[Attivita_OraScadenza]";
      strSQL += ",[Attivita_Chiusura]";
      strSQL += ",[Anagrafiche_Ky]";
      strSQL += ",[Opportunita_Ky]";
      strSQL += ",[AttivitaTipo_Ky]";
      strSQL += ",[Attivita_Completo]";
      strSQL += ",[Utenti_Ky]";
      strSQL += ",[Priorita_Ky]";
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
      strSQL += "('" + strAttivita_Descrizione + "'";
      strSQL += ",GETDATE()";
      strSQL += ",CONVERT (time, SYSDATETIME())";
      strSQL += ",GETDATE()";
      strSQL += ",CONVERT (time, SYSDATETIME())";
      strSQL += ",GETDATE()";
      strSQL += "," + strAnagrafiche_Ky;
      strSQL += "," + strOpportunita_Ky;
      strSQL += "," + strAttivitaTipo_Ky;
      strSQL += ",1";
      strSQL += "," +Smartdesk.Session.CurrentUser.ToString();
      strSQL += ",1";
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
      strSQL += ",2)";
      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
      return true;
    } 
}
