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
        strComuni_Ky= Request["Comuni_Ky"];
        if (strComuni_Ky!=null && strComuni_Ky.Length>0){
          strWHERENet="Comuni_Ky=" + strComuni_Ky;
          strFROMNet = "Comuni";
          strORDERNet = "Comuni_Ky";
          dtComune = new DataTable("Comuni");
          dtComune = Smartdesk.Sql.getTablePage(strFROMNet, null, "Comuni_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtComune.Rows.Count>0){
            strNomeProvincia=dtComune.Rows[0]["Comuni_Comune"].ToString().ToLower();
            strNomeProvinciaHTML=dtComune.Rows[0]["Comuni_ComuneHTML"].ToString().ToLower();
            strMetaDescription="Valutazione casa a " + strNomeProvincia + ". Se vuoi una valutazone per la tua nuova casa contatta gli esperti di casecasa.it";;
            strH1="Valutazione casa " + strNomeProvincia;
            strP1="Valuta la tua casa e scopri grazie a degli esperti il reale valore di mercato";
            strTitle="Valutazione casa " + strNomeProvincia;
            strFondo="Scoprire il reale valore di mercato di una casa non è mai stato così semplice!";
          }else{
            strMetaDescription="Valutazione casa";;
            strH1="Valutazione casa";
            strP1="Valuta la tua casa e scopri grazie a degli esperti il reale valore di mercato";
            strTitle="Valutazione casa";
            strFondo="Scoprire il reale valore di mercato di una casa non è mai stato così semplice!";
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
            strMetaDescription="Valutazione casa a " + strNomeProvincia;
            strH1="Valutazione casa " + strNomeProvincia;
            strP1="Valuta la tua casa e scopri grazie a degli esperti il reale valore di mercato";
            strTitle="Valutazione casa " + strNomeProvincia;
            strFondo="Scoprire il reale valore di mercato di una casa non è mai stato così semplice!";
          }else{
            strMetaDescription="Valutazione casa";;
            strH1="Valutazione casa";
            strP1="Valuta la tua casa e scopri grazie a degli esperti il reale valore di mercato";
            strTitle="Valutazione casa";
            strFondo="Scoprire il reale valore di mercato di una casa non è mai stato così semplice!";
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
