using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.IO;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ciit = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo cien = new System.Globalization.CultureInfo("en-US");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtCoreForms;
    public DataTable dtCoreGrids;
    public DataTable dtUtentiGruppi;
    public DataTable dtUsergroupsForms;
    public DataTable dtUsergroupsGrids;
    public string strRisultato = "";
    public string strH1 = "Permission for forms and grids";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strFROMNet = "";
      string strWHERENet="";
      string strORDERNet = "";
      string strSQL="";

      
      
      /*
      strSQL="TRUNCATE TABLE UsergroupsForms;";
      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
      strSQL="TRUNCATE TABLE UsergroupsGrids;";
      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
      */

      strWHERENet="UtentiGruppi_Admin=1";
      strORDERNet = "UtentiGruppi_Ky";
      strFROMNet = "UtentiGruppi";
      dtUtentiGruppi = Smartdesk.Sql.getTablePage(strFROMNet, null, "UtentiGruppi_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

      strWHERENet="";
      strORDERNet = "CoreForms_Ky";
      strFROMNet = "CoreForms";
      dtCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreForms_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      if (dtCoreForms.Rows.Count>0){
        strRisultato="<h2>Forms</h2><ul>";        
        for (int i = 0; i < dtCoreForms.Rows.Count; i++){
            for (int j = 0; j < dtUtentiGruppi.Rows.Count; j++){
              strWHERENet="UtentiGruppi_Ky=" + dtUtentiGruppi.Rows[j]["UtentiGruppi_Ky"].ToString() + " AND CoreForms_Ky=" + dtCoreForms.Rows[i]["CoreForms_Ky"].ToString();
              strORDERNet = "UsergroupsForms_Ky";
              strFROMNet = "UsergroupsForms";
              dtUsergroupsForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsForms_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtUsergroupsForms.Rows.Count<1){                
                  strSQL="INSERT INTO UsergroupsForms (CoreForms_Ky, UtentiGruppi_Ky,UsergroupsForms_UserInsert,UsergroupsForms_DateInsert) VALUES (" + dtCoreForms.Rows[i]["CoreForms_Ky"].ToString() + ", " + dtUtentiGruppi.Rows[0]["UtentiGruppi_Ky"].ToString() + ",0,GETDATE());";
                  new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  strRisultato=strRisultato + "<li>" + dtCoreForms.Rows[i]["CoreForms_Ky"].ToString() + "</li>";        
              }
            }
        }
        strRisultato=strRisultato + "</ul>";        
      }

      //strWHERENet="CoreGrids_Ky=277";
      strWHERENet="";
      strORDERNet = "CoreGrids_Ky";
      strFROMNet = "CoreGrids";
      dtCoreGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGrids_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      if (dtCoreGrids.Rows.Count>0){
        strRisultato+="<h2>Grids</h2><ul>";        
        for (int i = 0; i < dtCoreGrids.Rows.Count; i++){
            for (int j = 0; j < dtUtentiGruppi.Rows.Count; j++){
              strWHERENet="UtentiGruppi_Ky=" + dtUtentiGruppi.Rows[j]["UtentiGruppi_Ky"].ToString() + " AND CoreGrids_Ky=" + dtCoreGrids.Rows[i]["CoreGrids_Ky"].ToString();
              strORDERNet = "UsergroupsGrids_Ky";
              strFROMNet = "UsergroupsGrids";
              dtUsergroupsGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsGrids_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtUsergroupsGrids.Rows.Count<1){                
                  strSQL="INSERT INTO UsergroupsGrids (CoreGrids_Ky, UtentiGruppi_Ky,UsergroupsGrids_UserInsert,UsergroupsGrids_DateInsert) VALUES (" + dtCoreGrids.Rows[i]["CoreGrids_Ky"].ToString() + ", " + dtUtentiGruppi.Rows[0]["UtentiGruppi_Ky"].ToString() + ",0,GETDATE());";
                  new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  strRisultato=strRisultato + "<li>" + dtCoreGrids.Rows[i]["CoreGrids_Ky"].ToString() + "</li>";        
              }
            }
        }
        strRisultato=strRisultato + "</ul>";        
      }                    

    }    
    
public string FirstLetterToUpper(string str)
{
    if (str == null)
        return null;

    if (str.Length > 1)
        return char.ToUpper(str[0]) + str.Substring(1);

    return str.ToUpper();
}
    
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
