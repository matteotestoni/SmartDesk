using System;
using System.Data;
using System.Data.SqlClient;


public partial class _Default : System.Web.UI.Page 
{
    
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public DataTable dtProdotti;
    public string strH1 = "Esporta prodotti";
    public int intRecxPag = 1000;
    public int intPage = 0;
    public int intNumPagine=1;
    public int intNumRecords = 0;
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
      string strPage="";

      
      strPage = Request["page"];
      if ((strPage == null) || (strPage == "")){
        intPage = 1;
      }
      else{
        intPage = Convert.ToInt32(strPage);
      }
      strWHERENet="";             
      strFROMNet = "Prodotti_Vw";
      strORDERNet = "Prodotti_Ky DESC";
      dtProdotti = new DataTable("Prodotti");
      dtProdotti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Prodotti_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    }    

    public String sistemaCampo(string strIN){
        string strOUT;    
        strOUT=strIN.Replace("\"","&quot;").Replace("à","&agrave;").TrimEnd(new char[] { '\r', '\n' });
        return strOUT;
    }

	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
