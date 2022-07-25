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
    public string strMetaRobots="index,follow";
    public string strH1 = "";
    public string strP1 = "";
    public string strTitle = "";
    public int i = 0;
    public int intNumRecords = 0;
    public DataTable dtUtente;
    public string strImmobili_Ky="";
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    private string strInviato = "";
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
        string strWHERENet="";
        string strFROMNet = "";
        string strORDERNet = "";
        string strImmobili_Ky="";
    
    	  
    	  
        strImmobili_Ky= Request["Utenti_Ky"];
        strInviato= Request["inviato"];
        strWHERENet="Utenti_Ky=" + strImmobili_Ky;
        strFROMNet = "Utenti_Vw";
        strORDERNet = "Utenti_Ky";
        dtUtente = new DataTable("agenzia");
        dtUtente = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtUtente.Rows.Count>0){
          strTitle=dtUtente.Rows[0]["Utenti_Nominativo"].ToString();
          if (dtUtente.Rows[0]["Comuni_Comune"].ToString().Length>0){
            strTitle+=" a " + dtUtente.Rows[0]["Comuni_Comune"].ToString();
          }
          strMetaKeywords=strTitle;
          if ((dtUtente.Rows[0]["Province_Provincia"].ToString().Length>0) && !(dtUtente.Rows[0]["Province_Provincia"].Equals(dtUtente.Rows[0]["Comuni_Comune"]))){
            strTitle+=" in provincia di " + dtUtente.Rows[0]["Province_Provincia"].ToString();
          }
          if (dtUtente.Rows[0]["Utenti_Indirizzo"].ToString().Length>0){
            strTitle+=" " + dtUtente.Rows[0]["Utenti_Indirizzo"].ToString();
          }
          strH1=strTitle;
          strMetaDescription = strTitle;
        }else{
          Response.RedirectPermanent("/");
        }        
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
      dtUtente.Dispose();
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
