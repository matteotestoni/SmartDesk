using System;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    public string strWHERENet="";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public DataTable dtProdottiVetrina;
    
    public int intNumRecords = 0;
    public int intRecxPag = 20;
    public int intNumPagine=1;
    public int i = 0;
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtAnagrafiche;
    public bool boolEnableticket = false;
    public bool boolEnableprojects = false;
    public bool boolEnableproducts = false;

    protected void Page_Load(object sender, EventArgs e)
    {
    DataTable dtCoreModulesOptionsValue;
      
      if(Request.Cookies["rswcrm-cliente"] != null)
      {
          if  (Request.Cookies["rswcrm-cliente"]!=null){
                  strWHERENet = "Anagrafiche_Ky =" + Smartdesk.Session.CurrentUser.ToString();
		          strORDERNet = "Anagrafiche_Ky";
		          strFROMNet = "Anagrafiche";
		          dtLogin = new DataTable("Login");
		          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtLogin.Rows.Count>0){
                strWHERENet = "Anagrafiche_Ky =" + Smartdesk.Session.CurrentUser.ToString();
                strORDERNet = "Anagrafiche_Ky";
                strFROMNet = "Anagrafiche_Vw";
                dtAnagrafiche = new DataTable("Login");
                dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

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
                Response.Redirect("Default.aspx");
              }
          }else{
            Response.Redirect("Default.aspx");
          }
      
          //prodotti in vetrina
          strORDERNet = "Prodotti_Ky";
          strFROMNet = "Prodotti_Vw";
          strWHERENet = "Prodotti_InVetrina=1 And Prodotti_PubblicaWEB=1";
          dtProdottiVetrina = new DataTable("ProdottiVetrina");
          dtProdottiVetrina = Smartdesk.Sql.getTablePage(strFROMNet, null, "Prodotti_Ky", strWHERENet, strORDERNet, 1, 6,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);        
      }else{
      }
    }
    
    public String getVenditore(string strIn){
    string strOut="";
    int intCount;
      if (strIn!=null && strIn.Length>0){
        intCount=(strIn.Split(' ')).Length;
        if (intCount>1){
          strOut=strIn.Split(' ')[0];
        }
        if (intCount>2){
          strOut+=" " + strIn.Split(' ')[1];
        }
      }
      return strOut;
    }
}
