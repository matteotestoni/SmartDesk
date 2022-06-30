<% if (dtLogin.Rows[0]["UtentiGruppi_Aste"].Equals(true) && strAzione!="new"){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
	  <a name="offerte"></a>
		<div class="card">
		  <div class="card-divider">
			  <h2><i class="fa-duotone fa-calculator fa-lg fa-fw"></i>Proxybid sull'asta (<%=dtAsteProxyBid.Rows.Count%>)</h2>
		  </div>
		  <div class="card-section">
		    <table class="grid hover scroll" border="0" width="100%">
		    	<thead>
			      <tr>
              <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
			        <th width="30">Cod.</th>
        			<th width="40" class="text-left">Anagrafica</th>
        			<th width="40" class="large-text-center small-text-left">Lotto</th>
        			<th width="40" class="large-text-center small-text-left">Esperimento</th>
        			<th width="110" class="text-center date">Data</th>
        			<th width="40" class="large-text-center small-text-left">Prezzo massimo</th>
			        <th width="60" class="text-center nowrap"></th>
			      </tr>
		    	</thead>
		    	<tbody>
				    <%for (int i = 0; i < dtAsteProxyBid.Rows.Count; i++){ 
							if (dtAsteProxyBid.Rows[i]["Annunci_Ky"].ToString()!=strAnnunci_Ky){ %>
				        <tr class="riga<%=i%2%>">
				          <td colspan="10"><strong>Lotto: <%=dtAsteProxyBid.Rows[i]["Annunci_Ky"].ToString()%> - <%=dtAsteProxyBid.Rows[i]["Annunci_Titolo"].ToString()%></strong></td>
				        </tr>
						<%	}
						
						%>
				        <tr class="riga<%=i%2%>">
		              <td><input type="checkbox" class="checkrow" id="record<%=dtAsteProxyBid.Rows[i]["AsteProxyBid_Ky"].ToString()%>" data-value="<%=dtAsteProxyBid.Rows[i]["AsteProxyBid_Ky"].ToString()%>" /></td>
				          <td><%=dtAsteProxyBid.Rows[i]["AsteProxyBid_Ky"].ToString()%></td>
	          			<td class="text-left"><%=dtAsteProxyBid.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></td>
	          			<td class="large-text-center small-text-left"><%=dtAsteProxyBid.Rows[i]["Annunci_Ky"].ToString()%></td>
	          			<td class="large-text-center small-text-left"><%=dtAsteProxyBid.Rows[i]["AsteEsperimenti_Numero"].ToString()%></td>
	          			<td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=Convert.ToDateTime(dtAsteProxyBid.Rows[i]["AsteProxyBid_Data"]).ToString("M/d/yyyy HH:mm:ss.fff",System.Globalization.CultureInfo.InvariantCulture)%></td>
	          			<td class="large-text-center small-text-left">&euro; <%=((decimal)dtAsteProxyBid.Rows[i]["AsteProxyBid_ValoreMax"]).ToString("N2",ci)%></td>
				          <td class="text-center nowrap"><a href="/admin/app/aste/crud/elimina-asteproxybid.aspx?azione=delete&sorgente=scheda-asta&AsteProxyBid_Ky=<%=dtAsteProxyBid.Rows[i]["AsteProxyBid_Ky"].ToString()%>&Aste_Ky=<%=dtAsteProxyBid.Rows[i]["Aste_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></td>
				        </tr>
				    <% 
							strAnnunci_Ky=dtAsteProxyBid.Rows[i]["Annunci_Ky"].ToString();
						} %>
			    	</tbody>
					  <% if (dtAsteProxyBid.Rows.Count<1){
					      	Response.Write("<tfoot><tr><td colspan=\"11\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
						} %> 
		    </table>
			</div>    
		</div>
	</div>
</div>
<% } %>
