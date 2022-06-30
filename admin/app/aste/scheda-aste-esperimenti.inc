<% if (dtLogin.Rows[0]["UtentiGruppi_Aste"].Equals(true) && strAzione!="new"){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
	   <a name="esperimenti"></a>
		<div class="card">
		  <div class="card-divider">
			  <h2><i class="fa-duotone fa-sync fa-lg fa-fw"></i>Esperimenti dell'asta (<%=dtAsteEsperimenti.Rows.Count%>)</h2>
				<div class="button-group tiny">
					<a href="/admin/app/aste/scheda-asteesperimenti.aspx?azione=new&sorgente=scheda-aste&Aste_Ky=<%=GetFieldValue(dtAste, "Aste_Ky")%>" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>nuovo esperimento</a>
		  	</div>
		  </div>
		  <div class="card-section">
		    <table class="grid hover scroll" border="0" width="100%">
		    	<thead>
			      <tr>
              <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
        			<th width="40">Codice</th>
        			<th width="40">Num&deg;</th>
        			<th width="80" class="text-left">Esito</th>
        			<th width="40" class="text-center">Ribasso</th>
        			<th width="40" class="text-center">Inizio</th>
        			<th width="40" class="text-center">Termine</th>
        			<th width="40" class="text-center">Pubblicazione</th>
        			<th width="40" class="text-center">Chiusura</th>
			        <th width="60" class="text-center nowrap"></th>
			      </tr>
		    	</thead>
		    	<tbody>
				    <%for (int i = 0; i < dtAsteEsperimenti.Rows.Count; i++){ %>
				        <tr class="riga<%=i%2%>">
		              <td><input type="checkbox" class="checkrow" id="record<%=dtAsteEsperimenti.Rows[i]["AsteEsperimenti_Ky"].ToString()%>" data-value="<%=dtAsteEsperimenti.Rows[i]["AsteEsperimenti_Ky"].ToString()%>" /></td>
	          			<td><a href="/admin/app/aste/scheda-asteesperimenti.aspx?AsteEsperimenti_Ky=<%=dtAsteEsperimenti.Rows[i]["AsteEsperimenti_Ky"].ToString()%>&Aste_Ky=<%=dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString()%>&sorgente=scheda-aste"><%=dtAsteEsperimenti.Rows[i]["AsteEsperimenti_Ky"].ToString()%></a></td>
	          			<td><a href="/admin/app/aste/scheda-asteesperimenti.aspx?AsteEsperimenti_Ky=<%=dtAsteEsperimenti.Rows[i]["AsteEsperimenti_Ky"].ToString()%>&Aste_Ky=<%=dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString()%>&sorgente=scheda-aste"><%=dtAsteEsperimenti.Rows[i]["AsteEsperimenti_Numero"].ToString()%></a></td>
	          			<td class="text-left"><span class="label" style="background-color:<%=dtAsteEsperimenti.Rows[i]["AsteEsperimentiEsiti_Colore"].ToString()%>"><i class="<%=dtAsteEsperimenti.Rows[i]["AsteEsperimentiEsiti_Icona"].ToString()%> fa-fw"></i><%=dtAsteEsperimenti.Rows[i]["AsteEsperimentiEsiti_Titolo"].ToString()%></span></td>
	          			<td class="large-text-center small-text-left"><%=dtAsteEsperimenti.Rows[i]["AsteEsperimenti_PercentualeRibasso"].ToString()%></td>
	          			<td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=Convert.ToDateTime(dtAsteEsperimenti.Rows[i]["AsteEsperimenti_DataInizio"]).ToString("d/M/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":")%></td>
	          			<td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=Convert.ToDateTime(dtAsteEsperimenti.Rows[i]["AsteEsperimenti_DataTermine"]).ToString("d/M/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":")%></td>
	          			<td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=Convert.ToDateTime(dtAsteEsperimenti.Rows[i]["AsteEsperimenti_DataPubblicazione"]).ToString("d/M/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":")%></td>
	          			<td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=Convert.ToDateTime(dtAsteEsperimenti.Rows[i]["AsteEsperimenti_DataChiusura"]).ToString("d/M/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":")%></td>
				          <td class="text-center nowrap"><a href="/admin/app/aste/crud/elimina-asteesperimenti.aspx?azione=delete&AsteEsperimenti_Ky=<%=dtAsteEsperimenti.Rows[i]["AsteEsperimenti_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></td>
				        </tr>
				    <% } %>
			    	</tbody>
					  <% if (dtAsteEsperimenti.Rows.Count<1){
					      	Response.Write("<tfoot><tr><td colspan=\"10\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
						} %> 
		    </table>
			</div>    
		</div>
	</div>
</div>
<% } %>
