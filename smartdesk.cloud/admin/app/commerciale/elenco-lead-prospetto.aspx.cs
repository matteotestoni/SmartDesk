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
    public DataTable dtLead;
    public DataTable dtLeadStato;
    public string strH1 = "";
    public decimal decTotValoreMin=0; 
    public decimal decTotValoreMax=0; 
    public DataTable dtStatistiche;
    public int intNumeroLead = 0;
    public int intNumeroLeadPositive = 0;
    public int intNumeroLeadNegative = 0;
    public int intNumeroLeadAttive = 0;
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public int intRecxPag = 100;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strPage="";
      int intPage = 0;

      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            checkPermessi();
            strPage = Request["page"];
            if ((strPage == null) || (strPage == "")){
              intPage = 1;
            }
            else{
              intPage = Convert.ToInt32(strPage);
            }
            strH1="Commerciale > Prospetto Lead";

            strWHERENet="";
            strFROMNet = "LeadStato";
            strORDERNet = "LeadStato_Ordine";
            dtLeadStato = new DataTable("LeadStato");
            dtLeadStato = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadStato_Ky", strWHERENet, strORDERNet, intPage,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strWHERENet=getWhere();
            strFROMNet = "Lead_Vw";
            strORDERNet = "Lead_Ky DESC";
            dtLead = new DataTable("Lead");
            dtLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, intPage,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			      intNumeroLead=dtLead.Rows.Count;
            
            switch (Convert.ToInt32(dtLogin.Rows[0]["UtentiGruppi_CommercialeQuali"].ToString())){
              case 2:
          			strWHERENet = "LeadStato_Chiusa=1 AND UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
                break;
              case 3:
                strWHERENet = "LeadStato_Chiusa=1 AND Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString();
                break;
            }
            strFROMNet = "Lead_Vw";
            strORDERNet = "Lead_Ky DESC";
            dtStatistiche = new DataTable("Statistiche");
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  		      intNumeroLeadNegative = dtStatistiche.Rows.Count;
            
            switch (Convert.ToInt32(dtLogin.Rows[0]["UtentiGruppi_CommercialeQuali"].ToString())){
              case 2:
          			strWHERENet = "LeadStato_Ky=7 AND UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
                break;
              case 3:
                strWHERENet = "LeadStato_Ky=7 AND Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString();
                break;
            }
            strFROMNet = "Lead_Vw";
            strORDERNet = "Lead_Ky DESC";
            dtStatistiche = new DataTable("Statistiche");
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    		    intNumeroLeadPositive = dtStatistiche.Rows.Count;
            
            switch (Convert.ToInt32(dtLogin.Rows[0]["UtentiGruppi_CommercialeQuali"].ToString())){
              case 2:
          			strWHERENet = "LeadStato_Aperta=1 AND UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
                break;
              case 3:
                strWHERENet = "LeadStato_Aperta=1 AND Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString();
                break;
            }
            strFROMNet = "Lead_Vw";
            strORDERNet = "Lead_Ky DESC";
            dtStatistiche = new DataTable("Statistiche");
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    		    intNumeroLeadAttive = dtStatistiche.Rows.Count;
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public bool checkPermessi(){
	  bool boolReturn=false;
      if (dtLogin.Rows[0]["UtentiGruppi_Lead"].Equals(true)){
	    boolReturn=true;
	  }else{
	  	boolReturn=false;
	  	Response.Redirect("/admin/403.aspx");
	  }
	  return boolReturn;
	}

    public string getWhere()
    {
        string strWHERE="";
        string strValue="";

        strWHERE="";
        strValue = Smartdesk.Current.Request("Aziende_Ky");
        if (strValue != null && strValue != ""){
            strWHERE = "(Aziende_Ky=" + strValue + ")";
            strH1="Trattative: per azienda " + strValue;
        }
        strValue = Request["Anagrafiche_RagioneSociale"];
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>1){
      				strWHERE += " And (Anagrafiche_RagioneSociale like '%" + strValue + "%')";
      			}else{
      				strWHERE = "(Anagrafiche_RagioneSociale like '%" + strValue + "%')";
      			}
            strH1="Trattative: per ragione sociale: " + strValue;
        }
        strValue = Request["Lead_Titolo"];
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>1){
				strWHERE += " And (Lead_Titolo like '%" + strValue + "%')";
			}else{
				strWHERE = "(Lead_Titolo like '%" + strValue + "%')";
			}
            strH1="Trattative: per titolo: " + strValue;
        }
        strValue = Smartdesk.Current.Request("LeadStato_Ky");
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>1){
		        strWHERE += " And (LeadStato_Ky=" + strValue + ")";
			}else{
				strWHERE = "(LeadStato_Ky=" + strValue + ")";
			}
            strH1="Trattative: per stato: " + strValue;
        }
        strValue = Smartdesk.Current.Request("LeadSorgenti_Ky");
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>1){
		        strWHERE += " And (LeadSorgenti_Ky=" + strValue + ")";
			}else{
				strWHERE = "(LeadSorgenti_Ky=" + strValue + ")";
			}
            strH1="Trattative: per sorgente: " + strValue;
        }
        strValue = Request["mese"];
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>1){
		        strWHERE += " And (Month(Lead_Data)=" + strValue + ")";
			}else{
				strWHERE = "(Month(Lead_Data)=" + strValue + ")";
			}
            strH1="Trattative: per mese: " + strValue;
        }
        strValue = Request["apertachiusa"];
        if (strValue != null && strValue != ""){
            switch (strValue){
                case "1":
                        if (strWHERE.Length>1){
            		        strWHERE += " And (LeadStato_Aperta=1)";
            			}else{
            				strWHERE = "(LeadStato_Aperta=1)";
            			}
                    break;
                case "2":
                        if (strWHERE.Length>1){
            		        strWHERE += " And (LeadStato_Chiusa=1)";
            			}else{
            				strWHERE = "(LeadStato_Chiusa=1)";
            			}
                    break;
            }
            
            strH1="Trattative: per mese: " + strValue;
        }
        
        //permessi limitati
        switch (Convert.ToInt32(dtLogin.Rows[0]["UtentiGruppi_CommercialeQuali"].ToString())){
          case 2:
              if ((strWHERE==null || strWHERE.Length<1)){
      				  strWHERE = "UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
      			  }else{
      				  strWHERE = strWHERE + " AND (UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
              }
            break;
          case 3:
              if ((strWHERE==null || strWHERE.Length<1)){
                  strWHERE = "Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString();
      			  }else{
      				  strWHERE = strWHERE + " AND (Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString() + ")";
              }
            break;
        }
        return strWHERE;
    }
}
