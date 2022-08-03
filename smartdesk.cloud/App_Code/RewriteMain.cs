using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace RewriteMain.NET
{

    public class RewriteMain : IHttpModule {
    private HttpApplication _application = null;
    public int intNumRecords = 0;

    public void Init(HttpApplication context) {
       context.BeginRequest += new System.EventHandler(RewriteMain_BeginRequest);
      _application = context;
    }
    
    public void Dispose() {
      throw new Exception("Metodo o operazione non implementata");
    }

    public void RewriteMain_BeginRequest(object sender, System.EventArgs args) {		
        string strWHERENet="";
        string strFROMNet = "";
        string strORDERNet = "";
        string strKey = "";
        DataTable dtCoreUrlRewrite;
        DataTable dtCoreUrlRedirect;
        DataTable dtCoreModulesOptionsValue;
        string strUrlSource = "";
        string strUrlDestination = "";
        string[] strFolders;
        string strRequestRawUrl;
        string strPage;
        char[] splitter = { '/' };
        bool boolRewriteOrRedirect=false;
        string strTheme="base";

		    strUrlSource = _application.Request.Path;
        Uri uriUrl = new Uri(_application.Request.Url.ToString()); 
        
        /*
        _application.Context.Response.Write("1:" + _application.Context.Request.Url.Host + "<br>");
        _application.Context.Response.Write("2:" + _application.Request.Path + "<br>");
        _application.Context.Response.Write("3" + _application.Request.Url.ToString() + "<br>");
        _application.Context.Response.Write("4:" + _application.Request.RawUrl + "<br>");
        _application.Context.Response.Write("5:" + _application.Request.QueryString + "<br>");
        */

        strWHERENet="CoreUrlRedirect_UrlSource='" + strUrlSource + "'";
        strFROMNet = "CoreUrlRedirect";
        strORDERNet = "CoreUrlRedirect_Ky";
        dtCoreUrlRedirect = new DataTable("CoreUrlRedirect");
        dtCoreUrlRedirect = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreUrlRedirect_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out intNumRecords);
        if (dtCoreUrlRedirect.Rows.Count>0){
            strUrlDestination=dtCoreUrlRedirect.Rows[0]["CoreUrlRedirect_UrlDestination"].ToString() + "";
            if (_application.Request.QueryString.ToString().Length>0){
              if (strUrlDestination.IndexOf("?")>0){
                strUrlDestination+="&" +_application.Request.QueryString.ToString();
              }else{
                strUrlDestination+="?" +_application.Request.QueryString.ToString();
              }
            }
            _application.Context.Response.RedirectPermanent(strUrlDestination);
            boolRewriteOrRedirect=true;
        }   

        dtCoreUrlRewrite = new DataTable("CoreUrlRewrite");
        strKey = "CoreUrlRewrite_Ky";
        strORDERNet = "CoreUrlRewrite_Ky";
    		strFROMNet = "CoreUrlRewrite";
    		strWHERENet = "CoreUrlRewrite_UrlSource='" + strUrlSource + "'";
        dtCoreUrlRewrite = Smartdesk.Sql.getTablePage(strFROMNet, null, strKey, strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out intNumRecords);
        if (dtCoreUrlRewrite.Rows.Count > 0){
            strUrlDestination = dtCoreUrlRewrite.Rows[0]["CoreUrlRewrite_UrlDestination"].ToString();
            if (_application.Context.Request.QueryString.ToString().Length>0){
                if (strUrlDestination.IndexOf("?")>0){
                  strUrlDestination+="&" +_application.Request.QueryString.ToString();
                }else{
                  strUrlDestination+="?" +_application.Request.QueryString.ToString();
                }
            }
            _application.Context.RewritePath(strUrlDestination);
            boolRewriteOrRedirect=true;
        }

        //nessun redirect impostato ma calcolato
        if (boolRewriteOrRedirect==false){
        
            dtCoreModulesOptionsValue = new DataTable("Options");
            strWHERENet="CoreModulesOptions_Code='design'";
            strORDERNet = "CoreModulesOptionsValue_Ky";
            strFROMNet = "CoreModulesOptionsValue";
            dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtCoreModulesOptionsValue.Rows.Count>0){
              strTheme=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
            }else{
              strTheme="base";
            }        
        
            strRequestRawUrl = _application.Request.RawUrl.ToString();
            if (strRequestRawUrl.Length > 1)
            {
                strFolders = strRequestRawUrl.Split(splitter);
                if (strFolders.Length > 0)
                {
                    //_application.Context.Response.Write(strFolders[1].ToString().ToLower());
                    if (strFolders[1].ToString().ToLower() == "annuncio")
                    {
                        strPage = _application.Request.Url.Segments[_application.Request.Url.Segments.Length-1];
                        strPage = strPage.Substring(0, strPage.LastIndexOf(".html"));
                        strUrlDestination="/frontend/" + strTheme + "/annunci/scheda-annuncio.aspx?Annunci_Ky=" + strPage;
                        //_application.Context.Response.Write(strUrlDestination);
                        _application.Context.RewritePath(strUrlDestination);
                    }
                    if (strFolders[1].ToString().ToLower() == "immobile")
                    {
                        strPage = _application.Request.Url.Segments[_application.Request.Url.Segments.Length-1];
                        strPage = strPage.Substring(0, strPage.LastIndexOf(".html"));
                        strUrlDestination="/frontend/" + strTheme + "/immobili/scheda-immobile.aspx?Immobili_Ky=" + strPage;
                        //_application.Context.Response.Write(strUrlDestination);
                        _application.Context.RewritePath(strUrlDestination);
                    }
                    if (strFolders[1].ToString().ToLower() == "cantiere")
                    {
                        strPage = _application.Request.Url.Segments[_application.Request.Url.Segments.Length-1];
                        strPage = strPage.Substring(0, strPage.LastIndexOf(".html"));
                        strUrlDestination="/frontend/" + strTheme + "/immobili/scheda-cantiere.aspx?Cantieri_Ky=" + strPage;
                        //_application.Context.Response.Write(strUrlDestination);
                        _application.Context.RewritePath(strUrlDestination);
                    }
                    if (strFolders[1].ToString().ToLower() == "asta")
                    {
                        strPage = _application.Request.Url.Segments[_application.Request.Url.Segments.Length-1];
                        strPage = strPage.Substring(0, strPage.LastIndexOf(".html"));
                        strUrlDestination="/frontend/" + strTheme + "/aste/scheda-asta.aspx?Aste_Ky=" + strPage;
                        //_application.Context.Response.Write(strUrlDestination);
                        _application.Context.RewritePath(strUrlDestination);
                    }
                    if (strFolders[1].ToString().ToLower() == "prodotto")
                    {
                        strPage = _application.Request.Url.Segments[_application.Request.Url.Segments.Length-1];
                        strPage = strPage.Substring(0, strPage.LastIndexOf(".html"));
                        strUrlDestination="/frontend/" + strTheme + "/catalogo/scheda-prodotto.aspx?Prodotti_Ky=" + strPage;
                        //_application.Context.Response.Write(strUrlDestination);
                        _application.Context.RewritePath(strUrlDestination);
                    }
                    if (strFolders[1].ToString().ToLower() == "produttore")
                    {
                        strPage = _application.Request.Url.Segments[_application.Request.Url.Segments.Length-1];
                        strPage = strPage.Substring(0, strPage.LastIndexOf(".html"));
                        strUrlDestination="/frontend/" + strTheme + "/catalogo/scheda-produttore.aspx?Produttori_Ky=" + strPage;
                        //_application.Context.Response.Write(strUrlDestination);
                        _application.Context.RewritePath(strUrlDestination);
                    }
                    if (strFolders[1].ToString().ToLower() == "servizio")
                    {
                        strPage = _application.Request.Url.Segments[_application.Request.Url.Segments.Length-1];
                        strPage = strPage.Substring(0, strPage.LastIndexOf(".html"));
                        strUrlDestination="/frontend/" + strTheme + "/catalogo/scheda-servizio.aspx?Prodotti_Ky=" + strPage;
                        //_application.Context.Response.Write(strUrlDestination);
                        _application.Context.RewritePath(strUrlDestination);
                    }
                    if (strFolders[1].ToString().ToLower() == "veicolo")
                    {
                        strPage = _application.Request.Url.Segments[_application.Request.Url.Segments.Length-1];
                        strPage = strPage.Substring(0, strPage.LastIndexOf(".html"));
                        strUrlDestination="/frontend/" + strTheme + "/veicoli/scheda-auto.aspx?Veicoli_Ky=" + strPage;
                        //_application.Context.Response.Write(strUrlDestination);
                        _application.Context.RewritePath(strUrlDestination);
                    }
                    if (strFolders[1].ToString().ToLower() == "pag")
                    {
                        strPage = _application.Request.Url.Segments[_application.Request.Url.Segments.Length-1];
                        strPage = strPage.Substring(0, strPage.LastIndexOf(".html"));
                        strUrlDestination="/frontend/" + strTheme + "/contenuti/scheda-contenuti.aspx?Veicoli_Ky=" + strPage;
                        //_application.Context.Response.Write(strUrlDestination);
                        _application.Context.RewritePath(strUrlDestination);
                    }
                } 
            }
        }
    } 
    
  }
}
