using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtSitiWeb;
    public DataTable dtAnagrafiche;
    public DataTable dtAnagraficheContatti;
    public DataTable dtAnagraficheContattiAlias;
    public DataTable dtAnagraficheContattiPEC;
    public DataTable dtPagamenti;
    public DataTable dtProviders;
    public DataTable dtAzienda;
    public int intAnagrafiche_Ky = 0;
    public string strAnagrafiche_Ky = "";
    public string strSitiWeb_Ky = "";
    public string strFROMNet = "";
    public string strH1 = "";
    public string strDominio = "";
    public string strPop3 = "";
    public string strPop3s = "";
    public string strPop3sporta = "";
    public string strSmtp = "";
    public string strSmtps = "";
    public string strSmtpsporta = "";
    public string strWebmail1 = "";
    public string strWebmail2 = "";
    public string strProviders_Ky = "";
    
    public string strImap = "";
    public string strImapPorta = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
					if (dtLogin.Rows.Count>0){
            
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
            if (strAnagrafiche_Ky==null || strAnagrafiche_Ky.Length<1){
                strAnagrafiche_Ky="47";
            }
             //servizi
            strWHERENet="Aziende_Ky=1";
            strORDERNet = "Aziende_Ky";
            strFROMNet = "Aziende_Vw";
            dtAzienda = new DataTable("Azienda");
            dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

            strSitiWeb_Ky=Smartdesk.Current.Request("SitiWeb_Ky");          
			
			strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
            strORDERNet = "Anagrafiche_Ky";
            strFROMNet = "Anagrafiche_Vw";
            dtAnagrafiche = new DataTable("Anagrafiche");
            dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			
			strWHERENet="SitiWeb_Ky=" + strSitiWeb_Ky;
            strORDERNet = "SitiWeb_Ky";
            strFROMNet = "SitiWeb_Vw";
            dtSitiWeb = new DataTable("SitiWeb");
            dtSitiWeb = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWeb_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            strDominio=dtSitiWeb.Rows[0]["SitiWeb_Dominio"].ToString();
            strProviders_Ky=dtSitiWeb.Rows[0]["Providers_Ky"].ToString();
            
			strWHERENet="Providers_Ky=" + strProviders_Ky;
            strORDERNet = "Providers_Ky";
            strFROMNet = "Providers";
            dtProviders = new DataTable("Providers");
            dtProviders = Smartdesk.Sql.getTablePage(strFROMNet, null, "Providers_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
            //[dominio da sostituire]
            strPop3=dtProviders.Rows[0]["Providers_pop3"].ToString();
            strPop3=strPop3.Replace("[dominio]",strDominio);
            strPop3=strPop3.Replace("dominio",strDominio);

            strPop3s=dtProviders.Rows[0]["Providers_pop3s"].ToString();
            strPop3s=strPop3s.Replace("[dominio]",strDominio);
            strPop3s=strPop3s.Replace("dominio",strDominio);
            strPop3sporta=dtProviders.Rows[0]["Providers_pop3sporta"].ToString();
            
			
			      strSmtp=dtProviders.Rows[0]["Providers_smtp"].ToString();
            strSmtp=strSmtp.Replace("[dominio]",strDominio);
            strSmtp=strSmtp.Replace("dominio",strDominio);
			      strSmtps=dtProviders.Rows[0]["Providers_Smtps"].ToString();
            strSmtps=strSmtps.Replace("[dominio]",strDominio);
            strSmtps=strSmtps.Replace("dominio",strDominio);
			      strSmtpsporta=dtProviders.Rows[0]["Providers_smtpsporta"].ToString();
                strImap = dtProviders.Rows[0]["Providers_Imap"].ToString();
                strImap = strImap.Replace("[dominio]", strDominio);
                strImap = strImap.Replace("dominio", strDominio);
                strImapPorta = dtProviders.Rows[0]["Providers_ImapPorta"].ToString();

                strWebmail1=dtProviders.Rows[0]["Providers_webmail"].ToString();
            strWebmail1=strWebmail1.Replace("[dominio]",strDominio);
            strWebmail1=strWebmail1.Replace("dominio",strDominio);
			
			strWebmail2=dtProviders.Rows[0]["Providers_webmail2"].ToString();
            strWebmail2=strWebmail2.Replace("[dominio]",strDominio);
            strWebmail2=strWebmail2.Replace("dominio",strDominio);

            
            //servizi standard
            strWHERENet="(AnagraficheContatti_PEC=0) AND (AnagraficheContatti_Stampa=0) AND (Len(LTrim(RTrim(AnagraficheContatti_Alias)))<5 OR AnagraficheContatti_Alias Is Null) AND (Anagrafiche_Ky=" + strAnagrafiche_Ky + ") AND (SitiWeb_Ky=" + strSitiWeb_Ky + ")";
            strORDERNet = "AnagraficheContatti_Email";
            strFROMNet = "AnagraficheContatti_Vw";
            dtAnagraficheContatti = new DataTable("AnagraficheContatti");
            dtAnagraficheContatti = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheContatti_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
            //alias
            strWHERENet="(AnagraficheContatti_PEC=0) AND (AnagraficheContatti_Stampa=0) AND (Len(LTrim(RTrim(AnagraficheContatti_Alias)))>5) AND (Anagrafiche_Ky=" + strAnagrafiche_Ky + ") AND (SitiWeb_Ky=" + strSitiWeb_Ky + ")";
            strORDERNet = "AnagraficheContatti_Email";
            strFROMNet = "AnagraficheContatti_Vw";
            dtAnagraficheContattiAlias = new DataTable("AnagraficheContattiAlias");
            dtAnagraficheContattiAlias = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheContatti_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
            //servizi PEC
            strWHERENet="(AnagraficheContatti_PEC=1) AND (AnagraficheContatti_Stampa=0) AND (Anagrafiche_Ky=" + strAnagrafiche_Ky + ") AND (SitiWeb_Ky=" + strSitiWeb_Ky + ")";
            strORDERNet = "AnagraficheContatti_Email";
            strFROMNet = "AnagraficheContatti_Vw";
            dtAnagraficheContattiPEC = new DataTable("AnagraficheContattiPEC");
            dtAnagraficheContattiPEC = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheContatti_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    public String GetUTF(string strTestoIn)
    {
      string strTestoOut="";
      if (strTestoIn!=null){
        strTestoOut=strTestoIn.Replace(".","").Replace("&","").Replace("snc","").Replace(" ","-").Replace("--","-");
      }else{
        strTestoOut="";
      }
      return strTestoOut;
    }   
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
