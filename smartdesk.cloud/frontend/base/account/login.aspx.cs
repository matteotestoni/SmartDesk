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
    public bool boolLogin = false;
    public string strUtentiLogin="";
    public bool boolSSL = false;
    public string strUrl="";
    
    public string strUtenti_Ky="";
    public string strReturnUrl="";
    public string strMessaggio="";
    public string strErrore = "";
    public string strH1 = "Accedi";
    public DataTable dtAsteCategorie;
    public DataTable dtAnnunciCategorie;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";

      boolSSL=Request.IsSecureConnection;
	  System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
      
      strErrore=Request["errore"];
      strMessaggio = Request["messaggio"];
      strReturnUrl =Request["ReturnUrl"];
      boolLogin=false;
	  	
      switch (strErrore){
        case "utentepresente":
            strErrore="L'indirizzo email digitato non &egrave; presente nel nostro archivio.";
            break;
        case "nonattivo":
            strErrore="Il tuo profilo non &egrave; stato attivato.";
            break;
        case "passworderrata":
            strErrore="La password inserita non &egrave; corretta.";
            break;
        case "nessunutente":
            strErrore="L'indirizzo email digitato non &egrave; presente nel nostro archivio.";
            break;
        case "datinoninseriti":
            strErrore="Non hai inserito i dati per l'accesso.";
            break;
     }
      if (Request.Cookies["rswcrm-az"] != null){
          strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
          strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
            boolLogin=true;
			Response.Redirect("/account/area-personale.html");
          }else{
            boolLogin=false;
          }
      }else{
        boolLogin=false;
      }
  
      strWHERENet = "AnnunciCategorie_Padre=0";
      dtAnnunciCategorie = new DataTable("AnnunciCategorie");
      dtAnnunciCategorie = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Ordine, AnnunciCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

	  strWHERENet = "";
      dtAsteCategorie = new DataTable("AsteCategorie");
      dtAsteCategorie = Smartdesk.Sql.getTablePage("AsteCategorie", null, "AsteCategorie_Ky", strWHERENet, "AsteCategorie_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    }    
}
