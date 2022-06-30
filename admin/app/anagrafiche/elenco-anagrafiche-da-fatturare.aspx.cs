using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Web.Mvc;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtAnagrafiche;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "Amministrazione > Servizi da fatturare";
    public decimal decTotMese=0; 
    public decimal decTot=0; 
    public int intMese = 0;
    public int intAnno = 0;
    
    public DataTable dtStatistiche;
    public int intNumeroServizi = 0;
    public int intNumeroServizi1 = 0;
    public int intNumeroServizi2 = 0;
    public int intNumeroServizi3 = 0;
    public int intNumeroServizi4 = 0;
    public int intNumeroServizi5 = 0;
    public int intNumeroServizi6 = 0;
    public int intNumeroServizi7 = 0;
    public int intNumeroServizi8 = 0;
    public int intNumeroServizi9 = 0;
    public int intNumeroServizi10 = 0;
    public int intNumeroServizi11 = 0;
    public int intNumeroServizi12 = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strPage="";
      int intPage = 0;

      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strPage = Request["page"];
            if ((strPage == null) || (strPage == "")){
              intPage = 1;
            }
            else{
              intPage = Convert.ToInt32(strPage);
            }
            strWHERENet=getWhere();
            strFROMNet = "AnagraficheServizi_Vw";
            strORDERNet = "Month(AnagraficheServizi_Scadenza), Year(AnagraficheServizi_Scadenza), Anagrafiche_Ky";
            dtAnagrafiche = new DataTable("AnagraficheServizi");
            dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
          
            strWHERENet="(Anagrafiche_Disdetto!=1 And (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null))";
            strFROMNet = "AnagraficheServizi_Vw";
            strORDERNet = "Month(AnagraficheServizi_Scadenza), Year(AnagraficheServizi_Scadenza), Anagrafiche_Ky";
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
		    intNumeroServizi = dtStatistiche.Rows.Count;
            strWHERENet="(Anagrafiche_Disdetto!=1 And (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) AND Month(AnagraficheServizi_Scadenza)=1)";
            strFROMNet = "AnagraficheServizi_Vw";
            strORDERNet = "Month(AnagraficheServizi_Scadenza), Year(AnagraficheServizi_Scadenza), Anagrafiche_Ky";
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
		    intNumeroServizi1 = dtStatistiche.Rows.Count;
            strWHERENet="(Anagrafiche_Disdetto!=1 And (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) AND Month(AnagraficheServizi_Scadenza)=2)";
            strFROMNet = "AnagraficheServizi_Vw";
            strORDERNet = "Month(AnagraficheServizi_Scadenza), Year(AnagraficheServizi_Scadenza), Anagrafiche_Ky";
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
		    intNumeroServizi2 = dtStatistiche.Rows.Count;
            strWHERENet="(Anagrafiche_Disdetto!=1 And (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) AND Month(AnagraficheServizi_Scadenza)=3)";
            strFROMNet = "AnagraficheServizi_Vw";
            strORDERNet = "Month(AnagraficheServizi_Scadenza), Year(AnagraficheServizi_Scadenza), Anagrafiche_Ky";
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
		    intNumeroServizi3 = dtStatistiche.Rows.Count;
            strWHERENet="(Anagrafiche_Disdetto!=1 And (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) AND Month(AnagraficheServizi_Scadenza)=4)";
            strFROMNet = "AnagraficheServizi_Vw";
            strORDERNet = "Month(AnagraficheServizi_Scadenza), Year(AnagraficheServizi_Scadenza), Anagrafiche_Ky";
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
		    intNumeroServizi4 = dtStatistiche.Rows.Count;
            strWHERENet="(Anagrafiche_Disdetto!=1 And (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) AND Month(AnagraficheServizi_Scadenza)=5)";
            strFROMNet = "AnagraficheServizi_Vw";
            strORDERNet = "Month(AnagraficheServizi_Scadenza), Year(AnagraficheServizi_Scadenza), Anagrafiche_Ky";
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
		    intNumeroServizi5 = dtStatistiche.Rows.Count;
            strWHERENet="(Anagrafiche_Disdetto!=1 And (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) AND Month(AnagraficheServizi_Scadenza)=6)";
            strFROMNet = "AnagraficheServizi_Vw";
            strORDERNet = "Month(AnagraficheServizi_Scadenza), Year(AnagraficheServizi_Scadenza), Anagrafiche_Ky";
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
		    intNumeroServizi6 = dtStatistiche.Rows.Count;
            strWHERENet="(Anagrafiche_Disdetto!=1 And (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) AND Month(AnagraficheServizi_Scadenza)=7)";
            strFROMNet = "AnagraficheServizi_Vw";
            strORDERNet = "Month(AnagraficheServizi_Scadenza), Year(AnagraficheServizi_Scadenza), Anagrafiche_Ky";
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
		    intNumeroServizi7 = dtStatistiche.Rows.Count;
            strWHERENet="(Anagrafiche_Disdetto!=1 And (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) AND Month(AnagraficheServizi_Scadenza)=8)";
            strFROMNet = "AnagraficheServizi_Vw";
            strORDERNet = "Month(AnagraficheServizi_Scadenza), Year(AnagraficheServizi_Scadenza), Anagrafiche_Ky";
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
		    intNumeroServizi8 = dtStatistiche.Rows.Count;
            strWHERENet="(Anagrafiche_Disdetto!=1 And (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) AND Month(AnagraficheServizi_Scadenza)=9)";
            strFROMNet = "AnagraficheServizi_Vw";
            strORDERNet = "Month(AnagraficheServizi_Scadenza), Year(AnagraficheServizi_Scadenza), Anagrafiche_Ky";
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
		    intNumeroServizi9 = dtStatistiche.Rows.Count;
            strWHERENet="(Anagrafiche_Disdetto!=1 And (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) AND Month(AnagraficheServizi_Scadenza)=10)";
            strFROMNet = "AnagraficheServizi_Vw";
            strORDERNet = "Month(AnagraficheServizi_Scadenza), Year(AnagraficheServizi_Scadenza), Anagrafiche_Ky";
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
		    intNumeroServizi10 = dtStatistiche.Rows.Count;
            strWHERENet="(Anagrafiche_Disdetto!=1 And (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) AND Month(AnagraficheServizi_Scadenza)=11)";
            strFROMNet = "AnagraficheServizi_Vw";
            strORDERNet = "Month(AnagraficheServizi_Scadenza), Year(AnagraficheServizi_Scadenza), Anagrafiche_Ky";
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
		    intNumeroServizi11 = dtStatistiche.Rows.Count;
            strWHERENet="(Anagrafiche_Disdetto!=1 And (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) AND Month(AnagraficheServizi_Scadenza)=12)";
            strFROMNet = "AnagraficheServizi_Vw";
            strORDERNet = "Month(AnagraficheServizi_Scadenza), Year(AnagraficheServizi_Scadenza), Anagrafiche_Ky";
            dtStatistiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
		    intNumeroServizi12 = dtStatistiche.Rows.Count;
		  
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public int getMese(string strMeseIN){
      int intMeseOut=0;
      
      if (strMeseIN!=null && strMeseIN.Length>0){
        intMeseOut=Convert.ToInt32(strMeseIN);
      }else{
        intMeseOut=0;
          
      }
      return intMeseOut;        
    }

    public int getAnno(string strAnnoIN){
      int intAnnoOut=0;
      
      if (strAnnoIN!=null && strAnnoIN.Length>0){
        intAnnoOut=Convert.ToInt32(strAnnoIN);
      }else{
        intAnnoOut=0;
          
      }
      return intAnnoOut;        
    }


    public string getWhere()
    {
        string strWHERE="";
        string strValue="";

        strWHERE="Anagrafiche_Disdetto!=1 AND AnagraficheServizi_Chiuso=0";
        strFROMNet = "AnagraficheServizi_Vw";
        strValue = Request["lettera"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Anagrafiche_Disdetto!=1 AND (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) AND Anagrafiche_RagioneSociale like '" + strValue + "%')";
        }
        strValue = Request["Anagrafiche_RagioneSociale"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Anagrafiche_Disdetto!=1 AND (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) AND Anagrafiche_RagioneSociale like '%" + strValue + "%')";
        }
        strValue = Request["mese"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Anagrafiche_Disdetto!=1 AND (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) AND Month(AnagraficheServizi_Scadenza)=" + strValue + ")";
        }
        strValue = Request["Servizi_Ky"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Anagrafiche_Disdetto!=1) AND (AnagraficheServizi_Chiuso=0 Or AnagraficheServizi_Chiuso Is Null) AND (Servizi_Ky=" + strValue + ")";
        }
        strValue = Request["tutti"];
        if (strValue != null && strValue != ""){
            strWHERE = "Anagrafiche_Disdetto!=1";
        }
        //Response.Write(strWHERE);
        return strWHERE;
    }
    
    public String GetTipoRinnovo(string strRinnovoIn){
      string strRinnovoOut="";
      if (strRinnovoIn!=null){
        switch (strRinnovoIn){
          case "0":
            strRinnovoOut="no rinnovo";
            break;
          case "1":
            strRinnovoOut="mensile";
            break;
          case "2":
            strRinnovoOut="bimestrale";
            break;
          case "3":
            strRinnovoOut="ogni 3 mesi";
            break;
          case "4":
            strRinnovoOut="ogni 4 mesi";
            break;
          case "5":
            strRinnovoOut="ogni 5 mesi";
            break;
          case "6":
            strRinnovoOut="ogni 6 mesi";
            break;
          case "7":
            strRinnovoOut="ogni 7 mesi";
            break;
          case "8":
            strRinnovoOut="ogni 8 mesi";
            break;
          case "9":
            strRinnovoOut="ogni 9 mesi";
            break;
          case "10":
            strRinnovoOut="ogni 10 mesi";
            break;
          case "11":
            strRinnovoOut="ogni 11 mesi";
            break;
          case "12":
            strRinnovoOut="annuale";
            break;
        }
      }else{
        strRinnovoOut="";
      }
      return strRinnovoOut;
        
    }
}
