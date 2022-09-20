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
    
    public bool boolAdmin = false;
    
    public DataTable dtSitiWeb;
    public int intNumRecords = 0;
    
    public string strLog="";
		
		protected void Page_Load(object sender, EventArgs e){
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
      string strUrl="";
      string strValue="";

      
      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
            
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strWHERENet="SitiWebTipo_Ky=3 And SitiWeb_Redirect Is Null";
            strFROMNet = "SitiWeb";
            strORDERNet = "SitiWeb_Url";
            dtSitiWeb = new DataTable("SitiWeb");
            dtSitiWeb = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWeb_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    				strLog=dtSitiWeb.Rows.Count.ToString();
    				strLog+="<ul>";
						for (int i = 0; i < dtSitiWeb.Rows.Count; i++){
    					strUrl=dtSitiWeb.Rows[i]["SitiWeb_Url"].ToString();
			        try{
						    HtmlWeb webGet = new HtmlWeb();
								HtmlDocument document = webGet.Load(strUrl);
								strValue = document.DocumentNode.SelectNodes("//meta[@name='generator']")[0].GetAttributeValue("content", String.Empty);
								strLog+="<li>" + strUrl + ":" + strValue + "</li>";
				        aggiornaVersione(strValue,dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString(),strUrl);
			        }catch{
								strLog+="<li>" + strUrl + ": errore</li>";
				        aggiornaVersione("n/a",dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString(),strUrl);
							}
    				}
    				strLog+="</ul>";
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

		public bool aggiornaVersione(string strVersione, string strSitiWeb_Ky, string strSitiWeb_Url)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE SitiWeb SET SitiWeb_VersioneData=GETDATE(), SitiWeb_Versione='" + strVersione + "' WHERE SitiWeb_Ky = " + strSitiWeb_Ky;
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
				strSQL = "INSERT INTO SitiWebLog ([SitiWeb_Url],[SitiWebLog_Data],[SitiWebLog_Descrizione],[SitiWebLog_Valore]) VALUES ('" + strSitiWeb_Url + "' ,GETDATE() ,'Versione' ,'" + strVersione + "')";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        return output;
    }
}
