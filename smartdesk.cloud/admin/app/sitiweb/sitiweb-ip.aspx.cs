using System;
using System.Data;
using System.Data.SqlClient;

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
      string strDominio="";
      string strDominio2="";
      string strValue="";

      if (Smartdesk.Login.Verify){
        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
        boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
	      strSorgente=Smartdesk.Current.Request("sorgente");
	      strSitiWeb_Ky=Smartdesk.Current.Request("SitiWeb_Ky");
	      strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
        strWHERENet=getWhere();
        Response.Write(strWHERENet);
        strFROMNet = "SitiWeb";
        strORDERNet = "SitiWeb_Ky";
        dtSitiWeb = new DataTable("SitiWeb");
        dtSitiWeb = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWeb_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    		strLog=dtSitiWeb.Rows.Count.ToString();
    		strLog+="<ul>";
				for (int i = 0; i < dtSitiWeb.Rows.Count; i++){
    			strDominio=dtSitiWeb.Rows[i]["SitiWeb_Dominio"].ToString();
          //Response.Write(strDominio + "<br>");
					strUrl=dtSitiWeb.Rows[i]["SitiWeb_Url"].ToString();
			    try{
	    			System.Net.IPAddress[] ip = System.Net.Dns.GetHostAddresses(strDominio);
	    			strValue=ip[0].ToString();
						strLog+="<li>" + strUrl + "-1:" + strValue + "</li>";
				    aggiornaIP(strValue,dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString(),strUrl);
			    }catch{
				    try{
		    			strDominio2="www." + strDominio;
							System.Net.IPAddress[] ip = System.Net.Dns.GetHostAddresses(strDominio2);
		    			strValue=ip[0].ToString();
							strLog+="<li>" + strUrl + "-2:" + strValue + "</li>";
					    aggiornaIP(strValue,dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString(),strUrl);
				    }catch{
							strLog+="<li>" + strUrl + "-3: errore</li>";
					    //aggiornaIP("n/a",dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString(),strUrl);
						}
					}
    		}
    		strLog+="</ul>";
    		Response.Write(strLog);
          switch (strSorgente){
						case "scheda-anagrafiche":
		            			Response.Redirect("/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=" + strAnagrafiche_Ky);
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

        strWHERE = "(SitiWeb_Redirect Is Null OR LEN(SitiWeb_Redirect)<1)";
        strWHERE = "";
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
            strWHERE = "(SitiWeb_Redirect Is Null)";
        }
        //Response.Write(strWHERE + "<br>");
				return strWHERE;
    }
	
	public bool aggiornaIP(string strIP, string strSitiWeb_Ky, string strSitiWeb_Url)
    {
        string strWHERENet = "";
        string strORDERNet = "";
        string strFROMNet = "";
        string strSQL="";
        string strCountry="";
        bool output = false;
        
        strWHERENet = "SitiWeb_Url='" + strSitiWeb_Url + "' AND SitiWebLog_Descrizione='Rilvevamento IP'";
        strFROMNet = "SitiWebLog";
        strORDERNet = "SitiWebLog_Data DESC";
        dtTemp = new DataTable("SitiWeb");
        dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWebLog_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtTemp.Rows.Count < 1 || dtTemp.Rows[0]["SitiWebLog_Valore"].ToString() != strIP){
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
            Response.Write(strSQL + "<hr>");
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

			      strSQL = "INSERT INTO SitiWebLog (SitiWeb_Url,SitiWebLog_Data,SitiWebLog_UserInsert,SitiWebLog_DateInsert,SitiWebLog_Descrizione,SitiWebLog_Valore,SitiWeb_Ky) VALUES ('" + strSitiWeb_Url + "' ,GETDATE(),0,GETDATE(),'Rilvevamento IP' ,'" + strIP + "'," + strSitiWeb_Ky + ")";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
 
        }
		return output;
    }

    void WriteInfo(IpInfo ip)
    {
        Response.Write("IP Address: " + ip.IpAddress + "<br />");
        Response.Write("IP Number: " + ip.IpNumber + "<br />");
        Response.Write("Country Code: " + ip.CountryCode + "<br />");
        Response.Write("Country: " + ip.CountryName + "<br />");
        Response.Write("Region: " + ip.RegionName + "<br />");
        Response.Write("City: " + ip.CityName + "<br />");
        Response.Write("Latitue: " + ip.Latitude + "<br />");
        Response.Write("Longitue: " + ip.Longitude + "<br />");
        Response.Write("Zip Code: " + ip.ZipCode + "<br />");
        Response.Write("Time Zone: " + ip.TimeZone + "<br />");
        Response.Write("<hr />");
    }
}
