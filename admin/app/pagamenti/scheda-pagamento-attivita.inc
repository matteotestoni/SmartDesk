<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true) && dtAttivita.Rows.Count>0){ %>
<div class="grid-x grid-padding-x">
	<div class="small-12 medium-12 large-12 cell">
			<br>
			<a name="attivita"></a>
			<div class="card">
			  <div class="card-divider">
					<h2><i class="fa-duotone fa-calendar-days fa-lg fa-fw"></i>Attivit&agrave; fatte sul pagamento (<%=dtAttivita.Rows.Count%>)</h2>
					<div class="button-group tiny">
						<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new&AttivitaTipo_Ky=3&AttivitaSettore_Ky=3&Anagrafiche_Ky=<%=GetFieldValue(dtPagamenti, "Anagrafiche_Ky")%>&Pagamenti_Ky=<%=GetFieldValue(dtPagamenti, "Pagamenti_Ky")%>&Documenti_Ky=<%=GetFieldValue(dtPagamenti, "Documenti_Ky")%>&sorgente=scheda-pagamenti" class="tiny button secondary"><i class="fa-duotone fa-gear fa-fw"></i> Nuova attivit&agrave; amministrativa</a>
					</div> 
				</div>        
				<div class="card-section">
					    <% if (dtAttivita!=null && dtAttivita.Rows.Count>0){ %>
					      <div class="small-12 medium-12">
								<table class="grid hover scroll" border="0" width="100%">
						    	<thead>
					        <tr>
					          <th width="40" class="text-left">Cod.</th>
					          <th width="300" align="left">Descrizione</th>
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
					        <%for (int i = 0; i < dtAttivita.Rows.Count; i++){ %>
					            <tr>
						            <td class="text-left nowrap"><a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-pagamenti"><%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%></a></td>
					              <td class="text-left nowrap">
													<div class="width300">
													 	<i class="fa-duotone fa-fw <%=dtAttivita.Rows[i]["AttivitaTipo_Icona"].ToString()%>"></i>
														<% if (dtAttivita.Rows[i]["Priorita_Icona"].ToString().Length>0){ %>
															<i class="fa-duotone <%=dtAttivita.Rows[i]["Priorita_Icona"].ToString()%> fa-fw"></i>
													 	<% } %>
														<% if (dtAttivita.Rows[i]["Attivita_Trasferta"].Equals(true)){ %>
															<i class="fa-duotone fa-car fa-fw"></i>
													 	<% } %>
														<%=dtAttivita.Rows[i]["Attivita_Descrizione"].ToString()%>
													</div>
												</td>
					              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivita.Rows[i]["Attivita_Scadenza_IT"].ToString()%></td>
			        					<td class="large-text-center small-text-left"><strong><%=Smartdesk.Functions.getGGDaFare(dtAttivita.Rows[i]["ggTrascorsi"].ToString())%></strong></td>
					              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivita.Rows[i]["Attivita_Chiusura_IT"].ToString()%></td>
					              <td class="large-text-center small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><%=dtAttivita.Rows[i]["Attivita_Ore"].ToString()%></td>
					              <td class="large-text-center small-text-left"><%=dtAttivita.Rows[i]["AttivitaSettore_Titolo"].ToString()%></td>
					              <td class="text-center nowrap"><i class="fa-duotone fa-user fa-fw" style="color:<%=dtAttivita.Rows[i]["Utenti_Colore"].ToString()%>"></i><%=dtAttivita.Rows[i]["Utenti_Nominativo"].ToString()%></td>
	          						<td class="text-center show-for-medium-up"><i class="fa-duotone fa-user-secret fa-fw"></i><%=dtAttivita.Rows[i]["Utenti_Iniziali"].ToString()%></td>
					              <td class="text-center nowrap">
													<a href="/admin/app/attivita/actions/attivita-completa.aspx?Anagrafiche_Ky=<%=dtAttivita.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivita.Rows[i]["AttivitaSettore_Ky"].ToString()%>&Attivita_Completo=1&sorgente=scheda-anagrafiche" title="completo"><i class="fa-duotone fa-check fa-fw"></i></a>
					              	<a href="/admin/app/attivita/crud/elimina-attivita.aspx?azione=delete&Pagamenti_Ky=<%=dtAttivita.Rows[i]["Pagamenti_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAttivita.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-pagamenti" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
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
			</div>        
		</div>        
</div>
<% } %>
