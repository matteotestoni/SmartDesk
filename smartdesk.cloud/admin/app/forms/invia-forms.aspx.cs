using System;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtAnagrafiche;
    public int intAnagrafiche_Ky = 0;
    public string strH1 = "Invia sondaggio";
    public int intRecxPag = 30;
    public int intPage = 0;
    public int intNumPagine=1;
    public int intNumRecords = 0;
    
    public string strPaginazione = "";
    public DataTable dtStatistiche;
    public int intNumeroAnagrafiche = 0;
    public int intNumeroAnagraficheClientiAttivi = 0;
    public int intNumeroAnagraficheClientiChiusi = 0;
    public int intNumeroAnagraficheFornitori = 0;
    public int intNumeroAnagraficheConcorrenti = 0;
    public int intNumeroAnagraficheLeads = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
      string strPage="";

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
          if (dtLogin.Rows.Count>0){
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            checkPermessi();
			strPage = Request["page"];
            if ((strPage == null) || (strPage == "")){
              intPage = 1;
            }
            else{
              intPage = Convert.ToInt32(strPage);
            }
            strWHERENet=getWhere();
            strFROMNet = "Anagrafiche_Vw";
            strORDERNet = "Anagrafiche_DateInsert DESC";
            dtAnagrafiche = new DataTable("Anagrafiche");
            dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			intNumeroAnagrafiche=dtAnagrafiche.Rows.Count;
			this.PaginaSotto.Text = Smartdesk.Grid.getPagination(dtAnagrafiche,System.IO.Path.GetFileName(Request.Url.AbsolutePath), intRecxPag,intNumRecords, intPage,Request.QueryString);						            
			
            strWHERENet="";
            strFROMNet = "Anagrafiche_Vw";
            strORDERNet = "Anagrafiche_DateInsert DESC";
            dtStatistiche = new DataTable("Statistiche");
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1,100000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            intNumeroAnagrafiche=dtStatistiche.Rows.Count;

            strWHERENet="AnagraficheTipo_Ky=1 And (Anagrafiche_Disdetto Is Null Or Anagrafiche_Disdetto=0)";
            strFROMNet = "Anagrafiche_Vw";
            strORDERNet = "Anagrafiche_DateInsert DESC";
            dtStatistiche = new DataTable("Statistiche");
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1,100000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            intNumeroAnagraficheClientiAttivi=dtStatistiche.Rows.Count;

            strWHERENet="AnagraficheTipo_Ky=1 And Anagrafiche_Disdetto=1";
            strFROMNet = "Anagrafiche_Vw";
            strORDERNet = "Anagrafiche_DateInsert DESC";
            dtStatistiche = new DataTable("Statistiche");
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1,100000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            intNumeroAnagraficheClientiChiusi=dtStatistiche.Rows.Count;
			
            strWHERENet="AnagraficheTipo_Ky=4";
            strFROMNet = "Anagrafiche_Vw";
            strORDERNet = "Anagrafiche_DateInsert DESC";
            dtStatistiche = new DataTable("Statistiche");
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1,100000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            intNumeroAnagraficheFornitori=dtStatistiche.Rows.Count;
			
            strWHERENet="AnagraficheTipo_Ky=5";
            strFROMNet = "Anagrafiche_Vw";
            strORDERNet = "Anagrafiche_DateInsert DESC";
            dtStatistiche = new DataTable("Statistiche");
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1,100000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            intNumeroAnagraficheConcorrenti=dtStatistiche.Rows.Count;
			
            strWHERENet="AnagraficheTipo_Ky=3";
            strFROMNet = "Anagrafiche_Vw";
            strORDERNet = "Anagrafiche_DateInsert DESC";
            dtStatistiche = new DataTable("Statistiche");
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1,100000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            intNumeroAnagraficheLeads=dtStatistiche.Rows.Count;
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public bool checkPermessi(){
	  bool boolReturn=false;
      if (dtLogin.Rows[0]["UtentiGruppi_Anagrafiche"].Equals(true)){
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
        string strWHEREPermessi="";
        string strValue="";

        strWHERE="(Anagrafiche_Disdetto=0 Or Anagrafiche_Disdetto Is Null)";
        strValue = Request["lettera"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Anagrafiche_RagioneSociale like '" + strValue + "%')";
        }
        strValue = Request["Anagrafiche_RagioneSociale"];
        if (strValue != null && strValue != ""){
            strWHERE = "((Anagrafiche_RagioneSociale like '%" + strValue + "%') Or (Anagrafiche_ParoleChiave like '%" + strValue + "%'))";
        }
        strValue = Request["Anagrafiche_Disdetto"];
        if (strValue != null && strValue != ""){
            strWHERE += " AND (Anagrafiche_Disdetto=1)";
        }
        strValue = Request["cercatxt"];
        if (strValue != null && strValue != ""){
            strWHERE = "((Anagrafiche_RagioneSociale like '%" + strValue + "%') Or (Anagrafiche_ParoleChiave like '%" + strValue + "%'))";
        }
        strValue = Request["Nazioni_Ky"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Nazioni_Ky=" + strValue + ")";
        }
        strValue = Request["Regioni_Ky"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Regioni_Ky=" + strValue + ")";
        }
        strValue = Request["Province_Ky"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Province_Ky=" + strValue + ")";
        }
        strValue = Request["Comuni_Ky"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Comuni_Ky=" + strValue + ")";
        }
        strValue = Request["Anagrafiche_Telefono"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Anagrafiche_Telefono like '%" + strValue + "%')";
        }
        strValue = Request["Anagrafiche_EmailContatti"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Anagrafiche_EmailContatti like '%" + strValue + "%')";
        }
        strValue = Request["AnagraficheTipo_Ky"];
        if (strValue != null && strValue != ""){
            strWHERE += " AND (AnagraficheTipo_Ky=" + strValue + ")";
        }
        strValue = Request["AnagraficheStati_Ky"];
        if (strValue != null && strValue != ""){
            strWHERE = "(AnagraficheStati_Ky=" + strValue + ")";
        }
        strValue = Request["Anagrafiche_Categorie"];
        if (strValue != null && strValue != ""){
			strValue="'" + strValue.Replace(",","','") + "'";
            strWHERE = "(Anagrafiche_Categorie IN (" + strValue + "))";
        }
        strValue = Request["tutti"];
        if (strValue != null && strValue != ""){
            strWHERE = "";
        }
    	//permessi
    	if (boolAdmin==false){
      		switch (dtLogin.Rows[0]["UtentiGruppi_AnagraficheQuali"].ToString()){
      			case "1":
      				strWHEREPermessi="";
      				break;
      			case "2":
       				strWHEREPermessi="(UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString() + ")";
     				break;
      			case "3":
       				strWHEREPermessi="(Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString() + ")";
      				break;
			}
			if (dtLogin.Rows[0]["UtentiGruppi_AnagraficheClienti"].Equals(false)){
				if (strWHEREPermessi.Length>0){
					strWHEREPermessi+=" And (AnagraficheTipo_Ky<>1)";	
				}else{
					strWHEREPermessi="(AnagraficheTipo_Ky<>1)";	
				}
			}
			if (dtLogin.Rows[0]["UtentiGruppi_AnagraficheFornitori"].Equals(false)){
				if (strWHEREPermessi.Length>0){
					strWHEREPermessi+=" And (AnagraficheTipo_Ky<>4)";	
				}else{
					strWHEREPermessi="(AnagraficheTipo_Ky<>4)";	
				}
			}
			if (dtLogin.Rows[0]["UtentiGruppi_AnagraficheConcorrenti"].Equals(false)){
				if (strWHEREPermessi.Length>0){
					strWHEREPermessi+=" And (AnagraficheTipo_Ky<>5)";	
				}else{
					strWHEREPermessi="(AnagraficheTipo_Ky<>5)";	
				}
			}
			if (dtLogin.Rows[0]["UtentiGruppi_AnagraficheLead"].Equals(false)){
				if (strWHEREPermessi.Length>0){
					strWHEREPermessi+=" And (AnagraficheTipo_Ky<>3)";	
				}else{
					strWHEREPermessi="(AnagraficheTipo_Ky<>3)";	
				}
			}
			if (strWHEREPermessi.Length>0){
				if (strWHERE.Length>0){
					strWHERE=strWHERE + " And " + strWHEREPermessi;
				}else{
					strWHERE=strWHEREPermessi;
				}	
			}	
			
		}
        //Response.Write("1:" + strWHEREPermessi);
        //Response.Write("2:" + strWHERE);
        return strWHERE;
    }
}
