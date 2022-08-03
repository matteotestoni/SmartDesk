using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using HtmlAgilityPack;

public partial class _Default : System.Web.UI.Page{
    
    
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtSitiWeb;
    public DataTable dtVecchiaVersione;
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
      string strValue="";

      
      
      if (Smartdesk.Login.Verify){
        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
        strSorgente=Smartdesk.Current.Request("sorgente");
        strSitiWeb_Ky=Smartdesk.Current.Request("SitiWeb_Ky");
        strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
        strWHERENet=getWhere();
        Response.Write("<hr>");
        Response.Write(strWHERENet);
        strFROMNet = "SitiWeb";
        strORDERNet = "SitiWeb_Url";
        dtSitiWeb = new DataTable("SitiWeb");
        dtSitiWeb = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWeb_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  			strLog=dtSitiWeb.Rows.Count.ToString();
  			strLog+="<ul>";
  			for (int i = 0; i < dtSitiWeb.Rows.Count; i++){
				  strUrl=dtSitiWeb.Rows[i]["SitiWeb_Url"].ToString();
	        if (dtSitiWeb.Rows[i]["SitiWebTipo_Ky"].ToString()=="6"){
		        aggiornaVersione("n/a",dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString(),strUrl);
    		  }else{
    				try{
			        HtmlWeb webGet = new HtmlWeb();
    					HtmlDocument document = webGet.Load(strUrl);
    					strValue = document.DocumentNode.SelectNodes("//meta[@name='generator']")[0].GetAttributeValue("content", String.Empty);
    					strLog+="<li>" + strUrl + ":" + strValue + "</li>";
	        		aggiornaVersione(strValue,dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString(),strUrl);
              //Response.Write("1");
    		    }catch{
    					strLog+="<li>" + strUrl + ": errore</li>";
              aggiornaVersione("n/a",dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString(),strUrl);
              //Response.Write("2");
    				}
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

        strWHERE = "(SitiWeb_Redirect Is Null Or LEN(SitiWeb_Redirect)=0)";
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
        Response.Write(strWHERE);
				return strWHERE;
  }

	public bool aggiornaVersione(string strVersione, string strSitiWeb_Ky, string strSitiWeb_Url)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
      string strSQL="";
      bool output = false;
      SqlDataAdapter da = new SqlDataAdapter();
      DataTable dt = new DataTable("getTable");
      string strVecchiaVersione="";

      strWHERENet = "SitiWeb_Ky =" + strSitiWeb_Ky;
      strORDERNet = "SitiWeb_Ky";
      strFROMNet = "SitiWeb";
      dtVecchiaVersione = new DataTable("VecchiaVersione");
      dtVecchiaVersione = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWeb_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      if (dtVecchiaVersione.Rows.Count>0){
			 strVecchiaVersione=dtVecchiaVersione.Rows[0]["SitiWeb_Versione"].ToString();
		  }   
  		if (strVecchiaVersione!=strVersione){
  				SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
	        SqlCommand cm = new SqlCommand();
	        strSQL = "UPDATE SitiWeb SET SitiWeb_VersioneData=GETDATE(), SitiWeb_Versione='" + strVersione + "' WHERE SitiWeb_Ky = " + strSitiWeb_Ky;
	        cm.CommandText = strSQL;
	        cm.CommandType = CommandType.Text;
	        cm.Connection = cn;
	        cm.CommandTimeout = 300;
	        da.SelectCommand = cm;
	        cn.Open();
	        try
	        {
	            cm.ExecuteNonQuery();
	        }
	        catch (SqlException ex)
	        {
	            Exception err = new Exception("csLoadData->CreateXslInsUpdXls_In: " + ex.Message);
	            throw err;
	        }
  				strSQL = "INSERT INTO SitiWebLog (SitiWeb_Url,SitiWebLog_Data,SitiWebLog_UserInsert,SitiWebLog_DateInsert,SitiWebLog_Descrizione,SitiWebLog_Valore,SitiWeb_Ky) VALUES ('" + strSitiWeb_Url + "' ,GETDATE(),0,GETDATE(),'Versione' ,'" + strVersione + "'," + strSitiWeb_Ky + ")";
  				//Response.Write(strSQL);        
	        cm.CommandText = strSQL;
	        try
	        {
	            cm.ExecuteNonQuery();
	        }
	        catch (SqlException ex)
	        {
	            Exception err = new Exception("csLoadData->CreateXslInsUpdXls_In: " + ex.Message);
	            throw err;
	        }
	        finally
	        {
	            cn.Close();
	        }
  		}
      return output;
    }
}
