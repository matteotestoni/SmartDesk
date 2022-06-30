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
    public DataTable dtCoreEntities;
    public DataTable dtCoreAttributes;
    public DataTable dtCoreGrids;
    public DataTable dtCoreForms;
    public string strFROMNet = "";
    public string strH1 = "Scheda entit&agrave;";
    public string strAzione = "modifica";
    
    public DataTable dtTemp;
    public string strSorgente = "";

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
	        	dtCoreEntities = Smartdesk.Data.Read("CoreEntities", "CoreEntities_Ky",Smartdesk.Current.QueryString("CoreEntities_Ky"));            
						strWHERENet = "CoreEntities_Ky=" + Smartdesk.Current.QueryString("CoreEntities_Ky");
            strORDERNet = "CoreAttributes_Order, CoreAttributes_Code";
            strFROMNet = "CoreAttributes_Vw";
            dtCoreAttributes = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreAttributes_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
						strWHERENet = "CoreEntities_Ky=" + Smartdesk.Current.QueryString("CoreEntities_Ky");
            strORDERNet = "CoreGrids_Ky";
            strFROMNet = "CoreGrids_Vw";
            dtCoreGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGrids_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
						strWHERENet = "CoreEntities_Ky=" + Smartdesk.Current.QueryString("CoreEntities_Ky");
            strORDERNet = "CoreForms_Ky";
            strFROMNet = "CoreForms_Vw";
            dtCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreForms_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
					}
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    
    public String GetDefaultValue(string strField)
    {
      string strValore="";
      switch (strField){
	    	case "CoreEntities_Order":
	    		strValore="99";
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
