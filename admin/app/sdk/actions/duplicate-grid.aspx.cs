using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strKy="";
    public int intKy = 0;
    public long longKy = 0;
    public string strCoreGrids_Ky="";
    public string strCoreEntities_Ky="";
    public string strCoreModules_Ky="";
    public string strSorgente="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

	  
      if (Smartdesk.Login.Verify){
            strCoreGrids_Ky=Smartdesk.Current.Request("CoreGrids_Ky");
            strCoreEntities_Ky = Smartdesk.Current.Request("CoreEntities_Ky");
            strCoreModules_Ky=Smartdesk.Current.Request("CoreModules_Ky");
            strSorgente=Smartdesk.Current.Request("sorgente");
            strSQL= "INSERT INTO CoreGrids (CoreEntities_Ky, CoreGrids_Custom, CoreGrids_Default, CoreGrids_Title, CoreGrids_Order, CoreGrids_SQLFrom, CoreGrids_SQLWhere, CoreGrids_SQLOrder)";
			      strSQL+= "SELECT CoreEntities_Ky, CoreGrids_Custom, CoreGrids_Default, 'Copy of ' + CoreGrids_Title, CoreGrids_Order, CoreGrids_SQLFrom, CoreGrids_SQLWhere, CoreGrids_SQLOrder FROM CoreGrids WHERE CoreGrids_Ky = " + strCoreGrids_Ky;
            longKy = new Smartdesk.Sql().SQLScriptExecuteNonQueryKy(strSQL, "CoreGrids", "CoreGrids_Ky");

            strSQL = "INSERT INTO CoreGridsColumns (CoreGrids_Ky,CoreAttributes_Ky,CoreGridsColumns_Width,CoreGridsColumns_Order,CoreGridsColumns_Link,CoreGridsColumns_Label,CoreGridsColumns_Renderer)";
            strSQL += " SELECT " + longKy.ToString() + ",CoreAttributes_Ky,CoreGridsColumns_Width,CoreGridsColumns_Order,CoreGridsColumns_Link,CoreGridsColumns_Label,CoreGridsColumns_Renderer FROM CoreGridsColumns WHERE CoreGrids_Ky = " + strCoreGrids_Ky;
            intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            
            strSQL = "INSERT INTO UsergroupsGrids (CoreGrids_Ky,UtentiGruppi_Ky,UsergroupsGrids_UserInsert,UsergroupsGrids_DateInsert)";
            strSQL += " SELECT " + longKy.ToString() + ",UtentiGruppi_Ky,UsergroupsGrids_UserInsert,GETDATE() FROM UsergroupsGrids WHERE CoreGrids_Ky = " + strCoreGrids_Ky;
            intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);      
            Response.Write(intKy.ToString());
            switch (strSorgente){
                  case "scheda-coregrids":
                    Response.Redirect("/admin/app/sdk/scheda-coreentities.aspx?CoreModules_Ky=" + strCoreModules_Ky + "&CoreEntities_Ky=" + strCoreEntities_Ky);
                    break;
                  case "scheda-coreentities":
                    Response.Redirect("/admin/app/sdk/scheda-coreentities.aspx?CoreModules_Ky=" + strCoreModules_Ky + "&CoreEntities_Ky=" + strCoreEntities_Ky);
                    break;
		          default:
                    Response.Redirect("/admin/app/sdk/scheda-coreentities.aspx?CoreModules_Ky=" + strCoreModules_Ky + "&CoreEntities_Ky=" + strCoreEntities_Ky);
		            break;
                }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
