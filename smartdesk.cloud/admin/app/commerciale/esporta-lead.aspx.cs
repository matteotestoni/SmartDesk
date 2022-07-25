using System;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;    
    public DataTable dtLead;
    public int intLead_Ky = 0;
    public string strH1 = "Esporta Lead";
    public int intRecxPag = 2000000;
    public int intPage = 0;
    public int intNumPagine=1;
    public int intNumRecords = 0;
    

    public string strCampi = "";
    public string LeadTipo_Ky = "";
    public string Lead_Categorie = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
      string strPage="";

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strPage = Request["page"];
          if ((strPage == null) || (strPage == "")){
            intPage = 1;
          }
          else{
            intPage = Convert.ToInt32(strPage);
          }
          strWHERENet=getWhere();
          //Response.Write(strWHERENet);
          strFROMNet = "Lead_Vw";
          strORDERNet = "Lead_Ky DESC";
          dtLead = new DataTable("Lead");
          dtLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        	strCampi = Request["campi"];
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public string getWhere()
    {
        string strWHERE="";
        string strValue="";

        strWHERE="";
        strH1="Lead";
    
		strValue = Request["Lead_Categorie"];
        if (strValue != null && strValue != ""){
    			strValue="'" + strValue.Replace(",","','") + "'";
    			if (strWHERE.Length>0){
    				strWHERE+=" And (Lead_Categorie IN (" + strValue + "))";	
    			}else{
    				strWHERE="(Lead_Categorie IN (" + strValue + "))";	
    			}
        }
		
    
		strValue = Request["Lead_Titolo"];
        if (strValue != null && strValue != ""){
    			if (strWHERE.Length>0){
    				strWHERE+=" And (Lead_Titolo like '%" + strValue + "%')";	
    			}else{
    				strWHERE="(Lead_Titolo like '%" + strValue + "%')";	
    			}
        }
        
        
    strValue = Request["LeadCategorie_Ky"];
    if (strValue != null && strValue != ""){
  			if (strWHERE.Length>0){
  				strWHERE+=" And (LeadCategorie_Ky=" + strValue + ")";	
  			}else{
  				strWHERE="(LeadCategorie_Ky=" + strValue + ")";	
  			}
    }

    strValue = Request["LeadTipo_Ky"];
    if (strValue != null && strValue != ""){
  			if (strWHERE.Length>0){
  				strWHERE+=" And (LeadTipo_Ky=" + strValue + ")";	
  			}else{
  				strWHERE="(LeadTipo_Ky=" + strValue + ")";	
  			}
    }

    strValue = Request["LeadSorgenti_Ky"];
    if (strValue != null && strValue != ""){
  			if (strWHERE.Length>0){
  				strWHERE+=" And (LeadSorgenti_Ky=" + strValue + ")";	
  			}else{
  				strWHERE="(LeadSorgenti_Ky=" + strValue + ")";	
  			}
    }


		strValue = Request["Nazioni_Ky"];
    if (strValue != null && strValue != ""){
  			if (strWHERE.Length>0){
  				strWHERE+=" And (Nazioni_Ky=" + strValue + ")";	
  			}else{
  				strWHERE="(Nazioni_Ky=" + strValue + ")";	
  			}
    }
		strValue = Request["Regioni_Ky"];
        if (strValue != null && strValue != ""){
			if (strWHERE.Length>0){
				strWHERE+=" And (Regioni_Ky=" + strValue + ")";	
			}else{
				strWHERE="(Regioni_Ky=" + strValue + ")";	
			}
        }
		strValue = Request["Province_Ky"];
        if (strValue != null && strValue != ""){
			if (strWHERE.Length>0){
				strWHERE+=" And (Province_Ky=" + strValue + ")";	
			}else{
				strWHERE="(Province_Ky=" + strValue + ")";	
			}
        }
		strValue = Request["Comuni_Ky"];
        if (strValue != null && strValue != ""){
			if (strWHERE.Length>0){
				strWHERE+=" And (Comuni_Ky=" + strValue + ")";	
			}else{
				strWHERE="(Comuni_Ky=" + strValue + ")";	
			}
        }
			strValue = Request["Lead_DateInsert"];
      if (strValue != null && strValue != ""){
					if (strWHERE.Length>0){
						strWHERE+=" And (Lead_DateInsert>='" + strValue + "')";	
					}else{
						strWHERE="(Lead_DateInsert>='" + strValue + "')";	
					}
      }

        return strWHERE;
    }

	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
