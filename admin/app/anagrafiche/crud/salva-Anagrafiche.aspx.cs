using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    
    public DataTable dtAnagrafiche;
    public int intNumRecords = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        bool boolAjax = false;
        string strJson = "";
        string strAnagrafiche_RagioneSociale="";
        string strSQL = "";
        
        //if (Smartdesk.Login.Verify){
          Dictionary<string, object> frm = new Dictionary<string, object>();
        	if (Smartdesk.Current.Request("Anagrafiche_Default") == "") frm.Add("Anagrafiche_Default", false);
          if (Smartdesk.Current.Request("Anagrafiche_Newsletter") == "") frm.Add("Anagrafiche_Newsletter", false);
          if (Smartdesk.Current.Request("Anagrafiche_Disdetto") == "") frm.Add("Anagrafiche_Disdetto", false);
          if (Smartdesk.Current.Request("Anagrafiche_Attivo") == "") frm.Add("Anagrafiche_Attivo", false);
          if (Smartdesk.Current.Request("Anagrafiche_Privacy") == "") frm.Add("Anagrafiche_Privacy", false);
          boolAjax = Convert.ToBoolean(Request["ajax"]);
          strKy = Smartdesk.Functions.SqlWriteKey("Anagrafiche", frm);
      	  strSQL="UPDATE Anagrafiche SET Anagrafiche_RagioneSociale=Anagrafiche_Cognome + ' ' + Anagrafiche_Nome WHERE Anagrafiche_Ky=" + strKy + " AND (Anagrafiche_RagioneSociale Is Null OR LEN(Anagrafiche_RagioneSociale)=0)";
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
       	  strSQL="UPDATE Anagrafiche SET AnagraficheTipologia_Ky=1 WHERE Anagrafiche_Ky=" + strKy + " AND (AnagraficheTipologia_Ky Is Null Or AnagraficheTipologia_Ky=0)";
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
         dtAnagrafiche = Smartdesk.Data.Read("Anagrafiche", "Anagrafiche_Ky", strKy);
          if (boolAjax==true){
            strJson="{\"Anagrafiche_Ky\": " + strKy + ",\"Anagrafiche_RagioneSociale\":\"" + dtAnagrafiche.Rows[0]["Anagrafiche_RagioneSociale"].ToString() + "\",\"Anagrafiche_Nome\":\"" + dtAnagrafiche.Rows[0]["Anagrafiche_Nome"].ToString() + "\",\"Anagrafiche_Cognome\":\"" + dtAnagrafiche.Rows[0]["Anagrafiche_Cognome"].ToString() + "\",\"Anagrafiche_Telefono\":\"" + dtAnagrafiche.Rows[0]["Anagrafiche_Telefono"].ToString() + "\",\"Anagrafiche_EmailContatti\":\"" + dtAnagrafiche.Rows[0]["Anagrafiche_EmailContatti"].ToString() + "\",\"Anagrafiche_Privacy\":\"" + dtAnagrafiche.Rows[0]["Anagrafiche_Privacy"].ToString() + "\",\"AnagraficheTipologia_Ky\":\"" + dtAnagrafiche.Rows[0]["AnagraficheTipologia_Ky"].ToString() + "\",\"AnagraficheTipo_Ky\":\"" + dtAnagrafiche.Rows[0]["AnagraficheTipo_Ky"].ToString() + "\"}";
            Response.Write(strJson);
          }else{
            strRedirect = "/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=36";
            strRedirect = "/admin/app/anagrafiche/scheda-anagrafiche.aspx?salvato=salvato&Anagrafiche_Ky=" + strKy;
            Response.Redirect(strRedirect);
          }
        //}
        //Response.Redirect(strRedirect);
    }

    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
