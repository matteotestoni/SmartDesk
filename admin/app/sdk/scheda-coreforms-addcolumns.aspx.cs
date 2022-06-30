using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtCoreAttributes;
    public DataTable dtCoreAttributesJoin;
    public DataTable dtCoreModules;
    public DataTable dtCoreForms;
    public DataTable dtCoreFormsFields;
    public DataTable dtJoin;
    public string strFROMNet = "";
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strH1 = "Aggiungi colonne a form";
    public string strAzione = "modifica";
    
    public DataTable dtTemp;
    public string strSorgente = "";
    public string strCoreModules_Ky = "";
    public string strCoreForms_Ky = "";
    public string strSelected = "";
    public string strCoreAttributes_Attributi="";

    protected void Page_Load(object sender, EventArgs e)
    {
      

      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strSorgente=Smartdesk.Current.Request("sorgente");
          
					strWHERENet = "CoreEntities_Ky=" + Smartdesk.Current.QueryString("CoreEntities_Ky");
	        strORDERNet = "CoreAttributes_Order";
	        strFROMNet = "CoreAttributes_Vw";
	        dtCoreAttributes = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreAttributes_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
					
          strWHERENet = "CoreAttributesType_Ky=7 AND CoreAttributes_System<>1 AND CoreEntities_Ky=" + Smartdesk.Current.QueryString("CoreEntities_Ky");
	        strORDERNet = "CoreAttributes_Order";
	        strFROMNet = "CoreAttributes_Vw";
	        dtCoreAttributesJoin = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreAttributes_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          
					strWHERENet = "CoreForms_Ky=" + Smartdesk.Current.QueryString("CoreForms_Ky");
	        strORDERNet = "CoreForms_Ky";
	        strFROMNet = "CoreForms_Vw";
	        dtCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreForms_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          
					strWHERENet = "CoreForms_Ky=" + Smartdesk.Current.QueryString("CoreForms_Ky");
	        strORDERNet = "CoreFormsFields_Order";
	        strFROMNet = "CoreFormsFields_Vw";
	        dtCoreFormsFields = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsFields_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
					for (int i = 0; i < dtCoreFormsFields.Rows.Count; i++){
            strCoreAttributes_Attributi=strCoreAttributes_Attributi + dtCoreFormsFields.Rows[i]["CoreAttributes_Ky"].ToString() + ",";
            if (i!=dtCoreFormsFields.Rows.Count-1){
              strCoreAttributes_Attributi=strCoreAttributes_Attributi + ",";
            }
          }
          
					strWHERENet = "CoreModules_Ky=" + Smartdesk.Current.QueryString("CoreModules_Ky");
	        strORDERNet = "CoreModules_Ky";
	        strFROMNet = "CoreModules";
	        dtCoreModules = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModules_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    
    public String GetDefaultValue(string strField)
    {
      string strValore="";
      switch (strField){
	    	case "CoreModules_Order":
	    		strValore="99";
	    		break;
	    	case "CoreModules_Ky":
	    		strValore=Request["CoreModules_Ky"];
	    		break;
	    	case "CoreEntities_Ky":
	    		strValore=Request["CoreEntities_Ky"];
	    		break;
	    }
      return strValore;
    }

    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        strValore=Smartdesk.Data.Field(dtTabella,strField);
      }
      return strValore;
    }
    
    public Boolean GetCheckValue(DataTable dtTabella, string strField)
    {
        Boolean boolValore = false;
        if (strAzione == "new")
        {
            boolValore = false;
        }
        else
        {
            boolValore = Smartdesk.Data.FieldBool(dtTabella,strField);
        }
        return boolValore;
    }
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
