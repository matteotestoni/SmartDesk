using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using System.Text;

  public partial class _Default : System.Web.UI.Page 
	{
    public DataTable dtCoreAttributes;
    public DataTable dtCoreModules;
    public DataTable dtCoreModulesOptions;
    public DataTable dtCoreModulesOptionsValue;
    public DataTable dtCoreEntities;
    public DataTable dtCoreGrids;
    public int intNumRecords = 0;
    public string strEntities = "";
    protected void Page_Load(object sender, EventArgs e)
    {
    	string strKy="";
      string strPath="";
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
      string strSQL="";
      SqlConnection conn;

      if (Smartdesk.Login.Verify){
        conn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
        conn.Open();        

				Dictionary<string, object> frm = new Dictionary<string, object>();
				if (Smartdesk.Current.Request("CoreModules_Active") == "") frm.Add("CoreModules_Active", false);
				strKy = Smartdesk.Functions.SqlWriteKey("CoreModules",frm);
        
        strWHERENet="CoreModules_Ky=" + strKy;
        strORDERNet = "CoreModules_Ky";
        strFROMNet = "CoreModules";
        dtCoreModules = new DataTable("CoreModules");
        dtCoreModules = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModules_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        
        strWHERENet="CoreModules_Ky=" + strKy;
        strORDERNet = "CoreModulesOptions_Ky";
        strFROMNet = "CoreModulesOptions";
        dtCoreModulesOptions = new DataTable("CoreModulesOptions");
        dtCoreModulesOptions = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptions_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        
        //creo le directory
        strPath="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/";
        strPath=Server.MapPath(strPath);
        if (!Directory.Exists(strPath)) {
          DirectoryInfo di = Directory.CreateDirectory(strPath);
        }
        strPath="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/crud/";
        strPath=Server.MapPath(strPath);
        if (!Directory.Exists(strPath)) {
          DirectoryInfo di = Directory.CreateDirectory(strPath);
        }
        strPath="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/forms/";
        strPath=Server.MapPath(strPath);
        if (!Directory.Exists(strPath)) {
          DirectoryInfo di = Directory.CreateDirectory(strPath);
        }
        strPath="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/where/";
        strPath=Server.MapPath(strPath);
        if (!Directory.Exists(strPath)) {
          DirectoryInfo di = Directory.CreateDirectory(strPath);
        }
        strPath="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/actions/";
        strPath=Server.MapPath(strPath);
        if (!Directory.Exists(strPath)) {
          DirectoryInfo di = Directory.CreateDirectory(strPath);
        }                
        strPath="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/report/";
        strPath=Server.MapPath(strPath);
        if (!Directory.Exists(strPath)) {
          DirectoryInfo di = Directory.CreateDirectory(strPath);
        }                
        dtCoreGrids = new DataTable("CoreGrids");

        strWHERENet="CoreModules_Ky=" + strKy;
        strORDERNet = "CoreEntities_Ky";
        strFROMNet = "CoreEntities";
        dtCoreEntities = new DataTable("CoreEntities");
        dtCoreEntities = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        for (int i = 0; i < dtCoreEntities.Rows.Count; i++){
          //sistemazioni chiavi tabella
            strSQL="UPDATE CoreAttributes SET CoreAttributes_Key=1 WHERE CoreAttributes_Key=0 AND CoreAttributes_Code='" + dtCoreEntities.Rows[i]["CoreEntities_Key"].ToString() + "' AND CoreEntities_Ky=" +  dtCoreEntities.Rows[i]["CoreEntities_Ky"].ToString();
            //Response.Write(strSQL);
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
          
          if (strEntities.Length>0){
            strEntities+=",\"" + dtCoreEntities.Rows[i]["CoreEntities_Code"].ToString() + "\"";
          }else{
            strEntities="\"" + dtCoreEntities.Rows[i]["CoreEntities_Code"].ToString() + "\"";
          }
          strWHERENet="CoreEntities_Ky=" +  dtCoreEntities.Rows[i]["CoreEntities_Ky"].ToString();
          strORDERNet = "CoreGrids_Default DESC";
          strFROMNet = "CoreGrids";
          dtCoreGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGrids_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                    
          //elimina
          if (Convert.ToBoolean(dtCoreEntities.Rows[i]["CoreEntities_CustomDelete"])==true){
            strPath="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/crud/elimina-" + dtCoreEntities.Rows[i]["CoreEntities_Code"].ToString() + ".aspx.cs";
            strPath=Server.MapPath(strPath);
            if (!File.Exists(strPath)) {
              using(StreamWriter sw = File.AppendText(strPath))
              {

                  sw.WriteLine("using System;");
                  sw.WriteLine("public partial class _Default : System.Web.UI.Page");
                  sw.WriteLine("{");
                  sw.WriteLine("    protected void Page_Load(object sender, EventArgs e){");
                  sw.WriteLine("        string strRedirect = Smartdesk.Current.LoginPageRoot;");
                  sw.WriteLine("        string strSorgente = Smartdesk.Current.Request(\"sorgente\");");
                  sw.WriteLine("        string strDeletemultiplo = Smartdesk.Current.Request(\"deletemultiplo\");");
                  sw.WriteLine("        string strIds = Smartdesk.Current.Request(\"azionidigruppo-ids\");");

                  sw.WriteLine("        if (Smartdesk.Login.Verify){");
                  sw.WriteLine("            if (strDeletemultiplo==\"deletemultiplo\"){");
                  sw.WriteLine("                Smartdesk.Functions.SqlDeleteKeyIn(\"" + dtCoreEntities.Rows[i]["CoreEntities_Code"].ToString() + "\",strIds);");
                  sw.WriteLine("            }else{");
                  sw.WriteLine("                Smartdesk.Functions.SqlDeleteKey(\"" + dtCoreEntities.Rows[i]["CoreEntities_Code"].ToString() + "\");");
                  sw.WriteLine("            }");
                  sw.WriteLine("            strRedirect=\"/admin/view.aspx?CoreModules_Ky=" + strKy + "&CoreEntities_Ky=" + dtCoreEntities.Rows[i]["CoreEntities_Ky"].ToString() + "&CoreGrids_Ky=" + dtCoreGrids.Rows[0]["CoreGrids_Ky"].ToString() + "\";");
                  sw.WriteLine("        	Response.Redirect(strRedirect);");
                  sw.WriteLine("        }else{");
                  sw.WriteLine("            Response.Redirect(Smartdesk.Current.LoginPageRoot);");
                  sw.WriteLine("        }");
                  sw.WriteLine("    }");
                  sw.WriteLine("}");                  
                  sw.Close();
              } 
            }
            strPath="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/crud/elimina-" + dtCoreEntities.Rows[i]["CoreEntities_Code"].ToString() + ".aspx";
            strPath=Server.MapPath(strPath);
            if (!File.Exists(strPath)) {
              using(StreamWriter sw = File.AppendText(strPath))
              {
                  sw.WriteLine("<%@ Page codepage=\"1252\" Language=\"C#\" AutoEventWireup=\"true\" Debug=\"true\" CodeFile=\"/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/crud/elimina-" + dtCoreEntities.Rows[i]["CoreEntities_Code"].ToString() + ".aspx.cs\" Inherits=\"_Default\"%>");                    
                  sw.Close();
              } 
            }
          }


          //salva
          if (Convert.ToBoolean(dtCoreEntities.Rows[i]["CoreEntities_CustomSave"])==true){
            strPath="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/crud/salva-" + dtCoreEntities.Rows[i]["CoreEntities_Code"].ToString() + ".aspx";
            strPath=Server.MapPath(strPath);
            if (!File.Exists(strPath)) {
              using(StreamWriter sw = File.AppendText(strPath))
              {
                  sw.WriteLine("<%@ Page codepage=\"1252\" Language=\"C#\" AutoEventWireup=\"true\" Debug=\"true\" CodeFile=\"/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/crud/salva-" + dtCoreEntities.Rows[i]["CoreEntities_Code"].ToString() + ".aspx.cs\" Inherits=\"_Default\"%>");                    
                  sw.Close();
              } 
            }
            strPath="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/crud/salva-" + dtCoreEntities.Rows[i]["CoreEntities_Code"].ToString() + ".aspx.cs";
            strPath=Server.MapPath(strPath);
            if (!File.Exists(strPath)) {
              using(StreamWriter sw = File.AppendText(strPath))
              {

                  sw.WriteLine("using System;");
                  sw.WriteLine("using System.Collections.Generic;");
                  sw.WriteLine("using System.Data;");
                  sw.WriteLine("using System.Data.SqlClient;");
                  sw.WriteLine("public partial class _Default : System.Web.UI.Page");
                  sw.WriteLine("{");
                  sw.WriteLine("public int intNumRecords = 0;");
                  sw.WriteLine("    protected void Page_Load(object sender, EventArgs e)");
                  sw.WriteLine("    {");
                  sw.WriteLine("        string strKy = \"\";");
                  sw.WriteLine("        DataTable dtRecord;");
                  sw.WriteLine("        string strSQL = \"\";");
                  sw.WriteLine("        string strRedirect = Smartdesk.Current.LoginPageRoot;");
                  sw.WriteLine("        bool boolAjax = false;");
                  sw.WriteLine("        if (Smartdesk.Login.Verify)");
                  sw.WriteLine("        {");
                  sw.WriteLine("          Dictionary<string, object> frm = new Dictionary<string, object>();");
                  //ciclo tutti i bit e metto il salvataggio
                  strWHERENet="CoreAttributesType_Ky=4 AND CoreEntities_Ky=" + dtCoreEntities.Rows[i]["CoreEntities_Ky"].ToString();
                  strORDERNet = "CoreAttributes_Ky";
                  strFROMNet = "CoreAttributes";
                  dtCoreAttributes = new DataTable("CoreAttributes");
                  dtCoreAttributes = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreAttributes_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  for (int j = 0; j < dtCoreAttributes.Rows.Count; j++){
                    sw.WriteLine("      	  if (Smartdesk.Current.Request(\"" + dtCoreAttributes.Rows[j]["CoreAttributes_Code"].ToString() + "\") == \"\") frm.Add(\"" + dtCoreAttributes.Rows[j]["CoreAttributes_Code"].ToString() + "\", false);");
                  }
                  sw.WriteLine("          boolAjax = Convert.ToBoolean(Request[\"ajax\"]);");
                  sw.WriteLine("          strKy = Smartdesk.Functions.SqlWriteKey(\"" + dtCoreEntities.Rows[i]["CoreEntities_Code"].ToString() + "\", frm);");

                  sw.WriteLine("          if (boolAjax==true){");
                  sw.WriteLine("            Response.Write(\"ok\");");
                  sw.WriteLine("          }else{");
                  sw.WriteLine("            strRedirect = \"/admin/view.aspx?CoreModules_Ky=" + strKy + "&CoreEntities_Ky=" + dtCoreEntities.Rows[i]["CoreEntities_Ky"].ToString() + "&CoreGrids_Ky=" + dtCoreGrids.Rows[0]["CoreGrids_Ky"].ToString() + "\";");
                  sw.WriteLine("            Response.Redirect(strRedirect);");
                  sw.WriteLine("          }");
                  sw.WriteLine("        }");
                  sw.WriteLine("        Response.Redirect(strRedirect);");
                  sw.WriteLine("    }");
                  sw.WriteLine("}");              
                  sw.Close();
              } 
            }
          }
        }
        
        //classe
        strPath="/App_Code/Smartdesk." + FirstCharToUpper(dtCoreModules.Rows[0]["CoreModules_Code"].ToString()) + ".cs";
        strPath=Server.MapPath(strPath);
        //if (!File.Exists(strPath)) {
          using(StreamWriter sw = File.CreateText(strPath))
          {
              sw.WriteLine("namespace Smartdesk{\n");                     
              sw.WriteLine("  public static class " + FirstCharToUpper(dtCoreModules.Rows[0]["CoreModules_Code"].ToString()) + "{");                     
              sw.WriteLine("    public static int CoreModules_Ky = " + dtCoreModules.Rows[0]["CoreModules_Ky"].ToString() + ";");                     
              sw.WriteLine("    public static string CoreModules_Code = \"" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "\";");                     
              sw.WriteLine("    public static string[] CoreEntities = {" + strEntities + "};");                     
              /*
              for (int i = 0; i < dtCoreEntities.Rows.Count; i++){
              
                sw.WriteLine("    class " + FirstCharToUpper(dtCoreEntities.Rows[i]["CoreEntities_Code"].ToString()) + "{");                     
                sw.WriteLine("      public int CoreEntities_Ky = " + dtCoreEntities.Rows[i]["CoreEntities_Ky"].ToString() + ";");                     
                sw.WriteLine("    }");                     
              }*/

              sw.WriteLine("  }");                     
              sw.WriteLine("\n}");                     
              sw.Close();
          } 
         
        //}
                
        //javascript
        strPath="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + ".js";
        strPath=Server.MapPath(strPath);
        if (!File.Exists(strPath)) {
          using(StreamWriter sw = File.AppendText(strPath))
          {
              sw.WriteLine("//javascript");                     
               sw.Close();
          } 
         
        }

        dtCoreModulesOptionsValue = new DataTable("CoreModulesOptionsValue");
        for (int i = 0; i < dtCoreModulesOptions.Rows.Count; i++){
          strWHERENet="CoreModulesOptions_Code='" + dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Code"].ToString() + "'";
          strORDERNet = "CoreModulesOptionsValue_Ky";
          strFROMNet = "CoreModulesOptionsValue";          
          dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtCoreModulesOptionsValue.Rows.Count<1){
            strSQL="INSERT INTO CoreModulesOptionsValue (CoreModulesOptions_Code,CoreModulesOptionsValue_Value) VALUES ('" + dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Code"].ToString() + "','" + dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Default"].ToString() + "')";
            //Response.Write(strSQL);
            new SqlCommand(strSQL, conn).ExecuteNonQuery();
          }
          
        }
				Response.Redirect("/admin/app/sdk/scheda-coremodules.aspx?salvato=salvato&CoreModules_Ky=" + strKy);
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
}
