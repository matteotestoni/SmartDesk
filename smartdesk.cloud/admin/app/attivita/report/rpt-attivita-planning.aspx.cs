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
    public DataTable dtAzienda;
    public DataTable dtAttivita;
    public string strFROMNet = "";
    public string strH1 = "";
    public DateTime dt;
    public string strPeriodo = "";
    public string strTipo = "";
    public string strCommesse_Ky = "";
    public string strAnagrafiche_Ky = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strSQL="";
      SqlConnection conn;
      SqlCommand cmd;

      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            /*
            conn = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
            conn.Open();
            strSQL= "SELECT Attivita.Attivita_Ky,Commesse.Commesse_Ky, Commesse.Commesse_Riferimenti, Attivita.Attivita_Descrizione, Attivita.Attivita_Scadenza, Attivita.AttivitaTipo_Ky,"; 
            strSQL+= " Attivita.Persone_Ky, Attivita.Attivita_Ky AS chiave, Anagrafiche.Anagrafiche_Ky, Commesse.CommesseStato_Ky, Attivita.Attivita_Completo, Attivita.Attivita_Chiusura, CONVERT(varchar, ";
            strSQL+= " Attivita.Attivita_Chiusura, 105) AS Attivita_Chiusura_IT, AttivitaTipo.AttivitaTipo_Descrizione, Attivita.Attivita_Trasferta, Attivita.Attivita_Ore, Commesse.Commesse_Titolo, CONVERT(varchar, Attivita.Attivita_Scadenza, 105) AS Attivita_Scadenza_IT, AttivitaTipo.AttivitaTipo_Icona, Anagrafiche.Anagrafiche_RagioneSociale, Commesse.Commesse_DataInizioLavori, ";
            strSQL+= " Commesse.Commesse_DataConsegna, CONVERT(varchar, Commesse.Commesse_DataInizioLavori, 105) AS Commesse_DataInizioLavori_IT, CONVERT(varchar, Commesse.Commesse_DataConsegna, 105) AS Commesse_DataConsegna_IT, Attivita.Attivita_OrePreviste, Commesse.Commesse_OrePreviste, Commesse.Commesse_OreImpiegate, Commesse.Opportunita_Ky, Utenti.Utenti_Colore, ";
            strSQL+= " Utenti.Utenti_Cognome, Utenti.Utenti_Nome, Attivita.Utenti_Ky, Commesse.Commesse_Data";
            strSQL+= " FROM Utenti RIGHT OUTER JOIN AttivitaTipo INNER JOIN Attivita ON AttivitaTipo.AttivitaTipo_Ky = Attivita.AttivitaTipo_Ky INNER JOIN Anagrafiche ON Attivita.Anagrafiche_Ky = Anagrafiche.Anagrafiche_Ky ON Utenti.Utenti_Ky = Attivita.Utenti_Ky LEFT OUTER JOIN Commesse ON Attivita.Commesse_Ky = Commesse.Commesse_Ky";
            Response.Write(strSQL);
            cmd = new SqlCommand(strSQL, conn);
            dtAttivita.Load(cmd.ExecuteReader());*/
          strWHERENet="(Attivita_Completo=0)";
          strORDERNet = "Anagrafiche_RagioneSociale ASC, Attivita_Scadenza";
          strFROMNet = "Attivita_Planning_Vw";
          dtAttivita = new DataTable("Attivita_Planning");
          dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "chiave", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          strWHERENet="Aziende_Ky=1";
          strORDERNet = "Aziende_Ky";
          strFROMNet = "Aziende_Vw";
          dtAzienda = new DataTable("Azienda");
          dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
      }else{
            Response.Redirect("default.aspx");
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
}
