using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page 
{
    public string strMetaDescription = "";
    public string strMetaKeywords = "";
    public string strMetaRobots = "";
    public string strH1 = "";
    public string strP1 = "";
    public string strTitle = "";
    public string strNomeProvincia="";
    public string strNomeComune = "";
    public string strNomeProvinciaHTML="";
    public string strNomeComuneHTML = "";
    public string strContrattoDemo="";
    public int i = 0;
    public int intNumPagine=1;
    public int intNumRecords = 0;
    public int intRecxPag = 30;
    public int intStartPag = 1;
    public int intEndPag = 1;
    public int intPage = 0;
    public DataTable dtAgenzie;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strScheda="";
    public string strAlt="";
    public string strFondo = "";
    public string strComuni_Ky = "";
    public string strConnNetRO = "";
    public string strConnNetWR = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string strChiave = "0";
        string strProvince_Ky="";
        int i = 0;
        string strPagineSotto = "";
        string strWHERENet="";
        string strFROMNet = "";
        string strORDERNet = "";
        DataTable dtProvince;
        DataTable dtComuni;
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
        string strPage="";
        string curpage="";
    
    	  strConnNetRO = RswStudio.Config.Sql.ConnectionReadOnly;
    	  strConnNetWR = RswStudio.Config.Sql.ConnectionWrite;
        //strTipologiaDemo="Agenzia immobiliare";
        strContrattoDemo="";
        strPage = Request["page"];
        strChiave = Request["chiave"];
        strProvince_Ky= Request["Province_Ky"];
        strComuni_Ky = Request["Comuni_Ky"];
        if (isInteger(strPage)==false || isInteger(strChiave)==false || isInteger(strProvince_Ky)==false){
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
        if (strComuni_Ky==null || strComuni_Ky.Length<1){
            //agenzie per provincia
            strWHERENet = "Province_Ky=" + strProvince_Ky;
            strFROMNet = "Comuni_Vw";
            strORDERNet = "Province_Ky";
            dtProvince = new DataTable("Comuni");
            dtProvince = getTablePage(strFROMNet, null, "Province_Ky", strWHERENet, strORDERNet, intPage, 1, strConnNetRO);
            strNomeProvincia = dtProvince.Rows[0]["Province_Provincia"].ToString().ToLower();
            strNomeProvinciaHTML = dtProvince.Rows[0]["Province_ProvinciaHTML"].ToString().ToLower();
            strNomeProvincia = strNomeProvincia.ToUpper();
            dtProvince.Dispose();
            strMetaDescription = "Agenzie immobiliari a " + strNomeProvincia + ". Se stai cercando una agenzia immobiliare trova quella piï¿½ vicina a casa tra le migliaia di agenzie immobiliari di " + strNomeProvincia + " presenti in citt&agrave; e provincia.";
            strMetaKeywords = "Agenzie immobiliari " + strNomeProvincia + ", Franchising Immobiliari " + strNomeProvincia + ", " + strNomeProvincia;
            strH1 = "Agenzie immobiliari " + strNomeProvincia;
            strP1 = "Agenzie immobiliari " + strNomeProvincia + ", Franchising Immobiliari " + strNomeProvincia + "," + strNomeProvincia;
            strTitle = "Agenzie immobiliari " + strNomeProvincia + ", Franchising Immobiliari " + strNomeProvincia;
            strWHERENet = "Province_Ky=" + strProvince_Ky;
        }else{
            strWHERENet = "Comuni_Ky=" + strComuni_Ky;
            strFROMNet = "Comuni_Vw";
            strORDERNet = "Comuni_Ky";
            dtComuni = new DataTable("Comuni");
            dtComuni = getTablePage(strFROMNet, null, "Comuni_Ky", strWHERENet, strORDERNet, 1, 1000, strConnNetRO);
            strNomeProvincia = dtComuni.Rows[0]["Province_Provincia"].ToString().ToLower();
            strNomeProvinciaHTML = dtComuni.Rows[0]["Province_ProvinciaHTML"].ToString().ToLower();
            strNomeComune = dtComuni.Rows[0]["Comuni_Comune"].ToString().ToLower();
            strNomeComuneHTML = dtComuni.Rows[0]["Comuni_ComuneHTML"].ToString().ToLower();
            strNomeComune = strNomeComune.ToUpper();
            strNomeProvincia = strNomeProvincia.ToUpper();
            dtComuni.Dispose();
             strMetaDescription = "Agenzie immobiliari a " + strNomeComune + ". Trova le agenzie immobiliari più vicine a casa e naviga tutte le agenzie immobiliari di " + strNomeComune + ".";
            strMetaKeywords = "Agenzie immobiliari " + strNomeComune + ", Franchising Immobiliari " + strNomeComune + ", agenzie, franchising," + strNomeComune;
            strH1 = "Agenzie immobiliari " + strNomeComune;
            strP1 = "Agenzie immobiliari " + strNomeComune + ", Franchising Immobiliari " + strNomeComune + "," + strNomeComune;
            strTitle = "Agenzie immobiliari " + strNomeComune + ", Franchising Immobiliari " + strNomeComune + "," + strNomeComune + ". Trova l'agenzia più vicina a casa e naviga tutte le agenzie immobiliari di " + strNomeComune + ".";
            strFondo = "<p>Naviga per cercare le <b>agenzie immobiliari " + strNomeComune + "</b>, i franchising immobiliari " + strNomeComune + " per te tra tutte le agenzie in città e provincia per ragione sociale, localit&agrave;. Se vuoi aprire un'agenzia immobiliare visita la nostra sezione dedicata</p><p align=\"justify\">Fra le agenzie di <b>" + strNomeComune + "</b></p>";
            strWHERENet = "Comuni_Ky=" + strComuni_Ky;
        }
        
        //Response.Write(strWHERENet);
        strFROMNet = "Utenti_AgenzieImmobiliari_Vw";
        strORDERNet = "Utenti_Tipocontratto DESC, UtentiGruppi_Ky DESC,Utenti_Nominativo";
        dtAgenzie = new DataTable("ElencoAgenzie");
        dtAgenzie = getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, intPage, intRecxPag, strConnNetRO);
        //------------------------------------------------------------------------------
        //paginazione
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

        strPagineSotto = "<nav aria-label=\"Pagination\"><ul class=\"pagination\">";
        //prima
        if ((intNumPagine > 1) && (intPage!=1))
        {
            strPagineSotto += "<li class=\"pagination-first\"><a href=\"/elenco-agenzie.aspx?Province_Ky=" + strProvince_Ky + "&Comuni_Ky=" + strProvince_Ky + "&page=1&chiave=" + strChiave + "\" rel=\"nofollow\">&lt;&lt; prima &nbsp;</a></li>";
        }
        //pagine
        for (i = intStartPag; i <= intEndPag; i++)
        {
            if (intPage == i)
            {
                strPagineSotto += "<li class=\"current\">&nbsp;" + i + "&nbsp;</li>";
            }
            else
            {
                strPagineSotto += "<li><a href=\"/elenco-agenzie.aspx?Province_Ky=" + strProvince_Ky + "&Comuni_Ky=" + strProvince_Ky + "&page=" + i + "&chiave=" + strChiave + "\" rel=\"nofollow\">" + i + "</a></li>";
            }
        }
        //ultima
        if ((intNumPagine > 1) && (intPage!=intNumPagine))
        {
          strPagineSotto += "<li class=\"pagination-last\"><a href=\"/elenco-agenzie.aspx?Province_Ky=" + strProvince_Ky + "&Comuni_Ky=" + strProvince_Ky + "&page=" + intNumPagine.ToString() + "&chiave=" + strChiave + "\" rel=\"nofollow\">ultima &gt;&gt;</a></li>";
        }
        strPagineSotto += "</ul></nav>";
        if ((intNumRecords > 0) && (intNumPagine>1))
        {
           this.PaginaSotto.Text = strPagineSotto;
        }
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
}
