 <%
	System.Data.DataTable dtAttivita;
  string strWHERENet="";
  if (intUtenti_Ky>0){
		strWHERENet="(AttivitaSettore_Ky=1) AND (Attivita_Completo='no') AND Utenti_Ky=" + intUtenti_Ky.ToString();
	}else{
		strWHERENet="(AttivitaSettore_Ky=1) AND (Attivita_Completo='no')";
	}
	string strFROMNet = "Attivita_Vw";
	string strORDERNet = "Utenti_Nominativo, Attivita_Scadenza, Anagrafiche_RagioneSociale ASC";
	dtAttivita = new System.Data.DataTable("Attivita");
	dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);   
  if (dtAttivita.Rows.Count>0){        
        for (int i = 0; i < dtAttivita.Rows.Count; i++){
        	if (intUtenti_Ky!=Convert.ToInt32(dtAttivita.Rows[i]["Utenti_Ky"]) || i==0 ){
        	if (i>1){
        	%>
        		</tbody>
        		<tfoot>
        			<tr class="totale">
        	      <td colspan="9" class="text-right">Totale attivit&agrave; da fare: <strong><%=decTot.ToString("N0", ci)%></strong></td>
        	      <td></td>
        	    </tr>
        		</tfoot>
        		</table>
        	<% } %>
        <div class="card">					
          <div class="card-divider">
        			<h2><img src="<%=dtAttivita.Rows[i]["Utenti_Logo"].ToString()%>" width="25" height="25" align="left">Per <%=dtAttivita.Rows[i]["Utenti_Nominativo"].ToString()%></h2>
        			<div class="button-group tiny">
        	  		<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new&Utenti_Ky=<%=dtAttivita.Rows[i]["Utenti_Ky"].ToString()%>&sorgente=home" class="tiny button clear"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>nuova attivit&agrave;</a>
        				<a href="/admin/app/attivita/elenco-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreGrids_Ky=62&Utenti_Ky=<%=dtAttivita.Rows[i]["Utenti_Ky"].ToString()%>" class="tiny button clear"><i class="fa-duotone fa-list fa-lg fa-fw"></i>Vai all'elenco</a>
        				<a href="/admin/app/attivita/attivita-da-fare.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1&Utenti_Ky=<%=dtAttivita.Rows[i]["Utenti_Ky"].ToString()%>" class="tiny button clear"><i class="fa-duotone fa-calendar-star fa-lg fa-fw"></i>Vai al prospetto per scadenza</a>
        				<a href="/admin/app/attivita/attivita-da-fare-stato.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1&Utenti_Ky=<%=dtAttivita.Rows[i]["Utenti_Ky"].ToString()%>" class="tiny button clear"><i class="fa-duotone fa-square-kanban fa-lg fa-fw"></i>Vai al prospetto per stato</a>
        				<a href="/admin/app/attivita/calendario.aspx?Utenti_Ky=<%=dtAttivita.Rows[i]["Utenti_Ky"].ToString()%>" class="tiny button clear"><i class="fa-duotone fa-calendar-days fa-lg fa-fw"></i>Vai al calendario</a>
        			    <a href="/admin/app/attivita/report/rpt-attivita-planning.aspx?sorgente=home" class="button clear" target="_blank"><i class="fa-duotone fa-print fa-lg fa-fw"></i>Stampa planning</a> 
        			</div>
        	</div>
        	<div class="card-section">
        					<div class="divgridcard">
        					<table class="grid hover scroll" border="0" width="100%" style="width:100%">
        		    	<thead>
        			      <tr>
            					<th width="40" class="text-left">Cod.</th>
                      <th width="200" class="text-left">Anagrafica</th>
                      <th width="200">Descrizione</th>
        		          <th width="250" class="small-text-left large-text-center">Progetto</th>
                      <th width="180" class="small-text-left large-text-center">Scadenza</th>
                      <th width="60" class="small-text-left large-text-center">gg</th>
                      <th width="60" class="small-text-left large-text-center">Ore</th>
                      <th width="12" class="nowrap"></th>
                      <th width="12" class="nowrap"></th>
        			      </tr>
        		    	</thead>
        					<tbody>
                  <%
                  decTot=0;
              	} %>
                <tr class="riga<%=i%2%>">
                	<td class="small-text-left large-text-left show-for-medium-up"><a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=home"><%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%></a></td>
                  <td>
                    <div class="width200">
        							<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtAttivita.Rows[i]["Anagrafiche_Ky"].ToString()%>">
                        <i class="fa-duotone fa-users fa-fw"></i><%=dtAttivita.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a> 
                    </div>
                  </td>
                  <td>
                  	<div class="width400">
                    <i class="fa-duotone fa-fw <%=dtAttivita.Rows[i]["AttivitaTipo_Icona"].ToString()%>"></i>
        						<%
                      Response.Write(dtAttivita.Rows[i]["Attivita_Descrizione"].ToString());
                    %>
                    </div>
                  </td>
                  <td class="small-text-left large-text-center"><% if (dtAttivita.Rows[i]["Commesse_Ky"].ToString().Length>0){ %><a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtAttivita.Rows[i]["Commesse_Ky"].ToString()%>&sorgente=home"><i class="fa-duotone fa-circle-info fa-fw has-tip" data-tooltip title="<%=dtAttivita.Rows[i]["Commesse_Titolo"].ToString()%>"></i><%=dtAttivita.Rows[i]["Commesse_Riferimenti"].ToString()%></a><% } %></td>
                  <td class="small-text-left large-text-center"><i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtAttivita.Rows[i]["Attivita_Scadenza"].ToString()%></strong></td>
                  <td class="small-text-left large-text-center"><strong><%=Smartdesk.Functions.getGGDaFare(dtAttivita.Rows[i]["ggTrascorsi"].ToString())%></strong></td>
                  <td class="small-text-left large-text-center"><i class="fa-duotone fa-clock fa-fw"></i><%=dtAttivita.Rows[i]["Attivita_Ore"].ToString()%></strong></td>
        		  <td class="show-for-medium-up small-text-left large-text-center nowrap"><a href="/admin/app/attivita/actions/attivita-completa.aspx?Anagrafiche_Ky=<%=dtAttivita.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivita.Rows[i]["AttivitaSettore_Ky"].ToString()%>&Attivita_Completo=1&sorgente=home" title="completo"><i class="fa-duotone fa-check fa-lg"></i></a></td>
                	<td class="show-for-medium-up small-text-left large-text-center nowrap"><a href="/admin/app/attivita/crud/elimina-attivita.aspx?Anagrafiche_Ky=<%=dtAttivita.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivita.Rows[i]["AttivitaSettore_Ky"].ToString()%>&sorgente=home" title="elimina"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
                </tr>
            <%
        			decTot+=1;
              intUtenti_Ky=Convert.ToInt32(dtAttivita.Rows[i]["Utenti_Ky"].ToString());
            } %>
        		</tbody>
        		<tfoot>
        			<tr class="totale">
                <td colspan="8" class="text-right">Totale attivit&agrave; da fare: <strong><%=decTot.ToString("N0", ci)%></strong></td>
                <td></td>
              </tr>
        		</tfoot>
        	</table>
        	</div>
        </div>
        </div>
  <% }else{ 
    Response.Write("Nessuna attivit&agrave;");
  
  }
  %>
