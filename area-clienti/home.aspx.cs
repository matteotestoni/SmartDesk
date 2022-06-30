using System;
using System.Data;
using System.Collections.Specialized;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public string strAnagrafiche_Ky="";
    public DataTable dtAnagrafica;
    public int intAnagrafiche_Ky = 0;
    public int intAnno = 0;
    public int intMese = 0;
    public string strColor="";
    public DateTime dt;
    public decimal decTotMese=0; 
    public decimal decTotIVAMese=0; 
    public decimal decTotServiziMese=0; 
    public decimal decTot=0; 
    public decimal decTotServizi=0; 
    public decimal decTotIVA=0; 
    public int intDocumenti_Ky = 0;
    public string strWHERENet="";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public bool boolEnableticket = false;
    public bool boolEnableprojects = false;
    public bool boolEnableproducts = false;
    public string strH1 = "Area clienti";

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
            dt=DateTime.Now;
            int intYear=dt.Year;
            int intMonth=dt.Month+1;

            //Anagrafica
            strWHERENet="Anagrafiche_Ky =" + strAnagrafiche_Ky;
            strFROMNet = "Anagrafiche_Vw";
            strORDERNet = "Anagrafiche_RagioneSociale ASC";
            dtAnagrafica = new DataTable("Anagrafiche");
            dtAnagrafica = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

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
            Response.Redirect("Default.aspx?utente=" + Smartdesk.Session.CurrentUser.ToString());
          }
      }else{
        Response.Redirect("Default.aspx");
      }
    }    
    
    
		public String GetOreResidue(string strValore){
    string strReturn;
			if (strValore==null){
				strReturn="0";
			}else{
				if (Convert.ToDouble(strValore)<0){
					strReturn="<font color=red><b>" + strValore + "</b></font>";
				}else{
					strReturn="<font color=green><b>" + strValore + "</b></font>";
				}
			}
			return strReturn;
    }

    public String GetMese(string strMeseIn)
    {
      string strMeseOut="";
      if (strMeseIn!=null){
        switch (strMeseIn){
          case "1":
            strMeseOut="gen";
            break;
          case "2":
            strMeseOut="feb";
            break;
          case "3":
            strMeseOut="mar";
            break;
          case "4":
            strMeseOut="apr";
            break;
          case "5":
            strMeseOut="mag";
            break;
          case "6":
            strMeseOut="giu";
            break;
          case "7":
            strMeseOut="lug";
            break;
          case "8":
            strMeseOut="ago";
            break;
          case "9":
            strMeseOut="set";
            break;
          case "10":
            strMeseOut="ott";
            break;
          case "11":
            strMeseOut="nov";
            break;
          case "12":
            strMeseOut="dic";
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
