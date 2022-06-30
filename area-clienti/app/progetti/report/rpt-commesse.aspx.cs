using System;
using System.Data;

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
    public int intDocumenti_Ky = 0;
    public string strPeriodo = "";
    public string strTipo = "";
    public string strAnagrafiche_Ky="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      strAnagrafiche_Ky=(FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-cliente"].Value)).UserData;
	    if (strAnagrafiche_Ky!=null){
          strWHERENet = "Anagrafiche_Ky =" + strAnagrafiche_Ky;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
            strAzione=Smartdesk.Current.Request("azione");
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
								strWHERENet="Commesse_Ky=" + Request["Commesse_Ky"] + " And Attivita_Chiusura Is Not Null";
                if (strPeriodo=="mese"){
            			dt=DateTime.Now;
			            int intYear=dt.Year;
			            int intMonth=dt.Month;
									strWHERENet+=" And Month(Attivita_Chiusura)=" + intMonth + " And Year(Attivita_Chiusura)=" + intYear;
								}
                if (strTipo=="trasferte"){
									strWHERENet+=" And Attivita_Trasferta=1";
                }
								//Response.Write(strWHERENet);
                strORDERNet = "Attivita_Chiusura DESC";
                strFROMNet = "Attivita_Vw";
                dtAttivita = new DataTable("Attivita");
                dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
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
    
    public String GetMese(string strMeseIn)
    {
      string strMeseOut="";
      if (strMeseIn!=null){
        switch (strMeseIn){
          case "1":
            strMeseOut="gennaio";
            break;
          case "2":
            strMeseOut="febbraio";
            break;
          case "3":
            strMeseOut="marzo";
            break;
          case "4":
            strMeseOut="aprile";
            break;
          case "5":
            strMeseOut="maggio";
            break;
          case "6":
            strMeseOut="giugno";
            break;
          case "7":
            strMeseOut="luglio";
            break;
          case "8":
            strMeseOut="agosto";
            break;
          case "9":
            strMeseOut="settembre";
            break;
          case "10":
            strMeseOut="ottobre";
            break;
          case "11":
            strMeseOut="novembre";
            break;
          case "12":
            strMeseOut="dicembre";
            break;
        }
      }else{
        strMeseOut="";
      }
      return strMeseOut;
    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App) //#bp
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}
