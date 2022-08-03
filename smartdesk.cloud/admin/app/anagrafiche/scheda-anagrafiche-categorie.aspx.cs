using System;
using System.Data;
using System.Data.SqlClient;


public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public bool boolWysiwyg = false;
    public DataTable dtAnagraficheCategorie;
    public DataTable dtAttributi;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "Categoria anagrafica";
    public string strAzione = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet = "";
      string strORDERNet = "";
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          boolWysiwyg=(dtLogin.Rows[0]["Utenti_Wysiwyg"]).Equals(true);
          strAzione = Request["azione"];
          if (strAzione!="new"){
              strAzione = "modifica";
              dtAnagraficheCategorie = Smartdesk.Data.Read("AnagraficheCategorie", "AnagraficheCategorie_Ky",Smartdesk.Current.QueryString("AnagraficheCategorie_Ky"));
          }
          strWHERENet = "Attributi_Anagrafiche=1";
          strORDERNet = "Attributi_Ky";
          strFROMNet = "Attributi_Vw";
          dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="";
      }else{
        strValore=Smartdesk.Data.Field(dtTabella,strField);
      }
      return strValore;
    }
}
