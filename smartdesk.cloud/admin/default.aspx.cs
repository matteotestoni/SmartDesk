using System;
using System.Data;
public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false; 
    public DataTable dtPagamentiScaduti;
    public DataTable dtPagamentiFuturi;
    public DataTable dtPagamentiDaFare;
    public DataTable dtAttivita;
    public DataTable dtAttivitaCommerciali;
    public DataTable dtAnagraficheServizi;
    public DataTable dtFormsAvanzamento;
    public int intAnagrafiche_Ky = 0;
    public decimal decTot=0; 
    public decimal decTotMese=0; 
    public int intAnno = 0;
    public int intMese = 0;
    public string strColor="";
    public DateTime dt;
    public int intPersone_Ky = 0;
    
    public string strActive=" is-active";

    protected void Page_Load(object sender, EventArgs e)
    {   
    if (Context.Request.Cookies["rswcrm"]!=null){
		  
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            switch (dtLogin.Rows[0]["Utenti_Home"].ToString()){
				case "1":
					Response.Redirect("/admin/home.aspx");
					break;
				case "2":
					Response.Redirect("calendario.aspx");
					break;
				case "3":
					Response.Redirect("/admin/app/anagrafiche/elenco-anagrafiche.aspx?AnagraficheTipo_Ky=1");
					break;
				default:
					Response.Redirect("/admin/home.aspx");
					break;
			}
       }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    protected void tracciaLogin(string strUtenti_Ky)
    {
        string strSQL = "";
        string strIP = "";
        string strCookie = "";
        string strUserAgent = "";

        strIP = Request.ServerVariables["REMOTE_ADDR"];
        strUserAgent = Request.ServerVariables["HTTP_USER_AGENT"];
        strCookie = Request.ServerVariables["HTTP_COOKIE"];

        strSQL = "INSERT INTO UtentiLog (Utenti_Ky, UtentiLog_IP, UtentiLog_UserAgent, UtentiLog_Cookie, UtentiLog_Data, UtentiLog_UserInsert,UtentiLog_DateInsert) VALUES (" + strUtenti_Ky + ", '" + strIP + "', '" + strUserAgent + "', '" + strCookie + "' ,GETDATE()," + strUtenti_Ky + ",GETDATE())";
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
    }
}
