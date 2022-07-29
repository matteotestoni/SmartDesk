using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false; 
    public string strPagamenti_Ky="";
    public string strAnagrafiche_Ky="";
    public string strSpese_Ky="";
    public DataTable dtPagamenti;
    public string strDocumenti_Ky="";
    public string strAzione = "";
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public string strSorgente="";
    public string strSQL="";

    protected void Page_Load(object sender, EventArgs e)
    {
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());        
          strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
          strSpese_Ky=Smartdesk.Current.Request("Spese_Ky");
          strDocumenti_Ky=Smartdesk.Current.Request("Documenti_Ky");
          Dictionary<string, object> frm = new Dictionary<string, object>();
          if (Smartdesk.Current.Request("Pagamenti_Pagato") == "") frm.Add("Pagamenti_Pagato", false);
          strSorgente=Smartdesk.Current.Request("sorgente");
          
          //strKy = Smartdesk.Functions.SqlWriteKey("Pagamenti", frm);
          aggiornaAnnuncio();
          aggiornaStato();
          //Response.Write("ci sono:" + strSorgente);
		  		switch (strSorgente){
            case "scheda-anagrafiche":
              Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreForms_Ky=145&salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky);
              break;
            case "scheda-documenti":
              Response.Redirect("/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&salvato=salvato&Documenti_Ky=" + strDocumenti_Ky + "&Anagrafiche_Ky=" + strAnagrafiche_Ky);
              break;
            case "scheda-spese":
              Response.Redirect("/admin/app/amministrazione/scheda-spese.aspx?CoreModules_Ky=2&CoreEntities_Ky=1&CoreForms_Ky=211&salvato=salvato&Spese_Ky=" + strSpese_Ky + "&Anagrafiche_Ky=" + strAnagrafiche_Ky);
              break;
            case "elenco-pagamenti":
              Response.Redirect("/admin/view.aspx?CoreModules_Ky=21&CoreEntities_Ky=75&CoreGrids_Ky=233");
              break;
           default:
              Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky);
              break;
          }
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
        string strValue="";
        bool output = false;
        strAzione=Smartdesk.Current.Request("azione");
        //Response.Write(strAzione);
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");
        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
        SqlCommand cm = new SqlCommand();
        
        csSql sql = new csSql();
        sql.hrRequest = Request;     
        sql.Table = "Pagamenti";
        if (strAzione=="new"){
            strValue=Request["Pagamenti_Riferimenti"].Replace("'","''");
            sql.StringInsert("Pagamenti_Riferimenti", strValue);
            strValue=dta2EN(Request["Pagamenti_Data"]).Replace("'","''");
            sql.StringInsert("Pagamenti_Data", strValue);
            strValue=Request["Pagamenti_DataPagato"];
            if (strValue!=null && strValue.Length>0){
				strValue=dta2EN(Request["Pagamenti_DataPagato"]).Replace("'","''");
	            sql.StringInsert("Pagamenti_DataPagato", strValue);
            }
            sql.NumberInsert("Pagamenti_Importo");
            sql.NumberInsert("Anagrafiche_Ky");
            strValue=Smartdesk.Current.Request("Spese_Ky");
            if (strValue!=null && strValue.Length>0){
            	sql.NumberInsert("Spese_Ky");
            }
            strValue=Smartdesk.Current.Request("Documenti_Ky");
            if (strValue!=null && strValue.Length>0){
				sql.NumberInsert("Documenti_Ky");
            }
            strValue=Smartdesk.Current.Request("Commesse_Ky");
            if (strValue!=null && strValue.Length>0){
            	sql.NumberInsert("Commesse_Ky");
            }
            sql.NumberInsert("PagamentiTipo_Ky");
            sql.NumberInsert("Conti_Ky");
            sql.NumberInsert("PagamentiMetodo_Ky");
            sql.CheckInsert("Pagamenti_Pagato");
            strSQL = sql.InsertCreate();
        }else{
            strValue=Request["Pagamenti_Riferimenti"].Replace("'","''");
            sql.StringUpdate("Pagamenti_Riferimenti", strValue);
            strValue=dta2EN(Request["Pagamenti_Data"]).Replace("'","''");
            sql.StringUpdate("Pagamenti_Data", strValue);
            strValue=Request["Pagamenti_DataPagato"];
            if (strValue!=null && strValue.Length>0){
	            strValue=dta2EN(Request["Pagamenti_DataPagato"]).Replace("'","''");
	            sql.StringUpdate("Pagamenti_DataPagato", strValue);
            }
            sql.NumberUpdate("Pagamenti_Importo");
            sql.NumberUpdate("Anagrafiche_Ky");
            strValue=Smartdesk.Current.Request("Spese_Ky");
            if (strValue!=null && strValue.Length>0){
            	sql.NumberUpdate("Spese_Ky");
            }
            strValue=Smartdesk.Current.Request("Documenti_Ky");
            if (strValue!=null && strValue.Length>0){
            	sql.NumberUpdate("Documenti_Ky");
            }
            strValue=Smartdesk.Current.Request("Commesse_Ky");
            if (strValue!=null && strValue.Length>0){
            	sql.NumberUpdate("Commesse_Ky");
            }
            sql.NumberUpdate("PagamentiTipo_Ky");
            sql.NumberUpdate("Conti_Ky");
            sql.NumberUpdate("PagamentiMetodo_Ky");
            sql.CheckUpdate("Pagamenti_Pagato");
            strPagamenti_Ky=Smartdesk.Current.Request("Pagamenti_Ky");
            sql.WhereCreate("Pagamenti_Ky", strPagamenti_Ky);
            strSQL = sql.UpdateCreate();
        }
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
        if (strAzione=="new"){
          strORDERNet = "Pagamenti_Ky DESC";
          strFROMNet = "Pagamenti";
          strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky;
          dtPagamenti = new DataTable("Pagamenti");
          dtPagamenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          strAnagrafiche_Ky=dtPagamenti.Rows[0]["Anagrafiche_Ky"].ToString();
         }
        return output;
    }

    public bool aggiornaStato()
    {
		SqlDataAdapter da = new SqlDataAdapter();
		DataTable dt = new DataTable("getTable");
		SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
		SqlCommand cm = new SqlCommand();
		
		if (strDocumenti_Ky!=null && strDocumenti_Ky.Length>0){
					strWHERENet="(Pagamenti_Pagato=0 Or Pagamenti_Pagato Is Null) And (Documenti_Ky=" + strDocumenti_Ky + ")";
					strORDERNet = "Pagamenti_Ky";
					strFROMNet = "Pagamenti";
					dtPagamenti = new DataTable("Pagamenti");
					dtPagamenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
					if (dtPagamenti!=null && dtPagamenti.Rows.Count>0){
						strSQL = "UPDATE Documenti SET DocumentiStato_Ky=2 WHERE Documenti_Ky=" + strDocumenti_Ky;
					}else{
						strSQL = "UPDATE Documenti SET DocumentiStato_Ky=6 WHERE Documenti_Ky=" + strDocumenti_Ky;
					}
	        cm.CommandText = strSQL;
	        cm.CommandType = CommandType.Text;
	        cm.Connection = cn;
	        cm.CommandTimeout = 300;
	        da.SelectCommand = cm;
	        cn.Open();
					cm.ExecuteNonQuery();								
    }
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
     
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
