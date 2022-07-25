using System;
using System.Data;
using System.Web.Security;
using System.Collections;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page 
{
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolLogin = false;
    public string strUtentiLogin="";
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public string strH1="Asta";
    public DataTable dtAsteEsperimenti;
    public DataTable dtAsteCauzioni;
    public DataTable dtAsteCommissioni;
    public DataTable dtAnnunciOfferte;
    public DataTable dtAnnunciOfferteLotto;
    public DataTable dtAnnunci;
    public DataTable dtAsteCategorie;
    public DataTable dtAnnunciCategorie;
    public DataTable dtFiles;
    public bool boolCauzione = false;
    public bool boolAstaScaduta = false;
    public string strIndirizzo = "";
    public DataTable dtAttributi;
    public string strWHERENet="";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public string strFoto = "";
    public string strAsteEsperimenti_Ky = "";
    public string strAste_Ky = "";

    protected void Page_Load(object sender, EventArgs e)
    {

      
      
  	
      strAste_Ky=Smartdesk.Current.QueryString("Aste_Ky");
      if (strAste_Ky!=null && strAste_Ky.Length>0){
              //prendo l'ultimo esperimento  
              strAsteEsperimenti_Ky=Smartdesk.Current.QueryString("AsteEsperimenti_Ky");
              if (strAsteEsperimenti_Ky==null || strAsteEsperimenti_Ky.Length<1){
                strWHERENet = "Aste_Ky=" + strAste_Ky;
                dtAsteEsperimenti = new DataTable("AsteEsperimenti");
                dtAsteEsperimenti = Smartdesk.Sql.getTablePage("AsteEsperimenti_Web_Vw", null, "AsteEsperimenti_Ky", strWHERENet, "AsteEsperimenti_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                strAsteEsperimenti_Ky=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Ky"].ToString();
              }else{
                strWHERENet = "AsteEsperimenti_Ky=" + strAsteEsperimenti_Ky;
                dtAsteEsperimenti = new DataTable("AsteEsperimenti");
                dtAsteEsperimenti = Smartdesk.Sql.getTablePage("AsteEsperimenti_Web_Vw", null, "AsteEsperimenti_Ky", strWHERENet, "AsteEsperimenti_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              }
              if (Request.Cookies["rswcrm-az"] != null){
                  strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
                  strWHERENet = "Anagrafiche_Ky=" + strUtentiLogin;
                  strORDERNet = "Anagrafiche_Ky";
                  strFROMNet = "Anagrafiche";
                  dtLogin = new DataTable("Login");
                  dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtLogin.Rows.Count>0){
                    boolLogin=true;
                    strLogin="<a href=\"/account/area-personale.html\" class=\"login\"><i class=\"fa-duotone fa-envelope fa-fw\"></i>" + dtLogin.Rows[0]["Anagrafiche_EmailContatti"].ToString() + "</a> | <a href=\"/logoutanagrafiche.aspx\" class=\"login\"><i class=\"fa-duotone fa-user-times fa-fw\"></i>Esci</a>";
                    strWHERENet = "Anagrafiche_Ky=" + strUtentiLogin + " AND AsteCauzioni_Autorizzata=1 AND AsteEsperimenti_Ky=" + strAsteEsperimenti_Ky;
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
        
          	  if (dtAsteEsperimenti!=null && dtAsteEsperimenti.Rows.Count>0){
              		if (Convert.ToDateTime(dtAsteEsperimenti.Rows[0]["AsteEsperimenti_DataTermine"])>DateTime.Now){
              	      	boolAstaScaduta=false;
              		}else{
              	      	boolAstaScaduta=true;
              		}
          	  }else{
          	      	boolAstaScaduta=true;
          	  }
        
              if (dtAsteEsperimenti.Rows.Count>0){
                    strWHERENet = "Aste_Ky=" + dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString();
                    dtAsteCommissioni = new DataTable("AsteCommissioni");
                    dtAsteCommissioni = Smartdesk.Sql.getTablePage("AsteCommissioni", null, "AsteCommissioni_Ky", strWHERENet, "AsteCommissioni_Ky", 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        
                    strWHERENet = "Aste_Ky=" + dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString() + " AND AsteEsperimenti_Ky=" + strAsteEsperimenti_Ky;
                    dtAnnunciOfferte = new DataTable("AnnunciOfferte");
                    dtAnnunciOfferte = Smartdesk.Sql.getTablePage("AnnunciOfferte", null, "AnnunciOfferte_Ky", strWHERENet, "AnnunciOfferte_Ky", 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              
                    strWHERENet = "Aste_Ky=" + dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString() + " AND AnnunciStato_PubblicaWEB=1";
                    //strWHERENet = "Aste_Ky=" + dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString();
                    dtAnnunci = new DataTable("Annunci");
                    dtAnnunci = Smartdesk.Sql.getTablePage("Annunci_Vw", null, "Annunci_Ky", strWHERENet, "Annunci_Ky", 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              
                    strWHERENet = "Chiave_Tabella='Aste' AND Chiave_Ky=" + dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString();
                    dtFiles = new DataTable("Files");
                    dtFiles = Smartdesk.Sql.getTablePage("Files_Vw", null, "Files_Ky", strWHERENet, "Files_Ky", 1, 50,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                    
                    strWHERENet = "Attributi_Annunci=1";
                    strORDERNet = "Attributi_Ky";
                    strFROMNet = "Attributi_Vw";
                    dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                    
                    strH1=dtAsteEsperimenti.Rows[0]["Aste_Titolo"].ToString() + " all'asta in vendita.";
                      
                    if (IsCrawlByBot()==false){
                        aggiungiVisualizzazioneAsta();   
                    }
              }else{
                    //Response.Redirect("/home.aspx");
              }
      }else{
        //Response.Redirect("/home.aspx");

      }
    }

    protected void aggiungiVisualizzazioneAsta()
    {
        string strSQL = "";

        strSQL = "UPDATE Aste SET Aste_Visite=0 WHERE Aste_Visite Is Null And Aste_Ky=" + dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString();
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL = "UPDATE Aste SET Aste_Visite=Aste_Visite+1 WHERE Aste_Ky=" + dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString();
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
