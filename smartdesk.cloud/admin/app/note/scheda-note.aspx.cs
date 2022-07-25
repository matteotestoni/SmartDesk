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
    public DataTable dtNote;
    public DataTable dtNoteCategorie;
    public DataTable dtCMSTags;
    public string strFROMNet = "";
    public string strH1 = "Scheda nota";
    public string strAzione = "modifica";
    
    public string strAnagrafiche_Ky = "";
    public string strAnagrafiche_RagioneSociale = "";
    public DataTable dtCommesse;
    public string strCommesse_Ky = "";
    public string strAttivita_Ky = "";
    public string strDocumenti_Ky = "";
    public DataTable dtTemp;
    public string strSorgente = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      
      string strWHERENet="";
      string strORDERNet = "";

      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
			strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
            strCommesse_Ky=Smartdesk.Current.Request("Commesse_Ky");
            strAttivita_Ky=Request["Attivita_Ky"];
            strDocumenti_Ky=Request["Documenti_Ky"];
            strAzione = Request["azione"];
            strSorgente=Smartdesk.Current.Request("sorgente");
            if (strAzione!="new"){
					strAzione = "modifica";
					dtNote = Smartdesk.Data.Read("Note_Vw", "Note_Ky",Smartdesk.Current.QueryString("Note_Ky"));
					strAnagrafiche_Ky=dtNote.Rows[0]["Anagrafiche_Ky"].ToString();
					strAnagrafiche_RagioneSociale=dtNote.Rows[0]["Anagrafiche_RagioneSociale"].ToString();
					strCommesse_Ky=dtNote.Rows[0]["Commesse_Ky"].ToString();
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
			if (strAnagrafiche_Ky!=null && strAnagrafiche_Ky.Length>0){
	            strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
	            strORDERNet = "Commesse_Ky";
	            strFROMNet = "Commesse_Vw";
		          dtCommesse = new DataTable("Commessa");
	            dtCommesse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            }
            dtNoteCategorie = Smartdesk.Sql.getTablePage("NoteCategorie", null, "NoteCategorie_Ky", "", "NoteCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
			//tags
			strWHERENet="";
			strORDERNet = "CMSTags_Titolo";
			strFROMNet = "CMSTags";
			dtCMSTags = new DataTable("CMSTags");
			dtCMSTags = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSTags_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    
    public String GetDefaultValue(string strField)
    {
      string strValore="";
      switch (strField){
    	case "Priorita_Ky":
    		strValore="1";
    		break;
    	case "Documenti_Ky":
    		strValore=strDocumenti_Ky;
    		break;
    	case "Commesse_Ky":
    		strValore=strCommesse_Ky;
    		break;
    	case "Anagrafiche_Ky":
    		strValore=strAnagrafiche_Ky;
    		break;
    	case "Anagrafiche_RagioneSociale":
    		strValore=strAnagrafiche_RagioneSociale;
    		break;
    	case "Attivita_Ky":
    		strValore=strAttivita_Ky;
    		break;
    	case "Note_Data":
    		strValore=DateTime.Now.ToString("d");
    		break;
    	case "Note_Data_IT":
    		strValore=DateTime.Now.ToString("d");
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
