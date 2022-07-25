<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Pagamenti"].Equals(true)){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
	<br>
	<a name="pagamenti"></a>
	<div class="card">
	  <div class="card-divider">
	    <h2><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i>Pagamenti in uscita (<%=dtPagamentiDaFare.Rows.Count%>)</h2>
			<div class="button-group tiny">
					<a data-toggle="drop<%=GetFieldValue(dtSpese, "Spese_Ky")%>" aria-controls="drop<%=GetFieldValue(dtSpese, "Spese_Ky")%>" aria-expanded="false" class="tiny button">Segna pagato<i class="fa-duotone fa-caret-down"></i></a>
					<ul id="drop<%=GetFieldValue(dtSpese, "Spese_Ky")%>" class="dropdown-pane no-bullet" data-dropdown data-auto-focus="true" aria-hidden="true" tabindex="-1">
				    <%	for (int i = 0; i < dtPagamentiMetodo.Rows.Count; i++){	%>
						  <li><a href="/admin/app/amministrazione/actions/segna-spesapagata.aspx?Spese_Ky=<%=GetFieldValue(dtSpese, "Spese_Ky")%>&PagamentiMetodo_Ky=<%=dtPagamentiMetodo.Rows[i]["PagamentiMetodo_Ky"].ToString()%>&sorgente=scheda-spese">Segna pagato con <%=dtPagamentiMetodo.Rows[i]["PagamentiMetodo_Titolo"].ToString()%></a></li>
						<% } %>
					</ul>							
					<a href="/admin/app/pagamenti/scheda-pagamenti.aspx?azione=new&Anagrafiche_Ky=<%=GetFieldValue(dtSpese, "Anagrafiche_Ky")%>&Commesse_Ky=<%=GetFieldValue(dtSpese, "Commesse_Ky")%>&Spese_Ky=<%=GetFieldValue(dtSpese, "Spese_Ky")%>&sorgente=scheda-spese" class="button tiny alert">Nuovo pagamento</a>
	    </div>    
		</div>
		<div class="card-section">
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
        <tr>
          <th width="40" class="text-center">Cod.</th>
          <th width="110" class="text-center">Scadenza</th>
					<th width="90" class="text-center">Importo</th>
					<th class="text-left" width="250">Tramite</th>
          <th width="110" class="text-center">Pagato?</th>
          <th width="110" class="text-center">Data pagato</th>
          <th width="110" class="text-center">GG Ritardo</th>
          <th width="110" class="text-center">GG Trascorsi</th>
					<th width="250">Riferimenti</th>
					<th width="50" class="text-center nowrap" data-orderable="false"></th>
        </tr>
	    	</thead>
	    	<tbody>
        <%for (int i = 0; i < dtPagamentiDaFare.Rows.Count; i++){ %>
            <tr>
		          <td class="text-left nowrap"><a href="/admin/app/pagamenti/scheda-pagamenti.aspx?Pagamenti_Ky=<%=dtPagamentiDaFare.Rows[i]["Pagamenti_Ky"].ToString()%>&sorgente=scheda-spese"><%=dtPagamentiDaFare.Rows[i]["Pagamenti_Ky"].ToString()%></a></td>
              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtPagamentiDaFare.Rows[i]["Pagamenti_Data_IT"].ToString()%></td>
              <td class="large-text-center small-text-left">&euro; <%=dtPagamentiDaFare.Rows[i]["Pagamenti_Importo_IT"].ToString()%></td>
			        <td class="text-left"><i class="<%=dtPagamentiDaFare.Rows[i]["PagamentiMetodo_icona"].ToString()%> fa-fw" style="color:<%=dtPagamentiDaFare.Rows[i]["PagamentiMetodo_Colore"].ToString()%>"></i><%=dtPagamentiDaFare.Rows[i]["PagamentiMetodo_Titolo"].ToString()%> su <%=dtPagamentiDaFare.Rows[i]["Conti_Titolo"].ToString()%></td>
              <td class="large-text-center small-text-left">
								<% if (dtPagamentiDaFare.Rows[i]["Pagamenti_Pagato"].ToString()=="si"){ %>
									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
								<% }else{ %>
									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
								<% } %>
							</td>
              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtPagamentiDaFare.Rows[i]["Pagamenti_DataPagato_IT"].ToString()%></td>
              <td class="large-text-center small-text-left"><%=Smartdesk.Functions.getGG(dtPagamentiDaFare.Rows[i]["ggRitardoPagamento"].ToString())%></td>
              <td class="large-text-center small-text-left">
								<%
									if (dtPagamentiDaFare.Rows[i]["Pagamenti_DataPagato_IT"].ToString().Length<1){
									  Response.Write(Smartdesk.Functions.getGG(dtPagamentiDaFare.Rows[i]["ggTrascorsi"].ToString()));
									}
								%>
							</td>
              <td><small><%=dtPagamentiDaFare.Rows[i]["Pagamenti_Riferimenti"].ToString()%></small></td>
              <td class="text-center nowrap">
								<a href="/admin/app/pagamenti/actions/pagamento-pagato.aspx?Spese_Ky=<%=dtPagamentiDaFare.Rows[i]["Spese_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtPagamentiDaFare.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiDaFare.Rows[i]["Pagamenti_Ky"].ToString()%>&Documenti_Ky=<%=dtPagamentiDaFare.Rows[i]["Documenti_Ky"].ToString()%>&Pagamenti_Pagato=1&sorgente=scheda-spese" title="Segna come pagato"><i class="fa-duotone fa-check fa-fw"></i></a>
              	<a href="/admin/app/pagamenti/crud/elimina-pagamento.aspx?azione=delete&Spese_Ky=<%=dtPagamentiDaFare.Rows[i]["Spese_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtPagamentiDaFare.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiDaFare.Rows[i]["Pagamenti_Ky"].ToString()%>&Documenti_Ky=<%=dtPagamentiDaFare.Rows[i]["Documenti_Ky"].ToString()%>&sorgente=scheda-spese" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
							</td>
            </tr>
        <% } %>
	    	</tbody>
			  <% if (dtPagamentiDaFare.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
		</div>
	</div>
</div>
<% } %>
