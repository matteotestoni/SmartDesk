using System;
using System.Data;
using System.Data.SqlClient;


public partial class _Default : System.Web.UI.Page 
{
    
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    
    public DataTable dtTrasferte;
    public int intAnagrafiche_Ky = 0;
    public string strH1 = "";
    public int intRecxPag = 2000;
    public int intPage = 0;
    public int intNumPagine=1;
    public int intNumRecords = 0;
    
    public string strPaginazione = "";
    public int intYear;
    public int intMonth;
    public DateTime dt;
    public string strWHERENet="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strORDERNet = "";
      string strFROMNet = "";
      string strPage="";

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          if (dtLogin.Rows.Count>0){
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strPage = Request["page"];
            if ((strPage == null) || (strPage == "")){
              intPage = 1;
            }
            else{
              intPage = Convert.ToInt32(strPage);
            }
            dt=DateTime.Now;
            intYear=dt.Year;
            intMonth=dt.Month;
            strWHERENet=getWhere();
            strFROMNet = "Attivita_Trasferte_Vw";
            strORDERNet = "Utenti_Nominativo, Attivita_Scadenza DESC";
            dtTrasferte = new DataTable("Trasferte");
            dtTrasferte = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
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

        strWHERE="";
        strH1="Trasferte";
        strWHERE="Attivita_Trasferta=1";
        strValue = Request["anno"];
        if (strValue != null && strValue != "" && strValue != "tutti"){
            strWHERE += " AND (YEAR(Attivita_Scadenza)=" + strValue + ")";
        		strH1+=" Anno: " + strValue;
        }else{
            strWHERE += " AND (YEAR(Attivita_Scadenza)>=" + (intYear-1) + ")";
         		strH1+=" Anno: " + intYear;
       }
        strValue = Request["mese"];
        if (strValue != null && strValue != ""){
            strWHERE += " AND (MONTH(Attivita_Scadenza)=" + strValue + ")";
         		strH1+=" - Mese: " + Smartdesk.Functions.GetMese(strValue);
        }
        strValue = Smartdesk.Current.Request("Utenti_Ky");
        if (strValue != null && strValue != ""){
            strWHERE += " And (Utenti_Ky=" + strValue + ")";
         		strH1+=" - Utente: " + strValue;
        }
        strValue = Request["tutti"];
        if (strValue != null && strValue != ""){
            strWHERE = "Attivita_Trasferta=1";
            strH1="Trasferte di tutti";
        }
        //Response.Write(strWHERE);
        return strWHERE;
    }
}
