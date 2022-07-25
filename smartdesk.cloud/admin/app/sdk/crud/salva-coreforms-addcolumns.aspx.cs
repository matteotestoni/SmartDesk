using System;
using System.Data;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public DataTable dtCoreFormsFields;
    public int intNumRecords = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
    	string strCoreForms_Ky=Request["CoreForms_Ky"];
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
          strWHERENet="CoreForms_Ky=" + strCoreForms_Ky + " AND CoreAttributes_Ky=" + word;
          strORDERNet = "CoreFormsFields_Ky";
          strFROMNet = "CoreFormsFields";
          dtCoreFormsFields = new DataTable("CoreFormsFields");
          dtCoreFormsFields = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsFields_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtCoreFormsFields.Rows.Count<1){
              strSQL="INSERT INTO CoreFormsFields (CoreForms_Ky,CoreAttributes_Ky,CoreFormsFields_Order,CoreFormsFields_Columns,CoreFormsFields_UserInsert,CoreFormsFields_DateInsert)";
              strSQL+=" VALUES (";
              strSQL+=strCoreForms_Ky + ",";
              strSQL+=word + ",";
              strSQL+=intOrdine + ",";
              strSQL+=6 + ",";
              strSQL+="0,";
              strSQL+="GETDATE()";
              strSQL+=")";
              //Response.Write(strSQL + "<hr>");
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
           }
          intOrdine=intOrdine+1;
        }
        strSQL="DELETE FROM CoreFormsFields WHERE CoreForms_Ky=" + strCoreForms_Ky + " AND CoreAttributes_Ky NOT IN(" + strCoreAttributes_Attributi + ")";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        //Response.Write(strSQL + "<hr>");
				Response.Redirect("/admin/app/sdk/scheda-CoreForms.aspx?salvato=salvato&CoreModules_Ky=" + strCoreModules_Ky + "&CoreForms_Ky=" + strCoreForms_Ky);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
