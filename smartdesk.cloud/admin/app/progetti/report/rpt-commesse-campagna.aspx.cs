using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net.Mail;


public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtCommesse;
    public DataTable dtDocumenti;
    public DataTable dtAttivita;
    public DataTable dtAzienda;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strAzione = "";
    public DateTime dt;
    public int intAnno = 0;
    public int intMese = 0;
    public decimal decTotOre=0; 
    public decimal decTotOreMese=0; 
    public decimal decTotBudget=0; 
    public decimal decTotBudgetMese=0; 
    public int intDocumenti_Ky = 0;
    public string strPeriodo = "";
    public string strTipo = "";
    public int intColonne = 4;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            strAzione = Request["azione"];
            strPeriodo=Request["periodo"];
            strTipo=Request["tipo"];
	            strWHERENet="Commesse_Ky=" + Smartdesk.Current.Request("Commesse_Ky");
	            strORDERNet = "Commesse_Ky";
	            strFROMNet = "Commesse_Vw";
	            dtCommesse = new DataTable("Commesse");
	            dtCommesse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (GetCheckValue(dtCommesse, "Commesse_AbilitaCampagna")==false){
                intColonne=intColonne-1;
              }
  		        if (GetCheckValue(dtCommesse, "Commesse_AbilitaBudget")==false){
                intColonne=intColonne-1;
              }
  		        if (GetCheckValue(dtCommesse, "Commesse_AbilitaFatturato")==false){
                intColonne=intColonne-1;
              }

	            strWHERENet="Aziende_Ky=1";
	            strORDERNet = "Aziende_Ky";
	            strFROMNet = "Aziende_Vw";
	            dtAzienda = new DataTable("Azienda");
	            dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              //attivita
              if (dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){
								strWHERENet="Commesse_Ky=" + Request["Commesse_Ky"] + " And Attivita_Chiusura Is Not Null AND AttivitaSettore_Ky=1";
                if (strPeriodo=="mese"){
            			dt=DateTime.Now;
			            int intYear=dt.Year;
			            int intMonth=dt.Month;
									strWHERENet+=" And Month(Attivita_Chiusura)=" + intMonth + " And Year(Attivita_Chiusura)=" + intYear;
								}
                if (strPeriodo=="meseprecedente"){
            			dt=DateTime.Now.AddMonths(-1);
			            int intYear=dt.Year;
			            int intMonth=dt.Month;
									strWHERENet+=" And Month(Attivita_Chiusura)=" + intMonth + " And Year(Attivita_Chiusura)=" + intYear;
								}
                if (strTipo=="trasferte"){
									strWHERENet+=" And Attivita_Trasferta=1";
                }
								//Response.Write(strWHERENet);
                if (GetCheckValue(dtCommesse, "Commesse_AbilitaBudget")){
                  strORDERNet = "Attivita_Campagna ASC, Attivita_Chiusura DESC";
                }else{
                  strORDERNet = "Attivita_Chiusura DESC";
                }
                strFROMNet = "Attivita_Vw";
                dtAttivita = new DataTable("Attivita");
                dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 10000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              }            
              //documenti
              if (dtLogin.Rows[0]["UtentiGruppi_Vendite"].Equals(true)){
                strWHERENet="Commesse_Ky=" + Smartdesk.Current.Request("Commesse_Ky");
                strORDERNet = "Documenti_Ky DESC";
                strFROMNet = "Documenti_Vw";
                dtDocumenti = new DataTable("Documenti");
                dtDocumenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, 1, 10000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              }            
      }else{
            Response.Redirect("default.aspx");
      }
    }    
    
    public String GetUTF(string strTestoIn)
    {
      string strTestoOut="";
      if (strTestoIn!=null){
        strTestoOut=strTestoIn.Replace(".","").Replace("&","").Replace("snc","").Replace(" ","-").Replace("--","-");
      }else{
        strTestoOut="";
      }
      return strTestoOut;
    }   

    public String GetFieldValue(string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="";
      }else{
        strValore=dtCommesse.Rows[0][strField].ToString();
      }
      return strValore;

    }
    
    public Boolean GetCheckValue(DataTable dtTabella, string strField)
    {
      Boolean boolValore=false;
      if (strAzione=="new"){
        boolValore=false;
      }else{
        if (dtTabella.Rows[0][strField].Equals(true)){
          boolValore=true;
        }
      }
      return boolValore;
    }
}
