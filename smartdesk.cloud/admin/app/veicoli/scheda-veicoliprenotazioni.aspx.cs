using System;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtVeicoli;
    public DataTable dtVeicoliPrenotazioni;
    public DataTable dtPagamenti;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strAzione = "";
    public DataTable dtFormsData;
    public int intCoreGrids_Ky = 283;
    public int intCoreForms_Ky = 1214;
    public int intCoreEntities_Ky = 258;
    public int intCoreModules_Ky = 29;
    public string strWHERENet = "";
    public string strORDERNet = "";
    public string strSelected = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strAzione = Request["azione"];
          strH1="Veicoli > Scheda prenotazione";
          if (strAzione!="new"){
            strAzione = "modifica";
  	  	  	dtFormsData = Smartdesk.Data.Read("VeicoliPrenotazioni_Vw", "VeicoliPrenotazioni_Ky",Smartdesk.Current.QueryString("VeicoliPrenotazioni_Ky"));
          }
          
          strWHERENet = "(VeicoliTipologie_Sostitutiva=1)";
          strFROMNet = "Veicoli_Vw";
          strORDERNet = "Veicoli_Ky";
          dtVeicoli = new DataTable ("Veicoli");
          dtVeicoli = Smartdesk.Sql.getTablePage(strFROMNet, null, "Veicoli_Ky", strWHERENet, strORDERNet, 1, 2000, Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
          
    public String GetDefaultValue(string strField)
    {
      string strValore="";
      switch (strField){
		    case "VeicoliPrenotazioni_Data":
					strValore=DateTime.Now.ToString("dd-MM-yyyy HH:mm");
			    break;
		    case "VeicoliPrenotazioni_DataInizio":
					strValore=DateTime.Now.ToString("dd-MM-yyyy HH:mm");
			    break;
	    }
      return strValore;
    }

    public Boolean GetCheckValue(DataTable dtTabella, string strField)
    {
      Boolean boolValore=false;
      if (strAzione=="new"){
        boolValore=false;
      }else{
        if (dtTabella.Rows[0][strField].Equals(true)){
          boolValore=true;
        }
      }
      return boolValore;
    }

		public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        strValore=dtTabella.Rows[0][strField].ToString();
      }
      return strValore;

    }
}
