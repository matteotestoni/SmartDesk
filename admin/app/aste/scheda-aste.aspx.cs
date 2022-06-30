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
    public DataTable dtAste;
    public DataTable dtAsteProxyBid;
    public DataTable dtAsteEsperimenti;
    public DataTable dtAsteCauzioni;
    public DataTable dtAsteCommissioni;
    public DataTable dtFiles;
    public DataTable dtAnnunci;
    public DataTable dtAnnunciOfferte;
    public DataTable dtPagamenti;
    public DataTable dtTemp;
    public string strFROMNet = "";
    public string strWHERENet = "";
    public string strORDERNet = "";
    public string strH1 = "Scheda Asta";
    public string strAzione = "";
  	public string strAnnunci_Ky="";
  	public string strAste_Ky="";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Smartdesk.Login.Verify)
        {
            dtLogin = Smartdesk.Data.LoginUtente();
            boolAdmin = Smartdesk.Data.FieldBool(dtLogin,"Utenti_Admin");
            strAzione = Smartdesk.Current.Request("azione");
            if (strAzione != "new")
            {
                strAzione = "modifica";
                strAste_Ky = Smartdesk.Current.QueryString("Aste_Ky");

                dtAste = Smartdesk.Data.Read("Aste_Vw", "Aste_Ky", strAste_Ky);
                dtAsteEsperimenti = Smartdesk.Data.Read("AsteEsperimenti_Vw", "Aste_Ky", strAste_Ky);

				strWHERENet = "Aste_Ky=" + strAste_Ky;
                strORDERNet = "AsteProxyBid_Data DESC";
                strFROMNet = "AsteProxyBid_Vw";
                dtAsteProxyBid = Smartdesk.Sql.getTablePage(strFROMNet, null, "AsteProxyBid_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

				strWHERENet = "Aste_Ky=" + strAste_Ky;
                strORDERNet = "AsteEsperimenti_Ky, AsteCauzioni_Ky";
                strFROMNet = "AsteCauzioni_Vw";
                dtAsteCauzioni = Smartdesk.Sql.getTablePage(strFROMNet, null, "AsteCauzioni_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

				strWHERENet = "Aste_Ky=" + strAste_Ky;
                strORDERNet = "AsteCommissioni_Da, AsteCommissioni_Ky DESC";
                strFROMNet = "AsteCommissioni";
                dtAsteCommissioni = Smartdesk.Sql.getTablePage(strFROMNet, null, "AsteCommissioni_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                
				strWHERENet = "Aste_Ky=" + strAste_Ky;
                strORDERNet = "Annunci_Ky";
                strFROMNet = "Annunci_Vw";
                dtAnnunci = Smartdesk.Sql.getTablePage(strFROMNet, null, "Annunci_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                strWHERENet = "Chiave_Tabella='Aste' AND Chiave_Ky=" + strAste_Ky;
                strORDERNet = "Files_Ky";
                strFROMNet = "Files_Vw";
                dtFiles = Smartdesk.Sql.getTablePage(strFROMNet, null, "Files_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            }
        }
        else
        {
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }    
    
    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        strValore= Smartdesk.Data.Field(dtTabella,strField);
      }
      return strValore;
    }

    public String GetDefaultValue(string strField)
    {
        string strValore = "";
        switch (strField)
        {
            case "AsteTipo_Ky":
                dtTemp = new DataTable("Temp");
                dtTemp = Smartdesk.Sql.getTablePage("AsteTipo", null, "AsteTipo_Ky", "AsteTipo_Default=1", "AsteTipo_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtTemp.Rows.Count>0){
					strValore = dtTemp.Rows[0]["AsteTipo_Ky"].ToString();
				}else{
					strValore="";	
				}
                break;
            case "Conti_Ky":
			   strValore="1";	
               break;
            case "AliquoteIVA_Ky":
                dtTemp = new DataTable("Temp");
                dtTemp = Smartdesk.Sql.getTablePage("AliquoteIVA", null, "AliquoteIVA_Ky", "AliquoteIVA_Predefinita=1", "AliquoteIVA_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtTemp.Rows.Count>0){
                	strValore = dtTemp.Rows[0]["AliquoteIVA_Ky"].ToString();
				}else{
					strValore="";	
				}
               break;
            case "PagamentiCondizioni_Ky":
                dtTemp = new DataTable("Temp");
                dtTemp = Smartdesk.Sql.getTablePage("PagamentiCondizioni", null, "PagamentiCondizioni_Ky", "PagamentiCondizioni_Predefinita=1", "PagamentiCondizioni_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtTemp.Rows.Count>0){
					strValore = dtTemp.Rows[0]["PagamentiCondizioni_Ky"].ToString();
				}else{
					strValore="";	
				}
                break;
            case "PagamentiMetodo_Ky":
                dtTemp = new DataTable("Temp");
                dtTemp = Smartdesk.Sql.getTablePage("PagamentiMetodo", null, "PagamentiMetodo_Ky", "PagamentiMetodo_Default=1", "PagamentiMetodo_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtTemp.Rows.Count>0){
					strValore = dtTemp.Rows[0]["PagamentiMetodo_Ky"].ToString();
				}else{
					strValore="";	
				}
                break;
            case "SpedizioniTipo_Ky":
				strValore="1";	
                break;                
            case "Nazioni_Ky":
				strValore="105";	
                break;        
            case "AsteRitiri_Ky":
				strValore="1";	
                break;      
            case "Aste_Provvigione":
				strValore="4";	
                break;      
            case "Aste_Cauzione":
				strValore="250";	
                break;      
            case "Aste_Rilancio":
				strValore="100";	
                break;      				  
        }
        return strValore;
    }
}
