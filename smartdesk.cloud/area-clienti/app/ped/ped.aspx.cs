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
    public DataTable dtSocialpedFacebook;
    public DataTable dtSocialpedInstagram;
    
    public string strWHERENet="";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public int intWeekNum=0;
    public string strTitolo="";
    public string strH1 = "Piano Editoriale";
    public string strAnagrafiche_Ky="";
    public bool boolEnableticket = false;
    public bool boolEnableprojects = false;
    public bool boolEnableproducts = false;

    protected void Page_Load(object sender, EventArgs e)
    {
    DataTable dtCoreModulesOptionsValue;
      
      strAnagrafiche_Ky=(FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-cliente"].Value)).UserData;

      //Anagrafica
      strWHERENet="Anagrafiche_Ky IN (20203,20204,11881,6781,138)";
      strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
      strFROMNet = "Anagrafiche_Vw";
      strORDERNet = "Anagrafiche_Ky";
      dtAnagrafiche = new DataTable("Anagrafiche");
      dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1,100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      
	  	CultureInfo myCI = new CultureInfo("it-IT");
      Calendar myCal = myCI.Calendar;	
	  
		  CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
		  DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;  
		  intWeekNum = myCal.GetWeekOfYear( DateTime.Now, myCWR, myFirstDOW );


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
}
