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
    public DataTable dtCommesse;
    public DataTable dtPasswordmanager;
    public DataTable dtSitiWeb;
    public int intAnagrafiche_Ky = 0;
    public string strH1 = "Ricerca";
    public int intRecxPag = 30;
    public int intPage = 0;
    public int intNumPagine=1;
    public int intNumRecords = 0;
    
    public string strPaginazione = "";
    public DataTable dtStatistiche;
    public int intNumeroAnagrafiche = 0;
    public int intNumeroCommesse = 0;
    public int intNumeroPassword = 0;
    public int intNumeroSitiweb = 0;
    public string strViewUrl = "";
    public string strFormUrl = "";
    public int intCoreForms_Ky = 0;
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public string strUtentiGruppi_Ky = "";
    public DataTable dtCoreForms;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strPage="";

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strUtentiGruppi_Ky=dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
          checkPermessi();
					strPage = Request["page"];
          if ((strPage == null) || (strPage == "")){
            intPage = 1;
          }
          else{
            intPage = Convert.ToInt32(strPage);
          }
					strWHERENet=getWhereAnagrafiche();
          //Response.Write(strWHERENet);
          strFROMNet = "Anagrafiche_Vw";
          strORDERNet = "Anagrafiche_DateInsert DESC";
          dtAnagrafiche = new DataTable("Anagrafiche");
          dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
					intNumeroAnagrafiche=dtAnagrafiche.Rows.Count;
          
					strWHERENet=getWhereCommesse();
          strFROMNet = "Commesse_Vw";
          strORDERNet = "Commesse_Data DESC";
          dtCommesse = new DataTable("Commesse");
          dtCommesse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
					intNumeroCommesse=dtCommesse.Rows.Count;

					strWHERENet=getWherePassword();
          strFROMNet = "PasswordManager_Vw";
          strORDERNet = "PasswordManager_Ky DESC";
          dtPasswordmanager = new DataTable("PasswordManager");
          dtPasswordmanager = Smartdesk.Sql.getTablePage(strFROMNet, null, "PasswordManager_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
					intNumeroPassword=dtPasswordmanager.Rows.Count;

					strWHERENet=getWhereSitiWeb();
          strFROMNet = "SitiWeb_Vw";
          strORDERNet = "SitiWeb_Ky DESC";
          dtSitiWeb = new DataTable("SitiWeb");
          dtSitiWeb = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWeb_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
					intNumeroPassword=dtSitiWeb.Rows.Count;

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

    public string getWhereAnagrafiche(){
        string strWHERE="";
        string strWHEREPermessi="";
        string strValue="";

        strWHERE="(Anagrafiche_Disdetto=0 Or Anagrafiche_Disdetto Is Null)";
        strValue = Request["cercatxt"];
        if (strValue != null && strValue != ""){
            strWHERE = "((Anagrafiche_RagioneSociale like '%" + strValue + "%') Or (Anagrafiche_ParoleChiave like '%" + strValue + "%'))";
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
    
    public string getWhereCommesse(){
        string strWHERE="";
        string strWHEREPermessi="";
        string strValue="";

        strWHERE="(CommesseStato_Ky=4)";
        strValue = Request["cercatxt"];
        if (strValue != null && strValue != ""){
            strWHERE += " AND ((Commesse_Titolo like '%" + strValue + "%') OR (Anagrafiche_RagioneSociale like '%" + strValue + "%') OR (Anagrafiche_ParoleChiave like '%" + strValue + "%'))";
        }
     	  //permessi
      	if (boolAdmin==false){
        		switch (dtLogin.Rows[0]["UtentiGruppi_ProduzioneQuali"].ToString()){
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
  			if (strWHEREPermessi.Length>0){
  				if (strWHERE.Length>0){
  					strWHERE=strWHERE + " And " + strWHEREPermessi;
  				}else{
  					strWHERE=strWHEREPermessi;
  				}	
  			}	
  			
  		}
      return strWHERE;
    }
    
    
    public string getWherePassword(){
        string strWHERE="";
        string strWHEREPermessi="";
        string strValue="";

        strWHERE="";
        strValue = Request["cercatxt"];
        if (strValue != null && strValue != ""){
            strWHERE += "((PasswordManager_Titolo like '%" + strValue + "%') OR (Anagrafiche_RagioneSociale like '%" + strValue + "%') OR (Anagrafiche_ParoleChiave like '%" + strValue + "%'))";
        }
     	  //permessi
      	if (boolAdmin==false){
        		switch (dtLogin.Rows[0]["UtentiGruppi_ProduzioneQuali"].ToString()){
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
  			if (strWHEREPermessi.Length>0){
  				if (strWHERE.Length>0){
  					strWHERE=strWHERE + " And " + strWHEREPermessi;
  				}else{
  					strWHERE=strWHEREPermessi;
  				}	
  			}	
  			
  		}
      return strWHERE;
    }
    
    public string getWhereSitiWeb(){
        string strWHERE="";
        string strWHEREPermessi="";
        string strValue="";

        strWHERE="";
        strValue = Request["cercatxt"];
        if (strValue != null && strValue != ""){
            strWHERE += "((SitiWeb_Dominio like '%" + strValue + "%') OR (Anagrafiche_RagioneSociale like '%" + strValue + "%') OR (Anagrafiche_ParoleChiave like '%" + strValue + "%'))";
        }
     	  //permessi
      	if (boolAdmin==false){
        		switch (dtLogin.Rows[0]["UtentiGruppi_ProduzioneQuali"].ToString()){
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
  			if (strWHEREPermessi.Length>0){
  				if (strWHERE.Length>0){
  					strWHERE=strWHERE + " And " + strWHEREPermessi;
  				}else{
  					strWHERE=strWHEREPermessi;
  				}	
  			}	
  			
  		}
      return strWHERE;
    }
}
