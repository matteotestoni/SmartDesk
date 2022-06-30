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
    public DataTable dtAnagraficheServizi;
    public DataTable dtAnagraficheServiziAttributi;
    public DataTable dtAnagrafiche;
    public DataTable dtCommesse;
    public string strCommesse_Ky = "";
    public string strAnagraficheServizi_Ky = "";
    public string strAnagrafiche_Ky = "";
    public string strAnagrafiche_RagioneSociale = "";
    public string strFROMNet = "";
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strH1 = "Servizi";
    public string strAzione = "modifica";
    public string strSorgente = "";
    
    public string strData = "";
    public DataTable dtAttributi;
    public DataTable dtAttributiGruppi;
    public DataTable dtAttributiOpzioni;

    protected void Page_Load(object sender, EventArgs e)
    {

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
            
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strH1="Scheda servizio";
			      strAzione = Request["azione"];
            strSorgente=Smartdesk.Current.Request("sorgente");
            strAnagraficheServizi_Ky=Smartdesk.Current.Request("AnagraficheServizi_Ky");
            strAnagraficheServizi_Ky=Request["AnagraficheServizi_Ky"];
            strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
            strCommesse_Ky=Smartdesk.Current.Request("Commesse_Ky");
            if (strAzione!="new"){
              strAzione = "modifica";
				      strWHERENet="AnagraficheServizi_Ky=" + strAnagraficheServizi_Ky;
	            strORDERNet = "AnagraficheServizi_Ky";
	            strFROMNet = "AnagraficheServizi_Lettura_Vw";
	            dtAnagraficheServizi = new DataTable("AnagraficheServizi");
	            dtAnagraficheServizi = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

      			  //attributi
              strWHERENet="AnagraficheServizi_Ky=" + strAnagraficheServizi_Ky;
              strORDERNet="AnagraficheServizi_Ky";
      			  dtAnagraficheServiziAttributi = new DataTable("AnagraficheServiziAttributi");
              dtAnagraficheServiziAttributi = Smartdesk.Sql.getTablePage("AnagraficheServizi", null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			  
      			  strAnagrafiche_Ky=GetFieldValue(dtAnagraficheServizi, "Anagrafiche_Ky");
      			  strAnagrafiche_RagioneSociale=GetFieldValue(dtAnagraficheServizi, "Anagrafiche_RagioneSociale");
	           	if (strAnagrafiche_Ky!=null && strAnagrafiche_Ky.Length>0){
              	dtCommesse = Smartdesk.Data.Read("Commesse_Vw", "Anagrafiche_Ky",strAnagrafiche_Ky);
	            }
	            if (GetFieldValue(dtAnagraficheServizi, "AttributiGruppi_Ky")!=null && GetFieldValue(dtAnagraficheServizi, "AttributiGruppi_Ky").Length>0 && GetFieldValue(dtAnagraficheServizi, "AttributiGruppi_Ky")!="0"){
								
					      strWHERENet="AttributiGruppi_Ky=" + GetFieldValue(dtAnagraficheServizi, "AttributiGruppi_Ky");
		            strORDERNet = "AttributiGruppi_Ky";
		            strFROMNet = "AttributiGruppi";
		            dtAttributiGruppi = new DataTable("AttributiGruppi");
		            dtAttributiGruppi = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttributiGruppi_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

					      if (dtAttributiGruppi.Rows[0]["AttributiGruppi_Attributi"].ToString().Length>0){
                  strWHERENet="Attributi_Ky in (" + dtAttributiGruppi.Rows[0]["AttributiGruppi_Attributi"].ToString() + ") AND Attributi_Servizi=1";
		              strORDERNet = "Attributi_Ky";
		              strFROMNet = "Attributi_Vw";
		              dtAttributi = new DataTable("Attributi");
		              dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                }
					      dtAttributiOpzioni = new DataTable("AttributiOpzioni");
	            }

            }else{
							if (strAnagrafiche_Ky!=null && strAnagrafiche_Ky.Length>0){
	              strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
	              strORDERNet = "Anagrafiche_Ky";
	              strFROMNet = "Anagrafiche_Vw";
	              dtAnagrafiche = new DataTable("Anagrafiche");
	              dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
								strAnagrafiche_RagioneSociale=dtAnagrafiche.Rows[0]["Anagrafiche_RagioneSociale"].ToString();
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
				case "AnagraficheServizi_Scadenza":
					if (strData!=null){
						strValore=strData;
					}else{
						strValore=DateTime.Now.ToString("d");
					}
					break;
				case "AnagraficheServizi_Scadenza_IT":
					if (strData!=null){
						strValore=strData;
					}else{
						strValore=DateTime.Now.ToString("d");
					}
					break;
				case "AnagraficheServizi_Qta":
					strValore="1";
					break;
				case "AnagraficheServizi_Prezzo":
					strValore="0";
					break;
				case "AnagraficheServizi_Importo":
					strValore="0";
					break;
				case "Anagrafiche_Ky":
					strValore=strAnagrafiche_Ky;
					break;
				case "Anagrafiche_RagioneSociale":
					strValore=strAnagrafiche_RagioneSociale;
					break;


			}
      return strValore;
    }

    public String GetAttributoValue(string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        try{
					strValore=dtAnagraficheServiziAttributi.Rows[0][strField].ToString();
        }catch{
        	strValore="";
				}
      }
      return strValore;
    }

    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="";
      }else{
        strValore=Smartdesk.Data.Field(dtTabella,strField);
      }
      return strValore;
    }
    
    public String GetMoneyValue(string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        strValore=dtAnagraficheServizi.Rows[0][strField].ToString();
        strValore=strValore.Replace(",00","");
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
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
