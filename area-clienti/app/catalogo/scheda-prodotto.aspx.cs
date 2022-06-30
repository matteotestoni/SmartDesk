using System;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtProdotto;
    public DataTable dtProdotti;
    public int intProdotti_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "";
    public int intNumDoc = 0;
    public int intNumDocVuoto = 0;
    public string strAzione = "modifica";
    public int intNumProdottiInseriti = 0;
    public int intNumProdottiMassimo = 0;
    public bool boolEnableticket = false;
    public bool boolEnableprojects = false;
    public bool boolEnableproducts = false;

    protected void Page_Load(object sender, EventArgs e)
    {
    DataTable dtCoreModulesOptionsValue;
      string strWHERENet="";
      string strORDERNet = "";

      
      if(Request.Cookies["rswcrm-cliente"] != null)
      {
          strWHERENet = "Anagrafiche_Ky =" + Smartdesk.Session.CurrentUser.ToString();
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
            strAzione=Smartdesk.Current.Request("azione");
            if (strAzione!="new"){
	            strWHERENet="Prodotti_Ky=" + Smartdesk.Current.Request("Prodotti_Ky");
	            strORDERNet = "Prodotti_Ky";
	            strFROMNet = "Prodotti_Vw";
	            dtProdotto = new DataTable("Prodotto");
	            dtProdotto = Smartdesk.Sql.getTablePage(strFROMNet, null, "Prodotti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
						}else{
	            strWHERENet="Anagrafiche_Ky=" + Smartdesk.Session.CurrentUser.ToString();
	            strORDERNet = "Prodotti_Ky";
	            strFROMNet = "Prodotti_Vw";
	            dtProdotti = new DataTable("Prodotti");
	            dtProdotti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Prodotti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
							intNumProdottiInseriti=intNumRecords;
							intNumProdottiMassimo=Convert.ToInt32(dtLogin.Rows[0]["Anagrafiche_NumeroProdotti"].ToString());
							if (intNumProdottiInseriti>=intNumProdottiMassimo){
								Response.Redirect("numero-max-prodotti.aspx?NumeroProdottiInseriti=" + intNumProdottiInseriti + "&NumeroProdottiMassimo=" + intNumProdottiMassimo);
							}
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
            Response.Redirect("default.aspx");
          }
      }else{
            Response.Redirect("default.aspx");
      }
    }    
    
    public String GetFieldValue(string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="";
      }else{
        strValore=dtProdotto.Rows[0][strField].ToString();
      }
      return strValore;
    }
    
    public Boolean GetCheckValue(string strField)
    {
      Boolean boolValore=false;
      if (strAzione=="new"){
        boolValore=false;
      }else{
        if (dtProdotto.Rows[0][strField].Equals(true)){
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
