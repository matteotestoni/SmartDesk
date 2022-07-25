using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Text;
using System.IO;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strSQL = "";
    public string strWHERE = "";
    public string strAnnunci_Ky = "";
    public string strAsteEsperimenti_Ky="";
    
    public int intNumRecords = 0;
    public DataTable dtAnnuncio;
    public DataTable dtAnnunciOfferte;
    public DataTable dtAsteEsperimenti;
    public decimal decValoreAttuale = 0;
    public decimal decValoreOffertaMinima = 0;
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolLogin = false;
    public string strUtentiLogin="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strFROMNet = "";
      string strWHERENet = "";
      string strORDERNet = "";

      if (Request.Cookies["rswcrm-az"] != null){
          
          strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
          strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
              
              int intNum =0;
              Response.Cache.SetCacheability(HttpCacheability.NoCache);
      
              strAnnunci_Ky = Smartdesk.Current.QueryString("Annunci_Ky");
              strWHERENet = "Annunci_Ky=" + strAnnunci_Ky;
              dtAnnuncio = new DataTable("Annuncio");
              dtAnnuncio = Smartdesk.Sql.getTablePage("Annunci_Vw", null, "Annunci_Ky", strWHERENet, "Annunci_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
       
              strAsteEsperimenti_Ky = Smartdesk.Current.QueryString("AsteEsperimenti_Ky");
              if (strAsteEsperimenti_Ky.Length>0){
                strWHERENet = "AsteEsperimenti_Ky=" + strAsteEsperimenti_Ky;
                dtAsteEsperimenti = new DataTable("AsteEsperimenti");
                dtAsteEsperimenti = Smartdesk.Sql.getTablePage("AsteEsperimenti_Vw", null, "AsteEsperimenti_Ky", strWHERENet, "AsteEsperimenti_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              }
             
              strWHERENet = "Annunci_Ky=" + strAnnunci_Ky + " AND AsteEsperimenti_Ky=" + strAsteEsperimenti_Ky;
              strORDERNet="AnnunciOfferte_Ky DESC";
              dtAnnunciOfferte = new DataTable("AnnunciOfferte");
              dtAnnunciOfferte = Smartdesk.Sql.getTablePage("AnnunciOfferte_Vw", null, "AnnunciOfferte_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtAnnunciOfferte.Rows.Count>0){
                decValoreAttuale=((decimal)dtAnnunciOfferte.Rows[0]["AnnunciOfferte_Valore"]);
                decValoreOffertaMinima=((decimal)dtAnnunciOfferte.Rows[0]["AnnunciOfferte_Valore"])+((decimal)dtAnnuncio.Rows[0]["Annunci_Rilancio"]);
                Response.Clear();
          	    Response.ContentType = "application/json";
          	    TextWriter objX = new StreamWriter(Response.OutputStream, Encoding.UTF8);
      	  	    objX.WriteLine("{\"valoreattuale\":[");
      		    objX.WriteLine("{");
                objX.WriteLine("\"id\" : \"" + dtAnnuncio.Rows[0]["Annunci_Ky"].ToString() + "\",");
                objX.WriteLine("\"vincitore\" : \"" + dtAnnunciOfferte.Rows[0]["Anagrafiche_Ky"].ToString() + "\",");
                objX.WriteLine("\"idofferta\" : \"" + dtAnnunciOfferte.Rows[0]["AnnunciOfferte_Ky"].ToString() + "\",");
	            if (strAsteEsperimenti_Ky.Length>0 && dtAsteEsperimenti.Rows.Count>0){
                	objX.WriteLine("\"datascadenzaasta\" : \"" + Convert.ToDateTime(dtAsteEsperimenti.Rows[0]["AsteEsperimenti_DataTermine"]).ToString("M/d/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":") + "\",");
                }else{
                	objX.WriteLine("\"datascadenzaasta\" : \"31/12/2019 00:00:00\",");
				}
                objX.WriteLine("\"numeroofferte\" : \"" + dtAnnunciOfferte.Rows.Count + "\",");
                objX.WriteLine("\"valoreattuale\" : \"" + decValoreAttuale.ToString("N0", ci).Replace(",0000","") + "\",");
                objX.WriteLine("\"valoreoffertaminima\" : \"" + decValoreOffertaMinima.ToString("N0", ci).Replace(",0000","") + "\"");
                objX.WriteLine("}");
            	objX.WriteLine("]");
      		    objX.WriteLine("}");
            	objX.Flush();
            	objX.Close();
            	Response.End();
            }else{
                decValoreAttuale=((decimal)dtAnnuncio.Rows[0]["Annunci_Valore"]);
                decValoreOffertaMinima=((decimal)dtAnnuncio.Rows[0]["Annunci_Valore"])+((decimal)dtAnnuncio.Rows[0]["Annunci_Rilancio"]);
                Response.Clear();
          	    Response.ContentType = "application/json";
          	    TextWriter objX = new StreamWriter(Response.OutputStream, Encoding.UTF8);
      	  	    objX.WriteLine("{\"valoreattuale\":[");
      		    objX.WriteLine("{");
                objX.WriteLine("\"id\" : \"" + dtAnnuncio.Rows[0]["Annunci_Ky"].ToString() + "\",");
                objX.WriteLine("\"vincitore\" : \"0\",");
                objX.WriteLine("\"idofferta\" : \"0\",");
	            if (strAsteEsperimenti_Ky.Length>0){
                	objX.WriteLine("\"datascadenzaasta\" : \"" + Convert.ToDateTime(dtAsteEsperimenti.Rows[0]["AsteEsperimenti_DataTermine"]).ToString("M/d/yyyy HH:mm",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":") + "\",");
                }else{
                	objX.WriteLine("\"datascadenzaasta\" : \"31/12/2019 00:00\",");
				}
                objX.WriteLine("\"numeroofferte\" : \"0\",");
                objX.WriteLine("\"valoreattuale\" : \"" + decValoreAttuale.ToString("N0", ci).Replace(",0000","") + "\",");
                objX.WriteLine("\"valoreoffertaminima\" : \"" + decValoreOffertaMinima.ToString("N0", ci).Replace(",0000","") + "\"");
                objX.WriteLine("}");
            	objX.WriteLine("]");
      		    objX.WriteLine("}");
            	objX.Flush();
            	objX.Close();
            	Response.End();
            }
         }
      }
    }

    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
