using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Linq;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;



public partial class _Default : System.Web.UI.Page{

    
    
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    
    public DataTable dtSitiWeb;
    public int intNumRecords = 0;
    
    public string strLog="";
    public string strAnagrafiche_Ky="";
		
	protected void Page_Load(object sender, EventArgs e){
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
      string strCSV="";

      
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
          strWHERENet=getWhere();
          strFROMNet = "Anagrafiche_GooglePlaces_Vw";
          strORDERNet = "Anagrafiche_RagioneSociale";
          dtSitiWeb = new DataTable("SitiWeb");
          dtSitiWeb = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  				strLog=dtSitiWeb.Rows.Count.ToString();
  				strLog+="<ul>";
					strCSV="Codice negozio,Nome,Riga indirizzo 1,Città,Regione,Paese,Codice postale,Telefono principale,Numero di telefono alternativo,Fax,Home page,Email,Orario di apertura,Categorie,Descrizione";
					strCSV+=Environment.NewLine;
					for (int i = 0; i < dtSitiWeb.Rows.Count; i++){
  					strCSV+=dtSitiWeb.Rows[i]["Anagrafiche_Ky"].ToString() + ",";
  					strCSV+="\"" + dtSitiWeb.Rows[i]["Anagrafiche_RagioneSociale"].ToString() + "\",";
						strCSV+="\"" + dtSitiWeb.Rows[i]["Anagrafiche_Indirizzo"].ToString() + "\",";
						strCSV+="\"" + dtSitiWeb.Rows[i]["Comuni_Comune"].ToString() + "\",";
  					strCSV+="\"" + dtSitiWeb.Rows[i]["Province_Provincia"].ToString() + "\",";
  					strCSV+="\"IT\",";
  					strCSV+="\"" + dtSitiWeb.Rows[i]["Anagrafiche_CAP"].ToString() + "\",";
  					strCSV+="\"" + dtSitiWeb.Rows[i]["Anagrafiche_Telefono"].ToString() + "\",";
  					strCSV+="\"" + dtSitiWeb.Rows[i]["Anagrafiche_FAX"].ToString() + "\",";
  					strCSV+="\"" + dtSitiWeb.Rows[i]["Anagrafiche_FAX"].ToString() + "\",";
  					strCSV+="\"" + dtSitiWeb.Rows[i]["Anagrafiche_SitoWeb"].ToString() + "\",";
  					strCSV+="\"" + dtSitiWeb.Rows[i]["Anagrafiche_EmailContatti"].ToString() + "\",";
  					strCSV+="\"2:08:00:19:00,3:08:00:19:00,4:08:00:19:00,5:08:00:19:00,6:08:00:19:00\",";
  					strCSV+="\"" + dtSitiWeb.Rows[i]["AnagraficheCategorie_Descrizione"].ToString() + "\",";
  					strCSV+="\"" + dtSitiWeb.Rows[i]["AnagraficheCategorie_Descrizione"].ToString() + "\"";
						strCSV+=Environment.NewLine;
  				}
  				Response.Write(strCSV);
          //Response.Redirect("/admin/view.aspx?CoreModules_Ky=27&CoreEntities_Ky=142&CoreGrids_Ky=126");
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    public string getWhere()
    {
        string strWHERE="";
        string strValue="";

        strWHERE="";
				strValue = Smartdesk.Current.Request("Anagrafiche_Ky");
        if (strValue != null && strValue != ""){
            strWHERE = "(Anagrafiche_Ky=" + strValue + ")";
        }
        strValue = Request["tutti"];
        if (strValue != null && strValue != ""){
            strWHERE = "";
        }
        return strWHERE;
    }

		public bool aggiornaBackLink(string strBackLink, string strSitiWeb_Ky, string strSitiWeb_Url)
    {
        string strSQL="";
        bool output = false;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");

       SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
        SqlCommand cm = new SqlCommand();
        
        strSQL = "UPDATE SitiWeb SET SitiWeb_BackLink='" + strBackLink + "' WHERE SitiWeb_Ky = " + strSitiWeb_Ky;
        cm.CommandText = strSQL;
        cm.CommandType = CommandType.Text;
        cm.Connection = cn;

        cm.CommandTimeout = 300;
        da.SelectCommand = cm;
        cn.Open();
        try
        {
            cm.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Exception err = new Exception("csLoadData->CreateXslInsUpdXls_In: " + ex.Message);
            throw err;
        }
				strSQL = "INSERT INTO SitiWebLog ([SitiWeb_Url],[SitiWebLog_Data],[SitiWebLog_Descrizione],[SitiWebLog_Valore]) VALUES ('" + strSitiWeb_Url + "' ,GETDATE() ,'Back Link' ,'" + strBackLink + "')";
				//Response.Write(strSQL);        
        cm.CommandText = strSQL;
        try
        {
            cm.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Exception err = new Exception("csLoadData->CreateXslInsUpdXls_In: " + ex.Message);
            throw err;
        }
        finally
        {
            cn.Close();
        }
        return output;
    }

    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}}