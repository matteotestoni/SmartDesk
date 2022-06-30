<% if (dtLogin.Rows[0]["UtentiGruppi_Aste"].Equals(true) && strAzione!="new"){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
	  <a name="cauzioni"></a>
		<div class="card">
		  <div class="card-divider">
			  <h2><i class="fa-duotone fa-credit-card fa-lg fa-fw"></i>Cauzioni dell'asta (<%=dtAsteCauzioni.Rows.Count%>)</h2>
				<div class="button-group tiny">
					<% if (dtAsteEsperimenti.Rows.Count>0){ %>
            <a href="/admin/app/aste/scheda-astecauzioni.aspx?azione=new&sorgente=scheda-aste&Aste_Ky=<%=GetFieldValue(dtAste, "Aste_Ky")%>" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>nuova cauzione</a>
          <% }else{  %>
            <span class="label warning radius">Nessun esperimento sull'asta</span>
          <% } %>
		  	</div>
		  </div>
		  <div class="card-section">
		    <table class="grid hover scroll" border="0" width="100%">
		    	<thead>
			      <tr>
              <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
			        <th width="30">Cod.</th>
        			<th width="40">Esper.</th>
        			<th width="80" class="text-left">Esito</th>
        			<th width="130">Anagrafica</th>
        			<th width="110" class="text-center date">Data</th>
        			<th width="40">Valore</th>
        			<th width="200">Metodo</th>
        			<th width="40">Riferimenti</th>
        			<th width="40" class="large-text-center small-text-left">Autorizzata</th>
			        <th width="60" class="text-center nowrap"></th>
			      </tr>
		    	</thead>
		    	<tbody>
				    <%for (int i = 0; i < dtAsteCauzioni.Rows.Count; i++){ %>
				        <tr class="riga<%=i%2%>">
		              <td><input type="checkbox" class="checkrow" id="record<%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Ky"].ToString()%>" data-value="<%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Ky"].ToString()%>" /></td>
				          <td><a href="/admin/app/aste/scheda-astecauzioni.aspx?Aste_Ky=<%=dtAsteCauzioni.Rows[i]["Aste_Ky"].ToString()%>&AsteCauzioni_Ky=<%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Ky"].ToString()%>"><%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Ky"].ToString()%></a></td>
	          			<td class="text-left"><%=dtAsteCauzioni.Rows[i]["AsteEsperimenti_Numero"].ToString()%></td>
	          			<td class="text-left"><span class="label" style="background-color:<%=dtAsteCauzioni.Rows[i]["AsteEsperimentiEsiti_Colore"].ToString()%>"><i class="<%=dtAsteCauzioni.Rows[i]["AsteEsperimentiEsiti_Icona"].ToString()%> fa-fw"></i><%=dtAsteCauzioni.Rows[i]["AsteEsperimentiEsiti_Titolo"].ToString()%></span></td>
	          			<td class="text-left"><%=dtAsteCauzioni.Rows[i]["Anagrafiche_Ky"].ToString()%>-<%=dtAsteCauzioni.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></td>
	          			<td class="text-left"><%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Data"].ToString()%></td>
	          			<td class="text-left"><%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Valore"].ToString()%></td>
		              <td class="text-left">
										<i class="fa-duotone <%=dtAsteCauzioni.Rows[i]["PagamentiMetodo_Icona"].ToString()%> fa-fw" style="color:<%=dtAsteCauzioni.Rows[i]["PagamentiMetodo_Colore"].ToString()%>"></i><%=dtAsteCauzioni.Rows[i]["PagamentiMetodo_Titolo"].ToString()%> su <%=dtAsteCauzioni.Rows[i]["Conti_Titolo"].ToString()%><br>
				          </td>
	          			<td class="text-left"><%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Riferimenti"].ToString()%></td>
	          			<td class="large-text-center small-text-left">
    								<% if (dtAsteCauzioni.Rows[i]["AsteCauzioni_Autorizzata"].Equals(true)){ %>
    									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
    								<% }else{  %>
    									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
    								<% } %>
                  </td>
				          <td class="text-center nowrap"><a href="/admin/app/aste/crud/elimina-astecauzioni.aspx?azione=delete&sorgente=scheda-aste&AsteCauzioni_Ky=<%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Ky"].ToString()%>&Aste_Ky=<%=dtAsteCauzioni.Rows[i]["Aste_Ky"].ToString()%>&AsteEsperimenti_Ky=<%=dtAsteCauzioni.Rows[i]["AsteEsperimenti_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></td>
				        </tr>
				    <% } %>
			    	</tbody>
					  <% if (dtAsteCauzioni.Rows.Count<1){
					      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
						} %> 
		    </table>
			</div>    
		</div>
	</div>
</div>
<% } %>
