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
    public DataTable dtOpportunita;
    public DataTable dtUtenti;
    public DataTable dtPreventiviAuto;
    public DataTable dtPreventiviAutoProdotti;
    public string strFROMNet = "";
    public string strH1 = "Automotive > Preventivo auto";
    public string strAzione = "modifica";
    public string strAnagrafiche_Ky = "";
    public string strAnagrafiche_RagioneSociale = "";
    public DataTable dtTemp;
    public string strSorgente = "";
    public int intAnagrafiche_Ky = 0;
    public string strOpportunita_Ky = "";
    public string strPreventiviAuto_Ky = "";
    public DataTable dtCoreForms;
    public DataTable dtCoreFormsButtons;
    public int intCoreGrids_Ky = 1;
    public int intCoreForms_Ky = 1;
    public int intCoreEntities_Ky = 1;
    public int intCoreModules_Ky = 28;
    public string strAction = "";
    public DataTable dtFormsData;
    public DataTable dtCoreEntities;
    public DataTable dtCurrentCoreForms;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

    if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
      	  strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
      	  strOpportunita_Ky=Smartdesk.Current.Request("Opportunita_Ky");
       	  strPreventiviAuto_Ky=Smartdesk.Current.Request("PreventiviAuto_Ky");
          intCoreForms_Ky = Convert.ToInt32(Request["CoreForms_Ky"]);
          intCoreEntities_Ky = Convert.ToInt32(Request["CoreEntities_Ky"]);
          strAzione = Request["azione"];
          strSorgente=Smartdesk.Current.Request("sorgente");
          strWHERENet="Utenti_Attivo=1";
          strORDERNet = "Utenti_Nome, Utenti_Cognome";
          strFROMNet = "Utenti";
          dtUtenti = new DataTable("Utenti");
          dtUtenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);


          strWHERENet = "(CoreForms_Ky=" + intCoreForms_Ky + ")";
          strFROMNet = "CoreForms_Vw";
          strORDERNet = "CoreForms_Ky";
          dtCurrentCoreForms = new DataTable ("CurrentCoreForms");
          dtCurrentCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreForms_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          intCoreEntities_Ky = Convert.ToInt32(dtCurrentCoreForms.Rows[0]["CoreEntities_Ky"]);
          strWHERENet = "(CoreEntities_Ky=" + dtCurrentCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + ")";
          strFROMNet = "CoreEntities_Vw";
          strORDERNet = "CoreEntities_Ky";
          dtCoreEntities = new DataTable ("CoreEntities");
          dtCoreEntities = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1, 2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          strWHERENet = "(CoreForms_Ky=" + intCoreForms_Ky + ")";
          strFROMNet = "CoreFormsButtons";
          strORDERNet = "CoreFormsButtons_Order ASC, CoreFormsButtons_Ky DESC";
          dtCoreFormsButtons = new DataTable ("CoreFormsButtons");
          dtCoreFormsButtons = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsButtons_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          if (strAzione!="new"){
            strAzione = "modifica";
            //preventivi auto
            strWHERENet="PreventiviAuto_Ky=" + strPreventiviAuto_Ky;
            strORDERNet = "PreventiviAuto_Ky Desc";
            strFROMNet = "PreventiviAuto_Vw";
            dtPreventiviAuto = new DataTable("PreventiviAuto");
            dtPreventiviAuto = Smartdesk.Sql.getTablePage(strFROMNet, null, "PreventiviAuto_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            dtFormsData = dtPreventiviAuto;
            
            strWHERENet="PreventiviAuto_Ky=" + strPreventiviAuto_Ky;
            strORDERNet = "PreventiviAutoProdotti_Ky Desc";
            strFROMNet = "PreventiviAutoProdotti";
            dtPreventiviAutoProdotti = new DataTable("PreventiviAutoProdotti");
            dtPreventiviAutoProdotti = Smartdesk.Sql.getTablePage(strFROMNet, null, "PreventiviAutoProdotti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
            strAnagrafiche_Ky=dtPreventiviAuto.Rows[0]["Anagrafiche_Ky"].ToString();
            strAnagrafiche_RagioneSociale=dtPreventiviAuto.Rows[0]["Anagrafiche_RagioneSociale"].ToString();

            strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
            strORDERNet = "Opportunita_Ky Desc";
            strFROMNet = "Opportunita_Vw";
            dtOpportunita = new DataTable("Opportunita");
            dtOpportunita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Opportunita_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);               
    	    }else{
        		if (strAnagrafiche_Ky!=null && strAnagrafiche_Ky.Length>0){
        		  strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
              strORDERNet = "Anagrafiche_Ky";
              strFROMNet = "Anagrafiche";
              dtTemp = new DataTable("Anagrafiche");
              dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    		      strAnagrafiche_RagioneSociale=dtTemp.Rows[0]["Anagrafiche_RagioneSociale"].ToString();
    		}
    	}            
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    public String GetDefaultValue(string strField)
    {
     string strValore="";
     switch (strField){
      case "Utenti_Ky":
        strValore = Smartdesk.Session.CurrentUser.ToString();
        break;
      case "Anagrafiche_Ky":
				strValore=strAnagrafiche_Ky;
				break;
			case "Anagrafiche_RagioneSociale":
				strValore=strAnagrafiche_RagioneSociale;
				break;
			case "PreventiviAuto_Data":
				strValore=DateTime.Now.ToString("dd-MM-yyyy HH:mm");
				break;
			case "PreventiviAuto_Data_IT":
				strValore=DateTime.Now.ToString("dd-MM-yyyy HH:mm");
				break;
      case "PreventiviAuto_Numero":
        strValore = GetNewNumDoc(DateTime.Now.Year);
        break;
      case "PreventiviAuto_Sconto":
        strValore = "";
        break;
      case "PreventiviAuto_Prezzo":
        strValore = "";
        break;
      case "PreventiviAuto_IVA":
        strValore = "";
        break;
      case "Opportunita_Ky":
        strValore = Request["Opportunita_Ky"];
        break;
      case "Opportunita_Titolo":
        strValore = Request["Opportunita_Titolo"];
        break;
    }
    return strValore;
    }
  public String GetNewNumDoc(int intAnno)
  {
    string strWHERE = "Year(PreventiviAuto_Data)=" + intAnno + " AND Utenti_Ky=" + Smartdesk.Session.CurrentUser.ToString();
    int intUltimoNumero = 0;
    string strNuovoNumero = "";
    dtTemp = new DataTable("GetNewNumDoc");
    dtTemp = Smartdesk.Sql.getTablePage("PreventiviAuto_Vw", null, "PreventiviAuto_Ky", strWHERE, "PreventiviAuto_Numero DESC", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    if (dtTemp != null && dtTemp.Rows.Count > 0)
    {
      intUltimoNumero = Convert.ToInt32(dtTemp.Rows[0]["PreventiviAuto_Numero"]);
    }
    strNuovoNumero = (intUltimoNumero + 1).ToString();
    return strNuovoNumero;
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
    
    
    public String GetMoneyValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        strValore=dtTabella.Rows[0][strField].ToString();
        strValore=strValore.Replace(",0000","");
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
}
