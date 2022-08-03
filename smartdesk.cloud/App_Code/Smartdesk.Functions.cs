using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Mvc;

namespace Smartdesk{

  public class Functions{

    private static Smartdesk.Sql sql = new Smartdesk.Sql();

    public static string QueryString(string filed){
        string ret = "";
        try
        {
            ret = HttpContext.Current.Request.QueryString[filed];
        }
        catch
            { ret = "";  }
        return ret;
    }
        public static string SqlDeleteKey(string table)
    {
        //Azione = delete (logicon) deletefisico = Delete Fisico
        Dictionary<string, object> element = new Dictionary<string, object>() { {"azione", "deletefisico"},{ table+"_Ky", QueryString(table + "_Ky")} }; // Passo Azione = Delete
        return SqlWriteKey(table, element);
    }
    public static string SqlDeleteKeyIn(string table,string keyin)
    {
        //Azione = delete (logicon) deletefisico = Delete Fisico
        Dictionary<string, object> element = new Dictionary<string, object>() { { "azione", "deletefisico" }, { table + "_Ky", QueryString(table + "_Ky") }, {"deletein",keyin } }; // Passo Azione = Delete
        return SqlWriteKey(table, element);
    }
    public static string SqlWriteKey(string table,Dictionary<string, object> element = null)
    {
        return SqlWriteKey(SqlExec(table,element), String.Format("{0}_Ky",table));
    }
    public static string SqlWriteKey(DataTable dt, string field)
    {
        return SqlWriteKey(dt.Rows[0], field);
    }
    public static string SqlWriteKey(DataRow dr, string field)
    {
        return dr[field].ToString();
    }

    public static DataTable SqlExec(string table, Dictionary<string, object> element = null)
    {
        Smartdesk.Sql sql = new Smartdesk.Sql();
        return sql.SQLToDataTable(getSqlScript(table, element));
    }
    private static string getSqlScript(string table, Dictionary<string, object> element = null)
    {
        Dictionary<string, object> form = new Dictionary<string, object>();
        HttpContext.Current.Request.Form.CopyTo(form);
        if (element != null)
        {
            foreach (string key in element.Keys)
            {
                if (form.ContainsKey(key))
                {
                    form[key] = element[key];
                }
                else
                {
                    form.Add(key, element[key]);
                }
            }
        }
        return sql.ManageSqlTabella(Smartdesk.Config.Sql.Path.Table(table), form);
    }
   
    public static string ManutenzioneScaricaTuttoDBToXML()
    {
        return sql.ManutenzioneScaricaTuttoDBToXML();
    }
    public static string ManutenzioneAddDateUserTuttoDBToXML()
    {
       return sql.ManutenzioneAddDateUserTuttoDBToXML();
    }
    public static string ManutenzioneAddFieldDBToXML()
    {
        return sql.ManutenzioneAddFieldDBToXML();
    }

    public static string ManutenzioneAddViewXMLTotDB()
    {
        return sql.ManutenzioneAddViewXMLTotDB();
    }

    /**
     * Get week number from date
     *
     * @return int
     */
    public static int GetSettimana(string strData){
		int intSettimana=0;
		  DateTime dt;
      if (strData.Length>0){
				dt = Convert.ToDateTime(strData);
				DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
				Calendar cal = dfi.Calendar;
				intSettimana=cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
			}
		  return intSettimana;
	  }
    
    /**
     * Get name of day
     *
     * @return string
     */
    public static string GetGiorno(string strData) {
      string strGiornoOut = "";
      DateTime dt;
      int intGiorno = 0;
      if (strData.Length > 0) {
        dt = Convert.ToDateTime (strData);
        intGiorno = (int) dt.DayOfWeek;
        switch (intGiorno) {
          case 1:
            strGiornoOut = "luned&igrave;";
            break;
          case 2:
            strGiornoOut = "marted&igrave;";
            break;
          case 3:
            strGiornoOut = "mercoled&igrave;";
            break;
          case 4:
            strGiornoOut = "gioved&igrave;";
            break;
          case 5:
            strGiornoOut = "venerd&igrave;";
            break;
          case 6:
            strGiornoOut = "sabato";
            break;
          case 7:
            strGiornoOut = "domenica";
            break;
        }
      }
      return strGiornoOut;
    }
    
    /**
     * Get name of month
     *
     * @return string
     */
    public static string GetMese(string strMeseIn)
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
    
    /**
     * Get tags separated by comma
     *
     * @return string
     */
  	public static string getTags(string strIN){
      string strOUT="";
      Char delimiter = ',';
	    String[] substrings = strIN.Split(delimiter);
    	foreach (var substring in substrings){
       	strOUT=strOUT+"<span class=\"label secondary\">" + substring + "</span>";
      }
      return strOUT;
    }

    /**
     * Get option
     *
     * @return string
     */
  	public static string getOption(string strCoreModulesOptions_Code){
      string strWHERENet = "";
      string strORDERNet = "";
      string strFROMNet = "";
      DataTable dtCoreModulesOptionsValue;
      string strCoreModulesOptionsValue_Value = "";

      strWHERENet="CoreModulesOptions_Code='" + strCoreModulesOptions_Code +"'";
      strORDERNet = "CoreModulesOptionsValue_Ky";
      strFROMNet = "CoreModulesOptionsValue";
      int intNumRecords=0;
      dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1, Smartdesk.Config.Sql.ConnectionReadOnly, out intNumRecords);
      if (dtCoreModulesOptionsValue.Rows.Count>0){
          strCoreModulesOptionsValue_Value=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
      }            
      return strCoreModulesOptionsValue_Value;
    }


    /**
     * Get badge days
     *
     * @return string
     */
    public static string getGG(string strNumGG){
	    string strReturn;
	    int intNumGG;
    
    	strReturn="";
  		try{
  			intNumGG=Convert.ToInt32(strNumGG);
  		}catch{
  			intNumGG=0;	
  		}
  		if (intNumGG<=60){
  		  strReturn="<span class=\"badge success\">" + strNumGG + "</span>";
  		}
  		if (intNumGG>60 && intNumGG<120){
  		  strReturn="<span class=\"badge warning\">" + strNumGG + "</span>";
  		}
  		if (intNumGG>120){
  		  strReturn="<span class=\"badge alert animate__animated animate__headShake animate__infinite infinite\">" + strNumGG + "</span>";
  		}
		  return strReturn;
	 }

    /**
     * Get badge ore
     *
     * @return string
     */
    public static string getGGDaFare(string strNumGG){
	    string strReturn;
	    int intNumGG;
    
    	strReturn="";
  		try{
  			intNumGG=Convert.ToInt32(strNumGG);
  		}catch{
  			intNumGG=0;	
  		}
  		if (intNumGG<=0){
  		  strReturn="<span class=\"badge success\">" + strNumGG + "</span>";
  		}
  		if (intNumGG>0 && intNumGG<=30){
  		  strReturn="<span class=\"badge warning\">" + strNumGG + "</span>";
  		}
  		if (intNumGG>30){
  		  strReturn="<span class=\"badge alert animate__animated animate__headShake animate__infinite infinite\">" + strNumGG + "</span>";
  		}
  		return strReturn;
  	}


    /**
     * Get badge ore residue
     *
     * @return string
     */
  	public static string GetOreResidue(string strValore){
  	string strReturn;
  		if (strValore==null){
  			strReturn="0";
  		}else{
  			if (Convert.ToDouble(strValore)<0){
  				strReturn="<span class=\"badge alert\">" + strValore + "</span>";
  			}else{
  				strReturn="<span class=\"badge success\">" + strValore + "</span>";
  			}
  		}
  		return strReturn;
    }
    
    public static bool ControllaPartitaIva (string PartitaIva) {
        int[] ListaPari = { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 };
        // normalizziamo la cifra
        if (PartitaIva.Length < 11)
            PartitaIva = PartitaIva.PadLeft (11, '0');
        // lunghezza errata non fa neanche il controllo
        if (PartitaIva.Length != 11)
            return false;
        int Somma = 0;
        for (int k = 0; k < 11; k++) {
            string s = PartitaIva.Substring (k, 1);
            // otteniamo contemporaneamente	
            // il valore, la posizione e testiamo se ci sono	
            // caratteri non numerici		
            int i = "0123456789".IndexOf (s);
            if (i == -1)
                return false;
            int x = int.Parse (s);
            if (k % 2 == 1) // Pari perch� iniziamo da zero		
                x = ListaPari[i];
            Somma += x;
        }
        return ((Somma % 10 == 0) && (Somma != 0));
    }
    
      public static bool ControllaCodiceFiscale (string cf) {
          int i, s, c;
          int[] setdisp = { 1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23 };

          if (string.IsNullOrEmpty (cf))
              return false;

          if (cf.Length != 16)
              return false;

          cf = cf.ToUpper ();

          for (i = 0; i < 16; i++) {
              if (!char.IsDigit (cf[i]) && !('A' <= cf[i] && cf[i] <= 'Z'))
                  return false;
          }

          s = 0;
          int asciiA = Convert.ToInt32 ('A');
          int ascii0 = Convert.ToInt32 ('0');
          for (i = 1; i <= 13; i += 2) {
              if (char.IsDigit (cf[i]))
                  s += Convert.ToInt32 (cf[i]) - ascii0;
              else
                  s += Convert.ToInt32 (cf[i]) - asciiA;
          }

          for (i = 0; i <= 14; i += 2) {
              c = Convert.ToInt32 (cf[i]);
              if (char.IsDigit (cf[i]))
                  c = c - ascii0 + asciiA;
              s += setdisp[c - asciiA];
          }

          if ((s % 26) + asciiA != Convert.ToInt32 (cf[15]))
              return false;

          return true;
      }
    
      public static string GetValorePageSpeed (string strValore) {
          int intValore;
          string strReturn = "";
          if (strValore == null || strValore.Length < 1) {
              strReturn = "";
          } else {
              try {
                  intValore = Convert.ToInt32 (strValore);
              } catch {
                  intValore = 0;
              }
              if (intValore >= 70) {
                  strReturn = "<span class=\"badge success\"><strong>" + strValore + "</strong></span>";
              }
              if (intValore < 70) {
                  strReturn = "<span class=\"badge warning\"><strong>" + strValore + "</strong></span>";
              }
              if (intValore < 50) {
                  strReturn = "<span class=\"badge alert\"><strong>" + strValore + "</strong></span>";
              }
              if (intValore < 1) {
                  strReturn = "-";
              }
          }
          return strReturn;

      }

  }
}
