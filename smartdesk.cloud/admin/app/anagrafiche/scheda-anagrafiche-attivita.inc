<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){ %>
<div class="grid-container" id="attivita">   
  <div class="grid-x grid-padding-x">
		<div class="small-12 medium-12 large-12 cell" id="attivita-tabs">
				<div class="card">
				  <div class="card-divider">
		    		<a name="attivita"></a>
							<h2><i class="fa-duotone fa-calendar-days fa-lg fa-fw"></i>Attivit&agrave; (<%=dtAttivitaDaFare.Rows.Count+dtAttivitaCompletateTecniche.Rows.Count%>)</h2>
							<div class="button-group tiny"> 
								<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new&AttivitaTipo_Ky=1&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button secondary"><i class="fa-duotone fa-gear fa-fw"></i> Nuova attivit&agrave; tecnica</a>
								<a href="/admin/app/attivita/actions/segna-attivita-commerciale.aspx?azione=new&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>Fatta attivit&agrave; commerciale</a>
								<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new&AttivitaTipo_Ky=4&AttivitaSettore_Ky=2&Attivita_Trasferta=1&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&sorgente=scheda-anagrafiche&Attivita_Completo=1" class="tiny button warning"><i class="fa-duotone fa-chart-mixed fa-fw"></i> Nuova attivit&agrave; commerciale</a> 
							</div> 
				  </div>
				  <div class="card-section-tabs">
		    	<ul class="horizontal tabs" data-responsive-accordion-tabs="tabs small-accordion medium-tabs large-tabs" role="tablist" id="attivita-tabs">
		    		<li class="tabs-title is-active" role="presentational"><a href="#tabattivita-1"><i class="fa-duotone fa-triangle-exclamation fa-lg fa-fw" style="--fa-primary-color:red;--fa-primary-opacity: 1.0"></i> Attivit&agrave; da fare (<%=dtAttivitaDaFare.Rows.Count%>)</a></li>
		    		<li class="tabs-title" role="presentational"><a href="#tabattivita-2"><i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i> Attivit&agrave; tecniche completate (<%=dtAttivitaCompletateTecniche.Rows.Count%>)</a></li>
		    		<% if (dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(true)){  %>
							<li class="tabs-title" role="presentational"><a href="#tabattivita-3"><i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i> Attivit&agrave; amministrative completate (<%=dtAttivitaCompletateAmministrative.Rows.Count%>)</a></li>
						<% } %>
		    		<% if (dtLogin.Rows[0]["UtentiGruppi_Vendite"].Equals(true)){  %>
			    		<li class="tabs-title" role="presentational"><a href="#tabattivita-4"><i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i> Attivit&agrave; commerciali completate (<%=dtAttivitaCompletateCommerciali.Rows.Count%>)</a></li>
						<% } %>
		    	</ul>
			  	<div class="tabs-content" data-tabs-content="attivita-tabs">
					<div class="tabs-panel is-active" id="tabattivita-1">
					    <% if (dtAttivitaDaFare!=null && dtAttivitaDaFare.Rows.Count>0){ %>
					      <div class="small-12 medium-12">
								<table class="grid hover scroll" border="0" width="100%">
						    	<thead>
					        <tr>
	        		      <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
					          <th width="40" class="text-left">Cod.</th>
					          <th width="300" align="left">Descrizione</th>
					          <th width="120" class="text-center">Progetto</th>
										<th width="110" class="text-center">Scadenza</th>
										<th width="40" class="text-center">gg</th>
										<th width="70" class="text-center">Chiusura</th>
										<th width="60" class="text-center">Ore</th>
										<th width="80" class="text-center">Settore</th>
										<th width="150" class="text-center">Per chi</th>
	        					<th width="60">Utente</th>
										<th width="50" class="text-center nowrap" data-orderable="false"></th>
					        </tr>
						    	</thead>
						    	<tbody>
					        <%for (int i = 0; i < dtAttivitaDaFare.Rows.Count; i++){ %>
					            <tr>
		          		      <td><input type="checkbox" class="checkrow" id="record<%=dtAttivitaDaFare.Rows[i]["Attivita_Ky"].ToString()%>" data-value="<%=dtAttivitaDaFare.Rows[i]["Attivita_Ky"].ToString()%>" /></td>
						            <td class="text-left nowrap"><a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=<%=dtAttivitaDaFare.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtAttivitaDaFare.Rows[i]["Attivita_Ky"].ToString()%></a></td>
					              <td class="text-left nowrap">
													<div class="width200">
													 	<i class="fa-duotone fa-fw <%=dtAttivitaDaFare.Rows[i]["AttivitaTipo_Icona"].ToString()%>"></i>
														<% if (dtAttivitaDaFare.Rows[i]["Priorita_Icona"].ToString().Length>0){ %>
															<i class="fa-duotone <%=dtAttivitaDaFare.Rows[i]["Priorita_Icona"].ToString()%> fa-fw"></i>
													 	<% } %>
														<% if (dtAttivitaDaFare.Rows[i]["Attivita_Trasferta"].Equals(true)){ %>
															<i class="fa-duotone fa-car fa-fw"></i>
													 	<% } %>
														<small><%=dtAttivitaDaFare.Rows[i]["Attivita_Descrizione"].ToString()%></small>
													</div>
												</td>
					              <td class="text-left"><% if (dtAttivitaDaFare.Rows[i]["Commesse_Ky"].ToString().Length>0){ %><a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtAttivitaDaFare.Rows[i]["Commesse_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><i class="fa-duotone fa-circle-info fa-fw" title="<%=dtAttivitaDaFare.Rows[i]["Commesse_Titolo"].ToString()%>"></i><%=dtAttivitaDaFare.Rows[i]["Commesse_Riferimenti"].ToString()%></a><% } %></td>
					              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaDaFare.Rows[i]["Attivita_Scadenza_IT"].ToString()%></td>
			        					<td class="large-text-center small-text-left"><strong><%=Smartdesk.Functions.getGGDaFare(dtAttivitaDaFare.Rows[i]["ggTrascorsi"].ToString())%></strong></td>
					              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaDaFare.Rows[i]["Attivita_Chiusura_IT"].ToString()%></td>
					              <td class="large-text-center small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><%=dtAttivitaDaFare.Rows[i]["Attivita_Ore"].ToString()%></td>
					              <td class="large-text-center small-text-left"><%=dtAttivitaDaFare.Rows[i]["AttivitaSettore_Titolo"].ToString()%></td>
					              <td class="text-center nowrap"><i class="fa-duotone fa-user fa-fw" style="color:<%=dtAttivitaDaFare.Rows[i]["Utenti_Colore"].ToString()%>"></i><%=dtAttivitaDaFare.Rows[i]["Utenti_Nominativo"].ToString()%></td>
	          						<td class="text-center show-for-medium-up"><i class="fa-duotone fa-user-secret fa-fw"></i><%=dtAttivitaDaFare.Rows[i]["Utenti_Iniziali"].ToString()%></td>
					              <td class="text-center nowrap">
													<a href="/admin/app/attivita/actions/attivita-completa.aspx?Anagrafiche_Ky=<%=dtAttivitaDaFare.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaDaFare.Rows[i]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivitaDaFare.Rows[i]["AttivitaSettore_Ky"].ToString()%>&Attivita_Completo=1&sorgente=scheda-anagrafiche" title="completo"><i class="fa-duotone fa-check fa-fw"></i></a>
					              	<a href="/admin/app/attivita/crud/elimina-attivita.aspx?azione=delete&Anagrafiche_Ky=<%=dtAttivitaDaFare.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaDaFare.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
												</td>
					            </tr>
					        <% } %>
						    	</tbody>
					      </table>
					      </div>
					    <% }else{
                 Response.Write("<div class=\"card\"><div class=\"grid-x grid-padding-x\"><div class=\"small-12 large-12 medium-12 cell\"><div class=\"messaggio\">Nessun dato</div></div></div></div>");
					    } %>
			  	</div>
			  	<div class="tabs-panel" id="tabattivita-2">
					    <% if (dtAttivitaCompletateTecniche!=null && dtAttivitaCompletateTecniche.Rows.Count>0){ %>
					      <table class="grid hover scroll" border="0" width="100%">
						    	<thead>
					        <tr>
	        	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
					          <th width="40" class="text-left">Cod.</th>
					          <th width="300" align="left">Descrizione</th>
					          <th width="120" class="text-center">Progetto</th>
										<th width="110" class="text-center">Scadenza</th>
										<th width="110" class="text-center">Chiusura</th>
										<th width="60" class="text-center">Ore</th>
										<th width="80" class="text-center">Settore</th>
										<th width="150" class="text-center">Per chi</th>
	        					<th width="60">Utente</th>
										<th width="50" class="text-center nowrap" data-orderable="false"></th>
					        </tr>
						    	</thead>
						    	<tbody>
					        <%
										decTot=0;
										for (int i = 0; i < dtAttivitaCompletateTecniche.Rows.Count; i++){ %>
					            <tr>
		          		      <td><input type="checkbox" class="checkrow" id="record<%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ky"].ToString()%>" data-value="<%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ky"].ToString()%>" /></td>
						            <td class="text-left nowrap"><a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=<%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ky"].ToString()%></a></td>
					              <td class="text-left nowrap">
													<div class="width300">
													 	<i class="fa-duotone <%=dtAttivitaCompletateTecniche.Rows[i]["AttivitaTipo_Icona"].ToString()%> fa-fw "></i>
														<% if (dtAttivitaCompletateTecniche.Rows[i]["Priorita_Icona"].ToString().Length>0){ %>
															<i class="fa-duotone <%=dtAttivitaCompletateTecniche.Rows[i]["Priorita_Icona"].ToString()%> fa-fw"></i>
													 	<% } %>
													 	<% if (dtAttivitaCompletateTecniche.Rows[i]["Attivita_Trasferta"].Equals(true)){ %>
															<i class="fa-duotone fa-car fa-fw"></i>
													 	<% } %>
														<small><%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Descrizione"].ToString()%></small>
													</div>
												</td>
					              <td class="text-left"><% if (dtAttivitaCompletateTecniche.Rows[i]["Commesse_Ky"].ToString().Length>0){ %><a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtAttivitaCompletateTecniche.Rows[i]["Commesse_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><i class="fa-duotone fa-circle-info fa-fw" title="<%=dtAttivitaCompletateTecniche.Rows[i]["Commesse_Titolo"].ToString()%>"></i><%=dtAttivitaCompletateTecniche.Rows[i]["Commesse_Riferimenti"].ToString()%></a><% } %></td>
					              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Scadenza_IT"].ToString()%></td>
					              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Chiusura_IT"].ToString()%></td>
					              <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ore"].ToString()%></td>
					              <td class="large-text-center small-text-left"><%=dtAttivitaCompletateTecniche.Rows[i]["AttivitaSettore_Titolo"].ToString()%></td>
					              <td class="large-text-center small-text-left"><i class="fa-duotone fa-user fa-fw" style="color:<%=dtAttivitaCompletateTecniche.Rows[i]["Utenti_Colore"].ToString()%>"></i><%=dtAttivitaCompletateTecniche.Rows[i]["Utenti_Nominativo"].ToString()%></td>
	          						<td class="text-center show-for-medium-up"><i class="fa-duotone fa-user-secret fa-fw"></i><%=dtAttivitaCompletateTecniche.Rows[i]["Utenti_Iniziali"].ToString()%></td>
					              <td class="text-center nowrap">
													<a href="/admin/app/attivita/actions/attivita-completa.aspx?Anagrafiche_Ky=<%=dtAttivitaCompletateTecniche.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivitaCompletateTecniche.Rows[i]["AttivitaSettore_Ky"].ToString()%>&Attivita_Completo=0&sorgente=scheda-anagrafiche" title="da fare"><i class="fa-duotone fa-undo fa-fw"></i></a>
					              	<a href="/admin/app/attivita/crud/elimina-attivita.aspx?azione=delete&Anagrafiche_Ky=<%=dtAttivitaCompletateTecniche.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
												</td>
					            </tr>
					        <%
										if (dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ore"]!=System.DBNull.Value){
											decTot+=Convert.ToDecimal(dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ore"]);
										}
										} %>
						    	</tbody>
						    	<tfoot>
							      <tr class="totale">
							        <td class="large-text-right small-text-left" colspan="8">Totali</td>
							        <td class="large-text-right small-text-left" style="padding-right:5px"><i class="fa-duotone fa-clock fa-fw"></i> <%=decTot.ToString("N2", ci)%></td>
							        <td colspan="5"></td>
							      </tr>
				    			</tfoot>
					      </table>
					    <% }else{
                Response.Write("<div class=\"card\"><div class=\"grid-x grid-padding-x\"><div class=\"small-12 large-12 medium-12 cell\"><div class=\"messaggio\">Nessun dato</div></div></div></div>");
					    } %>
			  	</div>
			  	<div class="tabs-panel" id="tabattivita-3">
					    <% if (dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(true) && dtAttivitaCompletateAmministrative!=null && dtAttivitaCompletateAmministrative.Rows.Count>0){ %>
					      <table class="grid hover scroll" border="0" width="100%">
						    	<thead>
					        <tr>
	        	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
					          <th width="40" class="text-left">Cod.</th>
					          <th width="300" align="left">Descrizione</th>
					          <th width="120" class="text-center">Progetto</th>
										<th width="110" class="text-center">Scadenza</th>
										<th width="110" class="text-center">Chiusura</th>
										<th width="60" class="text-center">Ore</th>
										<th width="80" class="text-center">Settore</th>
										<th width="150" class="text-center">Per chi</th>
	        					<th width="60">Utente</th>
										<th width="50" class="text-center nowrap" data-orderable="false"></th>
					        </tr>
						    	</thead>
						    	<tbody>
					        <%
										decTot=0;
										for (int i = 0; i < dtAttivitaCompletateAmministrative.Rows.Count; i++){ %>
					            <tr>
		          		      <td><input type="checkbox" class="checkrow" id="record<%=dtAttivitaCompletateAmministrative.Rows[i]["Attivita_Ky"].ToString()%>" data-value="<%=dtAttivitaCompletateAmministrative.Rows[i]["Attivita_Ky"].ToString()%>" /></td>
						            <td class="text-left nowrap"><a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=<%=dtAttivitaCompletateAmministrative.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtAttivitaCompletateAmministrative.Rows[i]["Attivita_Ky"].ToString()%></a></td>
					              <td class="text-left nowrap">
													<div class="width300">
													 	<i class="fa-duotone <%=dtAttivitaCompletateAmministrative.Rows[i]["AttivitaTipo_Icona"].ToString()%> fa-fw "></i>
														<% if (dtAttivitaCompletateAmministrative.Rows[i]["Priorita_Icona"].ToString().Length>0){ %>
															<i class="fa-duotone <%=dtAttivitaCompletateAmministrative.Rows[i]["Priorita_Icona"].ToString()%> fa-fw"></i>
													 	<% } %>
													 	<% if (dtAttivitaCompletateAmministrative.Rows[i]["Attivita_Trasferta"].Equals(true)){ %>
															<i class="fa-duotone fa-car fa-fw"></i>
													 	<% } %>
														<small><%=dtAttivitaCompletateAmministrative.Rows[i]["Attivita_Descrizione"].ToString()%></small>
													</div>
												</td>
					              <td class="text-left"><% if (dtAttivitaCompletateAmministrative.Rows[i]["Commesse_Ky"].ToString().Length>0){ %><a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtAttivitaCompletateAmministrative.Rows[i]["Commesse_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><i class="fa-duotone fa-circle-info fa-fw" title="<%=dtAttivitaCompletateAmministrative.Rows[i]["Commesse_Titolo"].ToString()%>"></i><%=dtAttivitaCompletateAmministrative.Rows[i]["Commesse_Riferimenti"].ToString()%></a><% } %></td>
					              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaCompletateAmministrative.Rows[i]["Attivita_Scadenza_IT"].ToString()%></td>
					              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaCompletateAmministrative.Rows[i]["Attivita_Chiusura_IT"].ToString()%></td>
					              <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><%=dtAttivitaCompletateAmministrative.Rows[i]["Attivita_Ore"].ToString()%></td>
					              <td class="large-text-center small-text-left"><%=dtAttivitaCompletateAmministrative.Rows[i]["AttivitaSettore_Titolo"].ToString()%></td>
					              <td class="large-text-center small-text-left"><i class="fa-duotone fa-user fa-fw" style="color:<%=dtAttivitaCompletateAmministrative.Rows[i]["Utenti_Colore"].ToString()%>"></i><%=dtAttivitaCompletateAmministrative.Rows[i]["Utenti_Nominativo"].ToString()%></td>
	          						<td class="text-center show-for-medium-up"><i class="fa-duotone fa-user-secret fa-fw"></i><%=dtAttivitaCompletateAmministrative.Rows[i]["Utenti_Iniziali"].ToString()%></td>
					              <td class="text-center nowrap">
													<a href="/admin/app/attivita/actions/attivita-completa.aspx?Anagrafiche_Ky=<%=dtAttivitaCompletateAmministrative.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaCompletateAmministrative.Rows[i]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivitaCompletateAmministrative.Rows[i]["AttivitaSettore_Ky"].ToString()%>&Attivita_Completo=0&sorgente=scheda-anagrafiche" title="da fare"><i class="fa-duotone fa-undo fa-fw"></i></a>
					              	<a href="/admin/app/attivita/crud/elimina-attivita.aspx?azione=delete&Anagrafiche_Ky=<%=dtAttivitaCompletateAmministrative.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaCompletateAmministrative.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
												</td>
					            </tr>
					        <%
										if (dtAttivitaCompletateAmministrative.Rows[i]["Attivita_Ore"]!=System.DBNull.Value){
											decTot+=Convert.ToDecimal(dtAttivitaCompletateAmministrative.Rows[i]["Attivita_Ore"]);
										}
										} %>
						    	</tbody>
						    	<tfoot>
							      <tr class="totale">
							        <td class="large-text-right small-text-left" colspan="8">Totali</td>
							        <td class="large-text-right small-text-left" style="padding-right:5px"><i class="fa-duotone fa-clock fa-fw"></i> <%=decTot.ToString("N2", ci)%></td>
							        <td colspan="6"></td>
							      </tr>
				    			</tfoot>
					      </table>
					    <% }else{
                Response.Write("<div class=\"card\"><div class=\"grid-x grid-padding-x\"><div class=\"small-12 large-12 medium-12 cell\"><div class=\"messaggio\">Nessun dato</div></div></div></div>");
					    } %>
			  	</div>
			  	
					
					<div class="tabs-panel" id="tabattivita-4">
					    <% if (dtLogin.Rows[0]["UtentiGruppi_Vendite"].Equals(true) && dtAttivitaCompletateCommerciali!=null && dtAttivitaCompletateCommerciali.Rows.Count>0){ %>
					      <table class="grid hover scroll" border="0" width="100%">
						    	<thead>
					        <tr>
	        	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
					          <th width="40" class="text-left">Cod.</th>
					          <th width="300" align="left">Descrizione</th>
					          <th width="120" class="text-center">Progetto</th>
										<th width="110" class="text-center">Scadenza</th>
										<th width="110" class="text-center">Chiusura</th>
										<th width="60" class="text-center">Ore</th>
										<th width="80" class="text-center">Settore</th>
										<th width="150" class="text-center">Per chi</th>
	        					<th width="60">Utente</th>
										<th width="50" class="text-center nowrap" data-orderable="false"></th>
					        </tr>
						    	</thead>
						    	<tbody>
					        <%
										decTot=0;
										for (int i = 0; i < dtAttivitaCompletateCommerciali.Rows.Count; i++){ %>
					            <tr>
		          		      <td><input type="checkbox" class="checkrow" id="record<%=dtAttivitaCompletateCommerciali.Rows[i]["Attivita_Ky"].ToString()%>" data-value="<%=dtAttivitaCompletateCommerciali.Rows[i]["Attivita_Ky"].ToString()%>" /></td>
						            <td class="text-left nowrap"><a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=<%=dtAttivitaCompletateCommerciali.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtAttivitaCompletateCommerciali.Rows[i]["Attivita_Ky"].ToString()%></a></td>
					              <td class="text-left nowrap">
													<div class="width300">
													 	<i class="fa-duotone <%=dtAttivitaCompletateCommerciali.Rows[i]["AttivitaTipo_Icona"].ToString()%> fa-fw "></i>
														<% if (dtAttivitaCompletateCommerciali.Rows[i]["Priorita_Icona"].ToString().Length>0){ %>
															<i class="fa-duotone <%=dtAttivitaCompletateCommerciali.Rows[i]["Priorita_Icona"].ToString()%> fa-fw"></i>
													 	<% } %>
													 	<% if (dtAttivitaCompletateCommerciali.Rows[i]["Attivita_Trasferta"].Equals(true)){ %>
															<i class="fa-duotone fa-car fa-fw"></i>
													 	<% } %>
														<small><%=dtAttivitaCompletateCommerciali.Rows[i]["Attivita_Descrizione"].ToString()%></small>
													</div>
												</td>
					              <td class="text-left"><% if (dtAttivitaCompletateCommerciali.Rows[i]["Commesse_Ky"].ToString().Length>0){ %><a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtAttivitaCompletateCommerciali.Rows[i]["Commesse_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><i class="fa-duotone fa-circle-info fa-fw" title="<%=dtAttivitaCompletateCommerciali.Rows[i]["Commesse_Titolo"].ToString()%>"></i><%=dtAttivitaCompletateCommerciali.Rows[i]["Commesse_Riferimenti"].ToString()%></a><% } %></td>
					              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaCompletateCommerciali.Rows[i]["Attivita_Scadenza_IT"].ToString()%></td>
					              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaCompletateCommerciali.Rows[i]["Attivita_Chiusura_IT"].ToString()%></td>
					              <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><%=dtAttivitaCompletateCommerciali.Rows[i]["Attivita_Ore"].ToString()%></td>
					              <td class="large-text-center small-text-left"><%=dtAttivitaCompletateCommerciali.Rows[i]["AttivitaSettore_Titolo"].ToString()%></td>
					              <td class="large-text-center small-text-left"><i class="fa-duotone fa-user fa-fw" style="color:<%=dtAttivitaCompletateCommerciali.Rows[i]["Utenti_Colore"].ToString()%>"></i><%=dtAttivitaCompletateCommerciali.Rows[i]["Utenti_Nominativo"].ToString()%></td>
	          						<td class="text-center show-for-medium-up"><i class="fa-duotone fa-user-secret fa-fw"></i><%=dtAttivitaCompletateCommerciali.Rows[i]["Utenti_Iniziali"].ToString()%></td>
					              <td class="text-center nowrap">
													<a href="/admin/app/attivita/actions/attivita-completa.aspx?Anagrafiche_Ky=<%=dtAttivitaCompletateCommerciali.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaCompletateCommerciali.Rows[i]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivitaCompletateCommerciali.Rows[i]["AttivitaSettore_Ky"].ToString()%>&Attivita_Completo=0&sorgente=scheda-anagrafiche" title="da fare"><i class="fa-duotone fa-undo fa-fw"></i></a>
					              	<a href="/admin/app/attivita/crud/elimina-attivita.aspx?azione=delete&Anagrafiche_Ky=<%=dtAttivitaCompletateCommerciali.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaCompletateCommerciali.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
												</td>
					            </tr>
					        <%
										if (dtAttivitaCompletateCommerciali.Rows[i]["Attivita_Ore"]!=System.DBNull.Value){
											decTot+=Convert.ToDecimal(dtAttivitaCompletateCommerciali.Rows[i]["Attivita_Ore"]);
										}
										} %>
						    	</tbody>
						    	<tfoot>
							      <tr class="totale">
							        <td class="large-text-right small-text-left" colspan="8">Totali</td>
							        <td class="large-text-right small-text-left" style="padding-right:5px"><i class="fa-duotone fa-clock fa-fw"></i> <%=decTot.ToString("N2", ci)%></td>
							        <td colspan="5"></td>
							      </tr>
				    			</tfoot>
					      </table>
					    <% }else{
                Response.Write("<div class=\"card\"><div class=\"grid-x grid-padding-x\"><div class=\"small-12 large-12 medium-12 cell\"><div class=\"messaggio\">Nessun dato</div></div></div></div>");
					    } %>
			  	</div>
			  </div>
			</div>
			</div>
		</div>
	</div>
</div>
<% } %>
