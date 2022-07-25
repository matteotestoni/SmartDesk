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
    public string strH1="Partecipa all'asta";
    public DataTable dtAsteCategorie;
    public DataTable dtAnnunciCategorie;
    public DataTable dtNazioni;
    public DataTable dtProvince;
    public DataTable dtAsteEsperimenti;
    public DataTable dtAste;
    public string strAzione = "";
    public string strAste_Ky="";
    public string strAsteEsperimenti_Ky="";
    public string strAnnunci_Ky="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";

      boolSSL=Request.IsSecureConnection;
	    System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
      
      strErrore=Request["errore"];
      strReturnUrl=Request["ReturnUrl"];
      strAste_Ky=Request["Aste_Ky"];
      strAsteEsperimenti_Ky=Request["AsteEsperimenti_Ky"];
      strAnnunci_Ky=Request["Annunci_Ky"];
	  	
      if (Request.Cookies["rswcrm-az"] != null){
          strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
          strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
            boolLogin=true;
            strLogin="<a href=\"/account/area-personale.html\" class=\"login\"><i class=\"fa-duotone fa-envelope fa-fw\"></i>" + dtLogin.Rows[0]["Anagrafiche_EmailContatti"].ToString() + "</a> | <a href=\"/logoutanagrafiche.aspx\" class=\"login\"><i class=\"fa-duotone fa-user-times fa-fw\"></i>Esci</a>";
            
            
            dtAste = new DataTable("Aste");
            strWHERENet = "Aste_Ky=" + strAste_Ky;
            dtAste = Smartdesk.Sql.getTablePage("Aste_Vw", null, "Aste_Ky", strWHERENet, "Aste_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
            dtAsteEsperimenti = new DataTable("AsteEsperimenti");
            strWHERENet = "AsteEsperimenti_Ky=" + strAsteEsperimenti_Ky;
            dtAsteEsperimenti = Smartdesk.Sql.getTablePage("AsteEsperimenti_Vw", null, "AsteEsperimenti_Ky", strWHERENet, "AsteEsperimenti_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              
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

            
          }else{
			      Response.Redirect("/account/login.html?returnUrl=/frontend/base/aste/scheda-asta.aspx?Annunci_Ky=" + strAnnunci_Ky);
            strLogin="<a href=\"/account/login.html\"><i class=\"fa-duotone fa-key fa-lg fa-fw\"></i>Accedi</a> | <a href=\"/registrazione.aspx\"><i class=\"fa-duotone fa-user-shield fa-lg fa-fw\"></i>Registrati</a>";
            boolLogin=false;
          }
      }else{
		Response.Redirect("/account/login.html?returnUrl=/frontend/base/aste/scheda-asta.aspx?AsteEsperimenti_Ky=" + strAsteEsperimenti_Ky + "&Aste_Ky=" + strAste_Ky);
        strLogin="<a href=\"/account/login.html\"><i class=\"fa-duotone fa-key fa-lg fa-fw\"></i>Accedi</a> | <a href=\"/registrazione.aspx\"><i class=\"fa-duotone fa-user-shield fa-lg fa-fw\"></i>Registrati</a>";
        boolLogin=false;
      }

    }

    public String GetDefaultValue(string strField)
    {
        string strValore = "";
        switch (strField)
        {
            case "Annunci_Titolo":
                strValore = "";
                break;
        }
        return strValore;
    }

    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore= GetDefaultValue(strField);
        }
        else{
        strValore=dtTabella.Rows[0][strField].ToString();
      }
      return strValore;

    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App)
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}
