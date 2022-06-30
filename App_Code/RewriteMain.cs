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
        dtCoreUrlRedirect = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreUrlRedirect_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly);
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
        dtCoreUrlRewrite = Smartdesk.Sql.getTablePage(strFROMNet, null, strKey, strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly);
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
              string msg = "<br>Table: " + table + "<br>Tableout:" + tableout + "<br>Where:" + where + "<br>Orderby:" + orderby;
              Exception err = new Exception("csLoadData->getTablePage: " + ex.Message + msg);
              throw err;
          }
          finally
          {
              cn.Close();
          }
          System.Data.IDataParameter[] id;
          id = da.GetFillParameters();
          return dt;
      }
  }
}
