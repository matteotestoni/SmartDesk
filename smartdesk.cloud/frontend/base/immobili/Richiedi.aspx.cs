using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public string strMetaDescription = "";
    public string strH1 = "";
    public string strP1 = "";
    public string strTitle = "";
    public string strFondo = "";
    public string strNomeProvincia="";
    public string strNomeProvinciaHTML="";
    public string strComuniLink="";
    public string strProvinciaLink="";
    public string strMetaRobots="index,follow";
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
        string strProvince_Ky="";
        string strComuni_Ky="";
        int i = 0;
        string strWHERENet="";
        string strFROMNet = "";
        string strORDERNet = "";
        DataTable dtProvincia;
        DataTable dtComune;
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
        System.IO.StringWriter sw;
    
    	  
    	  
        strProvince_Ky= Request["Province_Ky"];
        strComuni_Ky=Request["Comuni_Ky"];
        if (strComuni_Ky!=null && strComuni_Ky.Length>0){
          strWHERENet="Comuni_Ky=" + strComuni_Ky;
          strFROMNet = "Comuni";
          strORDERNet = "Comuni_Ky";
          dtComune = new DataTable("Comuni");
          dtComune = Smartdesk.Sql.getTablePage(strFROMNet, null, "Comuni_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtComune.Rows.Count>0){
            strNomeProvincia=dtComune.Rows[0]["Comuni_Comune"].ToString().ToLower();
            strNomeProvinciaHTML=dtComune.Rows[0]["Comuni_ComuneHTML"].ToString().ToLower();
            strMetaDescription="Richiedi casa alle agenzie immobiliari di " + strNomeProvincia + ". Se stai cercando la tua nuova casa contatta gli esperti di casecasa.it";;
            strH1="Richiedi casa " + strNomeProvincia;
            strP1="Richiedi casa e scopri grazie a degli esperti il reale valore di mercato";
            strTitle="Richiedi casa " + strNomeProvincia;
            strFondo="Richiedi casa alle agenzie immobiliari di " + strNomeProvincia;
          }else{
            strMetaDescription="Richiedi casa";;
            strH1="Richiedi casa con agenzia immobiliare";
            strP1="Richiedi la tua nuova casa online";
            strTitle="Richiedi casa con agenzia immobiliare";
            strFondo="Richiedi casa con agenzia immobiliare non è mai stato così semplice!";
          }
        }else{
          if (strProvince_Ky!=null && strProvince_Ky.Length>0){
            strWHERENet="Province_Ky=" + strProvince_Ky;
            strFROMNet = "Province";
            strORDERNet = "Province_Ky";
            dtProvincia = new DataTable("Province");
            dtProvincia = Smartdesk.Sql.getTablePage(strFROMNet, null, "Province_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            strNomeProvincia=dtProvincia.Rows[0]["Province_Provincia"].ToString().ToLower();
            strNomeProvinciaHTML=dtProvincia.Rows[0]["Province_ProvinciaHTML"].ToString().ToLower();
            strMetaDescription="Trovare casa con agenzia immobiliare a  " + strNomeProvincia;
            strH1="Trovare casa con agenzia immobiliare a  " + strNomeProvincia;
            strP1="Valuta la tua casa e scopri grazie a degli esperti il reale valore di mercato";
            strTitle="Valutazione casa " + strNomeProvincia;
            strFondo="Scoprire il reale valore di mercato di una casa non è mai stato così semplice!";
          }else{
            strMetaDescription="Valutazione casa";;
            strH1="Trovare casa con agenzia immobiliare";
            strP1="Trova la tua nuova casa online";
            strTitle="Trovare casa con agenzia immobiliare";
            strFondo="Trovare casa con agenzia immobiliare non è mai stato così semplice!";
          }       
        }
    }
}
