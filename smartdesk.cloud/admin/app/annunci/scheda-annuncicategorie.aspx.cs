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
    public DataTable dtAnnunciCategorie;
    public DataTable dtAttributi;
    public string strFROMNet = "";
    public string strH1 = "Scheda categoria annunci";
    public string strAzione = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet = "";
      string strORDERNet = "";
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strAzione = Request["azione"];
            if (strAzione!="new"){
                strAzione = "modifica";
                dtAnnunciCategorie = Smartdesk.Data.Read("AnnunciCategorie", "AnnunciCategorie_Ky",Smartdesk.Current.QueryString("AnnunciCategorie_Ky"));
	        }
            strWHERENet = "Attributi_Annunci=1";
            strORDERNet = "Attributi_Ky";
            strFROMNet = "Attributi_Vw";
            dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
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
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
