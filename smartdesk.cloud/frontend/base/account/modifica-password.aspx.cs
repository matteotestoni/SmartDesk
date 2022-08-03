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
    public string strH1="Modifica dati";
    public DataTable dtAnnunciCategorie;
    public DataTable dtNazioni;
    public DataTable dtProvince;
    public string strAzione = "";
    public string strWHERENet="";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public string strRequired = "";
    public string strClass = "";
    public int intNumeroFoto = 0;
    public string strPlaceholder = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strAnnunci_Ky = "";

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

          }else{
            strLogin="<li><a href=\"/account/login.html\" rel=\"nofollow\"><i class=\"fa-duotone fa-key fa-lg fa-fw\"></i><span class=\"hide-for-small-only\">Accedi</span></a><li></li><a href=\"/registrazione.aspx\"><i class=\"fa-duotone fa-user-plus fa-lg fa-fw\"></i><span class=\"hide-for-small-only\">Registrati</span></a><li>";
            boolLogin=false;
			Response.Redirect("/account/login.html");
          }
      }else{
        strLogin="<li><a href=\"/account/login.html\" rel=\"nofollow\"><i class=\"fa-duotone fa-key fa-lg fa-fw\"></i><span class=\"hide-for-small-only\">Accedi</span></a><li></li><a href=\"/registrazione.aspx\"><i class=\"fa-duotone fa-user-plus fa-lg fa-fw\"></i><span class=\"hide-for-small-only\">Registrati</span></a><li>";
        boolLogin=false;
	    Response.Redirect("/account/login.html");
      }

      strWHERENet = "AnnunciCategorie_Padre=0";
      dtAnnunciCategorie = new DataTable("AnnunciCategorie");
      dtAnnunciCategorie = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Ordine, AnnunciCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

	   strWHERENet = "";
      dtNazioni = new DataTable("Nazioni");
      dtNazioni = Smartdesk.Sql.getTablePage("Nazioni", null, "Nazioni_Ky", strWHERENet, "Nazioni_Ky", 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

	  strWHERENet = "";
      dtProvince = new DataTable("Province");
      dtProvince = Smartdesk.Sql.getTablePage("Province", null, "Province_Ky", strWHERENet, "Province_Ky", 1, 200,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

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
}
