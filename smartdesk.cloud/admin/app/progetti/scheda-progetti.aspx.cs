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
    public DataTable dtAttivitaCategorie;
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
    public int intColonne = 8;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strWHEREPermessi = "";
      string strReportdatarangestart = "";
      string strReportdatarangeend = "";

      if (Smartdesk.Login.Verify){
            dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());                      
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            if (Request.Cookies["reportdatarangestart"]!=null){
              strReportdatarangestart=Request.Cookies["reportdatarangestart"].Value;
            }
            if (Request.Cookies["reportdatarangeend"]!=null){
              strReportdatarangeend=Request.Cookies["reportdatarangeend"].Value;
            }
            if (strReportdatarangestart==null || strReportdatarangestart==""){
              strReportdatarangestart=new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("MM-dd-yyyy") + " 00:00";
            }
            if (strReportdatarangeend==null || strReportdatarangeend==""){
              strReportdatarangeend=DateTime.Now.ToString("MM-dd-yyyy") + " 23:59";
            }
            dt=DateTime.Now;
            intYear=dt.Year;
            intMonth=dt.Month;            
            
			      strAzione = Request["azione"];
            strCommesse_Ky=Smartdesk.Current.Request("Commesse_Ky");
            if (strAzione!="new"){
            strAzione = "modifica";
	        	dtCommesse = Smartdesk.Data.Read("Commesse_Vw", "Commesse_Ky",Smartdesk.Current.QueryString("Commesse_Ky"));
            strH1="Progetti > " + GetFieldValue(dtCommesse, "CommesseTipo_Titolo");
		        intColonne=8;
            if (GetCheckValue(dtCommesse, "Commesse_AbilitaCampagna")==false){
              intColonne=intColonne-1;
            }
		        if (GetCheckValue(dtCommesse, "Commesse_AbilitaBudget")==false){
              intColonne=intColonne-1;
            }
		        if (GetCheckValue(dtCommesse, "Commesse_AbilitaFatturato")==false || dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(false)){
              intColonne=intColonne-1;
            }

			      //note
        	  dtNote = Smartdesk.Data.Read("Note_Vw", "Commesse_Ky",Smartdesk.Current.QueryString("Commesse_Ky"));
            //utenti
            strWHERENet="Utenti_Attivo=1";
            strORDERNet = "Utenti_Nome, Utenti_Cognome";
            strFROMNet = "Utenti";
            dtUtenti = new DataTable("Utenti");
            dtUtenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            //categorie
            strWHERENet="AttivitaCategorie_Attiva=1";
            strORDERNet = "AttivitaCategorie_Ordine";
            strFROMNet = "AttivitaCategorie";
            dtAttivitaCategorie = new DataTable("AttivitaCategorie");
            dtAttivitaCategorie = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttivitaCategorie_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            //attivita
            if (dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){
              strWHERENet="AttivitaStati_Aperta=1 AND Commesse_Ky=" + strCommesse_Ky;
              strORDERNet = "Attivita_Scadenza DESC, Attivita_Ky";
              strFROMNet = "Attivita_Vw";
              dtAttivita = new DataTable("Attivita");
              dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 500,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
              strWHERENet="Attivita_Chiusura>='" + strReportdatarangestart + "' AND Attivita_Chiusura<='" + strReportdatarangeend + "' AND AttivitaStati_Chiusa=1 AND Commesse_Ky=" + strCommesse_Ky;
              if (Request["Attivita_Descrizione"]!=null && Request["Attivita_Descrizione"].Length>0){
                strWHERENet+=" AND Attivita_Descrizione like '%" + Request["Attivita_Descrizione"] + "%'";
              }
              if (Request["Attivita_Campagna"]!=null && Request["Attivita_Campagna"].Length>0){
                strWHERENet+=" AND Attivita_Campagna like '%" + Request["Attivita_Campagna"] + "%'";
              }
              if (Request["AttivitaCategorie_Ky"]!=null && Request["AttivitaCategorie_Ky"].Length>0){
                strWHERENet+=" AND AttivitaCategorie_Ky=" + Request["AttivitaCategorie_Ky"];
              }
              if (Request["Utenti_Ky"]!=null && Request["Utenti_Ky"].Length>0){
                strWHERENet+=" AND Utenti_Ky=" + Request["Utenti_Ky"];
              }
              //Response.Write(strWHERENet);
              strORDERNet = "Attivita_Chiusura DESC, Attivita_Ky DESC";
              strFROMNet = "Attivita_Vw";
              dtAttivitaCompletate = new DataTable("AttivitaCompletate");
              dtAttivitaCompletate = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 500,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
            }            
	          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
                                                                                                                       
    public Boolean GetCheckValue(DataTable dtTabella, string strField)
    {
        Boolean boolValore = false;
        if (strAzione == "new")
        {
            boolValore = false;
        }
        else
        {
            boolValore = Smartdesk.Data.FieldBool(dtTabella,strField);
        }
        return boolValore;
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
}
