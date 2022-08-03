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
    public DataTable dtAsteCauzioni;
    public DataTable dtAsteEsperimenti;
    public string strFROMNet = "";
    public string strH1 = "Cauzione asta";
    public string strAzione = "";
    public string strAste_Ky = "";
    public string strAsteEsperimenti_Ky = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet = "";
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strAzione = Request["azione"];
          if (strAzione!="new"){
            strAzione="modifica";
            dtAsteCauzioni = Smartdesk.Data.Read("AsteCauzioni_Vw", "AsteCauzioni_Ky",Smartdesk.Current.QueryString("AsteCauzioni_Ky"));
            strAste_Ky=dtAsteCauzioni.Rows[0]["Aste_Ky"].ToString();
            strAsteEsperimenti_Ky=dtAsteCauzioni.Rows[0]["AsteEsperimenti_Ky"].ToString();
          }else{
            strAste_Ky=Request["Aste_Ky"];
            strAsteEsperimenti_Ky=Request["AsteEsperimenti_Ky"];
          }
          if (strAste_Ky!=null && strAste_Ky.Length>0){
            strWHERENet = "Aste_Ky=" + strAste_Ky;
            dtAsteEsperimenti = new DataTable("AsteEsperimenti");
            dtAsteEsperimenti = Smartdesk.Sql.getTablePage("AsteEsperimenti_Vw", null, "AsteEsperimenti_Ky", strWHERENet, "AsteEsperimenti_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            strWHERENet = "Aste_Ky=" + strAste_Ky;
            dtAste = new DataTable("Aste");
            dtAste = Smartdesk.Sql.getTablePage("Aste_Vw", null, "Aste_Ky", strWHERENet, "Aste_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          }else{
          	if (strAsteEsperimenti_Ky!=null && strAsteEsperimenti_Ky.Length>0){
	            strWHERENet = "AsteEsperimenti_Ky=" + strAsteEsperimenti_Ky;
	            dtAsteEsperimenti = new DataTable("AsteEsperimenti");
	            dtAsteEsperimenti = Smartdesk.Sql.getTablePage("AsteEsperimenti_Vw", null, "AsteEsperimenti_Ky", strWHERENet, "AsteEsperimenti_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
	          }
          }
      }else{
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
            case "Aste_Ky":
			   strValore=strAste_Ky;	
               break;
            case "AsteCauzioni_Valore":
			   if (dtAste!=null && dtAste.Rows.Count>0){
                   strValore=Convert.ToInt32(dtAste.Rows[0]["Aste_Cauzione"]).ToString();	
               }else{
                   strValore="0";	
               }
               break;
            case "Anagrafiche_Ky":
			   if (dtAste!=null && dtAste.Rows.Count>0){
                   strValore=dtAste.Rows[0]["Anagrafiche_Ky"].ToString();	
               }else{
                   strValore="";	
               }
               break;
            case "Anagrafiche_RagioneSociale":
			   if (dtAste!=null && dtAste.Rows.Count>0){
                   strValore=dtAste.Rows[0]["Anagrafiche_RagioneSociale"].ToString();	
               }else{
                   strValore="";	
               }
               break;
            case "PagamentiMetodo_Ky":
			   if (dtAste!=null && dtAste.Rows.Count>0){
                   strValore=dtAste.Rows[0]["PagamentiMetodo_Ky"].ToString();	
               }else{
                   strValore="";	
               }
               break;
            case "Conti_Ky":
			   if (dtAste!=null && dtAste.Rows.Count>0){
                   strValore=dtAste.Rows[0]["Conti_Ky"].ToString();	
               }else{
                   strValore="";	
               }
               break;
            case "AsteEsperimenti_Ky":
			   if (dtAsteEsperimenti!=null && dtAsteEsperimenti.Rows.Count>0){
                   strValore=dtAsteEsperimenti.Rows[dtAsteEsperimenti.Rows.Count-1]["AsteEsperimenti_Ky"].ToString();	
               }else{
                   strValore="";	
               }
               break;
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
}
