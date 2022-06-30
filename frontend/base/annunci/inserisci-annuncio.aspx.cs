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
    public string strH1="Inserisci il tuo annuncio in autonomia";
    public DataTable dtAnnunciCategorie;
    public DataTable dtNazioni;
    public DataTable dtProvince;
    public DataTable dtAnnunci;
    public DataTable dtAnagraficheServizi;
    public string strAzione = "";
    public DataTable dtAttributi;
    public DataTable dtAttributiOpzioni;
    public string strWHERENet="";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public string strRequired = "";
    public string strClass = "";
    public string strPlaceholder = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      boolSSL=Request.IsSecureConnection;
	  System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
      
      strErrore=Request["errore"];
      strReturnUrl=Request["ReturnUrl"];
	  	
      if (Request.Cookies["rswcrm-az"] != null){
          strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
          strWHERENet = "Anagrafiche_Ky=" + strUtentiLogin;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche_Vw";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
            boolLogin=true;
            strLogin="<li><a href=\"/account/area-personale.html\" class=\"login\"><i class=\"fa-duotone fa-envelope fa-fw\"></i>Il mio profilo</a></li><li><a href=\"/logoutanagrafiche.aspx\" class=\"login\"><i class=\"fa-duotone fa-user-times fa-fw\"></i>Esci</a></li>";
            dtAnnunci = new DataTable("Annunci");
            strWHERENet = "AnnunciTipo_Ky=1 AND Anagrafiche_Ky=" + strUtentiLogin;
            dtAnnunci = new DataTable("Annunci");
            dtAnnunci = Smartdesk.Sql.getTablePage("Annunci", null, "Annunci_Ky", strWHERENet, "Annunci_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            /*
			if (dtAnnunci.Rows.Count>0){
              //controllo l'abbonamento
              strWHERENet = "Servizi_MaxAnnunci>" + dtAnnunci.Rows.Count + " AND Anagrafiche_Ky=" + strUtentiLogin + " AND AnagraficheServizi_Inizio<=GETDATE() AND AnagraficheServizi_Termine>=GETDATE()";
              dtAnagraficheServizi = new DataTable("AnagraficheServizi");
              dtAnagraficheServizi = Smartdesk.Sql.getTablePage("AnagraficheServizi_Vw", null, "AnagraficheServizi_Ky", strWHERENet, "AnagraficheServizi_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtAnagraficheServizi.Rows.Count<1 && dtAnnunci.Rows.Count>4){
	           Response.Redirect("/abbonamento.aspx");
              }  
            }
			*/
            strWHERENet = "AnnunciCategorie_Padre=0";
            dtAnnunciCategorie = new DataTable("AnnunciCategorie");
            dtAnnunciCategorie = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

      	    strWHERENet = "";
            dtNazioni = new DataTable("Nazioni");
            dtNazioni = Smartdesk.Sql.getTablePage("Nazioni", null, "Nazioni_Ky", strWHERENet, "Nazioni_Ky", 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      
      	    strWHERENet = "";
            dtProvince = new DataTable("Province");
            dtProvince = Smartdesk.Sql.getTablePage("Province", null, "Province_Ky", strWHERENet, "Province_Ky", 1, 200,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          }else{
            strLogin="<li><a href=\"/account/login.html\" class=\"text-primary\"><i class=\"fa-duotone fa-fw fa-user\"></i> <span class=\"menu-label\">accedi</span></a></li><li><a href=\"/registrazione.aspx\" class=\"text-secondary\"><i class=\"fa-duotone fa-fw fa-user-plus\"></i> <span class=\"menu-label\">registrati</span></a></li>";
            boolLogin=false;
			Response.Redirect("/login.aspx");
          }
      }else{
        strLogin="<li><a href=\"/account/login.html\" class=\"text-primary\"><i class=\"fa-duotone fa-fw fa-user\"></i> <span class=\"menu-label\">accedi</span></a></li><li><a href=\"/registrazione.aspx\" class=\"text-secondary\"><i class=\"fa-duotone fa-fw fa-user-plus\"></i> <span class=\"menu-label\">registrati</span></a></li>";
        boolLogin=false;
	    Response.Redirect("/login.aspx");
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

    public Boolean GetCheckValue(DataTable dtTabella, string strField)
    {
        Boolean boolValore = false;
        if (strAzione == "new")
        {
            boolValore = false;
        }
        else
        {
            boolValore = Smartdesk.Data.FieldBool(dtTabella,strField);
        }
        return boolValore;
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
