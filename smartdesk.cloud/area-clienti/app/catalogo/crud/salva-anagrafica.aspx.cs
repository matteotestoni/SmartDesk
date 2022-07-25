using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{

    public string strConnNet = "";
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin; 
    public string strAnagraficheServizi_Ky="";
    public string strAnagrafiche_Ky="";
    public DataTable dtAnagrafiche;
    public string strAzione = "";
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public string strFoto = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      strConnNet = Smartdesk.Config.Sql.ConnectionReadOnly;
      if(Request.Cookies["rswcrm-cliente"] != null)
      {
        strWHERENet = "Anagrafiche_Ky =" + Smartdesk.Session.CurrentUser.ToString();
        strORDERNet = "Anagrafiche_Ky";
        strFROMNet = "Anagrafiche";
        dtLogin = new DataTable("Login");
        dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1, strConnNet);
        if (dtLogin.Rows.Count>0){
          aggiornaAnnuncio();
          caricafiles();
          Response.Redirect("/area-clienti/profilo.aspx");
        }else{
          Response.Redirect("/area-clienti/Default.aspx");
        }
      }else{
        Response.Redirect("/area-clienti/Default.aspx");
      }
    }


    public void caricafiles()
    {
      string strFileName;
      string [ ] myFiles = Request.Files.AllKeys;
      if (myFiles.Length>0){
            for ( int i = 0; i < myFiles.Length; i++ ) {
              if (Request.Files[i].FileName !=""){
                strFileName=Server.MapPath("../uploads/foto-anagrafiche/" + strAnagrafiche_Ky + ".jpg");
                Request.Files.Get(i).SaveAs(strFileName);
                strFoto="/uploads/foto-anagrafiche/" + strAnagrafiche_Ky + ".jpg";
                aggiornaFoto();
              }      
            }
      }
    }

    public bool aggiornaFoto()
    {
        string strSQL="";
        bool output = false;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");

        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
        SqlCommand cm = new SqlCommand();
        strSQL = "UPDATE Anagrafiche SET  Anagrafiche_Logo='" + strFoto + "' WHERE Anagrafiche_Ky = " + strAnagrafiche_Ky;
        Response.Write(strSQL);
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
        finally
        {
            cn.Close();
        }
        return output;
    }

    public bool aggiornaAnnuncio()
    {
        string strSQL="gg";
        string strValue="";
        bool output = false;

        strAzione=Smartdesk.Current.Request("azione");
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");
        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
        SqlCommand cm = new SqlCommand();
        csSql sql = new csSql();
        sql.hrRequest = Request;     
        sql.Table = "Anagrafiche";
        if (strAzione=="new"){
            sql.StringInsert("Anagrafiche_RagioneSociale", Request["Anagrafiche_RagioneSociale"]);
            sql.StringInsert("Anagrafiche_Indirizzo", Request["Anagrafiche_Indirizzo"]);
            sql.StringInsert("Anagrafiche_Comune", Request["Anagrafiche_Comune"]);
            sql.StringInsert("Anagrafiche_Provincia", Request["Anagrafiche_Provincia"]);
            sql.StringInsert("Anagrafiche_Telefono", Request["Anagrafiche_Telefono"]);
            sql.StringInsert("Anagrafiche_PartitaIVA", Request["Anagrafiche_PartitaIVA"]);
            sql.StringInsert("Anagrafiche_CodiceFiscale", Request["Anagrafiche_CodiceFiscale"]);
            sql.StringInsert("Anagrafiche_FAX", Request["Anagrafiche_FAX"]);
            sql.StringInsert("Anagrafiche_EmailContatti", Request["Anagrafiche_EmailContatti"]);
            sql.StringInsert("Anagrafiche_EmailAmministrazione", Request["Anagrafiche_EmailAmministrazione"]);
            sql.StringInsert("Anagrafiche_Password", Request["Anagrafiche_Password"]);
            sql.StringInsert("Anagrafiche_SitoWeb", Request["Anagrafiche_SitoWeb"]);
            strSQL = sql.InsertCreate();
        }else{
            strValue=Request["Anagrafiche_RagioneSociale"];
            sql.StringUpdate("Anagrafiche_RagioneSociale", strValue);
            strValue=Request["Anagrafiche_Indirizzo"];
            sql.StringUpdate("Anagrafiche_Indirizzo", strValue);
            strValue=Request["Anagrafiche_Comune"];
            sql.StringUpdate("Anagrafiche_Comune", strValue);
            strValue=Request["Anagrafiche_Provincia"];
            sql.StringUpdate("Anagrafiche_Provincia", strValue);
            strValue=Request["Anagrafiche_Telefono"];
            sql.StringUpdate("Anagrafiche_Telefono", strValue);            
            strValue=Request["Anagrafiche_FAX"].Replace("'","''");
            sql.StringUpdate("Anagrafiche_FAX", strValue);           
            strValue=Request["Anagrafiche_PartitaIVA"];
            sql.StringUpdate("Anagrafiche_PartitaIVA", strValue);           
            strValue=Request["Anagrafiche_CodiceFiscale"];
            sql.StringUpdate("Anagrafiche_CodiceFiscale", strValue);            
            strValue=Request["Anagrafiche_EmailContatti"];
            sql.StringUpdate("Anagrafiche_EmailContatti", strValue);            
            strValue=Request["Anagrafiche_EmailAmministrazione"];
            sql.StringUpdate("Anagrafiche_EmailAmministrazione", strValue);
            strValue=Request["Anagrafiche_Password"];
            sql.StringUpdate("Anagrafiche_Password", strValue);
            strValue=Request["Anagrafiche_SitoWeb"];
            sql.StringUpdate("Anagrafiche_SitoWeb", strValue);            
            strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
            sql.WhereCreate("Anagrafiche_Ky", strAnagrafiche_Ky);
            strSQL = sql.UpdateCreate();
        }
        //Response.Write(strSQL);
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
        finally
        {
            cn.Close();
        }

        if (strAzione=="new"){
          strORDERNet = "Anagrafiche_Ky DESC";
          strFROMNet = "Anagrafiche";
          strWHERENet = "";
          dtAnagrafiche = new DataTable("Anagrafiche");
          dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1, strConnNet);
          strAnagrafiche_Ky=dtAnagrafiche.Rows[0]["Anagrafiche_Ky"].ToString();
         }
        return output;
    }

    public string FnNum(object o)
    {
        string ret = "null";

        if (o != null)
        {
            if (o.ToString()== "")
            {
                ret = "null";
            }
            else
            {
                ret = o.ToString().Replace(",", ".");
            }
        }
        return ret;
    }

    public string FnText(object o)
    {

        string ret = "";

        if (o != null)
        {
            if (o.ToString() == "")
            {
                ret = "null";
            }
            else
            {
                ret = "'"+o.ToString().Replace("'", "''")+"'";
            }
        }

        return ret;
    }

        public string FnCheck(object o)
    {
        string ret = "null";

        if (o != null)
        {
            ret = (o.ToString() == "on") ? "1" : "0";

        }
        return ret;
    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App) //#bp
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }

}
