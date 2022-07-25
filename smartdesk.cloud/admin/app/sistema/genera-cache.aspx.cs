using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.IO;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ciit = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo cien = new System.Globalization.CultureInfo("en-US");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtTemp;
    public DataTable dtTempFigli;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strRisultato = "";
    public string strTemp = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      StreamWriter sw;
      StreamWriter swJson;
      int i=0;

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            strH1="Aggiornamento cache";
  	        strRisultato="<ul>";
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            
            //CoreResponseCode
            strWHERENet="";
            strORDERNet = "CoreResponseCode_Title";
            strFROMNet = "CoreResponseCode";
            dtTemp = new DataTable("CoreResponseCode");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreResponseCode_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            sw = new StreamWriter(Server.MapPath("/var/cache/CoreResponseCode-options.htm"), false, System.Text.Encoding.Default);
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["CoreResponseCode_Ky"].ToString() + "\">" + dtTemp.Rows[i]["CoreResponseCode_Title"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " CoreResponseCode</li>";        
            
            
            //categorie CMS
            strWHERENet="";
            strORDERNet = "CMSCategorie_Descrizione";
            strFROMNet = "CMSCategorie";
            dtTemp = new DataTable("CMSCategorie");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSCategorie_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            sw = new StreamWriter(Server.MapPath("/var/cache/CMSCategorie-options.htm"), false, System.Text.Encoding.Default);
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["CMSCategorie_Ky"].ToString() + "\">" + dtTemp.Rows[i]["CMSCategorie_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " categorie CMS generati</li>";        
            //Tipo contenuti CMS
            strWHERENet="";
            strORDERNet = "CMSContenutiTipo_Titolo";
            strFROMNet = "CMSContenutiTipo";
            dtTemp = new DataTable("CMSContenutiTipo");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSContenutiTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            sw = new StreamWriter(Server.MapPath("/var/cache/CMSContenutiTipo-options.htm"), false, System.Text.Encoding.Default);
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["CMSContenutiTipo_Ky"].ToString() + "\">" + dtTemp.Rows[i]["CMSContenutiTipo_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipo di contenuti CMS generati</li>";        
            
			//tags CMS
          	strWHERENet="";
            strORDERNet = "CMSTags_Titolo";
            strFROMNet = "CMSTags";
            dtTemp = new DataTable("CMSTags");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSTags_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            sw = new StreamWriter(Server.MapPath("/var/cache/CMSTags-options.htm"), false, System.Text.Encoding.Default);
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["CMSTags_Ky"].ToString() + "\">" + dtTemp.Rows[i]["CMSTags_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tags CMS generati</li>";        
			
			//fusi orari
          	strWHERENet="";
            strORDERNet = "TimeZones_TimeZone";
            strFROMNet = "TimeZones";
            dtTemp = new DataTable("TimeZones");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "TimeZones_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            sw = new StreamWriter(Server.MapPath("/var/cache/TimeZones-options.htm"), false, System.Text.Encoding.Default);
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["TimeZones_Ky"].ToString() + "\">" + dtTemp.Rows[i]["TimeZones_TimeZone"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " fusi orari generati</li>";        
			            
            //aziende
            sw = new StreamWriter(Server.MapPath("/var/cache/Aziende-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "Aziende_Ky";
              strFROMNet = "Aziende";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  if (dtTemp.Rows[i]["Aziende_Attiva"].Equals(true)){
					  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Aziende_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Aziende_RagioneSociale"].ToString() + "</option>");
				  }else{
					  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Aziende_Ky"].ToString() + "\" disabled=\"disabled\">" + dtTemp.Rows[i]["Aziende_RagioneSociale"].ToString() + "</option>");
				  }
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " aziende generate</li>";        
            
			//Negozi
            sw = new StreamWriter(Server.MapPath("/var/cache/Negozi-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "Negozi_Ky";
              strFROMNet = "Negozi";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Negozi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Negozi_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Negozi_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " negozi generati</li>";        

            //Ore
            sw = new StreamWriter(Server.MapPath("/var/cache/Ore-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "Ore_Ordine";
              strFROMNet = "Ore";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Ore_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  strTemp=((decimal)dtTemp.Rows[i]["Ore_Valore"]).ToString("N1", cien);
                  strTemp=strTemp.Replace(".00","");
				  if (dtTemp.Rows[i]["Ore_Disabilita"].Equals(true)){
					  sw.WriteLine("<option value=\"" + strTemp + "\" disabled>" + dtTemp.Rows[i]["Ore_Titolo"].ToString() + " (non selezionabile)</option>");
				  }else{
					  sw.WriteLine("<option value=\"" + strTemp + "\">" + dtTemp.Rows[i]["Ore_Titolo"].ToString() + "</option>");
				  }
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " ore generate</li>";        

            //Conti
            sw = new StreamWriter(Server.MapPath("/var/cache/Conti-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "Conti_Titolo";
              strFROMNet = "Conti";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Conti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
				  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Conti_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Conti_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " conti generati</li>";        

            //centri di costi e ricavi
            sw = new StreamWriter(Server.MapPath("/var/cache/CentridiCR-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="(CentridiCR_Padre Is Null Or CentridiCR_Padre=0) AND (CentridiCR_Attivo=1)";
              strORDERNet = "CentridiCR_Titolo";
              strFROMNet = "CentridiCR";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "CentridiCR_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){

              	strWHERENet="CentridiCR_Padre=" + dtTemp.Rows[i]["CentridiCR_Ky"].ToString() + " AND CentridiCR_Attivo=1";
      		      dtTempFigli = Smartdesk.Sql.getTablePage("CentridiCR", null, "CentridiCR_Ky", strWHERENet, "CentridiCR_Titolo", 1, 10000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          	    if (dtTempFigli.Rows.Count>0){
                    sw.WriteLine("<optgroup label=\"" + dtTemp.Rows[i]["CentridiCR_Titolo"].ToString() + "\">");
                    sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["CentridiCR_Ky"].ToString() + "\">" + dtTemp.Rows[i]["CentridiCR_Titolo"].ToString() + "</option>");
                    for (int j = 0; j < dtTempFigli.Rows.Count; j++){
                       sw.WriteLine("<option value=\"" + dtTempFigli.Rows[j]["CentridiCR_Ky"].ToString() + "\">" + dtTempFigli.Rows[j]["CentridiCR_Titolo"].ToString() + "</option>");
                    }
                    sw.WriteLine("</optgroup>"); 
                 }else{
                   sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["CentridiCR_Ky"].ToString() + "\">" + dtTemp.Rows[i]["CentridiCR_Titolo"].ToString() + "</option>");
                 }
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " centri di costi e ricavi generati</li>";        

            //gruppi di attributi
            sw = new StreamWriter(Server.MapPath("/var/cache/AttributiGruppi-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AttributiGruppi_Titolo";
              strFROMNet = "AttributiGruppi";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttributiGruppi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AttributiGruppi_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AttributiGruppi_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " gruppi di attributi generati</li>";        

            //utenti
            sw = new StreamWriter(Server.MapPath("/var/cache/Utenti-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="Utenti_Attivo=1";
              strORDERNet = "Utenti_Nominativo";
              strFROMNet = "Utenti";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Utenti_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Utenti_Nominativo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " utenti generati</li>";        

            //Persone select2
            sw = new StreamWriter(Server.MapPath("/var/cache/Utenti-options-select2.htm"), false, System.Text.Encoding.Default);
              strWHERENet="Utenti_Attivo=1";
              strORDERNet = "Utenti_Nominativo";
              strFROMNet = "Utenti";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                if (dtTemp.Rows[i]["Utenti_Logo"].ToString().Length>0){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Utenti_Ky"].ToString() + "\" data-img=\"" + dtTemp.Rows[i]["Utenti_Logo"].ToString() + "\">" + dtTemp.Rows[i]["Utenti_Nominativo"].ToString()  + "</option>");
                }else{
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Utenti_Ky"].ToString() + "\" data-icon=\"fa-duotone fa-user\" data-color=\"" + dtTemp.Rows[i]["Utenti_Colore"].ToString() + "\">" + dtTemp.Rows[i]["Utenti_Nominativo"].ToString() + "</option>");
                }
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Persone generate</li>";        


            //gruppi di utenti
            sw = new StreamWriter(Server.MapPath("/var/cache/UtentiGruppi-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "UtentiGruppi_Descrizione";
              strFROMNet = "UtentiGruppi";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "UtentiGruppi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["UtentiGruppi_Ky"].ToString() + "\">" + dtTemp.Rows[i]["UtentiGruppi_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " gruppi di utenti generati</li>";        

            //tipo documenti
            sw = new StreamWriter(Server.MapPath("/var/cache/DocumentiTipo-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "DocumentiTipo_Ordine, DocumentiTipo_Descrizione";
              strFROMNet = "DocumentiTipo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "DocumentiTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["DocumentiTipo_Ky"].ToString() + "\" report=\"" + dtTemp.Rows[i]["DocumentiTipo_Report"].ToString() + "\">" + dtTemp.Rows[i]["DocumentiTipo_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipo documenti generati</li>";        
            
						//colori
            sw = new StreamWriter(Server.MapPath("/var/cache/Colori-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "Colori_Ordine";
              strFROMNet = "Colori";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Colori_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Colori_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Colori_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " colori generati</li>";        
            
			//stato documenti
            sw = new StreamWriter(Server.MapPath("/var/cache/DocumentiStato-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "DocumentiStato_Descrizione";
              strFROMNet = "DocumentiStato";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "DocumentiStato_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["DocumentiStato_Ky"].ToString() + "\">" + dtTemp.Rows[i]["DocumentiStato_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " stato documenti generati</li>";        

            //tipo anagrafiche
            sw = new StreamWriter(Server.MapPath("/var/cache/AnagraficheTipo-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AnagraficheTipo_Descrizione";
              strFROMNet = "AnagraficheTipo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AnagraficheTipo_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AnagraficheTipo_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipo anagrafiche generati</li>";        
            
						//gruppi anagrafiche
            sw = new StreamWriter(Server.MapPath("/var/cache/AnagraficheGruppi-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AnagraficheGruppi_Titolo";
              strFROMNet = "AnagraficheGruppi";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheGruppi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AnagraficheGruppi_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AnagraficheGruppi_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " gruppi anagrafiche generati</li>";        

            //tipologia file
            sw = new StreamWriter(Server.MapPath("/var/cache/FilesTipo-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "FilesTipo_Titolo";
              strFROMNet = "FilesTipo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "FilesTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["FilesTipo_Ky"].ToString() + "\">" + dtTemp.Rows[i]["FilesTipo_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipologia anagrafiche generati</li>";        

            //tipologia anagrafiche
            sw = new StreamWriter(Server.MapPath("/var/cache/AnagraficheTipologia-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AnagraficheTipologia_Ordine";
              strFROMNet = "AnagraficheTipologia";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheTipologia_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AnagraficheTipologia_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AnagraficheTipologia_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipologia anagrafiche generati</li>";        
            
			//stati opportunita options
            sw = new StreamWriter(Server.MapPath("/var/cache/OpportunitaStati-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "OpportunitaStati_Titolo";
              strFROMNet = "OpportunitaStati";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "OpportunitaStati_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["OpportunitaStati_Ky"].ToString() + "\">" + dtTemp.Rows[i]["OpportunitaStati_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " stati trattative (options) generati</li>";        
			//stati opportunita radio
            sw = new StreamWriter(Server.MapPath("/var/cache/OpportunitaStati-radio.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "OpportunitaStati_Ordine";
              strFROMNet = "OpportunitaStati";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "OpportunitaStati_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<div class=\"button-group round toggle small\">");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<input type=\"radio\" id=\"opportunitastati-" + dtTemp.Rows[i]["OpportunitaStati_Ky"].ToString() + "\" name=\"OpportunitaStati_Ky\" value=\"" + dtTemp.Rows[i]["OpportunitaStati_Ky"].ToString() + "\" /><label for=\"opportunitastati-" + dtTemp.Rows[i]["OpportunitaStati_Ky"].ToString() + "\" class=\"button\"><i class=\"" + dtTemp.Rows[i]["OpportunitaStati_Icona"].ToString() + " fa-fw\"></i>"  + dtTemp.Rows[i]["OpportunitaStati_Titolo"].ToString() + "</label>");
              }
              sw.WriteLine("</div>");
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " stati trattative (radio) generati</li>";        
			     //sorgenti opportunita options
            sw = new StreamWriter(Server.MapPath("/var/cache/OpportunitaSorgenti-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="OpportunitaSorgenti_Attiva=1";
              strORDERNet = "OpportunitaSorgenti_Titolo";
              strFROMNet = "OpportunitaSorgenti";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "OpportunitaSorgenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["OpportunitaSorgenti_Ky"].ToString() + "\">" + dtTemp.Rows[i]["OpportunitaSorgenti_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " sorgenti trattative (options) generati</li>";        

            
			//tipo contatti
            sw = new StreamWriter(Server.MapPath("/var/cache/AnagraficheContattiTipo-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AnagraficheContattiTipo_Descrizione";
              strFROMNet = "AnagraficheContattiTipo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheContattiTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AnagraficheContattiTipo_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AnagraficheContattiTipo_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipo contatti generati</li>";        
			
			//tipo di siti web
            sw = new StreamWriter(Server.MapPath("/var/cache/SitiWebTipo-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "SitiWebTipo_Titolo";
              strFROMNet = "SitiWebTipo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWebTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["SitiWebTipo_Ky"].ToString() + "\">" + dtTemp.Rows[i]["SitiWebTipo_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipo siti web generati</li>";        
            
            //Aliquote iva
            sw = new StreamWriter(Server.MapPath("/var/cache/AliquoteIVA-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AliquoteIVA_Descrizione";
              strFROMNet = "AliquoteIVA";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AliquoteIVA_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AliquoteIVA_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AliquoteIVA_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Aliquote generate</li>";        
            
            //PersoneAssenzeTipo
            sw = new StreamWriter(Server.MapPath("/var/cache/PersoneAssenzeTipo-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "PersoneAssenzeTipo_Descrizione";
              strFROMNet = "PersoneAssenzeTipo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "PersoneAssenzeTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["PersoneAssenzeTipo_Ky"].ToString() + "\">" + dtTemp.Rows[i]["PersoneAssenzeTipo_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipo di assenze generate</li>";        
            
            //Mesi
            sw = new StreamWriter(Server.MapPath("/var/cache/Mesi-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "Mesi_Ky";
              strFROMNet = "Mesi";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Mesi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Mesi_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Mesi_Mese"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Mesi generati</li>";        
            
            //Priorita select
            sw = new StreamWriter(Server.MapPath("/var/cache/Priorita-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "Priorita_Ordine";
              strFROMNet = "Priorita";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Priorita_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Priorita_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Priorita_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Priorit&agrave; (select)</li>";        
						
            //Priorita select2
            sw = new StreamWriter(Server.MapPath("/var/cache/Priorita-options-select2.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "Priorita_Ordine";
              strFROMNet = "Priorita";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Priorita_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  if (dtTemp.Rows[i]["Priorita_Icona"].ToString().Length>0){
                    sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Priorita_Ky"].ToString() + "\" data-icon=\"" + dtTemp.Rows[i]["Priorita_Icona"].ToString() + "\" data-color=\"" + dtTemp.Rows[i]["Priorita_Colore"].ToString() + "\">" + dtTemp.Rows[i]["Priorita_Descrizione"].ToString() + "</option>");
                  }else{
                    sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Priorita_Ky"].ToString() + "\" data-icon=\"" + dtTemp.Rows[i]["Priorita_Icona"].ToString() + "\" data-color=\"" + dtTemp.Rows[i]["Priorita_Colore"].ToString() + "\">" + dtTemp.Rows[i]["Priorita_Descrizione"].ToString() + "</option>");
                  }
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Priorit&agrave; (select)</li>";        

            //Priorita radio
            sw = new StreamWriter(Server.MapPath("/var/cache/Priorita-radio.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "Priorita_Ordine";
              strFROMNet = "Priorita";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Priorita_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<div class=\"button-group round toggle small\">");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  if (dtTemp.Rows[i]["Priorita_Icona"].ToString().Length>0){
				  	sw.WriteLine("<input type=\"radio\" id=\"priorita-" + dtTemp.Rows[i]["Priorita_Ky"].ToString() + "\" name=\"Priorita_Ky\" value=\"" + dtTemp.Rows[i]["Priorita_Ky"].ToString() + "\" /><label class=\"button\" for=\"priorita-" + dtTemp.Rows[i]["Priorita_Ky"].ToString() + "\"><i class=\"" + dtTemp.Rows[i]["Priorita_Icona"].ToString() + " fa-fw fa-lg\"></i>" + dtTemp.Rows[i]["Priorita_Descrizione"].ToString() + "</label>");
				  }else{
				  	sw.WriteLine("<input type=\"radio\" id=\"priorita-" + dtTemp.Rows[i]["Priorita_Ky"].ToString() + "\" name=\"Priorita_Ky\" value=\"" + dtTemp.Rows[i]["Priorita_Ky"].ToString() + "\" /><label class=\"button\" for=\"priorita-" + dtTemp.Rows[i]["Priorita_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Priorita_Descrizione"].ToString() + "</label>");
				  }
              }
              sw.WriteLine("</div>");
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Priorit&agrave; (radio)</li>";        
                        
						//stati attivita radio
            sw = new StreamWriter(Server.MapPath("/var/cache/AttivitaStati-radio.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AttivitaStati_Ordine";
              strFROMNet = "AttivitaStati";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttivitaStati_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<div class=\"button-group round toggle small\">");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<input type=\"radio\" id=\"attivitastati-" + dtTemp.Rows[i]["AttivitaStati_Ky"].ToString() + "\" name=\"AttivitaStati_Ky\" value=\"" + dtTemp.Rows[i]["AttivitaStati_Ky"].ToString() + "\" /><label for=\"attivitastati-" + dtTemp.Rows[i]["AttivitaStati_Ky"].ToString() + "\" class=\"button\"><i class=\"" + dtTemp.Rows[i]["AttivitaStati_Icona"].ToString() + " fa-fw\"></i>"  + dtTemp.Rows[i]["AttivitaStati_Titolo"].ToString() + "</label>");
              }
              sw.WriteLine("</div>");
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " stati attivit&agrave; (radio) generati</li>";        
            //stati attivita select
            sw = new StreamWriter(Server.MapPath("/var/cache/AttivitaStati-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AttivitaStati_Ordine";
              strFROMNet = "AttivitaStati";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttivitaStati_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AttivitaStati_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AttivitaStati_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " stati attivit&agrave; (select)</li>";        

            //stati attivita select2
            sw = new StreamWriter(Server.MapPath("/var/cache/AttivitaStati-options-select2.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AttivitaStati_Ordine";
              strFROMNet = "AttivitaStati";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttivitaStati_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AttivitaStati_Ky"].ToString() + "\" data-icon=\"" + dtTemp.Rows[i]["AttivitaStati_Icona"].ToString() + "\" data-color=\"" + dtTemp.Rows[i]["AttivitaStati_Colore"].ToString() + "\">" + dtTemp.Rows[i]["AttivitaStati_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " stati attivit&agrave; (select)</li>";        

            //Tipo attivita select
            sw = new StreamWriter(Server.MapPath("/var/cache/AttivitaTipo-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="AttivitaTipo_Attiva=1";
              strORDERNet = "AttivitaTipo_Ky";
              strFROMNet = "AttivitaTipo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttivitaTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AttivitaTipo_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AttivitaTipo_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipi di attivit&agrave; (select)</li>";        
            
			      //Tipo attivita radio
            sw = new StreamWriter(Server.MapPath("/var/cache/AttivitaTipo-radio.htm"), false, System.Text.Encoding.Default);
              strWHERENet="AttivitaTipo_Attiva=1";
              strORDERNet = "AttivitaTipo_Ky";
              strFROMNet = "AttivitaTipo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttivitaTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<div class=\"button-group round toggle small\">");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<input class=\"button\" type=\"radio\" id=\"attivita-" + dtTemp.Rows[i]["AttivitaTipo_Ky"].ToString() + "\" name=\"AttivitaTipo_Ky\" value=\"" + dtTemp.Rows[i]["AttivitaTipo_Ky"].ToString() + "\" /><label class=\"button\" for=\"attivita-" + dtTemp.Rows[i]["AttivitaTipo_Ky"].ToString() + "\"><i class=\"" + dtTemp.Rows[i]["AttivitaTipo_Icona"].ToString() + " fa-fw fa-lg\"></i>" + dtTemp.Rows[i]["AttivitaTipo_Descrizione"].ToString() + "</label>");
              }
              sw.WriteLine("</div>");
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipi di attivit&agrave; (radio)</li>";        

            //Settore attivita select
            sw = new StreamWriter(Server.MapPath("/var/cache/AttivitaSettore-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="AttivitaSettore_Attiva=1";
              strORDERNet = "AttivitaSettore_Ky";
              strFROMNet = "AttivitaSettore";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttivitaSettore_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AttivitaSettore_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AttivitaSettore_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipi di attivit&agrave; (select)</li>";        
            
			//Settore attivita radio
            sw = new StreamWriter(Server.MapPath("/var/cache/AttivitaSettore-radio.htm"), false, System.Text.Encoding.Default);
              strWHERENet="AttivitaSettore_Attiva=1";
              strORDERNet = "AttivitaSettore_Ky";
              strFROMNet = "AttivitaSettore";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttivitaSettore_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<div class=\"button-group round toggle small\">");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<input type=\"radio\" id=\"attivitasettore-" + dtTemp.Rows[i]["AttivitaSettore_Ky"].ToString() + "\" name=\"AttivitaSettore_Ky\" value=\"" + dtTemp.Rows[i]["AttivitaSettore_Ky"].ToString() + "\" /><label class=\"button\" for=\"attivitasettore-" + dtTemp.Rows[i]["AttivitaSettore_Ky"].ToString() + "\"><i class=\"" + dtTemp.Rows[i]["AttivitaSettore_Icona"].ToString() + " fa-fw fa-lg\"></i>" + dtTemp.Rows[i]["AttivitaSettore_Titolo"].ToString() + "</label>");
              }
              sw.WriteLine("</div>");
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipi di attivit&agrave; (radio)</li>";        

            //CommesseStato
            sw = new StreamWriter(Server.MapPath("/var/cache/CommesseStato-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "CommesseStato_Titolo";
              strFROMNet = "CommesseStato";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "CommesseStato_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["CommesseStato_Ky"].ToString() + "\">" + dtTemp.Rows[i]["CommesseStato_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Stati Tags generati</li>";        
            
            //CommesseStato
            sw = new StreamWriter(Server.MapPath("/var/cache/CommesseTipo-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "CommesseTipo_Titolo";
              strFROMNet = "CommesseTipo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "CommesseTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["CommesseTipo_Ky"].ToString() + "\">" + dtTemp.Rows[i]["CommesseTipo_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipo progetti generati</li>";        

            //CommesseTags
            sw = new StreamWriter(Server.MapPath("/var/cache/CommesseTags-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "CommesseTags_Titolo";
              strFROMNet = "CommesseTags";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "CommesseTags_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["CommesseTags_Titolo"].ToString() + "\">" + dtTemp.Rows[i]["CommesseTags_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Tags progetti generati</li>";        
            
            //Providers
            sw = new StreamWriter(Server.MapPath("/var/cache/Providers-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "Providers_Descrizione";
              strFROMNet = "Providers";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Providers_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Providers_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Providers_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Providers generati</li>";        

            //Tipo prodotti
            sw = new StreamWriter(Server.MapPath("/var/cache/ProdottiTipo-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="ProdottiTipo_Attivo=1";
              strORDERNet = "ProdottiTipo_Titolo";
              strFROMNet = "ProdottiTipo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "ProdottiTipo_Ky", strWHERENet, strORDERNet, 1, 10,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["ProdottiTipo_Ky"].ToString() + "\">" + dtTemp.Rows[i]["ProdottiTipo_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Tipi di prodotto generati</li>";        

            //Visibilit&agrave; prodotti
            sw = new StreamWriter(Server.MapPath("/var/cache/ProdottiVisibilita-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "ProdottiVisibilita_Titolo";
              strFROMNet = "ProdottiVisibilita";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "ProdottiVisibilita_Ky", strWHERENet, strORDERNet, 1, 10,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["ProdottiVisibilita_Ky"].ToString() + "\">" + dtTemp.Rows[i]["ProdottiVisibilita_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Visibilit&agrave; prodotti generate</li>";        

            //Montagggio prodotti
            sw = new StreamWriter(Server.MapPath("/var/cache/ProdottiMontaggio-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "ProdottiMontaggio_Descrizione";
              strFROMNet = "ProdottiMontaggio";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "ProdottiMontaggio_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["ProdottiMontaggio_Ky"].ToString() + "\">" + dtTemp.Rows[i]["ProdottiMontaggio_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Montaggio prodotti generate</li>";        

            //Consegna prodotti
            sw = new StreamWriter(Server.MapPath("/var/cache/ProdottiConsegna-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "ProdottiConsegna_Descrizione";
              strFROMNet = "ProdottiConsegna";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "ProdottiConsegna_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["ProdottiConsegna_Ky"].ToString() + "\">" + dtTemp.Rows[i]["ProdottiConsegna_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Consegna prodotti generate</li>";        

            //Categorie anagrafiche
            sw = new StreamWriter(Server.MapPath("/var/cache/AnagraficheCategorie-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="AnagraficheCategorie_Padre Is Null Or AnagraficheCategorie_Padre='0'";
              strORDERNet = "AnagraficheCategorie_Titolo";
              strFROMNet = "AnagraficheCategorie";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheCategorie_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){

            	strWHERENet="AnagraficheCategorie_Padre=" + dtTemp.Rows[i]["AnagraficheCategorie_Ky"].ToString();
    		    dtTempFigli = Smartdesk.Sql.getTablePage("AnagraficheCategorie", null, "AnagraficheCategorie_Ky", strWHERENet, "AnagraficheCategorie_Descrizione", 1, 10000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        	    if (dtTempFigli.Rows.Count>0){
                    sw.WriteLine("<optgroup label=\"" + dtTemp.Rows[i]["AnagraficheCategorie_Titolo"].ToString() + "\">");
                    sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AnagraficheCategorie_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AnagraficheCategorie_Titolo"].ToString() + "</option>");
                    for (int j = 0; j < dtTempFigli.Rows.Count; j++){
                       sw.WriteLine("<option value=\"" + dtTempFigli.Rows[j]["AnagraficheCategorie_Ky"].ToString() + "\">" + dtTempFigli.Rows[j]["AnagraficheCategorie_Titolo"].ToString() + "</option>");
                    }
                    sw.WriteLine("</optgroup>"); 
                 }else{
                   sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AnagraficheCategorie_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AnagraficheCategorie_Titolo"].ToString() + "</option>");
                 }
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Categorie anagrafiche generate</li>";        

            //Condizioni di pagamento
            sw = new StreamWriter(Server.MapPath("/var/cache/PagamentiCondizioni-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "PagamentiCondizioni_Descrizione";
              strFROMNet = "PagamentiCondizioni";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "PagamentiCondizioni_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["PagamentiCondizioni_Ky"].ToString() + "\">" + dtTemp.Rows[i]["PagamentiCondizioni_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Condizioni di pagamento generate</li>";        

            //tipi di pagamento
            sw = new StreamWriter(Server.MapPath("/var/cache/PagamentiTipo-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "PagamentiTipo_Descrizione";
              strFROMNet = "PagamentiTipo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "PagamentiTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["PagamentiTipo_Ky"].ToString() + "\">" + dtTemp.Rows[i]["PagamentiTipo_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Tipi di pagamento generati</li>";        

            //metodi di pagamento
            sw = new StreamWriter(Server.MapPath("/var/cache/PagamentiMetodo-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "PagamentiMetodo_Titolo";
              strFROMNet = "PagamentiMetodo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "PagamentiMetodo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["PagamentiMetodo_Ky"].ToString() + "\">" + dtTemp.Rows[i]["PagamentiMetodo_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Tipi di pagamento generati</li>";        

            //tipo di spedizioni
            sw = new StreamWriter(Server.MapPath("/var/cache/SpedizioniTipo-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "SpedizioniTipo_Descrizione";
              strFROMNet = "SpedizioniTipo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "SpedizioniTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["SpedizioniTipo_Ky"].ToString() + "\">" + dtTemp.Rows[i]["SpedizioniTipo_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Tipi di spedizioni generati</li>";        

            //Disponibilita prodotti
            sw = new StreamWriter(Server.MapPath("/var/cache/ProdottiDisponibilita-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "ProdottiDisponibilita_Descrizione";
              strFROMNet = "ProdottiDisponibilita";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "ProdottiDisponibilita_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["ProdottiDisponibilita_Ky"].ToString() + "\">" + dtTemp.Rows[i]["ProdottiDisponibilita_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Disponibilit&agrave; prodotti generate</li>";        

            //Lingue
            sw = new StreamWriter(Server.MapPath("/var/cache/Lingue-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "Lingue_Titolo";
              strFROMNet = "Lingue";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lingue_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Lingue_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Lingue_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Lingue generati</li>";        

            //Divise
            sw = new StreamWriter(Server.MapPath("/var/cache/Divise-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "Divise_Descrizione";
              strFROMNet = "Divise";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Divise_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Divise_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Divise_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Lingue generati</li>";        

            //Nazioni
            sw = new StreamWriter(Server.MapPath("/var/cache/Nazioni-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "Nazioni_Nazione";
              strFROMNet = "Nazioni";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Nazioni_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Nazioni_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Nazioni_Nazione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Nazioni generati</li>";        

            //Regioni
            sw = new StreamWriter(Server.MapPath("/var/cache/Regioni-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="Nazioni_Ky=105";
              strORDERNet = "Regioni_Regione";
              strFROMNet = "Regioni";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Regioni_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Regioni_Ky"].ToString() + "\" data-url=\"" + dtTemp.Rows[i]["Regioni_UrlKey"].ToString() + "\">" + dtTemp.Rows[i]["Regioni_Regione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Regioni generate</li>";        
                 
            //Province
            sw = new StreamWriter(Server.MapPath("/var/cache/Province-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "Province_Provincia";
              strFROMNet = "Province";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Province_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Province_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Province_Provincia"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Province generate</li>";        

            //Comuni
            sw = new StreamWriter(Server.MapPath("/var/cache/Comuni-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "Comuni_Comune";
              strFROMNet = "Comuni";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Comuni_Ky", strWHERENet, strORDERNet, 1, 10000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Comuni_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Comuni_Comune"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Comuni generati</li>";        
            
            //Persone select
            sw = new StreamWriter(Server.MapPath("/var/cache/Persone-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="Persone_Attivo=1";
              strORDERNet = "Persone_Nome";
              strFROMNet = "Persone";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Persone_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Persone_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Persone_Nome"].ToString() + " " + dtTemp.Rows[i]["Persone_Cognome"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Persone generate</li>";        
                        
            //Persone select2
            sw = new StreamWriter(Server.MapPath("/var/cache/Persone-options-select2.htm"), false, System.Text.Encoding.Default);
              strWHERENet="Persone_Attivo=1";
              strORDERNet = "Persone_Nome";
              strFROMNet = "Persone";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Persone_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                if (dtTemp.Rows[i]["Persone_Foto"].ToString().Length>0){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Persone_Ky"].ToString() + "\" data-img=\"" + dtTemp.Rows[i]["Persone_Foto"].ToString() + "\">" + dtTemp.Rows[i]["Persone_Nome"].ToString() + " " + dtTemp.Rows[i]["Persone_Cognome"].ToString() + "</option>");
                }else{
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Persone_Ky"].ToString() + "\" data-icon=\"fa-duotone fa-user\" data-color=\"" + dtTemp.Rows[i]["Persone_Colore"].ToString() + "\">" + dtTemp.Rows[i]["Persone_Nome"].ToString() + " " + dtTemp.Rows[i]["Persone_Cognome"].ToString() + "</option>");
                }
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Persone generate</li>";        

            //Servizi
            sw = new StreamWriter(Server.MapPath("/var/cache/Servizi-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="Servizi_CodicePadre Is Null Or Servizi_CodicePadre='0'";
              strORDERNet = "Servizi_Titolo";
              strFROMNet = "Servizi";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Servizi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
            	    strWHERENet="Servizi_CodicePadre='" + dtTemp.Rows[i]["Servizi_Ky"].ToString() + "'";
      				    dtTempFigli = Smartdesk.Sql.getTablePage("Servizi_Vw", null, "Servizi_Ky", strWHERENet, strORDERNet, 1, 10000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      		    	    if (dtTempFigli.Rows.Count>0){
                      sw.WriteLine("<optgroup value=\"" + dtTemp.Rows[i]["Servizi_Ky"].ToString() + "\" label=\"" + dtTemp.Rows[i]["Servizi_Titolo"].ToString() + "\">");
                      sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Servizi_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Servizi_Titolo"].ToString() + "</option>");
                      for (int j = 0; j < dtTempFigli.Rows.Count; j++){
                         sw.WriteLine("<option value=\"" + dtTempFigli.Rows[j]["Servizi_Ky"].ToString() + "\" attributigruppi_ky=\"" + dtTemp.Rows[i]["attributigruppi_ky"].ToString() + "\">" + dtTempFigli.Rows[j]["Servizi_Titolo"].ToString() + "</option>");
                      }
                      sw.WriteLine("</optgroup>"); 
                     }else{
                       sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Servizi_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Servizi_Titolo"].ToString() + "</option>");
                     }
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Servizi generati</li>";
            
            //ServiziCategorie
            sw = new StreamWriter(Server.MapPath("/var/cache/ServiziCategorie-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "ServiziCategorie_Descrizione";
              strFROMNet = "ServiziCategorie";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "ServiziCategorie_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["ServiziCategorie_Ky"].ToString() + "\">" + dtTemp.Rows[i]["ServiziCategorie_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Categorie di Servizi generate</li>";        

            //Categorie prodotti option
            sw = new StreamWriter(Server.MapPath("/var/cache/ProdottiCategorie-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "ProdottiCategorie_Ordine, ProdottiCategorie_Titolo";
              strFROMNet = "ProdottiCategorie";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "ProdottiCategorie_Ky", strWHERENet, strORDERNet, 1, 500,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["ProdottiCategorie_Ky"].ToString() + "\">" + dtTemp.Rows[i]["ProdottiCategorie_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Categorie prodotti generate options</li>";        
            
						//Categorie prodotti list
            sw = new StreamWriter(Server.MapPath("/var/cache/ProdottiCategorie-list.htm"), false, System.Text.Encoding.Default);
              strWHERENet="ProdottiCategorie_PubblicaWEB=1";
              strORDERNet = "ProdottiCategorie_Ordine, ProdottiCategorie_Titolo";
              strFROMNet = "ProdottiCategorie";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "ProdottiCategorie_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<li><a href=\"/prodotti/" + dtTemp.Rows[i]["ProdottiCategorie_Url"].ToString() + ".html\">" + dtTemp.Rows[i]["ProdottiCategorie_Titolo"].ToString() + "</a></li>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Categorie prodotti generate come liste</li>";        
						
						//Categorie prodotti flat
            sw = new StreamWriter(Server.MapPath("/var/cache/ProdottiCategorie-flat.htm"), false, System.Text.Encoding.Default);
              strWHERENet="ProdottiCategorie_PubblicaWEB=1";
              strORDERNet = "ProdottiCategorie_Ordine, ProdottiCategorie_Titolo";
              strFROMNet = "ProdottiCategorie";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "ProdottiCategorie_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<a href=\"/prodotti/" + dtTemp.Rows[i]["ProdottiCategorie_Url"].ToString() + ".html\" title=\"" + dtTemp.Rows[i]["ProdottiCategorie_Titolo"].ToString() + "\">" + dtTemp.Rows[i]["ProdottiCategorie_Titolo"].ToString() + "</a>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Categorie prodotti generate flat</li>";        

            //Produttori
            sw = new StreamWriter(Server.MapPath("/var/cache/Produttori-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "Produttori_Descrizione";
              strFROMNet = "Produttori";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Produttori_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["Produttori_Ky"].ToString() + "\">" + dtTemp.Rows[i]["Produttori_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Produttori generati</li>";        

            //Veicoli Marca
            sw = new StreamWriter(Server.MapPath("/var/cache/VeicoliMarca-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "VeicoliMarca_Descrizione";
              strFROMNet = "VeicoliMarca";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliMarca_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["VeicoliMarca_Ky"].ToString() + "\">" + dtTemp.Rows[i]["VeicoliMarca_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " marca veicoli generati</li>";        

            //Veicoli carburante
            sw = new StreamWriter(Server.MapPath("/var/cache/VeicoliCarburante-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "VeicoliCarburante_Descrizione";
              strFROMNet = "VeicoliCarburante";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliCarburante_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\">Carburante</option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["VeicoliCarburante_Ky"].ToString() + "\">" + dtTemp.Rows[i]["VeicoliCarburante_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " carburante veicoli generati</li>";        

            //Veicoli categoria
            sw = new StreamWriter(Server.MapPath("/var/cache/VeicoliCategoria-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "VeicoliCategoria_Descrizione";
              strFROMNet = "VeicoliCategoria";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliCategoria_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["VeicoliCategoria_Ky"].ToString() + "\">" + dtTemp.Rows[i]["VeicoliCategoria_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " categorie veicoli generati</li>";        

            //Veicoli normative
            sw = new StreamWriter(Server.MapPath("/var/cache/VeicoliNormativeEuro-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="VeicoliNormativeEuro_Attiva=1";
              strORDERNet = "VeicoliNormativeEuro_Descrizione";
              strFROMNet = "VeicoliNormativeEuro";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliNormativeEuro_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\">Normativa euro</option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["VeicoliNormativeEuro_Ky"].ToString() + "\">" + dtTemp.Rows[i]["VeicoliNormativeEuro_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " normative veicoli generati</li>";        

            //Veicoli cambio
            sw = new StreamWriter(Server.MapPath("/var/cache/VeicoliCambio-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "VeicoliCambio_Descrizione";
              strFROMNet = "VeicoliCambio";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliCambio_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\">Cambio</option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["VeicoliCambio_Ky"].ToString() + "\">" + dtTemp.Rows[i]["VeicoliCambio_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " cambio veicoli generati</li>";        

            //Veicoli carrozzeria
            sw = new StreamWriter(Server.MapPath("/var/cache/VeicoliCarrozzeria-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "VeicoliCarrozzeria_Descrizione";
              strFROMNet = "VeicoliCarrozzeria";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliCarrozzeria_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\">Carrozzeria</option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["VeicoliCarrozzeria_Ky"].ToString() + "\">" + dtTemp.Rows[i]["VeicoliCarrozzeria_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " carrozzeria veicoli generati</li>";        

            //Veicoli colore
            sw = new StreamWriter(Server.MapPath("/var/cache/VeicoliColore-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "VeicoliColore_Descrizione";
              strFROMNet = "VeicoliColore";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliColore_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["VeicoliColore_Ky"].ToString() + "\">" + dtTemp.Rows[i]["VeicoliColore_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " colore veicoli generati</li>";        

            //Veicoli contratto
            sw = new StreamWriter(Server.MapPath("/var/cache/VeicoliContratto-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "VeicoliContratto_Descrizione";
              strFROMNet = "VeicoliContratto";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliContratto_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["VeicoliContratto_Ky"].ToString() + "\">" + dtTemp.Rows[i]["VeicoliContratto_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " colore veicoli generati</li>";        

            //Veicoli tipo
            sw = new StreamWriter(Server.MapPath("/var/cache/VeicoliTipo-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "VeicoliTipo_Descrizione";
              strFROMNet = "VeicoliTipo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["VeicoliTipo_Ky"].ToString() + "\">" + dtTemp.Rows[i]["VeicoliTipo_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipo veicoli generati</li>";        

            //Veicoli tipologie
            sw = new StreamWriter(Server.MapPath("/var/cache/VeicoliTipologie-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "VeicoliTipologie_Descrizione";
              strFROMNet = "VeicoliTipologie";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliTipologie_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["VeicoliTipologie_Ky"].ToString() + "\">" + dtTemp.Rows[i]["VeicoliTipologie_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipologie veicoli generati</li>";        

            //Veicoli gruppi
            sw = new StreamWriter(Server.MapPath("/var/cache/VeicoliGruppi-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "VeicoliGruppi_Descrizione";
              strFROMNet = "VeicoliGruppi";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliGruppi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["VeicoliGruppi_Ky"].ToString() + "\">" + dtTemp.Rows[i]["VeicoliGruppi_Descrizione"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " gruppi veicoli generati</li>";        

            //AsteTipo
            sw = new StreamWriter(Server.MapPath("/var/cache/AsteTipo-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AsteTipo_Titolo";
              strFROMNet = "AsteTipo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AsteTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AsteTipo_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AsteTipo_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipi di aste generati</li>";        
            
			//AsteNatura
            sw = new StreamWriter(Server.MapPath("/var/cache/AsteNatura-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AsteNatura_Titolo";
              strFROMNet = "AsteNatura";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AsteNatura_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AsteNatura_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AsteNatura_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipi di aste generati</li>";        
			
			//AsteVendita
            sw = new StreamWriter(Server.MapPath("/var/cache/AsteVendita-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AsteVendita_Titolo";
              strFROMNet = "AsteVendita";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AsteVendita_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AsteVendita_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AsteVendita_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " tipo di vendita aste generati</li>";        

            //AsteCategorie
            sw = new StreamWriter(Server.MapPath("/var/cache/AsteCategorie-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AsteCategorie_Titolo";
              strFROMNet = "AsteCategorie";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AsteCategorie_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AsteCategorie_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AsteCategorie_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " categorie aste generati</li>";        

            //AsteEsperimentiEsiti
            sw = new StreamWriter(Server.MapPath("/var/cache/AsteEsperimentiEsiti-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AsteEsperimentiEsiti_Titolo";
              strFROMNet = "AsteEsperimentiEsiti";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AsteEsperimentiEsiti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AsteEsperimentiEsiti_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AsteEsperimentiEsiti_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " esiti esperimenti generati</li>";        

            //AsteRitiri
            sw = new StreamWriter(Server.MapPath("/var/cache/AsteRitiri-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AsteRitiri_Titolo";
              strFROMNet = "AsteRitiri";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AsteRitiri_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AsteRitiri_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AsteRitiri_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " AsteRitiri generati</li>";        

            //AnnunciCategorie
            sw = new StreamWriter(Server.MapPath("/var/cache/AnnunciCategorie-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="AnnunciCategorie_Padre=0 OR AnnunciCategorie_Padre Is Null";
              strORDERNet = "AnnunciCategorie_Ordine, AnnunciCategorie_Titolo";
              strFROMNet = "AnnunciCategorie";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnnunciCategorie_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
            	    strWHERENet="AnnunciCategorie_Padre=" + dtTemp.Rows[i]["AnnunciCategorie_Ky"].ToString();
				    dtTempFigli = Smartdesk.Sql.getTablePage("AnnunciCategorie_Vw", null, "AnnunciCategorie_Ky", strWHERENet, strORDERNet, 1, 10000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		    	    if (dtTempFigli.Rows.Count>0){
                      sw.WriteLine("<optgroup value=\"" + dtTemp.Rows[i]["AnnunciCategorie_Ky"].ToString() + "\" label=\"" + dtTemp.Rows[i]["AnnunciCategorie_Titolo"].ToString() + "\">");
                      for (int j = 0; j < dtTempFigli.Rows.Count; j++){
                         sw.WriteLine("<option value=\"" + dtTempFigli.Rows[j]["AnnunciCategorie_Ky"].ToString() + "\">" + dtTempFigli.Rows[j]["AnnunciCategorie_Titolo"].ToString() + "</option>");
                      }
                      sw.WriteLine("</optgroup>"); 
                     }else{
                       sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AnnunciCategorie_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AnnunciCategorie_Titolo"].ToString() + "</option>");
                     }

              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " AnnunciCategorie generati</li>";        

            //AnnunciMarca
            sw = new StreamWriter(Server.MapPath("/var/cache/AnnunciMarca-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AnnunciMarca_Titolo";
              strFROMNet = "AnnunciMarca";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnnunciMarca_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AnnunciMarca_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AnnunciMarca_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " AnnunciMarca generati</li>";        

            //AnnunciStato
            sw = new StreamWriter(Server.MapPath("/var/cache/AnnunciStato-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AnnunciStato_Titolo";
              strFROMNet = "AnnunciStato";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnnunciStato_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AnnunciStato_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AnnunciStato_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " AnnunciStato generati</li>";        

            //AnnunciAbbonamenti
            sw = new StreamWriter(Server.MapPath("/var/cache/AnnunciAbbonamenti-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AnnunciAbbonamenti_Titolo";
              strFROMNet = "AnnunciAbbonamenti";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnnunciAbbonamenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AnnunciAbbonamenti_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AnnunciAbbonamenti_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Abbonamenti annunci generati</li>";        
            
            //AnnunciTipo
            sw = new StreamWriter(Server.MapPath("/var/cache/AnnunciTipo-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AnnunciTipo_Titolo";
              strFROMNet = "AnnunciTipo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnnunciTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AnnunciTipo_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AnnunciTipo_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " AnnunciTipo generati</li>";        

            //AnnunciTipologie
            sw = new StreamWriter(Server.MapPath("/var/cache/AnnunciTipologie-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AnnunciTipologie_Titolo";
              strFROMNet = "AnnunciTipologie";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnnunciTipologie_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AnnunciTipologie_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AnnunciTipologie_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " AnnunciTipologie generati</li>";        

            //AnnunciSorgenti
            sw = new StreamWriter(Server.MapPath("/var/cache/AnnunciSorgenti-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "AnnunciSorgenti_Ordine";
              strFROMNet = "AnnunciSorgenti";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnnunciSorgenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["AnnunciSorgenti_Ky"].ToString() + "\">" + dtTemp.Rows[i]["AnnunciSorgenti_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " AnnunciSorgenti generati</li>";        

            //PasswordmanagerCategorie
            sw = new StreamWriter(Server.MapPath("/var/cache/PasswordmanagerCategorie-options.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "PasswordmanagerCategorie_Titolo";
              strFROMNet = "PasswordmanagerCategorie";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "PasswordmanagerCategorie_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["PasswordmanagerCategorie_Ky"].ToString() + "\">" + dtTemp.Rows[i]["PasswordmanagerCategorie_Titolo"].ToString() + "</option>");
              }
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " PasswordmanagerCategorie generati</li>";        

            //LeadCategorie
            sw = new StreamWriter(Server.MapPath("/var/cache/LeadCategorie-options.htm"), false, System.Text.Encoding.Default);
            swJson = new StreamWriter(Server.MapPath("/var/cache/json/LeadCategorie.json"), false, System.Text.Encoding.Default);
              strWHERENet="LeadCategorie_Attiva=1";
              strORDERNet = "LeadCategorie_Ordine";
              strFROMNet = "LeadCategorie";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadCategorie_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              swJson.WriteLine("[");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["LeadCategorie_Ky"].ToString() + "\">" + dtTemp.Rows[i]["LeadCategorie_Titolo"].ToString() + "</option>");
                  strTemp = "{ \"LeadCategorie_Ky\": \"" + dtTemp.Rows[i]["LeadCategorie_Ky"].ToString() + "\", \"LeadCategorie_Titolo\": \"" + dtTemp.Rows[i]["LeadCategorie_Titolo"].ToString() + "\"}";
                  if (i>0){
                    strTemp="," + strTemp;
                  }
                  swJson.WriteLine(strTemp);
              }
              swJson.WriteLine("]");
            sw.Close();
            swJson.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Categorie Lead generate</li>";        

            //LeadSorgenti
            sw = new StreamWriter(Server.MapPath("/var/cache/LeadSorgenti-options.htm"), false, System.Text.Encoding.Default);
            swJson = new StreamWriter(Server.MapPath("/var/cache/json/LeadSorgenti.json"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "LeadSorgenti_Titolo";
              strFROMNet = "LeadSorgenti";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadSorgenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              swJson.WriteLine("[");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["LeadSorgenti_Ky"].ToString() + "\">" + dtTemp.Rows[i]["LeadSorgenti_Titolo"].ToString() + "</option>");
                  strTemp = "{ \"LeadSorgenti_Ky\": \"" + dtTemp.Rows[i]["LeadSorgenti_Ky"].ToString() + "\", \"LeadSorgenti_Titolo\": \"" + dtTemp.Rows[i]["LeadSorgenti_Titolo"].ToString() + "\"}";
                  if (i>0){
                    strTemp="," + strTemp;
                  }
                  swJson.WriteLine(strTemp);
              }
              swJson.WriteLine("]");
            sw.Close();
            swJson.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Sorgenti Lead generate</li>";        

            //LeadTipo
            sw = new StreamWriter(Server.MapPath("/var/cache/LeadTipo-options.htm"), false, System.Text.Encoding.Default);
            swJson = new StreamWriter(Server.MapPath("/var/cache/json/LeadTipo.json"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "LeadTipo_Titolo";
              strFROMNet = "LeadTipo";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              swJson.WriteLine("[");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["LeadTipo_Ky"].ToString() + "\">" + dtTemp.Rows[i]["LeadTipo_Titolo"].ToString() + "</option>");
                  strTemp = "{ \"LeadTipo_Ky\": \"" + dtTemp.Rows[i]["LeadTipo_Ky"].ToString() + "\", \"LeadTipo_Titolo\": \"" + dtTemp.Rows[i]["LeadTipo_Titolo"].ToString() + "\"}";
                  if (i>0){
                    strTemp="," + strTemp;
                  }
                  swJson.WriteLine(strTemp);
              }
              swJson.WriteLine("]");
            sw.Close();
            swJson.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Tipo Lead generate</li>";        

            //LeadStato
            sw = new StreamWriter(Server.MapPath("/var/cache/LeadStato-options.htm"), false, System.Text.Encoding.Default);
            swJson = new StreamWriter(Server.MapPath("/var/cache/json/LeadStato.json"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "LeadStato_Titolo";
              strFROMNet = "LeadStato";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadStato_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              swJson.WriteLine("[");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["LeadStato_Ky"].ToString() + "\">" + dtTemp.Rows[i]["LeadStato_Titolo"].ToString() + "</option>");
                  strTemp = "{ \"LeadStato_Ky\": \"" + dtTemp.Rows[i]["LeadStato_Ky"].ToString() + "\", \"LeadStato_Titolo\": \"" + dtTemp.Rows[i]["LeadStato_Titolo"].ToString() + "\"}";
                  if (i>0){
                    strTemp="," + strTemp;
                  }
                  swJson.WriteLine(strTemp);
              }
              swJson.WriteLine("]");
            sw.Close();
            swJson.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Tipo Lead generate</li>"; 
            
            //PreventiviAutoStati
            sw = new StreamWriter(Server.MapPath("/var/cache/PreventiviAutoStati-options.htm"), false, System.Text.Encoding.Default);
            swJson = new StreamWriter(Server.MapPath("/var/cache/json/PreventiviAutoStati.json"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "PreventiviAutoStati_Titolo";
              strFROMNet = "PreventiviAutoStati";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "PreventiviAutoStati_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<option value=\"\"></option>");
              swJson.WriteLine("[");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<option value=\"" + dtTemp.Rows[i]["PreventiviAutoStati_Ky"].ToString() + "\">" + dtTemp.Rows[i]["PreventiviAutoStati_Titolo"].ToString() + "</option>");
                  strTemp = "{ \"PreventiviAutoStati_Ky\": \"" + dtTemp.Rows[i]["PreventiviAutoStati_Ky"].ToString() + "\", \"PreventiviAutoStati_Titolo\": \"" + dtTemp.Rows[i]["PreventiviAutoStati_Titolo"].ToString() + "\"}";
                  if (i>0){
                    strTemp="," + strTemp;
                  }
                  swJson.WriteLine(strTemp);
              }
              swJson.WriteLine("]");
            sw.Close();
            swJson.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Stati preventivi auto generati</li>"; 
            
            //PreventiviAutoStati
            sw = new StreamWriter(Server.MapPath("/var/cache/PreventiviAutoStati-radio.htm"), false, System.Text.Encoding.Default);
              strWHERENet="";
              strORDERNet = "PreventiviAutoStati_Ky";
              strFROMNet = "PreventiviAutoStati";
              dtTemp = new DataTable("Temp");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "PreventiviAutoStati_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
              sw.WriteLine("<div class=\"button-group round toggle small\">");
              for (i = 0; i < dtTemp.Rows.Count; i++){
                  sw.WriteLine("<input class=\"button\" type=\"radio\" id=\"preventiviautostati-" + dtTemp.Rows[i]["PreventiviAutoStati_Ky"].ToString() + "\" name=\"PreventiviAutoStati_Ky\" value=\"" + dtTemp.Rows[i]["PreventiviAutoStati_Ky"].ToString() + "\" /><label class=\"button\" for=\"preventiviautostati-" + dtTemp.Rows[i]["PreventiviAutoStati_Ky"].ToString() + "\"><i class=\"" + dtTemp.Rows[i]["PreventiviAutoStati_Icona"].ToString() + " fa-fw fa-lg\"></i>" + dtTemp.Rows[i]["PreventiviAutoStati_Titolo"].ToString() + "</label>");
              }
              sw.WriteLine("</div>");
            sw.Close();
            strRisultato=strRisultato + "<li>" + intNumRecords + " Stati preventivi auto (radio)</li>";        

            
                   

            strRisultato=strRisultato + "</ul>";        
            
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
