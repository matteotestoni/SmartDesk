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
    public DataTable dtAttivitaAperte;
    public DataTable dtAttivitaChiuse;
    public DataTable dtAttivitaTotali;
    public DataTable dtAttivitaCommesseTotaleOre;
    public DataTable dtCommesse;
    public bool boolAdmin = false;
    public string strAnagrafiche_Ky="";
    public string strCommesse_Ky="";
    public string strCommesseStato_Ky="";
    public string strSorgente="";
    
    public int intAvanzamento = 0;
    public decimal decTotOrePreviste=0; 
    public decimal decTotOreImpiegate=0; 
    public decimal decTotOreResidue=0; 
    public string strTotOrePreviste="0"; 
    public string strTotOreImpiegate="0"; 
    public string strTotOreResidue="0"; 

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";

      
      
	  
      if (Smartdesk.Login.Verify){
        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
			  strCommesse_Ky=Smartdesk.Current.Request("Commesse_Ky");
	        if (strCommesse_Ky!=null && strCommesse_Ky.Length>0){
			  	  strWHERENet = "Commesse_Ky=" + strCommesse_Ky;
	        }else{
			  	  strWHERENet = "CommesseStato_Ky=4";
			  }
			  //strWHERENet = "Commesse_Ky=10578";
			  strORDERNet = "Commesse_Ky DESC";
        strFROMNet = "Commesse";
        dtCommesse = new DataTable("Commesse");
        dtCommesse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");
        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
        SqlCommand cm = new SqlCommand();
        cm.CommandType = CommandType.Text;
        cm.Connection = cn;
        cm.CommandTimeout = 300;
        da.SelectCommand = cm;
        cn.Open();
    			for (int i = 0; i < dtCommesse.Rows.Count; i++){
    				  strCommesse_Ky=dtCommesse.Rows[i]["Commesse_Ky"].ToString();
              if (strCommesse_Ky!=null && strCommesse_Ky.Length>0){
                    Response.Write("Progetto:" + strCommesse_Ky + " - " + dtCommesse.Rows[i]["Commesse_Titolo"].ToString() + "<br>");
    								decTotOrePreviste=Convert.ToDecimal(dtCommesse.Rows[i]["Commesse_OrePreviste"]);
    								decTotOreResidue=Convert.ToDecimal(dtCommesse.Rows[i]["Commesse_OreResidue"]);
      							strWHERENet="Commesse_Ky=" + strCommesse_Ky + "";
		                strORDERNet = "Commesse_Ky";
		                strFROMNet = "Attivita_TotaliCommesse_Vw";
		                dtAttivitaCommesseTotaleOre = new DataTable("AttivitaCommesseTotaleOre");
		                dtAttivitaCommesseTotaleOre = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		                if (dtAttivitaCommesseTotaleOre!=null && dtAttivitaCommesseTotaleOre.Rows.Count>0){
      								if (dtAttivitaCommesseTotaleOre.Rows[0]["Attivita_Ore"]!=System.DBNull.Value){
      									decTotOreImpiegate=Convert.ToDecimal(dtAttivitaCommesseTotaleOre.Rows[0]["Attivita_Ore"]);
      								}else{
      									decTotOreImpiegate=0;	
      								}
      							}else{
      								strTotOreImpiegate="0";
      							}
                    if (dtCommesse.Rows[i]["CommesseTipo_Ky"].ToString()=="1"){
                        //progetto
    						        strWHERENet="(Commesse_Ky=" + strCommesse_Ky + ")";
    		                strORDERNet = "Attivita_Ky";
    		                strFROMNet = "Attivita";
    		                dtAttivitaTotali = new DataTable("AttivitaTotali");
    		                dtAttivitaTotali = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            						if (dtAttivitaTotali!=null && dtAttivitaTotali.Rows.Count>0){
            							strWHERENet="(Attivita_Completo<>1 Or Attivita_Completo Is Null) And (Commesse_Ky=" + strCommesse_Ky + ")";
    			                strORDERNet = "Attivita_Ky";
    			                strFROMNet = "Attivita";
    			                dtAttivitaAperte = new DataTable("AttivitaAperte");
    			                dtAttivitaAperte = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            							strWHERENet="(Attivita_Completo=1) And (Commesse_Ky=" + strCommesse_Ky + ")";
    			                strORDERNet = "Attivita_Ky";
    			                strFROMNet = "Attivita";
    			                dtAttivitaChiuse = new DataTable("AttivitaChiuse");
    			                dtAttivitaChiuse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                         	Response.Write("Attivita aperte:" + dtAttivitaAperte.Rows.Count + "<br>");	
                         	Response.Write("Attivita chiuse:" + dtAttivitaChiuse.Rows.Count + "<br>");	
                         	Response.Write("Attivita totali:" + dtAttivitaTotali.Rows.Count + "<br>");	
            							intAvanzamento=Math.Abs(dtAttivitaChiuse.Rows.Count*100/dtAttivitaTotali.Rows.Count);
            							strWHERENet="Commesse_Ky=" + strCommesse_Ky + "";
    			                strORDERNet = "Commesse_Ky";
    			                strFROMNet = "Attivita_TotaliCommesse_Vw";
    			                dtAttivitaCommesseTotaleOre = new DataTable("AttivitaCommesseTotaleOre");
    			                dtAttivitaCommesseTotaleOre = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    			                if (dtAttivitaCommesseTotaleOre!=null && dtAttivitaCommesseTotaleOre.Rows.Count>0){
            								if (dtAttivitaCommesseTotaleOre.Rows[0]["Attivita_Ore"]!=System.DBNull.Value){
            									decTotOreImpiegate=Convert.ToDecimal(dtAttivitaCommesseTotaleOre.Rows[0]["Attivita_Ore"]);
            								}else{
            									decTotOreImpiegate=0;	
            								}
                            decTotOreResidue=decTotOrePreviste-decTotOreImpiegate;
            								strTotOreImpiegate=Convert.ToString(decTotOreImpiegate).Replace(",",".");
            								strTotOreResidue=Convert.ToString(decTotOreResidue).Replace(",",".");
            							}else{
            								strTotOreImpiegate="0";
            							  strTotOreResidue="0";
            							}
                        }else{
                          intAvanzamento=0;
            							strTotOreImpiegate="0";
                        
                        }
                    }else{
                        //contratto ad ore
                        if (decTotOreImpiegate>0 && decTotOrePreviste>0){
                          intAvanzamento=Math.Abs(Convert.ToInt32((decTotOreImpiegate*100)/decTotOrePreviste));
                        }else{
                          intAvanzamento=0;
                        }
                        decTotOreResidue=decTotOrePreviste-decTotOreImpiegate;
        								strTotOreImpiegate=Convert.ToString(decTotOreImpiegate).Replace(",",".");
        								strTotOreResidue=Convert.ToString(decTotOreResidue).Replace(",",".");

                    }
                    Response.Write("Ore previste:" + decTotOrePreviste + "<br>");
                    Response.Write("Ore impiegate:" + decTotOreImpiegate + "<br>");
                    Response.Write("Ore residue:" + decTotOreResidue + "<br>");
                    Response.Write("Avanzamento:" + intAvanzamento + "<br>");
  						}
  						strSQL = "UPDATE Commesse SET Commesse_OreImpiegate=" + strTotOreImpiegate + ", Commesse_OreResidue=" + strTotOreResidue + ", Commesse_Avanzamento=" + intAvanzamento + " WHERE Commesse_Ky=" + strCommesse_Ky;
  	          Response.Write(strSQL + "<br>");
  						cm.CommandText = strSQL;
  	          cm.ExecuteNonQuery();								
  					}
            cn.Close();
            Response.Write("<hr>");            

   				   switch (strSorgente){
    					case "scheda-commessa":
    					  Response.Redirect("/admin/app/progetti/scheda-commesse.aspx?Commesse_Ky=" + strCommesse_Ky);
    					  break;
    					case "elenco-commesse":
    					  Response.Redirect("/admin/app/progetti/elenco-commesse.aspx?CoreModules_Ky=24&CoreEntities_Ky=107&CoreGrids_Ky=118");
    					  break;
    					default:
    					  Response.Redirect("/admin/app/progetti/elenco-commesse.aspx?CoreModules_Ky=24&CoreEntities_Ky=107&CoreGrids_Ky=118");
    					  break;
    				}
      }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
