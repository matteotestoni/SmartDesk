using System;
using System.Data;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page 
{
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolLogin = false;
    public string strUtentiLogin="";
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public string strH1="contenuto";
    public DataTable dtAnnunciCategorie;
    public DataTable dtCMSContenuti;
    public string strTemp="";
    public string strCMSContenuti_Ky="";
    public string strUrl="";
    public string strCurrentUrl="";
    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";

	  
	  
      
      if (Request.Cookies["rswcrm-az"] != null){
          strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
          strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
            boolLogin=true;
            strLogin="<li><a href=\"/account/area-personale.html\" class=\"login\"><i class=\"fa-duotone fa-envelope fa-fw\"></i>Il mio profilo</a></li><li><a href=\"/logoutanagrafiche.aspx\" class=\"login\"><i class=\"fa-duotone fa-user-times fa-fw\"></i>Esci</a></li>";
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

	  strCMSContenuti_Ky=Request["CMSContenuti_Ky"];
	  if (strCMSContenuti_Ky!=null && strCMSContenuti_Ky.Length>0){
		  strWHERENet = "CMSContenuti_Ky=" + strCMSContenuti_Ky;
	      dtCMSContenuti = new DataTable("CMSContenuti");
	      dtCMSContenuti = Smartdesk.Sql.getTablePage("CMSContenuti", null, "CMSContenuti_Ky", strWHERENet, "CMSContenuti_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtCMSContenuti.Rows.Count>0){
            strUrl="/pag/" + dtCMSContenuti.Rows[0]["CMSContenuti_UrlKey"].ToString().ToLower().Trim() + ".html";
            strCurrentUrl=Request.RawUrl.ToString();
            if (strUrl!=strCurrentUrl){
              Response.Redirect(strUrl);
            }
          }else{
            Response.RedirectPermanent("/");
          }
	  }
    }    
}
