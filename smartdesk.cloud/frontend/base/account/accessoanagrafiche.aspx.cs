using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page 
{
    
    
    public bool boolLogin = false;
    public int intNumRecords = 0;
    public DataTable dtAnagrafiche;
    public string strAnagrafiche_Ky="";
    public string strAziende_Ky="";
    public string strEmail="";
    public string strPassword="";
    public string strErrore="";
    public string strHome="";
    public string strWHERENet="";
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    
    public string strReturnUrl="";
    public bool boolSSL = false;
   
    protected void Page_Load(object sender, EventArgs e){
        string strFROMNet = "";
        string strORDERNet = "";
        
      	boolSSL=Request.IsSecureConnection;
		System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
		
		
        strEmail=Request["email"];
        strPassword=Request["password"];
        strReturnUrl=Request["ReturnUrl"];
        if (strEmail!=null && strPassword!=null){
					strEmail=StripHTML(strEmail);
					strPassword=StripHTML(strPassword);
			        strORDERNet = "Anagrafiche_Ky";
			        strFROMNet = "Anagrafiche_Vw";
			        strWHERENet = "Anagrafiche_EmailContatti ='" + strEmail +"'";
			        dtAnagrafiche = new DataTable("Anagrafiche");
			        dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			        if (dtAnagrafiche.Rows.Count>0){
			          if (dtAnagrafiche.Rows[0]["Anagrafiche_Password"].ToString()==strPassword){
			            if (dtAnagrafiche.Rows[0]["Anagrafiche_Attivo"].Equals(true)){
			              boolLogin=true;
			              strAnagrafiche_Ky = dtAnagrafiche.Rows[0]["Anagrafiche_Ky"].ToString();
			              FormsAuthentication.SetAuthCookie(strAnagrafiche_Ky, true);
      							FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,"rswcrm-az",DateTime.Now,DateTime.Now.AddMinutes(600),true,dtAnagrafiche.Rows[0]["Anagrafiche_Ky"].ToString(),FormsAuthentication.FormsCookiePath);
      							string encryptedTicket = FormsAuthentication.Encrypt(ticket);
      							System.Web.HttpCookie authCookie = new System.Web.HttpCookie("rswcrm-az", encryptedTicket);
      							authCookie.Secure = opzioni.fSSL;
      							Response.Cookies.Add(authCookie);
      							//tracciamento
      							tracciaLogin(strAnagrafiche_Ky);
      							if (strReturnUrl!=null && strReturnUrl.Length>0){
      								Response.Redirect(strReturnUrl);
      							}else{
      								strHome="/account/area-personale.html";
      								Response.Redirect(strHome);
      							}
			            }else{
			              boolLogin=false;
			              strErrore="Utente non attivo";
			              Response.Redirect("/account/login.html?errore=nonattivo&ReturnUrl=" + strReturnUrl);
			            }
			          }else{
			            boolLogin=false;
			            strErrore="Password errata";
			            Response.Redirect("/account/login.html?errore=passworderrata&ReturnUrl=" + strReturnUrl);
			          }
			        }else{
			          boolLogin=false;
			          strErrore="Utente inesistente";
			          Response.Redirect("/account/login.html?errore=nessunutente&ReturnUrl=" + strReturnUrl);
			        }
			  }else{
			      strErrore="Email e password nulli";
		          boolLogin=false;
		          Response.Redirect("/account/login.html?errore=datinoninseriti&ReturnUrl=" + strReturnUrl);
				}
    }

    protected void tracciaLogin(string strAnagrafiche_Ky){
      string strSQL="";

	  //strCookie=strCookie.Replace("'","").Replace(",","");
	  SqlDataAdapter da = new SqlDataAdapter();
      DataTable dt = new DataTable("getTable");
      SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
      SqlCommand cm = new SqlCommand();
      strSQL = "INSERT INTO AnagraficheLog (Anagrafiche_Ky, AnagraficheLog_Data, AnagraficheLog_Descrizione) VALUES (" + strAnagrafiche_Ky + ",GETDATE(),'login')";
      //Response.Write(strSQL);
      cm.CommandText = strSQL;
      cm.CommandType = CommandType.Text;
      cm.Connection = cn;
      cm.CommandTimeout = 300;
      da.SelectCommand = cm;
      cn.Open();
      cm.ExecuteNonQuery();			
		}

		public static string StripHTML(string htmlString){
	    string strPattern;
	    string strReturn;
	    if (htmlString!=null){
				strPattern=@"<(.|\n)*?>";
				strReturn=Regex.Replace(htmlString, strPattern, string.Empty);
				return strReturn;
	    }else{
	     	return string.Empty;
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
