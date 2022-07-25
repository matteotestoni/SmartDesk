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
    public DataTable dtFiles;
    public DataTable dtFilesTipo;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strAzione = "";
    
    public string strSorgente = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strAzione = Request["azione"];
            strSorgente = Request["sorgente"];
            strH1 ="Scheda file";
            if (strAzione!="new"){
	        	dtFiles = Smartdesk.Data.Read("Files", "Files_Ky",Smartdesk.Current.QueryString("Files_Ky"));
            }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }



    public String GetDefaultValue(string strField)
    {
        string strChiave_Ky = "";
        string strChiave_Tabella = "";

        switch (strSorgente){
            case "scheda-aste":
                strChiave_Ky= Request["Aste_Ky"];
                strChiave_Tabella = "Aste";
                break;
            case "scheda-annunci":
                strChiave_Ky= Request["Annunci_Ky"];
                strChiave_Tabella = "Annunci";
                break;

        }


        string strValore = "";
        switch (strField)
        {
            case "Chiave_Ky":
                strValore = strChiave_Ky;
                break;
            case "Chiave_Tabella":
                strValore = strChiave_Tabella;
                break;
            case "Files_Data":
                strValore=DateTime.Now.ToString("d");
                break;
            case "Lingue_Ky":
                strValore = "1";
                break;
            case "FilesTipo_Ky":
                strValore = "2";
                break;
            case "Files_Titolo":
                strValore = "File " + DateTime.Now.ToString("d");
                break;
        }
        return strValore;
    }


    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore= GetDefaultValue(strField);
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
