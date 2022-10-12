 <%
	System.Data.DataTable dtAttivita;
  string strWHERENet="";
  if (intUtenti_Ky>0){
		strWHERENet="(AttivitaSettore_Ky=1) AND (Attivita_Completo='no') AND Utenti_Ky=" + intUtenti_Ky.ToString();
	}else{
		strWHERENet="(AttivitaSettore_Ky=1) AND (Attivita_Completo='no')";
	}
	string strFROMNet = "Attivita_Vw";
	string strORDERNet = "Attivita_Scadenza DESC";
	dtAttivita = new System.Data.DataTable("Attivita");
	dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1,50,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);   
  if (dtAttivita.Rows.Count>0){        
    dtGridData=dtAttivita;
  %>
			<h2><img src="<%=dtLogin.Rows[0]["Utenti_Logo"].ToString()%>" width="25" height="25" align="left">Per <%=dtLogin.Rows[0]["Utenti_Iniziali"].ToString()%></h2>
			<div class="button-group tiny">
	  		<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new&Utenti_Ky=<%=dtLogin.Rows[0]["Utenti_Ky"].ToString()%>&sorgente=home" class="tiny button clear"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>nuova attivit&agrave;</a>
				<a href="/admin/app/attivita/elenco-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreGrids_Ky=62&AttivitaStati_Aperta=1&Utenti_Ky=<%=dtLogin.Rows[0]["Utenti_Ky"].ToString()%>" class="tiny button clear"><i class="fa-duotone fa-list fa-lg fa-fw"></i>Vai all'elenco</a>
				<a href="/admin/app/attivita/attivita-da-fare.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1&Utenti_Ky=<%=dtLogin.Rows[0]["Utenti_Ky"].ToString()%>" class="tiny button clear"><i class="fa-duotone fa-calendar-star fa-lg fa-fw"></i>Vai al prospetto per scadenza</a>
				<a href="/admin/app/attivita/attivita-da-fare-stato.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1&Utenti_Ky=<%=dtLogin.Rows[0]["Utenti_Ky"].ToString()%>" class="tiny button clear"><i class="fa-duotone fa-square-kanban fa-lg fa-fw"></i>Vai al prospetto per stato</a>
				<a href="/admin/app/attivita/calendario.aspx?Utenti_Ky=<%=dtLogin.Rows[0]["Utenti_Ky"].ToString()%>" class="tiny button clear"><i class="fa-duotone fa-calendar-days fa-lg fa-fw"></i>Vai al calendario</a>
			    <a href="/admin/app/attivita/report/rpt-attivita-planning.aspx?sorgente=home" class="button clear" target="_blank"><i class="fa-duotone fa-print fa-lg fa-fw"></i>Stampa planning</a> 
			</div>
      <!--#include file=/admin/app/attivita/elenco-attivita-grid.inc -->
  <% }else{ 
    Response.Write("Nessuna attivit&agrave;");
  
  }
  %>
