using System;
using System.Data;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public string strLead_Ky = "";
    public DataTable dtLead;
    public DataTable dtOpportunita;


    public DataTable dtOpportunitaStati;    
    public string strAnagrafiche_Ky="";
    public string strOpportunita_Ky="";
    public string strAttivitaTipo_Ky="";
    public string strSorgente="";
    public string strAttivita_Descrizione="";
    
    public DataTable dtLogin;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strWHERENet = "";
      string strORDERNet = "";
      string strFROMNet = "";
      
      
	  
      if (Smartdesk.Login.Verify){
        dtLogin = Smartdesk.Data.Read("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
		    strLead_Ky=Smartdesk.Current.Request("Lead_Ky");
        strWHERENet = "Lead_Ky=" + strLead_Ky;
        strORDERNet = "Opportunita_Ky";
        strFROMNet = "Opportunita";
        dtOpportunita = new DataTable("Opportunita");
        dtOpportunita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Opportunita_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtOpportunita.Rows.Count<1){
          creaTrattativa();
        strWHERENet = "Lead_Ky=" + strLead_Ky;
          strORDERNet = "Opportunita_Ky";
          strFROMNet = "Opportunita";
          dtOpportunita = new DataTable("Opportunita");
          dtOpportunita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Opportunita_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          strOpportunita_Ky = dtOpportunita.Rows[0]["Opportunita_Ky"].ToString();
          strSQL = "UPDATE Lead SET LeadStato_Ky=3, Opportunita_Ky=" + strOpportunita_Ky + " WHERE Lead_Ky=" + strLead_Ky;
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        }else{
          strSQL = "UPDATE Lead SET LeadStato_Ky=3 WHERE Lead_Ky=" + strLead_Ky;
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
          strOpportunita_Ky = dtOpportunita.Rows[0]["Opportunita_Ky"].ToString();
        }
        Response.Redirect("/admin/app/commerciale/scheda-opportunita.aspx?Opportunita_Ky=" + strOpportunita_Ky);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    public bool creaTrattativa(){
        string strSQL="";
	    strSQL = "INSERT INTO Opportunita";
        strSQL += " (Lead_Ky, Opportunita_Titolo, OpportunitaStati_Ky, Opportunita_Stato, Anagrafiche_Ky, Opportunita_Data, Utenti_Ky, Opportunita_Note, utm_source, utm_medium, utm_campaign, Prodotti_Ky, Annunci_Ky, Cantieri_Ky, Veicoli_Ky, Immobili_Ky, Servizi_Ky, Aste_Ky, Commesse_Ky, Spese_Ky, Documenti_Ky, Note_Ky, Opportunita_UserInsert, Opportunita_DateInsert)";
        strSQL += " SELECT ";
        strSQL += strLead_Ky + ",";
        strSQL += "Lead_Titolo,";
        strSQL += "5,";
        strSQL += "'creata da Lead',";
        strSQL += "Anagrafiche_Ky,";
        strSQL += "GETDATE(),";
        strSQL += Smartdesk.Session.CurrentUser.ToString() + ",";
        strSQL += "Lead_Note,";
        strSQL += "utm_source,";
        strSQL += "utm_medium,";
        strSQL += "utm_campaign,";
        strSQL += "Prodotti_Ky, Annunci_Ky, Cantieri_Ky, Veicoli_Ky, Immobili_Ky, Servizi_Ky, Aste_Ky, Commesse_Ky, Spese_Ky, Documenti_Ky, Note_Ky,";
        strSQL += Smartdesk.Session.CurrentUser.ToString() + ",";
        strSQL += "GETDATE()";
        strSQL += " FROM Lead";
        strSQL += " WHERE Lead_Ky=" + strLead_Ky;
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        return true;
    } 

	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
