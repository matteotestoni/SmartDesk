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
    public string strAttivitaSettore_Ky="";
    public string strAnagrafiche_Ky="";
    public string strAttivita_Completo="";
    public string strSorgente="";
    public string strCommesse_Ky="";
    public string strOpportunita_Ky="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            strAttivita_Ky=Request["Attivita_Ky"];
            strAttivitaSettore_Ky=Smartdesk.Current.Request("AttivitaSettore_Ky");
            strAttivita_Completo=Request["Attivita_Completo"];
            strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
            strSorgente=Smartdesk.Current.Request("sorgente");
	        	strCommesse_Ky=Smartdesk.Current.Request("Commesse_Ky");
		        	strOpportunita_Ky=Smartdesk.Current.Request("Opportunita_Ky");
                if (strAttivita_Completo=="0"){
                  strSQL = "UPDATE Attivita SET AttivitaStati_Ky=3, Attivita_Completo=" + strAttivita_Completo + ", Attivita_Chiusura=Null WHERE Attivita_Ky=" + strAttivita_Ky;
                }else{
                  strSQL = "UPDATE Attivita SET AttivitaStati_Ky=5, Attivita_Completo=" + strAttivita_Completo + ", Attivita_Chiusura=GETDATE() WHERE Attivita_Ky=" + strAttivita_Ky;
                }
      					new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
								switch(strAttivitaSettore_Ky){
									case "1":
										strSQL = "UPDATE Anagrafiche SET Anagrafiche_AttivitaTecnica=GETDATE() WHERE Anagrafiche_Ky=" + strAnagrafiche_Ky;
										break;
									case "2":
										strSQL = "UPDATE Anagrafiche SET Anagrafiche_AttivitaCommerciale=GETDATE() WHERE Anagrafiche_Ky=" + strAnagrafiche_Ky;
										break;
									case "3":
										strSQL = "UPDATE Anagrafiche SET Anagrafiche_AttivitaAmministrazione=GETDATE() WHERE Anagrafiche_Ky=" + strAnagrafiche_Ky;
										break;
								}
      					new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

                switch (strSorgente){
                  case "home":
                    Response.Redirect("/admin/home.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky);
                    break;
                  case "home-tecnici":
                    Response.Redirect("/admin/home.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky);
                    break;
                  case "dafare":
                    Response.Redirect("/admin/app/anagrafiche/elenco-anagrafiche-da-fare.aspx?Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString() + "#attivita");
                    break;
                  case "scheda-anagrafiche":
                    Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky);
                    break;
                  case "scheda-commessa":
                    Response.Redirect("/admin/app/progetti/scheda-commesse.aspx?Commesse_Ky=" + strCommesse_Ky);
                    break;
                  case "scheda-progetti":
                    Response.Redirect("/admin/app/progetti/scheda-progetti.aspx?Commesse_Ky=" + strCommesse_Ky);
                    break;
                  case "scheda-opportunita":
                    Response.Redirect("/admin/app/commerciale/scheda-opportunita.aspx?Opportunita_Ky=" + strOpportunita_Ky);
                    break;
                  case "prospetto":
                    Response.Redirect("/admin/app/attivita/attivita-da-fare.aspx?Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString() + "&attivita-scadute=1&prossime-scadenze=1&scadenze-future=1#attivita");
                    break;
    		          case "commessa":
    	                Response.Redirect("/admin/app/progetti/scheda-commesse.aspx?Commesse_Ky=" + strCommesse_Ky);
    	                break;
                }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
