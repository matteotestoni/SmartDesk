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
    public DataTable dtAnagrafiche;
    public int intAnagrafiche_Ky = 0;
    public string strH1 = "Esporta anagrafiche";
    public int intRecxPag = 2000;
    public int intPage = 0;
    public int intNumPagine=1;
    public int intNumRecords = 0;
    

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
          //Response.Write(strWHERENet);
          strFROMNet = "Anagrafiche_Vw";
          strORDERNet = "Anagrafiche_Ky DESC";
          dtAnagrafiche = new DataTable("Anagrafiche");
          dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        	strCampi = Request["campi"];
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
			strValue="'" + strValue.Replace(",","','") + "'";
			if (strWHERE.Length>0){
				strWHERE+=" And (Anagrafiche_Categorie IN (" + strValue + "))";	
			}else{
				strWHERE="(Anagrafiche_Categorie IN (" + strValue + "))";	
			}
        }
    
		strValue = Request["Nazioni_Ky"];
        if (strValue != null && strValue != ""){
			if (strWHERE.Length>0){
				strWHERE+=" And (Nazioni_Ky=" + strValue + ")";	
			}else{
				strWHERE="(Nazioni_Ky=" + strValue + ")";	
			}
        }
		strValue = Request["Regioni_Ky"];
        if (strValue != null && strValue != ""){
			if (strWHERE.Length>0){
				strWHERE+=" And (Regioni_Ky=" + strValue + ")";	
			}else{
				strWHERE="(Regioni_Ky=" + strValue + ")";	
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
			strValue = Request["Anagrafiche_DateInsert"];
      if (strValue != null && strValue != ""){
					if (strWHERE.Length>0){
						strWHERE+=" And (Anagrafiche_DateInsert>='" + strValue + "')";	
					}else{
						strWHERE="(Anagrafiche_DateInsert>='" + strValue + "')";	
					}
      }
			strValue = Request["Anagrafiche_CodiceDestinatario"];
      if (strValue != null && strValue != ""){
					if (strWHERE.Length>0){
						strWHERE+=" And (Anagrafiche_CodiceDestinatario Is Not Null AND Len(Anagrafiche_CodiceDestinatario)>0)";	
					}else{
						strWHERE="(Anagrafiche_CodiceDestinatario Is Not Null AND Len(Anagrafiche_CodiceDestinatario)>0)";	
					}
      }

        return strWHERE;
    }
}
