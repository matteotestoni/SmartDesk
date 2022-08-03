using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public int intAnagraficheProdotti_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "Ticket inviato";
    public int intNumDoc = 0;
    public int intNumDocVuoto = 0;
    public string strAzione = "modifica";
    public int intNumProdottiInseriti = 0;
    public int intNumProdottiMassimo = 0;
    public string strAnagrafiche_Ky = "";
    public DataTable dtTicketStati;
    public DataTable dtTicketCategorie;
    public DataTable dtLogin;
    public DataTable dtAnagraficheProdotti;
    public DataTable dtTicket;
    public DataTable dtAttivita;
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strTicket_Ky = "";
    public DateTime dateOggi;
    public bool boolEnableticket = false;
    public bool boolEnableprojects = false;
    public bool boolEnableproducts = false;

    protected void Page_Load(object sender, EventArgs e)
    {
    DataTable dtCoreModulesOptionsValue;
      
      strAnagrafiche_Ky=(FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-cliente"].Value)).UserData;
	  if (strAnagrafiche_Ky!=null){
          strWHERENet = "Anagrafiche_Ky =" + strAnagrafiche_Ky;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
            strAzione=Smartdesk.Current.Request("azione");
            dateOggi = DateTime.Now;
            
            strWHERENet = "";
            strORDERNet = "TicketStati_Ky";
            strFROMNet = "TicketStati";
            dtTicketStati = new DataTable("TicketStati");
            dtTicketStati = Smartdesk.Sql.getTablePage(strFROMNet, null, "TicketStati_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
            strWHERENet = "";
            strORDERNet = "TicketCategorie_Ky";
            strFROMNet = "TicketCategorie";
            dtTicketCategorie = new DataTable("TicketCategorie");
            dtTicketCategorie = Smartdesk.Sql.getTablePage(strFROMNet, null, "TicketCategorie_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
            strORDERNet = "AnagraficheProdotti_Ky";
            strFROMNet = "AnagraficheProdotti_Vw";
            dtAnagraficheProdotti = new DataTable("AnagraficheProdotti");
            dtAnagraficheProdotti = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheProdotti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  
            if (strAzione!="new"){
	            strWHERENet="Ticket_Ky=" + Smartdesk.Current.Request("Ticket_Ky");
	            strORDERNet = "Ticket_Ky";
	            strFROMNet = "Ticket_Vw";
	            dtTicket = new DataTable("Ticket");
	            dtTicket = Smartdesk.Sql.getTablePage(strFROMNet, null, "Ticket_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                strTicket_Ky = dtTicket.Rows[0]["Ticket_Ky"].ToString();
                
	            strWHERENet="Ticket_Ky=" + Smartdesk.Current.Request("Ticket_Ky");
	            strORDERNet = "Attivita_Ky";
	            strFROMNet = "Attivita_Vw";
	            dtAttivita = new DataTable("Attivita");
	            dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 10000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                
			}           
            strWHERENet="CoreModulesOptions_Code='customer.enableticket'";
            strORDERNet = "CoreModulesOptionsValue_Ky";
            strFROMNet = "CoreModulesOptionsValue";
            dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtCoreModulesOptionsValue.Rows.Count>0){
                if (dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].Equals(true)){
                 boolEnableticket=true;
                }
            }            
            strWHERENet="CoreModulesOptions_Code='customer.enableprojects'";
            strORDERNet = "CoreModulesOptionsValue_Ky";
            strFROMNet = "CoreModulesOptionsValue";
            dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtCoreModulesOptionsValue.Rows.Count>0){
                if (Convert.ToBoolean(dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"]).Equals(true)){
                 boolEnableprojects=true;
                }
            }            
            strWHERENet="CoreModulesOptions_Code='customer.enableproducts'";
            strORDERNet = "CoreModulesOptionsValue_Ky";
            strFROMNet = "CoreModulesOptionsValue";
            dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtCoreModulesOptionsValue.Rows.Count>0){
                if (Convert.ToBoolean(dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"]).Equals(true)){
                 boolEnableproducts=true;
                }
            }            
          }else{
            Response.Redirect("/area-clienti/login.aspx");
          }
      }else{
            Response.Redirect("/area-clienti/login.aspx");
      }
    }    
    
    public String GetFieldValue(string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="";
      }else{
        strValore=dtTicket.Rows[0][strField].ToString();
      }
      return strValore;
    }
    
    public Boolean GetCheckValue(string strField)
    {
      Boolean boolValore=false;
      if (strAzione=="new"){
        boolValore=false;
      }else{
        if (dtTicket.Rows[0][strField].Equals(true)){
          boolValore=true;
        }
      }
      return boolValore;
    }
}
