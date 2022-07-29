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
        string strUrlSource = "";
        string strUrlDestination = "";
        string[] strFolders;
        string strRequestRawUrl;
        string strPage;
        char[] splitter = { '/' };
        bool boolRewriteOrRedirect=false;

		    strUrlSource = _application.Request.Path;			
        strWHERENet="CoreUrlRedirect_UrlSource='" + strUrlSource + "'";
        strFROMNet = "CoreUrlRedirect";
        strORDERNet = "CoreUrlRedirect_Ky";
        dtCoreUrlRedirect = new DataTable("CoreUrlRedirect");
        dtCoreUrlRedirect = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreUrlRedirect_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out intNumRecords);
        if (dtCoreUrlRedirect.Rows.Count>0){
            strUrlDestination=dtCoreUrlRedirect.Rows[0]["CoreUrlRedirect_UrlDestination"].ToString();
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
                strUrlDestination = strUrlDestination + "&" + _application.Context.Request.QueryString.ToString();
            }
            _application.Context.RewritePath(strUrlDestination);
            boolRewriteOrRedirect=true;
        }

        //nessun redirect impostato ma calcolato
        if (boolRewriteOrRedirect==false){
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
                        strUrlDestination="/frontend/base/annunci/scheda-annuncio.aspx?Annunci_Ky=" + strPage;
                        //_application.Context.Response.Write(strUrlDestination);
                        _application.Context.RewritePath(strUrlDestination);
                    }
                    if (strFolders[1].ToString().ToLower() == "immobile")
                    {
                        strPage = _application.Request.Url.Segments[_application.Request.Url.Segments.Length-1];
                        strPage = strPage.Substring(0, strPage.LastIndexOf(".html"));
                        strUrlDestination="/frontend/base/immobili/scheda-immobile.aspx?Immobili_Ky=" + strPage;
                        //_application.Context.Response.Write(strUrlDestination);
                        _application.Context.RewritePath(strUrlDestination);
                    }
                    if (strFolders[1].ToString().ToLower() == "asta")
                    {
                        strPage = _application.Request.Url.Segments[_application.Request.Url.Segments.Length-1];
                        strPage = strPage.Substring(0, strPage.LastIndexOf(".html"));
                        strUrlDestination="/frontend/base/aste/scheda-asta.aspx?Aste_Ky=" + strPage;
                        //_application.Context.Response.Write(strUrlDestination);
                        _application.Context.RewritePath(strUrlDestination);
                    }
                    if (strFolders[1].ToString().ToLower() == "prodotto")
                    {
                        strPage = _application.Request.Url.Segments[_application.Request.Url.Segments.Length-1];
                        strPage = strPage.Substring(0, strPage.LastIndexOf(".html"));
                        strUrlDestination="/frontend/base/catalogo/scheda-prodotto.aspx?Prodotti_Ky=" + strPage;
                        //_application.Context.Response.Write(strUrlDestination);
                        _application.Context.RewritePath(strUrlDestination);
                    }
                    if (strFolders[1].ToString().ToLower() == "veicolo")
                    {
                        strPage = _application.Request.Url.Segments[_application.Request.Url.Segments.Length-1];
                        strPage = strPage.Substring(0, strPage.LastIndexOf(".html"));
                        strUrlDestination="/frontend/base/veicoli/scheda-auto.aspx?Veicoli_Ky=" + strPage;
                        //_application.Context.Response.Write(strUrlDestination);
                        _application.Context.RewritePath(strUrlDestination);
                    }
                } 
            }
        }
    } 
    
  }
}
