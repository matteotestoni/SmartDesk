using System;
using System.Data;
using System.Collections.Specialized;
using System.Web.Security;

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
    public string strAnagrafiche_Ky = "";
    public string strH1 = "";
    public string strAzione = "modifica";
    public DataTable dtTemp;
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
              strWHERENet = "Anagrafiche_Ky =" + strAnagrafiche_Ky;
              strORDERNet = "Anagrafiche_Ky";
              strFROMNet = "Anagrafiche_Vw";
              dtAnagrafiche = new DataTable("Login");
              dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              strH1="Anagrafiche > Scheda anagrafica";

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
          //prodotti in vetrina
          strORDERNet = "Prodotti_Ky";
          strFROMNet = "Prodotti_Vw";
          strWHERENet = "Prodotti_InVetrina=1 And Prodotti_PubblicaWEB=1";
          dtProdottiVetrina = new DataTable("ProdottiVetrina");
          dtProdottiVetrina = Smartdesk.Sql.getTablePage(strFROMNet, null, "Prodotti_Ky", strWHERENet, strORDERNet, 1, 6,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);        
      }else{
        Response.Redirect("Default.aspx");
      }
    }
    

    public String GetFieldValue (DataTable dtTabella, string strField) {
        string strValore = "";
        if (strAzione == "new") {
            strValore = GetDefaultValue (strField);
        } else {
            strValore = Smartdesk.Data.Field (dtTabella, strField);
        }
        return strValore;
    }

    public Boolean GetCheckValue (DataTable dtTabella, string strField) {
        Boolean boolValore = false;
        if (strAzione == "new") {
            boolValore = false;
        } else {
            boolValore = Smartdesk.Data.FieldBool (dtTabella, strField);
        }
        return boolValore;
    }

    public String GetDefaultValue (string strField) {
        string strValore = "";
        switch (strField) {
            case "Conti_Ky":
                dtTemp = new DataTable ("Temp");
                dtTemp = Smartdesk.Sql.getTablePage("Conti", null, "Conti_Ky", "Conti_Default=1", "Conti_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtTemp.Rows.Count > 0) {
                    strValore = dtTemp.Rows[0]["Conti_Ky"].ToString ();
                } else {
                    strValore = "";
                }
                break;
            case "AliquoteIVA_Ky":
                dtTemp = new DataTable ("Temp");
                dtTemp = Smartdesk.Sql.getTablePage("AliquoteIVA", null, "AliquoteIVA_Ky", "AliquoteIVA_Predefinita=1", "AliquoteIVA_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtTemp.Rows.Count > 0) {
                    strValore = dtTemp.Rows[0]["AliquoteIVA_Ky"].ToString ();
                } else {
                    strValore = "";
                }
                break;
            case "PagamentiCondizioni_Ky":
                dtTemp = new DataTable ("Temp");
                dtTemp = Smartdesk.Sql.getTablePage("PagamentiCondizioni", null, "PagamentiCondizioni_Ky", "PagamentiCondizioni_Predefinita=1", "PagamentiCondizioni_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtTemp.Rows.Count > 0) {
                    strValore = dtTemp.Rows[0]["PagamentiCondizioni_Ky"].ToString ();
                } else {
                    strValore = "";
                }
                break;
            case "PagamentiMetodo_Ky":
                dtTemp = new DataTable ("Temp");
                dtTemp = Smartdesk.Sql.getTablePage("PagamentiMetodo", null, "PagamentiMetodo_Ky", "PagamentiMetodo_Default=1", "PagamentiMetodo_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtTemp.Rows.Count > 0) {
                    strValore = dtTemp.Rows[0]["PagamentiMetodo_Ky"].ToString ();
                } else {
                    strValore = "";
                }
                break;
            case "SpedizioniTipo_Ky":
                strValore = "1";
                break;
        }
        return strValore;
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
