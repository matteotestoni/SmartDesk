using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

public partial class _Default : System.Web.UI.Page 
{
    
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    
    public DataTable dtSitiWeb;
    public int intAnagrafiche_Ky = 0;
    public string strH1 = "";
    public int intRecxPag = 2000;
    public int intPage = 0;
    public int intNumPagine=1;
    public int intNumRecords = 0;
    
    public string strComando = "";

    public string strCampi = "";
    public string AnagraficheTipo_Ky = "";
    public string Anagrafiche_Categorie = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
      string strPage="";

      
	  
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
            //strWHERENet=getWhere();
            strWHERENet="SitiWebTipo_Ky=3 AND SitiWeb_IP='95.110.198.240'";
            strFROMNet = "SitiWeb";
            strORDERNet = "SitiWeb_Dominio ASC";
            dtSitiWeb = new DataTable("SitiWeb");
            dtSitiWeb = Smartdesk.Sql.getTablePage(strFROMNet, null, "SitiWeb_Ky", strWHERENet, strORDERNet, 1,20000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        	strCampi = Request["campi"];
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
        strH1="Anagrafiche";
        strValue = Request["AnagraficheTipo_Ky"];
        
		strValue = Request["AnagraficheTipo_Ky"];
        if (strValue != null && strValue != ""){
            strWHERE = "(AnagraficheTipo_Ky=" + strValue + ")";
        }
    
		strValue = Request["Anagrafiche_Categorie"];
        if (strValue != null && strValue != ""){
			if (strWHERE.Length>0){
				strWHERE+=" And (Anagrafiche_Categorie IN (" + strValue + "))";	
			}else{
				strWHERE="(Anagrafiche_Categorie IN (" + strValue + "))";	
			}
        }
    
		strValue = Request["Province_Ky"];
        if (strValue != null && strValue != ""){
			if (strWHERE.Length>0){
				strWHERE+=" And (Province_Ky=" + strValue + ")";	
			}else{
				strWHERE="(Province_Ky=" + strValue + ")";	
			}
        }

		strValue = Request["Comuni_Ky"];
        if (strValue != null && strValue != ""){
			if (strWHERE.Length>0){
				strWHERE+=" And (Comuni_Ky=" + strValue + ")";	
			}else{
				strWHERE="(Comuni_Ky=" + strValue + ")";	
			}
        }
        return strWHERE;
    }

	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
