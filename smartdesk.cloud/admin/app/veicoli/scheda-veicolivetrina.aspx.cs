using System;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtVeicoliVetrina;
    public DataTable dtVeicoliVetrinaCorpo;
    public DataTable dtPagamenti;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strAzione = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strAzione = Request["azione"];
          strH1="Veicoli > Scheda vetrina veicolo";
          if (strAzione!="new"){
            strAzione = "modifica";
  	  	  	dtVeicoliVetrina = Smartdesk.Data.Read("VeicoliVetrina", "VeicoliVetrina_Ky",Smartdesk.Current.QueryString("VeicoliVetrina_Ky"));
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
          
    public Boolean GetCheckValue(string strField)
    {
      Boolean boolValore=false;
      if (strAzione=="new"){
        boolValore=false;
      }else{
        if (dtVeicoliVetrina.Rows[0][strField].Equals(true)){
          boolValore=true;
        }
      }
      return boolValore;
    }

		public String GetFieldValue(string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="";
      }else{
        strValore=dtVeicoliVetrina.Rows[0][strField].ToString();
      }
      return strValore;

    }
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
