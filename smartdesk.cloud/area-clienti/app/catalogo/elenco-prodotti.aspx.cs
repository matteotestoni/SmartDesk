using System;
using System.Data;

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
    public DataTable dtProdotti;
    public string strPage="";
    public int intPage = 0;
    public bool boolEnableticket = false;
    public bool boolEnableprojects = false;
    public bool boolEnableproducts = false;

    protected void Page_Load(object sender, EventArgs e)
    {
    DataTable dtCoreModulesOptionsValue;
      
      if(Smartdesk.Login.Verify)
      {
              strWHERENet = "Anagrafiche_Ky =" + Smartdesk.Session.CurrentUser.ToString();
              strORDERNet = "Anagrafiche_Ky";
              strFROMNet = "Anagrafiche";
              dtLogin = new DataTable("Login");
              dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtLogin.Rows.Count>0){
                strPage = Request["page"];
                if ((strPage == null) || (strPage == "")){
                  intPage = 1;
                }
                else{
                  intPage = Convert.ToInt32(strPage);
                }
                strWHERENet = "Anagrafiche_Ky =" + Smartdesk.Session.CurrentUser.ToString();
                //Response.Write(strWHERENet);
                strFROMNet = "Prodotti_Vw";
                strORDERNet = "Prodotti_Ky DESC";
                dtProdotti = new DataTable("Prodotti");
                dtProdotti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Prodotti_Ky", strWHERENet, strORDERNet, intPage,50,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
          }
      
          //prodotti in vetrina
          strORDERNet = "Prodotti_Ky";
          strFROMNet = "Prodotti_Vw";
          strWHERENet = "Prodotti_InVetrina=1 And Prodotti_PubblicaWEB=1";
          dtProdottiVetrina = new DataTable("ProdottiVetrina");
          dtProdottiVetrina = Smartdesk.Sql.getTablePage(strFROMNet, null, "Prodotti_Ky", strWHERENet, strORDERNet, 1, 6,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);        

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
        else
     {
      }
    }

    public string getStato(Boolean boolValue, string strCampo, string strColor){
	    string strReturn;
	    string strClass;
			if (strColor!=null){
			  strClass="check-" + strColor;
			}else{
			  strClass="check";
			}
			if (boolValue){
			  strReturn="<span class=\"" + strClass + "\">" + strCampo + "</span>";
			}else{
			  strReturn="";
			}
			return strReturn;
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
