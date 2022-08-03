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
    public DataTable dtForms;
    public DataTable dtFormsFields;
    public DataTable dtFormsValori;
    public DataTable dtFormsAvanzamento;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strAzione = "";
    public string strForms_Ky = "";
    public DataTable dtFormsFieldsConteggio;
    public decimal decPercCompilato = 0;
    public string strRequired="";
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

	            //Anagrafica
	            strWHERENet="Anagrafiche_Ky =" + strAnagrafiche_Ky;
	            strFROMNet = "Anagrafiche_Vw";
	            strORDERNet = "Anagrafiche_RagioneSociale ASC";
	            dtAnagrafica = new DataTable("Anagrafiche");
	            dtAnagrafica = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

	            strForms_Ky=Smartdesk.Current.Request("Forms_Ky");
	            if ((strForms_Ky==null) || strForms_Ky.Length<1){
				  strForms_Ky="1";	
				}     
				strWHERENet="Forms_Ky=" + strForms_Ky;
	            strORDERNet = "Forms_Ky";
	            strFROMNet = "Forms";
	            dtForms = new DataTable("Forms");
	            dtForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "Forms_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

				strWHERENet="Forms_Ky=" + strForms_Ky;
				strORDERNet = "FormsFields_Ordine ASC";
				strFROMNet = "FormsFields";
				dtFormsFields = new DataTable("FormsFields");
				dtFormsFields = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsFields_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

				strWHERENet="Forms_Ky=" + strForms_Ky + " And Anagrafiche_Ky=" + strAnagrafiche_Ky;
				//Response.Write(strWHERENet);
				strORDERNet = "FormsValori_Ky";
				strFROMNet = "FormsValori_Vw";
				dtFormsValori = new DataTable("FormsValori");
				dtFormsValori = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsValori_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
				
				strWHERENet="Forms_Ky=" + strForms_Ky + " And FormsFieldsTipo_Ky<>5 And FormsFieldsTipo_Ky<>6";
				strORDERNet = "FormsFields_Ky";
				strFROMNet = "FormsFields";
				dtFormsFieldsConteggio = new DataTable("FormsFieldsConteggio");
				dtFormsFieldsConteggio = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsFields_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
				strWHERENet="Forms_Ky=" + strForms_Ky + " And FormsAvanzamento_Stato=3";
				strORDERNet = "FormsAvanzamento_Ky";
				strFROMNet = "FormsAvanzamento";
				dtFormsAvanzamento = new DataTable("FormsAvanzamento");
				dtFormsAvanzamento = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsAvanzamento_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
	            if (dtFormsAvanzamento.Rows.Count>0){
	            	//Response.Redirect("sondaggio-inviato.aspx?inviato=inviato");
				}

				if (dtFormsFieldsConteggio.Rows.Count>0){
          decPercCompilato=dtFormsValori.Rows.Count*100/dtFormsFieldsConteggio.Rows.Count;
        }else{
          decPercCompilato=0;
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
            
            
            }
          }else{
            Response.Redirect(".." + Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(".." + Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="";
      }else{
        strValore=dtTabella.Rows[0][strField].ToString();
      }
      return strValore;

    }
}
