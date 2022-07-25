using System;
using System.Data;
using System.Collections.Specialized;
using System.Web.Security;
using System.Globalization;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtAnagrafiche;
    public DataTable dtSocialchannels;
    public DataTable dtSocialped;
    public DataTable dtSocialpedsidebar;
    
    public string strWHERENet="";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public string strSocialped_Ky = "";
    public int intWeekNum=0;
    public int intYear = 2020;
    public string strTitolo = "";
    public int intSettimana = 0;
    public string strH1 = "Piano Editoriale";
    public string strAnagrafiche_Ky="";
    public bool boolEnableticket = false;
    public bool boolEnableprojects = false;
    public bool boolEnableproducts = false;

    protected void Page_Load(object sender, EventArgs e)
    {
    DataTable dtCoreModulesOptionsValue;
      
      strSocialped_Ky = Request["Socialped_Ky"];
      strAnagrafiche_Ky=(FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-cliente"].Value)).UserData;
      
	  	CultureInfo myCI = new CultureInfo("it-IT");
      Calendar myCal = myCI.Calendar;	
	  
		  CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
		  DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;  
		  intWeekNum = myCal.GetWeekOfYear( DateTime.Now, myCWR, myFirstDOW );
      intYear = DateTime.Now.Year;

      //Anagrafica
      strWHERENet="Anagrafiche_Ky IN (20203,20204,11881,6781,138)";
      strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
      strFROMNet = "Anagrafiche_Vw";
      strORDERNet = "Anagrafiche_RagioneSociale ASC";
      dtAnagrafiche = new DataTable("Anagrafiche");
      dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1,100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      
      //tutti i ped
      strWHERENet="Socialchannels_Attivo=1 AND Socialped_DataFine>GETDATE() AND YEAR(Socialped_DataInizio)=" + intYear + " AND settimana>=" + intWeekNum + " AND Anagrafiche_Ky=" + strAnagrafiche_Ky;
      strFROMNet = "Socialped_Vw";
      strORDERNet = "settimana ASC, Socialchannels_Titolo ASC";
      dtSocialpedsidebar = new DataTable("Socialpedsidebar");
      dtSocialpedsidebar = Smartdesk.Sql.getTablePage(strFROMNet, null, "Socialped_Ky", strWHERENet, strORDERNet, 1,100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

      //ped corrente
      strWHERENet="Socialchannels_Attivo=1 AND Socialped_Ky=" + strSocialped_Ky + " AND Anagrafiche_Ky=" + strAnagrafiche_Ky;
      strFROMNet = "Socialped_Vw";
      strORDERNet = "Socialchannels_Titolo ASC";
      dtSocialped = new DataTable("Socialped");
      dtSocialped = Smartdesk.Sql.getTablePage(strFROMNet, null, "Socialped_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);


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

    }    
    
    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App) //#bp
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}
