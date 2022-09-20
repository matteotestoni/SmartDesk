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
                      <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
						          <th width="40" class="text-left">Cod.</th>
						          <th width="400" align="left">Descrizione</th>
											<th width="80" align="center" class="text-center">Priorit&agrave;</th>
											<th width="120" align="center" class="text-center">Data</th>
											<th width="115" align="center" class="text-center">Chiusura</th>
											<th width="80" align="right" class="text-right">Ore</th>
											<th width="80" align="center" class="text-center">Settore</th>
											<th width="150" align="center">Per chi</th>
											<th width="60" class="text-center nowrap"></th>
						        </tr>
							    	</thead>
							    	<tbody>
						        <%
											decTot=0;
											for (int i = 0; i < dtAttivitaCompletate.Rows.Count; i++){ %>
						            <tr>
                          <td><input type="checkbox" class="checkrow" id="record<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>" data-value="<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>" /></td>
							            <td class="text-left nowrap"><a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-progetti"><%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%></a></td>
						              <td class="text-left nowrap">
														<div class="width400">
													 	<i class="<%=dtAttivitaCompletate.Rows[i]["AttivitaTipo_Icona"].ToString()%> fa-fw"></i>
													 	<% if (dtAttivitaCompletate.Rows[i]["Attivita_Trasferta"].Equals(true)){ %>
															<i class="fa-duotone fa-car fa-fw"></i>
													 	<% } %>
														<%=dtAttivitaCompletate.Rows[i]["Attivita_Descrizione"].ToString()%>
														</div>
													</td>
						              <td class="large-text-center small-text-left"><%=dtAttivitaCompletate.Rows[i]["Priorita_Descrizione"].ToString()%></td>
						              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaCompletate.Rows[i]["Attivita_Scadenza"].ToString()%></td>
						              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaCompletate.Rows[i]["Attivita_Chiusura"].ToString()%></td>
						              <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><%=dtAttivitaCompletate.Rows[i]["Attivita_Ore"].ToString()%></td>
						              <td class="large-text-center small-text-left"><%=dtAttivitaCompletate.Rows[i]["AttivitaSettore_Titolo"].ToString()%></td>
						              <td class="text-left">
                          <% if (dtAttivitaCompletate.Rows[i]["Utenti_Logo"].ToString().Length>0){ %>
                            <img src="<%=dtAttivitaCompletate.Rows[i]["Utenti_Logo"].ToString()%>" width="30" height="30" align="left" style="width:30px;height:30px;border-radius:50%;margin-right:5px;">
                          <% }else{ %>
                            <i class="fa-duotone fa-user fa-fw" style="color:<%=dtAttivitaCompletate.Rows[i]["Utenti_Colore"].ToString()%>"></i>
                          <% } %>
                          
                          <span style="color:<%=dtAttivitaCompletate.Rows[i]["Utenti_Colore"].ToString()%>"><%=dtAttivitaCompletate.Rows[i]["Utenti_Nominativo"].ToString()%></span></td>
						              <td class="text-center nowrap">
                            <% if (strAzione!="new" && dtCommesse.Rows[0]["CommesseStato_Ky"].ToString()!="6"){ %>
														<a href="/admin/app/attivita/actions/attivita-completa.aspx?Commesse_Ky=<%=dtAttivitaCompletate.Rows[i]["Commesse_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAttivitaCompletate.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivitaCompletate.Rows[i]["AttivitaSettore_Ky"].ToString()%>&Attivita_Completo=0&sorgente=scheda-progetti" title="da fare"><i class="fa-duotone fa-undo fa-fw"></i></a>
						              	<a href="/admin/app/attivita/crud/elimina-attivita.aspx?azione=delete&Commesse_Ky=<%=dtAttivitaCompletate.Rows[i]["Commesse_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAttivitaCompletate.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-progetti" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
                            <% } %>
													</td>
						            </tr>
						        <%
											if (dtAttivitaCompletate.Rows[i]["Attivita_Ore"]!=System.DBNull.Value){
												decTot+=Convert.ToDecimal(dtAttivitaCompletate.Rows[i]["Attivita_Ore"]);
											}
											} %>
							    	</tbody>
									  <% if (dtAttivitaCompletate.Rows.Count<1){
							      	          Response.Write("<tfoot><tr><td colspan=\"11\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
										} %> 
									  <% if (dtAttivitaCompletate.Rows.Count>0){ %>
							    	<tfoot>
								      <tr class="totale">
								        <td class="large-text-right small-text-left" colspan="6">Totali</td>
								        <td class="large-text-right small-text-left" style="padding-right:5px"><%=decTot.ToString("N2", ci)%></td>
								        <td colspan="6"></td>
								      </tr>
					    			</tfoot>
										<% } %> 
						      </table>
					
			</div>
		</div>
	</div>
</div>
<% } %>
