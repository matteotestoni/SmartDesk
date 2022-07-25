<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
  <a name="attivita"></a>
	<br>
	<div class="card">
	  <div class="card-divider">
			<h2><i class="fa-duotone fa-calendar-days fa-lg fa-fw"></i>Attivit&agrave; completate</h2>
		</div>
	  <div class="card-section">
						      <table class="grid hover scroll" border="0" width="100%">
							    	<thead>
						        <tr>
						          <th width="40" class="text-left">Cod.</th>
						          <th width="400" align="left">Descrizione</th>
											<th width="80" class="large-text-center small-text-left">Priorit&agrave;</th>
											<th width="115" class="large-text-center small-text-left">Scadenza</th>
											<th width="115" class="large-text-center small-text-left">Chiusura</th>
											<th width="100" class="text-right">Ore</th>
											<th width="80" align="center">Settore</th>
						        </tr>
							    	</thead>
							    	<tbody>
						        <%
											decTot=0;
											for (int i = 0; i < dtAttivitaCompletate.Rows.Count; i++){ %>
						            <tr>
							            <td class="text-left nowrap"><%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%></td>
						              <td class="text-left nowrap">
														<div class="width400">
													 	<i class="<%=dtAttivitaCompletate.Rows[i]["AttivitaTipo_Icona"].ToString()%> fa-fw"></i>
													 	<% if (dtAttivitaCompletate.Rows[i]["Attivita_Trasferta"].Equals(true)){ %>
															<i class="fa-duotone fa-car fa-fw"></i>
													 	<% } %>
														<%=dtAttivitaCompletate.Rows[i]["Attivita_Descrizione"].ToString()%>
														</div>
													</td>
						              <td class="large-text-center small-text-left"><i class="<%=dtAttivitaCompletate.Rows[i]["Priorita_Icona"].ToString()%> fa-fw"></i><%=dtAttivitaCompletate.Rows[i]["Priorita_Descrizione"].ToString()%></td>
						              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaCompletate.Rows[i]["Attivita_Scadenza_IT"].ToString()%></td>
						              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaCompletate.Rows[i]["Attivita_Chiusura_IT"].ToString()%></td>
						              <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><%=dtAttivitaCompletate.Rows[i]["Attivita_OrePreviste"].ToString()%></td>
						              <td class="large-text-center small-text-left"><%=dtAttivitaCompletate.Rows[i]["AttivitaSettore_Titolo"].ToString()%></td>
						            </tr>
						        <%
											if (dtAttivitaCompletate.Rows[i]["Attivita_Ore"]!=System.DBNull.Value){
												decTot+=Convert.ToDecimal(dtAttivitaCompletate.Rows[i]["Attivita_OrePreviste"]);
											}
											} %>
							    	</tbody>
									  <% if (dtAttivitaCompletate.Rows.Count<1){
							      	          Response.Write("<tfoot><tr><td colspan=\"11\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
										} %> 
									  <% if (dtAttivitaCompletate.Rows.Count>0){ %>
							    	<tfoot>
								      <tr class="totale">
								        <td class="large-text-right small-text-left" colspan="5">Totali </td>
								        <td class="large-text-right small-text-left" style="padding-right:5px"><i class="fa-duotone fa-clock fa-fw"></i><%=decTot.ToString("N2", ci)%></td>
								        <td colspan="4"></td>
								      </tr>
					    			</tfoot>
										<% } %> 
						      </table>
					
			</div>
		</div>
	</div>
</div>
<% } %>
