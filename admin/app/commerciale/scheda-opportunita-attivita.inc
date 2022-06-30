<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
  <br>
	<a name="attivita"></a>
	<div class="card">
	  <div class="card-divider">
			<h2><i class="fa-duotone fa-triangle-exclamation fa-lg fa-fw" style="--fa-primary-color:red;--fa-primary-opacity: 1.0"></i> Attivit&agrave; predefinite:</h2> 
		</div>        
	  <div class="card-section">
		<% for (int i = 0; i < dtAttivitaTipo.Rows.Count; i++){ %>
			<div class="grid-x grid-padding-x">
				<div class="small-12 medium-3 large-2 cell">
					<label class="large-text-right small-text-left middle"><%=dtAttivitaTipo.Rows[i]["AttivitaTipo_Descrizione"].ToString()%> <i class="<%=dtAttivitaTipo.Rows[i]["AttivitaTipo_Icona"].ToString()%> fa-fw"></i></label>
				</div>
				<div class="small-12 medium-9 large-10 cell">
					<div class="button-group tiny"> 
						<% for (int j = 0; j < dtOpportunitaStati.Rows.Count; j++){ %>
							  <a href="/admin/app/commerciale/actions/opportunita-aggiornastato.aspx?Opportunita_Ky=<%=GetFieldValue(dtOpportunita, "Opportunita_Ky")%>&Anagrafiche_Ky=<%=GetFieldValue(dtOpportunita, "Anagrafiche_Ky")%>&AttivitaTipo_Ky=<%=dtAttivitaTipo.Rows[i]["AttivitaTipo_Ky"].ToString()%>&OpportunitaStati_Ky=<%=dtOpportunitaStati.Rows[j]["OpportunitaStati_Ky"].ToString()%>&sorgente=scheda-opportunita" class="button secondary"><span class="label" style="color:#ffffff;background-color:<%=dtOpportunitaStati.Rows[j]["OpportunitaStati_Colore"].ToString()%>"><%=dtOpportunitaStati.Rows[j]["OpportunitaStati_Titolo"].ToString()%></span></a>
						<% } %>
					</div>
				</div>
			</div>			
		<% } %>
		
		

		<div class="grid-x grid-padding-x">
			<div class="small-12 medium-3 large-2 cell">
				<label class="large-text-right small-text-left middle">Nuova attivit&agrave; <i class="fa-duotone fa-gears fa-fw"></i></label>
			</div>
			<div class="small-12 medium-9 large-10 cell">
				<div class="button-group tiny"> 
					<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new&Opportunita_Ky=<%=GetFieldValue(dtOpportunita, "Opportunita_Ky")%>&Anagrafiche_Ky=<%=GetFieldValue(dtOpportunita, "Anagrafiche_Ky")%>&sorgente=scheda-opportunita&AttivitaTipo_Ky=3&AttivitaSettore_Ky=2&Attivita_Completo=1" class="button secondary"><span class="label alert">Nuova attivit&agrave; personalizzata</span></a> 
				</div>
			</div>
		</div>

		</div> 
	</div>
	<div class="card">
		  <div class="card-divider">
					<h2><i class="fa-duotone fa-triangle-exclamation fa-lg fa-fw" style="--fa-primary-color:red;--fa-primary-opacity: 1.0"></i> Attivit&agrave; da fare (<%=dtAttivitaDaFare.Rows.Count%>)</h2> 
			</div>        
	  	<div class="card-section">
						    <% if (dtAttivitaDaFare.Rows.Count>0){ %>
									<div class="divgrid" id="divgrid">
									<table class="grid hover scroll" border="0" width="100%">
							    	<thead>
						        <tr>
						          <th width="40" class="text-left">Cod.</th>
						          <th width="12" align="left"></th>
						          <th width="500" align="left">Descrizione</th>
											<th width="80" class="text-center">Priorit&agrave;</th>
											<th width="110" class="text-center">Scadenza</th>
											<th width="40" class="text-center">gg</th>
											<th width="70" class="text-center">Chiusura</th>
											<th width="80" class="text-center">Ore</th>
											<th width="60" class="text-center">Completo</th>
											<th width="80" class="text-center">Settore</th>
											<th width="150" class="text-center">Per chi</th>
											<th width="60" class="text-center nowrap"></th>
						        </tr>
							    	</thead>
							    	<tbody>
						        <%for (int i = 0; i < dtAttivitaDaFare.Rows.Count; i++){ %>
						            <tr>
							            <td class="text-left nowrap"><a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=<%=dtAttivitaDaFare.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-opportunita"><%=dtAttivitaDaFare.Rows[i]["Attivita_Ky"].ToString()%></a></td>
			        						<td class="large-text-center small-text-left">
														<i class="fa-duotone fa-fw <%=dtAttivitaDaFare.Rows[i]["AttivitaTipo_Icona"].ToString()%>"></i>
													 	<% if (dtAttivitaDaFare.Rows[i]["Attivita_Trasferta"].Equals(true)){ %>
															<i class="fa-duotone fa-car fa-fw"></i>
													 	<% } %>
													</td>
						              <td class="text-left nowrap"><div class="width500"><%=dtAttivitaDaFare.Rows[i]["Attivita_Descrizione"].ToString()%></div></td>
						              <td class="large-text-center small-text-left"><%=dtAttivitaDaFare.Rows[i]["Priorita_Descrizione"].ToString()%></td>
						              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaDaFare.Rows[i]["Attivita_Scadenza_IT"].ToString()%></td>
				        					<td class="large-text-center small-text-left"><strong><%=Smartdesk.Functions.getGGDaFare(dtAttivitaDaFare.Rows[i]["ggTrascorsi"].ToString())%></strong></td>
						              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaDaFare.Rows[i]["Attivita_Chiusura_IT"].ToString()%></td>
						              <td class="large-text-center small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><%=dtAttivitaDaFare.Rows[i]["Attivita_Ore"].ToString()%></td>
						              <td class="large-text-center small-text-left"><%=dtAttivitaDaFare.Rows[i]["Attivita_Completo"].ToString()%></td>
						              <td class="large-text-center small-text-left"><%=dtAttivitaDaFare.Rows[i]["AttivitaSettore_Titolo"].ToString()%></td>
						              <td class="text-center nowrap"><i class="fa-duotone fa-user fa-fw" style="color:<%=dtAttivitaDaFare.Rows[i]["Utenti_Colore"].ToString()%>"></i><%=dtAttivitaDaFare.Rows[i]["Utenti_Nome"].ToString()%> <%=dtAttivitaDaFare.Rows[i]["Utenti_Cognome"].ToString()%></td>
						              <td class="text-center nowrap">
														<a href="/admin/app/attivita/actions/attivita-completa.aspx?Opportunita_Ky=<%=dtAttivitaDaFare.Rows[i]["Opportunita_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAttivitaDaFare.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaDaFare.Rows[i]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivitaDaFare.Rows[i]["AttivitaSettore_Ky"].ToString()%>&Attivita_Completo=1&sorgente=scheda-opportunita" title="completo"><i class="fa-duotone fa-check fa-fw"></i></a>
						              	<a href="/admin/app/attivita/crud/elimina-attivita.aspx?azione=delete&Opportunita_Ky=<%=dtAttivitaDaFare.Rows[i]["Opportunita_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaDaFare.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-opportunita" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
													</td>
						            </tr>
						        <% } %>
							    	</tbody>
						      </table>
						      </div>
						    <% }else{
			      			Response.Write("<div class=\"messaggio\"><i class=\"fa-duotone fa-circle-info fa-fw\"></i>Nessun attivit&agrave;<br><br></div>");
						    } %>
						    <% if (dtAttivitaCompletate.Rows.Count>0){ %>
							  <div class="titolotabella">
										<div class="grid-x grid-padding-x">
											<div class="small-12 large-12 cell">
												<h2><i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i> Attivit&agrave; completate (<%=dtAttivitaCompletate.Rows.Count%>)</h2>
											</div>        
										</div>
								</div>
									<table class="grid hover scroll" border="0" width="100%">
							    	<thead>
						        <tr>
						          <th width="40" class="text-left">Cod.</th>
						          <th width="12" class="text-center"></th>
						          <th width="500" align="left">Descrizione</th>
											<th width="80" class="text-center">Priorit&agrave;</th>
											<th width="110" class="text-center">Scadenza</th>
											<th width="110" class="text-center">Chiusura</th>
											<th width="80" class="text-center">Ore</th>
											<th width="60" class="text-center">Completo</th>
											<th width="80" class="text-center">Settore</th>
											<th width="150" class="text-center">Per chi</th>
											<th width="60" class="text-center nowrap"></th>
						        </tr>
							    	</thead>
							    	<tbody>
						        <%
											decTot=0;
											for (int i = 0; i < dtAttivitaCompletate.Rows.Count; i++){ %>
						            <tr>
							            <td class="text-left nowrap"><a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-opportunita"><%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%></a></td>
			        						<td class="large-text-center small-text-left">
														<i class="fa-duotone fa-fw <%=dtAttivitaCompletate.Rows[i]["AttivitaTipo_Icona"].ToString()%>"></i>
													 	<% if (dtAttivitaCompletate.Rows[i]["Attivita_Trasferta"].Equals(true)){ %>
															<i class="fa-duotone fa-car fa-fw"></i>
													 	<% } %>
													</td>
						              <td class="text-left nowrap"><div class="width500"><%=dtAttivitaCompletate.Rows[i]["Attivita_Descrizione"].ToString()%></div></td>
						              <td class="large-text-center small-text-left"><%=dtAttivitaCompletate.Rows[i]["Priorita_Descrizione"].ToString()%></td>
						              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaCompletate.Rows[i]["Attivita_Scadenza_IT"].ToString()%></td>
						              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaCompletate.Rows[i]["Attivita_Chiusura_IT"].ToString()%></td>
						              <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><%=dtAttivitaCompletate.Rows[i]["Attivita_Ore"].ToString()%></td>
						              <td class="large-text-center small-text-left"><%=dtAttivitaCompletate.Rows[i]["Attivita_Completo"].ToString()%></td>
						              <td class="large-text-center small-text-left"><%=dtAttivitaCompletate.Rows[i]["AttivitaSettore_Titolo"].ToString()%></td>
						              <td class="large-text-center small-text-left"><i class="fa-duotone fa-user fa-fw" style="color:<%=dtAttivitaCompletate.Rows[i]["Utenti_Colore"].ToString()%>"></i><%=dtAttivitaCompletate.Rows[i]["Utenti_Nome"].ToString()%> <%=dtAttivitaCompletate.Rows[i]["Utenti_Cognome"].ToString()%></td>
						              <td class="text-center nowrap">
														<a href="/admin/app/attivita/actions/attivita-completa.aspx?Opportunita_Ky=<%=dtAttivitaCompletate.Rows[i]["Opportunita_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAttivitaCompletate.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivitaCompletate.Rows[i]["AttivitaSettore_Ky"].ToString()%>&Attivita_Completo=0&sorgente=scheda-opportunita" title="da fare"><i class="fa-duotone fa-undo fa-fw"></i></a>
						              	<a href="/admin/app/attivita/crud/elimina-attivita.aspx?azione=delete&Opportunita_Ky=<%=dtAttivitaCompletate.Rows[i]["Opportunita_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAttivitaCompletate.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-opportunita" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
													</td>
						            </tr>
						        <%
											if (dtAttivitaCompletate.Rows[i]["Attivita_Ore"]!=System.DBNull.Value){
												decTot+=Convert.ToDecimal(dtAttivitaCompletate.Rows[i]["Attivita_Ore"]);
											}
											} %>
							    	</tbody>
							    	<tfoot>
								      <tr class="totale">
								        <td class="large-text-right small-text-left" colspan="6">Totali</td>
								        <td class="large-text-right small-text-left" style="padding-right:5px"><i class="fa-duotone fa-clock fa-fw"></i><%=decTot.ToString("N2", ci)%></td>
								        <td colspan="4"></td>
								      </tr>
					    			</tfoot>
						      </table>
						    <% }else{
			      			Response.Write("<div class=\"grid-x grid-padding-x\"><div class=\"small-12 large-12 medium-12 cell\"><div class=\"messaggio\">Nessun attivit&agrave;</div></div></div>");
						    } %>
					</div>
		</div>
	</div>
</div>
<% } %>
