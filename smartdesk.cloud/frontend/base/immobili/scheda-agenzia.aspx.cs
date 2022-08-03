using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page 
{
    public string strMetaDescription = "";
    public string strMetaKeywords = "";
    public string strMetaRobots="index,follow";
    public string strH1 = "";
    public string strP1 = "";
    public string strTitle = "";
    public int i = 0;
    public int intNumRecords = 0;
    public DataTable dtUtente;
    public string strImmobili_Ky="";
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    private string strInviato = "";
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
        string strWHERENet="";
        string strFROMNet = "";
        string strORDERNet = "";
        string strImmobili_Ky="";
    
    	  
    	  
        strImmobili_Ky= Request["Utenti_Ky"];
        strInviato= Request["inviato"];
        strWHERENet="Utenti_Ky=" + strImmobili_Ky;
        strFROMNet = "Utenti_Vw";
        strORDERNet = "Utenti_Ky";
        dtUtente = new DataTable("agenzia");
        dtUtente = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtUtente.Rows.Count>0){
          strTitle=dtUtente.Rows[0]["Utenti_Nominativo"].ToString();
          if (dtUtente.Rows[0]["Comuni_Comune"].ToString().Length>0){
            strTitle+=" a " + dtUtente.Rows[0]["Comuni_Comune"].ToString();
          }
          strMetaKeywords=strTitle;
          if ((dtUtente.Rows[0]["Province_Provincia"].ToString().Length>0) && !(dtUtente.Rows[0]["Province_Provincia"].Equals(dtUtente.Rows[0]["Comuni_Comune"]))){
            strTitle+=" in provincia di " + dtUtente.Rows[0]["Province_Provincia"].ToString();
          }
          if (dtUtente.Rows[0]["Utenti_Indirizzo"].ToString().Length>0){
            strTitle+=" " + dtUtente.Rows[0]["Utenti_Indirizzo"].ToString();
          }
          strH1=strTitle;
          strMetaDescription = strTitle;
        }else{
          Response.RedirectPermanent("/");
        }        
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
      dtUtente.Dispose();
    }
}
