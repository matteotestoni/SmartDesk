using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    public DataTable dtForms;
    public DataTable dtFormsFields;
    public DataTable dtFormsValori;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strAzione = "";
    public string strForms_Ky = "";
    public DataTable dtFormsFieldsConteggio;
    public string strCorpo="";
    public bool boolEnableticket = false;
    public bool boolEnableprojects = false;
    public bool boolEnableproducts = false;

    protected void Page_Load(object sender, EventArgs e)
    {
    DataTable dtCoreModulesOptionsValue;
      string strWHERENet="";
      string strORDERNet = "";
      string strValori="";

      
      strAnagrafiche_Ky=(FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-cliente"].Value)).UserData;
      strForms_Ky=Request["Forms_Ky"];
	  if (strAnagrafiche_Ky!=null){
          strWHERENet = "Anagrafiche_Ky =" + strAnagrafiche_Ky;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
            strAzione=Smartdesk.Current.Request("azione");
            //Anagrafica
            strWHERENet="Anagrafiche_Ky =" + strAnagrafiche_Ky;
            strFROMNet = "Anagrafiche_Vw";
            strORDERNet = "Anagrafiche_RagioneSociale ASC";
            dtAnagrafica = new DataTable("Anagrafiche");
            dtAnagrafica = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
            strWHERENet="Forms_Ky=" + strForms_Ky;
            strORDERNet = "Forms_Ky";
            strFROMNet = "Forms";
            dtForms = new DataTable("Forms");
            dtForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "Forms_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
            
    		strWHERENet="(Forms_Ky=" + strForms_Ky + "  And Anagrafiche_Ky=" + strAnagrafiche_Ky + ")";
    		strORDERNet = "FormsFields_Ordine ASC";
    		strFROMNet = "FormsValori_Vw";
    		dtFormsValori = new DataTable("FormsValori");
    		dtFormsValori = Smartdesk.Sql.getTablePage(strFROMNet, null, "chiave", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strCorpo=dtForms.Rows[0]["Forms_EmailBodyThankyou"].ToString();
            
            strValori="<p>Di seguito i valori scelti:</p>";
            strValori+="<table border=\"1\" cellpadding=\"5\" cellspacing=\"5\">";
            for (int i = 0; i < dtFormsValori.Rows.Count; i++){
                switch (dtFormsValori.Rows[i]["FormsFieldsTipo_Ky"].ToString()){
					case "1":
						strValori+="<tr><td>" + dtFormsValori.Rows[i]["FormsFields_Descrizione"].ToString() + "</td><td>" + dtFormsValori.Rows[i]["FormsValori_Valore"].ToString() + "</td></tr>";
						break;
					case "2":
						strValori+="<tr><td>" + dtFormsValori.Rows[i]["FormsFields_Descrizione"].ToString() + "</td><td>" + dtFormsValori.Rows[i]["FormsValori_Valore"].ToString() + "</td></tr>";
						break;
					case "3":
						strValori+="<tr><td>" + dtFormsValori.Rows[i]["FormsFields_Descrizione"].ToString() + "</td><td>" + dtFormsValori.Rows[i]["FormsValori_Valore"].ToString() + "</td></tr>";
						break;
					case "4":
						strValori+="<tr><td>" + dtFormsValori.Rows[i]["FormsFields_Descrizione"].ToString() + "</td><td>" + dtFormsValori.Rows[i]["FormsValori_Valore"].ToString() + "</td></tr>";
						break;
					case "5":
						strValori+="<tr><td bgcolor=\"#ededed\" colspan=\"2\"><strong>" + dtFormsValori.Rows[i]["FormsFields_Descrizione"].ToString() + "</strong></td></tr>";
						break;
					case "6":
						strValori+="<tr><td bgcolor=\"#ededed\" colspan=\"2\"><h2>" + dtFormsValori.Rows[i]["FormsFields_Descrizione"].ToString() + "</h2></td></tr>";
						break;
					
				}
            }
            strValori+="</table>";
            strCorpo = strCorpo.Replace("[VALORI]", strValori);

            

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
            Response.Redirect(".." + Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(".." + Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    public String GetFieldValue(string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="";
      }else{
        strValore=dtForms.Rows[0][strField].ToString();
      }
      return strValore;

    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App) //#bp
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}
