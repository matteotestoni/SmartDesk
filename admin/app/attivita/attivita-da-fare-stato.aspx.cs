using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public int iStati = 0;
    public int iAttivita = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtUtenti;
    public DataTable dtAttivitaStati;
    public DataTable dtAttivitaxStato;
    public DataTable dtDaFareScaduti;
    public DataTable dtDaFareAppenaScaduti;
    public DataTable dtDaFareProssimi;
    public DataTable dtDaFareFuturi;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public string strHtml = "";
    public string strHtmlCorpo = "";
    public string strH1 = "Attivit&agrave; da fare per stato";
    public string strWHERENet="";
    public string strORDERNet = "";
    
    public int intNumeroColonne = 0;
    public int intNumeroColonneResponsive = 0;
    public int intNumeroAttivita = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

      
      if (Context.Request.Cookies["rswcrm"]!=null){
		  
        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
        boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
		    strH1="Attivit&agrave; da fare per stato";
						
  			strFROMNet = "Utenti";
  			strWHERENet= getWhereUtenti();
  			strORDERNet = "Utenti_Ky";
  			dtUtenti = new DataTable("Utenti");
  			dtUtenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strFROMNet = "AttivitaStati";
            strWHERENet = "AttivitaStati_Aperta=1";
            strORDERNet = "AttivitaStati_Ordine";
            dtAttivitaStati = new DataTable("AttivitaStati");
            dtAttivitaStati = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttivitaStati_Ky", strWHERENet, strORDERNet, 1, 2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);


            strFROMNet = "Attivita_Vw";
			strWHERENet= getWhere(4);
			//Response.Write(strWHERENet);
			strORDERNet = "Attivita_Scadenza,Anagrafiche_RagioneSociale ASC";
			dtDaFareScaduti = new DataTable("scaduti");
			dtDaFareScaduti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strFROMNet = "Attivita_Vw";
			strWHERENet= getWhere(3);
			//Response.Write(strWHERENet);
			strORDERNet = "Attivita_Scadenza,Anagrafiche_RagioneSociale ASC";
			dtDaFareAppenaScaduti = new DataTable("AppenaScaduti");
			dtDaFareAppenaScaduti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			
			strFROMNet = "Attivita_Vw";
			strWHERENet= getWhere(1);
			strORDERNet = "Attivita_Scadenza,Anagrafiche_RagioneSociale ASC";
			dtDaFareProssimi = new DataTable("prossimi");
			dtDaFareProssimi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			
			strFROMNet = "Attivita_Vw";
			strWHERENet= getWhere(2);
			strORDERNet = "Attivita_Scadenza,Anagrafiche_RagioneSociale ASC";
			dtDaFareFuturi = new DataTable("futuri");
			dtDaFareFuturi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
		    
    public string renderAttivita(DataRow dtAttivita,string strClass)
    {
	    string strReturn;
        strReturn = "<div id=\"attivita" + dtAttivita["Attivita_Ky"].ToString() + "\" data-attivita=\"" + dtAttivita["Attivita_Ky"].ToString() + "\" class=\"card card-" + strClass + " drag-drop\">";
        strReturn += "<div class=\"card-section\">";
        strReturn += "<div class=\"grid-x\"><div class=\"large-11 medium-10 small-10 cell\">";
        strReturn += "<div><i class=\"fa-duotone " + dtAttivita["AttivitaTipo_Icona"].ToString() + " fa-fw \"></i><small>" + dtAttivita["Attivita_Descrizione"].ToString() + "</small></div>\n";
        strReturn += "<i class=\"fa-duotone fa-clock fa-fw\"></i>Ore:</i>" + dtAttivita["Attivita_Ore"].ToString() + "\n";
        strReturn += "<div style=\"float:left;width:120px\"><i class=\"fa-duotone fa-calendar-days fa-fw\"></i>" + dtAttivita["Attivita_Scadenza_IT"].ToString() + "</div>\n";
        strReturn += "<div style=\"float:left;width:60px\">" + Smartdesk.Functions.getGGDaFare(dtAttivita["ggTrascorsi"].ToString()) + "</div>\n";
        strReturn += "<div style=\"float:left;overflow:hidden\"><a href=\"/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=" + dtAttivita["Anagrafiche_Ky"].ToString() + "&sorgente=prospetto\" class=\"funzione\"><i class=\"fa-duotone fa-user fa-fw\"></i>" + dtAttivita["Anagrafiche_RagioneSociale"].ToString() + "</a></div>\n";
        strReturn += getPriorita(dtAttivita["Priorita_Ky"].ToString());
        if (dtAttivita["Commesse_Ky"].ToString().Length > 0 && dtAttivita["Commesse_Ky"].ToString() != "0")
        {
            strReturn += "<br><i class=\"fa-duotone fa-building fa-fw\"></i><a href=\"/admin/app/progetti/scheda-commesse.aspx?Commesse_Ky=" + dtAttivita["Commesse_Ky"].ToString() + "\">" + dtAttivita["Commesse_Riferimenti"].ToString() + "</a>\n";
        }
        strReturn += "</div><div class=\"large-1 medium-2 small-2 cell\">";
        strReturn += "<a href=\"/admin/app/attivita/actions/attivita-completa.aspx?Anagrafiche_Ky=" + dtAttivita["Anagrafiche_Ky"].ToString() + "&Attivita_Ky=" + dtAttivita["Attivita_Ky"].ToString() + "&AttivitaSettore_Ky=" + dtAttivita["AttivitaSettore_Ky"].ToString() + "&Attivita_Completo=1&sorgente=prospetto\" class=\"funzione\" data-tooltip title=\"Segna come completata\"><i class=\"fa-duotone fa-check fa-fw\"></i></a>";
        strReturn += "<a href=\"/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=" + dtAttivita["Attivita_Ky"].ToString() + "&sorgente=prospetto\" data-tooltip title=\"modifica\"><i class=\"fa-duotone fa-pen-to-square fa-fw\"></i></a>";
        strReturn += "<a href=\"/admin/app/attivita/actions/attivita-cambiastato.aspx?Attivita_Ky=" + dtAttivita["Attivita_Ky"].ToString() + "&AttivitaStati_Ky=" + dtAttivita["AttivitaStati_Ky"].ToString() + "&sorgente=prospetto\" data-tooltip title=\"cambia stato\"><i class=\"fa-duotone fa-arrow-right fa-fw\"></i></a>";
        strReturn += "</div></div>\n";
        strReturn += "</div></div>\n";
        return strReturn;
    }

    public string getWhereUtenti()
    {
        string strWHERE="";
        string strValue="";

        strWHERE="(Utenti_Attivo=1)";
        strValue = Smartdesk.Current.Request("Utenti_Ky");
        if (strValue != null && strValue != ""){
            strWHERE = strWHERE + " AND (Utenti_Ky=" + strValue + ")";
        }else{
            strWHERE = strWHERE + " AND (Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString() + ")";
				}
        return strWHERE;
    }

    public string getPriorita(string strPriorita_Ky){
      string strReturn="";
      int intPriorita_Ky=1;
				if (strPriorita_Ky!=null && strPriorita_Ky.Length>0){
					intPriorita_Ky=Convert.ToInt32(strPriorita_Ky);
					switch (intPriorita_Ky){
						case 1:
		        			strReturn="";
							break;
						case 2:
		        			strReturn="<span class=\"badge warning\"><i class=\"fa-duotone fa-triangle-exclamation-circle fa-fw warning\"></i></span>";
							break;
						case 3:
		        			strReturn="<span class=\"badge alert\"><i class=\"fa-duotone fa-triangle-exclamation-circle fa-fw alert\"></i></span>";
							break;					
					}
				}
			return strReturn;
    }

    public string getWhere(int intTipo)
    {
        string strWHERE="";
        string strValue="";

        strWHERE="";
				switch (intTipo){
					case 1:
		        strWHERE="(Attivita_Completo='no') AND (Attivita_Scadenza>=GETDATE()) AND (Attivita_Scadenza<=GETDATE()+30)";
						break;
					case 2:
		      	strWHERE="(Attivita_Completo='no') AND (Attivita_Scadenza>=GETDATE()+30)";
						break;
					case 3:
		        strWHERE="(Attivita_Completo='no') AND (Attivita_Scadenza<=GETDATE() AND (Attivita_Scadenza>=GETDATE()-30))";
						break;
					case 4:
		        strWHERE="(Attivita_Completo='no') AND (Attivita_Scadenza<=GETDATE()-30)";
						break;
				}
        strValue = Request["Utenti_Ky"];
        if (strValue != null && strValue != ""){
            strWHERE = strWHERE + " AND (Utenti_Ky=" + strValue + ")";
        }else{
            strWHERE = strWHERE + " AND (Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString() + ")";
				}
        strValue = Smartdesk.Current.Request("AttivitaSettore_Ky");
        if (strValue != null && strValue != ""){
            strWHERE = strWHERE + " AND (AttivitaSettore_Ky=" + strValue + ")";
        }
		return strWHERE;
    }
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
