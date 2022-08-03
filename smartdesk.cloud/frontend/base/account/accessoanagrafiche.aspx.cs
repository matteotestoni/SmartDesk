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
      							authCookie.Secure = true;
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
}
