using System;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    
    public int intNumRecords = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    public string strH1="Pagamenti > Pagamenti da fare";
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
            strFROMNet = "Pagamenti_Vw";
            strWHERENet= "(Pagamenti_Pagato!='si' AND Pagamenti_Data>=GETDATE() And PagamentiTipo_Ky=2)";
            strORDERNet = "Pagamenti_Data, Anagrafiche_Ky";
            dtPagamentiFuturi = new DataTable("PagamentiFuturi");
            dtPagamentiFuturi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
 
            strFROMNet = "Pagamenti_Vw";
            strWHERENet= "(Pagamenti_Pagato!='si' AND Pagamenti_Data<GETDATE() And PagamentiTipo_Ky=2)";
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
}
