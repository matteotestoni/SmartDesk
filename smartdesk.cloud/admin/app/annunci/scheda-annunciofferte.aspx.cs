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
    public DataTable dtAnnunci;
    public DataTable dtAnnunciOfferte;
    public DataTable dtAste;
    public DataTable dtAsteEsperimenti;
    public string strFROMNet = "";
    public string strH1 = "Scheda offerta annuncio";
    public string strAzione = "";
    public string strAste_Ky = "";
    public string strAsteEsperimenti_Ky = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      
      string strWHERENet = "";

      if (Smartdesk.Login.Verify){
        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
        boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
        strAste_Ky = Smartdesk.Current.QueryString("Aste_Ky");
        strAsteEsperimenti_Ky = Smartdesk.Current.QueryString("AsteEsperimenti_Ky");
        strAzione = Request["azione"];
        if (strAzione!="new"){
    			  strAzione = "modifica";
    			  dtAnnunciOfferte = Smartdesk.Data.Read("AnnunciOfferte_Vw", "AnnunciOfferte_Ky",Smartdesk.Current.QueryString("AnnunciOfferte_Ky"));
    				strWHERENet = "Aste_Ky=" + dtAnnunciOfferte.Rows[0]["Aste_Ky"].ToString();
    				dtAsteEsperimenti = new DataTable("AsteEsperimenti");
    				dtAsteEsperimenti = Smartdesk.Sql.getTablePage("AsteEsperimenti_Vw", null, "AsteEsperimenti_Ky", strWHERENet, "AsteEsperimenti_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    				strWHERENet = "Aste_Ky=" + dtAnnunciOfferte.Rows[0]["Aste_Ky"].ToString();
    				dtAste = new DataTable("Aste");
    				dtAste = Smartdesk.Sql.getTablePage("Aste_Vw", null, "Aste_Ky", strWHERENet, "Aste_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    				strWHERENet = "Aste_Ky=" + dtAnnunciOfferte.Rows[0]["Aste_Ky"].ToString();
    				dtAnnunci = new DataTable("Annunci");
    				dtAnnunci = Smartdesk.Sql.getTablePage("Annunci_Vw", null, "Aste_Ky", strWHERENet, "Annunci_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }else{
          if (strAste_Ky!=null && strAste_Ky.Length>0){
            strWHERENet = "Aste_Ky=" + strAste_Ky;
            dtAsteEsperimenti = new DataTable("AsteEsperimenti");
            dtAsteEsperimenti = Smartdesk.Sql.getTablePage("AsteEsperimenti_Vw", null, "AsteEsperimenti_Ky", strWHERENet, "AsteEsperimenti_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            strWHERENet = "Aste_Ky=" + strAste_Ky;
            dtAste = new DataTable("Aste");
            dtAste = Smartdesk.Sql.getTablePage("Aste_Vw", null, "Aste_Ky", strWHERENet, "Aste_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            strWHERENet = "Aste_Ky=" + strAste_Ky;
      			dtAnnunci = new DataTable("Annunci");
      			dtAnnunci = Smartdesk.Sql.getTablePage("Annunci_Vw", null, "Aste_Ky", strWHERENet, "Annunci_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
	          }
		  }
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
}
