using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtUtenti;
    public DataTable dtAttivita;
    public DataTable dtAzienda;
    public string strUtenti_Ky = "";
    public string strFROMNet = "";
    public string strH1 = "";
    public string strAzione = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            strAzione = Request["azione"];
            strUtenti_Ky = Smartdesk.Current.Request("Utenti_Ky");
            strWHERENet="Utenti_Ky=" + strUtenti_Ky;
            strORDERNet = "Utenti_Ky";
            strFROMNet = "Utenti_Vw";
            dtUtenti = new DataTable("Utenti");
            dtUtenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strWHERENet="Aziende_Ky=1";
            strORDERNet = "Aziende_Ky";
            strFROMNet = "Aziende_Vw";
            dtAzienda = new DataTable("Azienda");
            dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
            
			if (dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){
              strWHERENet="Utenti_Ky=" + strUtenti_Ky + " AND (Attivita_Completo Is Null Or Attivita_Completo='no')";
              strORDERNet = "Attivita_Scadenza DESC";
              strFROMNet = "Attivita_Vw";
              dtAttivita = new DataTable("Attivita");
              dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            }            
      }else{
            Response.Redirect("default.aspx");
      }
    }    

	public static string TextToHtml(string text)
	{
	    text = "<pre>" + System.Web.HttpUtility.HtmlEncode(text) + "</pre>";
	    return text;
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

    public String GetFieldValue(string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="";
      }else{
        strValore=dtUtenti.Rows[0][strField].ToString();
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
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
