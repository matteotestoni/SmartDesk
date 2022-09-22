using System;
using System.Data;
public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtVeicoliPrenotazioni;
    public DataTable dtVeicoli;
    public DataTable dtAnagrafiche;
    public DataTable dtAzienda;
    public string strAziende_Ky = "";
    public int intVeicoliPrenotazioni_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "Scheda prenotazione";
    public string strAzione = "modifica";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      int intKy = 0;

      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          if (dtLogin.Rows.Count>0){
            strAzione = Request["azione"];
              strAzione = "modifica";
				      strAziende_Ky="1";            
	             //servizi
	            strWHERENet="Aziende_Ky=" + strAziende_Ky;
	            strORDERNet = "Aziende_Ky";
	            strFROMNet = "Aziende_Vw";
	            dtAzienda = new DataTable("Azienda");
	            dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

              strWHERENet="VeicoliPrenotazioni_Ky=" + Smartdesk.Current.Request("VeicoliPrenotazioni_Ky");
              strORDERNet = "VeicoliPrenotazioni_Ky";
              strFROMNet = "VeicoliPrenotazioni_Vw";
              dtVeicoliPrenotazioni = new DataTable("VeicoliPrenotazioni");
              dtVeicoliPrenotazioni = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliPrenotazioni_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

              strWHERENet="Veicoli_Ky=" + dtVeicoliPrenotazioni.Rows[0]["Veicoli_Ky"].ToString();
              strORDERNet = "Veicoli_Ky";
              strFROMNet = "Veicoli_Vw";
              dtVeicoli = new DataTable("Veicoli");
              dtVeicoli = Smartdesk.Sql.getTablePage(strFROMNet, null, "Veicoli_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

              strWHERENet="Anagrafiche_Ky=" + dtVeicoliPrenotazioni.Rows[0]["Anagrafiche_Ky"].ToString();
              strORDERNet = "Anagrafiche_Ky";
              strFROMNet = "Anagrafiche_Vw";
              dtAnagrafiche = new DataTable("Anagrafiche");
              dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              //strSQL="UPDATE VeicoliPrenotazioni SET VeicoliPrenotazioni_Stampata=1 WHERE VeicoliPrenotazioni_Ky=" + Smartdesk.Current.Request("VeicoliPrenotazioni_Ky");
              //intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                          
          }else{
            Response.Redirect("default.aspx");
          }
      }else{
            Response.Redirect("default.aspx");
      }
    }    
    
    public String GetCheckValueSiNo (DataTable dtTabella, string strField) {
        Boolean boolValore = false;
        String strValore = "<i class=\"fa-duotone fa-square fa-fw fa-lg\"></i>";
        if (strAzione == "new") {
            boolValore = false;
        } else {
            boolValore = Smartdesk.Data.FieldBool (dtTabella, strField);
        }
        if (boolValore){
          strValore = "<i class=\"fa-duotone fa-square-check fa-fw fa-xl\"></i> S&Igrave;";
        }else{
          strValore = "NO";
        }
        return strValore;
    }
    
    public String GetCheckValue (DataTable dtTabella, string strField) {
        Boolean boolValore = false;
        String strValore = "<i class=\"fa-duotone fa-square fa-fw fa-lg\"></i>";
        if (strAzione == "new") {
            boolValore = false;
        } else {
            boolValore = Smartdesk.Data.FieldBool (dtTabella, strField);
        }
        if (boolValore){
          strValore = "<i class=\"fa-duotone fa-square-check fa-fw fa-xl\"></i> S&Igrave;";
        }else{
          strValore = "<i class=\"fa-duotone fa-square fa-fw fa-xl\"></i>";
        }
        return strValore;
    }
}
