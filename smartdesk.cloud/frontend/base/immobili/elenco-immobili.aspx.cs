using System;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page 
{
    public string strMetaDescription = "";
    public string strMetaRobots = "";
    public string strCanonical = "";
    public string strH1 = "";
    public string strP1 = "";
    public string strTitle = "";
    public string strNomeProvincia="";
    public string strNomeRegione="";
    public string strNomeProvinciaHTML="";
    public string strProvinciaLink="";
    public string strScheda="";
    public string strAlt="";
    public int i = 0;
    public int intNumPagine=1;
    public int intNumRecords = 0;
    public int intRecxPag = 50;
    public int intStartPag = 1;
    public int intEndPag = 1;
    public int intPage = 0;
    public DataTable dtImmobili;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strProvince_Ky="";
    public string strImmobiliCategoria_Ky="";
    public string strDove="";
    public string strArea="";
    public string strImmobiliTipologia_Ky="";
    public string strImmobiliTipologia2_Ky="";
    public string strImmobiliSottotipologia_Ky="";
    public string strImmobiliSottotipologia2_Ky="";
    public string strCamere="";
    public string strBagni="";
    public string strPostiAuto="";
    public string strUtenti_Ky="";
    public string strComuni_Ky="";
    public string strImmobiliZona_Ky="";
    public string strComuniLink="";
    public string strNomeComune="";
    public string strNomeComuneHTML="";
    public string strTipologia="";
    public string strContratto="";
    public string strLocalita="";
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
        string strChiave = "0";
        int i = 0;
        string strPagineSotto = "";
        string strWHERENet="";
        string strFROMNet = "";
        string strORDERNet = "";
        DataTable dtComuni;
        DataTable dtCoreUrlRewrite;
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
        string strPage="";
        string curpage="";
    
    	  
    	  

        //canonical
        strWHERENet = "CoreEntities_Code='immobilisa' AND CoreUrlRewrite_UrlDestination='" + removeBlankParameters(Request.Url.PathAndQuery) + "'";
        strORDERNet = "CoreUrlRewrite_Ky";
        strFROMNet = "CoreUrlRewrite";
        dtCoreUrlRewrite = new DataTable("Login");
        dtCoreUrlRewrite = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreUrlRewrite_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreUrlRewrite.Rows.Count > 0)
        {
            strCanonical = dtCoreUrlRewrite.Rows[0]["CoreUrlRewrite_UrlSource"].ToString();
        }

        strPage = Request["page"];
        strChiave = Request["chiave"];
        strProvince_Ky = Request["Province_Ky"];
        strComuni_Ky = Request["Comuni_Ky"];
        strImmobiliZona_Ky = Request["ImmobiliZona_Ky"];
        strImmobiliCategoria_Ky = Request["ImmobiliCategoria_Ky"];
        strImmobiliTipologia_Ky = Request["ImmobiliTipologia_Ky"];
        strImmobiliTipologia2_Ky = Request["ImmobiliTipologia2_Ky"];
        strImmobiliSottotipologia_Ky = Request["ImmobiliSottotipologia_Ky"];
        strImmobiliSottotipologia2_Ky = Request["ImmobiliSottotipologia2_Ky"];
        strCamere = Request["camere"];
        strBagni= Request["bagni"];
        strPostiAuto= Request["postiauto"];
        strUtenti_Ky = Request["Utenti_Ky"];

        if (strImmobiliCategoria_Ky == null)
        {
            strImmobiliCategoria_Ky = "";
        }
        if (strProvince_Ky==null || strProvince_Ky.Length<1 || isInteger(strPage)==false || isInteger(strChiave)==false || isInteger(strProvince_Ky)==false){
          Response.RedirectPermanent("/");
        }
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
        if (intPage==1){
          strMetaRobots="index,follow";
        }else{
          strMetaRobots="noindex, nofollow";
        }
        
        if (strComuni_Ky!=null && strComuni_Ky.Length>0){
			strWHERENet="Comuni_Ky=" + strComuni_Ky;
		}else{
			strWHERENet="Province_Ky=" + strProvince_Ky;
		}
		//Response.Write(strWHERENet);
        strFROMNet = "Comuni_Vw";
        strORDERNet = "Province_Ky, Comuni_Comune";
        dtComuni = new DataTable("Comuni");
        dtComuni = Smartdesk.Sql.getTablePage(strFROMNet, null, "Comuni_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        strNomeProvincia=dtComuni.Rows[0]["Province_Provincia"].ToString().ToLower();
        strNomeProvinciaHTML=dtComuni.Rows[0]["Province_ProvinciaHTML"].ToString().ToLower();
        strNomeProvincia=strNomeProvincia.ToUpper();
        strNomeRegione=dtComuni.Rows[0]["Regioni_Regione"].ToString();
        strNomeComune=dtComuni.Rows[0]["Comuni_Comune"].ToString().ToLower();
        strNomeComuneHTML=dtComuni.Rows[0]["Comuni_ComuneHTML"].ToString().ToLower();
        strNomeComune=strNomeComune.ToUpper();
		//Response.Write(strNomeComune);
        dtComuni.Dispose();
        strProvinciaLink=getProvinciaLink(strNomeProvinciaHTML,strChiave);
        strComuniLink=getComuniLink(strNomeProvinciaHTML,strNomeComuneHTML,strChiave);

        switch (strChiave){
          case "0":
            strTipologia="case";
            break;
          case "1":
            strTipologia="case";
            break;
          case "2":
            strTipologia="case";
            break;
          case "3":
            strTipologia="immobili";
            break;
          case "4":
            strTipologia="annunci immobiliari";
            break;
          case "5":
            strTipologia="annunci immobiliari";
            break;
          case "6":
            strTipologia="case";
            break;
          case "7":
            strTipologia="case";
            break;
          case "8":
            strTipologia="case";
            break;
          case "9":
            strTipologia="agenzie immobiliari";
            break;
          case "10":
            strTipologia="agenzia immobiliare";
            break;
          case "11":
            strTipologia="appartamenti";
            break;
          case "12":
            strTipologia="appartamenti";
            break;
          case "13":
            strTipologia="appartamenti monolocali";
            break;
          case "14":
            strTipologia="appartamenti";
            break;
          case "15":
            strTipologia="appartamenti";
            break;
          case "16":
            strTipologia="rustici";
            break;
          case "17":
            strTipologia="negozi";
            break;
          case "18":
            strTipologia="terreni";
            break;
          case "19":
            strTipologia="uffici";
            break;
          case "20":
            strTipologia="Ville e villette";
            break;
          case "21":
            strTipologia="Ville e villette";
            break;
          case "26":
            strTipologia="casa";
            break;
          case "27":
            strTipologia="nuove costruzioni";
            break;
          case "28":
            strTipologia="stanze";
            break;
          case "29":
            strTipologia="case vacanza";
            break;
          case "30":
            strTipologia="nuove costruzioni";
            break;
          case "31":
            strTipologia="stanze";
            break;        
        }
        switch (strImmobiliCategoria_Ky){
          case "":
			strContratto="affitto e vendita";
			break;                                              
	      case "1":
        	strContratto="affitto";
			break;                                              
	      case "2":
        	strContratto="vendita";
			break;                                              
	    }
        if (strComuni_Ky!=null && strComuni_Ky.Length>0){
        	strLocalita=strNomeComune;
        }else{
        	strLocalita=strNomeProvincia;
		    }
        strMetaDescription=strTipologia + " in " + strContratto + " a " + strLocalita;
        strH1=strTipologia + " in " + strContratto + " a " + strLocalita;
        strP1=strTipologia + " in " + strContratto + " a " + strLocalita + ", cerco compro vendo affitti vendite " + strTipologia + " a " + strLocalita;
        strTitle=strTipologia + " in " + strContratto + " a " + strLocalita;
		
		    strWHERENet = getWhere();
        //Response.Write(strWHERENet);
        strFROMNet = "Immobili_ElencoWeb_Vw";
        strORDERNet = "Immobili_Ky DESC";
        dtImmobili = new DataTable("ElencoImmobili");
        dtImmobili = Smartdesk.Sql.getTablePage(strFROMNet, null, "Immobili_Ky", strWHERENet, strORDERNet, intPage, intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtImmobili.Rows.Count>0){
        intNumPagine = intNumRecords / intRecxPag;
	        if ((intNumRecords % intRecxPag) != 0)
	        {
	            intNumPagine += 1;
	        }
	        if (intNumPagine == 0){
	          intNumPagine = 1;
	        }
	        intStartPag = intPage - 4;
	        intEndPag = intPage + 5;
	        if (intStartPag < 1) { intStartPag = 1; }
	        if (intEndPag > intNumPagine) { intEndPag = intNumPagine; }
	
	        strPagineSotto = "<ul class=\"pagination text-center\" role=\"navigation\" aria-label=\"Pagination\">";
	        //prima
	        if ((intNumPagine > 1) && (intPage!=1))
	        {
			  strPagineSotto += "<li class=\"pagination-first\"><a href=\"/frontend/base/immobili/elenco-immobili.aspx?Province_Ky=" + strProvince_Ky + "&ImmobiliCategoria_Ky=" + strImmobiliCategoria_Ky + "&ImmobiliTipologia_Ky=" + strImmobiliTipologia_Ky + "&page=1&chiave=" + strChiave + "\" rel=\"nofollow\">&lt;&lt; prima &nbsp;</a></li>";
	        }
	        //pagine
	        for (i = intStartPag; i <= intEndPag; i++)
	        {
	            if (intPage == i)
	            {
	                strPagineSotto += "<li class=\"current\">" + i + "</li>\n";
	            }
	            else
	            {
	                strPagineSotto += "<li><a href=\"/frontend/base/immobili/elenco-immobili.aspx?Province_Ky=" + strProvince_Ky + "&ImmobiliCategoria_Ky=" + strImmobiliCategoria_Ky + "&ImmobiliTipologia_Ky=" + strImmobiliTipologia_Ky + "&page=" + i + "&chiave=" + strChiave + "\" rel=\"nofollow\" aria-label=\"Pagina " + i + "\">";
	                strPagineSotto += i;
	                strPagineSotto += "</a></li>\n";
	            }
	        }
	        //ultima
	        if ((intNumPagine > 1) && (intPage!=intNumPagine))
	        {
	          strPagineSotto += "<li class=\"pagination-last\"><a href=\"/frontend/base/immobili/elenco-immobili.aspx?Province_Ky=" + strProvince_Ky + "&ImmobiliCategoria_Ky=" + strImmobiliCategoria_Ky + "&ImmobiliTipologia_Ky=" + strImmobiliTipologia_Ky + "&page=" + intNumPagine.ToString() + "&chiave=" + strChiave + "\" rel=\"nofollow\"> ultima &gt;&gt;</a></li>";
	          
	        }
	        if (intNumPagine > 1){
	          strPagineSotto += "</ul>";
			}
	        if ((intNumRecords > 0) && (intNumPagine>1))
	        {
	           this.PaginaSotto.Text = strPagineSotto;
	        }
		}
    }

    public string getWhere()
    {
        string strWHERE="";
        string strValue="";

        strWHERE = "(Immobili_Valore>1)";
      
        if (strDove!=null && strDove.Length>0){
          if (strWHERE!=null && strWHERE.Length>0){
            strWHERE += " And (Comuni_Comune like '%" + strDove.Replace("'","''") + "%')";
          }else{
          	strWHERE = "(Comuni_Comune like '%" + strDove.Replace("'","''") + "%')";
          }
        }
      
        if (strProvince_Ky != null && strProvince_Ky != "")
        {
          if (strWHERE!=null && strWHERE.Length>0){
            strWHERE += " And (Immobili_PrvKy=" + strProvince_Ky + ")";
          }else{
            strWHERE = "(Immobili_PrvKy=" + strProvince_Ky + ")";
          }
        }
      
        if (strComuni_Ky != null && strComuni_Ky != "")
        {
          if (strWHERE!=null && strWHERE.Length>0){
            strWHERE += " And (Immobili_CmnKy=" + strComuni_Ky + ")";
          }else{
            strWHERE = "(Immobili_CmnKy=" + strComuni_Ky + ")";
          }
        }
      
        if (strImmobiliZona_Ky != null && strImmobiliZona_Ky != "")
        {
          if (strWHERE!=null && strWHERE.Length>0){
            strWHERE += " And (ImmobiliZona_Ky=" + strImmobiliZona_Ky + ")";
          }else{
            strWHERE = "(ImmobiliZona_Ky=" + strImmobiliZona_Ky + ")";
          }
        }
      
        if (strArea != null && strArea != "")
        {
          if (strWHERE!=null && strWHERE.Length>0){
            strWHERE += " And (ImmobiliArea_Ky=" + strArea + ")";
          }else{
            strWHERE = "(ImmobiliArea_Ky=" + strArea + ")";
          }
        }
        
		if (strImmobiliTipologia_Ky != null && strImmobiliTipologia_Ky != "")
        {
          if (strWHERE!=null && strWHERE.Length>0){
            strWHERE += " And (ImmobiliTipologia_Ky=" + strImmobiliTipologia_Ky + ")";
          }else{
            strWHERE = "(ImmobiliTipologia_Ky=" + strImmobiliTipologia_Ky + ")";
          }
        }
        
		if (strImmobiliSottotipologia_Ky != null && strImmobiliSottotipologia_Ky != "")
        {
          if (strWHERE!=null && strWHERE.Length>0){
            strWHERE += " And (ImmobiliSottotipologia_Ky=" + strImmobiliSottotipologia_Ky + ")";
          }else{
            strWHERE = "(ImmobiliSottotipologia_Ky=" + strImmobiliSottotipologia_Ky + ")";
          }
        }
        
        if (strImmobiliCategoria_Ky != null && strImmobiliCategoria_Ky != "")
        {
          if (strWHERE!=null && strWHERE.Length>0){
            strWHERE += " And (ImmobiliCategoria_Ky=" + strImmobiliCategoria_Ky + ")";
          }else{
            strWHERE = "(ImmobiliCategoria_Ky=" + strImmobiliCategoria_Ky + ")";
          }
        }

        if (strCamere != null && strCamere != "")
        {
          if (strWHERE!=null && strWHERE.Length>0){
            strWHERE = strWHERE + " And (Immobili_NumeroCamereLetto" + strCamere + ")";
          }else{
            strWHERE = "(Immobili_NumeroCamereLetto" + strCamere + ")";
          }
        }
        
		if (strBagni != null && strBagni != ""){
            strWHERE = strWHERE + " AND (Immobili_NumeroBagni" + strBagni + ")";
        }
        if (strPostiAuto != null && strPostiAuto != ""){
            strWHERE = strWHERE + " AND (Immobili_NumeroPostiAuto" + strPostiAuto + ")";
        }

        strValue = Request["classe"];
        if (strValue != null && strValue != ""){
            strWHERE = strWHERE + " AND (Immobili_ClasseEnergetica='" + strValue + "')";
        }
        strValue = Request["incostruzione"];
        if (strValue != null && strValue != ""){
            strWHERE = strWHERE + " AND (Immobili_NuovaCostruzione=1)";
        }
        strValue = Request["ecologico"];
        if (strValue != null && strValue != ""){
            strWHERE = strWHERE + " AND (Immobili_Ecologico=1)";
        }
        strValue = Request["turistico"];
        if (strValue != null && strValue != ""){
            strWHERE = strWHERE + " AND (Immobili_Turistico=1)";
        }
        strValue = Request["prestigio"];
        if (strValue != null && strValue != ""){
            strWHERE = strWHERE + " AND (Immobili_Prestigio=1)";
        }
        strValue = Request["mqmin"];
        if (strValue != null && strValue != "")
        {
            strWHERE = strWHERE + " AND (Immobili_Mq" + strValue + ")";
        }
        strValue = Request["prezzomax"];
        if (strValue != null && strValue != "")
        {
            strWHERE = strWHERE + " AND (Immobili_Valore" + strValue + ")";
        }
        if (strUtenti_Ky != null && strUtenti_Ky != "")
        {
            strWHERE = strWHERE + " AND (Utenti_Ky=" + strUtenti_Ky + ")";
        }		
		//Response.Write(strWHERE);
        return strWHERE;
    }

    public string getChecked(string strCheck){
      if (strCheck=="1" || strCheck=="on"){
	  	return "true";
	  }else{
	  	return "false";
	  }	
	}

    public string getAnnuncio(string strAnnuncio,string strComune,string strTipologia){
    	string strAnnuncioTemp="";
    	strAnnuncioTemp=StripHTML(strAnnuncio);
    	if (strAnnuncioTemp!=null && strAnnuncioTemp.Length>0){
    	if (strTipologia!=null && strTipologia.Length>0){
		  strAnnuncioTemp=strAnnuncioTemp.Replace(strTipologia, "<strong>" + strTipologia + "</strong>");
		}
    	if (strTipologia!=null && strTipologia.Length>0){
	    	strAnnuncioTemp=strAnnuncioTemp.Replace(strTipologia, "<strong>" + strTipologia + "</strong>");
	    }
    	strAnnuncioTemp=strAnnuncioTemp.Replace("affitto", "<strong>affitto</strong>");
    	strAnnuncioTemp=strAnnuncioTemp.Replace("vendita", "<strong>vendita</strong>");
    	}
    	return strAnnuncioTemp; 
    }

	public static string StripHTML(string input){
	   return Regex.Replace(input, "<.*?>", String.Empty);
	}

    public string getProvinciaLink(string strProvincia,string strChiave)
    {
      string strRitorno="<ul class=\"no-bullet\">";
        strRitorno+="<li><a href=\"/immobili/" + strProvincia + "/vendita-case-provincia-" + strProvincia + ".html\" title=\"vendita case provincia " + strProvincia + "\">vendita case provincia " + strProvincia + "</a></li>";
        strRitorno+="<li><a href=\"/immobili/" + strProvincia + "/affitto-case-provincia-" + strProvincia + ".html\" title=\"affitto case provincia " + strProvincia + "\">affitto case provincia " + strProvincia + "</a></li>";
        strRitorno+= "<li><a href=\"/immobili/" + strProvincia + "/agenzie-immobiliari-provincia-" + strProvincia + ".html\" title=\"agenzie immobiliari provincia " + strProvincia + "\">agenzie immobiliari provincia " + strProvincia + "</a></li>";

        strRitorno+="</ul>";
      return strRitorno;     
    }

    public string getComuniLink(string strProvincia,string strComune,string strChiave)
    {
      string strRitorno="<ul class=\"no-bullet\">";
        if (strChiave!="15"){strRitorno+="<li><a href=\"/immobili/" + strProvincia + "/affitto-appartamenti-" + strComune + ".html\" title=\"affitto appartamenti " + strComune + "\">affitto appartamenti " + strComune + "</a></li>";}
        if (strChiave!="11"){strRitorno+="<li><a href=\"/immobili/" + strProvincia + "/vendita-appartamenti-" + strComune + ".html\" title=\"vendita appartamenti " + strComune + "\">vendita appartamenti " + strComune + "</a></li>";}

        if (strChiave!="6"){strRitorno+="<li><a href=\"/immobili/" + strProvincia + "/vendita-case-" + strComune + ".html\" title=\"vendita case " + strComune + "\">vendita case " + strComune + "</a></li>";}
        if (strChiave!="7"){strRitorno+="<li><a href=\"/immobili/" + strProvincia + "/affitto-case-" + strComune + ".html\" title=\"affitto case " + strComune + "\">affitto case " + strComune + "</a></li>";}

        if (strChiave!="20"){strRitorno+="<li><a href=\"/immobili/" + strProvincia + "/vendita-ville-" + strComune + ".html\" title=\"vendita ville villette " + strComune + "\">vendita ville villette " + strComune + "</a></li>";}
        if (strChiave!="21"){strRitorno+="<li><a href=\"/immobili/" + strProvincia + "/affitto-ville-" + strComune + ".html\" title=\"affitto ville villette " + strComune + "\">affitto ville villette " + strComune + "</a></li>";}
        
        if (strChiave!="16"){strRitorno+="<li><a href=\"/immobili/" + strProvincia + "/rustico-" + strComune + ".html\" title=\"rustico " + strComune + "\">rustico " + strComune + "</a></li>";}
        if (strChiave!="17"){strRitorno+="<li><a href=\"/immobili/" + strProvincia + "/negozi-" + strComune + ".html\" title=\"negozi " + strComune + "\">negozi " + strComune + "</a></li>";}
        if (strChiave!="18"){strRitorno+="<li><a href=\"/immobili/" + strProvincia + "/terreni-" + strComune + ".html\" title=\"terreni " + strComune + "\">terreni " + strComune + "</a></li>";}
        if (strChiave!="19"){strRitorno+="<li><a href=\"/immobili/" + strProvincia + "/ufficio-" + strComune + ".html\" title=\"ufficio " + strComune + "\">ufficio " + strComune + "</a></li>";}
        if (strChiave!="29"){strRitorno+="<li><a href=\"/immobili/" + strProvincia + "/case-vacanza-" + strComune + ".html\" title=\"case vacanza " + strComune + "\">case vacanza " + strComune + "</a></li>";}
        if (strChiave!="30"){strRitorno+="<li><a href=\"/immobili/" + strProvincia + "/nuove-costruzioni-" + strComune + ".html\" title=\"nuove costruzioni " + strComune + "\">nuove costruzioni " + strComune + "</a></li>";}
        if (strChiave!="31"){strRitorno+="<li><a href=\"/immobili/" + strProvincia + "/stanze-" + strComune + ".html\" title=\"stanze " + strComune + "\">stanze " + strComune + "</a></li>";}
        if (strChiave!="32"){strRitorno+="<li><a href=\"/immobili/" + strProvincia + "/case-lusso-" + strComune + ".html\" title=\"case lusso " + strComune + "\">case lusso " + strComune + "</a></li>";}
        if (strChiave != "9") { strRitorno += "<li><a href=\"/immobili/" + strProvincia + "/agenzie-immobiliari-" + strComune + ".html\" title=\"agenzie immobiliari " + strComune + "\">agenzie immobiliari " + strComune + "</a></li>"; }
        strRitorno+="</ul>";
	  return strRitorno;     
    }

    public String GetDataSeo(DateTime dtIn)
    {
      String[] MonthNames={"Gennaio","Febbraio","Marzo","Aprile","Maggio","Giugno","Luglio","Agosto","Settembre","Ottobre","Novembre","Dicembre"};
      return dtIn.Day.ToString() + " " + MonthNames[dtIn.Month-1];
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

    public static bool isInteger(string theValue)
    {
        try
        {
            Convert.ToInt32(theValue);
            return true;
        } 
        catch 
        {
            return false;
        }
    }

    public static string removeBlankParameters(string strParameters)
    {
        string pattern = "(?:^|&)[a-zA-Z]+=(?=&|$)";
        string replacement = "";
        Regex rgx = new Regex(pattern);
        string result = rgx.Replace(strParameters, replacement);

        return result;
    }

}
