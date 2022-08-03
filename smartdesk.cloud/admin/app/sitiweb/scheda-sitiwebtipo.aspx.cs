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
    public DataTable dtSitiWebTipo;
    public DataTable dtSitiWebTipoCorpo;
    public string strFROMNet = "";
    public string strH1 = "Tipo di sito web";
    public string strAzione = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strAzione = Request["azione"];
          strH1="Sorgente trattativa";
          if (strAzione!="new"){
            strAzione = "modifica";
  	  	  	dtSitiWebTipo = Smartdesk.Data.Read("SitiWebTipo", "SitiWebTipo_Ky",Smartdesk.Current.QueryString("SitiWebTipo_Ky"));
          }
      }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
          
    public Boolean GetCheckValue(string strField)
    {
      Boolean boolValore=false;
      if (strAzione=="new"){
        boolValore=false;
      }else{
        if (dtSitiWebTipo.Rows[0][strField].Equals(true)){
          boolValore=true;
        }
      }
      return boolValore;
    }

		public String GetFieldValue(string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="";
      }else{
        strValore=dtSitiWebTipo.Rows[0][strField].ToString();
      }
      return strValore;

    }
}
