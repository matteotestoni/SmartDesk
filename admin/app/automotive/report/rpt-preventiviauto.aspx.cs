using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

public partial class _Default : System.Web.UI.Page 
{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtUtenti;
    public DataTable dtAnagrafiche;
    public DataTable dtPreventiviAuto;
    public DataTable dtPreventiviAutoProdotti;
    public DataTable dtPagamenti;
    public DataTable dtAzienda;
    public int intAnagrafiche_Ky = 0;
    public string strAnagrafiche_Ky = "";
    public string strPreventiviAuto_Ky = "";
    public string strAziende_Ky = "1";
    public string strFROMNet = "";
    public string strH1 = "";
    
    public decimal decTotale=0;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strSQL = "";
      int intKy = 0;

      
      
	  
      //Smartdesk.Session.CurrentUser.ToString()="1";
		  if (Smartdesk.Login.Verify){
            dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strPreventiviAuto_Ky=Smartdesk.Current.Request("PreventiviAuto_Ky");
            if (strPreventiviAuto_Ky==null || strPreventiviAuto_Ky.Length<1){
                strPreventiviAuto_Ky="1";
            }
            strWHERENet="PreventiviAuto_Ky=" + strPreventiviAuto_Ky;
            strORDERNet = "PreventiviAuto_Ky";
            strFROMNet = "PreventiviAuto_Vw";
            dtPreventiviAuto = new DataTable("Documenti");
            dtPreventiviAuto = Smartdesk.Sql.getTablePage(strFROMNet, null, "PreventiviAuto_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
	          strAnagrafiche_Ky=dtPreventiviAuto.Rows[0]["Anagrafiche_Ky"].ToString();            
            
            strWHERENet="PreventiviAuto_Ky=" + strPreventiviAuto_Ky;
            strORDERNet = "PreventiviAutoProdotti_Ky Desc";
            strFROMNet = "PreventiviAutoProdotti";
            dtPreventiviAutoProdotti = new DataTable("PreventiviAutoProdotti");
            dtPreventiviAutoProdotti = Smartdesk.Sql.getTablePage(strFROMNet, null, "PreventiviAutoProdotti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strWHERENet="Utenti_Ky=" + dtPreventiviAuto.Rows[0]["Utenti_Ky"].ToString();
            strORDERNet = "Utenti_Ky";
            strFROMNet = "Utenti_Vw";
            dtUtenti = new DataTable("Utenti");
            dtUtenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

            strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
            strORDERNet = "Anagrafiche_Ky";
            strFROMNet = "Anagrafiche_Vw";
            dtAnagrafiche = new DataTable("Anagrafiche");
            dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

            strWHERENet="Aziende_Ky=" + strAziende_Ky;
            strORDERNet = "Aziende_Ky";
            strFROMNet = "Aziende_Vw";
            dtAzienda = new DataTable("Azienda");
            dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

            strSQL="UPDATE PreventiviAuto SET PreventiviAutoStati_Ky=3 WHERE PreventiviAutoStati_Ky Is Null AND PreventiviAuto_Ky=" + Smartdesk.Current.Request("PreventiviAuto_Ky");
            intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    public String GetUTF(string strTestoIn)
    {
      string strTestoOut="";
      if (strTestoIn!=null){
        strTestoOut=strTestoIn.Replace(".","").Replace("&","").Replace("snc","").Replace(" ","-").Replace("--","-");
      }else{
        strTestoOut="";
      }
      return strTestoOut;
    }   
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
