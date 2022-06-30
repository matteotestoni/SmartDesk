using System;
using System.Data;
using System.Web.Security;
using System.Collections;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page 
{
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo cien = new System.Globalization.CultureInfo("en-US");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolLogin = false;
    public string strUtentiLogin="";
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public string strH1="Annuncio";
    public DataTable dtAsteEsperimenti;
    public DataTable dtAsteCauzioni;
    public DataTable dtAsteCommissioni;
    public DataTable dtAnnunciOfferte;
    public DataTable dtAnnunciOfferteLotto;
    public DataTable dtAnnuncio;
    public DataTable dtAnnunci;
    public DataTable dtAsteCategorie;
    public DataTable dtAnnunciCategorie;
    public DataTable dtFilesAsta;
    public DataTable dtFilesLotto;
    public bool boolCauzione = false;
    public bool boolAstaScaduta = false;
    public string strIndirizzo = "";
    public decimal decValoreOffertaMinima = 0;
    public string strErrore = "";
    public DataTable dtAttributi;
    public string strWHERENet="";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public string strFoto = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        
	    
	  	
        strErrore=Request["errore"];
        strWHERENet = "Annunci_Ky=" + Smartdesk.Current.QueryString("Annunci_Ky");
        dtAnnuncio = new DataTable("Annunci");
        dtAnnuncio = Smartdesk.Sql.getTablePage("Annunci_Vw", null, "Annunci_Ky", strWHERENet, "Annunci_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtAnnuncio.Rows.Count>0){
            switch (dtAnnuncio.Rows[0]["AnnunciStato_Ky"].ToString()){
              case "2":
                Response.Redirect("/lotto-in-pubblicazione.aspx");
                break;
              case "3":
                Response.Redirect("/lotto-scaduto.aspx");
                break;
            }
            strH1=dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString();
    
            strWHERENet = "AsteEsperimentiEsiti_Ky=3 AND Aste_Ky=" + dtAnnuncio.Rows[i]["Aste_Ky"].ToString();
            dtAsteEsperimenti = new DataTable("AsteEsperimenti");
            dtAsteEsperimenti = Smartdesk.Sql.getTablePage("AsteEsperimenti_Web_Vw", null, "AsteEsperimenti_Ky", strWHERENet, "AsteEsperimenti_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtAsteEsperimenti==null || dtAsteEsperimenti.Rows.Count<1){
				Response.Redirect("/asta-scaduta.aspx");
			}else{
	            strWHERENet = "Aste_Ky=" + dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString();
	            dtAsteCommissioni = new DataTable("AsteCommissioni");
	            dtAsteCommissioni = Smartdesk.Sql.getTablePage("AsteCommissioni", null, "AsteCommissioni_Ky", strWHERENet, "AsteCommissioni_Ky", 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
				if (Convert.ToDateTime(dtAsteEsperimenti.Rows[0]["AsteEsperimenti_DataTermine"])>=DateTime.Now){
	            	boolAstaScaduta=false;
				}else{
	            	boolAstaScaduta=true;
				}
			}

            if (Request.Cookies["rswcrm-az"] != null){
                strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
                strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
                strORDERNet = "Anagrafiche_Ky";
                strFROMNet = "Anagrafiche";
                dtLogin = new DataTable("Login");
                dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtLogin.Rows.Count>0){
                  boolLogin=true;
                  strLogin="<a href=\"/account/area-personale.html\" class=\"login\"><i class=\"fa-duotone fa-envelope fa-fw\"></i>" + dtLogin.Rows[0]["Anagrafiche_EmailContatti"].ToString() + "</a> | <a href=\"/logoutanagrafiche.aspx\" class=\"login\"><i class=\"fa-duotone fa-user-times fa-fw\"></i>Esci</a>";
                  if (dtAsteEsperimenti!=null && dtAsteEsperimenti.Rows.Count>0){
					  strWHERENet = "Anagrafiche_Ky=" + strUtentiLogin + " AND AsteCauzioni_Autorizzata=1 AND AsteEsperimenti_Ky=" + dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Ky"].ToString();
				  }else{
					  strWHERENet = "Anagrafiche_Ky=" + strUtentiLogin + " AND AsteCauzioni_Autorizzata=1";
				  }
                  dtAsteCauzioni = new DataTable("AsteCauzioni");
                  dtAsteCauzioni = Smartdesk.Sql.getTablePage("AsteCauzioni", null, "AsteCauzioni_Ky", strWHERENet, "AsteCauzioni_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtAsteCauzioni.Rows.Count>0){ 
                    boolCauzione=true;
                  }           
                }else{
                  strLogin="<a href=\"/account/login.html\"><i class=\"fa-duotone fa-key fa-lg fa-fw\"></i>Accedi</a> | <a href=\"/registrazione.aspx\"><i class=\"fa-duotone fa-user-shield fa-lg fa-fw\"></i>Registrati</a>";
                  boolLogin=false;
                }
            }else{
              strLogin="<a href=\"/account/login.html\"><i class=\"fa-duotone fa-key fa-lg fa-fw\"></i>Accedi</a> | <a href=\"/registrazione.aspx\"><i class=\"fa-duotone fa-user-shield fa-lg fa-fw\"></i>Registrati</a>";
              boolLogin=false;
            }
      
            strWHERENet = "AnnunciCategorie_Padre=0";
            dtAnnunciCategorie = new DataTable("AnnunciCategorie");
            dtAnnunciCategorie = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Ordine, AnnunciCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      
    		strWHERENet = "";
            dtAsteCategorie = new DataTable("AsteCategorie");
            dtAsteCategorie = Smartdesk.Sql.getTablePage("AsteCategorie", null, "AsteCategorie_Ky", strWHERENet, "AsteCategorie_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
            strWHERENet = "Annunci_Ky<>" + Smartdesk.Current.QueryString("Annunci_Ky") +  " AND Aste_Ky=" + dtAnnuncio.Rows[i]["Aste_Ky"].ToString();
            dtAnnunci = new DataTable("Annunci");
            dtAnnunci = Smartdesk.Sql.getTablePage("Annunci_Vw", null, "Annunci_Ky", strWHERENet, "Annunci_Ky", 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    
            if (dtAsteEsperimenti!=null && dtAsteEsperimenti.Rows.Count>0){
				strWHERENet = "AsteEsperimenti_Ky=" + dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Ky"].ToString() + " AND Annunci_Ky=" + Smartdesk.Current.QueryString("Annunci_Ky");
			}else{
				strWHERENet = "Annunci_Ky=" + Smartdesk.Current.QueryString("Annunci_Ky");
			}
            strORDERNet = "AnnunciOfferte_Ky DESC";
            dtAnnunciOfferte = new DataTable("AnnunciOfferte");
            dtAnnunciOfferte = Smartdesk.Sql.getTablePage("AnnunciOfferte", null, "AnnunciOfferte_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    
            strWHERENet = "Chiave_Tabella='Aste' AND Chiave_Ky=" + dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString();
            dtFilesAsta = new DataTable("Files");
            dtFilesAsta = Smartdesk.Sql.getTablePage("Files_Vw", null, "Files_Ky", strWHERENet, "Files_Ky", 1, 50,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    
            strWHERENet = "Chiave_Tabella='Annunci' AND Chiave_Ky=" + dtAnnuncio.Rows[0]["Annunci_Ky"].ToString();
            dtFilesLotto = new DataTable("Files");
            dtFilesLotto = Smartdesk.Sql.getTablePage("Files_Vw", null, "Files_Ky", strWHERENet, "Files_Ky", 1, 50,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          
            strWHERENet = "Attributi_Annunci=1";
            strORDERNet = "Attributi_Ky";
            strFROMNet = "Attributi_Vw";
            dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (IsCrawlByBot()==false){
                aggiungiVisualizzazioneAnnuncio();   
            }
        }else{
            Response.Redirect("/");
        }
        
    }

    protected void aggiungiVisualizzazioneAnnuncio()
    {
        string strSQL = "";

        strSQL = "UPDATE Annunci SET Annunci_Visite=0 WHERE Annunci_Visite Is Null And Annunci_Ky=" + Smartdesk.Current.QueryString("Annunci_Ky");
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL = "UPDATE Annunci SET Annunci_Visite=Annunci_Visite+1 WHERE Annunci_Ky=" + Smartdesk.Current.QueryString("Annunci_Ky");
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
    }

    public string getAttributi(int indiceRecord)
    {
        string strOutput="";
        string strAttributi="";
        string strCodice="";
        string strTitolo="";
        string strTipo="";

        strOutput="";   
        strAttributi=dtAnnunci.Rows[indiceRecord]["AnnunciCategorie_AttributiElenchi"].ToString();
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
                    strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-calendar fa-fw\"></i>" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "4":
                    strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-check fa-fw\"></i>" + strTitolo + "&nbsp;&nbsp;</span>";
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

    public string getAttributiTable()
    {
        string strOutput="";
        string strAttributi="";
        string strCodice="";
        string strTitolo="";
        string strTipo="";

        strOutput="";   
        strAttributi=dtAnnuncio.Rows[0]["AnnunciCategorie_Attributi"].ToString();
        if (strAttributi.Length>0){
          
          DataRow[] drAttributiElenco=dtAttributi.Select("Attributi_Ky IN(" + strAttributi + ")", "Attributi_Ordine");
          strOutput="<table class=\"hover\" style=\"border:1px solid #ededed;\">";
          for (int x = 0; x < drAttributiElenco.Length; x++){
           strCodice=drAttributiElenco[x]["Attributi_Codice"].ToString();
           strTitolo=drAttributiElenco[x]["Attributi_Titolo"].ToString();
           strTipo=drAttributiElenco[x]["AttributiTipo_Ky"].ToString();
           if (dtAnnuncio.Rows[0][strCodice].ToString().Length>0 && dtAnnuncio.Rows[0][strCodice].ToString()!="0"){
              switch (strTipo){
                case "1":
                    strOutput+="<tr><th class=\"text-right\" width=\"180\">" + strTitolo + "</th><td><strong>" + dtAnnuncio.Rows[0][strCodice].ToString() + "</strong></td></tr>";
                    break;  
                case "2":
                    strOutput+="<tr><th class=\"text-right\" width=\"180\">" + strTitolo + "</th><td><strong>" + dtAnnuncio.Rows[0][strCodice].ToString() + "</strong></td></tr>";
                    break;  
                case "3":
                    strOutput+="<tr><th class=\"text-right\" width=\"180\">" + strTitolo + "</th><td><strong>><i class=\"fa-duotone fa-calendar fa-fw\"></i>" + dtAnnuncio.Rows[0][strCodice].ToString() + "</strong></td></tr>";
                    break;  
                case "4":
                    if (dtAnnuncio.Rows[0][strCodice].Equals(true)){
                        strOutput+="<tr><th class=\"text-right\" width=\"180\">" + strTitolo + "</th><td><i class=\"fa-duotone fa-check fa-fw\"></i></td></tr>";
                    }
                    break;  
                case "5":
                    strOutput+="<tr><th class=\"text-right\" width=\"180\">" + strTitolo + "</th><td><strong>" + dtAnnuncio.Rows[0][strCodice].ToString() + "</strong></td></tr>";
                    break;  
                case "6":
                    strOutput+="<tr><th class=\"text-right\" width=\"180\">" + strTitolo + "</th><td><strong>" + dtAnnuncio.Rows[0][strCodice].ToString() + "</strong></td></tr>";
                    break;                  
              }
           }
          }
          strOutput+="</table>";


        }
        return strOutput;
    }

    public string getRiserva(){
        decimal decValore=0;
        string strRiserva="<span class=\"dettaglio-asta\" style=\"color:green\"><i class=\"fa-duotone fa-check-square fa-fw\"></i>RAGGIUNTO</span>";
        if (dtAnnunciOfferte.Rows.Count>0){
          decValore=((decimal)dtAnnunciOfferte.Rows[0]["AnnunciOfferte_Valore"]);
          if (((decimal)dtAnnunciOfferte.Rows[0]["AnnunciOfferte_Valore"])>((decimal)dtAnnuncio.Rows[0]["Annunci_PrezzoRiserva"])){
            strRiserva="<span class=\"dettaglio-asta\" style=\"color:green\"><i class=\"fa-duotone fa-check-square fa-fw\"></i>RAGGIUNTO</span>";
          }else{
            strRiserva="<span class=\"dettaglio-asta\" style=\"color:red\"><i class=\"fa-duotone fa-exclamation-triangle fa-fw\" data-tooltip aria-haspopup=\"true\" class=\"has-tip\" data-disable-hover=\"false\" tabindex=\"1\" title=\"&Egrave il minimo valore nascosto al quale il proprietario &egrave; disposto a cedere il proprio bene.\"></i>NON RAGGIUNTO</span>";
          }
        }else{
          if (((decimal)dtAnnuncio.Rows[0]["Annunci_PrezzoRiserva"])>((decimal)dtAnnuncio.Rows[0]["Annunci_Valore"])){
            strRiserva="<span class=\"dettaglio-asta\" style=\"color:red\"><i class=\"fa-duotone fa-exclamation-triangle fa-fw\" data-tooltip aria-haspopup=\"true\" class=\"has-tip\" data-disable-hover=\"false\" tabindex=\"1\" title=\"&Egrave il minimo valore nascosto al quale il proprietario &egrave; disposto a cedere il proprio bene.\"></i>NON RAGGIUNTO</span>";
          }else{
            strRiserva="<span class=\"dettaglio-asta\" style=\"color:green\"><i class=\"fa-duotone fa-check-square fa-fw\"></i>RAGGIUNTO</span>";
          }         
        }
        return strRiserva;
    }

    public string getCommissione(){
        decimal decValore=0;
        string strCommissione="15";
        if (dtAnnunciOfferte.Rows.Count>0){
          decValore=((decimal)dtAnnunciOfferte.Rows[0]["AnnunciOfferte_Valore"]);
        }else{
          decValore=((decimal)dtAnnuncio.Rows[0]["Annunci_Valore"]);
        }
        if (Convert.ToInt32(dtAsteEsperimenti.Rows[0]["Aste_CommissioniTipo"])==2){
			//commissione fissa
			if (dtAsteEsperimenti.Rows[0]["Aste_Commissione"].ToString().Length<1 && (decimal)dtAsteEsperimenti.Rows[0]["Aste_Commissione"]==0){
	            strCommissione="0";
	        }else{
	            strCommissione=dtAsteEsperimenti.Rows[0]["Aste_Commissione"].ToString();
			}
		}else{
			//commissione a scaglioni
    		for (int i = 0; i < dtAsteCommissioni.Rows.Count; i++){
				if (decValore>=Convert.ToDecimal(dtAsteCommissioni.Rows[i]["AsteCommissioni_Da"]) && decValore<=Convert.ToDecimal(dtAsteCommissioni.Rows[i]["AsteCommissioni_A"])){
					  strCommissione=dtAsteCommissioni.Rows[i]["AsteCommissioni_Commissione"].ToString();
				}		
			}
		}
        return strCommissione;
    }

    public bool IsCrawlByBot(){
            List<string> Crawlers = new List<string>()
            {
                "googlebot","bingbot","yandexbot","ahrefsbot","msnbot","linkedinbot","exabot","compspybot",
                "yesupbot","paperlibot","tweetmemebot","semrushbot","gigabot","voilabot","adsbot-google",
                "botlink","alkalinebot","araybot","undrip bot","borg-bot","boxseabot","yodaobot","admedia bot",
                "ezooms.bot","confuzzledbot","coolbot","internet cruiser robot","yolinkbot","diibot","musobot",
                "dragonbot","elfinbot","wikiobot","twitterbot","contextad bot","hambot","iajabot","news bot",
                "irobot","socialradarbot","ko_yappo_robot","skimbot","psbot","rixbot","seznambot","careerbot",
                "simbot","solbot","mail.ru_bot","spiderbot","blekkobot","bitlybot","techbot","void-bot",
                "vwbot_k","diffbot","friendfeedbot","archive.org_bot","woriobot","crystalsemanticsbot","wepbot",
                "spbot","tweetedtimes bot","mj12bot","who.is bot","psbot","robot","jbot","bbot","bot"
            };
    
            string ua = Request.UserAgent.ToLower();
            bool iscrawler = Crawlers.Exists(x => ua.Contains(x));
            return iscrawler;
    }    

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App)
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}
