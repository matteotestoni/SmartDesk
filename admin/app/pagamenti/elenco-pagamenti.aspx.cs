using System;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    
    public int intNumRecords = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtPagamentiFuturi;
    public DataTable dtPagamentiScaduti;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public int intAnno = 0;
    public int intMese = 0;
    public DateTime dt;
    public decimal decTot=0; 
    public decimal decTotAttivi=0; 
    public decimal decTotNonAttivi=0; 
    public decimal decTotMese=0; 
    public string strColor="";
    
    public string strH1="Pagamenti > Incassi da ricevere e solleciti";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strPage="";
      int intPage = 0;

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
            
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strPage = Request["page"];
            if ((strPage == null) || (strPage == "")){
              intPage = 1;
            }
            else{
              intPage = Convert.ToInt32(strPage);
            }
            dt=DateTime.Now;
            int intYear=dt.Year;
            int intMonth=dt.Month;
            strFROMNet = "Pagamenti_Vw";
            //strWHERENet= "(Month(Pagamenti_Data)=" + intMonth + ") AND (Year(Pagamenti_Data)=" + intYear + ") AND (Pagamenti_Pagato!='si' AND Pagamenti_Data>=(GETDATE()-1) And PagamentiTipo_Ky=1)";
            strWHERENet= "(Year(Pagamenti_Data)=" + intYear + ") AND (Pagamenti_Pagato!='si' AND Pagamenti_Data>=(GETDATE()-1) And PagamentiTipo_Ky=1)";
            strORDERNet = "Pagamenti_Data, Anagrafiche_Ky";
            dtPagamentiFuturi = new DataTable("PagamentiFuturi");
            dtPagamentiFuturi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
 
            strFROMNet = "Pagamenti_Vw";
            strWHERENet= "(Pagamenti_Pagato!='si' AND Pagamenti_Data<=(GETDATE()-1) And PagamentiTipo_Ky=1)";
            strORDERNet = "Pagamenti_Data, Anagrafiche_Ky";
            dtPagamentiScaduti = new DataTable("PagamentiScaduti");
            dtPagamentiScaduti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
         }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
