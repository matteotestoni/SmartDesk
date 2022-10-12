<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Pagamenti"].Equals(true)){ 
  int intMese=0;
  int intAnno=0;
	decimal decTotMese=0;

%>
<div class="grid-container">
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="SitiWeb"></a>
	    		<h2><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i>Pagamenti (<%=dtPagamenti.Rows.Count+dtPagamentiRicevuti.Rows.Count%>)</h2>
					<div class="button-group tiny">
						<a href="/admin/app/pagamenti/scheda-pagamenti.aspx?azione=new&PagamentiTipo_Ky=1&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>Nuovo pagamento</a>
			  	</div>
		  </div>
		  <div class="card-section-tabs">
    	<ul class="horizontal tabs" data-responsive-accordion-tabs="tabs small-accordion medium-tabs large-tabs" role="tablist" id="pagamenti-tabs">
    		<li id="li1" class="tabs-title is-active" role="presentational"><a href="#tabpagamenti-1"><i class="fa-duotone fa-triangle-exclamation fa-lg fa-fw" style="--fa-primary-color:red;--fa-primary-opacity: 1.0"></i> Pagamenti in entrata (<%=dtPagamenti.Rows.Count%>)</a></li>
    		<li id="li2" class="tabs-title" role="presentational"><a href="#tabpagamenti-2"><i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i> Pagamenti incassati ultimi 5 anni (<%=dtPagamentiRicevuti.Rows.Count%>)</a></li>
    		<li id="li3" class="tabs-title" role="presentational"><a href="#tabpagamenti-3"><i class="fa-duotone fa-triangle-exclamation fa-lg fa-fw" style="--fa-primary-color:red;--fa-primary-opacity: 1.0"></i> Pagamenti in uscita (<%=dtPagamentiDaFare.Rows.Count%>)</a></li>
    	</ul>
	  	<div class="tabs-content" data-tabs-content="pagamenti-tabs">
  			<div class="tabs-panel is-active" id="tabpagamenti-1">
  		      <table class="grid hover scroll" border="0" width="100%">
  			    	<thead>
  		        <tr>
  	        		<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
  		          <th width="40" class="text-center">Cod.</th>
  		          <th width="110" class="text-center">Scadenza</th>
  							<th class="text-right" width="110">Importo &euro;</th>
  							<th class="text-left" width="200">Tramite</th>
  		          <th width="110" class="text-center">GG Ritardo</th>
  							<th width="250">Riferimenti</th>
  			        <th width="150" data-orderable="false" class="text-center small-text-left">Promemoria</th>
  			        <th width="110">Ultimo</th>
  							<th width="50" class="text-center nowrap" data-orderable="false"></th>
  		        </tr>
  			    	</thead>
  			    	<tbody>
  		        <%
  							decTot=0;
  							decTotQta=0;
  							decTotIVA=0;
  							decTotServizi=0;
  							for (int i = 0; i < dtPagamenti.Rows.Count; i++){ 
                  //Response.Write(intMese + "-" + Convert.ToDateTime(dtPagamenti.Rows[i]["Pagamenti_Data"]).Month);
                  if (i>1 && intMese!=(Convert.ToDateTime(dtPagamenti.Rows[i]["Pagamenti_Data"]).Month)){
        				  %>
                      <tr class="totale">
        				        <td class="large-text-right small-text-left" colspan="3">Totale mese</td>
        				        <td class="large-text-right small-text-left" style="padding-right:5px;font-weight:700">&euro; <%=decTotMese.ToString("N2", ci)%></td>
        				        <td colspan="8" bgcolor="#ffffff"></td>
        				      </tr>
                  <% 
                  decTotMese=0;
                  }
                
                %>
  		            <tr>
  		          		<td><input type="checkbox" class="checkrow" id="record<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>" data-value="<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>" /></td>
  				          <td class="text-left nowrap"><a href="/admin/app/pagamenti/scheda-pagamenti.aspx?Pagamenti_Ky=<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%></a></td>
  		              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtPagamenti.Rows[i]["Pagamenti_Data_IT"].ToString()%></td>
  		              <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=dtPagamenti.Rows[i]["Pagamenti_Importo_IT"].ToString()%></td>
  			        		<td class="text-left"><i class="<%=dtPagamenti.Rows[i]["PagamentiMetodo_icona"].ToString()%> fa-fw" style="color:<%=dtPagamenti.Rows[i]["PagamentiMetodo_Colore"].ToString()%>"></i><%=dtPagamenti.Rows[i]["PagamentiMetodo_Titolo"].ToString()%> su <%=dtPagamenti.Rows[i]["Conti_Titolo"].ToString()%></td>
  		              <td class="large-text-center small-text-left"><%=Smartdesk.Functions.getGG(dtPagamenti.Rows[i]["ggTrascorsi"].ToString())%></td>
  		              <td>
  										<div class="divwidth250">
  										<a href="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=<%=dtPagamenti.Rows[i]["Documenti_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><i class="fa-duotone fa-file fa-fw"></i></a>
  										<small><%=dtPagamenti.Rows[i]["Pagamenti_Riferimenti"].ToString()%></small>
  										</div>
  									</td>
  				          <td class="text-center small-text-left">
  										<i class="fa-duotone fa-envelope fa-fw"></i><strong><%=dtPagamenti.Rows[i]["Pagamenti_NumeroPromemoria"].ToString()%></strong>
  				          	<i class="fa-duotone fa-phone-square fa-fw"></i><strong><%=dtPagamenti.Rows[i]["Pagamenti_NumeroChiamate"].ToString()%></strong>&nbsp;&nbsp;<a href="/admin/app/attivita/actions/segna-chiamata-pagamenti.aspx?sorgente=scheda-anagrafiche&Pagamenti_Ky=<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>&Documenti_Ky=<%=dtPagamenti.Rows[i]["Documenti_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtPagamenti.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="Segna una chiamata in pi&ugrave;" class="alert"><i class="fa-duotone fa-square-plus fa-fw alert"></i><i class="fa-duotone fa-phone fa-fw"></i></a>
  				          </td>
  				          <td class="text-center small-text-left">
  					          <i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtPagamenti.Rows[i]["Pagamenti_UltimoPromemoria_IT"].ToString()%></strong>
  									</td>
  		              <td class="text-center nowrap">
  										<a href="/admin/app/pagamenti/actions/pagamento-pagato.aspx?Anagrafiche_Ky=<%=dtPagamenti.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>&Documenti_Ky=<%=dtPagamenti.Rows[i]["Documenti_Ky"].ToString()%>&Pagamenti_Pagato=1&sorgente=scheda-anagrafiche" title="Segna come pagato"><i class="fa-duotone fa-check fa-fw"></i></a>
  		              	<a href="/admin/app/pagamenti/crud/elimina-pagamento.aspx?azione=delete&Anagrafiche_Ky=<%=dtPagamenti.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamenti.Rows[i]["Pagamenti_Ky"].ToString()%>&Documenti_Ky=<%=dtPagamenti.Rows[i]["Documenti_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
  									</td>
  		            </tr>
  		        <%
  							decTotMese+=Convert.ToDecimal(dtPagamenti.Rows[i]["Pagamenti_Importo"]);
                intMese=Convert.ToDateTime(dtPagamenti.Rows[i]["Pagamenti_Data"]).Month;
                intAnno=DateTime.Now.Year;
                decTot+=Convert.ToDecimal(dtPagamenti.Rows[i]["Pagamenti_Importo"]);
  							} %>
  			    	</tbody>
  					  <% if (dtPagamenti.Rows.Count<1){
  					      	Response.Write("<tfoot><tr><td colspan=\"13\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
  						}else{ %> 
  			    	<tfoot>
                <tr class="totale">
  				        <td class="large-text-right small-text-left" colspan="3">Totale mese</td>
  				        <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTotMese.ToString("N2", ci)%></td>
  				        <td colspan="8" bgcolor="#ffffff"></td>
  				      </tr>
  				      <tr class="totale">
  				        <td class="large-text-right small-text-left" colspan="3">Totale</td>
  				        <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTot.ToString("N2", ci)%></td>
  				        <td colspan="8" bgcolor="#ffffff"></td>
  				      </tr>
  	    			</tfoot>
  						<% } %> 
  		      </table>
  	  	</div>
  	  	<div class="tabs-panel" id="tabpagamenti-2">
  		      <a href="/admin/view.aspx?CoreModules_Ky=21&CoreEntities_Ky=75&CoreGrids_Ky=233&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>" class="button secondary">Visualizza tutti</a>
            
            <table class="grid hover scroll" border="0" width="100%">
  			    	<thead>
  		        <tr>
  	        		<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
  		          <th width="40" class="text-center">Cod.</th>
  		          <th width="110" class="text-center">Scadenza</th>
  							<th width="110" class="text-center">Importo &euro;</th>
  							<th class="text-left" width="200">Tramite</th>
  		          <th width="110" class="text-center">Data pagato</th>
  		          <th width="110" class="text-center">GG Ritardo</th>
  							<th width="250">Riferimenti</th>
  			        <th width="150" data-orderable="false" class="text-center small-text-left">Promemoria</th>
  			        <th width="110">Ultimo</th>
  							<th width="50" class="text-center nowrap" data-orderable="false"></th>
  		        </tr>
  			    	</thead>
  			    	<tbody>
  		        <%
  							decTot=0;
  							decTotQta=0;
  							decTotIVA=0;
  							decTotServizi=0;
  							for (int i = 0; i < dtPagamentiRicevuti.Rows.Count; i++){ %>
  		            <tr>
  		          		<td><input type="checkbox" class="checkrow" id="record<%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Ky"].ToString()%>" data-value="<%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Ky"].ToString()%>" /></td>
  				          <td class="text-left nowrap"><a href="/admin/app/pagamenti/scheda-pagamenti.aspx?Pagamenti_Ky=<%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Ky"].ToString()%></a></td>
  		              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Data_IT"].ToString()%></td>
  		              <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Importo_IT"].ToString()%></td>
  			        		<td class="text-left"><i class="<%=dtPagamentiRicevuti.Rows[i]["PagamentiMetodo_icona"].ToString()%> fa-fw" style="color:<%=dtPagamentiRicevuti.Rows[i]["PagamentiMetodo_Colore"].ToString()%>"></i><%=dtPagamentiRicevuti.Rows[i]["PagamentiMetodo_Titolo"].ToString()%> su <%=dtPagamentiRicevuti.Rows[i]["Conti_Titolo"].ToString()%></td>
  		              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtPagamentiRicevuti.Rows[i]["Pagamenti_DataPagato_IT"].ToString()%></td>
  		              <td class="large-text-center small-text-left"><%=Smartdesk.Functions.getGG(dtPagamentiRicevuti.Rows[i]["ggRitardoPagamento"].ToString())%></td>
  		              <td>
  										<div class="divwidth250">
  										<a href="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=<%=dtPagamentiRicevuti.Rows[i]["Documenti_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><i class="fa-duotone fa-file fa-fw"></i></a>
  										<small><%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Riferimenti"].ToString()%></small>
  										</div>
  									</td>
  				          <td class="large-text-center small-text-left">
  										<strong><%=dtPagamentiRicevuti.Rows[i]["Pagamenti_NumeroPromemoria"].ToString()%></strong><i class="fa-duotone fa-envelope fa-fw"></i>
  				          	<strong><%=dtPagamentiRicevuti.Rows[i]["Pagamenti_NumeroChiamate"].ToString()%></strong><i class="fa-duotone fa-phone-square fa-fw"></i>
  									</td>
  				          <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtPagamentiRicevuti.Rows[i]["Pagamenti_UltimoPromemoria_IT"].ToString()%></strong></td>
  		              <td class="text-center nowrap">
  										<a href="/admin/app/pagamenti/actions/pagamento-pagato.aspx?Anagrafiche_Ky=<%=dtPagamentiRicevuti.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Ky"].ToString()%>&Pagamenti_Pagato=0&sorgente=scheda-anagrafiche" title="Segna come da pagare"><i class="fa-duotone fa-undo fa-fw"></i></a>
  		              	<a href="/admin/app/pagamenti/crud/elimina-pagamento.aspx?azione=delete&Anagrafiche_Ky=<%=dtPagamentiRicevuti.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiRicevuti.Rows[i]["Pagamenti_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
  									</td>
  		            </tr>
  		        <%
  							decTot+=Convert.ToDecimal(dtPagamentiRicevuti.Rows[i]["Pagamenti_Importo"]);
  							} %>
  			    	</tbody>
  					  <% if (dtPagamentiRicevuti.Rows.Count<1){
  					      	Response.Write("<tfoot><tr><td colspan=\"13\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
  						}else{ %> 
  			    	<tfoot>
  				      <tr class="totale">
  				        <td class="large-text-right small-text-left" colspan="3">Totali</td>
  				        <td class="large-text-right small-text-left" style="padding-right:5px"><%=decTot.ToString("N2", ci)%></td>
  				        <td colspan="8" bgcolor="#ffffff"></td>
  				      </tr>
  	    			</tfoot>
  						<% } %> 
  		      </table>
  	  	</div>
  	  	<div class="tabs-panel" id="tabpagamenti-3">
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
  		          <th width="110" class="text-center">GG Trascorsi</th>
  							<th width="250">Riferimenti</th>
  							<th width="50" class="text-center nowrap" data-orderable="false"></th>
  		        </tr>
  			    	</thead>
  			    	<tbody>
  		        <%for (int i = 0; i < dtPagamentiDaFare.Rows.Count; i++){ %>
  		            <tr>
  		          		<td><input type="checkbox" class="checkrow" id="record<%=dtPagamentiDaFare.Rows[i]["Pagamenti_Ky"].ToString()%>" data-value="<%=dtPagamentiDaFare.Rows[i]["Pagamenti_Ky"].ToString()%>" /></td>
  				          <td class="text-left nowrap"><a href="/admin/app/pagamenti/scheda-pagamenti.aspx?Pagamenti_Ky=<%=dtPagamentiDaFare.Rows[i]["Pagamenti_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtPagamentiDaFare.Rows[i]["Pagamenti_Ky"].ToString()%></a></td>
  		              <td class="large-text-center small-text-left"><%=dtPagamentiDaFare.Rows[i]["Pagamenti_Data_IT"].ToString()%></td>
  		              <td class="large-text-center small-text-left">&euro; <%=dtPagamentiDaFare.Rows[i]["Pagamenti_Importo_IT"].ToString()%></td>
  			        		<td class="text-left"><i class="<%=dtPagamentiDaFare.Rows[i]["PagamentiMetodo_icona"].ToString()%> fa-fw" style="color:<%=dtPagamentiDaFare.Rows[i]["PagamentiMetodo_Colore"].ToString()%>"></i><%=dtPagamentiDaFare.Rows[i]["PagamentiMetodo_Titolo"].ToString()%> su <%=dtPagamentiDaFare.Rows[i]["Conti_Titolo"].ToString()%></td>
  		              <td class="large-text-center small-text-left"><%=dtPagamentiDaFare.Rows[i]["Pagamenti_DataPagato_IT"].ToString()%></td>
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
  										<a href="/admin/app/pagamenti/actions/pagamento-pagato.aspx?Anagrafiche_Ky=<%=dtPagamentiDaFare.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiDaFare.Rows[i]["Pagamenti_Ky"].ToString()%>&Documenti_Ky=<%=dtPagamentiDaFare.Rows[i]["Documenti_Ky"].ToString()%>&Pagamenti_Pagato=1&sorgente=scheda-anagrafiche" title="Segna come pagato"><i class="fa-duotone fa-check fa-fw"></i></a>
  		              	<a href="/admin/app/pagamenti/crud/elimina-pagamento.aspx?azione=delete&Anagrafiche_Ky=<%=dtPagamentiDaFare.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiDaFare.Rows[i]["Pagamenti_Ky"].ToString()%>&Documenti_Ky=<%=dtPagamentiDaFare.Rows[i]["Documenti_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
  									</td>
  		            </tr>
  		        <% } %>
  			    	</tbody>
  					  <% if (dtPagamentiDaFare.Rows.Count<1){
  					      	Response.Write("<tfoot><tr><td colspan=\"10\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
  						} %> 
  		      </table>
  	  	</div>
	  	</div>
      <% if (Smartdesk.Data.Field(dtAnagrafiche, "AnagraficheTipo_Ky")=="4"){ %>
      <script>
        jQuery("#li1").removeClass("is-active");
        jQuery("#tabpagamenti-1").removeClass("is-active");
        jQuery("#li2").removeClass("is-active");
        jQuery("#tabpagamenti-2").removeClass("is-active");
        jQuery("#li3").addClass("is-active");
        jQuery("#tabpagamenti-3").addClass("is-active");
      </script>
      <% } %>
      
			</div>
		</div>
	</div>
</div>
</div>
<% } %>
