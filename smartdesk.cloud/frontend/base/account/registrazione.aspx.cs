using System;
using System.Data;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolLogin = false;
    public bool boolAdmin = false;
    public string strUtentiLogin="";
    public bool boolSSL = false;
    public string strUrl="";
    public string strErrore="";
    
    public string strUtenti_Ky="";
    public string strAziende_Ky="";
    public string strReturnUrl="";
    public string strHome="";
    public string strH1="Registrazione";
    public DataTable dtAsteCategorie;
    public DataTable dtAnnunciCategorie;
    public DataTable dtNazioni;
    public DataTable dtProvince;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";

      boolSSL=Request.IsSecureConnection;
	  System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
      
      strErrore=Request["errore"];
      strReturnUrl=Request["ReturnUrl"];
	  	
      if (Request.Cookies["rswcrm-az"] != null){
          strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
          strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
            boolLogin=true;
			Response.Redirect("/area-personale.aspx");
          }else{
            strLogin="<li><a href=\"/account/login.html\" class=\"text-primary\"><i class=\"fa-duotone fa-fw fa-user\"></i> <span class=\"menu-label\">accedi</span></a></li><li><a href=\"/registrazione.aspx\" class=\"text-secondary\"><i class=\"fa-duotone fa-fw fa-user-plus\"></i> <span class=\"menu-label\">registrati</span></a></li>";
            boolLogin=false;
          }
      }else{
        strLogin="<li><a href=\"/account/login.html\" class=\"text-primary\"><i class=\"fa-duotone fa-fw fa-user\"></i> <span class=\"menu-label\">accedi</span></a></li><li><a href=\"/registrazione.aspx\" class=\"text-secondary\"><i class=\"fa-duotone fa-fw fa-user-plus\"></i> <span class=\"menu-label\">registrati</span></a></li>";
        boolLogin=false;
      }

      strWHERENet = "AnnunciCategorie_Padre=0";
      dtAnnunciCategorie = new DataTable("AnnunciCategorie");
      dtAnnunciCategorie = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Ordine, AnnunciCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

	  strWHERENet = "";
      dtAsteCategorie = new DataTable("AsteCategorie");
      dtAsteCategorie = Smartdesk.Sql.getTablePage("AsteCategorie", null, "AsteCategorie_Ky", strWHERENet, "AsteCategorie_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

	  strWHERENet = "";
      dtNazioni = new DataTable("Nazioni");
      dtNazioni = Smartdesk.Sql.getTablePage("Nazioni", null, "Nazioni_Ky", strWHERENet, "Nazioni_Ky", 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

	  strWHERENet = "";
      dtProvince = new DataTable("Province");
      dtProvince = Smartdesk.Sql.getTablePage("Province", null, "Province_Ky", strWHERENet, "Province_Ky", 1, 200,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App)
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}
