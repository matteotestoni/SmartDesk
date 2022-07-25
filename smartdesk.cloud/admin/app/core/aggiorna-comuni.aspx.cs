using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class _Default : System.Web.UI.Page 
	{
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public string strSorgente="";
    
    public DataTable dtComuni;
    public DataTable dtComuniNuovo;
    public DataTable dtProvince;
    
    
    public string strCSVPath;

  protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string Fulltext;
      DataTable dtCsv = new DataTable();
      DataTable dtCsvEstinzione = new DataTable();
      string strWHERENet = "";
      string strORDERNet = "";
      string strFROMNet = "";

    
    

    if (Smartdesk.Login.Verify){


      //aggiornamento comuni
      strCSVPath = Server.MapPath("/admin/app/core/db/Codici-statistici-e-denominazioni-al-01_07_2020.csv");
      Response.Write(strCSVPath + "<br>");
      using (StreamReader sr = new StreamReader(strCSVPath))
      {
        while (!sr.EndOfStream)
        {
          Fulltext = sr.ReadToEnd().ToString();
          string[] rows = Fulltext.Split('\n');  
          for (int i = 0; i < rows.Count() - 1; i++)
          {
            string[] rowValues = rows[i].Split(';'); 
            {
              if (i == 0)
              {
                for (int j = 0; j < rowValues.Count(); j++)
                {
                  dtCsv.Columns.Add(rowValues[j].ToString().Trim());  
                }
              }
              else
              {
                DataRow dr = dtCsv.NewRow();
                for (int k = 0; k < rowValues.Count(); k++)
                {
                  dr[k] = rowValues[k].ToString();
                }
                dtCsv.Rows.Add(dr); 
              }
            }
          }
        }
      }
      for (int i = 0; i < dtCsv.Rows.Count; i++)
        {
        strWHERENet = "Comuni_Istat='" + dtCsv.Rows[i]["Codice Comune formato alfanumerico"] + "'";
        strFROMNet = "Comuni";
        strORDERNet = "Comuni_Comune";
        dtComuni = Smartdesk.Sql.getTablePage(strFROMNet, null, "Comuni_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

        strWHERENet = "Province_Codice='" + dtCsv.Rows[i]["Sigla automobilistica"] + "'";
        strFROMNet = "Province";
        strORDERNet = "Province_Provincia";
        dtProvince = Smartdesk.Sql.getTablePage(strFROMNet, null, "Province_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtComuni.Rows.Count < 1)
        {
          strSQL= "INSERT INTO Comuni (";
          strSQL += "Comuni_Comune";
          strSQL += ",Comuni_Ordine";
          strSQL += ", Comuni_ComuneHTML";
          strSQL += ",Comuni_Principale";
          strSQL += ",Comuni_Cap";
          strSQL += ",Province_Codice";
          strSQL += ",Comuni_CodiceFiscale";
          strSQL += ",Comuni_CodiceCatastale";
          strSQL += ",Comuni_Istat";
          strSQL += ",Comuni_Tipo";
          strSQL += ",Comuni_Capo";
          strSQL += ",Comuni_Zona";
          strSQL += ",Comuni_CapoKy";
          strSQL += ",ImmobiliZona_Ky";
          strSQL += ",Comuni_ZonaRichiesta";
          strSQL += ",Province_Ky";
          strSQL += ",Comuni_UserUpdate";
          strSQL += ",Comuni_DateUpdate)";
          strSQL += " VALUES ( ";
          strSQL += "'" + dtCsv.Rows[i]["Denominazione in italiano"].ToString().Replace("'", "''") + "'";
          strSQL += ",99";
          strSQL += ",'" + dtCsv.Rows[i]["Denominazione in italiano"].ToString().ToLower().Replace(" ", "-").Replace("'", "-") + "'";
          strSQL += ",1";
          strSQL += ",Null"; 
          strSQL += ",'" + dtCsv.Rows[i]["Sigla automobilistica"] + "'";
          strSQL += ",Null";
          strSQL += ",'" + dtCsv.Rows[i]["Codice Catastale del comune"] + "'";
          strSQL += ",'" + dtCsv.Rows[i]["Codice Comune formato alfanumerico"] + "'";
          strSQL += ",1";
          strSQL += ",'" + dtCsv.Rows[i]["Denominazione in italiano"].ToString().Replace("'", "''") + "'";
          strSQL += ",0";
          strSQL += ",Null";
          strSQL += ",Null";
          strSQL += ",0";
          strSQL += "," + dtProvince.Rows[0]["Province_Ky"].ToString(); 
          strSQL += ",0";
          strSQL += ",GETDATE())";
          //Response.Write(strSQL + "<br>");
          //Response.Write("Istat non presente: " + dtCsv.Rows[i]["Codice Comune formato alfanumerico"] + "<br>");
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        }
        else
        {
          strSQL = "UPDATE Comuni SET";
          strSQL += " Comuni_Comune='" + dtCsv.Rows[i]["Denominazione in italiano"].ToString().Replace("'", "''") + "',";
          strSQL += " Comuni_ComuneHTML='" + dtCsv.Rows[i]["Denominazione in italiano"].ToString().ToLower().Replace(" ","-").Replace("'", "-") + "',";
          strSQL += " Comuni_Capo='" + dtCsv.Rows[i]["Denominazione in italiano"].ToString().Replace("'", "''") + "',";
          strSQL += " Comuni_Principale=1,";
          strSQL += " Comuni_Tipo=1,";
          strSQL += " Comuni_Zona=0,";
          strSQL += " Province_Ky=" + dtProvince.Rows[0]["Province_Ky"].ToString() + ",";
          strSQL += " Province_Codice='" + dtCsv.Rows[i]["Sigla automobilistica"] + "',";
          strSQL += " Comuni_CodiceCatastale='" + dtCsv.Rows[i]["Codice Catastale del comune"] + "',";
          strSQL += " Comuni_UserUpdate=0,";
          strSQL += " Comuni_DateUpdate=GETDATE()";
          strSQL += " WHERE Comuni_Istat='" + dtCsv.Rows[i]["Codice Comune formato alfanumerico"] + "'";
          //Response.Write(strSQL + "<br>");
          //Response.Write("Istat non presente: " + dtCsv.Rows[i]["Codice Comune formato alfanumerico"] + "<br>");
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        }
      }
      //estinzione comuni
      dtCsvEstinzione = new DataTable();
      Fulltext = "";
      strCSVPath = Server.MapPath("/admin/app/core/db/Variazioni_amministrative_territoriali_dal_01011991.csv");
      Response.Write(strCSVPath + "<br>");
      using (StreamReader sr = new StreamReader(strCSVPath))
      {
        while (!sr.EndOfStream)
        {
          Fulltext = sr.ReadToEnd().ToString();
          string[] rows = Fulltext.Split('\n'); 
          for (int i = 0; i < rows.Count() - 1; i++)
          {
            string[] rowValues = rows[i].Split(';');
            {
              if (i == 0)
              {
                for (int j = 0; j < rowValues.Count(); j++)
                {
                  dtCsvEstinzione.Columns.Add(rowValues[j].ToString().Trim());
                }
              }
              else
              {
                DataRow dr = dtCsvEstinzione.NewRow();
                for (int k = 0; k < rowValues.Count(); k++)
                {
                  dr[k] = rowValues[k].ToString();
                }
                dtCsvEstinzione.Rows.Add(dr);
              }
            }
          }
        }
      }
      //dtCsvEstinzione.Rows.Count
      for (int i = 0; i < dtCsvEstinzione.Rows.Count; i++)
      {
          
        if (dtCsvEstinzione.Rows[i]["Tipo variazione"].ToString() == "ES") { 
              strWHERENet = "Comuni_Istat='" + dtCsvEstinzione.Rows[i]["Istat vecchio"].ToString().Trim() + "'";
              strFROMNet = "Comuni";
              strORDERNet = "Comuni_Comune";
              dtComuni = Smartdesk.Sql.getTablePage(strFROMNet, null, "Comuni_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtComuni.Rows.Count > 0) { 
                  strWHERENet = "Comuni_Istat='" + dtCsvEstinzione.Rows[i]["Istat nuovo"].ToString().Trim() + "'";
                  strFROMNet = "Comuni";
                  strORDERNet = "Comuni_Comune";
                  dtComuniNuovo = Smartdesk.Sql.getTablePage(strFROMNet, null, "Comuni_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtComuniNuovo.Rows.Count > 0) { 
                      strSQL = "UPDATE Anagrafiche SET Comuni_Ky=" + dtComuniNuovo.Rows[0]["Comuni_Ky"].ToString() + " WHERE Comuni_Ky=" + dtComuni.Rows[0]["Comuni_Ky"].ToString();
                      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                      strSQL = "UPDATE Aste SET Comuni_Ky=" + dtComuniNuovo.Rows[0]["Comuni_Ky"].ToString() + " WHERE Comuni_Ky=" + dtComuni.Rows[0]["Comuni_Ky"].ToString();
                      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                      strSQL = "UPDATE CMSLink SET Comuni_Ky=" + dtComuniNuovo.Rows[0]["Comuni_Ky"].ToString() + " WHERE Comuni_Ky=" + dtComuni.Rows[0]["Comuni_Ky"].ToString();
                      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                      strSQL = "UPDATE ImmobiliZona SET Comuni_Ky=" + dtComuniNuovo.Rows[0]["Comuni_Ky"].ToString() + " WHERE Comuni_Ky=" + dtComuni.Rows[0]["Comuni_Ky"].ToString();
                      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                      strSQL = "UPDATE LocalitaVacanze SET Comuni_Ky=" + dtComuniNuovo.Rows[0]["Comuni_Ky"].ToString() + " WHERE Comuni_Ky=" + dtComuni.Rows[0]["Comuni_Ky"].ToString();
                      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                      strSQL = "UPDATE Persone SET Comuni_Ky=" + dtComuniNuovo.Rows[0]["Comuni_Ky"].ToString() + " WHERE Comuni_Ky=" + dtComuni.Rows[0]["Comuni_Ky"].ToString();
                      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                      strSQL = "UPDATE Utenti SET Comuni_Ky=" + dtComuniNuovo.Rows[0]["Comuni_Ky"].ToString() + " WHERE Comuni_Ky=" + dtComuni.Rows[0]["Comuni_Ky"].ToString();
                      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                      strSQL = "UPDATE Veicoli SET Comuni_Ky=" + dtComuniNuovo.Rows[0]["Comuni_Ky"].ToString() + " WHERE Comuni_Ky=" + dtComuni.Rows[0]["Comuni_Ky"].ToString();
                      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            }
          }
        }
      }
      Response.Write("Comuni Aggiornati");
    }
    else
    {
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

  public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App)
  {
    DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
    return dt;
  }

}
