using System;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtProdotto;
    public DataTable dtFaq;
    public DataTable dtFaqCategorie;
    public DataTable dtProdottiTag;
    public DataTable dtProdottiGruppi;
    public DataTable dtProdottiApplicazioni;
    public DataTable dtProdottiApplicazioniCategorie;
    public DataTable dtProdottiCategorie;
    public DataTable dtProdottiCategorieFigli;
    public DataTable dtProdottiPadre;
    public string strFROMNet = "";
    public string strH1 = "";
    public int intNumDoc = 0;
    public int intNumDocVuoto = 0;
    public string strAzione = "modifica";
    
    public bool boolAdmin = false;
    public bool boolWysiwyg = false;
    public string strSelected = "";
    public string strWHERENet = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      
      string strORDERNet = "";
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
		  boolWysiwyg=(dtLogin.Rows[0]["Utenti_Wysiwyg"]).Equals(true);
          strAzione = Request["azione"];
          if (strAzione!="new"){
            strAzione = "modifica";
          	dtProdotto = Smartdesk.Data.Read("Prodotti_Vw", "Prodotti_Ky",Smartdesk.Current.QueryString("Prodotti_Ky"));
		  }            

          strWHERENet = "ProdottiTipo_Ky=2 OR ProdottiTipo_Ky=3 OR ProdottiTipo_Ky=5";
          strORDERNet = "Prodotti_Ky";
          strFROMNet = "Prodotti";
          dtProdottiPadre = Smartdesk.Sql.getTablePage(strFROMNet, null, "Prodotti_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          strWHERENet = "";
          strORDERNet = "ProdottiGruppi_Ky";
          strFROMNet = "ProdottiGruppi";
          dtProdottiGruppi = Smartdesk.Sql.getTablePage(strFROMNet, null, "ProdottiGruppi_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          strWHERENet = "";
          strORDERNet = "ProdottiApplicazioni_Ky";
          strFROMNet = "ProdottiApplicazioni";
          dtProdottiApplicazioni = Smartdesk.Sql.getTablePage(strFROMNet, null, "ProdottiApplicazioni_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          
          strWHERENet = "";
          strORDERNet = "ProdottiApplicazioniCategorie_Ky";
          strFROMNet = "ProdottiApplicazioniCategorie";
          dtProdottiApplicazioniCategorie = Smartdesk.Sql.getTablePage(strFROMNet, null, "ProdottiApplicazioniCategorie_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          
          strWHERENet = "ProdottiCategorie_Padre=0";
          strORDERNet = "ProdottiCategorie_Ky";
          strFROMNet = "ProdottiCategorie";
          dtProdottiCategorie = Smartdesk.Sql.getTablePage(strFROMNet, null, "ProdottiCategorie_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          strWHERENet = "";
          strORDERNet = "Faq_Ky";
          strFROMNet = "Faq";
          dtFaq = Smartdesk.Sql.getTablePage(strFROMNet, null, "Faq_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          strWHERENet = "";
          strORDERNet = "FaqCategorie_Ky";
          strFROMNet = "FaqCategorie";
          dtFaqCategorie = Smartdesk.Sql.getTablePage(strFROMNet, null, "FaqCategorie_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          strWHERENet = "";
          strORDERNet = "ProdottiTag_Ky";
          strFROMNet = "ProdottiTag";
          dtProdottiTag = Smartdesk.Sql.getTablePage(strFROMNet, null, "ProdottiTag_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    

    public String GetDefaultValue(string strField)
    {
      string strValore="";
      switch (strField){
			case "Prodotti_PubblicaWEB":
				strValore="-1";
				break;
			case "Prodotti_InVetrina":
				strValore="-1";
				break;
			case "ProdottiVisibilita_Ky":
				strValore="1";
				break;
			case "ProdottiTipo_Ky":
				strValore="1";
				break;
			case "ProdottiDisponibilita_Ky":
				strValore="1";
				break;
		}
      return strValore;
    }

    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        strValore=Smartdesk.Data.Field(dtTabella,strField);
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
