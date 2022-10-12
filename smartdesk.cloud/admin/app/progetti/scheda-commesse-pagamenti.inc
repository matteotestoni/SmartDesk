<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Pagamenti"].Equals(true)){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
	<a name="pagamenti"></a>
	<div class="card">
	  <div class="card-divider">
  		<h2><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i>Pagamenti in entrata del progetto (<%=dtPagamenti.Rows.Count+dtPagamentiRicevuti.Rows.Count%>)</h2>
		</div>
	  <div class="card-section">
				<ul class="horizontal tabs" data-responsive-accordion-tabs="tabs small-accordion medium-tabs large-tabs" role="tablist" id="pagamenti-tabs">
	    		<li class="tabs-title" role="presentational"><a href="#tabs-1">Pagamenti in entrata (<%=dtPagamenti.Rows.Count%>)</a></li>
	    		<li class="tabs-title" role="presentational"><a href="#tabs-2">Pagamenti incassati (<%=dtPagamentiRicevuti.Rows.Count%>)</a></li>
	    	</ul>
	    	<div class="tabs-content" data-tabs-content="pagamenti-tabs">
		  	<section role="tabpanel" aria-hidden="false" class="tabs-panel is-active" id="tabs-1" name="tabs-1">
			      <table class="grid hover scroll" border="0" width="100%">
				    	<thead>
			        <tr>
	                   <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
			          <th width="40" class="text-center">Cod.</th>
			          <th width="110" class="text-center">Scadenza</th>
								<th width="90" class="text-center">Importo</th>
								<th class="text-left" width="200">Tramite</th>
			          <th width="110" class="text-center">Data pagato</th>
			          <th width="110" class="text-center">GG Ritardo</th>
								<th width="250">Riferimenti</th>
				        <th width="80">Promemoria</th>
				        <th width="90">Ultimo</th>
								<th width="60" class="text-center nowrap"></th>
			        </tr>
				    	</thead>
				    	<tbody>
			        <%for (int i = 0; i < dtPagamenti.Rows.Count; i++){ %>
			            <tr>
                            <td><input type="checkbox" class="checkrow" id="record<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>" data-value="<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>" /></td>
					          <td class="text-left nowrap"><a href="/admin/app/pagamenti/scheda-pagamenti.aspx?Pagamenti_Ky=<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>&sorgente=scheda-commessa"><%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%></td>
			              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtPagamenti.Rows[i]["Pagamenti_Data_IT"].ToString()%></td>
			              <td class="large-text-center small-text-left">&euro; <%=dtPagamenti.Rows[i]["Pagamenti_Importo_IT"].ToString()%></td>
			        			<td class="text-left"><i class="fa-duotone <%=dtPagamenti.Rows[i]["PagamentiMetodo_icona"].ToString()%> fa-fw" style="color:<%=dtPagamenti.Rows[i]["PagamentiMetodo_Colore"].ToString()%>"></i><%=dtPagamenti.Rows[i]["PagamentiMetodo_Titolo"].ToString()%> su <%=dtPagamenti.Rows[i]["Conti_Titolo"].ToString()%></td>
			              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtPagamenti.Rows[i]["Pagamenti_DataPagato_IT"].ToString()%></td>
		              	<td class="large-text-center small-text-left"><%=Smartdesk.Functions.getGG(dtPagamenti.Rows[i]["ggTrascorsi"].ToString())%></td>
			              <td><small><%=dtPagamenti.Rows[i]["Pagamenti_Riferimenti"].ToString()%></small></td>
					          <td class="large-text-center small-text-left"><strong><%=dtPagamenti.Rows[i]["Pagamenti_NumeroPromemoria"].ToString()%></strong></td>
					          <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtPagamenti.Rows[i]["Pagamenti_UltimoPromemoria_IT"].ToString()%></strong></td>
			              <td class="text-center nowrap">
											<a href="/admin/app/pagamenti/actions/pagamento-pagato.aspx?azione=update&Anagrafiche_Ky=<%=dtPagamenti.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>&Pagamenti_Pagato=1&sorgente=scheda-commessa" title="Segna come pagato"><i class="fa-duotone fa-check fa-fw"></i></a>
			              	<a href="/admin/app/pagamenti/crud/elimina-pagamento.aspx?azione=delete&Anagrafiche_Ky=<%=dtPagamenti.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>&sorgente=scheda-commessa" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
										</td>
			            </tr>
			        <% } %>
				    	</tbody>
						  <% if (dtPagamenti.Rows.Count<1){
						      	Response.Write("<tfoot><tr><td colspan=\"10\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
							} %> 
			      </table>
		  	</section>
		  	<section role="tabpanel" aria-hidden="true" class="tabs-panel" id="tabs-2" name="tabs-2">
	      <table class="grid hover scroll" border="0" width="100%">
		    	<thead>
	        <tr>
               <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	          <th width="40" class="text-center">Cod.</th>
	          <th width="110" class="text-center">Scadenza</th>
						<th width="90" class="text-center">Importo</th>
						<th class="text-left" width="200">Tramite</th>
	          <th width="110" class="text-center">Data pagato</th>
	          <th width="110" class="text-center">GG Ritardo</th>
						<th width="250">Riferimenti</th>
		        <th width="80">Promemoria</th>
		        <th width="90">Ultimo</th>
						<th width="60" class="text-center nowrap"></th>
	        </tr>
		    	</thead>
		    	<tbody>
	        <%for (int i = 0; i < dtPagamentiRicevuti.Rows.Count; i++){ %>
	            <tr>
                  <td><input type="checkbox" class="checkrow" id="record<%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Ky"].ToString()%>" data-value="<%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Ky"].ToString()%>" /></td>
			          <td class="text-left nowrap"><a href="/admin/app/pagamenti/scheda-pagamenti.aspx?Pagamenti_Ky=<%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Ky"].ToString()%>&sorgente=scheda-commessa"><%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Ky"].ToString()%></td>
	              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Data_IT"].ToString()%></td>
	              <td class="large-text-center small-text-left">&euro; <%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Importo_IT"].ToString()%></td>
	        			<td class="text-left"><i class="fa-duotone <%=dtPagamentiRicevuti.Rows[i]["PagamentiMetodo_icona"].ToString()%> fa-fw" style="color:<%=dtPagamentiRicevuti.Rows[i]["PagamentiMetodo_Colore"].ToString()%>"></i><%=dtPagamentiRicevuti.Rows[i]["PagamentiMetodo_Titolo"].ToString()%> su <%=dtPagamentiRicevuti.Rows[i]["Conti_Titolo"].ToString()%></td>
	              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtPagamentiRicevuti.Rows[i]["Pagamenti_DataPagato_IT"].ToString()%></td>
              	<td class="large-text-center small-text-left"><%=Smartdesk.Functions.getGG(dtPagamentiRicevuti.Rows[i]["ggRitardoPagamento"].ToString())%></td>
	              <td><small><%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Riferimenti"].ToString()%></small></td>
			          <td class="large-text-center small-text-left"><strong><%=dtPagamentiRicevuti.Rows[i]["Pagamenti_NumeroPromemoria"].ToString()%></strong></td>
			          <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtPagamentiRicevuti.Rows[i]["Pagamenti_UltimoPromemoria_IT"].ToString()%></strong></td>
	              <td class="text-center nowrap">
	              	<a href="/admin/app/pagamenti/actions/pagamento-pagato.aspx?azione=update&Anagrafiche_Ky=<%=dtPagamentiRicevuti.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Ky"].ToString()%>&Pagamenti_Pagato=0&sorgente=scheda-commessa" title="Segna come da pagare"><i class="fa-duotone fa-undo fa-fw"></i></a>
	              	<a href="/admin/app/pagamenti/crud/elimina-pagamento.aspx?azione=delete&Anagrafiche_Ky=<%=dtPagamentiRicevuti.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Ky"].ToString()%>&sorgente=scheda-commessa" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
								</td>
	            </tr>
	        <% } %>
		    	</tbody>
				  <% if (dtPagamentiRicevuti.Rows.Count<1){
				      	Response.Write("<tfoot><tr><td colspan=\"10\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
					} %> 
	      </table>
		  	</section>
		  </div>
	</div>
	</div>
	</div>
</div>
<% } %>
