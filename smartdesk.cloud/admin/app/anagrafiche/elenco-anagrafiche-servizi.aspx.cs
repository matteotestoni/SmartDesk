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
    public DataTable dtAnagrafiche;
    public DataTable dtAttributixServizi;
    public int intAnagrafiche_Ky = 0;
    public string strH1 = "Amministrazione > Servizi delle anagrafiche";
    public int intRecxPag = 2000;
    public decimal decTot=0; 
    
    public string strCodiceAttributo;
    public string strValoreAttributo;

    protected void Page_Load(object sender, EventArgs e)
    {
    	string strFROMNet = "";
    	string strWHERENet="";
    	string strORDERNet = "";
	    string strPage="";
	    int intPage = 0;

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
            
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strPage = Request["page"];
            if ((strPage == null) || (strPage == "")){
              intPage = 1;
            }
            else{
              intPage = Convert.ToInt32(strPage);
            }
            strWHERENet=getWhere();
            //Response.Write(strWHERENet);
        	 strFROMNet = "AnagraficheServizi_Vw";
            strORDERNet = "AnagraficheServizi_MeseScadenza, Anagrafiche_RagioneSociale";
            dtAnagrafiche = new DataTable("Anagrafiche");
            dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            dtAttributixServizi = Smartdesk.Sql.getTablePage("Attributi_Vw", null, "Attributi_Ky", "Attributi_Servizi=1", "Attributi_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    


    public string getWhere()
    {
        string strWHERE="";
        string strValue="";

        strWHERE="AnagraficheServizi_Chiuso=0 AND Anagrafiche_Disdetto=0";
        strValue = Request["Servizi_Ky"];
        if (strValue != null && strValue != ""){
            strWHERE += " AND (Servizi_Ky=" + strValue + ")";
        }
        strValue = Request["prezzoda"];
        if (strValue != null && strValue != ""){
            strWHERE += " AND (AnagraficheServizi_Importo>=" + strValue + ")";
        }
        strValue = Request["prezzoa"];
        if (strValue != null && strValue != ""){
            strWHERE += " AND (AnagraficheServizi_Importo<=" + strValue + ")";
        }
        return strWHERE;
    }
}
