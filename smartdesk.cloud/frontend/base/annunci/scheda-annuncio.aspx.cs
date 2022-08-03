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
    public string strH1="Annuncio";
    public DataTable dtAnnuncio;
    public DataTable dtAnnunciOfferte;
    public DataTable dtAnagrafiche;
    public DataTable dtAnagraficheServizi;
    public DataTable dtAnnunciSimili;
    public DataTable dtAsteCategorie;
    public DataTable dtAnnunciCategorie;
    public DataTable dtAttributi;
    public string strIndirizzo = "";
    public bool boolPremium = false;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";

        
	    
	  	
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

        strWHERENet = "Annunci_Ky=" + Smartdesk.Current.QueryString("Annunci_Ky");
        dtAnnuncio = new DataTable("Annuncio");
        dtAnnuncio = Smartdesk.Sql.getTablePage("Annunci_Vw", null, "Annunci_Ky", strWHERENet, "Annunci_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        strH1=dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString();

        strWHERENet = "Annunci_Ky<>" + Smartdesk.Current.QueryString("Annunci_Ky");
        strORDERNet = "AnnunciOfferte_Ky DESC";
        dtAnnunciOfferte = new DataTable("AnnunciOfferte");
        dtAnnunciOfferte = Smartdesk.Sql.getTablePage("AnnunciOfferte_Vw", null, "AnnunciOfferte_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

        strWHERENet = "Anagrafiche_Ky=" + dtAnnuncio.Rows[0]["Anagrafiche_Ky"].ToString();
        dtAnagrafiche = new DataTable("Anagrafiche");
        dtAnagrafiche = Smartdesk.Sql.getTablePage("Anagrafiche", null, "Anagrafiche_Ky", strWHERENet, "Anagrafiche_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

        //controllo l'abbonamento
        if (strUtentiLogin!=null && strUtentiLogin.Length>0){
          strWHERENet = "Anagrafiche_Ky=" + dtAnnuncio.Rows[0]["Anagrafiche_Ky"].ToString() + " AND AnagraficheServizi_Inizio<=GETDATE() AND AnagraficheServizi_Termine>=GETDATE()";
          //Response.Write(strWHERENet);
          dtAnagraficheServizi = new DataTable("AnagraficheServizi");
          dtAnagraficheServizi = Smartdesk.Sql.getTablePage("AnagraficheServizi_Vw", null, "AnagraficheServizi_Ky", strWHERENet, "AnagraficheServizi_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtAnagraficheServizi.Rows.Count<1){
             boolPremium=false;
          }else{
            if (Convert.ToDecimal(dtAnagraficheServizi.Rows[0]["AnagraficheServizi_Prezzo"])>0){
                boolPremium=true;
            }else{
               boolPremium=false;
            }
          } 
        }else{
          boolPremium=false;
        } 


        strWHERENet = "Annunci_Ky<>" + Smartdesk.Current.QueryString("Annunci_Ky") + " AND AnnunciMarca_Ky=" + dtAnnuncio.Rows[0]["AnnunciMarca_Ky"].ToString() + " AND AnnunciCategorie_Ky=" + dtAnnuncio.Rows[0]["AnnunciCategorie_Ky"].ToString();
        dtAnnunciSimili = new DataTable("AnnunciSimili");
        dtAnnunciSimili = Smartdesk.Sql.getTablePage("Annunci_Vw", null, "Annunci_Ky", strWHERENet, "Annunci_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      
        if (dtAnnuncio.Rows[0]["AnnunciCategorie_Attributi"].ToString().Length>0){
			strWHERENet = "Attributi_Annunci=1 And Attributi_Ky IN (" + dtAnnuncio.Rows[0]["AnnunciCategorie_Attributi"].ToString()  + ")";
		}else{
			strWHERENet = "Attributi_Annunci=1";
		}
        strORDERNet = "Attributi_Ky";
        strFROMNet = "Attributi_Vw";
        dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        
        if (IsCrawlByBot()==false){
            aggiungiVisualizzazioneAnnuncio();   
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
        strAttributi=dtAnnunciSimili.Rows[indiceRecord]["AnnunciCategorie_AttributiElenchi"].ToString();
        if (strAttributi.Length>0){
          
          DataRow[] drAttributiElenco=dtAttributi.Select("Attributi_Ky IN(" + strAttributi + ")", "Attributi_Ordine");
          for (int x = 0; x < drAttributiElenco.Length; x++){
           strCodice=drAttributiElenco[x]["Attributi_Codice"].ToString();
           strTitolo=drAttributiElenco[x]["Attributi_Titolo"].ToString();
           strTipo=drAttributiElenco[x]["AttributiTipo_Ky"].ToString();
           if (dtAnnunciSimili.Rows[indiceRecord][strCodice].ToString().Length>0 && dtAnnunciSimili.Rows[indiceRecord][strCodice].ToString()!="0"){
              switch (strTipo){
                case "1":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtAnnuncio.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "2":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtAnnuncio.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "3":
                    strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-calendar fa-fw\"></i>" + strTitolo + ":&nbsp;<strong>" + dtAnnuncio.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "4":
                    strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-check fa-fw\"></i>" + strTitolo + "&nbsp;&nbsp;</span>";
                    break;  
                case "5":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtAnnuncio.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "6":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtAnnuncio.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
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
}
