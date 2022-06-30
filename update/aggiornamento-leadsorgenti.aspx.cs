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
    public DataTable dtLeadSorgenti;
    public int intKy;

    protected void Page_Load(object sender, EventArgs e)
    {
        string strDirectory="";
        string strSQL="";
        string strWHERENet = "";
        string strORDERNet = "";
        string strFROMNet = "";
        
        
        
            strH1="Aggiornamento Lead Sorgenti";

            strWHERENet="";
            strFROMNet = "LeadSorgenti";
            strORDERNet = "LeadSorgenti_Ky ASC";
            dtLeadSorgenti = new DataTable("LeadSorgenti");
            dtLeadSorgenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadSorgenti_Ky", strWHERENet, strORDERNet, 1,100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		        for (int i = 0; i < dtLeadSorgenti.Rows.Count; i++){
              strSQL="UPDATE Lead SET LeadSorgenti_Ky=" + dtLeadSorgenti.Rows[i]["LeadSorgenti_Ky"].ToString() + " WHERE Lead_Link like '%https://" + dtLeadSorgenti.Rows[i]["LeadSorgenti_Titolo"].ToString() + "%';";
              Response.Write(strSQL + "<br>");
              intKy=new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
            strRisultato="fatto";
    }            
    
    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
      DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
      return dt;
    }
}
