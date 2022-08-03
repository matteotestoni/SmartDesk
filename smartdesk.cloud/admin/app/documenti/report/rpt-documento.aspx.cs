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
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strSQL="";

      
      
				
      	//Smartdesk.Session.CurrentUser.ToString()="1";
				if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
            
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strDocumenti_Ky=Smartdesk.Current.Request("Documenti_Ky");
            if (strDocumenti_Ky==null || strDocumenti_Ky.Length<1){
                strDocumenti_Ky="47";
            }
            strWHERENet="Documenti_Ky=" + strDocumenti_Ky;
            strORDERNet = "Documenti_Ky";
            strFROMNet = "Documenti_Vw";
            dtDocumenti = new DataTable("Documenti");
            dtDocumenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			strAziende_Ky=dtDocumenti.Rows[0]["Aziende_Ky"].ToString();            
             //servizi
            strWHERENet="Aziende_Ky=" + strAziende_Ky;
            strORDERNet = "Aziende_Ky";
            strFROMNet = "Aziende_Vw";
            dtAzienda = new DataTable("Azienda");
            dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
            //righe
            strWHERENet="Documenti_Ky=" + strDocumenti_Ky;
            strORDERNet = "codice";
            strFROMNet = "DocumentiIVA_Vw";
            dtDocumentiIVA = new DataTable("DocumentiIVA");
            dtDocumentiIVA = Smartdesk.Sql.getTablePage(strFROMNet, null, "codice", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
            //IVA
            strWHERENet="Documenti_Ky=" + strDocumenti_Ky;
            strORDERNet = "DocumentiCorpo_Ordine, DocumentiCorpo_Ky";
            strFROMNet = "DocumentiCorpo_Vw";
            dtDocumentiCorpo = new DataTable("DocumentiCorpo");
            dtDocumentiCorpo = Smartdesk.Sql.getTablePage(strFROMNet, null, "DocumentiCorpo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
            //pagamenti
            strWHERENet="Documenti_Ky=" + strDocumenti_Ky;
            strORDERNet = "Pagamenti_Data";
            strFROMNet = "Pagamenti_Vw";
            dtPagamenti = new DataTable("Pagamenti");
            dtPagamenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
						//blocco l'anagrafica
	          SqlDataAdapter da = new SqlDataAdapter();
	          DataTable dt = new DataTable("getTable");
	         SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
	          SqlCommand cm = new SqlCommand();
	          
	          strSQL = "UPDATE Anagrafiche SET Anagrafiche_Lock=1 WHERE Anagrafiche_Ky=" + dtDocumenti.Rows[0]["Anagrafiche_Ky"].ToString();
	          //Response.Write(strSQL);
	          cm.CommandText = strSQL;
	          cm.CommandType = CommandType.Text;
	          cm.Connection = cn;
	          cm.CommandTimeout = 300;
	          da.SelectCommand = cm;
	          cn.Open();
	          cm.ExecuteNonQuery();
	

          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
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
