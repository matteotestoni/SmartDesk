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
    public decimal decTotCostoOrario=0; 
    public decimal decTotCostoOrarioMese=0; 
    public decimal decTotOre=0; 
    public decimal decTotOreMese=0; 
    public decimal decTotOrePreviste=0; 
    public decimal decTotOrePrevisteMese=0; 
    public int intDocumenti_Ky = 0;
    public string strPeriodo = "";
    public string strTipo = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
            
            strAzione = Request["azione"];
            strPeriodo=Request["periodo"];
            strTipo=Request["tipo"];
            if (strAzione!="new"){
	            strWHERENet="Commesse_Ky=" + Smartdesk.Current.Request("Commesse_Ky");
	            strORDERNet = "Commesse_Ky";
	            strFROMNet = "Commesse_Vw";
	            dtCommesse = new DataTable("Commesse");
	            dtCommesse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

	            strWHERENet="Aziende_Ky=1";
	            strORDERNet = "Aziende_Ky";
	            strFROMNet = "Aziende_Vw";
	            dtAzienda = new DataTable("Azienda");
	            dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              //attivita
              if (dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){
								strWHERENet="Commesse_Ky=" + Smartdesk.Current.Request("Commesse_Ky");
								//Response.Write(strWHERENet);
                strORDERNet = "Attivita_Chiusura ASC, Attivita_Scadenza ASC";
                strFROMNet = "Attivita_Vw";
                dtAttivita = new DataTable("Attivita");
                dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              }            
              //documenti
              if (dtLogin.Rows[0]["UtentiGruppi_Vendite"].Equals(true)){
                strWHERENet="Commesse_Ky=" + Smartdesk.Current.Request("Commesse_Ky");
                strORDERNet = "Documenti_Ky DESC";
                strFROMNet = "Documenti_Vw";
                dtDocumenti = new DataTable("Documenti");
                dtDocumenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              }            
	          }
          }else{
            Response.Redirect("default.aspx");
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
    
    public Boolean GetCheckValue(string strField)
    {
      Boolean boolValore=false;
      if (strAzione=="new"){
        boolValore=false;
      }else{
        if (dtCommesse.Rows[0][strField].Equals(true)){
          boolValore=true;
        }
      }
      return boolValore;
    }
}
