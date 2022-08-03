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
    
    public DataTable dtDocumenti;
    public DataTable dtDocumentiCorpo;
    public DataTable dtDocumentiIVA;
    public DataTable dtPagamenti;
    public DataTable dtAzienda;
    public int intAnagrafiche_Ky = 0;
    public string strDocumenti_Ky = "";
    public string strAziende_Ky = "";
    public string strFROMNet = "";
    public string strH1 = "";
    
    public int intYear;
    public int intMonth;
    public int intAnno = 0;
    public int intMese = 0;
    public decimal decTotMese=0; 
    public decimal decTotIVAMese=0; 
    public decimal decTotServiziMese=0; 
    public decimal decTot=0; 
    public decimal decTotServizi=0; 
    public decimal decTotIVA=0; 
    public int intDocumenti_Ky = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
      
		
		//Smartdesk.Session.CurrentUser.ToString()="1";
		if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
            
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strDocumenti_Ky=Smartdesk.Current.Request("Documenti_Ky");
            if (strDocumenti_Ky==null || strDocumenti_Ky.Length<1){
                strDocumenti_Ky="47";
            }
            strWHERENet="DocumentiTipo_Ky=4";
            strORDERNet = "Documenti_Anno DESC, Documenti_Numero DESC";
            strFROMNet = "Documenti_Vw";
            dtDocumenti = new DataTable("Documenti");
            dtDocumenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			      strAziende_Ky=dtDocumenti.Rows[0]["Aziende_Ky"].ToString();            
             //servizi
            strWHERENet="Aziende_Ky=" + strAziende_Ky;
            strORDERNet = "Aziende_Ky";
            strFROMNet = "Aziende_Vw";
            dtAzienda = new DataTable("Azienda");
            dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public String getStato(string strDocumentiStato_Ky, string strDocumentiStato_Descrizione)
    {
      string strStatoOut="";
      if (strDocumentiStato_Ky!=null){
        switch (strDocumentiStato_Ky){
          case "1":
            strStatoOut="<span class=\"label radius success\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "2":
            strStatoOut="<span class=\"label radius warning\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "3":
            strStatoOut="<span class=\"label radius warning\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "4":
            strStatoOut="<span class=\"label radius alert\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "5":
            strStatoOut="<span class=\"label radius success\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "6":
            strStatoOut="<span class=\"label radius success\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "7":
            strStatoOut="<span class=\"label radius warning\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "8":
            strStatoOut="<span class=\"label radius alert\">" + strDocumentiStato_Descrizione + "</span>";
            break;
        }
      }else{
        strStatoOut="";
      }
      return strStatoOut;
    }   
    
    public String GetUTF(string strTestoIn)
    {
      string strTestoOut="";
      if (strTestoIn!=null){
        strTestoOut=strTestoIn.Replace(".","").Replace("&","").Replace("snc","").Replace(" ","-").Replace("--","-");
      }else{
        strTestoOut="";
      }
      return strTestoOut;
    }   
		  
		public static string StripTagsCharArray(string source){
			char[] array = new char[source.Length];
			int arrayIndex = 0;
			bool inside = false;
		
			for (int i = 0; i < source.Length; i++)
			{
			    char let = source[i];
			    if (let == '<')
			    {
				inside = true;
				continue;
			    }
			    if (let == '>')
			    {
				inside = false;
				continue;
			    }
			    if (!inside)
			    {
				array[arrayIndex] = let;
				arrayIndex++;
			    }
			}
			return new string(array, 0, arrayIndex);
		}    
}
