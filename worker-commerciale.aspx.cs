using System;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public DataTable dtAzienda;
    public DataTable dtLead;
    public DataTable dtLeadCategorie;
    public DataTable dtConteggioLead;
    public DataTable dtConteggioLeadSubtabella;
    public DataTable dtConteggioLeadutmcampaign;
    public DateTime dt;
    public int intYear;
    public int intMonth;
    public int intDay;
    public int intGiorni=0;
    public int intNumLead=0;
    public int intNumLeadGiorno=0;
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public string strHTML = "";
    protected void Page_Load(object sender, EventArgs e){

    strWHERENet="Aziende_Ky=1";
    strORDERNet = "Aziende_Ky";
    strFROMNet = "Aziende_Vw";
    dtAzienda = new DataTable("Azienda");
    dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

      dt = DateTime.Now;
      intYear=dt.Year;
      intMonth=dt.Month;
      intDay=dt.Day;
      intGiorni=DateTime.DaysInMonth(intYear,intMonth);
  
      strHTML +="<HTML lang=\"it\">";
      strHTML +="<head>";
      strHTML +="<meta http-equiv=\"Content-Type\" content=\"text/HTML; charset=iso-8859-1\">";
      strHTML +="<meta http-equiv=\"content-language\" content=\"it\" />";
      strHTML +="<link href=\"https://fonts.googleapis.com/css?family=Roboto\" rel=\"stylesheet\" type=\"text/css\">";
      strHTML +="<title>Andamento lead</title>";
      strHTML +="<style>";
      strHTML +="@import url('https://fonts.googleapis.com/css?family=Roboto&display=swap');";
      strHTML +="*{font-family:\"Roboto\";}";
      strHTML +="body, table, tr, td, th{font-size:11px;}";
      strHTML +="th{background-color:#f8f8f8;color:#0a0a0a;}";
      strHTML +="td.totale{background-color:#f8f8f8;color:#0a0a0a;font-weight:700;}";
      strHTML +="</style>";
      strHTML +="</head>";
      strHTML +="<body style=\"font-family:'Roboto';font-size:12px;font-weight:400;color:#000000\">";
      strHTML +="<h1>Lead aggiornati al " + dt.ToString() + "</h1>";
      strWHERENet="";
      strFROMNet = "LeadCategorie";
      strORDERNet = "LeadCategorie_Ordine";
      dtLeadCategorie = new DataTable("LeadCategorie");
      dtLeadCategorie = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadCategorie_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
      
      strHTML+="<h2>Andamento Lead Mese " + GetMese(intMonth) + " " + intYear + "</h2>";
      strHTML+="<table border=\"0\" cellpadding=\"5\" cellspacing=\"0\" style=\"border:1px solid #ededed\" id=\"andamentoleadmese\">";
      strHTML+="<thead><tr><th></th>";
        for (int i = 0; i < dtLeadCategorie.Rows.Count; i++){
          strHTML+="<th>" + dtLeadCategorie.Rows[i]["LeadCategorie_Titolo"].ToString() + "</th>";
        }
        strHTML+="<th></th>";
        strHTML+="<th>Totale</th><th></th>";
        strHTML+="</tr></thead>";
        strHTML+="<tbody>";
        for (int j = intDay; j>0; j--){
          intNumLeadGiorno=0;
          DateTime dateValue = new DateTime(intYear, intMonth, j );
          strHTML+="<tr><th align=\"right\">" + dateValue.ToString("dddd") + " " + j + "</th>";
          for (int i = 0; i < dtLeadCategorie.Rows.Count; i++){
            strWHERENet="LeadCategorie_Ky=" + dtLeadCategorie.Rows[i]["LeadCategorie_Ky"].ToString() + " AND YEAR(Lead_Data)=" + intYear + " AND MONTH(Lead_Data)=" + intMonth + " AND DAY(Lead_Data)=" + j;
            strFROMNet = "Lead";
            strORDERNet = "Lead_Ky DESC";
            dtConteggioLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            intNumLead=intNumLead+intNumRecords;         
            strHTML+="<td align=\"right\">" + intNumRecords + "</td>";
            intNumLeadGiorno=intNumLeadGiorno+intNumRecords;
          }
          //categoria nulla
            strWHERENet="LeadCategorie_Ky Is Null AND YEAR(Lead_Data)=" + intYear + " AND MONTH(Lead_Data)=" + intMonth + " AND DAY(Lead_Data)=" + j;
            strFROMNet = "Lead";
            strORDERNet = "Lead_Ky DESC";
            dtConteggioLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            intNumLead=intNumLead+intNumRecords;         
            strHTML+="<td align=\"right\">" + intNumRecords + "</td>";
            intNumLeadGiorno=intNumLeadGiorno+intNumRecords;

          strHTML+="<th>" + intNumLeadGiorno + "</th>";
          strHTML+="<td align=\"right\"><a href=\"https://" + Request.Url.Host + "/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&Year(Lead_Data)=" + intYear + "&Month(Lead_Data)=" + intMonth + "&Day(Lead_Data)=" + j + "\" target=\"blank\">Vedi lead</a></td>";
          strHTML+="</tr>";
        }
        strHTML+="</tbody>";
        strHTML+="</table>";
      
        
        strHTML+="<h2>Andamento utm_campaign " + GetMese(intMonth) + " " + intYear + "</h2>";
        strHTML+="<table border=\"0\" cellpadding=\"5\" cellspacing=\"0\" style=\"border:1px solid #ededed\" id=\"andamentoleadutmcampaign\">";
        strHTML+="<thead><tr><th>utm_campaign</th><th>Categoria</th><th>Numero Lead</th><th></th></tr></thead>";
        strHTML+="<tbody>";
        strWHERENet="Anno=" + intYear + " AND mese=" + intMonth;
        strFROMNet = "Lead_Prospetto_Campagne_Vw";
        strORDERNet = "Conteggio DESC, Campagne_Titolo";
        dtConteggioLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
        for (int i = 0; i < dtConteggioLead.Rows.Count; i++){
          strHTML+="<tr>";
          strHTML+="<td align=\"left\"><strong>" + dtConteggioLead.Rows[i]["Campagne_Titolo"].ToString() + "</strong></td>";
          strHTML+="<td>" + dtConteggioLead.Rows[i]["LeadCategorie_Titolo"].ToString() + "</td>";
          strHTML+="<td align=\"right\">" + dtConteggioLead.Rows[i]["Conteggio"].ToString() + "</td>";
          strHTML+="<td align=\"right\"><a href=\"https://" + Request.Url.Host + "/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&Campagne_Ky=" + dtConteggioLead.Rows[i]["Campagne_Ky"].ToString() + "&Year(Lead_Data)=" + intYear + "&Month(Lead_Data)=" + intMonth + "\" target=\"blank\">Vedi lead</a></td>";
          strHTML+="</tr>";
        }
        strHTML+="</tbody>";
        strHTML+="</table>";
        
        strHTML+="<h2>Andamento utm_campaign utm_medium utm_source " + GetMese(intMonth) + " " + intYear + "</h2>";
        strHTML+="<table border=\"0\" cellpadding=\"5\" cellspacing=\"0\" style=\"border:1px solid #ededed\" id=\"andamentoleadutmcampaign\">";
        strHTML+="<thead><tr><th width=\"200\">utm_campaign</th><th width=\"200\">utm_medium</th><th width=\"200\">utm_source</th><th>N&deg; Lead</th></tr></thead>";
        strHTML+="<tbody>";
        strWHERENet="utm_campaign Is Not Null AND LEN(utm_campaign)>0 AND Anno=" + intYear + " AND mese=" + intMonth;
        strFROMNet = "Lead_Prospetto_utmsource_utmmedium_utmcampaign_Vw";
        strORDERNet = "utm_campaign, Conteggio";
        dtConteggioLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
        for (int i = 0; i < dtConteggioLead.Rows.Count; i++){
          strHTML+="<tr>";
          strHTML+="<td width=\"300\" align=\"left\"><a href=\"https://" + Request.Url.Host + "/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&utm_campaign=" + dtConteggioLead.Rows[i]["utm_campaign"].ToString() + "&Year(Lead_Data)=" + intYear + "&Month(Lead_Data)=" + intMonth + "\" target=\"blank\">" + dtConteggioLead.Rows[i]["utm_campaign"].ToString() + "</a></td>";
          strHTML+="<td>" + dtConteggioLead.Rows[i]["utm_medium"].ToString() + "</td>";
          strHTML+="<td>" + dtConteggioLead.Rows[i]["utm_source"].ToString() + "</td>";
          strHTML+="<th align=\"right\">" + dtConteggioLead.Rows[i]["Conteggio"].ToString() + "</th>";
          strHTML+="</tr>";
        }
        strHTML+="</tbody>";
        strHTML+="</table>";
        
        strHTML+="<h2>Andamento utm_source " + GetMese(intMonth) + " " + intYear + "</h2>";
        strHTML+="<table border=\"0\" cellpadding=\"5\" cellspacing=\"0\" style=\"border:1px solid #ededed\" id=\"andamentoleadutmsource\">";
        strHTML+="<thead><tr><th width=\"200\">utm_source</th><th width=\"120\">utm_medium</th><th width=\"250\">utm_campaign</th><th>N&deg; Lead utmcampaign</th><th>N&deg; Lead utmmedium</th><th>N&deg; Lead utmsource</th></tr></thead>";
        strHTML+="<tbody>";
        strWHERENet="Anno=" + intYear + " AND mese=" + intMonth + " AND utm_source Is Not Null";
        strFROMNet = "Lead_Prospetto_Utm_source_Vw";
        strORDERNet = "Conteggio";
        dtConteggioLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
        for (int i = 0; i < dtConteggioLead.Rows.Count; i++){
          strHTML+="<tr border=\"1\" style=\"border-top:2px solid #000000\">";
          strHTML+="<td border=\"1\" width=\"200\" style=\"border-top:2px solid #000000\"><a href=\"https://" + Request.Url.Host + "/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&utm_source=" + dtConteggioLead.Rows[i]["utm_source"].ToString() + "&Year(Lead_Data)=" + intYear + "&Month(Lead_Data)=" + intMonth + "\" target=\"blank\">" + dtConteggioLead.Rows[i]["utm_source"].ToString() + "</a></td>";
          strHTML+="<td border=\"1\" style=\"border-top:2px solid #000000\"></td>";
          strHTML+="<td border=\"1\" style=\"border-top:2px solid #000000\"></td>";
          strHTML+="<td border=\"1\" style=\"border-top:2px solid #000000\"></td>";
          strHTML+="<td border=\"1\" style=\"border-top:2px solid #000000\"></td>";
          strHTML+="<th border=\"1\" align=\"right\" style=\"border-top:2px solid #000000\">" + dtConteggioLead.Rows[i]["Conteggio"].ToString() + "</th>";
          strHTML+="</tr>";
          
          strWHERENet="Anno=" + intYear + " AND mese=" + intMonth + " AND utm_source='" + dtConteggioLead.Rows[i]["utm_source"].ToString() + "'";
          strFROMNet = "Lead_Prospetto_utmsource_utmmedium_Vw";
          strORDERNet = "Conteggio";
          dtConteggioLeadSubtabella = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
          for (int j = 0; j < dtConteggioLeadSubtabella.Rows.Count; j++){
            strHTML+="<tr>";
            strHTML+="<td width=\"200\"><a href=\"https://" + Request.Url.Host + "/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&utm_source=" + dtConteggioLead.Rows[i]["utm_source"].ToString() + "&Year(Lead_Data)=" + intYear + "&Month(Lead_Data)=" + intMonth + "\" target=\"blank\">" + dtConteggioLead.Rows[i]["utm_source"].ToString() + "</a></td>";
            strHTML+="<td width=\"200\"><a href=\"https://" + Request.Url.Host + "/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&utm_source=" + dtConteggioLeadSubtabella.Rows[j]["utm_source"].ToString() + "&Year(Lead_Data)=" + intYear + "&Month(Lead_Data)=" + intMonth + "\" target=\"blank\">" + dtConteggioLeadSubtabella.Rows[j]["utm_medium"].ToString() + "</a></td>";
            strHTML+="<td></td>";
            strHTML+="<td></td>";
            strHTML+="<th align=\"right\">" + dtConteggioLeadSubtabella.Rows[j]["Conteggio"].ToString() + "</th>";
            strHTML+="<td></td>";
            strHTML+="</tr>";
            
            strWHERENet="Anno=" + intYear + " AND mese=" + intMonth + " AND utm_source='" + dtConteggioLead.Rows[i]["utm_source"].ToString() + "' AND utm_medium='" + dtConteggioLeadSubtabella.Rows[j]["utm_medium"].ToString() + "'";
            strFROMNet = "Lead_Prospetto_utmmedium_utmcampaign_Vw";
            strORDERNet = "Conteggio";
            dtConteggioLeadutmcampaign = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
            for (int x = 0; x < dtConteggioLeadutmcampaign.Rows.Count; x++){
              strHTML+="<tr>";
              strHTML+="<td width=\"200\"><a href=\"https://" + Request.Url.Host + "/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&utm_source=" + dtConteggioLead.Rows[i]["utm_source"].ToString() + "&Year(Lead_Data)=" + intYear + "&Month(Lead_Data)=" + intMonth + "\" target=\"blank\">" + dtConteggioLead.Rows[i]["utm_source"].ToString() + "</a></td>";
              strHTML+="<td width=\"200\"><a href=\"https://" + Request.Url.Host + "/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&utm_source=" + dtConteggioLeadSubtabella.Rows[j]["utm_source"].ToString() + "&Year(Lead_Data)=" + intYear + "&Month(Lead_Data)=" + intMonth + "\" target=\"blank\">" + dtConteggioLeadSubtabella.Rows[j]["utm_medium"].ToString() + "</a></td>";
              strHTML+="<td width=\"200\"><a href=\"https://" + Request.Url.Host + "/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&utm_campaign=" + dtConteggioLeadutmcampaign.Rows[x]["utm_campaign"].ToString() + "&Year(Lead_Data)=" + intYear + "&Month(Lead_Data)=" + intMonth + "\" target=\"blank\">" + dtConteggioLeadutmcampaign.Rows[x]["utm_campaign"].ToString() + "</a></td>";
              strHTML+="<th align=\"right\">" + dtConteggioLeadutmcampaign.Rows[x]["Conteggio"].ToString() + "</th>";
              strHTML+="<td></td>";
              strHTML+="<td></td>";
              strHTML+="</tr>";
            }
          }
        }
        strHTML+="</tbody>";
        strHTML+="</table>";
        
        
        strHTML+="<h2>Andamento Lead Anno " + intYear + "</h2>";
        strHTML+="<table border=\"0\" cellpadding=\"5\" cellspacing=\"0\" style=\"border:1px solid #ededed\" id=\"andamentoleadanno\">";
        strHTML+="<thead><tr><th></th>";
        for (int j = 1; j <= 12; j++){
          strHTML+="<th>" + GetMese(j) + " <br><span style=\"color:green\">" + intYear + "</span> / <span style=\"color:red\">" + (intYear-1).ToString() + "</span></th>";
        }
        strHTML+="</tr></thead>";

        for (int i = 0; i < dtLeadCategorie.Rows.Count; i++){
          strHTML+="<tr><th>" + dtLeadCategorie.Rows[i]["LeadCategorie_Titolo"].ToString() + "</th>";
          for (int j = 1; j < 13; j++){
            strWHERENet="LeadCategorie_Ky=" + dtLeadCategorie.Rows[i]["LeadCategorie_Ky"].ToString() + " AND YEAR(Lead_Data)=" + intYear + " AND MONTH(Lead_Data)=" + j;
            strFROMNet = "Lead";
            strORDERNet = "Lead_Ky DESC";
            dtConteggioLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
            strHTML+="<td align=\"right\"><span style=\"color:green\">" + intNumRecords + "</span>";
            strWHERENet="LeadCategorie_Ky=" + dtLeadCategorie.Rows[i]["LeadCategorie_Ky"].ToString() + " AND YEAR(Lead_Data)=" + (intYear-1) + " AND MONTH(Lead_Data)=" + j;
            strFROMNet = "Lead";
            strORDERNet = "Lead_Ky DESC";
            dtConteggioLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
            strHTML+=" / <span style=\"color:red\">" + intNumRecords + "</span></td>";
          }
          strHTML+="</tr>";
        }
        //categoria null
          strHTML+="<tr><th></th>";
          for (int j = 1; j < 13; j++){
            strWHERENet="(LeadCategorie_Ky Is Null Or LeadCategorie_Ky='') AND YEAR(Lead_Data)=" + intYear + " AND MONTH(Lead_Data)=" + j;
            strFROMNet = "Lead";
            strORDERNet = "Lead_Ky DESC";
            dtConteggioLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
            strHTML+="<td align=\"right\"><span style=\"color:green\">" + intNumRecords + "</span>";
            strWHERENet="(LeadCategorie_Ky Is Null Or LeadCategorie_Ky='') AND YEAR(Lead_Data)=" + (intYear-1) + " AND MONTH(Lead_Data)=" + j;
            strFROMNet = "Lead";
            strORDERNet = "Lead_Ky DESC";
            dtConteggioLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
            strHTML+=" / <span style=\"color:red\">" + intNumRecords + "</span></td>";
          }
          strHTML+="</tr>";
        strHTML+="</tbody>";
        strHTML+="</table>";
      strHTML +="</body>";
      strHTML +="</HTML>";
      //Response.Write(strHTML);
      Response.Write("ok");
      sendEmailCommerciale(strHTML);
      
    }    

    public Boolean sendEmailCommerciale(string strBody){
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

        strWHERENet="CoreModulesOptions_Code='commerciale.emailreportlead'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strFROM=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }
        
        strWHERENet="CoreModulesOptions_Code='commerciale.emailreportlead'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strTO=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }
      
    		System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
    		mail.From = new System.Net.Mail.MailAddress(strFROM);
    		string[] strTOs = strTO.Split(',');
        foreach (var strDestinatario in strTOs){
           //Response.Write("<hr>" + strDestinatario + "<br>");
           mail.To.Add(new System.Net.Mail.MailAddress(strDestinatario));
        }
        
    		mail.Subject = "[" + dtAzienda.Rows[0]["Aziende_Codice"].ToString().ToUpper() + "] Lead aggiornati al " + dt.ToString();
    		mail.Body = strHTML;
    		mail.IsBodyHtml = true;
    		System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(strServerSMTP, Convert.ToInt32(strServerSMTPPorta));
    		System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(strServerSMTPUser, strServerSMTPPassword);
    		client.UseDefaultCredentials = false;
    		client.Credentials = mailAuthentication;
    		client.EnableSsl = Convert.ToBoolean(strServerSMTPSSL);
    		client.Send(mail);

        Response.Write(strHTML);
        Response.Write("<br>From:" + strFROM + "<br>");
        Response.Write("To:" + strTO + "<br>");
        Response.Write("SMTP:" + strServerSMTP + "<br>");
        Response.Write("porta:" + strServerSMTPPorta + "<br>");
        Response.Write("username:" + strServerSMTPUser + "<br>");
        Response.Write("password:" + strServerSMTPPassword + "<br>");
        Response.Write("ssl:" + strServerSMTPSSL + "<hr>");

        return true;
    }

    public String GetMese(int intMeseIn){
      string strMeseOut="";
      if (intMeseIn!=null){
        switch (intMeseIn){
          case 1:
            strMeseOut="gennaio";
            break;
          case 2:
            strMeseOut="febbraio";
            break;
          case 3:
            strMeseOut="marzo";
            break;
          case 4:
            strMeseOut="aprile";
            break;
          case 5:
            strMeseOut="maggio";
            break;
          case 6:
            strMeseOut="giugno";
            break;
          case 7:
            strMeseOut="luglio";
            break;
          case 8:
            strMeseOut="agosto";
            break;
          case 9:
            strMeseOut="settembre";
            break;
          case 10:
            strMeseOut="ottobre";
            break;
          case 11:
            strMeseOut="novembre";
            break;
          case 12:
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
