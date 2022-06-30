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
    public DataTable dtLogin;
    public DataTable dtAnagraficheProdotti;
    public DataTable dtAnagraficheRivenditori;
    public int intAnagraficheProdotti_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "Scheda prodotto";
    public int intNumDoc = 0;
    public int intNumDocVuoto = 0;
    public string strAzione = "modifica";
    public int intNumProdottiInseriti = 0;
    public int intNumProdottiMassimo = 0;
    public string strAnagrafiche_Ky = "";
    public bool boolEnableticket = false;
    public bool boolEnableprojects = false;
    public bool boolEnableproducts = false;

    protected void Page_Load(object sender, EventArgs e)
    {
    DataTable dtCoreModulesOptionsValue;
      string strWHERENet="";
      string strORDERNet = "";

      
      strAnagrafiche_Ky=(FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-cliente"].Value)).UserData;
	     if (strAnagrafiche_Ky!=null){
          strWHERENet = "Anagrafiche_Ky =" + strAnagrafiche_Ky;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
            strAzione=Smartdesk.Current.Request("azione");
            if (strAzione!="new"){
	            strWHERENet="AnagraficheProdotti_Ky=" + Smartdesk.Current.Request("AnagraficheProdotti_Ky");
	            strORDERNet = "AnagraficheProdotti_Ky";
	            strFROMNet = "AnagraficheProdotti_Vw";
	            dtAnagraficheProdotti = new DataTable("AnagraficheProdotti");
	            dtAnagraficheProdotti = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheProdotti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			       }  
            strWHERENet = "AnagraficheTipo_Ky=6";
            strORDERNet = "Anagrafiche_Ky";
            strFROMNet = "Anagrafiche_Vw";
            dtAnagraficheRivenditori = new DataTable("AnagraficheRivenditori");
            dtAnagraficheRivenditori = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

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
        strValore=dtAnagraficheProdotti.Rows[0][strField].ToString();
      }
      return strValore;
    }
    
    public Boolean GetCheckValue(string strField)
    {
      Boolean boolValore=false;
      if (strAzione=="new"){
        boolValore=false;
      }else{
        if (dtAnagraficheProdotti.Rows[0][strField].Equals(true)){
          boolValore=true;
        }
      }
      return boolValore;
    }

    public String GetMese(string strMeseIn)
    {
      string strMeseOut="";
      if (strMeseIn!=null){
        switch (strMeseIn){
          case "1":
            strMeseOut="gennaio";
            break;
          case "2":
            strMeseOut="febbraio";
            break;
          case "3":
            strMeseOut="marzo";
            break;
          case "4":
            strMeseOut="aprile";
            break;
          case "5":
            strMeseOut="maggio";
            break;
          case "6":
            strMeseOut="giugno";
            break;
          case "7":
            strMeseOut="luglio";
            break;
          case "8":
            strMeseOut="agosto";
            break;
          case "9":
            strMeseOut="settembre";
            break;
          case "10":
            strMeseOut="ottobre";
            break;
          case "11":
            strMeseOut="novembre";
            break;
          case "12":
            strMeseOut="dicembre";
            break;
        }
      }else{
        strMeseOut="";
      }
      return strMeseOut;
    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App) //#bp
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}
