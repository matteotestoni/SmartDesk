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
    public DataTable dtProdottiApplicazioniCategorie;
    public string strH1 = "Scheda categoria prodottiapplicazioni";
    public string strAzione = "modifica";
    
    public string strSorgente = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strAzione = Request["azione"];
          strSorgente=Smartdesk.Current.Request("sorgente");
          if (strAzione!="new"){
          	strAzione = "modifica";
  	  	  	dtProdottiApplicazioniCategorie = Smartdesk.Data.Read("ProdottiApplicazioniCategorie", "ProdottiApplicazioniCategorie_Ky",Smartdesk.Current.QueryString("ProdottiApplicazioniCategorie_Ky"));
          }            
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
