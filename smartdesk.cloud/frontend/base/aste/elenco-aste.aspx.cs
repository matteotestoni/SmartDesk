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
    public string strH1="Elenco aste";
    public DataTable dtAsteEsperimenti;
    public int intRecxPag = 30;
    public int intPage = 0;
    public int intNumPagine = 1;
    public string strPaginazione = "";
    public DataTable dtAsteCategorie;
    public DataTable dtAnnunciCategorie;
    public DataTable dtRegioni;
    public DataTable dtLottiAsta;
    public string strWHERENet="";
    public string strFROMNet = "";
    public string strORDERNet = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strPage = "";
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
  
        strPage = Request["page"];
        if ((strPage == null) || (strPage == ""))
        {
            intPage = 1;
        }
        else
        {
            intPage = Convert.ToInt32(strPage);
        }
	  	
      
	  	strWHERENet = "AnnunciCategorie_Padre=0";
      	dtAnnunciCategorie = new DataTable("AnnunciCategorie");
      	dtAnnunciCategorie = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Ordine, AnnunciCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		
		strWHERENet = "";
        dtAsteCategorie = new DataTable("AsteCategorie");
        dtAsteCategorie = Smartdesk.Sql.getTablePage("AsteCategorie", null, "AsteCategorie_Ky", strWHERENet, "AsteCategorie_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
	    
        strWHERENet = "Nazioni_Ky=105";
      	dtRegioni = new DataTable("Regioni");
      	dtRegioni = Smartdesk.Sql.getTablePage("Regioni", null, "Regioni_Ky", strWHERENet, "Regioni_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

        strWHERENet = getWhere();
        //Response.Write(strWHERENet);
        dtAsteEsperimenti = new DataTable("AsteEsperimenti");
        dtAsteEsperimenti = Smartdesk.Sql.getTablePage("AsteEsperimenti_Web_Vw", null, "AsteEsperimenti_Ky", strWHERENet, "AsteEsperimenti_DataTermine", intPage, intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    }

    public string getWhere()
    {
        string strWHERE="";
        string strWHEREPermessi="";
        string strValue="";

        strWHERE="(AsteEsperimentiEsiti_Ky=3)";
        strValue = Request["AsteCategorie_Ky"];
        if (strValue != null && strValue != "" && strValue.Length>0){
            if (strValue.Substring(strValue.Length-1,1)==","){
              strValue=strValue.Substring(0,strValue.Length-1);              
            } 
            if (strValue != null && strValue != ""){
                strWHERE += " AND (AsteCategorie_Ky IN (" + strValue + "))";
            }
        }
        strValue = Request["Regioni_Ky"];
        if (strValue != null && strValue != "" && strValue.Length>0){
            if (strValue.Substring(0,1)==","){
              strValue=strValue.Substring(1,strValue.Length-1);              
            } 
            if (strValue.Substring(strValue.Length-1,1)==","){
              strValue=strValue.Substring(0,strValue.Length-1);              
            } 
            if (strValue != null && strValue != ""){
                strWHERE += " AND (Regioni_Ky IN (" + strValue + "))";
            }
        }
        //Response.Write("1:" + strWHEREPermessi);
        //Response.Write("2:" + strWHERE);
        return strWHERE;
    }
}
