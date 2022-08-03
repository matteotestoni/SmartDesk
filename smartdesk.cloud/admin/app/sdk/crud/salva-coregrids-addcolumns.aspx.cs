using System;
using System.Data;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public DataTable dtCoreGridsColumns;
    public int intNumRecords = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
    	string strCoreGrids_Ky=Request["CoreGrids_Ky"];
    	string strCoreEntities_Ky=Request["CoreEntities_Ky"];
     	string strCoreModules_Ky=Request["CoreModules_Ky"];
      string strCoreAttributes_Attributi=Request["CoreAttributes_Attributi"];
      string strSQL="";
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
      int intOrdine=1;

      if (Smartdesk.Login.Verify){
        
        strCoreAttributes_Attributi=Request["CoreAttributes_Attributi"];
        string[] words = strCoreAttributes_Attributi.Split(',');
        foreach (var word in words)
        {
          strWHERENet="CoreGrids_Ky=" + strCoreGrids_Ky + " AND CoreAttributes_Ky=" + word;
          strORDERNet = "CoreGridsColumns_Ky";
          strFROMNet = "CoreGridsColumns";
          dtCoreGridsColumns = new DataTable("CoreGridsColumns");
          dtCoreGridsColumns = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGridsColumns_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtCoreGridsColumns.Rows.Count<1){
              strSQL="INSERT INTO CoreGridsColumns (CoreGrids_Ky,CoreAttributes_Ky,CoreGridsColumns_Width,CoreGridsColumns_Order,CoreGridsColumns_Link,CoreGridsColumns_Renderer)";
              strSQL+=" VALUES (";
              strSQL+=strCoreGrids_Ky + ",";
              strSQL+=word + ",";
              strSQL+="40,";
              strSQL+=intOrdine + ",";
              strSQL+="0,";
              strSQL+="Null";
              strSQL+=")";
              //Response.Write(strSQL + "<hr>");
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
           }
          intOrdine=intOrdine+1;
        }
        strSQL="DELETE FROM CoreGridsColumns WHERE CoreGrids_Ky=" + strCoreGrids_Ky + " AND CoreAttributes_Ky NOT IN(" + strCoreAttributes_Attributi + ")";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        //Response.Write(strSQL + "<hr>");
				Response.Redirect("/admin/app/sdk/scheda-coregrids.aspx?salvato=salvato&CoreModules_Ky=" + strCoreModules_Ky + "&CoreGrids_Ky=" + strCoreGrids_Ky);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
