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
    public DataTable dtTemp;
    public DataTable dtDocumentiTipo;
    public DataTable dtDocumenti;
    public DataTable dtDocumentiCorpo;
    public DataTable dtPagamenti;
    public DataTable dtCommesse;
    public DataTable dtCommessa;
    public DataTable dtAttivita;
    public DataTable dtNote;
    public DataTable dtOpportunita;
    public string strAnagrafiche_Ky = "";
    public string strAnagrafiche_RagioneSociale = "";
    public string strCommesse_Ky = "";
    public string strDocumenti_Ky = "";
    public string strOpportunita_Ky = "";
    public string strFROMNet = "";
    public string strH1 = "Scheda documento";
    public string strAzione = "modifica";
    public string strDocumenti_Descrizione = "";
    public string strRiferimenti = "";
    public string strCheckPartitaIVA = "";
    public string strCheckCodiceFiscale = "";
    
    public decimal decTot=0; 
    public decimal decTotQta=0; 
    public decimal decTotIVA=0; 
    public decimal decIVA=0; 
    public string strAlert = "";
    public string strAziende_Ky = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
            
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strAzione = Request["azione"];
            strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
            strCommesse_Ky=Smartdesk.Current.Request("Commesse_Ky");
            strDocumenti_Ky=Smartdesk.Current.Request("Documenti_Ky");
            strAziende_Ky=Smartdesk.Current.Request("Aziende_Ky");
            strOpportunita_Ky=Smartdesk.Current.Request("Opportunita_Ky");

            if (strAzione!="new"){
            	strAzione="modifica";
    	  	  	dtDocumenti = Smartdesk.Data.Read("Documenti_Vw", "Documenti_Ky",Smartdesk.Current.QueryString("Documenti_Ky"));
				strAnagrafiche_Ky=dtDocumenti.Rows[0]["Anagrafiche_Ky"].ToString();
				strCommesse_Ky=dtDocumenti.Rows[0]["Commesse_Ky"].ToString();
				strOpportunita_Ky=dtDocumenti.Rows[0]["Opportunita_Ky"].ToString();
				if (Smartdesk.Functions.ControllaPartitaIva(dtDocumenti.Rows[0]["Anagrafiche_PartitaIVA"].ToString())){
					strCheckPartitaIVA="<span class=\"badge success\">Corretta</span>";
				}else{
					strCheckPartitaIVA="<span class=\"badge alert\">Errore di validazione</span>";
				}
				if (dtDocumenti.Rows[0]["Anagrafiche_CodiceFiscale"].ToString().Length>0){
					if (Smartdesk.Functions.ControllaCodiceFiscale(dtDocumenti.Rows[0]["Anagrafiche_CodiceFiscale"].ToString())){
						strCheckCodiceFiscale="<span class=\"badge success\">Corretto</span>";
					}else{
						strCheckCodiceFiscale="<span class=\"badge alert\">Errore di validazione</span>";
					}
				}
                //servizi
                strWHERENet="Documenti_Ky=" + strDocumenti_Ky;
                strORDERNet = "DocumentiCorpo_Ky";
                strFROMNet = "DocumentiCorpo_Vw";
                dtDocumentiCorpo = new DataTable("DocumentiCorpo");
                dtDocumentiCorpo = Smartdesk.Sql.getTablePage(strFROMNet, null, "DocumentiCorpo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
                //pagamenti
                strWHERENet="Documenti_Ky=" + strDocumenti_Ky;
                strORDERNet = "Pagamenti_Data";
                strFROMNet = "Pagamenti_Vw";
                dtPagamenti = new DataTable("Pagamenti");
                dtPagamenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                //Attività
                strWHERENet="Documenti_Ky=" + strDocumenti_Ky;
                strORDERNet = "Attivita_Ky DESC";
                strFROMNet = "Attivita_Vw";
                dtAttivita = new DataTable("Attivita");
                dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                //Note
                strWHERENet="Documenti_Ky=" + strDocumenti_Ky;
                strORDERNet = "Note_Ky DESC";
                strFROMNet = "Note_Vw";
                dtNote = new DataTable("Note");
                dtNote = Smartdesk.Sql.getTablePage(strFROMNet, null, "Note_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            }else{
				strAzione="new";			
				if (strCommesse_Ky!=null && strCommesse_Ky.Length>0){
		            strWHERENet="Commesse_Ky=" + strCommesse_Ky;
		            strORDERNet = "Commesse_Ky";
		            strFROMNet = "Commesse_Vw";
		            dtCommessa = new DataTable("Commessa");
		            dtCommessa = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		            strDocumenti_Descrizione=dtCommessa.Rows[0]["Commesse_Titolo"].ToString();
		            strRiferimenti=dtCommessa.Rows[0]["Commesse_Riferimenti"].ToString();
		            strAnagrafiche_RagioneSociale=dtCommessa.Rows[0]["Anagrafiche_RagioneSociale"].ToString();
		        }
			}            
			if (strAnagrafiche_Ky!=null && strAnagrafiche_Ky.Length>0){
	            strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
	            strORDERNet = "Commesse_Ky";
	            strFROMNet = "Commesse_Vw";
		          dtCommesse = new DataTable("Commessa");
	            dtCommesse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              //Opportunita
              strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
              strORDERNet = "Opportunita_Ky DESC";
              strFROMNet = "Opportunita_Vw";
              dtOpportunita = new DataTable("Opportunita");
              dtOpportunita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Opportunita_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            }

            strWHERENet="";
            strFROMNet = "DocumentiTipo";
            strORDERNet = "DocumentiTipo_Ordine";
            dtDocumentiTipo = new DataTable("DocumentiTipo");
            dtDocumentiTipo = Smartdesk.Sql.getTablePage(strFROMNet, null, "DocumentiTipo_Ky", strWHERENet, strORDERNet, 1,100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
		
    public String GetDefaultValue(string strField)
    {
      string strValore="";
      switch (strField){
				case "Documenti_Data_IT":
					strValore=DateTime.Now.ToString("d");
					break;
				case "Documenti_Numero":
					if (strAziende_Ky==null || strAziende_Ky.Length<1){
						strAziende_Ky="1";
					}
					strValore=GetNewNumDoc(DateTime.Now.Year, strAziende_Ky);
					break;
				case "Anagrafiche_Ky":
					strValore=strAnagrafiche_Ky;
					break;
				case "Anagrafiche_RagioneSociale":
					strValore=strAnagrafiche_RagioneSociale;
					break;
				case "Commesse_Ky":
					strValore=strCommesse_Ky;
					break;
				case "DocumentiTipo_Ky":
					strValore=Request["DocumentiTipo_Ky"];
					break;
				case "DocumentiStato_Ky":
					strValore="2";
					break;
				case "Documenti_Descrizione":
					strValore=strDocumenti_Descrizione;
					break;
				case "Documenti_Riferimenti":
					strValore=strRiferimenti;
					break;
				case "Negozi_Ky":
					strValore="1";
					break;
				case "Aziende_Ky":
					strValore="1";
					break;
			}
      return strValore;
    }

    public String GetNewNumDoc(int intAnno, string strAzienda)
    {
  	string strWHERE="Documenti_Anno=" + intAnno + " AND Aziende_Ky=" + strAzienda;
  	int intUltimoNumero=0;
  	string strNuovoNumero="";
		dtTemp = new DataTable("GetNewNumDoc");
		dtTemp = Smartdesk.Sql.getTablePage("Documenti_Vw", null, "Documenti_Ky", strWHERE, "Documenti_Numero DESC", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		if (dtTemp!=null && dtTemp.Rows.Count>0){
			intUltimoNumero=Convert.ToInt32(dtTemp.Rows[0]["Documenti_Numero"]);
		}     
		strNuovoNumero=(intUltimoNumero+1).ToString();
      return strNuovoNumero;
    }

    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        strValore=Smartdesk.Data.Field(dtTabella,strField);
      }
      return strValore;
    }

    public decimal GetDecimalValue(string strField)
    {
      decimal dclValore=0;
      if (strAzione=="new"){
        dclValore=0;
      }else{
        try{
	        if (dtDocumenti.Rows.Count>0 && dtDocumenti.Rows[0][strField]!=null && dtDocumenti.Rows[0][strField]!=System.DBNull.Value){
				try{
					dclValore=(decimal)dtDocumenti.Rows[0][strField];
				}catch{
        			dclValore=0;
				}
			}else{
				dclValore=0;
			}
        }catch{
        	dclValore=0;
		}
      }
      return dclValore;
    }
    
    public Boolean GetCheckValue(string strField)
    {
      Boolean boolValore=false;
      if (strAzione=="new"){
        boolValore=false;
      }else{
        if (dtDocumenti.Rows[0][strField].Equals(true)){
          boolValore=true;
        }
      }
      return boolValore;
    }
    
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
