using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public int intNumRecordsSidebar = 0;
    public int intNumRecordsToolbar = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ciit = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo cien = new System.Globalization.CultureInfo("en-US");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtCoreAttributes;
    public DataTable dtCoreModules;
    public DataTable dtCoreEntities;
    public DataTable dtCoreGrids;
    public DataTable dtCoreGridsColumns;
    public DataTable dtTemp;
    public string strFROMNet = "";
    public string strWHERENet = "";
    public string strORDERNet = "";
    public string strH1 = "";
    public string strRisultato = "";
    public string strTemp = "";
    public string strSQL = "";
    public string strTitle = "";
    public int intOrder = 0;
    public string strEntities = "";
    public string strPath="";

    protected void Page_Load(object sender, EventArgs e)
    {
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          strH1="Code generation";
          strRisultato += "<b>Code generation</b><br>";
					strWHERENet="";
					strFROMNet = "CoreModules";
					strORDERNet = "CoreModules_Order";
					dtCoreModules = new DataTable("CoreModules");
					dtCoreModules = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModules_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		    	for (int i = 0; i < dtCoreModules.Rows.Count; i++){
						strWHERENet="CoreModules_Ky=" + dtCoreModules.Rows[i]["CoreModules_Ky"].ToString();
						strFROMNet = "CoreEntities";
						strORDERNet = "CoreEntities_Order";
						dtCoreEntities = new DataTable("CoreEntities");
						dtCoreEntities = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		    		for (int j = 0; j < dtCoreEntities.Rows.Count; j++){
              if (strEntities.Length>0){
                strEntities+=",\"" + dtCoreEntities.Rows[j]["CoreEntities_Code"].ToString() + "\"";
              }else{
                strEntities="\"" + dtCoreEntities.Rows[j]["CoreEntities_Code"].ToString() + "\"";
              }
            }

            //classe
            strPath="/App_Code/Smartdesk." + FirstCharToUpper(dtCoreModules.Rows[i]["CoreModules_Code"].ToString()) + ".cs";
            strPath=Server.MapPath(strPath);
            //if (!File.Exists(strPath)) {
              using(StreamWriter sw = File.CreateText(strPath))
              {
                  sw.WriteLine("namespace Smartdesk{\n");                     
                  sw.WriteLine("  public static class " + FirstCharToUpper(dtCoreModules.Rows[i]["CoreModules_Code"].ToString()) + "{");                     
                  sw.WriteLine("    public static int CoreModules_Ky = " + dtCoreModules.Rows[i]["CoreModules_Ky"].ToString() + ";");                     
                  sw.WriteLine("    public static string CoreModules_Code = \"" + dtCoreModules.Rows[i]["CoreModules_Code"].ToString() + "\";");                     
                  sw.WriteLine("    public static string[] CoreEntities = {" + strEntities + "};");                     
                  sw.WriteLine("");  
                                     
                  for (int j = 0; j < dtCoreEntities.Rows.Count; j++){
                    sw.WriteLine("    public static string " + dtCoreEntities.Rows[j]["CoreEntities_Code"] + "_BeforeSave(){");
                    sw.WriteLine("      string strReturn=\"\";");
                    sw.WriteLine("      return strReturn;");
                	  sw.WriteLine("    }");
                    sw.WriteLine("");  
                    sw.WriteLine("    public static string " + dtCoreEntities.Rows[j]["CoreEntities_Code"] + "_AfterSave(string strKy){");
                    sw.WriteLine("      string strReturn=\"\";");
                    sw.WriteLine("      return strReturn;");
                	  sw.WriteLine("    }");
                    sw.WriteLine("");  
                  }
                  sw.WriteLine("  }");                     
                  sw.WriteLine("\n}");                     
                  sw.Close();
              } 
             
            //}
						}
      }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
  static string FirstCharToUpper(string s)
  {
      // Check for empty string.
      if (string.IsNullOrEmpty(s))
      {
          return string.Empty;
      }
      // Return char and concat substring.
      return char.ToUpper(s[0]) + s.Substring(1);
  }  

	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
