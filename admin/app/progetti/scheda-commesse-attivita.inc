<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
  <a name="attivita"></a>
	<br>
	<div class="card">
	  <div class="card-divider">
			<h2><i class="fa-duotone fa-calendar-days fa-lg fa-fw"></i>Attivit&agrave;</h2>
			<div class="button-group tiny">
				<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new&Commesse_Ky=<%=GetFieldValue(dtCommesse, "Commesse_Ky")%>&Anagrafiche_Ky=<%=GetFieldValue(dtCommesse, "Anagrafiche_Ky")%>&sorgente=scheda-commessa" type="button" class="button secondary tiny"><i class="fa-duotone fa-square-plus fa-fw"></i>nuova attivit&agrave;</a>
    	</div>    
		</div>
	  <div class="card-section">
	    	<ul class="tabs" data-responsive-accordion-tabs="tabs small-accordion medium-tabs large-tabs" role="tablist" id="attivita-tabs">
	    		<li class="tabs-title is-active" role="presentational"><a href="#tabattivita-1"><i class="fa-duotone fa-triangle-exclamation fa-lg fa-fw" style="--fa-primary-color:red;--fa-primary-opacity: 1.0"></i> Attivit&agrave; da fare (<%=dtAttivitaDaFare.Rows.Count%>)</a></li>
	    		<li class="tabs-title" role="presentational"><a href="#tabattivita-2"><i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i> Attivit&agrave; tecniche completate (<%=dtAttivitaCompletateTecniche.Rows.Count%>)</a></li>
	    		<% if (dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(true)){  %>
						<li class="tabs-title" role="presentational"><a href="#tabattivita-3"><i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i> Attivit&agrave; amministrative completate (<%=dtAttivitaCompletateAmministrative.Rows.Count%>)</a></li>
					<% } %>
	    	</ul>
		  	<div class="tabs-content" data-tabs-content="attivita-tabs">
				<div class="tabs-panel is-active" id="tabattivita-1" aria-selected="true">
							<table class="grid hover scroll" border="0" width="100%">
					    	<thead>
				        <tr>
                  <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
                  <th width="40" class="text-left">Cod.</th>
                  <th width="400" align="left">Descrizione</th>
									<th width="80" align="center">Priorit&agrave;</th>
									<th width="110" align="center">Scadenza</th>
									<th width="40" align="center">gg</th>
									<th width="100" align="center">Ore</th>
									<th width="80" align="center">Settore</th>
									<th width="150" align="center">Per chi</th>
									<th width="60" class="text-center nowrap"></th>
				        </tr>
					    	</thead>
					    	<tbody>
				        <%for (int i = 0; i < dtAttivitaDaFare.Rows.Count; i++){ %>
				            <tr>
                                <td><input type="checkbox" class="checkrow" id="record<%=dtAttivitaDaFare.Rows[i]["Attivita_Ky"].ToString()%>" data-value="<%=dtAttivitaDaFare.Rows[i]["Attivita_Ky"].ToString()%>" /></td>
					            <td class="text-left nowrap"><a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=<%=dtAttivitaDaFare.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-commessa"><%=dtAttivitaDaFare.Rows[i]["Attivita_Ky"].ToString()%></a></td>
				              <td class="text-left nowrap">
												<div class="width400">
												 	<i class="fa-duotone fa-fw <%=dtAttivitaDaFare.Rows[i]["AttivitaTipo_Icona"].ToString()%>"></i>
												 	<% if (dtAttivitaDaFare.Rows[i]["Attivita_Trasferta"].Equals(true)){ %>
														<i class="fa-duotone fa-car fa-fw"></i>
												 	<% } %>
													<%=dtAttivitaDaFare.Rows[i]["Attivita_Descrizione"].ToString()%>
												</div>
											</td>
				              <td class="large-text-center small-text-left"><%=dtAttivitaDaFare.Rows[i]["Priorita_Descrizione"].ToString()%></td>
				              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaDaFare.Rows[i]["Attivita_Scadenza_IT"].ToString()%></td>
		        					<td class="large-text-center small-text-left"><strong><%=Smartdesk.Functions.getGGDaFare(dtAttivitaDaFare.Rows[i]["ggTrascorsi"].ToString())%></strong></td>
				              <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><%=dtAttivitaDaFare.Rows[i]["Attivita_Ore"].ToString()%></td>
				              <td class="large-text-center small-text-left"><%=dtAttivitaDaFare.Rows[i]["AttivitaSettore_Titolo"].ToString()%></td>
				              <td class="text-left"><i class="fa-duotone fa-user fa-fw" style="color:<%=dtAttivitaDaFare.Rows[i]["Utenti_Colore"].ToString()%>"></i><%=dtAttivitaDaFare.Rows[i]["Utenti_Nominativo"].ToString()%></td>
				              <td class="text-center nowrap">
												<a href="/admin/app/attivita/actions/attivita-completa.aspx?Commesse_Ky=<%=dtAttivitaDaFare.Rows[i]["Commesse_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAttivitaDaFare.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaDaFare.Rows[i]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivitaDaFare.Rows[i]["AttivitaSettore_Ky"].ToString()%>&Attivita_Completo=1&sorgente=scheda-commessa" title="completo"><i class="fa-duotone fa-check fa-fw"></i></a>
				              	<a href="/admin/app/attivita/crud/elimina-attivita.aspx?azione=delete&Commesse_Ky=<%=dtAttivitaDaFare.Rows[i]["Commesse_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAttivitaDaFare.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaDaFare.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-commessa" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
											</td>
				            </tr>
				        <% } %>
					    	</tbody>
							  <% if (dtAttivitaDaFare.Rows.Count<1){
							      	Response.Write("<tfoot><tr><td colspan=\"11\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
								} %> 
				      </table>
			  	</div>
			  	<div class="tabs-panel" id="tabattivita-2" aria-selected="false" aria-hidden="true">
						      <table class="grid hover scroll" border="0" width="100%">
							    	<thead>
						        <tr>
                            <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
						          <th width="40" class="text-left">Cod.</th>
						          <th width="400" align="left">Descrizione</th>
											<th width="80" align="center">Priorit&agrave;</th>
											<th width="110" align="center">Scadenza</th>
											<th width="110" align="center">Chiusura</th>
											<th width="100" align="center">Ore impiegate</th>
											<th width="80" align="center">Settore</th>
											<th width="150" align="center">Per chi</th>
											<th width="60" class="text-center nowrap"></th>
						        </tr>
							    	</thead>
							    	<tbody>
						        <%
											decTot=0;
											for (int i = 0; i < dtAttivitaCompletateTecniche.Rows.Count; i++){ %>
						            <tr>
                                <td><input type="checkbox" class="checkrow" id="record<%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ky"].ToString()%>" data-value="<%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ky"].ToString()%>" /></td>
							            <td class="text-left nowrap"><a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=<%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-commessa"><%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ky"].ToString()%></a></td>
						              <td class="text-left nowrap">
														<div class="width400">
													 	<i class="fa-duotone fa-fw <%=dtAttivitaCompletateTecniche.Rows[i]["AttivitaTipo_Icona"].ToString()%>"></i>
													 	<% if (dtAttivitaCompletateTecniche.Rows[i]["Attivita_Trasferta"].Equals(true)){ %>
															<i class="fa-duotone fa-car fa-fw"></i>
													 	<% } %>
														<%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Descrizione"].ToString()%>
														</div>
													</td>
						              <td class="large-text-center small-text-left"><%=dtAttivitaCompletateTecniche.Rows[i]["Priorita_Descrizione"].ToString()%></td>
						              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Scadenza_IT"].ToString()%></td>
						              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Chiusura_IT"].ToString()%></td>
						              <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ore"].ToString()%></td>
						              <td class="large-text-center small-text-left"><%=dtAttivitaCompletateTecniche.Rows[i]["AttivitaSettore_Titolo"].ToString()%></td>
						              <td class="text-left"><i class="fa-duotone fa-user fa-fw" style="color:<%=dtAttivitaCompletateTecniche.Rows[i]["Utenti_Colore"].ToString()%>"></i><%=dtAttivitaCompletateTecniche.Rows[i]["Utenti_Nominativo"].ToString()%></td>
						              <td class="text-center nowrap">
														<a href="/admin/app/attivita/actions/attivita-completa.aspx?Commesse_Ky=<%=dtAttivitaCompletateTecniche.Rows[i]["Commesse_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAttivitaCompletateTecniche.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivitaCompletateTecniche.Rows[i]["AttivitaSettore_Ky"].ToString()%>&Attivita_Completo=0&sorgente=scheda-commessa" title="da fare"><i class="fa-duotone fa-undo fa-fw"></i></a>
						              	<a href="/admin/app/attivita/crud/elimina-attivita.aspx?azione=delete&Commesse_Ky=<%=dtAttivitaCompletateTecniche.Rows[i]["Commesse_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAttivitaCompletateTecniche.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-commessa" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
													</td>
						            </tr>
						        <%
											if (dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ore"]!=System.DBNull.Value){
												decTot+=Convert.ToDecimal(dtAttivitaCompletateTecniche.Rows[i]["Attivita_Ore"]);
											}
											} %>
							    	</tbody>
									  <% if (dtAttivitaCompletateTecniche.Rows.Count<1){
							      	          Response.Write("<tfoot><tr><td colspan=\"11\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
										} %> 
									  <% if (dtAttivitaCompletateTecniche.Rows.Count>0){ %>
							    	<tfoot>
								      <tr class="totale">
								        <td class="large-text-right small-text-left" colspan="6">Totali</td>
								        <td class="large-text-right small-text-left" style="padding-right:5px"><%=decTot.ToString("N2", ci)%></td>
								        <td colspan="5"></td>
								      </tr>
					    			</tfoot>
										<% } %> 
						      </table>
			  	</div>
			  	
					<div class="tabs-panel" id="tabattivita-3">
					    <% if (dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(true) && dtAttivitaCompletateAmministrative!=null && dtAttivitaCompletateAmministrative.Rows.Count>0){ %>
					      <table class="grid hover scroll" border="0" width="100%">
						    	<thead>
					        <tr>
                              <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
					          <th width="40" class="text-left">Cod.</th>
					          <th width="300" align="left">Descrizione</th>
					          <th width="120" align="center">Progetto</th>
										<th width="110" align="center">Scadenza</th>
										<th width="110" align="center">Chiusura</th>
										<th width="60" align="center">Ore Impiegate</th>
										<th width="80" align="center">Settore</th>
										<th width="150" align="center">Per chi</th>
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
					              <td class="text-left"><% if (dtAttivitaCompletateAmministrative.Rows[i]["Commesse_Ky"].ToString().Length>0){ %><a href="/admin/app/progetti/scheda-commesse.aspx?Commesse_Ky=<%=dtAttivitaCompletateAmministrative.Rows[i]["Commesse_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><i class="fa-duotone fa-circle-info fa-fw" title="<%=dtAttivitaCompletateAmministrative.Rows[i]["Commesse_Titolo"].ToString()%>"></i><%=dtAttivitaCompletateAmministrative.Rows[i]["Commesse_Riferimenti"].ToString()%></a><% } %></td>
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
							        <td colspan="5"></td>
							      </tr>
				    			</tfoot>
					      </table>
					    <% }else{
							Response.Write("<tfoot><tr><td colspan=\"11\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
					    } %>
			  	</div>
					
			  </div>
			</div>
		</div>
	</div>
</div>
<% } %>
