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
    public DataTable dtAnagrafiche;
    public DataTable dtAttivita;
    public DataTable dtCommesse;
    public DataTable dtOpportunita;
    public string strAnagrafiche_Ky = "";
    public string strAnagrafiche_RagioneSociale = "";
    public string strOpportunita_Ky = "";
    public string strCommesse_Ky = "";
    public string strAttivita_Ky = "";
    public string strAttivitaTipo_Ky = "";
    public string strAttivitaSettore_Ky = "";
    public string strUtenti_Ky = "";
    public string strFROMNet = "";
    public string strH1 = "Scheda Trasferta";
    public string strAzione = "modifica";
    public string strSorgente = "";
    public string strStart = "";
    public string strEnd = "";
    public string strData = "";
    
    public string strTipo = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
            
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strAzione = Request["azione"];
            strSorgente=Smartdesk.Current.Request("sorgente");
            strAttivita_Ky=Request["Attivita_Ky"];
            strAttivitaTipo_Ky=Request["AttivitaTipo_Ky"];
            strAttivitaSettore_Ky=Smartdesk.Current.Request("AttivitaSettore_Ky");
            strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
            strOpportunita_Ky=Smartdesk.Current.Request("Opportunita_Ky");
            strCommesse_Ky=Smartdesk.Current.Request("Commesse_Ky");
            strUtenti_Ky=Smartdesk.Current.Request("Utenti_Ky");
            strStart=Request["start"];
            strEnd=Request["end"];
            strData=Request["data"];
			if (strAzione!="new"){
              strAzione = "modifica";
              if (strAttivita_Ky!=null && strAttivita_Ky.Length>0){
              	  dtAttivita = Smartdesk.Data.Read("Attivita_Vw", "Attivita_Ky",Smartdesk.Current.QueryString("Attivita_Ky"));
	              strAnagrafiche_Ky=GetFieldValue(dtAttivita, "Anagrafiche_Ky");
				  strAnagrafiche_RagioneSociale=GetFieldValue(dtAttivita, "Anagrafiche_RagioneSociale");
	              strCommesse_Ky=GetFieldValue(dtAttivita, "Commesse_Ky");
	              strOpportunita_Ky=GetFieldValue(dtAttivita, "Opportunita_Ky");
              }
            }else{
			 strTipo=Request["tipo"];
			 if (strAnagrafiche_Ky!=null && strAnagrafiche_Ky.Length>0){
	              strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
	              strORDERNet = "Anagrafiche_Ky";
	              strFROMNet = "Anagrafiche_Vw";
	              dtAnagrafiche = new DataTable("Anagrafiche");
	              dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
								strAnagrafiche_RagioneSociale=dtAnagrafiche.Rows[0]["Anagrafiche_RagioneSociale"].ToString();
							}
						}
            if (strAnagrafiche_Ky!=null && strAnagrafiche_Ky.Length>0){
							strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
	            strORDERNet = "Commesse_Ky";
	            strFROMNet = "Commesse_Vw";
	            dtCommesse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

				      strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
	            strORDERNet = "Opportunita_Ky";
	            strFROMNet = "Opportunita_Vw";
	            dtOpportunita = new DataTable("Opportunita");
	            dtOpportunita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Opportunita_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            }
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
				case "Attivita_Inizio_IT":
					if (strData!=null){
						strValore=strData;
					}else{
						strValore=DateTime.Now.ToString("d");
					}
					break;
				case "Attivita_Scadenza_IT":
					if (strData!=null){
						strValore=strData;
					}else{
						strValore=DateTime.Now.ToString("d");
					}
					break;
				case "Attivita_Chiusura_IT":
					if (strData!=null){
						strValore=strData;
					}else{
						strValore=DateTime.Now.ToString("d");
					}
					break;
				case "Attivita_OraInizio":
					if (strStart!=null){
						strValore=strStart;
					}else{
						strValore=DateTime.Now.ToString("HH:mm").Replace(".",":");
					}
					break;
				case "Attivita_OraScadenza":
					if (strEnd!=null){
						strValore=strEnd;
					}else{
						strValore="18:00";
					}
					break;
				case "AttivitaTipo_Ky":
					if (strAttivitaTipo_Ky!=null){
						strValore=strAttivitaTipo_Ky;
					}else{
						strValore="4";
					}
					break;
				case "AttivitaSettore_Ky":
					if (strAttivitaSettore_Ky!=null){
						strValore=strAttivitaSettore_Ky;
					}else{
						strValore="2";
					}
					break;
				case "Anagrafiche_Ky":
					strValore=strAnagrafiche_Ky;
					break;
				case "Anagrafiche_RagioneSociale":
					strValore=strAnagrafiche_RagioneSociale;
					break;
				case "Priorita_Ky":
					strValore="1";
					break;
				case "Attivita_Km":
					strValore="0";
					break;
				case "Attivita_RimborsoKm":
					strValore="0";
					break;
				case "Attivita_SpeseKm":
					strValore="0";
					break;
				case "Attivita_SpeseAutostrada":
					strValore="0";
					break;
				case "Attivita_SpeseParcheggi":
					strValore="0";
					break;
				case "Attivita_SpesePasti":
					strValore="0";
					break;
				case "Attivita_SpeseMezziPubblici":
					strValore="0";
					break;
				case "Attivita_SpeseTotali":
					strValore="0";
					break;
				case "Attivita_Trasferta":
					strValore="true";
					break;
				case "Attivita_Completo":
					strValore="true";
					break;
			}
      return strValore;
    }

    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        strValore=dtTabella.Rows[0][strField].ToString();
      }
      return strValore;
    }

    public decimal GetDecimalValue(string strField)
    {
      decimal dclValore=0;
      if (strAzione=="new"){
        dclValore=0;
      }else{
        if (dtAttivita.Rows[0][strField] == System.DBNull.Value || dtAttivita.Rows[0][strField].ToString()=="" || dtAttivita.Rows[0][strField].ToString().Length<1 ){
            dclValore=0;
        }else{
            dclValore=Convert.ToDecimal(dtAttivita.Rows[0][strField]);            
        }
      }                    
      return dclValore;
    }
    
    public Boolean GetCheckValue(DataTable dtTabella, string strField)
    {
        Boolean boolValore = false;
        if (strAzione == "new")
        {
            boolValore = false;
        }
        else
        {
            boolValore = Smartdesk.Data.FieldBool(dtTabella,strField);
        }
        return boolValore;
    }
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
