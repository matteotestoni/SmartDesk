using System;
using System.Data;
using System.Data.SqlClient;
using Google.Apis.PagespeedInsights.v5;
using Google.Apis.Services;
using HtmlAgilityPack;

public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public DataTable dtSitiWeb;
    public DataTable dtVecchiaVersione;
    public DataTable dtAnagrafiche;
    public DataTable dtTemp;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public string strHtml = "";
    public string strLog="";
    public string strApiKey;
    public DateTime dt;

    protected void Page_Load(object sender, EventArgs e){
  	string strWHERENet="";
  	string strUrl="";
  	string strDominio="";
  	string strValue="";
    string strScoreDesktop="";
    float floatScoreDesktop = -1;
    string strScoreMobile = "";
    float floatScoreMobile = -1;

	  strWHERENet = "(SitiWeb_DataWorker Is Null OR SitiWeb_DataWorker<GETDATE()-1)";
	  //strWHERENet = "(SitiWeb_Ky=4750)";
      dtSitiWeb = new DataTable("SitiWeb");
      dtSitiWeb = Smartdesk.Sql.getTablePage("SitiWeb", null, "SitiWeb_Ky", strWHERENet, "SitiWeb_Url", 1,500,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      strLog=dtSitiWeb.Rows.Count.ToString();
      Google.Apis.PagespeedInsights.v5.PagespeedInsightsService service = new Google.Apis.PagespeedInsights.v5.PagespeedInsightsService(new BaseClientService.Initializer
      {
        ApplicationName = "app.rswstudio.it",
        ApiKey = "AIzaSyAES_hH89T1by4uvK9_fJaAZ2aKvsDkJ2I",
      });
      strLog ="<table border=\"1\">";
      strLog += "<tr><th>Sito</th><th>Page Speed Desktop</th><th>Page Speed Mobile</th><th>Generator</th><th>IP</th></tr>";
      dt = DateTime.Now;
	  for (int i = 0; i < dtSitiWeb.Rows.Count; i++){
        strLog += "<tr>";
        strDominio = dtSitiWeb.Rows[i]["SitiWeb_Dominio"].ToString();
        strUrl=dtSitiWeb.Rows[i]["SitiWeb_Url"].ToString();
        strLog += "<td>" + strUrl + "</td>";
        //page speed
        try
        {
          Google.Apis.PagespeedInsights.v5.PagespeedapiResource.RunpagespeedRequest request = service.Pagespeedapi.Runpagespeed(strUrl);
          request.Strategy = Google.Apis.PagespeedInsights.v5.PagespeedapiResource.RunpagespeedRequest.StrategyEnum.DESKTOP;
          try{
            Google.Apis.PagespeedInsights.v5.Data.PagespeedApiPagespeedResponseV5 resultDesktop = request.Execute();
            if (resultDesktop!=null){
                try {
                  floatScoreDesktop = float.Parse(resultDesktop.LighthouseResult.Categories.Performance.Score.ToString())*100;
                  strScoreDesktop = floatScoreDesktop.ToString();
                }
                catch { strScoreDesktop = "-1"; }
              }
            else
            {
                strScoreDesktop = "-1";
            }
            strLog += "<td>" + strScoreDesktop + "</td>";
          }catch(Exception ex){
            strLog += "<td colspan=\"2\">Page Speed Desktop:errore" + ex.ToString() + "</td>";
  		  }

          request.Strategy = Google.Apis.PagespeedInsights.v5.PagespeedapiResource.RunpagespeedRequest.StrategyEnum.MOBILE;
          try{
            Google.Apis.PagespeedInsights.v5.Data.PagespeedApiPagespeedResponseV5 resultMobile = request.Execute();
            if (resultMobile!=null){
                try {
                  floatScoreMobile = float.Parse(resultMobile.LighthouseResult.Categories.Performance.Score.ToString())*100;
                  strScoreMobile = floatScoreMobile.ToString();
                }
                catch { strScoreMobile = "-1"; }
              }
            else
            {
                strScoreMobile = "-1";
            }
            strLog += "<td>" + strScoreMobile + "</td>";
          }catch(Exception ex){
            strLog += "<td colspan=\"2\">Page Speed Desktop:errore" + ex.ToString() + "</td>";
  		  }

            if (strScoreDesktop != "-1") {
              aggiornaScore(strScoreDesktop,strScoreMobile,dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString(),strUrl);
		    }
              
              
              
        }catch(Exception ex){
  		  strLog+= "<td>Page Speed Desktop: " + ex.ToString() + "</td>";
            Response.Write(ex.ToString());
  	      //aggiornaScore("-1","-1",dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString(),strUrl);
  	    }
			
      //generator
      try{
      	HtmlWeb webGet = new HtmlWeb();
        HtmlDocument document = webGet.Load(strUrl);
        strValue = document.DocumentNode.SelectNodes("//meta[@name='generator']")[0].GetAttributeValue("content", String.Empty);
        strLog+="<td>" + strValue + "</td>";
      	aggiornaVersione(strValue,dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString(),strUrl);
      }catch{
        strLog+= "<td>errore</td>";
        aggiornaVersione("n/a",dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString(),strUrl);
      }
      
      //IP
      try{
        System.Net.IPAddress[] ip = System.Net.Dns.GetHostAddresses(strDominio);
        strValue=ip[0].ToString();
        strLog+= "<td>" + strValue + "</td>";
        aggiornaIP(strValue,dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString(),strUrl);
      }catch(Exception ex){
        strLog+= "<td>" + ex.ToString() + "</td>";
      }
      aggiornaDataWorker(dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString());
        strLog += "</tr>";
      }
      strLog += "</table>";
      Response.Write(strLog);
		System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
		mail.From = new System.Net.Mail.MailAddress("info@rswstudio.it");
		mail.To.Add(new System.Net.Mail.MailAddress("realizzazionesitiweb20@gmail.com"));
		mail.Subject = "[GESTIONALE] Dati siti aggiornati " + dt.ToString();
		mail.Body = strLog;
		mail.IsBodyHtml = true;
		System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(Smartdesk.Functions.getOption("core.serversmpt"),Smartdesk.Functions.getOption("core.serversmptport"));
		System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(Smartdesk.Functions.getOption("core.serversmptuser"), Smartdesk.Functions.getOption("core.serversmptpassword"));
		client.UseDefaultCredentials = false;
		client.Credentials = mailAuthentication;
		client.EnableSsl = Smartdesk.Functions.getOption("core.serversmptssl");
		//client.Send(mail);
    }    

	public bool aggiornaDataWorker(string strSitiWeb_Ky)
    {
        string strSQL="";
        bool output = false;
	    strSQL = "UPDATE SitiWeb SET SitiWeb_DataWorker=GETDATE() WHERE SitiWeb_Ky = " + strSitiWeb_Ky;
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output = true;
        return output;
    }
	
	public bool aggiornaIP(string strIP, string strSitiWeb_Ky, string strSitiWeb_Url)
    {
        string strWHERENet = "";
        string strORDERNet = "";
        string strFROMNet = "";
        string strSQL="";
        string strCountry="";
        bool output = false;
        string strOldScore = "";

        strWHERENet = "SitiWeb_Ky=" + strSitiWeb_Ky;
        strFROMNet = "SitiWeb";
        strORDERNet = "SitiWeb_Ky";
        dtTemp = new DataTable("SitiWeb");
        dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWeb_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		if (dtTemp.Rows.Count>0){
			strOldScore=dtTemp.Rows[0]["SitiWeb_IP"].ToString();
		}
		if (strOldScore != strIP){
            //rilevo nazione
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable("getTable");
            SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            IPLite ip = new IPLite(cmd, strIP);
	        strCountry=ip.REMOTE_ADDR.CountryCode;
            //WriteInfo(ip.REMOTE_ADDR);
            strSQL = "UPDATE SitiWeb SET SitiWeb_IP='" + strIP + "', SitiWeb_IPCountry='" + strCountry + "' WHERE SitiWeb_Ky = " + strSitiWeb_Ky;
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
			strSQL = "INSERT INTO SitiWebLog (SitiWeb_Url,SitiWebLog_Data,SitiWebLog_UserInsert,SitiWebLog_DateInsert,SitiWebLog_Descrizione,SitiWebLog_Valore,SitiWeb_Ky) VALUES ('" + strSitiWeb_Url + "',GETDATE(),0,GETDATE(),'Rilvevamento IP' ,'" + strIP + "'," + strSitiWeb_Ky + ")";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        }
		return output;
    }

    public bool aggiornaScore(string strPageSpeedScoreDesktop,string strPageSpeedScoreMobile, string strSitiWeb_Ky, string strSitiWeb_Url)
    {
        string strWHERENet = "";
        string strORDERNet = "";
        string strFROMNet = "";
        string strSQL = "";
        bool output = false;
        strSQL = "UPDATE SitiWeb SET SitiWeb_PageSpeedData=GETDATE(), SitiWeb_PageSpeedScore='" + strPageSpeedScoreDesktop + "', SitiWeb_PageSpeedScoreMobile='" + strPageSpeedScoreMobile + "' WHERE SitiWeb_Ky = " + strSitiWeb_Ky;
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL = "INSERT INTO SitiWebPageSpeedLog (SitiWeb_Url,SitiWeb_Ky,SitiWebPageSpeedLog_Data,SitiWebPageSpeedLog_UserInsert,SitiWebPageSpeedLog_DateInsert,SitiWebPageSpeedLog_ScoreDesktop,SitiWebPageSpeedLog_ScoreMobile) ";
		strSQL += "VALUES ('" + strSitiWeb_Url + "'," + strSitiWeb_Ky + ",GETDATE(),0,GETDATE(),'" + strPageSpeedScoreDesktop + "','" + strPageSpeedScoreMobile + "')";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output = true;
        return output;
    }

	public bool aggiornaVersione(string strVersione, string strSitiWeb_Ky, string strSitiWeb_Url)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";

        bool output = false;
        string strVecchiaVersione="";

        strWHERENet = "SitiWeb_Ky =" + strSitiWeb_Ky;
        strORDERNet = "SitiWeb_Ky";
        strFROMNet = "SitiWeb";
        dtVecchiaVersione = new DataTable("VecchiaVersione");
        dtVecchiaVersione = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWeb_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtVecchiaVersione.Rows.Count>0){
			strVecchiaVersione=dtVecchiaVersione.Rows[0]["SitiWeb_Versione"].ToString();
		}   
		//Response.Write(strVecchiaVersione);
		if (strVecchiaVersione!=strVersione){
            new Smartdesk.Sql().SQLScriptExecuteNonQuery("UPDATE SitiWeb SET SitiWeb_VersioneData=GETDATE(), SitiWeb_Versione='" + strVersione + "' WHERE SitiWeb_Ky = " + strSitiWeb_Ky);
            new Smartdesk.Sql().SQLScriptExecuteNonQuery("INSERT INTO SitiWebLog (SitiWeb_Url,SitiWebLog_Data,SitiWebLog_UserInsert,SitiWebLog_DateInsert,SitiWebLog_Descrizione,SitiWebLog_Valore,SitiWeb_Ky) VALUES ('" + strSitiWeb_Url + "',GETDATE(),0,GETDATE(),'Versione' ,'" + strVersione + "'," + strSitiWeb_Ky + ")");
		}
        return output;
    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App) //#bp
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}
