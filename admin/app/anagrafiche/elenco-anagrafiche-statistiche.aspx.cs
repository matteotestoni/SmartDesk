using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;


public partial class _Default : System.Web.UI.Page 
{
    
    public int i = 0;
    public System.Globalization.CultureInfo ciit = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo cien = new System.Globalization.CultureInfo("en-US");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtAnagrafiche;
    public int intAnagrafiche_Ky = 0;
    public string strH1 = "Statistiche anagrafiche";
    public int intRecxPag = 20;
    public int intPage = 0;
    public int intNumPagine=1;
    public int intNumRecords = 0;
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
      string strPage="";
      string strPagineSotto = "";

      
			
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
        		strH1="Stastistiche delle anagrafiche";
            strWHERENet="";
            strFROMNet = "Anagrafiche_Statistiche_Vw";
            strORDERNet = "Anagrafiche_Ky DESC";
            dtAnagrafiche = new DataTable("Anagrafiche");
            dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, intPage,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
						if (dtAnagrafiche.Rows.Count==1){
							Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=" + dtAnagrafiche.Rows[0]["Anagrafiche_Ky"].ToString());
						}else{
		        		intNumPagine = intNumRecords / intRecxPag;
				        if ((intNumRecords % intRecxPag) != 0)
				        {
				            intNumPagine += 1;
				        }
				        if (intNumPagine == 0){
				          intNumPagine = 1;
				        }
								if ((intNumPagine > 1) && (intPage!=1)){
				            strPagineSotto = "<a href=\"/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198&page=1\" rel=\"nofollow\" class=\"button\"><i class=\"fa-duotone fa-step-backward fa-fw\"></i></a>";
				        }
								if ((intNumPagine > 1) && (intPage!=1)){
				            strPagineSotto += "<a href=\"/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198&page=" + (intPage-1) + "\" rel=\"nofollow\" class=\"button\"><i class=\"fa-duotone fa-backward fa-fw\"></i></a>";
				        }
		      			strPagineSotto += "&nbsp;Pagina " + intPage + " di " + intNumPagine + "&nbsp;";
								if ((intNumPagine > 1) && (intNumPagine<=10)){
						        for (i = 1; i <= intNumPagine; i++){
			                strPagineSotto += "<a href=\"/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198&page=" + i + "\" class=\"button\" rel=\"nofollow\">" + i + "</a>";
						        }
						    }
								if ((intNumPagine > 1) && (intNumPagine>intPage)){
				            strPagineSotto += "<a href=\"/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198&page=" + (intPage+1) + "\" rel=\"nofollow\" class=\"button\"><i class=\"fa-duotone fa-forward fa-fw\"></i></a>";
				        }
				        if ((intNumPagine > 1) && (intPage!=intNumPagine))
				        {
				          strPagineSotto += "<a href=\"/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198&page=" + intNumPagine.ToString() + "\" rel=\"nofollow\" class=\"button\"><i class=\"fa-duotone fa-step-forward fa-fw\"></i></a>";
				        }
				        if ((intNumRecords > 0) && (intNumPagine>1))
				        {
				           //this.PaginaSotto.Text = strPagineSotto;
				        }
						}            

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
        strH1="Stastistiche delle anagrafiche";
        strValue = Request["lettera"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Anagrafiche_RagioneSociale like '" + strValue + "%')";
            strH1="Anagrafiche: per lettera";
        }
        strValue = Request["Anagrafiche_RagioneSociale"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Anagrafiche_RagioneSociale like '%" + strValue + "%') Or (Anagrafiche_ParoleChiave like '%" + strValue + "%')";
            strH1="Anagrafiche: " + strValue;
        }
        strValue = Request["Province_Ky"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Province_Ky=" + strValue + ")";
            strH1="Anagrafiche: " + strValue;
        }
        strValue = Request["Anagrafiche_Telefono"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Anagrafiche_Telefono like '%" + strValue + "%')";
            strH1="Anagrafiche: " + strValue;
        }
        strValue = Request["AnagraficheTipo_Ky"];
        if (strValue != null && strValue != ""){
            strWHERE = "(AnagraficheTipo_Ky=" + strValue + ")";
            strH1="Anagrafiche: " + strValue;
        }
        strValue = Request["Anagrafiche_Categorie"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Anagrafiche_Categorie (" + strValue + "))";
            strH1="Anagrafiche: " + strValue;
        }
        strValue = Request["tutti"];
        if (strValue != null && strValue != ""){
            strWHERE = "";
            strH1="Anagrafiche: tutto";
        }
        //Response.Write(strWHERE);
        return strWHERE;
    }
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
