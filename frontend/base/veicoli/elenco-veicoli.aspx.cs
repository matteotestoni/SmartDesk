using System;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page 
{
    public string strMetaTitle = "";
    public string strMetaDescription = "";
    public string strH1 = "";
    public string strP1 = "";
    public string strVeicoliMarca_Ky="";
    public string strVeicoliModello_Ky="";
    public string strVeicoliMarca_Descrizione="";
    public string strVeicoliMarca_DescrizioneHTML="";
    public string strVeicoliModello_Descrizione="";
    public string strVeicoliModello_DescrizioneHTML="";
    public int i = 0;
    public int intNumPagine=1;
    public int intNumRecords = 0;
    public int intRecxPag = 50;
    public int intStartPag = 1;
    public int intEndPag = 1;
    public int intPage = 0;
    public DataTable dtVeicoliCambioCorrente;
    public DataTable dtVeicoliCarburanteCorrente;
    public DataTable dtVeicoliNormativeEuroCorrente;
    public DataTable dtVeicoliCategoriaCorrente;
    public DataTable dtVeicoliCategoria;
    public DataTable dtVeicoliMarca;
    public DataTable dtVeicoliMarcaCorrente;
    public DataTable dtVeicoloModello;
    public DataTable dtVeicoliModelloCorrente;
    public DataTable dtVeicoloModello2;
    public DataTable dtVeicoli;
    public DataTable dtVeicoliEquipaggiamenti;
    public DataTable dtVeicoliOptionals;
    public DataTable dtSEO;
    public string strScheda = "";
    public string strAlt="";
    public string strImg="";
    public string strUrl="";
    public string strModelloUrl="";
    public string strMarcaUrl="";
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public int intNumRecordsVeicoli = 0;
    public int intNumRecordsModelli = 0;
    public string strVeicoliMarca_Ky_Selezionata = "";
    public string strVeicoliModello_Ky_Selezionato = "";
    public string strVeicoliModello_HTML_Selezionato = "";
    public string strWHERENet="";
    public string strWHEREVeicoli="";
    public string strPreferitiCookie;
    public string strConfrontoCookie;
    public string strFromRewrite;
    public string strVeicoliMarca_UrlKey="";
    public string strVeicoliModello_UrlKey="";
    public string strTemp="";
    public string strUtm_source="";
    public string strUtm_medium="";
    public string strUtm_campaign="";
    public string strUtm_term="";
    public string strUtm_content="";
    public DataTable dtVeicoliOfferteAttiva;
    public string strClass="";
    public DataTable dtVeicoliTestiSEO;
    public string strVeicoliCategoria_Ky="";
    public string strVeicoliCarburante_Ky="";
    public string strVeicoliNormativeEuro_Ky="";
    public string strVeicoliTipo_Ky="";
    public string strVeicoliCarrozzeria_Ky="";
    public string strComuni_Ky="";
    public string strVeicoliCambio_Ky="";
    public string strVeicoli_KMda="";
    public string strVeicoli_KMa="";
    public string strVeicoli_Valoreda="";
    public string strVeicoli_Valorea="";
    public string strUtenti_Ky="";
    public string strAutoecologiche="";
    public string strOrderby="";
    public string strAnno="";
    public string strTopcar="";
    public string strNeopatentati="";
    public string strBestprice="";
    public string strTags="";
    public string strDipendentifca="";
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
        string strChiave = "0";
        int i = 0;
        string strPagineSotto = "";
        string strFROMNet = "";
        string strORDERNet = "";
        DataTable dtVeicoliMarche;
        System.IO.StringWriter sw;
        string strPage="";
        string curpage="";
        string strElencoComuni="";
        int n;
    
    	  
    	  
        //tracciamento utm
        strUtm_source=StripHTML(Request["utm_source"]);
        if (strUtm_source==null || strUtm_source.Length<1){
            if (Request.Cookies["utm_source"]!=null && Request.Cookies["utm_source"].Value.ToString().Length>0){
               strUtm_source=Request.Cookies["utm_source"].Value.ToString();
            }
        }else{
    		Response.Cookies["utm_source"].Value = strUtm_source;		
    		Response.Cookies["utm_source"].Expires = DateTime.Now.AddDays(120);
        }
        strUtm_medium=StripHTML(Request["utm_medium"]);
        if (strUtm_medium==null || strUtm_medium.Length<1){
            if (Request.Cookies["utm_medium"]!=null && Request.Cookies["utm_medium"].Value.ToString().Length>0){
               strUtm_medium=Request.Cookies["utm_medium"].Value.ToString();
            }
        }else{
    		Response.Cookies["utm_medium"].Value = strUtm_medium;		
    		Response.Cookies["utm_medium"].Expires = DateTime.Now.AddDays(120);
        }
        strUtm_campaign=StripHTML(Request["utm_campaign"]);
        if (strUtm_campaign==null || strUtm_campaign.Length<1){
            if (Request.Cookies["utm_campaign"]!=null && Request.Cookies["utm_campaign"].Value.ToString().Length>0){
               strUtm_campaign=Request.Cookies["utm_campaign"].Value.ToString();
            }
        }else{
    		Response.Cookies["utm_campaign"].Value = strUtm_campaign;		
    		Response.Cookies["utm_campaign"].Expires = DateTime.Now.AddDays(120);
        }
        //preferiti e confronto
        if (Request.Cookies["preferiti"]!=null){
			   strPreferitiCookie=Request.Cookies["preferiti"].Value.ToString();
    		}else{
    			strPreferitiCookie="";
    		}
        if (Request.Cookies["confronto"]!=null){
    			strConfrontoCookie=Request.Cookies["confronto"].Value.ToString();
    		}else{
    			strConfrontoCookie="";
    		}
  			//cookie offerte
  			if (Request.Browser.Cookies){		
					if (Request.Cookies["dipendentifca"]!=null){
  					strDipendentifca=Request.Cookies["dipendentifca"].Value.ToString();
					}
  			}

    		strVeicoliCategoria_Ky=sanitizeInput(Request["VeicoliCategoria_Ky"],"number");
    		strVeicoliCarburante_Ky=sanitizeInput(Request["VeicoliCarburante_Ky"],"number");
    		strVeicoliNormativeEuro_Ky=sanitizeInput(Request["VeicoliNormativeEuro_Ky"],"number");
    		strVeicoliTipo_Ky=sanitizeInput(Request["VeicoliTipo_Ky"],"number");
        strChiave = StripHTML(Request["chiave"]);
        strVeicoliCarrozzeria_Ky = sanitizeInput(Request["VeicoliCarrozzeria_Ky"],"number");
        strComuni_Ky = sanitizeInput(Request["Comuni_Ky"],"number");
        strVeicoliCambio_Ky = sanitizeInput(Request["VeicoliCambio_Ky"],"number");
        strVeicoli_KMda = sanitizeInput(Request["Veicoli_KMda"],"number");
        strVeicoli_KMa = sanitizeInput(Request["Veicoli_KMa"],"number");
        strVeicoli_Valoreda = sanitizeInput(Request["Veicoli_Valoreda"],"number");
        strVeicoli_Valorea = sanitizeInput(Request["Veicoli_Valorea"],"number");
        strUtenti_Ky = sanitizeInput(Request["Utenti_Ky"],"number");
        strAutoecologiche = sanitizeInput(Request["autoecologiche"],"number");
        strOrderby = sanitizeInput(Request["orderby"],"string");
        strAnno = sanitizeInput(Request["anno"],"number");
        strTopcar = sanitizeInput(Request["topcar"],"number");
        strNeopatentati = sanitizeInput(Request["neopatentati"],"number");
        strBestprice = sanitizeInput(Request["bestprice"],"number");
        strTags = sanitizeInput(Request["tags"], "string");

        //prendo la prima offerta attiva
        strWHERENet = "VeicoliOfferte_DataInizio<=GETDATE() AND VeicoliOfferte_DataFine>GETDATE() AND VeicoliOfferte_Abilitata=1";
        strFROMNet = "VeicoliOfferte";
        strORDERNet = "VeicoliOfferte_Ky DESC";
        dtVeicoliOfferteAttiva = new DataTable("VeicoliOfferte");
        dtVeicoliOfferteAttiva = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliOfferte_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

        //SEO
        strFromRewrite=StripHTML(Request["fromrewrite"]);
    		strVeicoliMarca_Ky=StripHTML(Request["VeicoliMarca_Ky"]);
    		strVeicoliModello_Ky=StripHTML(Request["VeicoliModello_Ky"]);
    		strVeicoliCategoria_Ky=sanitizeInput(Request["VeicoliCategoria_Ky"], "numeric");

        if (strVeicoliMarca_Ky!=null && strVeicoliMarca_Ky!="0" && strVeicoliMarca_Ky.Length>0){
          dtVeicoliMarcaCorrente = Smartdesk.Sql.getTablePage("VeicoliMarca", null, "VeicoliMarca_Ky", "VeicoliMarca_Ky=" + strVeicoliMarca_Ky, "VeicoliMarca_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }
        if (strVeicoliModello_Ky!=null && strVeicoliModello_Ky!="0" && strVeicoliModello_Ky.Length>0){
          dtVeicoliModelloCorrente = Smartdesk.Sql.getTablePage("VeicoliModello_Vw", null, "VeicoliModello_Ky", "VeicoliModello_Ky=" + strVeicoliModello_Ky, "VeicoliModello_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }
        if (strVeicoliCategoria_Ky!=null && strVeicoliCategoria_Ky!="0" && strVeicoliCategoria_Ky.Length>0){
          dtVeicoliCategoriaCorrente = Smartdesk.Sql.getTablePage("VeicoliCategoria", null, "VeicoliCategoria_Ky", "VeicoliCategoria_Ky=" + strVeicoliCategoria_Ky, "VeicoliCategoria_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }
        dtVeicoliCategoria = Smartdesk.Sql.getTablePage("VeicoliCategoria", null, "VeicoliCategoria_Ky", "", "VeicoliCategoria_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (strVeicoliCarburante_Ky!=null && strVeicoliCarburante_Ky!="0" && strVeicoliCarburante_Ky.Length>0){
          dtVeicoliCarburanteCorrente = Smartdesk.Sql.getTablePage("VeicoliCarburante", null, "VeicoliCarburante_Ky", "VeicoliCarburante_Ky=" + strVeicoliCarburante_Ky, "VeicoliCarburante_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }
        if (strVeicoliNormativeEuro_Ky!=null && strVeicoliNormativeEuro_Ky!="0" && strVeicoliNormativeEuro_Ky.Length>0){
          dtVeicoliNormativeEuroCorrente = Smartdesk.Sql.getTablePage("VeicoliNormativeEuro", null, "VeicoliNormativeEuro_Ky", "VeicoliNormativeEuro_Ky=" + strVeicoliNormativeEuro_Ky, "VeicoliNormativeEuro_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }
        if (strVeicoliCambio_Ky!=null && strVeicoliCambio_Ky!="0" && strVeicoliCambio_Ky.Length>0){
          dtVeicoliCambioCorrente = Smartdesk.Sql.getTablePage("VeicoliCambio", null, "VeicoliCambio_Ky", "VeicoliCambio_Ky=" + strVeicoliCambio_Ky, "VeicoliCambio_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }
        
		    if (strFromRewrite!=null && strFromRewrite.Length>0){
            if (strVeicoliMarca_Ky!=null && strVeicoliMarca_Ky!="0" && strVeicoliMarca_Ky.Length>0){
              strWHERENet="VeicoliMarca_Ky=" + strVeicoliMarca_Ky;  
            }else{
              strWHERENet="(VeicoliMarca_Ky Is Null OR VeicoliMarca_Ky=0)";  
            }
            if (strVeicoliModello_Ky!=null && strVeicoliModello_Ky!="0" && strVeicoliModello_Ky.Length>0){
              strWHERENet+=" AND VeicoliModello_Ky=" + strVeicoliModello_Ky;  
            }else{
              strWHERENet+=" AND (VeicoliModello_Ky Is Null)";  
            }
            if (strVeicoliCategoria_Ky!=null && strVeicoliCategoria_Ky!="0" && strVeicoliCategoria_Ky.Length>0){
              strWHERENet+=" AND VeicoliCategoria_Ky=" + strVeicoliCategoria_Ky;  
            }else{
              strWHERENet+=" AND (VeicoliCategoria_Ky Is Null)";  
            }
            if (strVeicoliCarburante_Ky!=null && strVeicoliCarburante_Ky!="0" && strVeicoliCarburante_Ky.Length>0){
              strWHERENet+=" AND VeicoliCarburante_Ky=" + strVeicoliCarburante_Ky;  
            }else{
              strWHERENet+=" AND (VeicoliCarburante_Ky Is Null)";  
            }
            if (strVeicoliCambio_Ky!=null && strVeicoliCambio_Ky!="0" && strVeicoliCambio_Ky.Length>0){
              strWHERENet+=" AND VeicoliCambio_Ky=" + strVeicoliCambio_Ky;  
            }else{
              strWHERENet+=" AND (VeicoliCambio_Ky Is Null)";  
            }
            if (strVeicoliCarrozzeria_Ky!=null && strVeicoliCarrozzeria_Ky!="0" && strVeicoliCarrozzeria_Ky.Length>0){
              strWHERENet+=" AND VeicoliCarrozzeria_Ky=" + strVeicoliCarrozzeria_Ky;  
            }else{
              strWHERENet+=" AND (VeicoliCarrozzeria_Ky Is Null)";  
            }
            
            if (strAutoecologiche!=null && strAutoecologiche!="0" && strAutoecologiche.Length>0){
              strWHERENet+=" AND VeicoliTestiSEO_Ecologiche=" + strAutoecologiche;  
            }else{
              strWHERENet+=" AND (VeicoliTestiSEO_Ecologiche Is Null)";  
            }
            if (strTopcar!=null && strTopcar!="0" && strTopcar.Length>0){
              strWHERENet+=" AND VeicoliTestiSEO_Topcar=" + strTopcar;  
            }else{
              strWHERENet+=" AND (VeicoliTestiSEO_Topcar Is Null)";  
            }
            if (strNeopatentati!=null && strNeopatentati!="0" && strNeopatentati.Length>0){
              strWHERENet+=" AND VeicoliTestiSEO_Neopatentati=" + strNeopatentati;  
            }else{
              strWHERENet+=" AND (VeicoliTestiSEO_Neopatentati Is Null)";  
            }
            
            //Response.Write(strWHERENet);
            strFROMNet = "VeicoliTestiSEO";
            strORDERNet = "VeicoliTestiSEO_Ky DESC";
            dtVeicoliTestiSEO = new DataTable("VeicoliTestiSEO");
            dtVeicoliTestiSEO = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliTestiSEO_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtVeicoliTestiSEO.Rows.Count>0){
              strMetaTitle=dtVeicoliTestiSEO.Rows[0]["VeicoliTestiSEO_Title"].ToString();
              strMetaDescription=dtVeicoliTestiSEO.Rows[0]["VeicoliTestiSEO_Description"].ToString();
              strH1=dtVeicoliTestiSEO.Rows[0]["VeicoliTestiSEO_Titolo"].ToString();
              strP1=dtVeicoliTestiSEO.Rows[0]["VeicoliTestiSEO_Descrizione"].ToString();
            }else{
              strMetaTitle="Auto usate, aziendali e km0 da Spazio a Torino";
              strMetaDescription="Auto usate, aziendali e km0 da Spazio a Torino";
              strH1="Auto usate, aziendali e km0 da Spazio a Torino";
              strP1="";
            }
        }else{
          strMetaTitle="Auto usate, aziendali e km0 da Spazio a Torino";
          strMetaDescription="Auto usate, aziendali e km0 da Spazio a Torino";
          strH1="Auto usate, aziendali e km0 da Spazio a Torino";
          strP1="";
        }
        
        //marche
        strWHERENet="VeicoliTipo_Ky=1";
        strFROMNet = "VeicoliMarca_Presenti_Vw";
        strORDERNet = "VeicoliMarca_Titolo";
        dtVeicoliMarca = new DataTable("Marche");
        dtVeicoliMarca = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliMarca_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        strPage = sanitizeInput(Request["page"],"numeric");
        strChiave = Request["chiave"];
        if ((strPage == null) || (strPage == ""))
        {
            curpage = "1";
            strPage = "1";
        }
        else
        {
            curpage = strPage;
        }
        intPage = Convert.ToInt32(strPage);
        strWHERENet=getWhere();
        //Response.Write(strWHERENet);
        strFROMNet = "Veicoli_ElencoWeb_Vw";
        strORDERNet = "Veicoli_Valore, VeicoliMarca_Titolo, Veicoli_KM";
        strOrderby = sanitizeInput(Request["orderby"],"string");
        if (strOrderby!=null) { 
    			switch(strOrderby){
    				case "prezzo":
         		  strORDERNet = "Veicoli_Valore, VeicoliMarca_Titolo, Veicoli_KM";
    					break;
    				case "anno":
         		  strORDERNet = "CONVERT(datetime, Veicoli_DataPrimaImmatricolazione,105) DESC, Veicoli_Valore, Veicoli_KM";
    					break;
    				case "km":
         		  strORDERNet = "Veicoli_KM, Veicoli_Valore";
    					break;
    				case "id":
         		  strORDERNet = "Veicoli_Riferimento DESC";
    					break;
    			}
    		}else{
            strORDERNet = "Veicoli_Valore, VeicoliMarca_Titolo, Veicoli_KM";
    		} 
		
		    dtVeicoli = new DataTable("ElencoAuto");
        dtVeicoli = Smartdesk.Sql.getTablePage(strFROMNet, null, "Veicoli_Ky", strWHERENet, strORDERNet, intPage, intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        intNumRecordsVeicoli=intNumRecords;
        //------------------------------------------------------------------------------
        //modelli
        if (strVeicoliMarca_Ky!=null && strVeicoliMarca_Ky.Length>0){
          	strWHERENet="VeicoliTipo_Ky=1 AND VeicoliMarca_Ky=" + strVeicoliMarca_Ky;
          	//Response.Write(strWHERENet);
            strFROMNet = "VeicoliModello_ConVeicoli_Vw";
            strORDERNet = "VeicoliModello_Titolo";
          	dtVeicoloModello = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliModello_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          	strWHERENet="VeicoliTipo_Ky=1 AND VeicoliMarca_Ky=" + strVeicoliMarca_Ky;
          	//Response.Write(strWHERENet);
            strFROMNet = "VeicoliModello_ConVeicoli_Vw";
            strORDERNet = "VeicoliModello_Titolo";
          	dtVeicoloModello2 = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliModello_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          	intNumRecordsModelli=intNumRecords;
        }
        
        strVeicoliMarca_Descrizione=Request["VeicoliMarca_Ky"];
        strVeicoliMarca_DescrizioneHTML=Request["VeicoliMarca_Ky"];
        strVeicoliModello_Descrizione=Request["VeicoliModello_Descrizione"];
        strVeicoliModello_DescrizioneHTML=Request["VeicoliModello_DescrizioneHTML"];
        //------------------------------------------------------------------------------
        //paginazione
        intNumPagine = intNumRecordsVeicoli / intRecxPag;
        if ((intNumRecordsVeicoli % intRecxPag) != 0)
        {
            intNumPagine += 1;
        }
        if (intNumPagine == 0) intNumPagine = 1;
        if (intNumPagine>1){
			intStartPag = intPage - 4;
	        intEndPag = intPage + 5;
        }
        if (intStartPag < 1) { intStartPag = 1; }
        if (intEndPag > intNumPagine) { intEndPag = intNumPagine; }
        strPagineSotto="<ul class=\"pagination\">";
        if ((intNumPagine > 1) && (intPage!=1))
        {
          strPagineSotto += "<li><a href=\"/auto/ricerca-auto.html?orderby=" + strOrderby + "&tags=" + strTags + "&bestprice=" + strBestprice + "&neopatentati=" + strNeopatentati + "&topcar=" + strTopcar + "&autoecologiche=" + strAutoecologiche + "&Comuni_Ky=" + strComuni_Ky + "&Veicoli_Valoreda=" + strVeicoli_Valoreda + "&Veicoli_Valorea=" + strVeicoli_Valorea + "&Veicoli_KMda=" + strVeicoli_KMda + "&Veicoli_KMa=" + strVeicoli_KMa + "&Utenti_Ky=" + strUtenti_Ky + "&VeicoliMarca_Ky=" + strVeicoliMarca_Ky + "&VeicoliModello_Ky=" + strVeicoliModello_Ky + "&VeicoliCategoria_Ky=" + strVeicoliCategoria_Ky + "&VeicoliCarburante_Ky=" + strVeicoliCarburante_Ky + "&VeicoliNormativeEuro_Ky=" + strVeicoliNormativeEuro_Ky + "&VeicoliCambio_Ky=" + strVeicoliCambio_Ky + "&VeicoliCarrozzeria_Ky=" + strVeicoliCarrozzeria_Ky + "&page=1\" rel=\"nofollow\">&lt;&lt; prima &nbsp;</a></li>";
        }
        for (i = intStartPag; i <= intEndPag; i++)
        {
            if (intPage == i)
            {
                strPagineSotto += "<li class=\"current\"><a href=\"#\">" + i + "</a></li>";
            }
            else
            {
                strPagineSotto += "<li><a href=\"/auto/ricerca-auto.html?orderby=" + strOrderby + "&tags=" + strTags + "&bestprice=" + strBestprice + "&neopatentati=" + strNeopatentati + "&topcar=" + strTopcar + "&autoecologiche=" + strAutoecologiche + "&Comuni_Ky=" + strComuni_Ky + "&Veicoli_Valoreda=" + strVeicoli_Valoreda + "&Veicoli_Valorea=" + strVeicoli_Valorea + "&Veicoli_KMda=" + strVeicoli_KMda + "&Veicoli_KMa=" + strVeicoli_KMa + "&Utenti_Ky=" + strUtenti_Ky + "&VeicoliMarca_Ky=" + strVeicoliMarca_Ky + "&VeicoliModello_Ky=" + strVeicoliModello_Ky + "&VeicoliCategoria_Ky=" + strVeicoliCategoria_Ky + "&VeicoliCarburante_Ky=" + strVeicoliCarburante_Ky + "&VeicoliNormativeEuro_Ky=" + strVeicoliNormativeEuro_Ky + "&VeicoliCambio_Ky=" + strVeicoliCambio_Ky + "&VeicoliCarrozzeria_Ky=" + strVeicoliCarrozzeria_Ky + "&page=" + i + "\" rel=\"nofollow\">";
                strPagineSotto += i;
                strPagineSotto += "</a></li>";
            }
        }
        if ((intNumPagine > 1) && (intPage!=intNumPagine))
        {
          strPagineSotto += "<li><a href=\"/auto/ricerca-auto.html?orderby=" + strOrderby + "&tags=" + strTags + "&bestprice=" + strBestprice + "&neopatentati=" + strNeopatentati + "&topcar=" + strTopcar + "&autoecologiche=" + strAutoecologiche + "&Comuni_Ky=" + strComuni_Ky + "&Veicoli_Valoreda=" +strVeicoli_Valoreda + "&Veicoli_Valorea=" + strVeicoli_Valorea + "&Veicoli_KMda=" + strVeicoli_KMda + "&Veicoli_KMa=" + strVeicoli_KMa + "&Utenti_Ky=" + strUtenti_Ky + "&VeicoliMarca_Ky=" + strVeicoliMarca_Ky + "&VeicoliModello_Ky=" + strVeicoliModello_Ky + "&VeicoliCategoria_Ky=" + strVeicoliCategoria_Ky + "&VeicoliCarburante_Ky=" + strVeicoliCarburante_Ky + "&VeicoliNormativeEuro_Ky=" + strVeicoliNormativeEuro_Ky + "&VeicoliCambio_Ky=" + strVeicoliCambio_Ky + "&VeicoliCarrozzeria_Ky=" + strVeicoliCarrozzeria_Ky + "&page=" + intNumPagine.ToString() + "\" rel=\"nofollow\"> ultima &gt;&gt;</a></li>";
        }
        strPagineSotto+="</ul>";
        if (( intNumRecordsVeicoli > 0) && (intNumPagine>1))
        {
           this.PaginaSopra.Text = strPagineSotto;
           this.PaginaSotto.Text = strPagineSotto;
        }
        //------------------------------------------------------------------------------
    }

    public String GetUrlScheda(DataTable dtScheda)
    {
	  string strSchedaTemp="";
      strSchedaTemp="/usata_";
	    strSchedaTemp+=dtScheda.Rows[i]["VeicoliMarca_UrlKey"].ToString().Trim();
	    strSchedaTemp+="-" + dtScheda.Rows[i]["VeicoliModello_DescrizioneHTML"].ToString().Replace("(","").Replace(")","").Replace(">","").Replace("/","").Trim();
	    strSchedaTemp+="-usato_" + dtScheda.Rows[i]["Veicoli_Ky"].ToString().Trim() + ".html";
        if (strUtm_source!=null && strUtm_source.Length>0){
            strSchedaTemp+="?utm_source=" + strUtm_source;
            if (strUtm_medium!=null && strUtm_medium.Length>0){
                strSchedaTemp+="&utm_medium=" + strUtm_medium;
            }
            if (strUtm_campaign!=null && strUtm_campaign.Length>0){
                strSchedaTemp+="&utm_campaign=" + strUtm_campaign;
            }
            if (strUtm_term!=null && strUtm_term.Length>0){
                strSchedaTemp+="&urm_term=" + strUtm_term;
            }
            if (strUtm_content!=null && strUtm_content.Length>0){
                strSchedaTemp+="&utm_content=" + strUtm_content;
            }
        }
      strSchedaTemp="/veicolo/" + dtScheda.Rows[i]["Veicoli_Ky"].ToString().Trim() + ".html";
	  return strSchedaTemp;
    }   

    public int GetNumeroFotoVeicolo(DataRow dtRigaVeicolo)
    {
      int intNumeroFoto=0;
      int intCampo=0;
      string strCampo="";
      for (intCampo=1;intCampo<21;intCampo++){
            strCampo="Veicoli_Foto" + intCampo;
            if (dtRigaVeicolo[strCampo].ToString().Length > 0)
            {
                intNumeroFoto = intCampo;                
            }else{
                break;
            }
        }
      return intNumeroFoto;
    } 

    public String GetDataSeo(DateTime dtIn)
    {
      String[] MonthNames={"Gennaio","Febbraio","Marzo","Aprile","Maggio","Giugno","Luglio","Agosto","Settembre","Ottobre","Novembre","Dicembre"};
      return dtIn.Day.ToString() + " " + MonthNames[dtIn.Month-1];
    }   

    public string getWhere()
    {
    int n;
        string strWHERE="";
        strWHERE="VeicoliTipo_Ky=1"; 
        
		  if ((strAutoecologiche != null) && (strAutoecologiche != "")){
        if (IsNumeric(strAutoecologiche)==true){
          if (strWHERE!=null && strWHERE.Length>0){
            strWHERE = strWHERE + " And (VeicoliCarburante_Ecologico=1)";
          }else{
            strWHERE = "(VeicoliCarburante_Ecologico=1)";
          }    
        }
      }       

  		if ((strTopcar != null) && (strTopcar != "")){
        if (IsNumeric(strTopcar)==true){
          if (strWHERE!=null && strWHERE.Length>0){
            strWHERE = strWHERE + " And (Veicoli_Premium=1)";
          }else{
            strWHERE = "(Veicoli_Premium=1)";
          }    
        }
      } 
                   
		  if ((strNeopatentati != null) && (strNeopatentati != "")){
        if (IsNumeric(strNeopatentati)==true){
          if (strWHERE!=null && strWHERE.Length>0){
            strWHERE = strWHERE + " And (Veicoli_Neopatentati=1)";
          }else{
            strWHERE = "(Veicoli_Neopatentati=1)";
          }  
        }  
      }   
		
    if ((strBestprice != null) && (strBestprice != "")){
      if (IsNumeric(strBestprice)==true){
        if (strWHERE!=null && strWHERE.Length>0){
          strWHERE = strWHERE + " And (Veicoli_BestPrice=1)";
        }else{
          strWHERE = "(Veicoli_BestPrice=1)";
        }  
      }  
    }              

		  if ((strTags != null) && (strTags != "")){
              if (strWHERE!=null && strWHERE.Length>0){
                strWHERE = strWHERE + " And (Veicoli_Tags='" + strTags + "')";
              }else{
                strWHERE = "(Veicoli_Tags='" + strTags + "')";
              }  
          }              

		  if (strVeicoliMarca_Ky != null && strVeicoliMarca_Ky != ""){
          if (int.TryParse(strVeicoliMarca_Ky, out n)){
            if (strWHERE!=null && strWHERE.Length>0){
              strWHERE = strWHERE + " And (VeicoliMarca_Ky=" + strVeicoliMarca_Ky + ")";
            }else{
              strWHERE = "(VeicoliMarca_Ky=" + strVeicoliMarca_Ky + ")";
            }    
          }else{
            if (strWHERE!=null && strWHERE.Length>0){
              strWHERE = strWHERE + " And (VeicoliMarca_UrlKey='" + strVeicoliMarca_Ky + "')";
            }else{
              strWHERE = "(VeicoliMarca_UrlKey='" + strVeicoliMarca_Ky + "')";
            }    

          }
      }              
        
      if (strVeicoliMarca_Ky==null || strVeicoliMarca_Ky.Length<1){
    		if (strVeicoliMarca_UrlKey != null && strVeicoliMarca_UrlKey != ""){
          if (strWHERE!=null && strWHERE.Length>0){
            strWHERE = strWHERE + " And (VeicoliMarca_UrlKey='" + strVeicoliMarca_UrlKey + "')";
          }else{
            strWHERE = "(VeicoliMarca_UrlKey='" + strVeicoliMarca_UrlKey + "')";
          }    
        } 
      }             
				
				
		if ((strVeicoliModello_Ky != null) && (strVeicoliModello_Ky != ""))
        {
            strVeicoliModello_Ky_Selezionato=strVeicoliModello_Ky;
            if (IsNumeric(strVeicoliModello_Ky_Selezionato)==true){
  			      if (strWHERE!=null && strWHERE.Length>0){
                strWHERE = strWHERE + " And (VeicoliModello_Ky=" + strVeicoliModello_Ky_Selezionato + ")";
              }else{
                strWHERE = "VeicoliModello_Ky=" + strVeicoliModello_Ky_Selezionato + ")";
              }  
            }else{
  			      if (strWHERE!=null && strWHERE.Length>0){
                strWHERE = strWHERE + " And (VeicoliModelloSpazioGroup_Modello='" + strVeicoliModello_Ky_Selezionato + "')";
              }else{
                strWHERE = "VeicoliModelloSpazioGroup_Modello='" + strVeicoliModello_Ky_Selezionato + "')";
              }  
            }
        }              

		    if ((strVeicoliCarrozzeria_Ky != null) && (strVeicoliCarrozzeria_Ky != "") && (strVeicoliCarrozzeria_Ky != ",") && (strVeicoliCarrozzeria_Ky.Length>0) && (strVeicoliCarrozzeria_Ky.Length<3)){
          if (IsNumeric(strVeicoliCarrozzeria_Ky)==true){
            if (strWHERE!=null && strWHERE.Length>0){
              strWHERE = strWHERE + " And (VeicoliCarrozzeria_Ky=" + strVeicoliCarrozzeria_Ky + ")";
            }else{
              strWHERE = "VeicoliCarrozzeria_Ky=" + strVeicoliCarrozzeria_Ky + ")";
            }
          }            
        }              

        if ((Request["VeicoliModello_DescrizioneHTML"] != null) && (Request["VeicoliModello_DescrizioneHTML"] != "") && (Request["VeicoliModello_DescrizioneHTML"] != ","))
        {
            strVeicoliModello_HTML_Selezionato=Request["VeicoliModello_DescrizioneHTML"];
			      if (strWHERE!=null && strWHERE.Length>0){
              strWHERE = strWHERE + " And (VeicoliModello_UrlKey='" + strVeicoliModello_HTML_Selezionato + "')";
            }else{
              strWHERE = "VeicoliModello_UrlKey='" + strVeicoliModello_HTML_Selezionato + "')";
            }            
        }  
        
        if ((Request["VeicoliModello_UrlKey"] != null) && (Request["VeicoliModello_UrlKey"] != "") && (Request["VeicoliModello_UrlKey"] != "'") && (Request["VeicoliModello_UrlKey"] != ","))
        {
            strVeicoliModello_HTML_Selezionato=Request["VeicoliModello_UrlKey"];
			      if (strWHERE!=null && strWHERE.Length>0){
              strWHERE = strWHERE + " And (VeicoliModello_UrlKey='" + strVeicoliModello_HTML_Selezionato + "')";
            }else{
              strWHERE = "VeicoliModello_UrlKey='" + strVeicoliModello_HTML_Selezionato + "')";
            }            
        }  
        
                    
        if (strVeicoliCategoria_Ky != null && strVeicoliCategoria_Ky != "" && strVeicoliCategoria_Ky != ","){
          if (IsNumeric(strVeicoliCategoria_Ky)==true){
            if (strWHERE!=null && strWHERE.Length>0){
              strWHERE = strWHERE + " AND (VeicoliCategoria_Ky=" + strVeicoliCategoria_Ky + ")";
            }else{
              strWHERE = " (VeicoliCategoria_Ky=" + strVeicoliCategoria_Ky + ")";
            }
          }
		    }
        if (strComuni_Ky != null && strComuni_Ky != "" && strComuni_Ky != ","){
          if (IsNumeric(strVeicoliCategoria_Ky)==true){
            if (strWHERE!=null && strWHERE.Length>0){
              strWHERE = strWHERE + " AND (Veicoli_CmnKy=" + strComuni_Ky + ")";
            }else{
              strWHERE = " (Veicoli_CmnKy=" + strComuni_Ky + ")";
            }
          }
        }
        if ((strVeicoliCarburante_Ky != null) && (strVeicoliCarburante_Ky != "") && (strVeicoliCarburante_Ky != ","))
        {
           if (IsNumeric(strVeicoliCarburante_Ky)==true){
             if (strWHERE!=null && strWHERE.Length>0){
                strWHERE = strWHERE + " And (VeicoliCarburante_Ky=" + strVeicoliCarburante_Ky + ")";
              }else{
                strWHERE = "(VeicoliCarburante_Ky=" + strVeicoliCarburante_Ky + ")";
              }      
            }      
        }              
        if ((strVeicoliNormativeEuro_Ky != null) && (strVeicoliNormativeEuro_Ky != "") && (strVeicoliNormativeEuro_Ky != ","))
        {
           if (IsNumeric(strVeicoliNormativeEuro_Ky)==true){
             if (strWHERE!=null && strWHERE.Length>0){
                strWHERE = strWHERE + " And (VeicoliNormativeEuro_Ky=" + strVeicoliNormativeEuro_Ky + ")";
              }else{
                strWHERE = "(VeicoliNormativeEuro_Ky=" + strVeicoliNormativeEuro_Ky + ")";
              }      
            }      
        }              

        if ((strVeicoliCambio_Ky != null) && (strVeicoliCambio_Ky != "") && (strVeicoliCambio_Ky != ","))
        {
          if (IsNumeric(strVeicoliCambio_Ky)==true){
            if (strWHERE!=null && strWHERE.Length>0){
              strWHERE = strWHERE + " And (VeicoliCambio_Ky=" + strVeicoliCambio_Ky + ")";
            }else{
              strWHERE = "(VeicoliCambio_Ky=" + strVeicoliCambio_Ky + ")";
            }            
          }
        }              

        if ((strVeicoli_KMda != null) && (strVeicoli_KMda != "") && (strVeicoli_KMda != "NaN") && (strVeicoli_KMda != "0") && (strVeicoli_KMda != ","))
        {
          if (IsNumeric(strVeicoli_KMda)==true){
            if (strWHERE!=null && strWHERE.Length>0){
              strWHERE = strWHERE + " And (Veicoli_KM>=" + strVeicoli_KMda + ")";
            }else{
              strWHERE = "(Veicoli_KM>=" + strVeicoli_KMda + ")";
            }  
          }          
        }              
        if ((strVeicoli_KMa != null) && (strVeicoli_KMa != "") && (strVeicoli_KMa != "NaN") && (strVeicoli_KMa != "0") && (strVeicoli_KMa != ","))
        {
          if (IsNumeric(strVeicoli_KMa)==true){
            if (strWHERE!=null && strWHERE.Length>0){
              strWHERE = strWHERE + " And (Veicoli_KM<=" + strVeicoli_KMa + ")";
            }else{
              strWHERE = "(Veicoli_KM<=" + strVeicoli_KMa + ")";
            } 
          }           
        }              

        if ((strVeicoli_Valoreda != null) && (strVeicoli_Valoreda != "")  && (strVeicoli_Valoreda != "NaN") && (strVeicoli_Valoreda != "0") && (strVeicoli_Valoreda != ","))
        {
          if (IsNumeric(strVeicoli_Valoreda)==true){
            if (strWHERE!=null && strWHERE.Length>0){
              strWHERE = strWHERE + " And (Veicoli_Valore>=" + strVeicoli_Valoreda + ")";
            }else{
              strWHERE = "(Veicoli_Valore>=" + strVeicoli_Valoreda + ")";
            }
          }        
        }              
        if ((strVeicoli_Valorea != null) && (strVeicoli_Valorea != "") && (strVeicoli_Valorea != "NaN") && (strVeicoli_Valorea != "0") && (strVeicoli_Valorea != ","))
        {
          if (IsNumeric(strVeicoli_Valorea)==true){
            if (strWHERE!=null && strWHERE.Length>0){
              strWHERE = strWHERE + " And (Veicoli_Valore<=" + strVeicoli_Valorea + ")";
            }else{
              strWHERE = "(Veicoli_Valore<=" + strVeicoli_Valorea + ")";
            }  
          }          
        }              
				if ((strAnno != null) && (strAnno != "") && (strAnno != "Anno a partire") && (strAnno != ","))
        {
          if (IsNumeric(strAnno)==true){
            if (strWHERE!=null && strWHERE.Length>0){
              strWHERE = strWHERE + " And YEAR(CONVERT(datetime, Veicoli_DataPrimaImmatricolazione,105))>=" + strAnno + "";
            }else{
              strWHERE = "YEAR(CONVERT(datetime, Veicoli_DataPrimaImmatricolazione,105))>=" + strAnno + "";
            }  
          }          
        }              
        if ((strUtenti_Ky != null) && (strUtenti_Ky != "") && (strUtenti_Ky != "0"))
        {
          if (IsNumeric(strAnno)==true){
            if (strWHERE!=null && strWHERE.Length>0){
              strWHERE = strWHERE + " And (Utenti_Ky=" + strUtenti_Ky + ")";
            }else{
              strWHERE = "(Utenti_Ky=" + strUtenti_Ky + ")";
            }   
          }         
        }              
        strWHEREVeicoli=strWHERE;
				//Response.Write(Request["VeicoliModello_Ky"]);
        //Response.Write(strWHERE);
        return strWHERE;
    }

    public static string sanitizeInput(string strInput, string strType){
        string strPattern;
        string strReturn;
        if (strInput != null)
        {
            switch (strType){
              case "string":
                strPattern = @"<(.|\n)*?>";
                strReturn = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, string.Empty);
                strReturn = strReturn.Replace(">","").Replace("<","").Replace("'","").Replace("\"","");
                break;
              case "number":
                strPattern = @"[^0-9.]";
                strReturn = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, string.Empty);
                strReturn = strReturn.Replace(" ","").Replace("..",".");
                break;
              default:
                strPattern = @"<(.|\n)*?>";
                strReturn = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, string.Empty);
                strReturn = strReturn.Replace(">","").Replace("<","").Replace("'","").Replace("\"","");
                break;
            }
            return strReturn;
        }
        else
        {
            return string.Empty;
        }    
    }

    public static string StripHTML(string htmlString)
    {
        string strPattern;
        string strReturn;
        if (htmlString != null)
        {
            strPattern = @"<(.|\n)*?>";
            strReturn = System.Text.RegularExpressions.Regex.Replace(htmlString, strPattern, string.Empty);
            strReturn = strReturn.Replace(">","").Replace("<","").Replace("'","").Replace("\"","");
            return strReturn;
        }
        else
        {
            return string.Empty;
        }
    }
    
    public bool IsNumeric(string strValue){
      bool boolReturn=false;
      int number;
        if (int.TryParse(strValue, out number))
        {
            boolReturn=true;
        }
        return boolReturn;
    }    

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App)
    {
        if (table.Trim() == "" || App.Trim() == "")
        {
            Exception ex = new Exception("csLoadData->getTablePage: Manca Tabella: " + table + " o App: " + App);
            throw ex;
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");

        SqlConnection cn = new SqlConnection(App);
        SqlCommand cm = new SqlCommand();
        SqlParameter pm = null;

        cm.CommandTimeout = 0;
        cm.CommandText = "getTablePage";
        cm.CommandType = CommandType.StoredProcedure;
        cm.Connection = cn;

        pm = new SqlParameter("@table", SqlDbType.VarChar, 50);
        pm.Value = table;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@tableout", SqlDbType.VarChar, 50);
        pm.Value = tableout;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@key", SqlDbType.VarChar, 50);
        pm.Value = key;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@whr", SqlDbType.VarChar, 1000);
        pm.Value = where;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@ord", SqlDbType.VarChar, 100);
        pm.Value = orderby;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@pg", SqlDbType.Int);
        pm.Value = pagina;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@pgmax", SqlDbType.Int);
        pm.Value = paginamax;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@rows", SqlDbType.Int);
        pm.Value = paginamax;
        pm.Direction = System.Data.ParameterDirection.Output;
        cm.Parameters.Add(pm);
        da.SelectCommand = cm;
        cn.Open();
        try
        {
            da.Fill(dt);
        }
        catch (SqlException ex)
        {
            string msg = "<br />Table: " + table + "<br />Tableout:" + tableout + "<br />Where:" + where + "<br />Orderby:" + orderby;
            Exception err = new Exception("csLoadData->getTablePage: " + ex.Message + msg);
            throw err;
        }
        finally
        {
            dt.Dispose();
            cm.Dispose();
            cn.Close();
        }
        System.Data.IDataParameter[] id;
        id = da.GetFillParameters();
        this.intNumRecords = Convert.ToInt32(id[7].Value.ToString());
        return dt;
    }

}
