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
    public DataTable dtAnagraficheContatti;
    public DataTable dtSitiWeb;
    public DataTable dtAnagrafica;
    public int intAnagrafiche_Ky = 0;
    public string strAnagrafiche_Ky = "";
    public string strRagioneSociale = "";
    public string strSitiWeb_Ky = "";
    public string strFROMNet = "";
    public string strH1 = "Contatti";
    public string strAzione = "modifica";
    public string strSorgente = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
	  
      if (Smartdesk.Login.Verify){
            strAzione = Request["azione"];
            strSorgente=Smartdesk.Current.Request("sorgente");
            if (strAzione!="new"){
              strAzione = "modifica";
              dtAnagraficheContatti = Smartdesk.Data.Read("AnagraficheContatti_Vw", "AnagraficheContatti_Ky",Smartdesk.Current.QueryString("AnagraficheContatti_Ky"));
              strAnagrafiche_Ky= dtAnagraficheContatti.Rows[0]["Anagrafiche_Ky"].ToString();
			        strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
              strORDERNet = "SitiWeb_Ky";
              strFROMNet = "SitiWeb_Vw";
              dtSitiWeb = new DataTable("SitiWeb");
              dtSitiWeb = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWeb_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            }else{
			  strSitiWeb_Ky=Request["SitiWeb_Ky"];
			  strAnagrafiche_Ky=Request["Anagrafiche_Ky"];
			  if (strAnagrafiche_Ky!=null && strAnagrafiche_Ky.Length>0){
					  strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
		              strORDERNet = "Anagrafiche_Ky";
		              strFROMNet = "Anagrafiche_Vw";
		              dtAnagrafica = new DataTable("Anagrafica");
		              dtAnagrafica = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		              strRagioneSociale=dtAnagrafica.Rows[0]["Anagrafiche_RagioneSociale"].ToString();
					  strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
		              strORDERNet = "SitiWeb_Ky";
		              strFROMNet = "SitiWeb_Vw";
		              dtSitiWeb = new DataTable("SitiWeb");
		              dtSitiWeb = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWeb_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		              if (strSitiWeb_Ky==null || strSitiWeb_Ky.Length<1){
		                if (dtSitiWeb.Rows.Count>0){
		                  strSitiWeb_Ky=dtSitiWeb.Rows[0]["SitiWeb_Ky"].ToString();  
		                }  
		              }
		      }
			}            
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    public String GetDefaultValue(string strField)
    {
      string strValore="";
      switch (strField){
		case "Anagrafiche_Ky":
			strValore=strAnagrafiche_Ky;
			break;
		case "Anagrafiche_RagioneSociale":
			strValore=strRagioneSociale;
			break;
		case "SitiWeb_Ky":
			strValore=strSitiWeb_Ky;
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
