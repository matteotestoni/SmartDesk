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
}
