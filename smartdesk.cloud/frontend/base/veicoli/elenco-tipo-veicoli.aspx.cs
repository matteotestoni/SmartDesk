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
    public DataTable dtVeicoliTipo;
    public DataTable dtVeicoliCategoria;
    public DataTable dtCMSContenuti;
    public string strTemp="";
    public string strCMSContenuti_Ky="";
    public string strFoto="";
    public string strWHERENet="";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public string strTitle = "";
    public string strMetaDescription = "";
    public string strMetaRobots = "index,follow";
    public string strH1 = "Tipo veicoli";
    public string strP1 = "";

    protected void Page_Load(object sender, EventArgs e)
    {

  	  
  	  
      
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
          }else{
            strLogin="<a href=\"/account/login.html\"><i class=\"fa-duotone fa-key fa-lg fa-fw\"></i>Accedi</a> | <a href=\"/registrazione.aspx\"><i class=\"fa-duotone fa-user-shield fa-lg fa-fw\"></i>Registrati</a>";
            boolLogin=false;
          }
      }else{
        strLogin="<a href=\"/account/login.html\"><i class=\"fa-duotone fa-key fa-lg fa-fw\"></i>Accedi</a> | <a href=\"/registrazione.aspx\"><i class=\"fa-duotone fa-user-shield fa-lg fa-fw\"></i>Registrati</a>";
        boolLogin=false;
      }

	    strWHERENet = "";
      dtVeicoliTipo = new DataTable("VeicoliTipo");
      dtVeicoliTipo = Smartdesk.Sql.getTablePage("VeicoliTipo", null, "VeicoliTipo_Ky", strWHERENet, "VeicoliTipo_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

	    strWHERENet = "";
      dtVeicoliCategoria = new DataTable("VeicoliCategoria");
      dtVeicoliCategoria = Smartdesk.Sql.getTablePage("VeicoliCategoria", null, "VeicoliCategoria_Ky", strWHERENet, "VeicoliCategoria_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

  	  strCMSContenuti_Ky=Request["CMSContenuti_Ky"];
  	  if (strCMSContenuti_Ky!=null && strCMSContenuti_Ky.Length>0){
  		    strWHERENet = "CMSContenuti_Ky=" + strCMSContenuti_Ky;
  	      dtCMSContenuti = new DataTable("CMSContenuti");
  	      dtCMSContenuti = Smartdesk.Sql.getTablePage("CMSContenuti", null, "CMSContenuti_Ky", strWHERENet, "CMSContenuti_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  	  }
    }    


    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App)
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}
