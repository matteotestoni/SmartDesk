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
    public string strAttivita_Ky="";
    public string strAttivitaStati_Ky="";
    public string strAnagrafiche_Ky="";
    public string strCommesse_Ky="";
    public string strOpportunita_Ky="";
    public int intAttivitaStati_Ky=0;
    public string strSorgente="";
    
    public bool boolAjax = false;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            strAttivita_Ky=Request["Attivita_Ky"];
            boolAjax=Convert.ToBoolean(Smartdesk.Current.Request("ajax"));
            strAttivitaStati_Ky=Smartdesk.Current.Request("AttivitaStati_Ky");
            intAttivitaStati_Ky=Convert.ToInt32(strAttivitaStati_Ky);
            strSorgente=Smartdesk.Current.Request("sorgente");
            strSQL = "UPDATE Attivita SET AttivitaStati_Ky=" + intAttivitaStati_Ky.ToString() + " WHERE Attivita_Ky=" + strAttivita_Ky;
  					new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            if (boolAjax==true){
                //Response.Write(strSQL);
                Response.Write("ok");
            }else{
                switch (strSorgente){
                  case "home":
                    Response.Redirect("/admin/home.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky + "#attivita");
                    break;
                  case "home-tecnici":
                    Response.Redirect("/admin/home.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky + "#attivita");
                    break;
                  case "dafare":
                    Response.Redirect("/admin/app/anagrafiche/elenco-anagrafiche-da-fare.aspx?Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString() + "#attivita");
                    break;
                  case "scheda-anagrafiche":
                    Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky + "#attivita");
                    break;
                  case "scheda-commessa":
                    Response.Redirect("/admin/app/progetti/scheda-commesse.aspx?Commesse_Ky=" + strCommesse_Ky + "#attivita");
                    break;
                  case "scheda-opportunita":
                    Response.Redirect("/admin/app/commerciale/scheda-opportunita.aspx?Opportunita_Ky=" + strOpportunita_Ky + "#attivita");
                    break;
                  case "prospetto":
                    Response.Redirect("/admin/app/attivita/attivita-da-fare-stato.aspx?Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString() + "&attivita-scadute=1&prossime-scadenze=1&scadenze-future=1#attivita");
                    break;
    		          case "commessa":
                    Response.Redirect("/admin/app/progetti/scheda-commesse.aspx?Commesse_Ky=" + strCommesse_Ky + "#attivita");
                    break;
                }            
            }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
