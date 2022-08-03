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
    public DataTable dtProdotti;
    public string strH1 = "";
    public int intRecxPag = 50;
    public int intNumPagine=1;
    public int intPage = 0;
    public int intNumRecords = 0;
    
    
    public string strAnagrafiche_Ky="";
    public string strDocumenti_Ky="";

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
            strAnagrafiche_Ky = Smartdesk.Current.Request("Anagrafiche_Ky");
            strDocumenti_Ky = Smartdesk.Current.Request("Documenti_Ky");
            if ((strPage == null) || (strPage == "")){
              intPage = 1;
            }
            else{
              intPage = Convert.ToInt32(strPage);
            }
            strWHERENet=getWhere();
            strFROMNet = "Prodotti_Vw";
            strORDERNet = "Prodotti_Ordine ASC, Prodotti_Ky DESC";
            dtProdotti = new DataTable("Prodotti");
            dtProdotti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Prodotti_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
        		intNumPagine = intNumRecords / intRecxPag;
		        if ((intNumRecords % intRecxPag) != 0)
		        {
		            intNumPagine += 1;
		        }
		        if (intNumPagine == 0){
		          intNumPagine = 1;
		        }
		        
						//prima
						if ((intNumPagine > 1) && (intPage!=1)){
		            strPagineSotto = "<a href=\"/admin/app/catalogo/elenco-prodotti.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66&page=1\" rel=\"nofollow\" class=\"button\"><i class=\"fa-duotone fa-step-backward fa-fw\"></i></a>";
		        }
						//precedente
						if ((intNumPagine > 1) && (intPage!=1)){
		            strPagineSotto += "<a href=\"/admin/app/catalogo/elenco-prodotti.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66&page=" + (intPage-1) + "\" rel=\"nofollow\" class=\"button\"><i class=\"fa-duotone fa-backward fa-fw\"></i></a>";
		        }
		      	//indicazione pagine
      			strPagineSotto += "&nbsp;Pagina " + intPage + " di " + intNumPagine + "&nbsp;";
						if ((intNumPagine > 1) && (intNumPagine<=10)){
				        for (i = 1; i <= intNumPagine; i++){
	                strPagineSotto += "<a href=\"/admin/app/catalogo/elenco-prodotti.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66&page=" + i + "\" class=\"button\" rel=\"nofollow\">" + i + "</a>";
				        }
				    }
						if ((intNumPagine > 1) && (intNumPagine>intPage)){
		            strPagineSotto += "<a href=\"/admin/app/catalogo/elenco-prodotti.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66&page=" + (intPage+1) + "\" rel=\"nofollow\" class=\"button\"><i class=\"fa-duotone fa-forward fa-fw\"></i></a>";
		        }
		        if ((intNumPagine > 1) && (intPage!=intNumPagine))
		        {
		          strPagineSotto += "<a href=\"/admin/app/catalogo/elenco-prodotti.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66&page=" + intNumPagine.ToString() + "\" rel=\"nofollow\" class=\"button\"><i class=\"fa-duotone fa-forward fa-fw\"></i></a>";
		        }
		        if ((intNumRecords > 0) && (intNumPagine>1))
		        {
		           this.PaginaSotto.Text = strPagineSotto;
		        }
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public string getStato(Boolean boolValue, string strCampo, string strColor,string strProdotti_Ky){
    string strReturn;
    string strClass;
			if (strColor!=null){
			  strClass="check-" + strColor;
			}else{
			  strClass="check";
			}
			if (boolValue){
			  strReturn="<a href=\"/admin/app/documenti/actions/prodotto-check.aspx?sorgente=scheda-documenti&valore=0&Prodotti_Ky=" + strProdotti_Ky + "&elenco&campo=" + strCampo + "\" class=\"" + strClass + "\">-" + strCampo + "</a>";
			}else{
			  strReturn="<a href=\"/admin/app/documenti/actions/prodotto-check.aspx?sorgente=scheda-documenti&valore=1&Prodotti_Ky=" + strProdotti_Ky + "&elenco&campo=" + strCampo + "\" class=\"check-disabled\">+" + strCampo + "</a>";
			}
			return strReturn;
	  }

    public string getWhere()
    {
        string strWHERE="";
        string strValue="";

        strWHERE="";
        strH1="Aggiungi prodotto a documento";
        strValue = Request["invetrina"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Prodotti_InVetrina=1)";
            strH1="Prodotti: in vetrina";
        }
        strValue = Request["inofferta"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Prodotti_InOfferta=1)";
            strH1="Prodotti: in offerta";
        }
        strValue = Request["inpromozione"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Prodotti_InPromozione=1)";
            strH1="Prodotti: in promozione";
        }
        strValue = Request["outlet"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Prodotti_Outlet=1)";
            strH1="Prodotti: outlet";
        }
        
        strValue = Request["ricercatitolo"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Prodotti_Titolo like '%" + strValue + "%')";
            strH1="Prodotti per titolo: " + strValue;
        }
        strValue = Request["ricercacodice"];
        if (strValue != null && strValue != ""){
            strWHERE = "(Prodotti_Codice like '%" + strValue + "%')";
            strH1="Prodotti per codice: " + strValue;
        }
        strValue = Request["tutti"];
        if (strValue != null && strValue != ""){
            strWHERE = "";
            strH1="Prodotti: tutti";
        }
        return strWHERE;
    }    
}
