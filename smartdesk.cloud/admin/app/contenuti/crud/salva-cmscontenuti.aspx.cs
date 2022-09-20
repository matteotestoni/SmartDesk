using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    public string strKy = "";
    public string strFoto= "";
  	public DataTable dtCoreUrlRewrite;
    public DataTable dtCMSContenuti;
    public DataTable dtCoreModulesOptionsValue;
    public string strUrlKey= "";
    public string strFROMNet = "";
    public string strWHERENet = "";
    public string strORDERNet = "";
	  public string strSQL = "";
    public int intNumRecords = 0;
    public string strTheme="";

    protected void Page_Load(object sender, EventArgs e){
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify){
            Dictionary<string, object> frm = new Dictionary<string, object>();
            if (Smartdesk.Current.Request("CMSContenuti_PubblicaWEB") == "") frm.Add("CMSContenuti_PubblicaWEB", false);
            if (Smartdesk.Current.Request("CMSContenuti_InMenu") == "") frm.Add("CMSContenuti_InMenu", false);
            if (Smartdesk.Current.Request("CMSContenuti_Sitemap") == "") frm.Add("CMSContenuti_Sitemap", false);
            strUrlKey=System.Web.HttpUtility.HtmlEncode(Smartdesk.Current.Request("CMSContenuti_UrlKey"));
            strKy=Smartdesk.Functions.SqlWriteKey("CMSContenuti",frm);
            if (strUrlKey==null || strUrlKey.Length<2){
              strUrlKey = System.Web.HttpUtility.HtmlEncode(Smartdesk.Current.Request("CMSContenuti_Titolo")).ToLower().Replace(" ","-").Replace("/","").Replace("à","a").Replace("è","e").Replace("ì","i").Replace("ò","o").Replace("ù","u").Replace("'","") + "-" + strKy;
              aggiornaUrlKey(strUrlKey);
            }
          	caricafiles();
            updateUrlRewrite();
          	caricafiles();
            strRedirect = "/admin/app/contenuti/scheda-cmscontenuti.aspx?salvato=salvato&azione=edit&CMSContenuti_Ky=" + strKy;
			      Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
  }

  public bool aggiornaUrlKey(string strUrlKey)
  {
    string strSQL="";
    bool output = false;
    strSQL = "UPDATE CMSContenuti SET CMSContenuti_UrlKey='" + strUrlKey + "' WHERE CMSContenuti_Ky = " + strKy;
  	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
    output=true;
    return output;
  }

  public void updateUrlRewrite()
  {
    string strSource="";
    string strDestination="";
		
    dtCoreModulesOptionsValue = new DataTable("Options");
    strWHERENet="CoreModulesOptions_Code='design'";
    strORDERNet = "CoreModulesOptionsValue_Ky";
    strFROMNet = "CoreModulesOptionsValue";
    dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    if (dtCoreModulesOptionsValue.Rows.Count>0){
      strTheme=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
    }else{
      strTheme="base";
    }        

		strWHERENet = "CMSContenuti_Ky=" + strKy;
    strORDERNet = "CMSContenuti_Ky";
    strFROMNet = "CMSContenuti_Vw";
    dtCMSContenuti = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSContenuti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		strSource="/pag/" + dtCMSContenuti.Rows[0]["CMSContenuti_UrlKey"].ToString() + ".html";
		strDestination="/frontend/" + strTheme + "/contenuti/scheda-CMSContenuti.aspx?CMSContenuti_Ky=" + strKy;

		strWHERENet = "CoreEntities_Code='CMSContenuti' AND CoreEntities_KeyValue='" + strKy + "'";
		//Response.Write(strWHERENet);
        strORDERNet = "CoreUrlRewrite_Ky";
        strFROMNet = "CoreUrlRewrite";
        dtCoreUrlRewrite = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreUrlRewrite_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreUrlRewrite.Rows.Count>0){
            strSQL = "UPDATE CoreUrlRewrite SET ";
            strSQL += "CoreUrlRewrite_UrlSource='" + strSource + "',";
            strSQL += "CoreUrlRewrite_UrlDestination='" + strDestination + "',";
            strSQL += "CoreUrlRewrite_DateUpdate=GETDATE()";
            strSQL += " WHERE CoreUrlRewrite_Ky=" + dtCoreUrlRewrite.Rows[0]["CoreUrlRewrite_Ky"].ToString();
    		}else{
            strSQL = "INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_DateInsert) VALUES (";
            strSQL += " 'CMSContenuti',";
            strSQL += "'" + strKy + "',";
            strSQL += "'" + strSource + "',";
            strSQL += "'" + strDestination + "',";
            strSQL += "GETDATE()";
            strSQL += ")";
    		}
    		//Response.Write(strSQL);
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
  }

    public void caricafiles()
    {
      long milliseconds=0;
      string strFileName;
      string [ ] myFiles = Request.Files.AllKeys;
      if (myFiles.Length>0){
            for ( int i = 0; i < myFiles.Length; i++ ) {
              if (Request.Files[i].FileName !=""){
                milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                strFileName=Server.MapPath("/uploads/foto-contenuti/" + strKy + ".jpg");
                Request.Files.Get(i).SaveAs(strFileName);
                strFoto="/uploads/foto-contenuti/" + strKy + ".jpg";
                aggiornaFoto(i);
              }      
            }
      }
    }

    public bool aggiornaFoto(int intNumeroFoto)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE CMSContenuti SET CMSContenuti_Foto='" + strFoto + "' WHERE CMSContenuti_Ky = " + strKy;
      	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
        return output;
    }
}
