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
    public string strDocumentiCorpo_Ky="";
    public string strAnagrafiche_Ky="";
    public string strDocumenti_Ky="";
    public DataTable dtDocumentiCorpo;
    public string strAzione = "";
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public string strKy = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());        
          strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
          strDocumenti_Ky=Smartdesk.Current.Request("Documenti_Ky");
          strDocumentiCorpo_Ky=Smartdesk.Current.Request("DocumentiCorpo_Ky");
		  //strKy = Smartdesk.Functions.SqlWriteKey("DocumentiCorpo");
          aggiornaAttributi();
          aggiornaAnnuncio();
          Response.Redirect("/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&salvato=salvato&Documenti_Ky=" + strDocumenti_Ky + "&DocumentiCorpo_Ky=" + strDocumentiCorpo_Ky);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
		
	public bool aggiornaAttributi()
    {
        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
        cn.Open();
        SqlCommand cmd = new SqlCommand("checkColumnExists", cn);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        
		//aggiungo gli attributi se mancano
		foreach (String key in Request.Form)
		{
		    if (key.Substring(0,5)=="attr-"){
	  			cmd.Parameters.Clear();
				cmd.Parameters.Add(new SqlParameter("@table", "DocumentiCorpo"));
				cmd.Parameters.Add(new SqlParameter("@field", key));
	  			cmd.ExecuteNonQuery();
			}
		}

		//salvo gli attributi
		/*
		strSQL="";
		foreach (String key in Request.Form)
		{
		    if (key.Substring(0,5)=="attr-"){
      			if (strSQL.Length>0){
				  strSQL+=", [" + key + "]='" + Request.Form[key] + "'";
				}else{
				  strSQL+="[" + key + "]='" + Request.Form[key] + "'";
				}
			}
		}
		strSQL="UPDATE DocumentiCorpo SET " + strSQL + " WHERE DocumentiCorpo_Ky=" + strKy;
        Response.Write(strSQL);
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
		*/
		//chiudo la connessione
        if (cn != null)
        {
            cn.Close();
        }
			return true;
	}

    public bool aggiornaAnnuncio()
    {
        string strSQL="gg";
        string strDescrizione="";
        bool output = false;
        string strField="";

        strAzione = Request["azione"];
        //Response.Write(strAzione);
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");
        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
        SqlCommand cm = new SqlCommand();
        
        csSql sql = new csSql();
        sql.hrRequest = Request;     
        sql.Table = "DocumentiCorpo";
        strDescrizione=Request["DocumentiCorpo_Descrizione"];
        strDescrizione=strDescrizione.Replace("'","''");
        //Response.Write(Request["DocumentiCorpo_Descrizione"]);
		if (strAzione=="new"){
            sql.NumberInsert("DocumentiCorpo_Qta");
            sql.NumberInsert("DocumentiCorpo_Importo");
            sql.NumberInsert("DocumentiCorpo_ImportoTagliato");
            sql.NumberInsert("DocumentiCorpo_Totale");
            sql.NumberInsert("DocumentiCorpo_TotaleIVA");
            sql.StringInsert("DocumentiCorpo_Titolo", Request["DocumentiCorpo_Titolo"]);
            sql.StringInsert("DocumentiCorpo_Descrizione", strDescrizione);
            sql.NumberInsert("Documenti_Ky");
            sql.NumberInsert("AttributiGruppi_Ky");
            sql.NumberInsert("AliquoteIVA_Ky");
            sql.NumberInsert("Servizi_Ky");
            sql.NumberInsert("Prodotti_Ky");
            sql.NumberInsert("CentridiCR_Ky");
            sql.NumberInsert("AliquoteIVA_Aliquota");
			//attributi
			foreach (String key in Request.Form)
			{
			    if (key.Substring(0,5)=="attr-"){
        		strField="[" + key + "]";
				if (strAzione=="new"){
            		sql.StringInsert(strField, Request.Form[key]);
					Response.Write("Key: " + strField + " Value: " + Request.Form[key] + "<br>");
				}else{
            		sql.StringUpdate(strField, Request.Form[key]);
				}
				}
			}

            strSQL = sql.InsertCreate();
        }else{
            sql.NumberUpdate("DocumentiCorpo_Qta");
            sql.NumberUpdate("DocumentiCorpo_Importo");
            sql.NumberUpdate("DocumentiCorpo_ImportoTagliato");
            sql.NumberUpdate("DocumentiCorpo_Totale");
            sql.NumberUpdate("DocumentiCorpo_TotaleIVA");
            sql.StringUpdate("DocumentiCorpo_Titolo", Request["DocumentiCorpo_Titolo"]);
            sql.StringUpdate("DocumentiCorpo_Descrizione", strDescrizione);
            sql.NumberUpdate("Documenti_Ky");
            sql.NumberUpdate("AttributiGruppi_Ky");
            sql.NumberUpdate("AliquoteIVA_Ky");
            sql.NumberUpdate("Servizi_Ky");
            sql.NumberUpdate("Prodotti_Ky");
            sql.NumberUpdate("CentridiCR_Ky");
            sql.NumberUpdate("AliquoteIVA_Aliquota");
            strDocumentiCorpo_Ky=Smartdesk.Current.Request("DocumentiCorpo_Ky");
			//attributi
			foreach (String key in Request.Form)
			{
			    if (key.Substring(0,5)=="attr-"){
        		strField="[" + key + "]";
				if (strAzione=="new"){
            		sql.StringInsert(strField, Request.Form[key]);
					Response.Write("Key: " + strField + " Value: " + Request.Form[key] + "<br>");
				}else{
            		sql.StringUpdate(strField, Request.Form[key]);
				}
				}
			}
            sql.WhereCreate("DocumentiCorpo_Ky", strDocumentiCorpo_Ky);
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
          strORDERNet = "DocumentiCorpo_Ky DESC";
          strFROMNet = "DocumentiCorpo";
          strWHERENet = "";
          dtDocumentiCorpo = new DataTable("DocumentiCorpo");
          dtDocumentiCorpo = Smartdesk.Sql.getTablePage(strFROMNet, null, "DocumentiCorpo_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          strDocumentiCorpo_Ky = dtDocumentiCorpo.Rows[0]["DocumentiCorpo_Ky"].ToString();
         }
        strSQL="UPDATE Documenti SET "; 
        strSQL+="Documenti_TotaleRighe=Documenti_Totali_Vw.TotaleRighe,";
        strSQL+="Documenti_TotaleIVA=Documenti_Totali_Vw.TotaleIVA,";
        strSQL+="Documenti_Totale=Documenti_Totali_Vw.TotaleRighe+Documenti_Totali_Vw.TotaleIVA";
        strSQL+=" FROM Documenti inner JOIN Documenti_Totali_Vw ON Documenti.Documenti_Ky=Documenti_Totali_Vw.Documenti_Ky";
        strSQL+=" WHERE Documenti.Documenti_Ky=" + strDocumenti_Ky;
        //Response.Write(strSQL);
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        cn.Close();
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

     
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
