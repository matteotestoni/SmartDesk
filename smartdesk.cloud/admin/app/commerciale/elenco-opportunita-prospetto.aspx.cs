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
    public DataTable dtOpportunita;
    public DataTable dtOpportunitaStati;
    public string strH1 = "";
    
    public decimal decTotValoreMin=0; 
    public decimal decTotValoreMax=0; 
    public DataTable dtStatistiche;
    public int intNumeroOpportunita = 0;
    public int intNumeroOpportunitaPositive = 0;
    public int intNumeroOpportunitaNegative = 0;
    public int intNumeroOpportunitaAttive = 0;
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public int intRecxPag = 20;
    public DataTable dtGridData;

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
            strH1="Commerciale > Trattative";

            strWHERENet="";
            strFROMNet = "OpportunitaStati";
            strORDERNet = "OpportunitaStati_Ordine";
            dtOpportunitaStati = new DataTable("OpportunitaStati");
            dtOpportunitaStati = Smartdesk.Sql.getTablePage(strFROMNet, null, "OpportunitaStati_Ky", strWHERENet, strORDERNet, intPage,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);


            strWHERENet=getWhere();
            strFROMNet = "Opportunita_Vw";
            strORDERNet = "Opportunita_Ky DESC";
            dtOpportunita = new DataTable("Opportunita");
            dtOpportunita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Opportunita_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            dtGridData = dtOpportunita;
            //Response.Write(strWHERENet);
			intNumeroOpportunita=dtOpportunita.Rows.Count;
			this.PaginaSotto.Text = Smartdesk.Grid.getPagination(dtOpportunita,System.IO.Path.GetFileName(Request.Url.AbsolutePath), intRecxPag,intNumRecords, intPage,Request.QueryString);						            

      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public bool checkPermessi(){
	  bool boolReturn=false;
      if (dtLogin.Rows[0]["UtentiGruppi_Opportunita"].Equals(true)){
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
        }
        strValue = Request["Anagrafiche_RagioneSociale"];
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>1){
				strWHERE += " And (Anagrafiche_RagioneSociale like '%" + strValue + "%')";
			}else{
				strWHERE = "(Anagrafiche_RagioneSociale like '%" + strValue + "%')";
			}
        }
        strValue = Request["Opportunita_Titolo"];
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>1){
				strWHERE += " And (Opportunita_Titolo like '%" + strValue + "%')";
			}else{
				strWHERE = "(Opportunita_Titolo like '%" + strValue + "%')";
			}
        }
        strValue = Smartdesk.Current.Request("OpportunitaStati_Ky");
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>1){
		          strWHERE += " And (OpportunitaStati_Ky=" + strValue + ")";
      			}else{
      				strWHERE = "(OpportunitaStati_Ky=" + strValue + ")";
      			}
        }
        strValue = Smartdesk.Current.Request("OpportunitaSorgenti_Ky");
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>1){
		        strWHERE += " And (OpportunitaSorgenti_Ky=" + strValue + ")";
			}else{
				strWHERE = "(OpportunitaSorgenti_Ky=" + strValue + ")";
			}
        }
        strValue = Request["mese"];
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>1){
		        strWHERE += " And (Month(Opportunita_Data)=" + strValue + ")";
			}else{
				strWHERE = "(Month(Opportunita_Data)=" + strValue + ")";
			}
        }
        strValue = Request["apertachiusa"];
        if (strValue != null && strValue != ""){
            switch (strValue){
                case "1":
                  if (strWHERE.Length>1){
            		        strWHERE += " And (OpportunitaStati_Aperta=1 Or OpportunitaStati_Aperta Is Null)";
            			}else{
            				strWHERE = "(OpportunitaStati_Aperta=1 Or OpportunitaStati_Aperta Is Null)";
            			}
                    break;
                case "2":
                        if (strWHERE.Length>1){
            		        strWHERE += " And (OpportunitaStati_Chiusa=1)";
            			}else{
            				strWHERE = "(OpportunitaStati_Chiusa=1)";
            			}
                    break;
            }
        }else{
            if (strWHERE.Length>1){
      		        strWHERE += " And (OpportunitaStati_Aperta=1)";
      			}else{
      				strWHERE = "(OpportunitaStati_Aperta=1)";
      			}
		}
        
        //permessi limitati
        switch (Convert.ToInt32(dtLogin.Rows[0]["UtentiGruppi_CommercialeQuali"].ToString())){
          case 2:
              if ((strWHERE==null || strWHERE.Length<1)){
				  //strWHERE = "UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
			  }else{
				  //strWHERE = strWHERE + " AND (UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
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
