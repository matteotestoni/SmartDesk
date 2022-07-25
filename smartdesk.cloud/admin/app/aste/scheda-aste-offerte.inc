<% if (dtLogin.Rows[0]["UtentiGruppi_Aste"].Equals(true) && strAzione!="new"){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
	  <a name="offerte"></a>
		<div class="card">
		  <div class="card-divider">
			  <h2><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i>Offerte dell'asta</h2>
				<div class="button-group tiny">
					<% if (dtAsteEsperimenti.Rows.Count>0){ %>
            <a href="/admin/app/annunci/scheda-annunciofferte.aspx?azione=new&sorgente=scheda-aste&Aste_Ky=<%=GetFieldValue(dtAste, "Aste_Ky")%>" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>nuova offerta manuale</a>
          <% }else{  %>
            <span class="label warning radius">Nessun esperimento sull'asta</span>
          <% } %>
		  	</div>
		  </div>
		  <div class="card-section">
			<%for (int j = 0; j < dtAsteEsperimenti.Rows.Count; j++){
	
					strWHERENet = "Aste_Ky=" + strAste_Ky + " AND AsteEsperimenti_Ky=" + dtAsteEsperimenti.Rows[j]["AsteEsperimenti_Ky"].ToString();
	        strORDERNet = "Annunci_Ky, AnnunciOfferte_Ky";
	        strFROMNet = "AnnunciOfferte_Vw";
	        dtAnnunciOfferte = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnnunciOfferte_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
					if (dtAnnunciOfferte.Rows.Count>0){
			
			%> 

		                <h4>Esperimento n&deg; <%=dtAsteEsperimenti.Rows[j]["AsteEsperimenti_Numero"].ToString()%> - ID <%=dtAsteEsperimenti.Rows[j]["AsteEsperimenti_Ky"].ToString()%> <span class="label" style="background-color:<%=dtAsteEsperimenti.Rows[j]["AsteEsperimentiEsiti_Colore"].ToString()%>"><i class="<%=dtAsteEsperimenti.Rows[j]["AsteEsperimentiEsiti_Icona"].ToString()%> fa-fw"></i><%=dtAsteEsperimenti.Rows[j]["AsteEsperimentiEsiti_Titolo"].ToString()%></h4>
								    <table class="grid hover scroll" border="0" width="100%">
								    	<thead>
									      <tr>
						              <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
									        <th width="30">Cod.</th>
						        			<th width="40" class="text-left">Anagrafica</th>
						        			<th width="40" class="large-text-center small-text-left">Esperimento</th>
						        			<th width="40" class="large-text-center small-text-left">Ribasso</th>
						        			<th width="120" class="large-text-center small-text-left">Data offerta</th>
						        			<th width="120" class="large-text-center small-text-left">Termine asta</th>
						        			<th width="40" class="large-text-center small-text-left">Valore</th>
						        			<th width="40" class="text-left">Proxy Bid</th>
						        			<th width="120" class="large-text-center small-text-left">Tempo al termine</th>
									        <th width="60" class="text-center nowrap"></th>
									      </tr>
								    	</thead>
								    	<tbody>
										    <%for (int i = 0; i < dtAnnunciOfferte.Rows.Count; i++){ 
													if (dtAnnunciOfferte.Rows[i]["Annunci_Ky"].ToString()!=strAnnunci_Ky){ %>
										        <tr class="riga<%=i%2%>">
										          <td colspan="11"><strong>Lotto: <%=dtAnnunciOfferte.Rows[i]["Annunci_Ky"].ToString()%> - <%=dtAnnunciOfferte.Rows[i]["Annunci_Titolo"].ToString()%> - Numero: <%=dtAnnunciOfferte.Rows[i]["Annunci_Numero"].ToString()%></strong></td>
										        </tr>
												<%	}
												
												%>
										        <tr class="riga<%=i%2%>">
								              <td><input type="checkbox" class="checkrow" id="record<%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Ky"].ToString()%>" data-value="<%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Ky"].ToString()%>" /></td>
										          <td><a href="/admin/app/annunci/scheda-annunciofferte.aspx?Aste_Ky=<%=dtAnnunciOfferte.Rows[i]["Aste_Ky"].ToString()%>&AnnunciOfferte_Ky=<%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Ky"].ToString()%>"><%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Ky"].ToString()%></a></td>
							          			<td class="text-left"><%=dtAnnunciOfferte.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></td>
							          			<td class="large-text-center small-text-left"><%=dtAnnunciOfferte.Rows[i]["AsteEsperimenti_Numero"].ToString()%></td>
							          			<td class="large-text-center small-text-left"><%=dtAnnunciOfferte.Rows[i]["AsteEsperimenti_PercentualeRibasso"].ToString()%>%</td>
							          			<td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=Convert.ToDateTime(dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Data"]).ToString("d/M/yyyy HH:mm:ss.fff",System.Globalization.CultureInfo.InvariantCulture)%></strong></td>
							          			<td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=Convert.ToDateTime(dtAnnunciOfferte.Rows[i]["AsteEsperimenti_DataTermine"]).ToString("d/M/yyyy HH:mm:ss.fff",System.Globalization.CultureInfo.InvariantCulture)%></td>
							          			<td class="large-text-center small-text-left">&euro; <%=((decimal)dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Valore"]).ToString("N2",ci)%></td>
							          			<td class="text-left">
						    								<% if (dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Proxybid"].Equals(true)){ %>
						    									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i> <%=dtAnnunciOfferte.Rows[i]["AsteProxyBid_Ky"].ToString()%>
						    								<% }else{  %>
						    									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
						    								<% } %>
						                  </td>
							          			<td class="large-text-center small-text-left">
																<% 
																if (dtAnnunciOfferte.Rows[i]["d"].ToString().Length>0 && dtAnnunciOfferte.Rows[i]["d"].ToString()!="0" && dtAnnunciOfferte.Rows[i]["d"].ToString()!="1"){
																	Response.Write(dtAnnunciOfferte.Rows[i]["d"].ToString() + "g");
																}else{
																	if (dtAnnunciOfferte.Rows[i]["hh"].ToString().Length>0 && dtAnnunciOfferte.Rows[i]["hh"].ToString()!="0" && dtAnnunciOfferte.Rows[i]["hh"].ToString()!="1"){
																		Response.Write(dtAnnunciOfferte.Rows[i]["hh"].ToString() + "h");
																	}else{
																		if (dtAnnunciOfferte.Rows[i]["mi"].ToString().Length>0 && dtAnnunciOfferte.Rows[i]["mi"].ToString()!="0" && dtAnnunciOfferte.Rows[i]["mi"].ToString()!="1"){
																			Response.Write(dtAnnunciOfferte.Rows[i]["mi"].ToString() + "m");
																		}else{
																			if (dtAnnunciOfferte.Rows[i]["ss"].ToString().Length>0 && dtAnnunciOfferte.Rows[i]["s"].ToString()!="0"){
																				Response.Write(dtAnnunciOfferte.Rows[i]["ss"].ToString() + "s");
																			}
																		}
																	}
																}
																%> 
															</td>
										          <td class="text-center nowrap"><a href="/admin/app/annunci/crud/elimina-annunciofferte.aspx?azione=delete&sorgente=scheda-asta&AnnunciOfferte_Ky=<%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Ky"].ToString()%>&Aste_Ky=<%=dtAnnunciOfferte.Rows[i]["Aste_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></td>
										        </tr>
										    <% 
													strAnnunci_Ky=dtAnnunciOfferte.Rows[i]["Annunci_Ky"].ToString();
												} %>
									    	</tbody>
											  <% if (dtAnnunciOfferte.Rows.Count<1){
											      	Response.Write("<tfoot><tr><td colspan=\"11\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
												} %> 
								    </table>
				<% 
					}
				} %> 
			</div>    
		</div>
	</div>
</div>
<% } %>
