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
    public DataTable dtServizi;
    public DataTable dtServiziElenco;
    public DataTable dtServiziElencoFigli;
    public DataTable dtAttributi;
    public DataTable dtAttributiOpzioni;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public string strWHERENet = "";
    public string strORDERNet = "";
    public string strH1 = "";
    public string strAzione = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strAzione = Request["azione"];
          if (strAzione!="new"){
            strAzione = "modifica";
        	  dtServizi = Smartdesk.Data.Read("Servizi", "Servizi_Ky",Smartdesk.Current.QueryString("Servizi_Ky"));
          }
          strWHERENet = "(Attributi_Servizi=1)";
          strORDERNet = "Attributi_Ky";
          strFROMNet = "Attributi_Vw";
          dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          
          strWHERENet = "Servizi_CodicePadre Is Null OR Servizi_CodicePadre='0'";
          strORDERNet = "Servizi_Titolo";
          strFROMNet = "Servizi_Vw";
          dtServiziElenco = Smartdesk.Sql.getTablePage(strFROMNet, null, "Servizi_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    

    public String GetDefaultValue(string strField)
    {
      string strValore="";
      switch (strField){
				case "Servizi_PubblicaWEB":
					strValore="-1";
					break;
				case "Servizi_InVetrina":
					strValore="-1";
					break;
			}
      return strValore;
    }

    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="";
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
