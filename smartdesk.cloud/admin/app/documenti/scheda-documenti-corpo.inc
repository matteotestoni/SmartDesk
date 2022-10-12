<div class="grid-x grid-padding-x">
	<div class="small-12 medium-12 large-12 cell">
		<br>
		<div class="card">
		  <div class="card-divider">
				<h2><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i>Righe del documento</h2>
				<div class="button-group tiny"> 
			    <a href="/admin/app/documenti/scheda-documenticorpo.aspx?azione=new&tipo=1&sorgente=scheda-documenti&Anagrafiche_Ky=<%=GetFieldValue(dtDocumenti, "Anagrafiche_Ky")%>&Documenti_Ky=<%=GetFieldValue(dtDocumenti, "Documenti_Ky")%>" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>Aggiungi&nbsp; riga testo libero</a>
			    <a href="/admin/app/documenti/scheda-documenticorpo-aggiungiprodotto.aspx?azione=new&tipo=2&sorgente=scheda-documenti&Anagrafiche_Ky=<%=GetFieldValue(dtDocumenti, "Anagrafiche_Ky")%>&Documenti_Ky=<%=GetFieldValue(dtDocumenti, "Documenti_Ky")%>" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>Aggiungi&nbsp; prodotto</a>
			    <a href="/admin/app/documenti/scheda-documenticorpo-aggiungiservizio.aspx?azione=new&tipo=3&sorgente=scheda-documenti&Anagrafiche_Ky=<%=GetFieldValue(dtDocumenti, "Anagrafiche_Ky")%>&Documenti_Ky=<%=GetFieldValue(dtDocumenti, "Documenti_Ky")%>" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>Aggiungi&nbsp; servizio</a>
			  </div>
			</div>
	  	<div class="card-section">
            <div class="grid-x grid-padding-x">
              <div class="large-3 medium-3 small-8 cell end">
                <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione hide" method="post" action="#">
                <div class="input-group">
                  <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
                    <option value="">Azioni di gruppo</option>
                    <option value="delete" data-action="/admin/app/documenti/crud/elimina-documenti-corpo.aspx">Elimina</option>
                  </select>
                  <div class="input-group-button">
                    <input type="hidden" name="grid" value="elencodocumenticorpo">
                    <input type="hidden" id="sorgente" name="sorgente" value="scheda-documenti">
                    <input type="hidden" id="azione" name="azione" value="">
                    <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
                    <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
                    <input type="submit" id="doaction" class="button secondary" value="Applica">
                  </div>
                </div>
                </form>
              </div>
            </div>
			      <table id="elencodocumenticorpo" class="grid hover scroll" border="0" width="100%">
			    		<thead>
			        <tr>
	              <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
			          <th class="text-center" width="30">Qt&agrave;</th>
			          <th class="text-left">Descrizione</th>
			          <th class="text-center" width="110">Prezzo &euro;</th>
								<th class="text-center" width="110">Importo &euro;</th>
								<th class="text-center" width="110">IVA &euro;</th>
			          <th class="text-left" width="150">Regime IVA</th>
			          <th class="text-center" width="110">IVA %</th>
								<th class="text-right" width="60">Ordine</th>
								<th width="60"></th>
			        </tr>
			    		</thead>
			    		<tbody>
			        <%
								decTot=0;
			        	decTotQta=0;
			        	decTotIVA=0;
			        	decIVA=0;
								for (int i = 0; i < dtDocumentiCorpo.Rows.Count; i++){
									decIVA=((decimal)dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Totale"]*(decimal)dtDocumentiCorpo.Rows[i]["AliquoteIVA_Aliquota"]/100);
								%>
			            <tr class="riga<%=i%2%>">
		                <td><input type="checkbox" class="checkrow" id="record<%=dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Ky"].ToString()%>" data-value="<%=dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Ky"].ToString()%>" /></td>
			              <td class="large-text-center small-text-left"><%=dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Qta"].ToString()%></td>
			              <td class="text-left">
											<div class="width600">
				              	<a href="/admin/app/documenti/scheda-documenticorpo.aspx?azione=modifica&Documenti_Ky=<%=dtDocumentiCorpo.Rows[i]["Documenti_Ky"].ToString()%>&DocumentiCorpo_Ky=<%=dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Ky"].ToString()%>&sorgente=scheda-documenti">
													<%=dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Titolo"].ToString()%>
												</a>
												<br>
												<%=dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Descrizione"].ToString()%>
											</div>
										</td>
			              <td class="large-text-right small-text-left" style="padding-right:5px">
                      <% if (dtDocumentiCorpo.Rows[i]["DocumentiCorpo_ImportoTagliato"].ToString().Length>0){ %>
                      <span class="prezzotagliato" style="text-decoration: line-through;font-size:12px;">&euro; <%=((decimal)dtDocumentiCorpo.Rows[i]["DocumentiCorpo_ImportoTagliato"]).ToString("N2", ci)%></span>
                      <% } %>
                    &euro; <%=dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Importo_IT"].ToString()%>
                    </td>
			              <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <strong><%=dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Totale_IT"].ToString()%></strong></td>
			              <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <strong><%=decIVA.ToString("N2", ci)%></strong></td>
			              <td class="text-left"><%=dtDocumentiCorpo.Rows[i]["AliquoteIVA_Descrizione"].ToString()%></td>
			              <td class="large-text-center small-text-left"><%=((decimal)dtDocumentiCorpo.Rows[i]["AliquoteIVA_Aliquota"]).ToString("N0", ci)%> %</td>
			              <td class="large-text-right small-text-left" style="padding-right:5px"><strong><%=dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Ordine"].ToString()%></strong></td>
			              <td align="left">
			                <a href="/admin/app/documenti/crud/elimina-documenti-corpo.aspx?azione=delete&DocumentiCorpo_Ky=<%=dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Ky"].ToString()%>&Documenti_Ky=<%=dtDocumentiCorpo.Rows[i]["Documenti_Ky"].ToString()%>&sorgente=scheda-documenti" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
			              </td>
			            </tr>
			        <%
								decTotIVA+=decIVA;
								decTotQta+=Convert.ToDecimal(dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Qta"]);
								decTot+=Convert.ToDecimal(dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Importo"]);
							} %>
			    		</tbody>
				    	<tfoot>
					      <tr class="totale">
					        <td></td>
					        <td class="text-center" style="padding-right:5px"><%=decTotQta.ToString("N0", ci)%></td>
					        <td class="large-text-right small-text-left" bgcolor="#ffffff" class="text-right"></td>
					        <td class="large-text-right small-text-left" class="text-right"><strong>Totali</strong></td>
					        <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTot.ToString("N2", ci)%></td>
					        <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTotIVA.ToString("N2", ci)%></td>
					        <td>&euro; <%=(decTot+decTotIVA).ToString("N2", ci)%></td>
					      </tr>
				    	</tfoot>
			      </table>
			</div>
		</div>
	</div>
</div>
