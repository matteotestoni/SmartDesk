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
    public DataTable dtCoreGrids;
    public DataTable dtCoreGridsButtons;
    public DataTable dtCoreModules;
    public DataTable dtCoreGridsColumns;
    public DataTable dtUtentiGruppi;
    public DataTable dtUsergroupsGrids;
    public string strFROMNet = "";
    public string strH1 = "Scheda griglia";
    public string strAzione = "modifica";
    
    public DataTable dtTemp;
    public string strSorgente = "";
    public string strCoreModules_Ky = "";
    public string strCoreGrids_Ky = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      
      string strWHERENet="";
      string strORDERNet = "";

      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strAzione = Request["azione"];
          strSorgente=Smartdesk.Current.Request("sorgente");

          strWHERENet="";
          strORDERNet = "UtentiGruppi_Descrizione";
          strFROMNet = "UtentiGruppi";
          dtUtentiGruppi = new DataTable("UtentiGruppi");
          dtUtentiGruppi = Smartdesk.Sql.getTablePage(strFROMNet, null, "UtentiGruppi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (strAzione!="new"){
            strAzione = "modifica";
            strCoreGrids_Ky=Smartdesk.Current.QueryString("CoreGrids_Ky");
            dtCoreGrids = Smartdesk.Data.Read("CoreGrids_Vw", "CoreGrids_Ky", strCoreGrids_Ky);
            strCoreModules_Ky=dtCoreGrids.Rows[0]["CoreModules_Ky"].ToString();
            
            strWHERENet = "CoreEntities_Ky=" + dtCoreGrids.Rows[0]["CoreEntities_Ky"].ToString();
            strORDERNet = "CoreForms_Order";
            strFROMNet = "CoreForms";
            dtCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreForms_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strWHERENet = "CoreGrids_Ky=" + Smartdesk.Current.QueryString("CoreGrids_Ky");
            strORDERNet = "CoreGridsColumns_Order";
            strFROMNet = "CoreGridsColumns_Vw";
            dtCoreGridsColumns = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGridsColumns_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
            strWHERENet = "CoreGrids_Ky=" + Smartdesk.Current.QueryString("CoreGrids_Ky");
            strORDERNet = "CoreGridsButtons_Order";
            strFROMNet = "CoreGridsButtons";
            dtCoreGridsButtons = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGridsButtons_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
						
            strWHERENet = "CoreGrids_Ky=" + Smartdesk.Current.QueryString("CoreGrids_Ky");
    		    strORDERNet = "UsergroupsGrids_Ky DESC";
    		    strFROMNet = "UsergroupsGrids_Vw";
    		    dtUsergroupsGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsGrids_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strWHERENet = "CoreModules_Ky=" + strCoreModules_Ky;
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
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
