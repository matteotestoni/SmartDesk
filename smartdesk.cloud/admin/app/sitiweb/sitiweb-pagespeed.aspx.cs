using System;
using System.Data;
using Google.Apis.PagespeedInsights.v5;
using Google.Apis.Services;
public partial class _Default : System.Web.UI.Page{

    
    
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtSitiWeb;
    public DataTable dtTemp;
    public int intNumRecords = 0;
    public string strLog="";
    public string strSitiWeb_Ky="";
    public string strAnagrafiche_Ky="";
    public string strSorgente="";

    protected void Page_Load(object sender, EventArgs e){
    string strWHERENet="";
    string strORDERNet = "";
    string strFROMNet = "";
    string strUrl="";
    string strScoreDesktop="";
    float floatScoreDesktop = -1;
    string strScoreMobile = "";
    float floatScoreMobile = -1;

    
      
      
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strSorgente=Smartdesk.Current.Request("sorgente");
            strSitiWeb_Ky=Smartdesk.Current.Request("SitiWeb_Ky");
            strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
            strWHERENet=getWhere();
            strFROMNet = "SitiWeb";
            strORDERNet = "SitiWeb_Url";
            dtSitiWeb = new DataTable("SitiWeb");
            dtSitiWeb = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWeb_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            Google.Apis.PagespeedInsights.v5.PagespeedInsightsService service = new Google.Apis.PagespeedInsights.v5.PagespeedInsightsService(new BaseClientService.Initializer
            {
              ApplicationName = "app.rswstudio.it",
              ApiKey = "AIzaSyAES_hH89T1by4uvK9_fJaAZ2aKvsDkJ2I",
            });
                strLog ="<ul>";
				for (int i = 0; i < dtSitiWeb.Rows.Count; i++){
					strUrl=dtSitiWeb.Rows[i]["SitiWeb_Url"].ToString();
          strLog +="<li>" + strUrl + "</li>";
			        try{
                        Google.Apis.PagespeedInsights.v5.PagespeedapiResource.RunpagespeedRequest request = service.Pagespeedapi.Runpagespeed(strUrl);
                        request.Strategy = Google.Apis.PagespeedInsights.v5.PagespeedapiResource.RunpagespeedRequest.StrategyEnum.DESKTOP;
                        Google.Apis.PagespeedInsights.v5.Data.PagespeedApiPagespeedResponseV5 resultDesktop = request.Execute();                  
                        try { 
                          floatScoreDesktop = float.Parse(resultDesktop.LighthouseResult.Categories.Performance.Score.ToString()) * 100;
                          strScoreDesktop = floatScoreDesktop.ToString();
                        }
                        catch{ strScoreDesktop = "-1"; }                   
 
                        request.Strategy = Google.Apis.PagespeedInsights.v5.PagespeedapiResource.RunpagespeedRequest.StrategyEnum.MOBILE;
                        Google.Apis.PagespeedInsights.v5.Data.PagespeedApiPagespeedResponseV5 resultMobile = request.Execute();
                        try
                        {
                          floatScoreMobile = float.Parse(resultMobile.LighthouseResult.Categories.Performance.Score.ToString()) * 100;
                          strScoreMobile = floatScoreMobile.ToString();
                        }
                        catch { strScoreMobile = "-1"; }
                        
                        if (strScoreMobile != "-1" || strScoreDesktop != "-1")
                        {
                          strLog += "<li>Score Desktop:" + strScoreDesktop + " - Score Mobile:" + strScoreMobile + "</li>";
                          aggiornaScore(strScoreDesktop,strScoreMobile, dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString(), strUrl);
                        }




          //Response.Write("1");
        }
        catch (Exception ex){
				        Response.Write(ex.ToString());
						aggiornaScore("-1", "-1", dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString(),strUrl);
                        //Response.Write("2");
					}
  				}
  				strLog+="</ul>";
  				Response.Write(strLog);
      
      switch (strSorgente){
					case "scheda-anagrafiche":
					Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky);
					break;
				case "scheda-sitoweb":
					Response.Redirect("/admin/app/sitiweb/scheda-sitiweb.aspx?SitiWeb_Ky=" + strSitiWeb_Ky);
					break;
				case "elenco-sitiweb":
					Response.Redirect("/admin/view.aspx?CoreModules_Ky=27&CoreEntities_Ky=142&CoreGrids_Ky=126&SitiWeb_Ky=" + strSitiWeb_Ky);
					break;
				default:
					if (strSitiWeb_Ky!=null && strSitiWeb_Ky.Length>0){
						Response.Redirect("/admin/app/sitiweb/scheda-sitiweb.aspx?SitiWeb_Ky=" + strSitiWeb_Ky);
					}else{
						Response.Redirect("/admin/view.aspx?CoreModules_Ky=27&CoreEntities_Ky=142&CoreGrids_Ky=126&Anagrafiche_Ky=" + strAnagrafiche_Ky);
					}
				    break;
				}
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    public string getWhere()
    {
        string strWHERE="";
        string strValue="";

        strWHERE = "(SitiWeb_Redirect Is Null Or Len(SitiWeb_Redirect)<1)";
		    strValue = Smartdesk.Current.Request("SitiWeb_Ky");
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>0){
            	strWHERE += " And (SitiWeb_Ky=" + strValue + ")";
						}else{
            	strWHERE = "(SitiWeb_Ky=" + strValue + ")";
						}
        }
        strValue = Smartdesk.Current.Request("SitiWebTipo_Ky");
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>0){
				strWHERE += " And (SitiWebTipo_Ky=" + strValue + ")";
			}else{
				strWHERE += "(SitiWebTipo_Ky=" + strValue + ")";
			}
        }
        strValue = Smartdesk.Current.Request("Anagrafiche_Ky");
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>0){
							strWHERE += "And (Anagrafiche_Ky=" + strValue + ")";
						}else{
							strWHERE = "(Anagrafiche_Ky=" + strValue + ")";
						}
        }
        strValue = Request["SitiWeb_SEO"];
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>0){
							strWHERE += "And (SitiWeb_SEO=1)";
						}else{
							strWHERE = "(SitiWeb_SEO=1)";
						}
        }
        strValue = Request["tutti"];
        if (strValue != null && strValue != ""){
            strWHERE = "(SitiWeb_Redirect Is Null Or Len(SitiWeb_Redirect)<1)";
        }
        //Response.Write(strWHERE);
		return strWHERE;
    }

    public bool aggiornaScore(string strPageSpeedScoreDesktop, string strPageSpeedScoreMobile, string strSitiWeb_Ky, string strSitiWeb_Url)
    {
        string strSQL = "";
        bool output = false;
        strSQL = "UPDATE SitiWeb SET SitiWeb_PageSpeedData=GETDATE(), SitiWeb_PageSpeedScore='" + strPageSpeedScoreDesktop + "', SitiWeb_PageSpeedScoreMobile='" + strPageSpeedScoreMobile + "' WHERE SitiWeb_Ky = " + strSitiWeb_Ky;
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL = "INSERT INTO SitiWebPageSpeedLog (SitiWeb_Url,SitiWeb_Ky,SitiWebPageSpeedLog_Data,SitiWebPageSpeedLog_UserInsert,SitiWebPageSpeedLog_DateInsert,SitiWebPageSpeedLog_ScoreDesktop,SitiWebPageSpeedLog_ScoreMobile) ";
        strSQL += "VALUES ('" + strSitiWeb_Url + "'," + strSitiWeb_Ky + ",GETDATE(),0,GETDATE(),'" + strPageSpeedScoreDesktop + "','" + strPageSpeedScoreMobile + "')";
        Response.Write(strSQL);
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        return output;
    }
}
