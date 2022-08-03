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
    public DataTable dtCoreForms;
    public DataTable dtCoreModules;
    public DataTable dtCoreFormsFields;
    public string strFROMNet = "";
    public string strH1 = "Scheda colonna griglia";
    public string strAzione = "modifica";
    
    public DataTable dtTemp;
    public string strSorgente = "";
    public string strCoreModules_Ky = "";
    public string strCoreForms_Ky = "";
    public string strCoreFormsFields_Ky = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      
      string strWHERENet="";
      string strORDERNet = "";

      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strAzione = Request["azione"];
          strSorgente=Smartdesk.Current.Request("sorgente");
          if (strAzione!="new"){
						strAzione = "modifica";
	        	strCoreFormsFields_Ky=Smartdesk.Current.QueryString("CoreFormsFields_Ky");
						strWHERENet = "CoreFormsFields_Ky=" + Smartdesk.Current.QueryString("CoreFormsFields_Ky");
		        strORDERNet = "CoreFormsFields_Order";
		        strFROMNet = "CoreFormsFields_Vw";
		        dtCoreFormsFields = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsFields_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
	        	strCoreForms_Ky=Smartdesk.Current.QueryString("CoreForms_Ky");
						dtCoreForms = Smartdesk.Data.Read("CoreForms_Vw", "CoreForms_Ky", strCoreForms_Ky);
						strWHERENet = "CoreModules_Ky=" + Smartdesk.Current.QueryString("CoreModules_Ky");
		        strORDERNet = "CoreModules_Ky";
		        strFROMNet = "CoreModules";
		        dtCoreModules = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModules_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		  		}
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
}
