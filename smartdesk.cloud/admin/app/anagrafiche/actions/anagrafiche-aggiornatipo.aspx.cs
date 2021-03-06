using System;

  public partial class _Default : System.Web.UI.Page 
	{
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public string strAnagrafiche_Ky="";
    public string strAnagraficheTipo_Ky="";
    public string strSorgente="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
	  
      if (Smartdesk.Login.Verify){
        strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
        strAnagraficheTipo_Ky =Request["AnagraficheTipo_Ky"];
        strSorgente=Smartdesk.Current.Request("sorgente");
        strSQL = "UPDATE Anagrafiche SET AnagraficheTipo_Ky=" + strAnagraficheTipo_Ky + " WHERE Anagrafiche_Ky=" + strAnagrafiche_Ky;
      	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
		    strSQL = "UPDATE Anagrafiche SET Anagrafiche_AttivitaCommerciale=GETDATE() WHERE Anagrafiche_Ky=" + strAnagrafiche_Ky;
      	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        segnaFattaAttivita();
        switch (strSorgente){
            case "elenco-lead":
            Response.Redirect("/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=199");
            break;
            case "elenco-anagrafiche":
            Response.Redirect("/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=199");
            break;
            default:
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
      strSQL += "('attivita commerciale: convertito in cliente'";
      strSQL += ",GETDATE()";
      strSQL += ",CONVERT (time, SYSDATETIME())";
      strSQL += ",GETDATE()";
      strSQL += ",CONVERT (time, SYSDATETIME())";
      strSQL += ",GETDATE()";
      strSQL += "," + strAnagrafiche_Ky;
      strSQL += ",1";
      strSQL += ",1";
      strSQL += "," + Smartdesk.Session.CurrentUser.ToString();
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

	  strSQL = "UPDATE Anagrafiche SET Anagrafiche_AttivitaCommerciale=GETDATE() WHERE Anagrafiche_Ky=" + strAnagrafiche_Ky;
      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

      return true;
    } 
}
