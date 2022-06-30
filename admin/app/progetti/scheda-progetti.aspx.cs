using System;
using System.Data;
using System.Globalization;

public partial class _Default : System.Web.UI.Page 
{
    public NumberFormatInfo nfi = new CultureInfo( "it-IT", false ).NumberFormat;
	
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo cien = new System.Globalization.CultureInfo("en-US");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtCommesse;
    public DataTable dtAttivita;
    public DataTable dtAttivitaCompletate;
    public DataTable dtUtenti;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strAzione = "";
    public DateTime dt;
    public int intYear;
    public int intMonth;
    public int intAnno;
    public decimal decTot=0; 
    public decimal decTotServizi=0; 
    public decimal decTotIVA=0; 
    public decimal decTotOre=0; 
    public string strCommesse_Ky = "";
    
    public DataTable dtNote;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strWHEREPermessi = "";

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strH1="Scheda progetto";
			      strAzione = Request["azione"];
            strCommesse_Ky=Smartdesk.Current.Request("Commesse_Ky");
            if (strAzione!="new"){
            strAzione = "modifica";
	        	dtCommesse = Smartdesk.Data.Read("Commesse_Vw", "Commesse_Ky",Smartdesk.Current.QueryString("Commesse_Ky"));

			  //note
        	  dtNote = Smartdesk.Data.Read("Note_Vw", "Commesse_Ky",Smartdesk.Current.QueryString("Commesse_Ky"));
            strWHERENet="Utenti_Attivo=1";
            strORDERNet = "Utenti_Nome, Utenti_Cognome";
            strFROMNet = "Utenti";
            dtUtenti = new DataTable("Utenti");
            dtUtenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            //attivita
            if (dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){
              strWHERENet="AttivitaStati_Aperta=1 AND Commesse_Ky=" + strCommesse_Ky;
              strORDERNet = "Attivita_Scadenza DESC, Attivita_Ky";
              strFROMNet = "Attivita_Vw";
              dtAttivita = new DataTable("Attivita");
              dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
              strWHERENet="AttivitaStati_Chiusa=1 AND Commesse_Ky=" + strCommesse_Ky;
              strORDERNet = "Attivita_Scadenza DESC, Attivita_Ky DESC";
              strFROMNet = "Attivita_Vw";
              dtAttivitaCompletate = new DataTable("AttivitaCompletate");
              dtAttivitaCompletate = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
            }            


	          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public String getStato(string strDocumentiStato_Ky, string strDocumentiStato_Descrizione)
    {
      string strStatoOut="";
      if (strDocumentiStato_Ky!=null){
        switch (strDocumentiStato_Ky){
          case "1":
            strStatoOut="<span class=\"label success\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "2":
            strStatoOut="<span class=\"label warning\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "3":
            strStatoOut="<span class=\"label warning\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "4":
            strStatoOut="<span class=\"label alert animate__animated animate__headShake animate__infinite infinite\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "5":
            strStatoOut="<span class=\"label success\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "6":
            strStatoOut="<span class=\"label success\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "7":
            strStatoOut="<span class=\"label warning\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "8":
            strStatoOut="<span class=\"label alert animate__animated animate__headShake animate__infinite infinite\">" + strDocumentiStato_Descrizione + "</span>";
            break;
        }
      }else{
        strStatoOut="";
      }
      return strStatoOut;
    }   

    public String GetDefaultValue(string strField)
    {
      string strValore="";
      switch (strField){
				case "CommesseStato_Ky":
					strValore="4";
					break;
				case "Commesse_Valore":
					strValore="0";
					break;
				case "Commesse_Data_IT":
					strValore=DateTime.Now.ToString("d");
					break;
				case "Commesse_DataInizioLavori_IT":
					strValore=DateTime.Now.ToString("d");
					break;
			}
      return strValore;
    }

    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="";
      }else{
        strValore=Smartdesk.Data.Field(dtTabella,strField);
      }
      return strValore;
    }
    
    public String GetFieldValueMoney(string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
            //strValore=((decimal)dtCommesse.Rows[0][strField]).ToString("N", nfi);
            strValore = dtCommesse.Rows[0][strField].ToString();
            //strValore =((decimal)dtCommesse.Rows[0][strField]).ToString();
				//strValore=strValore.Replace(",0000","");
      }
      return strValore;
    }
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
