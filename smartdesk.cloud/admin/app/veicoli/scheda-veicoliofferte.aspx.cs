using System;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtVeicoliOfferte;
    public DataTable dtVeicoliOfferteAuto;
    public DataTable dtPagamenti;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strAzione = "";
    
    public string strWHERENet = "";
    public string strORDERNet = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strAzione = Request["azione"];
            strH1="Offerta veicolo";
            if (strAzione!="new"){
	        	dtVeicoliOfferte = Smartdesk.Data.Read("VeicoliOfferte", "VeicoliOfferte_Ky",Smartdesk.Current.QueryString("VeicoliOfferte_Ky"));
                strWHERENet = "VeicoliOfferte_Ky=" + dtVeicoliOfferte.Rows[0]["VeicoliOfferte_Ky"].ToString();
                strORDERNet = "Veicoli_Targa";
                strFROMNet = "VeicoliOfferteAuto_Vw";
                dtVeicoliOfferteAuto = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliOfferteAuto_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    public String GetFieldValue(DataTable dtTabella, string strField, string strFormat)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="";
      }else{
        switch(strFormat){
          case "int":
            strValore=Smartdesk.Data.Field(dtTabella,strField);
            break;
          case "text":
            strValore=Smartdesk.Data.Field(dtTabella,strField);
            break;
          case "date":
            strValore=Smartdesk.Data.Field(dtTabella,strField);
            if (strValore.Length>0){
              strValore=Convert.ToDateTime(Smartdesk.Data.Field(dtTabella,strField)).ToString("dd-MM-yyyy",System.Globalization.CultureInfo.InvariantCulture);
            }
            break;
          case "datetime":
            strValore=Smartdesk.Data.Field(dtTabella,strField);
            if (strValore.Length>0){
              strValore=Convert.ToDateTime(Smartdesk.Data.Field(dtTabella,strField)).ToString("dd-MM-yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":");
            }
            break;
          default:
            strValore=Smartdesk.Data.Field(dtTabella,strField);
            break;
        }
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
