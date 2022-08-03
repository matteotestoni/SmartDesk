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
    public DataTable dtUtenti;
    public DataTable dtAttivita;
    public DataTable dtAzienda;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strAzione = "";
    
    public string strAnno;
    public string strMese;
    public decimal decTotSpese=0; 
    public int intYear;
    public int intMonth;
    public DateTime dt;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            strAzione = Request["azione"];
            strAnno=Request["anno"];
            strMese=Request["mese"];
            dt=DateTime.Now;
            intYear=dt.Year;
            intMonth=dt.Month;
            if (strAzione!="new"){
	            strWHERENet="Utenti_Ky=" + Smartdesk.Current.Request("Utenti_Ky");
	            strORDERNet = "Utenti_Ky";
	            strFROMNet = "Utenti";
	            dtUtenti = new DataTable("Utenti");
	            dtUtenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

	            strWHERENet="Aziende_Ky=1";
	            strORDERNet = "Aziende_Ky";
	            strFROMNet = "Aziende_Vw";
	            dtAzienda = new DataTable("Azienda");
	            dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
	              if (dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){
	                strWHERENet=getWhere();
	                strORDERNet = "Attivita_Chiusura";
	                strFROMNet = "Attivita_Vw";
	                dtAttivita = new DataTable("Attivita");
	                dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
	              }            
	          }
      }else{
            Response.Redirect("default.aspx");
      }
    }    
    

    public string getWhere()
    {
        string strWHERE="";
        string strValue="";

	    strWHERE="Attivita_Trasferta=1";
		if (strAnno != null && strAnno != "" && strAnno != "tutti"){
            strWHERE += " AND (YEAR(Attivita_Chiusura)=" + strAnno + ")";
        }else{
            strWHERE += " AND (YEAR(Attivita_Scadenza)>=" + (intYear-1) + ")";
        }
        if (strMese != null && strMese != ""){
            strWHERE += " AND (MONTH(Attivita_Scadenza)=" + strMese + ")";
        }
    
        strValue = Smartdesk.Current.Request("Utenti_Ky");
        if (strValue != null && strValue != ""){
            strWHERE += " And (Utenti_Ky=" + strValue + ")";
        }
        return strWHERE;
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
        strValore=dtUtenti.Rows[0][strField].ToString();
      }
      return strValore;

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
}
