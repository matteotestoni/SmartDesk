<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
				<h2><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i>Pagamenti</h2>
				<div class="button-group tiny"> 
					<button class="tiny button secondary" data-toggle="nuovopagamento"><i class="fa-duotone fa-square-plus fa-fw"></i>aggiungi scadenza pagamento</button>
				</div>
			</div>				
	  	<div class="card-section">
          <div class="grid-x grid-padding-x">
            <div class="large-3 medium-3 small-8 cell end">
              <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione hide" method="post" action="#">
              <div class="input-group">
                <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
                  <option value="">Azioni di gruppo</option>
                  <option value="delete" data-action="/admin/app/pagamenti/crud/elimina-pagamenti.aspx">Elimina</option>
                </select>
                <div class="input-group-button">
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
		      <table class="grid hover scroll" border="0" width="100%">
		    		<thead>
		        <tr>
              <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
		          <th width="110" class="text-center date">Data</th>
							<th class="text-center" width="80">Importo</th>
							<th class="text-left" width="200">Tramite</th>
							<th class="text-left" width="200">Anagrafica</th>
							<th class="text-center" width="100">Progetto</th>
							<th width="150">Pagato</th>
		          <th class="text-center" width="100">GG Ritardo</th>
							<th width="40">Rif.</th>
			        <th width="80">Promemoria</th>
			        <th width="90">Ultimo</th>
							<th class="text-center nowrap" width="80"></th>
		        </tr>
		    		</thead>
		    		<tbody>
		          <%
								decTot=0;
								for (int i = 0; i < dtPagamenti.Rows.Count; i++){
									if (dtPagamenti.Rows[i]["Anagrafiche_Ky"].ToString()!=GetFieldValue(dtDocumenti, "Anagrafiche_Ky")){
										strAlert+="- Il Pagamento <em>" + dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString() + "</em> non ha la stessa anagrafica di: <em>" + dtPagamenti.Rows[i]["Anagrafiche_RagioneSociale"].ToString() + "</em>";
									}
								%>
		            <tr>
	                <td><input type="checkbox" class="checkrow" id="record<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>" data-value="<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>" /></td>
		              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><a href="/admin/app/pagamenti/scheda-pagamenti.aspx?sorgente=scheda-documenti&Pagamenti_ky=<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>"><%=dtPagamenti.Rows[i]["Pagamenti_Data_IT"].ToString()%></a></td>
		              <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=dtPagamenti.Rows[i]["Pagamenti_Importo_IT"].ToString()%></td>
		              <td class="text-left"><i class="fa-duotone <%=dtPagamenti.Rows[i]["PagamentiMetodo_icona"].ToString()%> fa-fw" style="color:<%=dtPagamenti.Rows[i]["PagamentiMetodo_Colore"].ToString()%>"></i><%=dtPagamenti.Rows[i]["PagamentiMetodo_Titolo"].ToString()%> su <%=dtPagamenti.Rows[i]["Conti_Titolo"].ToString()%></td>
		              <td class="text-left"><i class="fa-duotone fa-users fa-fw"></i><%=dtPagamenti.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></td>
		              <td class="large-text-center small-text-left"><% if (dtPagamenti.Rows[i]["Commesse_Ky"].ToString().Length>0){ %><a href="/admin/app/progetti/scheda-commesse.aspx?Commesse_Ky=<%=dtPagamenti.Rows[i]["Commesse_Ky"].ToString()%>&sorgente=scheda-documenti" style="float:left"><%=dtPagamenti.Rows[i]["Commesse_Riferimenti"].ToString()%></a><% } %></td>
		              <td class="text-left">
										<% if (dtPagamenti.Rows[i]["Pagamenti_Pagato"].ToString()=="si"){ %>
											<span class="label success"><i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i><%=dtPagamenti.Rows[i]["Pagamenti_Pagato"].ToString()%></span> 
										<% }else{  %>
											<span class="label alert"><i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i><%=dtPagamenti.Rows[i]["Pagamenti_Pagato"].ToString()%></span>
										<% } %>
                    
										<% if (dtPagamenti.Rows[i]["Pagamenti_DataPagato_IT"].ToString().Length>0){ %>
											il
											<i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtPagamenti.Rows[i]["Pagamenti_DataPagato_IT"].ToString()%>
										<% } %>
									</td>
		              <td class="large-text-center small-text-left"><%=dtPagamenti.Rows[i]["ggRitardoPagamento"].ToString()%></td>
		              <td class="large-text-center small-text-left">
										<i class="fa-duotone fa-circle-info fa-fw" title="<%=dtPagamenti.Rows[i]["Pagamenti_Riferimenti"].ToString()%>"></i>
									</td>
				          <td class="large-text-center small-text-left"><strong><%=dtPagamenti.Rows[i]["Pagamenti_NumeroPromemoria"].ToString()%></strong></td>
				          <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtPagamenti.Rows[i]["Pagamenti_UltimoPromemoria_IT"].ToString()%></strong></td>
		              <td>
										<a href="/admin/app/pagamenti/actions/pagamento-pagato.aspx?Documenti_Ky=<%=dtPagamenti.Rows[i]["Documenti_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>&Pagamenti_Pagato=0&sorgente=scheda-documenti" title="Segna come da pagare"><i class="fa-duotone fa-undo fa-fw"></i></a>
		              	<a href="/admin/app/pagamenti/actions/pagamento-pagato.aspx?Documenti_Ky=<%=dtPagamenti.Rows[i]["Documenti_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>&Pagamenti_Pagato=1&sorgente=scheda-documenti" title="Segna come pagato"><i class="fa-duotone fa-check fa-fw"></i></a>
		              	<a href="/admin/app/pagamenti/crud/elimina-pagamento.aspx?azione=delete&Documenti_Ky=<%=dtPagamenti.Rows[i]["Documenti_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>&sorgente=scheda-documenti" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
									</td>
		            </tr>
		        <%
							decTot+=Convert.ToDecimal(dtPagamenti.Rows[i]["Pagamenti_Importo"]);
							} %>
		    			</tbody>
						  <% if (dtPagamenti.Rows.Count<1){
						      	Response.Write("<tfoot><tr><td colspan=\"12\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
							}else{ %> 
					    	<tfoot>
						      <tr class="totale">
				            <td></td>
						        <td class="large-text-right small-text-left">Totali</td>
						        <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTot.ToString("N2", ci)%></td>
						        <td colspan="13" bgcolor="#ffffff"></td>
						      </tr>
					    	</tfoot>
		          <% } %>
			        </table>
		    	<a style="display:none" href="/admin/app/pagamenti/scheda-pagamenti.aspx?azione=new&Anagrafiche_Ky=<%=GetFieldValue(dtDocumenti, "Anagrafiche_Ky")%>&Documenti_Ky=<%=GetFieldValue(dtDocumenti, "Documenti_Ky")%>&Commesse_Ky=<%=GetFieldValue(dtDocumenti, "Commesse_Ky")%>" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i> Nuovo pagamento</a>
		      <fieldset class="fieldset hide" name="nuovopagamento" id="nuovopagamento" data-toggler=".hide">
		      <legend class="radius">Inserisci pagamento</legend>
					<form class="form" id="form-pagamento" action="/admin/app/pagamenti/crud/salva-pagamento.aspx" method="post" data-abide novalidate>
            <input type="hidden" name="sorgente" id="sorgente" value="scheda-documenti">
            <input type="hidden" name="azione" id="azione" value="new">
            <input type="hidden" name="Anagrafiche_Ky" id="Anagrafiche_Ky" value="<%=GetFieldValue(dtDocumenti, "Anagrafiche_Ky")%>">
            <input type="hidden" name="Pagamenti_Ky" id="Pagamenti_Ky" value="">
            <input type="hidden" name="Commesse_Ky" id="Commesse_Ky" value="<%=GetFieldValue(dtDocumenti, "Commesse_Ky")%>">
            <input type="hidden" name="Pagamenti_DataPagato" id="Pagamenti_DataPagato" value="">
            <input type="hidden" name="Documenti_Ky" id="Documenti_Ky" value="<%=GetFieldValue(dtDocumenti, "Documenti_Ky")%>">
            <input type="hidden" name="PagamentiTipo_Ky" id="PagamentiTipo_Ky" value="1">
            <input type="hidden" name="PagamentiMetodo_Ky" id="PagamentiMetodo_Ky" value="1">
            <input type="hidden" name="Conti_Ky" id="Conti_Ky" value="1">
					<div data-abide-error class="alert callout" style="display: none;">
						<p><i class="fa-duotone fa-triangle-exclamation-triangle fa-lg fa-fw"></i> Ci sono errori nel tuo modulo: compila tutti i campi richiesti e controlla i formati.</p>
					</div>

					<div class="grid-x grid-padding-x">
			    	<div class="large-1 medium-3 small-4 cell">
			    		<label for="Pagamenti_Data" class="text-right middle">Scadenza <i class="fa-duotone fa-calendar-days fa-fw"></i></label>
						</div>
			    	<div class="auto cell">
              <input type="text" name="Pagamenti_Data" id="Pagamenti_Data" class="fdatepicker" size="10" required="required">
              <span class="form-error">Obbligatorio</span>
			        <p class="help-text">Data entro quale il cliente deve pagare. Data di oggi per RIMESSA DIRETTA</p>
			    	</div>
			    	<div class="large-1 medium-3 small-4 cell">
			    		<label for="Pagamenti_Importo" class="text-right middle">Importo <i class="fa-duotone fa-euro-sign fa-fw"></i></label>
						</div>
			    	<div class="auto cell">
		          <input type="text" name="Pagamenti_Importo" id="Pagamenti_Importo" size="6" required="required" pattern="number" min="1" max="1000000" />
              <span class="form-error">Obbligatorio</span>
			        <p class="help-text">La somma degli importi dei pagamenti deve corrispondere al totale del documento</p>
			    	</div>
					</div>
					
					<div class="grid-x grid-padding-x">
			    	<div class="large-1 medium-3 small-4 cell">
			    		<label for="PagamentiMetodo_Ky" class="text-right middle">Tramite <i class="fa-duotone fa-euro-sign fa-fw"></i></label>
						</div>
			    	<div class="auto cell">
					    <select name="PagamentiMetodo_Ky" id="PagamentiMetodo_Ky" required="required">
			          <!--#include file="/var/cache/PagamentiMetodo-options.htm"--> 
              </select>
              <span class="form-error">Obbligatorio</span>
              <script type="text/javascript">
                selectSet('PagamentiMetodo_Ky', '1');
              </script>
              <span class="form-error">Obbligatorio</span>
			        <p class="help-text">Assegno, bonifico, carta, ecc</p>
			    	</div>
			    	<div class="large-1 medium-3 small-4 cell">
			    		<label for="Pagamenti_Riferimenti" class="text-right middle">Riferimenti <i class="fa-duotone fa-tag fa-fw"></i></label>
						</div>
			    	<div class="auto cell">
              <input type="text" name="Pagamenti_Riferimenti" id="Pagamenti_Riferimenti" size="35" required="required" value="<%=GetFieldValue(dtDocumenti, "Documenti_Numero")%> del <%=GetFieldValue(dtDocumenti, "Documenti_Data_IT")%> per <%=GetFieldValue(dtDocumenti, "Documenti_Descrizione")%>"> 
              <span class="form-error">Obbligatorio</span>
			        <p class="help-text">Numero del preventivo, del progetto o di riferimento del rinnovo</p>
			    	</div>
					</div>
					
					<div class="grid-x grid-padding-x">
			    	<div class="large-1 medium-3 small-4 cell">
		              <button type="submit" value="salva" name="salva" class="tiny button success"><i class="fa-duotone fa-square-plus fa-fw"></i> Inserisci</button>
		          </div>
		      </div>
		      </form>
		      </fieldset>
			</div>
		</div>
	</div>
</div>

