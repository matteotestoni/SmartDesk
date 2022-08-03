using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Data.SqlClient;


  public partial class _Default : System.Web.UI.Page 
	{

    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    
    public string strAnagraficheServizi_Ky="";
    public string strDocumenti_Ky="";
    public DataTable dtDocumenti;
    public DataTable dtPagamenti;
    public string strAzione = "";
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public string strSQL="";

    protected void Page_Load(object sender, EventArgs e)
    {
      
      
	  
      if (Smartdesk.Login.Verify){
        aggiornaAnnuncio();
        aggiornaStato();
        Response.Redirect("/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&salvato=salvato&Documenti_Ky=" + strDocumenti_Ky);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
    
    public string dta2EN(string strData){
    string strReturn=strData;
      if(strReturn!=null && strReturn.Length==10){
      	strReturn=strReturn.Substring(3, 2) + "/" + strReturn.Substring(0, 2) + "/" + strReturn.Substring(6, 4);
      } 
      return strReturn;
    }

    public bool aggiornaAnnuncio()
    {
        string strSQL="gg";
        bool output = false;

        strAzione = Request["azione"];
        if ((strAzione==null) || (strAzione=="")){
          strAzione="new";
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");
        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
        SqlCommand cm = new SqlCommand();
        
        csSql sql = new csSql();
        sql.hrRequest = Request;     
        sql.Table = "Documenti";
        //Response.Write(strAzione);
        if (strAzione=="new"){
            sql.StringInsert("Documenti_Riferimenti", Request["Documenti_Riferimenti"]);
            sql.StringInsert("Documenti_Descrizione", Request["Documenti_Descrizione"]);
            sql.StringInsert("Documenti_Note", Request["Documenti_Note"]);
            sql.NumberInsert("Documenti_Numero");
            sql.NumberInsert("Commesse_Ky");
            sql.NumberInsert("DocumentiTipo_Ky");
            sql.NumberInsert("DocumentiStato_Ky");
            sql.NumberInsert("Anagrafiche_Ky");
            sql.NumberInsert("Aziende_Ky");
            sql.NumberInsert("Utenti_Ky");
            sql.NumberInsert("Negozi_Ky");
            sql.NumberInsert("Opportunita_Ky");
            sql.NumberInsert("Campagne_Ky");
            sql.StringInsert("Documenti_Data", dta2EN(Request["Documenti_Data"]));
            strSQL = sql.InsertCreate();
        }else{
            sql.StringUpdate("Documenti_Riferimenti", Request["Documenti_Riferimenti"]);
            sql.StringUpdate("Documenti_Descrizione", Request["Documenti_Descrizione"]);
            sql.StringUpdate("Documenti_Note", Request["Documenti_Note"]);
            sql.NumberUpdate("Documenti_Numero");
            sql.NumberUpdate("DocumentiTipo_Ky");
            sql.NumberUpdate("DocumentiStato_Ky");
            sql.NumberUpdate("Commesse_Ky");
            sql.NumberUpdate("Anagrafiche_Ky");
            sql.NumberUpdate("Aziende_Ky");
            sql.NumberUpdate("Utenti_Ky");
            sql.NumberUpdate("Negozi_Ky");
            sql.NumberUpdate("Opportunita_Ky");
            sql.NumberUpdate("Campagne_Ky");
            sql.StringUpdate("Documenti_Data", dta2EN(Request["Documenti_Data"]));
            strDocumenti_Ky=Smartdesk.Current.Request("Documenti_Ky");
            sql.WhereCreate("Documenti_Ky", strDocumenti_Ky);
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
        if (strAzione=="new"){
          strORDERNet = "Documenti_Ky DESC";
          strFROMNet = "Documenti";
          strWHERENet = "";
          dtDocumenti = new DataTable("Documenti");
          dtDocumenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          strDocumenti_Ky=dtDocumenti.Rows[0]["Documenti_Ky"].ToString();
         }
        if (Request["DocumentiTipo_Ky"]=="2"){
				strSQL="UPDATE Documenti SET "; 
		        strSQL+="Documenti_TotaleRighe=-Documenti_Totali_Vw.TotaleRighe,";
		        strSQL+="Documenti_TotaleIVA=-Documenti_Totali_Vw.TotaleIVA,";
		        strSQL+="Documenti_Totale=-(Documenti_Totali_Vw.TotaleRighe+Documenti_Totali_Vw.TotaleIVA)";
		        strSQL+=" FROM Documenti inner JOIN Documenti_Totali_Vw ON Documenti.Documenti_Ky=Documenti_Totali_Vw.Documenti_Ky";
		        strSQL+=" WHERE Documenti.Documenti_Ky=" + strDocumenti_Ky;
        }else{
				strSQL="UPDATE Documenti SET "; 
		        strSQL+="Documenti_TotaleRighe=Documenti_Totali_Vw.TotaleRighe,";
		        strSQL+="Documenti_TotaleIVA=Documenti_Totali_Vw.TotaleIVA,";
		        strSQL+="Documenti_Totale=Documenti_Totali_Vw.TotaleRighe+Documenti_Totali_Vw.TotaleIVA";
		        strSQL+=" FROM Documenti inner JOIN Documenti_Totali_Vw ON Documenti.Documenti_Ky=Documenti_Totali_Vw.Documenti_Ky";
		        strSQL+=" WHERE Documenti.Documenti_Ky=" + strDocumenti_Ky;
				}
        //Response.Write(strSQL);
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        cn.Close();
        return output;
    }

    public bool aggiornaStato()
    {
		SqlDataAdapter da = new SqlDataAdapter();
		DataTable dt = new DataTable("getTable");
		SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
		SqlCommand cm = new SqlCommand();
		
		strWHERENet="(Pagamenti_Pagato=0 Or Pagamenti_Pagato Is Null) And (Documenti_Ky=" + strDocumenti_Ky + ")";
		strORDERNet = "Pagamenti_Ky";
		strFROMNet = "Pagamenti";
		dtPagamenti = new DataTable("Pagamenti");
		dtPagamenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		if (dtPagamenti!=null && dtPagamenti.Rows.Count>0){
			strSQL = "UPDATE Documenti SET DocumentiStato_Ky=2 WHERE DocumentiTipo_Ky<>4 AND Documenti_Ky=" + strDocumenti_Ky;
		}else{
			strSQL = "UPDATE Documenti SET DocumentiStato_Ky=6 WHERE DocumentiTipo_Ky<>4 AND Documenti_Ky=" + strDocumenti_Ky;
		}
        cm.CommandText = strSQL;
        cm.CommandType = CommandType.Text;
        cm.Connection = cn;
        cm.CommandTimeout = 300;
        da.SelectCommand = cm;
        cn.Open();
		cm.ExecuteNonQuery();								
        return true;
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
}
