using System;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
  public string strKy = "";
  public string strFoto= "";
  
  public DataTable dtCoreUrlRewrite;
  public DataTable dtAnnunciCategorie;
  public DataTable dtProvince;
  public int intNumRecords = 0;
  public string strFROMNet = "";
  public string strWHERENet = "";
  public string strORDERNet = "";
  public string strSQL = "";

  protected void Page_Load(object sender, EventArgs e)
  {
      
      string strRedirect = Smartdesk.Current.LoginPageRoot;
      bool boolAjax = false;
      if (Smartdesk.Login.Verify)
      {
          strKy = Smartdesk.Functions.SqlWriteKey("AnnunciCategorie");
        	caricafiles();
          //updateUrlRewrite();
    		strRedirect = "/admin/app/annunci/scheda-annuncicategorie.aspx?salvato=salvato&AnnunciCategorie_Ky=" + strKy;
    		Response.Redirect(strRedirect);
      }
      Response.Redirect(strRedirect);
  }

  public void updateUrlRewrite()
  {
    string strSource="";
    string strDestination="";
    string strChiave="";

		strWHERENet = "AnnunciCategorie_Ky=" + strKy;
    strORDERNet = "AnnunciCategorie_Ky";
    strFROMNet = "AnnunciCategorie";
    dtAnnunciCategorie = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnnunciCategorie_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		strSource="/annunci/" + dtAnnunciCategorie.Rows[0]["AnnunciCategorie_Url"].ToString() + ".html";
		strDestination="/frontend/base/annunci/visualizza-categoria.aspx?AnnunciCategorie_Ky_Corrente=" + strKy + "&AnnunciCategorie_Ky=" + strKy + "";

		strWHERENet = "CoreEntities_Code='annuncicategorie' AND CoreEntities_KeyValue='" + strKy + "'";
		//Response.Write(strWHERENet);
    strORDERNet = "CoreUrlRewrite_Ky";
    strFROMNet = "CoreUrlRewrite";
    dtCoreUrlRewrite = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreUrlRewrite_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    if (dtCoreUrlRewrite.Rows.Count>0){
        strSQL = "UPDATE CoreUrlRewrite SET ";
        strSQL += "CoreUrlRewrite_UrlSource='" + strSource + "',";
        strSQL += "CoreUrlRewrite_UrlDestination='" + strDestination + "'";
        strSQL += " WHERE CoreUrlRewrite_Ky=" + dtCoreUrlRewrite.Rows[0]["CoreUrlRewrite_Ky"].ToString();
		}else{
        strSQL = "INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination) VALUES (";
        strSQL += " 'annuncicategorie',";
        strSQL += "'" + strKy + "',";
        strSQL += "'" + strSource + "',";
        strSQL += "'" + strDestination + "'";
        strSQL += ")";
		}
		//Response.Write(strSQL);
    new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
    
		//url province
    strWHERENet = "Nazioni_Ky=105";
    strORDERNet = "Province_Ky";
    strFROMNet = "Province_Vw";
    dtProvince = Smartdesk.Sql.getTablePage(strFROMNet, null, "Province_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    for (int i = 0; i < dtProvince.Rows.Count; i++){
				strChiave=strKy + "-" + dtProvince.Rows[i]["Province_Ky"].ToString();
				strSource="/attivita/" + dtProvince.Rows[i]["Province_ProvinciaHTML"].ToString().ToLower() + "/" + dtAnnunciCategorie.Rows[0]["AnnunciCategorie_Url"].ToString() + "-" + dtProvince.Rows[i]["Province_ProvinciaHTML"].ToString().ToLower() + ".html";
				strDestination="/visualizza-categoria.aspx?AnnunciCategorie_Ky_Corrente=" + strKy + "&AnnunciCategorie_Ky=" + strKy + "&Province_Ky=" + dtProvince.Rows[i]["Province_Ky"].ToString();
				strWHERENet = "CoreEntities_Code='annuncicategorie_province' AND CoreEntities_KeyValue='" + strChiave + "'";
		    strORDERNet = "CoreUrlRewrite_Ky";
		    strFROMNet = "CoreUrlRewrite";
		    dtCoreUrlRewrite = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreUrlRewrite_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		    if (dtCoreUrlRewrite.Rows.Count>0){
		        strSQL = "UPDATE CoreUrlRewrite SET ";
		        strSQL += "CoreUrlRewrite_UrlSource='" + strSource + "',";
		        strSQL += "CoreUrlRewrite_UrlDestination='" + strDestination + "'";
		        strSQL += " WHERE CoreUrlRewrite_Ky=" + dtCoreUrlRewrite.Rows[0]["CoreUrlRewrite_Ky"].ToString();
				}else{
		        strSQL = "INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination) VALUES (";
		        strSQL += " 'annuncicategorie_province',";
		        strSQL += "'" + strChiave + "',";
		        strSQL += "'" + strSource + "',";
		        strSQL += "'" + strDestination + "'";
		        strSQL += ")";
				}
    		//Response.Write(strSQL + "<br>");
				new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
		}
  }

  public void caricafiles()
  {
    string strFileName;
    string [ ] myFiles = Request.Files.AllKeys;
    if (myFiles.Length>0){
          for ( int i = 0; i < myFiles.Length; i++ ) {
            if (Request.Files[i].FileName !=""){
              strFileName=Server.MapPath("/uploads/foto-annuncicategorie/" + strKy + "_" + i + ".jpg");
              Request.Files.Get(i).SaveAs(strFileName);
              strFoto="/uploads/foto-annuncicategorie/" + strKy + "_" + i + ".jpg";
              aggiornaFoto(i);
            }      
          }
    }
  }

  public bool aggiornaFoto(int intNumeroFoto)
  {
      string strSQL="";
      bool output = false;
      strSQL = "UPDATE AnnunciCategorie SET AnnunciCategorie_Foto='" + strFoto + "' WHERE AnnunciCategorie_Ky = " + strKy;
    	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
      output=true;
      return output;
  }

	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
