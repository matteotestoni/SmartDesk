using System;
using System.Data;
using System.Data.SqlClient;

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

    protected void Page_Load(object sender, EventArgs e)
    {
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          strH1="Aggiornamento SDK";
          strRisultato += "<b>Aggiornamento SDK</b><br>";
          

					strWHERENet="CoreAttributes_Label Is Null";
					strFROMNet = "CoreAttributes";
					strORDERNet = "CoreAttributes_Ky";
					dtCoreAttributes = new DataTable("CoreAttributes");
					dtCoreAttributes = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreAttributes_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		    	for (int i = 0; i < dtCoreAttributes.Rows.Count; i++){
		    		if (dtCoreAttributes.Rows[i]["CoreAttributes_Code"].ToString().Split('_').Length>1){
							strTitle= dtCoreAttributes.Rows[i]["CoreAttributes_Code"].ToString().Split('_')[1];
						}else{
							strTitle= dtCoreAttributes.Rows[i]["CoreAttributes_Code"].ToString();
						}
				   	strSQL="UPDATE CoreAttributes SET CoreAttributes_Label='" + strTitle + "' WHERE CoreAttributes_Ky=" + dtCoreAttributes.Rows[i]["CoreAttributes_Ky"].ToString();
						new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
					}



					strWHERENet="";
					strFROMNet = "CoreModules";
					strORDERNet = "CoreModules_Ky";
					dtCoreModules = new DataTable("CoreModules");
					dtCoreModules = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModules_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		    	for (int i = 0; i < dtCoreModules.Rows.Count; i++){
						strWHERENet="CoreModules_Ky=" + dtCoreModules.Rows[i]["CoreModules_Ky"].ToString();
						strFROMNet = "CoreEntities";
						strORDERNet = "CoreEntities_Ky";
						dtCoreEntities = new DataTable("CoreEntities");
						dtCoreEntities = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		    		for (int j = 0; j < dtCoreEntities.Rows.Count; j++){
							strWHERENet="CoreEntities_Ky=" + dtCoreEntities.Rows[j]["CoreEntities_Ky"].ToString();
							strFROMNet = "CoreGrids";
							strORDERNet = "CoreGrids_Ky";
							dtCoreGrids = new DataTable("CoreGrids");
							dtCoreGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGrids_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
							if (dtCoreGrids.Rows.Count<1){
									strSQL="INSERT INTO CoreGrids (CoreEntities_Ky,CoreGrids_Title,CoreGrids_Order,CoreGrids_SQLWhere,CoreGrids_SQLOrder,CoreGrids_UserInsert,CoreGrids_UserUpdate,CoreGrids_UserDelete,CoreGrids_DateInsert,CoreGrids_DateUpdate,CoreGrids_DateDelete)";
									strSQL+=" VALUES (" + dtCoreEntities.Rows[j]["CoreEntities_Ky"].ToString();
									strSQL+=",'Tutte le " + dtCoreEntities.Rows[j]["CoreEntities_LabelPlural"].ToString() + "'";
	 								strSQL+=",1";
	 								strSQL+=",Null";
	 								strSQL+=",Null";
	 								strSQL+=",1";
	 								strSQL+=",1";
	 								strSQL+=",1";
	 								strSQL+=",GETDATE()";
	 								strSQL+=",GETDATE()";
	 								strSQL+=",GETDATE())";
	 								//Response.Write(strSQL + "<hr>");
				        	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
							}else{
									strWHERENet="CoreGrids_Ky=" + dtCoreGrids.Rows[0]["CoreGrids_Ky"].ToString();
									strFROMNet = "CoreGridsColumns";
									strORDERNet = "CoreGridsColumns_Ky";
									dtCoreGridsColumns = new DataTable("CoreGridsColumns");
									dtCoreGridsColumns = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGridsColumns_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
									if (dtCoreGridsColumns.Rows.Count<1){
										strWHERENet="CoreAttributes_System=0 AND CoreEntities_Ky=" + dtCoreEntities.Rows[j]["CoreEntities_Ky"].ToString();
										strFROMNet = "CoreAttributes";
										strORDERNet = "CoreAttributes_Ky";
										dtCoreAttributes = new DataTable("CoreAttributes");
										dtCoreAttributes = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreAttributes_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
										intOrder=1;
										for (int x = 0; x < dtCoreAttributes.Rows.Count; x++){
											strSQL="INSERT INTO CoreGridsColumns (CoreGrids_Ky,CoreAttributes_Ky,CoreGridsColumns_Width,CoreGridsColumns_Order)";
											strSQL+=" VALUES (" + dtCoreGrids.Rows[0]["CoreGrids_Ky"].ToString() + "," + dtCoreAttributes.Rows[x]["CoreAttributes_Ky"].ToString() + ",30," + intOrder + ")";
			 								//Response.Write(strSQL + "<hr>");
						        	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
						        	intOrder++;
					    			}
									}
							}							
						}
					}

          
      }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
}
