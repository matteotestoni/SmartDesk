using System;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtAnagrafica;
    public DataTable dtDocumenti;
    public DataTable dtPagamenti;
    public DataTable dtCommesse;
    public DataTable dtAttivita;
    public int intAnagrafiche_Ky = 0;
    public string strAnagrafiche_Ky = "";
    public string strAnagrafiche_RagioneSociale = "";
    public string strCommesse_Ky = "";
    public string strPagamentiTipo_Ky="";
    public string strSpese_Ky="";
    public string strFROMNet = "";
    public string strH1 = "";
    public string strAzione = "modifica";
    public string strSorgente = "scheda-pagamenti";
    
    public string strData = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
 
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strH1="Scheda pagamento";
			strAzione = Request["azione"];
			if (strAzione==null || strAzione.Length<1){
				strAzione="modifica";	
			}
            strSorgente=Smartdesk.Current.Request("sorgente");
            strData=Request["data"];
            strCommesse_Ky=Smartdesk.Current.Request("Commesse_Ky");
            strSpese_Ky=Smartdesk.Current.Request("Spese_Ky");
            if (strAzione!="new"){
              strAzione = "modifica";
    	  	  dtPagamenti = Smartdesk.Data.Read("Pagamenti_Vw", "Pagamenti_Ky",Smartdesk.Current.QueryString("Pagamenti_Ky"));
              if (dtLogin.Rows[0]["UtentiGruppi_Produzione"].Equals(true) && dtPagamenti.Rows.Count>0){
				//Documenti
                strWHERENet="Anagrafiche_Ky=" + GetFieldValue(dtPagamenti, "Anagrafiche_Ky");
                strORDERNet = "Documenti_Data DESC";
                strFROMNet = "Documenti_Vw";
                dtDocumenti = new DataTable("Documenti");
                dtDocumenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
				//Commesse
                strWHERENet="Anagrafiche_Ky=" + GetFieldValue(dtPagamenti, "Anagrafiche_Ky");
                strORDERNet = "Commesse_Data DESC";
                strFROMNet = "Commesse_Vw";
                dtCommesse = new DataTable("Commesse");
                dtCommesse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
				//Attivita
              	strWHERENet="Pagamenti_Ky=" + Smartdesk.Current.Request("Pagamenti_Ky");
                strORDERNet = "Attivita_Ky DESC";
                strFROMNet = "Attivita_Vw";
                dtAttivita = new DataTable("Attivita");
                dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              }   
            }else{
              strPagamentiTipo_Ky = Request["PagamentiTipo_Ky"];
			        strAnagrafiche_Ky = Smartdesk.Current.Request("Anagrafiche_Ky");
              if (strAnagrafiche_Ky!=null && strAnagrafiche_Ky.Length>0){
                strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
                strORDERNet = "Anagrafiche_Ky";
                strFROMNet = "Anagrafiche";
                dtAnagrafica = new DataTable("Anagrafica");
                dtAnagrafica = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        			  strAnagrafiche_RagioneSociale=dtAnagrafica.Rows[0]["Anagrafiche_RagioneSociale"].ToString();
        			  if (dtLogin.Rows[0]["UtentiGruppi_Produzione"].Equals(true)){
          				//Documenti
                  strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
                  strORDERNet = "Documenti_Data DESC";
                  strFROMNet = "Documenti_Vw";
                  dtDocumenti = new DataTable("Documenti");
                  dtDocumenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          				//Commesse
                  strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
                  strORDERNet = "Commesse_Data DESC";
                  strFROMNet = "Commesse_Vw";
                  dtCommesse = new DataTable("Commesse");
                  dtCommesse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                }   
            }

			}            
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public String GetDefaultValue(string strField)
    {
      string strValore="";
      switch (strField){
			case "Anagrafiche_Ky":
				strValore=strAnagrafiche_Ky;
				break;
			case "Anagrafiche_RagioneSociale":
				strValore=strAnagrafiche_RagioneSociale;
				break;
			case "Spese_Ky":
				strValore=strSpese_Ky;
				break;
			case "Commesse_Ky":
				strValore=strCommesse_Ky;
				break;
			case "PagamentiTipo_Ky":
				strValore="1";
				break;
			case "Conti_Ky":
				strValore="1";
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
        strValore=Smartdesk.Data.Field(dtTabella,strField);
      }
      return strValore;
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
}
