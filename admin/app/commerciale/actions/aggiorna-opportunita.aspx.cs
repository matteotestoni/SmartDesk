using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Data.SqlClient;


  public partial class _Default : System.Web.UI.Page 
	{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtAttivitaTotali;
    public DataTable dtOpportunita;
    
    public bool boolAdmin = false;
    
    public string strAnagrafiche_Ky="";
    public string strOpportunita_Ky="";
    public string strOpportunita_Stato="";
    public string strSorgente="";
    


    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";

      
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
			  strOpportunita_Ky=Smartdesk.Current.Request("Opportunita_Ky");
			  //echo OpportunitaConcluse();
	          if (strOpportunita_Ky!=null && strOpportunita_Ky.Length>0){
			  	strWHERENet = "Opportunita_Ky=" + strOpportunita_Ky;
	          }else{
			  	strWHERENet = "";
			  }
			  strORDERNet = "Opportunita_Ky";
	          strFROMNet = "Opportunita";
	          dtOpportunita = new DataTable("Opportunita");
	          dtOpportunita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Opportunita_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              SqlDataAdapter da = new SqlDataAdapter();
              DataTable dt = new DataTable("getTable");
              SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
              SqlCommand cm = new SqlCommand();
              
              cm.CommandType = CommandType.Text;
              cm.Connection = cn;
              cm.CommandTimeout = 300;
              da.SelectCommand = cm;
              cn.Open();
    			for (int i = 0; i < dtOpportunita.Rows.Count; i++){
    				strOpportunita_Ky=dtOpportunita.Rows[i]["Opportunita_Ky"].ToString();
                	if (strOpportunita_Ky!=null && strOpportunita_Ky.Length>0){
						strWHERENet="(Opportunita_Ky=" + strOpportunita_Ky + ")";
		                strORDERNet = "Attivita_Scadenza DESC";
		                strFROMNet = "Attivita";
		                dtAttivitaTotali = new DataTable("AttivitaTotali");
		                dtAttivitaTotali = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
						if (dtAttivitaTotali!=null && dtAttivitaTotali.Rows.Count>0){
                            strOpportunita_Stato=dtAttivitaTotali.Rows[0]["Attivita_Descrizione"].ToString();
                            strOpportunita_Stato=strOpportunita_Stato.Replace("'","''");
							if (strOpportunita_Stato!=dtOpportunita.Rows[i]["Opportunita_Stato"].ToString()){
								strSQL = "UPDATE Opportunita SET Opportunita_Stato='" + strOpportunita_Stato + "' WHERE Opportunita_Ky=" + strOpportunita_Ky;
			                	cm.CommandText = strSQL;
			                	cm.ExecuteNonQuery();								
							}else{
								strSQL="";	
							}
	                     	//Response.Write("Stato:<br>" + dtOpportunita.Rows[i]["Opportunita_Stato"].ToString() + "<br>" + strOpportunita_Stato + "<br>" );	
	                     	//Response.Write(strSQL + "<hr>");	
						}
					}            
    			}
				switch (strSorgente){
					case "scheda-opportunita":
					  Response.Redirect("/admin/app/commerciale/scheda-opportunita.aspx?Opportunita_Ky=" + strOpportunita_Ky);
					  break;
					case "elenco-opportunita":
					  Response.Redirect("/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=138&CoreGrids_Ky=107");
					  break;
					default:
					  Response.Redirect("/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=138&CoreGrids_Ky=107");
					  break;
				}
              cn.Close();
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

	

     
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
