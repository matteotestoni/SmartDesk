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
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public System.Data.DataTable dtUtenti;
    public System.Data.DataTable dtDaFareScaduti;
    public System.Data.DataTable dtDaFareAppenaScaduti;
    public System.Data.DataTable dtDaFareProssimi;
    public System.Data.DataTable dtDaFareFuturi;
    public System.Data.DataTable dtGridData;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public string strHtml = "";
    public string strHtmlCorpo = "";
    public string strH1 = "Attivit&agrave; da fare per scadenza";
    public string strWHERENet="";
    public int intNumeroColonne = 0;
    public int intNumeroColonneResponsive = 0;
    public int intNumeroAttivita = 0;
    public DataTable dtCoreGrids;
    public int intCoreEntities_Ky = 79;
    public int intCoreForms_Ky = 1;
    public int intCoreGrids_Ky = 276;
    public int intCoreModules_Ky = 6;
    public bool boolCambioGrid = false;
    public string strViewUrl = "";
    public string strFormUrl = "";
    public DataTable dtCurrentCoreGrids;
    public DataTable dtCoreModules;
    public DataTable dtCoreEntities;
    public string strCommesse_Ky = "";
    public int intRecxPag = 30;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strORDERNet = "";
      string strPage="";
      int intPage = 0;
      
			strPage = Request["page"];
      if ((strPage == null) || (strPage == "")){
        intPage = 1;
      }
      else{
        intPage = Convert.ToInt32(strPage);
      }
      if (Context.Request.Cookies["rswcrm"]!=null){
		  
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          if (dtLogin.Rows.Count>0){
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            boolCambioGrid = (dtLogin.Rows[0]["Utenti_CambioGrid"]).Equals(true);
			      strFROMNet = "Utenti";
			      strWHERENet= getWhereUtenti();
			      strORDERNet = "Utenti_Ky";
			      dtUtenti = new System.Data.DataTable("Utenti");
			      dtUtenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strCommesse_Ky=Request["Commesse_Ky"];
            if (strCommesse_Ky!=null && strCommesse_Ky.Length>0){
              System.Web.HttpCookie myCookie = new System.Web.HttpCookie("attivitaprogetto", strCommesse_Ky);
              myCookie.Expires = DateTime.Now.AddHours(12);
              Response.Cookies.Add(myCookie);            
            }

			      strFROMNet = "Attivita_Vw";
			      strWHERENet= getWhere(4);
			      //Response.Write(strWHERENet);
			      strORDERNet = "Attivita_Scadenza,Anagrafiche_RagioneSociale ASC";
			      dtDaFareScaduti = new System.Data.DataTable("scaduti");
			      dtDaFareScaduti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strFROMNet = "Attivita_Vw";
			      strWHERENet= getWhere(3);
			      strORDERNet = "Attivita_Scadenza,Anagrafiche_RagioneSociale ASC";
			      dtDaFareAppenaScaduti = new System.Data.DataTable("AppenaScaduti");
			      dtDaFareAppenaScaduti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			
			      strFROMNet = "Attivita_Vw";
			      strWHERENet= getWhere(1);
			      strORDERNet = "Attivita_Scadenza,Anagrafiche_RagioneSociale ASC";
			      dtDaFareProssimi = new System.Data.DataTable("prossimi");
			      dtDaFareProssimi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			
			      strFROMNet = "Attivita_Vw";
			      strWHERENet= getWhere(2);
			      strORDERNet = "Attivita_Scadenza,Anagrafiche_RagioneSociale ASC";
			      dtDaFareFuturi = new System.Data.DataTable("futuri");
			      dtDaFareFuturi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

			      strFROMNet = "Attivita_Vw";
			      strWHERENet= getWhere(5);
		        //Response.Write(strWHERENet);
            
			      strORDERNet = "Attivita_Scadenza DESC,Anagrafiche_RagioneSociale ASC";
			      dtGridData = new System.Data.DataTable("Attivita");
			      dtGridData = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
						if (dtGridData.Rows.Count==1){
							this.PaginaSotto.Text = Smartdesk.Grid.getPagination(dtGridData,System.IO.Path.GetFileName(Request.Url.AbsolutePath), intRecxPag,intNumRecords, intPage,Request.QueryString);						            
						}else{
							this.PaginaSotto.Text = Smartdesk.Grid.getPagination(dtGridData,System.IO.Path.GetFileName(Request.Url.AbsolutePath), intRecxPag,intNumRecords, intPage,Request.QueryString);						            
						}            

      		  intCoreGrids_Ky = Convert.ToInt32(Request["CoreGrids_Ky"]);
      		  strWHERENet="(CoreGrids_Ky=" + intCoreGrids_Ky + ")";
      		  strFROMNet = "CoreGrids_Vw";
      		  strORDERNet = "CoreGrids_Ky";
      		  dtCurrentCoreGrids = new DataTable("CurrentCoreGrids");
      		  dtCurrentCoreGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGrids_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            intCoreEntities_Ky=Convert.ToInt32(dtCurrentCoreGrids.Rows[0]["CoreEntities_Ky"].ToString());
            intCoreModules_Ky=Convert.ToInt32(dtCurrentCoreGrids.Rows[0]["CoreModules_Ky"].ToString());
            if (dtCurrentCoreGrids.Rows[0]["CoreForms_Ky"].ToString().Length>0){
              intCoreForms_Ky=Convert.ToInt32(dtCurrentCoreGrids.Rows[0]["CoreForms_Ky"].ToString());
            }
          	strWHERENet="(CoreModules_Ky=" + intCoreModules_Ky + ")";
          	strFROMNet = "CoreModules";
          	strORDERNet = "CoreModules_Ky";
          	dtCoreModules = new DataTable("CoreModules");
          	dtCoreModules = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModules_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          	
            strWHERENet="(CoreEntities_Ky=" + intCoreEntities_Ky + ")";
          	strFROMNet = "CoreEntities";
          	strORDERNet = "CoreEntities_Ky";
          	dtCoreEntities = new DataTable("CoreEntities");
          	dtCoreEntities = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strWHERENet = "(UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString() + ") AND (CoreEntities_Ky=" + intCoreEntities_Ky + ")";
            strFROMNet = "UsergroupsGrids_Vw";
            strORDERNet = "CoreGrids_Default DESC, CoreGrids_Ky";
            dtCoreGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGrids_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          
            if (dtCurrentCoreGrids.Rows[0]["CoreGrids_Custom"].Equals(true)){
              strViewUrl="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreGrids_Ky=" + intCoreGrids_Ky;
            }else{
              strViewUrl="/admin/view.aspx?CoreModules_Ky=" + intCoreModules_Ky + "&CoreEntities_Ky=" + intCoreEntities_Ky + "&CoreGrids_Ky=" + intCoreGrids_Ky + "&custom=0";
            }

          }else{
            Response.Redirect(Smartdesk.Current.LoginPageBack +"?utente=" + Smartdesk.Session.CurrentUser.ToString());
          }
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
		    
    public string renderAttivita(DataRow dtAttivita,string strClass)
    {
	    string strReturn;
        strReturn = "<div id=\"attivita" + dtAttivita["Attivita_Ky"].ToString() + "\" data-attivita=\"" + dtAttivita["Attivita_Ky"].ToString() + "\" class=\"card card-" + strClass + " drag-drop\">";
        strReturn += "<div class=\"card-divider\"><i class=\"fa-duotone " + dtAttivita["AttivitaTipo_Icona"].ToString() + " fa-fw \"></i><small>" + dtAttivita["Attivita_Descrizione"].ToString() + "</small></div>\n";
        strReturn += "<div class=\"card-section\">";
        strReturn += "<div class=\"grid-x\"><div class=\"large-11 medium-10 small-10 cell\">";
        strReturn += "<i class=\"fa-duotone fa-clock fa-fw\"></i>Ore:</i>" + dtAttivita["Attivita_Ore"].ToString() + "<br>\n";
        strReturn += "<span style=\"color:" + dtAttivita["Utenti_Colore"].ToString() + "\"><i class=\"fa-duotone fa-user fa-fw\"></i></i>" + dtAttivita["Utenti_Nominativo"].ToString() + "</span>\n";
        strReturn += "</div><div class=\"large-1 medium-2 small-2 cell\">";
        strReturn += "<a href=\"/admin/app/attivita/actions/attivita-completa.aspx?Utenti_Ky=" + dtAttivita["Utenti_Ky"].ToString() + "&Anagrafiche_Ky=" + dtAttivita["Anagrafiche_Ky"].ToString() + "&Attivita_Ky=" + dtAttivita["Attivita_Ky"].ToString() + "&AttivitaSettore_Ky=" + dtAttivita["AttivitaSettore_Ky"].ToString() + "&Attivita_Completo=1&sorgente=prospetto\" class=\"funzione\" data-tooltip title=\"Segna come completata\"><i class=\"fa-duotone fa-check fa-fw\"></i></a>";
        strReturn += "<a href=\"/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=" + dtAttivita["Attivita_Ky"].ToString() + "&sorgente=prospetto\" data-tooltip title=\"modifica\"><i class=\"fa-duotone fa-pen-to-square fa-fw\"></i></a>";
        strReturn += "</div></div>\n";
        strReturn += "<div style=\"float:left;width:120px\"><i class=\"fa-duotone fa-calendar-days fa-fw\"></i>" + dtAttivita["Attivita_Scadenza_IT"].ToString() + "</div>\n";
        strReturn += "<div style=\"float:left;width:60px\">" + Smartdesk.Functions.getGGDaFare(dtAttivita["ggTrascorsi"].ToString()) + "</div>\n";
        strReturn += "<div style=\"float:left;overflow:hidden\"><a href=\"/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=" + dtAttivita["Anagrafiche_Ky"].ToString() + "&sorgente=prospetto\" class=\"funzione\"><i class=\"fa-duotone fa-user fa-fw\"></i>" + dtAttivita["Anagrafiche_RagioneSociale"].ToString() + "</a></div>\n";
        strReturn += getPriorita(dtAttivita["Priorita_Ky"].ToString());
        if (dtAttivita["Commesse_Ky"].ToString().Length > 0 && dtAttivita["Commesse_Ky"].ToString() != "0")
        {
            strReturn += "<br><i class=\"fa-duotone fa-building fa-fw\"></i><a href=\"/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=" + dtAttivita["Commesse_Ky"].ToString() + "\">" + dtAttivita["Commesse_Riferimenti"].ToString() + "</a>\n";
        }
        strReturn += "</div></div>\n";
        return strReturn;
    }

    public string getWhereUtenti()
    {
        string strWHERE="";
        string strValue="";

        strWHERE="(Utenti_Attivo=1)";
        if (Request.Cookies["attivitautente"]!=null){
          strValue=Request.Cookies["attivitautente"].Value;
        }else{
          strValue="";
        }
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
		      	strWHERE="(Attivita_Completo='no') AND (Attivita_Scadenza>GETDATE()+30)";
						break;
					case 3:
		        strWHERE="(Attivita_Completo='no') AND (Attivita_Scadenza<=GETDATE() AND (Attivita_Scadenza>=GETDATE()-30))";
						break;
					case 4:
		        strWHERE="(Attivita_Completo='no') AND (Attivita_Scadenza<=GETDATE()-30)";
						break;
					case 5:
		        strWHERE="1=1";
						break;
				}
        strValue = Smartdesk.Current.Request("Attivita_Completo");
        if (strValue != null && strValue != ""){
            strWHERE = strWHERE + " AND (Attivita_Completo='" + strValue + "')";
        }else{
        
        }
        if (Request.Cookies["attivitautente"]!=null){
          strValue=Request.Cookies["attivitautente"].Value;
          if (strValue != null && strValue != ""){
              strWHERE = strWHERE + " AND (Utenti_Ky=" + strValue + ")";
  				}
        }       
        if (Request.Cookies["attivitaprogetto"]!=null){
          strValue=Request.Cookies["attivitaprogetto"].Value;
          if (strValue != null && strValue != ""){
              strWHERE = strWHERE + " AND (Commesse_Ky=" + strValue + ")";
          }
        }       

        if (Request.Cookies["attivitastato"]!=null){
          strValue=Request.Cookies["attivitastato"].Value;
          if (strValue != null && strValue != ""){
              strWHERE = strWHERE + " AND (AttivitaStati_Ky=" + strValue + ")";
          }
        }       
        if (Request.Cookies["attivitacategoria"]!=null){
          strValue=Request.Cookies["attivitacategoria"].Value;
          if (strValue != null && strValue != ""){
              strWHERE = strWHERE + " AND (AttivitaCategorie_Ky=" + strValue + ")";
          }
        }       
        if (Request.Cookies["attivitatipo"]!=null){
          strValue=Request.Cookies["attivitatipo"].Value;
          if (strValue != null && strValue != ""){
              strWHERE = strWHERE + " AND (AttivitaTipo_Ky=" + strValue + ")";
          }
        }       
        if (Request.Cookies["attivitasettore"]!=null){
          strValue=Request.Cookies["attivitasettore"].Value;
          if (strValue != null && strValue != ""){
              strWHERE = strWHERE + " AND (AttivitaSettore_Ky=" + strValue + ")";
          }
        }       

        
        strValue = Smartdesk.Current.Request("AttivitaSettore_Ky");
        if (strValue != null && strValue != ""){
            strWHERE = strWHERE + " AND (AttivitaSettore_Ky=" + strValue + ")";
        }
    return strWHERE;
    }
}
