using System;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolLogin = false;  
    public DataTable dtPagamentiRicevuti;
    public DataTable dtPagamentiRicevutiPrecedenti;
    public DataTable dtPagamentiFatti;
    public DataTable dtPagamentiFattiPrecedenti;
    public string strFROMNet = "";
    public string strHtml = "";
    public DateTime dt;
    public decimal decTotRicevuti=0; 
    public decimal decTotRicevutiPrecedenti=0; 
    public decimal decTotFatti=0; 
    public decimal decTotFattiPrecedenti=0; 
    public string strWHERENet="";
    public string strORDERNet = "";
    public int intYear = DateTime.Now.Year;
    public int intMonth = DateTime.Now.Month;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

      
      

      int intWeek = DateTime.Now.DayOfYear/7;

      SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
      strSQL = "UPDATE PersoneAssenze SET PersoneAssenze_Lock=1 WHERE PersoneAssenze_Data<GETDATE()-50";
      cn.Open();
      new SqlCommand(strSQL, cn).ExecuteNonQuery();
      cn.Close();
	  
	  strFROMNet = "Pagamenti_xmese_Vw";
      strWHERENet= "(PagamentiTipo_Ky=1) AND (anno=" + intYear + ")";
      strORDERNet = "mese ASC";
      dtPagamentiRicevutiPrecedenti = new DataTable("PagamentiPrecedenti");
      dtPagamentiRicevutiPrecedenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "chiave", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
	  
	  strFROMNet = "Pagamenti_xmese_Vw";
      strWHERENet= "(PagamentiTipo_Ky=2) AND (anno=" + intYear + ")";
      strORDERNet = "mese ASC";
      dtPagamentiFattiPrecedenti = new DataTable("PagamentiFattiPrecedenti");
      dtPagamentiFattiPrecedenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "chiave", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

	  strFROMNet = "Pagamenti_Vw";
      strWHERENet= "(PagamentiTipo_Ky=1 AND Pagamenti_Pagato='si' AND (Month(Pagamenti_DataPagato)=" + intMonth + ") AND (Year(Pagamenti_DataPagato)=" + intYear + "))";
      strORDERNet = "Pagamenti_DataPagato ASC";
      dtPagamentiRicevuti = new DataTable("PagamentiRicevuti");
      dtPagamentiRicevuti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
 
	  strFROMNet = "Pagamenti_Vw";
      strWHERENet= "(PagamentiTipo_Ky=2 AND Pagamenti_Pagato='si' AND (Month(Pagamenti_DataPagato)=" + intMonth + ") AND (Year(Pagamenti_DataPagato)=" + intYear + "))";
      strORDERNet = "Pagamenti_DataPagato ASC";
      dtPagamentiFatti = new DataTable("PagamentiFatti");
      dtPagamentiFatti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
     
	  strHtml="<html><head><style>*{font-size:14px;font-family: 'Google Sans', Roboto;} h1{font-size:26px;font-weight:700;padding:0;margin:0;} h2{font-size:18px;font-weight:700;padding:0;margin:0;} table{border-collapse: collapse;}</style></head><body>";
	  
    //pagamenti
    strHtml+="<h2 style=\"color:green;margin:5px 0;\">Pagamenti anno " + intYear + "</h2>";
	  strHtml+="<table border=\"1\" cellpadding=\"4\" cellspacing=\"5\" style=\"font-size:12px\">";
	  strHtml+="<tr><td align=\"center\">Anno</td><td align=\"center\">Mese</td><td align=\"center\" width=\"140\">Pagamenti ricevuti &euro;</td><td align=\"center\" width=\"140\">Pagamenti fatti &euro;</td></tr>";
	  decTotRicevutiPrecedenti=0;
      for (int j = 0; j < dtPagamentiRicevutiPrecedenti.Rows.Count; j++){
	    strHtml+="<tr>";
	    	strHtml+="<td>" + dtPagamentiRicevutiPrecedenti.Rows[j]["anno"].ToString() + "</td>";
	    	strHtml+="<td>" + GetMese(dtPagamentiRicevutiPrecedenti.Rows[j]["mese"].ToString()) + "</td>";
	    	strHtml+="<td align=\"right\"><b>&euro;&nbsp;" + ((decimal)dtPagamentiRicevutiPrecedenti.Rows[j]["Pagamenti_Importo"]).ToString("N2", ci) + "</b></td>";
	    	strHtml+="<td align=\"right\"><b>&euro;&nbsp;" + ((decimal)dtPagamentiFattiPrecedenti.Rows[j]["Pagamenti_Importo"]).ToString("N2", ci) + "</b></td>";
	    strHtml+="</tr>";
		  decTotRicevutiPrecedenti+=Convert.ToDecimal(dtPagamentiRicevutiPrecedenti.Rows[j]["Pagamenti_Importo"]);
		  decTotFattiPrecedenti+=Convert.ToDecimal(dtPagamentiFattiPrecedenti.Rows[j]["Pagamenti_Importo"]);
      }
	    strHtml+="<tr>";
	    strHtml+="<td align=\"right\" colspan=\"2\"><b style=\"margin-right:10px\">Totale</b></td>";
	    strHtml+="<td align=\"right\" style=\"background-color:green;color:white\"><b>&euro;&nbsp;" + decTotRicevutiPrecedenti.ToString("N2", ci) + "</b></td>";
	    strHtml+="<td align=\"right\" style=\"background-color:red;color:white\"><b>&euro;&nbsp;" + decTotFattiPrecedenti.ToString("N2", ci) + "</b></td>";
  	  strHtml+="</tr>";
  	  strHtml+="</table><br><br>";
    
      //pagamenti ricevuti
  	  strHtml+="<h2 style=\"color:green;margin:5px 0;\">Dettaglio pagamenti ricevuti per il mese " + GetMese(intMonth.ToString()) + " anno " + intYear + "</h2>";
  	  strHtml+="<table border=\"1\" cellpadding=\"4\" cellspacing=\"5\" style=\"font-size:12px\">";
  	  strHtml+="<tr><td align=\"center\">Codice</td><td align=\"left\">Anagrafica</td><td align=\"center\">Riferimenti</td><td align=\"center\" width=\"80\">Importo &euro;</td><td align=\"center\">Scadenza</td><td align=\"center\">Pagato il</td><td align=\"center\">Ritardo</td><td align=\"center\">Promemoria</td></tr>";
  	  decTotRicevuti=0;
        for (int j = 0; j < dtPagamentiRicevuti.Rows.Count; j++){
  	    strHtml+="<tr>";
  	    	strHtml+="<td>" + dtPagamentiRicevuti.Rows[j]["Pagamenti_Ky"].ToString() + "</td>";
  	    	strHtml+="<td><div style=\"max-width:120px;max-height:20px;overflow:hidden;\">" + dtPagamentiRicevuti.Rows[j]["Anagrafiche_RagioneSociale"].ToString() + "</div></td>";
  	    	strHtml+="<td><div style=\"max-width:200px;max-height:20px;overflow:hidden;\">" + dtPagamentiRicevuti.Rows[j]["Pagamenti_Riferimenti"].ToString() + "</div></td>";
  	    	strHtml+="<td align=\"right\"><b>&euro;&nbsp;" + ((decimal)dtPagamentiRicevuti.Rows[j]["Pagamenti_Importo"]).ToString("N2", ci) + "</b></td>";
  	    	strHtml+="<td>" + dtPagamentiRicevuti.Rows[j]["Pagamenti_Data_IT"].ToString() + "</td>";
  	    	strHtml+="<td><b>" + dtPagamentiRicevuti.Rows[j]["Pagamenti_DataPagato_IT"].ToString() + "</b></td>";
  	    	strHtml+="<td align=\"right\"><b>" + dtPagamentiRicevuti.Rows[j]["ggRitardoDaScadenza"].ToString() + "</b></td>";
  	    	strHtml+="<td align=\"right\"><b>" + dtPagamentiRicevuti.Rows[j]["Pagamenti_NumeroPromemoria"].ToString() + "</b></td>";
  	    strHtml+="</tr>";
  		  decTotRicevuti+=Convert.ToDecimal(dtPagamentiRicevuti.Rows[j]["Pagamenti_Importo"]);
        }
  	    strHtml+="<tr>";
  	    strHtml+="<td colspan=\"3\" align=\"right\"><b style=\"margin-right:10px\">Totale</b></td>";
  	    strHtml+="<td align=\"right\" style=\"background-color:green;color:white\"><b>&euro;&nbsp;" + decTotRicevuti.ToString("N2", ci) + "</b></td>";
  	    strHtml+="<td colspan=\"4\"></td>";
  	  strHtml+="</tr>";
  	  strHtml+="</table><br><br>";
      
      //pagamenti fatti
  	  strHtml+="<h2 style=\"color:green;margin:5px 0;\">Dettaglio pagamenti fatti per il mese " + GetMese(intMonth.ToString()) + " anno " + intYear + "</h2>";
  	  strHtml+="<table border=\"1\" cellpadding=\"4\" cellspacing=\"5\" style=\"font-size:12px\">";
  	  strHtml+="<tr><td align=\"center\">Codice</td><td align=\"left\">Anagrafica</td><td align=\"center\">Riferimenti</td><td align=\"center\" width=\"80\">Importo &euro;</td><td align=\"center\">Scadenza</td><td align=\"center\">Pagato il</td><td align=\"center\">Ritardo</td><td align=\"center\">Promemoria</td></tr>";
  	  decTotFatti=0;
        for (int j = 0; j < dtPagamentiFatti.Rows.Count; j++){
  	    strHtml+="<tr>";
  	    	strHtml+="<td>" + dtPagamentiFatti.Rows[j]["Pagamenti_Ky"].ToString() + "</td>";
  	    	strHtml+="<td><div style=\"max-width:120px;max-height:20px;overflow:hidden;\">" + dtPagamentiFatti.Rows[j]["Anagrafiche_RagioneSociale"].ToString() + "</div></td>";
  	    	strHtml+="<td><div style=\"max-width:200px;max-height:20px;overflow:hidden;\">" + dtPagamentiFatti.Rows[j]["Pagamenti_Riferimenti"].ToString() + "</div></td>";
  	    	strHtml+="<td align=\"right\"><b>&euro;&nbsp;" + ((decimal)dtPagamentiFatti.Rows[j]["Pagamenti_Importo"]).ToString("N2", ci) + "</b></td>";
  	    	strHtml+="<td>" + dtPagamentiFatti.Rows[j]["Pagamenti_Data_IT"].ToString() + "</td>";
  	    	strHtml+="<td><b>" + dtPagamentiFatti.Rows[j]["Pagamenti_DataPagato_IT"].ToString() + "</b></td>";
  	    	strHtml+="<td align=\"right\"><b>" + dtPagamentiFatti.Rows[j]["ggRitardoDaScadenza"].ToString() + "</b></td>";
  	    	strHtml+="<td align=\"right\"><b>" + dtPagamentiFatti.Rows[j]["Pagamenti_NumeroPromemoria"].ToString() + "</b></td>";
  	    strHtml+="</tr>";
  		  decTotFatti+=Convert.ToDecimal(dtPagamentiFatti.Rows[j]["Pagamenti_Importo"]);
        }
  	    strHtml+="<tr>";
  	    strHtml+="<td colspan=\"3\" align=\"right\"><b style=\"margin-right:10px\">Totale</b></td>";
  	    strHtml+="<td align=\"right\" style=\"background-color:green;color:white\"><b>&euro;&nbsp;" + decTotFatti.ToString("N2", ci) + "</b></td>";
  	    strHtml+="<td colspan=\"4\"></td>";
  	  strHtml+="</tr>";
  	  strHtml+="</table><hr>";
  	  //Response.Write(strHtml);
  	  Response.Write("ok");
      sendEmailAmministrazione(strHtml);

    }    
    
    public Boolean sendEmailAmministrazione(string strBody){
        string strFROM="";
        string strTO="";
        string strServerSMTP="";
        string strServerSMTPUser="";
        string strServerSMTPPassword="";
        string strServerSMTPPorta="";
        string strServerSMTPSSL="";
        string strEmailAnagrafica="";
        string strHtml = "";
        DataTable dtCoreModulesOptionsValue;
        
        strWHERENet="CoreModulesOptions_Code='core.serversmpt'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTP=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptuser'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPUser=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptpassword'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPPassword=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptport'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPPorta=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptssl'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPSSL=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            

        strWHERENet="CoreModulesOptions_Code='pagamenti.from'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strFROM=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }
        
        strWHERENet="CoreModulesOptions_Code='pagamenti.emailreport'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strTO=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }
      
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
    		mail.From = new System.Net.Mail.MailAddress(strFROM);
        mail.To.Add(new System.Net.Mail.MailAddress(strTO));
        mail.Subject = "[GESTIONALE] Pagamenti ricevuti mese " + GetMese(intMonth.ToString()) + "/" + intYear;
        mail.Body = strBody;
        mail.IsBodyHtml = true;
    		System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(strServerSMTP, Convert.ToInt32(strServerSMTPPorta));
    		System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(strServerSMTPUser, strServerSMTPPassword);
        client.UseDefaultCredentials = false;
        client.Credentials = mailAuthentication;
    		client.EnableSsl = Convert.ToBoolean(strServerSMTPSSL);
        client.Send(mail);
        /*
        Response.Write("<br>From:" + strFROM + "<br>");
        Response.Write("To:" + strTO + "<br>");
        Response.Write("SMTP:" + strServerSMTP + "<br>");
        Response.Write("porta:" + strServerSMTPPorta + "<br>");
        Response.Write("username:" + strServerSMTPUser + "<br>");
        Response.Write("password:" + strServerSMTPPassword + "<br>");
        Response.Write("ssl:" + strServerSMTPSSL + "<hr>");
        */
        return true;
    }
    
}
