using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page 
{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public string strAnagrafiche_Ky="";
    public DataTable dtFormsFields;
    public DataTable dtFormsValori;
    public DataTable dtFormsFieldsConteggio;
    public DataTable dtFormsAvanzamento;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strAzione = "";
    public string strForms_Ky = "";
    public string strCampo = "";
    public string strValore = "";
    public string strRisposta = "";
    public decimal decPercCompilato = 0;
    public string strFormsFields_Ky = "";
    public int intMeta;
    public decimal decMeta;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strWHERENet="";
      string strORDERNet = "";

	  
	  
      strAnagrafiche_Ky=(FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-cliente"].Value)).UserData;
	  if (strAnagrafiche_Ky!=null){
          strWHERENet = "Anagrafiche_Ky =" + strAnagrafiche_Ky;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
	        strForms_Ky=Smartdesk.Current.Request("Forms_Ky");
	        strCampo=Request["campo"];
	        strValore=Request["valore"];

 			strWHERENet="Forms_Ky=" + strForms_Ky + " And FormsFields_Codice='" + strCampo + "'";
			//Response.Write(strWHERENet);
			strORDERNet = "FormsFields_Ky";
			strFROMNet = "FormsFields";
			dtFormsFields = new DataTable("FormsFields");
			dtFormsFields = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsFields_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            strFormsFields_Ky= dtFormsFields.Rows[0]["FormsFields_Ky"].ToString();


			strWHERENet="Forms_Ky=" + strForms_Ky + " And Anagrafiche_Ky=" +strAnagrafiche_Ky + " And FormsFields_Codice='" + strCampo + "'";
			//Response.Write(strWHERENet);
			strORDERNet = "FormsValori_Ky";
			strFROMNet = "FormsValori";
			dtFormsValori = new DataTable("FormsValori");
			dtFormsValori = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsValori_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			if  (dtFormsValori.Rows.Count>0){
           	 	strSQL = "UPDATE FormsValori SET FormsValori_Valore='" + strValore + "', FormsFields_Ky=" + strFormsFields_Ky + " WHERE (Anagrafiche_Ky=" + strAnagrafiche_Ky + " And Forms_Ky=" + strForms_Ky + " And FormsFields_Codice='" + strCampo + "')";
			}else{
				strSQL = "INSERT INTO FormsValori ([FormsFields_Ky] ,[FormsValori_Valore]  ,[Anagrafiche_Ky] ,[Forms_Ky] ,[FormsFields_Codice])";
				strSQL += " VALUES (" + strFormsFields_Ky + ", '" + strValore + "', " + strAnagrafiche_Ky + ", " + strForms_Ky + ", '" + strCampo + "')";				
			}
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable("getTable");
           	SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
            SqlCommand cm = new SqlCommand();
            cm.CommandText = strSQL;
            cm.CommandType = CommandType.Text;
            cm.Connection = cn;
            cm.CommandTimeout = 300;
            da.SelectCommand = cm;
            cn.Open();
            try{
				cm.ExecuteNonQuery();
				strRisposta="ok";
	        }catch (Exception ex){
	        	strRisposta=ex.Message;
	    	}
           
			strWHERENet="Forms_Ky=" + strForms_Ky + " And Anagrafiche_Ky=" + strAnagrafiche_Ky;
			strORDERNet = "FormsValori_Ky";
			strFROMNet = "FormsValori";
			dtFormsValori = new DataTable("FormsValori");
			dtFormsValori = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsValori_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
				
			strWHERENet="Forms_Ky=" + strForms_Ky + " And FormsFieldsTipo_Ky<>5 And FormsFieldsTipo_Ky<>6";
			strORDERNet = "FormsFields_Ky";
			strFROMNet = "FormsFields";
			dtFormsFieldsConteggio = new DataTable("FormsFieldsConteggio");
			dtFormsFieldsConteggio = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsFields_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            decPercCompilato=dtFormsValori.Rows.Count*100/dtFormsFieldsConteggio.Rows.Count;
            
        	decMeta=dtFormsFieldsConteggio.Rows.Count/2;
			intMeta=(int)Math.Round(decMeta);
			if (dtFormsValori.Rows.Count==1 || dtFormsValori.Rows.Count==dtFormsFieldsConteggio.Rows.Count ||  dtFormsValori.Rows.Count==intMeta+1){
				strWHERENet="Forms_Ky=" + strForms_Ky + " And FormsAvanzamento_Stato=2 And FormsAvanzamento_Valore=" + decPercCompilato;
				strORDERNet = "FormsAvanzamento_Ky";
				strFROMNet = "FormsAvanzamento";
				dtFormsAvanzamento = new DataTable("FormsAvanzamento");
				dtFormsAvanzamento = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsAvanzamento_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
	            if (dtFormsAvanzamento.Rows.Count<1){
	            	aggiornaAvanzamento();
				}
            }
      		Response.Clear();
      		Response.Write(strSQL + "-" + strRisposta);
			Response.End();

          }else{
            Response.Redirect(".." + Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(".." + Smartdesk.Current.LoginPageRoot);
      }
    }    

    public bool aggiornaAvanzamento()
    {
        string strSQL="";
        bool output = false;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");

        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
        SqlCommand cm = new SqlCommand();
		strSQL = "INSERT INTO FormsAvanzamento (Forms_Ky, Anagrafiche_Ky,FormsAvanzamento_Data, FormsAvanzamento_Descrizione, FormsAvanzamento_Stato, FormsAvanzamento_Valore)";
        strSQL += " VALUES (" + strForms_Ky + "," + strAnagrafiche_Ky + ", GETDATE(), 'Compilazione al " + decPercCompilato + "%', 2," + decPercCompilato + ")";
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

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App) //#bp
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}
