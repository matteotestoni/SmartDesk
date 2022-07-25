using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;

public partial class _Default : System.Web.UI.Page 
{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ciit = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo cien = new System.Globalization.CultureInfo("en-US");
    public string strH1 = "";
    public string strRisultato = "";
    public DataTable dtComuni;
    public DataTable dtProvince;
    public DataTable dtRegioni;
    public DataTable dtNazioni;
    public int intKy;

    protected void Page_Load(object sender, EventArgs e)
    {
        string strDirectory="";
        string strSQL="";
        string strWHERENet = "";
        string strORDERNet = "";
        string strFROMNet = "";
        string json="";
        string strComuni_Ky = "";
        string strProvince_Ky = "";
        string strRegioni_Ky = "";
        string strNazioni_Ky = "";
        string strUrlKey = "";
        SqlConnection conn;
        SqlCommand cmd;
        int intOrdine=1;
        
        
        
            strH1="Aggiornamento Cities";
            json = File.ReadAllText(Server.MapPath("cities.json"));
            //Response.Write(json);
            dynamic dynJson = JsonConvert.DeserializeObject(json);
            foreach (var item in dynJson)
            {
              strRisultato+=item.country+"-" + item.name + "<br>";
              if (item.country!="IT"){
                strUrlKey = item.name.ToString().ToLower().Replace("'","").Replace(" ","-").Replace("/","").Replace("à","a").Replace("è","e").Replace("ì","i").Replace("ò","o").Replace("ù","u");
                strWHERENet="Nazioni_Isocode2='" + item.country + "'";
                strORDERNet = "Nazioni_Ky";
                strFROMNet = "Nazioni";
                dtNazioni = new DataTable("Nazioni");
                dtNazioni = Smartdesk.Sql.getTablePage(strFROMNet, null, "Nazioni_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtNazioni.Rows.Count>0){ 
                  strNazioni_Ky=dtNazioni.Rows[0]["Nazioni_Ky"].ToString();
                  strWHERENet="Nazioni_Ky=" + strNazioni_Ky;
                  strORDERNet = "Regioni_Ky";
                  strFROMNet = "Regioni_Vw";
                  dtRegioni = new DataTable("Regioni");
                  dtRegioni = Smartdesk.Sql.getTablePage(strFROMNet, null, "Regioni_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtRegioni.Rows.Count<1){  
                      strSQL="INSERT INTO Regioni (Regioni_Regione,Regioni_Codice,Regioni_UrlKey,Nazioni_Ky) VALUES ('Region " + dtNazioni.Rows[0]["Nazioni_Nazione"].ToString() + "','" + dtNazioni.Rows[0]["Nazioni_Codice"].ToString() + "','" + dtNazioni.Rows[0]["Nazioni_Codice"].ToString().ToLower() + "'," + strNazioni_Ky + ")";
                      //Response.Write(strSQL);
                      intKy=new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                      strWHERENet="Nazioni_Ky=" + strNazioni_Ky;
                      strORDERNet = "Regioni_Ky";
                      strFROMNet = "Regioni_Vw";
                      dtRegioni = new DataTable("Regioni");
                      dtRegioni = Smartdesk.Sql.getTablePage(strFROMNet, null, "Regioni_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      strRegioni_Ky=dtRegioni.Rows[0]["Regioni_Ky"].ToString();
                  }else{
                      strRegioni_Ky=dtRegioni.Rows[0]["Regioni_Ky"].ToString();
                      strSQL="UPDATE Regioni SET Regioni_Regione='Region " + dtNazioni.Rows[0]["Nazioni_Nazione"].ToString() + "',Regioni_Codice='" + dtNazioni.Rows[0]["Nazioni_Codice"].ToString() + "',Regioni_UrlKey='" + dtNazioni.Rows[0]["Nazioni_Codice"].ToString().ToLower() + "'  WHERE Regioni_Ky=" + strRegioni_Ky;
                      intKy=new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  }     
                  strWHERENet="Nazioni_Isocode2='" + item.country + "' AND Province_Provincia='" + item.name.ToString().Replace("'","''") + "'";
                  strORDERNet = "Province_Ky";
                  strFROMNet = "Province_Vw";
                  dtProvince = new DataTable("Province");
                  dtProvince = Smartdesk.Sql.getTablePage(strFROMNet, null, "Province_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtProvince.Rows.Count<1){  
                      strSQL="INSERT INTO Province (Province_Provincia,Province_Codice,Province_ProvinciaHTML,Regioni_Codice,Regioni_Ky) VALUES ('" + item.name.ToString().Replace("'","''") + "','" + strUrlKey + "','" + strUrlKey + "','" + dtNazioni.Rows[0]["Nazioni_Codice"].ToString() + "', " + strRegioni_Ky + ")";
                      //Response.Write(strSQL);
                      intKy=new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                      strWHERENet="Nazioni_Isocode2='" + item.country + "' AND Province_Provincia='" + item.name.ToString().Replace("'","''") + "'";
                      strORDERNet = "Province_Ky";
                      strFROMNet = "Province_Vw";
                      dtProvince = new DataTable("Province");
                      dtProvince = Smartdesk.Sql.getTablePage(strFROMNet, null, "Province_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      strProvince_Ky=dtProvince.Rows[0]["Province_Ky"].ToString();
                  }else{
                      strProvince_Ky=dtProvince.Rows[0]["Province_Ky"].ToString();
                      strSQL="UPDATE Province SET Province_Codice='" + strUrlKey + "', Regioni_Codice='" + dtNazioni.Rows[0]["Nazioni_Codice"].ToString() + "' WHERE Province_Ky=" + strProvince_Ky;
                      intKy=new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  }     
                  strWHERENet="Nazioni_Isocode2='" + item.country + "' AND Comuni_Comune='" + item.name.ToString().Replace("'","''") + "'";
                  strORDERNet = "Comuni_Ky";
                  strFROMNet = "Comuni_Vw";
                  dtComuni = new DataTable("Comune");
                  dtComuni = Smartdesk.Sql.getTablePage(strFROMNet, null, "Comuni_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtComuni.Rows.Count<1){        
                    strSQL="INSERT INTO Comuni (Comuni_Comune,Comuni_ComuneHTML,Comuni_Principale,Comuni_Tipo,Province_Codice, Province_Ky, Comuni_Latitudine, Comuni_Longitudine, Comuni_Ordine) VALUES ('" + item.name.ToString().Replace("'","''") + "','" + strUrlKey + "',1,1,'" + strUrlKey + "'," + strProvince_Ky + ",'" + item.lat + "','" + item.lng + "'," + intOrdine + ");";
                    intKy=new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                    strComuni_Ky=intKy.ToString();
                  }else{
                    strComuni_Ky=dtComuni.Rows[0]["Comuni_Ky"].ToString();
                    strSQL="UPDATE Comuni SET Province_Codice='" + strUrlKey + "', Comuni_ComuneHTML='" + strUrlKey + "', Comuni_Latitudine='" + item.lat + "', Comuni_Longitudine='" + item.lng + "' WHERE Comuni_Ky=" + strComuni_Ky;
                    //Response.Write(strSQL);
                    intKy=new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  }       
                } 
            }
            intOrdine++;
          }            
            
            
   }    
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
