using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

public partial class _Default : System.Web.UI.Page {
  
  public int intNumRecords = 0;
  public int i = 0;
  public int j = 0;
  public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo ("it-IT");
  public string strLogin = "";
  public DataTable dtLogin;
  public bool boolAdmin = false;
  public DataTable dtAssenze;
  public DataTable dtPersone;
  public int intPersone_Ky = 0;
  public string strFROMNet = "";
  public string strWHERENet = "";
  public string strORDERNet = "";
  public string strH1 = "Assenze";
  public DateTime dt;
  public int intYear;
  public int intAnno;
  public int intMese;
  public string strAnno;
  public string strMese;
  public int intMonth;
  public int intOreFerie;
  public int intOreGiornaliere=1;
  public decimal decSaldo;
  public decimal decTotAssenze = 0;
  public decimal decTotRitardi = 0;
  public decimal decTotUsciteAnticipate = 0;
  public decimal decTotPresenzeOrdinarie = 0;
  public decimal decTotPresenzeStraordinarie = 0;
  public decimal decTotRecuperi = 0;
  public decimal decTotMalattia = 0;
  public decimal decTotCassaIntegrazione = 0;
  public decimal decTotFestivita = 0;
  public decimal decTotProgressivo = 0;
  
  public DataTable dtGridData;

  protected void Page_Load (object sender, EventArgs e) {
    string strPage = "";
    int intPage = 0;

    

    if (Smartdesk.Login.Verify) {
      dtLogin = Smartdesk.Data.Read ("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString ());
      if (dtLogin.Rows.Count > 0) {
        boolAdmin = (dtLogin.Rows[0]["Utenti_Admin"]).Equals (true);
        strPage = Request["page"];
        if ((strPage == null) || (strPage == "")) {
          intPage = 1;
        } else {
          intPage = Convert.ToInt32 (strPage);
        }
        dt = DateTime.Now;
        intYear = dt.Year;
        intMonth = dt.Month;

        strAnno = Request["anno"];
        if (strAnno!=null && strAnno.Length>3 && strAnno!="tutti"){
          intAnno=Convert.ToInt32(strAnno);
        }else{
          strAnno=intYear.ToString();
          intAnno=intYear;
        }
        strMese = Request["mese"];
        if (strMese!=null && strMese.Length>3 && strMese!="tutti"){
          intMese=Convert.ToInt32(strMese);
        }else{
          strMese=intMonth.ToString();
          intMese=intMonth;
        }

        strFROMNet = "Persone";
        strWHERENet = getWherePersone();
        strORDERNet = "Persone_Ky";
        dtPersone = Smartdesk.Sql.getTablePage(strFROMNet, null, "Persone_Ky", strWHERENet, strORDERNet, 1, 2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        
        strFROMNet = "PersoneAssenze_Vw";
        strWHERENet = getWhere ();
        strORDERNet = "Persone_Cognome, PersoneAssenze_Data ASC";
        dtAssenze = new DataTable ("PersoneAssenze");
        dtAssenze = Smartdesk.Sql.getTablePage(strFROMNet, null, "PersoneAssenze_Ky", strWHERENet, strORDERNet, intPage, 2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        dtGridData = dtAssenze;
      } else {
        Response.Redirect (Smartdesk.Current.LoginPageRoot);
      }
    } else {
      Response.Redirect (Smartdesk.Current.LoginPageRoot);
    }
  }

  public string getOre (decimal decOre) {
    string strReturn;
    strReturn = "";

    if (decOre <= 160) {
      strReturn = "<span class=\"badge success\">" + decOre + "</span>";
    }
    if (decOre > 160 && decOre < 240) {
      strReturn = "<span class=\"badge warning\">" + decOre + "</span>";
    }
    if (decOre > 240) {
      strReturn = "<span class=\"badge alert\">" + decOre + "</span>";
    }
    return strReturn;
  }

  public string getWherePersone() {
    string strWHERE = "";
    string strValue = "";
    string strWHEREPermessi = "";
    
    strValue = Smartdesk.Current.Request ("Persone_Ky");
    if (strValue != null && strValue != "") {
      strWHERE = "(Persone_Attivo=1) AND (Persone_Ky=" + strValue + ")";
    }else{
      strWHERE = "(Persone_Attivo=1)";
    }

    //permessi
    if (boolAdmin == false)
    {
        switch (dtLogin.Rows[0]["UtentiGruppi_PersoneQuali"].ToString())
        {
            case "1":
                strWHEREPermessi = "";
                break;
            case "2":
                strWHEREPermessi = "(UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString() + ")";
                break;
            case "3":
                strWHEREPermessi = "(Persone_Ky=" + dtLogin.Rows[0]["Persone_Ky"].ToString() + ")";
                break;
        }
        if (strWHEREPermessi.Length > 0)
        {
            if (strWHERE.Length > 0)
            {
                strWHERE = strWHERE + " And " + strWHEREPermessi;
            }
            else
            {
                strWHERE = strWHEREPermessi;
            }
        }

    }
    return strWHERE;
  }


  public string getWhere(){
    string strWHERE = "";
    string strValue = "";
    string strWHEREPermessi = "";

    strWHERE = "";
    strH1 = "Assenze";
    strWHERE = "";
    strValue = Request["anno"];
    if (strValue != null && strValue != "" && strValue != "tutti") {
      strWHERE = "(PersoneAssenze_Anno=" + strValue + ")";
      strH1 = "Assenze anno: " + strValue;
    } else {
      strWHERE = "(PersoneAssenze_Anno>=" + (intYear) + ")";
      strH1 = "Assenze";
    }

    strValue = Request["mese"];
    if (strValue != null && strValue != "" && strValue != "tutti") {
      strWHERE = strWHERE + " And (Month(PersoneAssenze_Data)=" + strValue + ")";
      strH1 = "Assenze mese: " + strValue;
    }

    strValue = Smartdesk.Current.Request ("Persone_Ky");
    if (strValue != null && strValue != "") {
      strWHERE = strWHERE + " And (Persone_Ky=" + strValue + ")";
    }
    strValue = Request["tutti"];
    if (strValue != null && strValue != "") {
      strWHERE = "";
      strH1 = "Assenze di tutti";
    }

    //permessi
    if (boolAdmin == false)
    {
        switch (dtLogin.Rows[0]["UtentiGruppi_PersoneQuali"].ToString())
        {
            case "1":
                strWHEREPermessi = "";
                break;
            case "2":
                strWHEREPermessi = "(UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString() + ")";
                break;
            case "3":
                strWHEREPermessi = "(Persone_Ky=" + dtLogin.Rows[0]["Persone_Ky"].ToString() + ")";
                break;
        }
        if (strWHEREPermessi.Length > 0)
        {
            if (strWHERE.Length > 0)
            {
                strWHERE = strWHERE + " And " + strWHEREPermessi;
            }
            else
            {
                strWHERE = strWHEREPermessi;
            }
        }

    }

    //Response.Write(strWHERE);
        return strWHERE;
  }

  public DataTable getTablePage (string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App) {
    DataTable dt = Smartdesk.Sql.getTablePage (table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
    return dt;
  }
}
