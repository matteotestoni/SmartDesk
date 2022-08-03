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
    public DataTable dtAste;
    public DataTable dtAsteEsperimenti;
    public DataTable dtAnnunci;
    public DataTable dtAnnunciOfferte;
    public DataTable dtAsteCauzioni;
    public DataTable dtDocumenti;
    public DataTable dtFiles;
    public DataTable dtAzienda;
    public DataTable dtAnagrafiche;
    public string strAste_Ky = "";
    public string strAsteEsperimenti_Ky = "";
    public string strAziende_Ky = "";
    public string strAnagrafiche_Ky = "";
    public string strFROMNet = "";
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strH1 = "";
    
    public DataTable dtAttributi;

    protected void Page_Load(object sender, EventArgs e)
    {
      
				
    //Smartdesk.Session.CurrentUser.ToString()="1";
	if (Smartdesk.Login.Verify){
        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
		boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
		strAste_Ky=Smartdesk.Current.Request("Aste_Ky");
		strAsteEsperimenti_Ky=Smartdesk.Current.Request("AsteEsperimenti_Ky");
		if (strAste_Ky==null || strAste_Ky.Length<1){
			strAste_Ky="1";
		}
		
		strAziende_Ky="1";            
		//servizi
		strWHERENet="Aziende_Ky=" + strAziende_Ky;
		strORDERNet = "Aziende_Ky";
		strFROMNet = "Aziende_Vw";
		dtAzienda = new DataTable("Azienda");
		dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

		dtAste = Smartdesk.Data.Read("Aste_Vw", "Aste_Ky", strAste_Ky );
		if (strAsteEsperimenti_Ky==null || strAsteEsperimenti_Ky.Length<1){
			dtAsteEsperimenti = Smartdesk.Data.Read("AsteEsperimenti_Vw", "Aste_Ky",strAste_Ky);
			dtAsteCauzioni = Smartdesk.Data.Read("AsteCauzioni_Vw", "Aste_Ky",strAste_Ky);
		}else{
			strWHERENet = "AsteEsperimenti_Ky=" + strAsteEsperimenti_Ky;
	        strORDERNet = "AsteEsperimenti_Ky";
	        strFROMNet = "AsteEsperimenti_Vw";
	        dtAsteEsperimenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "AsteEsperimenti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

			strWHERENet = "AsteEsperimenti_Ky=" + strAsteEsperimenti_Ky;
	        strORDERNet = "AsteCauzioni_Ky";
	        strFROMNet = "AsteCauzioni_Vw";
	        dtAsteCauzioni = Smartdesk.Sql.getTablePage(strFROMNet, null, "AsteCauzioni_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		}
        
		strWHERENet = "Aste_Ky=" + strAste_Ky;
        strORDERNet = "Annunci_Ky";
        strFROMNet = "Annunci_Vw";
        dtAnnunci = Smartdesk.Sql.getTablePage(strFROMNet, null, "Annunci_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
        strWHERENet = "Attributi_Annunci=1";
        strORDERNet = "Attributi_Ky";
        strFROMNet = "Attributi_Vw";
        dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

		strWHERENet = "Chiave_Tabella='Aste' AND Chiave_Ky=" + Smartdesk.Current.QueryString("Aste_Ky");
        strORDERNet = "Files_Ky";
        strFROMNet = "Files_Vw";
        dtFiles = Smartdesk.Sql.getTablePage(strFROMNet, null, "Files_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

		strAnagrafiche_Ky=dtAste.Rows[0]["Anagrafiche_Ky"].ToString();
		dtAnagrafiche = Smartdesk.Data.Read("Anagrafiche_Vw", "Anagrafiche_Ky", strAnagrafiche_Ky );
      
	  
	  }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    

    public string getAttributi(int indiceRecord)
    {
        string strOutput="";
        string strAttributi="";
        string strCodice="";
        string strTitolo="";
        string strTipo="";

        strOutput="";   
        strAttributi=dtAnnunci.Rows[indiceRecord]["AnnunciCategorie_Attributi"].ToString();
        if (strAttributi.Length>0){
          DataRow[] drAttributiElenco=dtAttributi.Select("Attributi_Ky IN(" + strAttributi + ")", "Attributi_Ordine");
          for (int x = 0; x < drAttributiElenco.Length; x++){
           strCodice=drAttributiElenco[x]["Attributi_Codice"].ToString();
           strTitolo=drAttributiElenco[x]["Attributi_Titolo"].ToString();
           strTipo=drAttributiElenco[x]["AttributiTipo_Ky"].ToString();
           if (dtAnnunci.Rows[indiceRecord][strCodice].ToString().Length>0 && dtAnnunci.Rows[indiceRecord][strCodice].ToString()!="0"){
                  switch (strTipo){
                    case "1":
                        strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                        break;  
                    case "2":
                        strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                        break;  
                    case "3":
                        strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-calendar-days fa-fw\"></i>" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                        break;  
                    case "4":
                        strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-square-check fa-fw\"></i>" + strTitolo + "&nbsp;&nbsp;</span>";
                        break;  
                    case "5":
                        strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                        break;  
                    case "6":
                        strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                        break;                  
                  }
           }
          }
        }

        return strOutput;
    }
}
