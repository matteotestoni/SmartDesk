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
    
    public DataTable dtTrasferte;
    public int intUtenti_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "Attivit&agrave; > Elenco trasferte";
    public DateTime dt;
    public int intYear;
    public int intMonth;
    public decimal decTotMeseOre=0; 
    public decimal decTotMeseKm=0; 
    public decimal decTotMeseSpeseKm=0; 
    public decimal decTotMeseParcheggi=0; 
    public decimal decTotMesePasti=0; 
    public decimal decTotMeseAutostrada=0; 
    public decimal decTotMeseMezziPubblici=0; 	
	  public decimal decTotMeseSpese=0; 
    public decimal decTotMeseNumero=0; 
    public decimal decTotTrasferteOre=0; 
    public decimal decTotTrasferteKm=0; 
    public decimal decTotTrasferteSpeseKm=0; 
    public decimal decTotTrasferteSpeseParcheggi=0; 
    public decimal decTotTrasferteSpesePasti=0; 
    public decimal decTotTrasferteSpeseAutostrada=0; 
    public decimal decTotTrasferteSpeseMezziPubblici=0; 
    public decimal decTotTrasferteSpese=0; 
    
    public string strAnno = "";
    public string strMese = "";
    public DataTable dtGridData;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strPage="";
      int intPage = 0;

      
	  
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
            strAnno=Request["anno"];
            if (strAnno==null || strAnno.Length<1){
      				strAnno=intYear.ToString();
      			}
            strMese=Request["mese"];
            strFROMNet = "Attivita_Trasferte_Vw";
            strWHERENet=getWhere();
            strORDERNet = "Utenti_Cognome, Mese DESC, Attivita_Scadenza DESC";
            dtTrasferte = new DataTable("Attivita");
            dtTrasferte = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            dtGridData =  dtTrasferte;           
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
		
    public decimal convertiDecimale(string strValore){
    decimal dclOut;
	    if (strValore!=null & strValore.Length>0){
	    	dclOut=Convert.ToDecimal(strValore);
	    }else{
				dclOut=0;
			}
			return dclOut;
		}

    public string getWhere()
    {
        string strWHERE="";
        string strValue="";

        strWHERE="";
        strWHERE="Attivita_Trasferta=1 And Utenti_Attivo=1";
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
         		strH1+=" - Persona: " + strValue;
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
