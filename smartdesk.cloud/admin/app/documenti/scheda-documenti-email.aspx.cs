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
    public bool boolWysiwyg = false;
    public DataTable dtTemp;
    public DataTable dtDocumenti;
    public DataTable dtAnagrafiche;
    public DataTable dtAziende;
    public string strAnagrafiche_Ky = "";
    public string strAnagrafiche_RagioneSociale = "";
    public string strDocumenti_Ky = "";
    public string strFROMNet = "";
    public string strH1 = "Invia Documento per email";
    public string strAzione = "modifica";
    public string strDocumenti_Descrizione = "";
    public string strRiferimenti = "";
    
    public string strAlert = "";
    public string strAziende_Ky = "";

    protected void Page_Load(object sender, EventArgs e)
    {

      
			
      if (Smartdesk.Login.Verify){
        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
        boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
        boolWysiwyg = (dtLogin.Rows[0]["Utenti_Wysiwyg"]).Equals(true);
        strAzione = Request["azione"];
        //strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
        strDocumenti_Ky=Smartdesk.Current.Request("Documenti_Ky");
        strAziende_Ky=Smartdesk.Current.Request("Aziende_Ky");
        strAzione="modifica";
    	dtDocumenti = Smartdesk.Data.Read("Documenti_Vw", "Documenti_Ky", strDocumenti_Ky);
        strAnagrafiche_Ky = dtDocumenti.Rows[0]["Anagrafiche_Ky"].ToString();
        dtAnagrafiche = Smartdesk.Data.Read("Anagrafiche_Vw", "Anagrafiche_Ky", strAnagrafiche_Ky);
        dtAziende = Smartdesk.Data.Read("Aziende", "Aziende_Ky", "1");
      }else
        {
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

		
    public String GetDefaultValue(string strField)
    {
      string strValore="";
      switch (strField){
		case "Anagrafiche_Ky":
			strValore=strAnagrafiche_Ky;
			break;
		case "Anagrafiche_RagioneSociale":
			strValore=strAnagrafiche_RagioneSociale;
			break;
		case "Aziende_Ky":
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

    public decimal GetDecimalValue(string strField)
    {
      decimal dclValore=0;
      if (strAzione=="new"){
        dclValore=0;
      }else{
        try{
	        if (dtDocumenti.Rows.Count>0 && dtDocumenti.Rows[0][strField]!=null && dtDocumenti.Rows[0][strField]!=System.DBNull.Value){
				try{
					dclValore=(decimal)dtDocumenti.Rows[0][strField];
				}catch{
        			dclValore=0;
				}
			}else{
				dclValore=0;
			}
        }catch{
        	dclValore=0;
		}
      }
      return dclValore;
    }
    
    public Boolean GetCheckValue(string strField)
    {
      Boolean boolValore=false;
      if (strAzione=="new"){
        boolValore=false;
      }else{
        if (dtDocumenti.Rows[0][strField].Equals(true)){
          boolValore=true;
        }
      }
      return boolValore;
    }

	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
