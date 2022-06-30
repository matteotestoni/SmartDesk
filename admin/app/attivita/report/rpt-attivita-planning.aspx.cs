using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtAzienda;
    public DataTable dtAttivita;
    public string strFROMNet = "";
    public string strH1 = "";
    
    public DateTime dt;
    public string strPeriodo = "";
    public string strTipo = "";
    public string strCommesse_Ky = "";
    public string strAnagrafiche_Ky = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            
          strWHERENet="(Attivita_Completo=0)";
          strORDERNet = "Anagrafiche_RagioneSociale ASC, Attivita_Scadenza";
          strFROMNet = "Attivita_Planning_Vw";
          dtAttivita = new DataTable("Attivita_Planning");
          dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "chiave", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          strWHERENet="Aziende_Ky=1";
          strORDERNet = "Aziende_Ky";
          strFROMNet = "Aziende_Vw";
          dtAzienda = new DataTable("Azienda");
          dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
      }else{
            Response.Redirect("default.aspx");
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
