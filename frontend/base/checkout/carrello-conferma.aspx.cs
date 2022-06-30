using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Xml;

public partial class _Default : System.Web.UI.Page 
{
    public string strConnNet = "";
    public int intNumRecords = 0;
    public int intNumRecordsCategorie = 0;
    public int intNumRecordsCarrello = 0;
    public int intNumRecordsSpedizioni = 0;
    public int intNumRecordsPagamenti = 0;
    public int i = 0;
    public DataTable dtCategorie;
    public DataTable dtCarrello;
    public DataTable dtAnagrafiche;
    public bool boolLogin = false;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public double dblSubtotale = 0;
    public double dblTotiva = 0;
    public double dblTotiva4 = 0;
    public double dblTotiva10 = 0;
    public double dblTotiva22 = 0;
    public double dblTotimponibile = 0;
    public double dblTotimponibile4 = 0;
    public double dblTotimponibile10 = 0;
    public double dblTotimponibile22 = 0;
    public double dblTotcomplessivo = 0;
    public DataTable dtSpedizioni;
    public DataTable dtPagamentiMetodo;
    public int intAnagraficheCategorie_Ky = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";
        
      if (Request.Cookies["ecommercersw1"]!=null && Request.Cookies["ecommercersw1"].Value!=null && Request.Cookies["ecommercersw1"].Value!=""){
        boolLogin=true;
        intAnagraficheCategorie_Ky=Convert.ToInt32(Request.Cookies["ecommercersw3"].Value);
        strConnNet = ConfigurationManager.ConnectionStrings["ecommercero.net"].ConnectionString;
        strFROMNet = "ProdottiCategorie";
        strORDERNet = "ProdottiCategorie_Descrizione";
        strWHERENet="ProdottiCategorie_Padre=0";
        dtCategorie = new DataTable("Categorie");
        dtCategorie = Smartdesk.Sql.getTablePage(strFROMNet, null, "ProdottiCategorie_Ky", strWHERENet, strORDERNet, 1, 99, strConnNet);
        intNumRecordsCategorie=intNumRecords;
        //anagrafica
        strFROMNet = "Anagrafiche_Vw";
        strORDERNet = "Anagrafiche_Ky";
        strWHERENet="Anagrafiche_Ky =" + Request.Cookies["ecommercersw2"].Value.ToString();
        dtAnagrafiche = new DataTable("Anagrafiche");
        dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1, strConnNet);
        //spedizioni
        strFROMNet = "Spedizioni";
        strORDERNet = "Spedizioni_Descrizione";
        strWHERENet="";
        dtSpedizioni = new DataTable("Spedizioni");
        dtSpedizioni = Smartdesk.Sql.getTablePage(strFROMNet, null, "Spedizioni_Ky", strWHERENet, strORDERNet, 1, 99, strConnNet);
        intNumRecordsSpedizioni=intNumRecords;
        //pagamenti
        strFROMNet = "PagamentiMetodo";
        strORDERNet = "PagamentiMetodo_Descrizione";
        strWHERENet="";
        dtPagamentiMetodo = new DataTable("PagamentiMetodo");
        dtPagamentiMetodo = Smartdesk.Sql.getTablePage(strFROMNet, null, "PagamentiMetodo_Ky", strWHERENet, strORDERNet, 1, 99, strConnNet);
        intNumRecordsPagamenti=intNumRecords;
        //carrello
        strFROMNet = "Carrello_Vw";
        strORDERNet = "Carrello_Ky";
        strWHERENet="Anagrafiche_Ky=" + Request.Cookies["ecommercersw2"].Value.ToString();
        dtCarrello = new DataTable("Carrello");
        dtCarrello = Smartdesk.Sql.getTablePage(strFROMNet, null, "Carrello_Ky", strWHERENet, strORDERNet, 1, 999, strConnNet);
        intNumRecordsCarrello=intNumRecords;
      }else{
        Response.Redirect("/necessaria-registrazione.aspx");      
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
