<% if (dtLogin.Rows[0]["UtentiGruppi_Aste"].Equals(true) && strAzione!="new"){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
	  <a name="commissioni"></a>
		<div class="card">
		  <div class="card-divider">
			  <h2><i class="fa-duotone fa-money-bill-1-wave fa-lg fa-fw"></i>Commissioni dell'asta (<%=dtAsteCommissioni.Rows.Count%>)</h2>
				<div class="button-group tiny">
          <a href="/admin/form.aspx?CoreModules_Ky=5&CoreEntities_Ky=63&CoreForms_Ky=185&azione=new&sorgente=scheda-aste&Aste_Ky=<%=GetFieldValue(dtAste, "Aste_Ky")%>" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>nuova commissione</a>
          <a href="/admin/app/aste/actions/aste-inseriscicommissionidefault.aspx?azione=new&sorgente=scheda-aste&Aste_Ky=<%=GetFieldValue(dtAste, "Aste_Ky")%>&AsteNatura_Ky=1" class="tiny button secondary"><i class="fa-duotone fa-plane fa-fw"></i>inserisci commissioni default Mobiliare</a>
          <a href="/admin/app/aste/actions/aste-inseriscicommissionidefault.aspx?azione=new&sorgente=scheda-aste&Aste_Ky=<%=GetFieldValue(dtAste, "Aste_Ky")%>&AsteNatura_Ky=2" class="tiny button secondary"><i class="fa-duotone fa-home fa-fw"></i>inserisci commissioni default Immobiliare</a>
		  	</div>
		  </div>
		  <div class="card-section">
		    <table class="grid hover scroll" border="0" width="100%">
		    	<thead>
			      <tr>
              <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
			        <th width="30">Cod.</th>
        			<th width="120" class="text-right">Da  &euro;</th>
        			<th width="120" class="text-right">A  &euro;</th>
        			<th width="120" class="text-right">Commissione %</th>
			        <th width="60" class="text-center nowrap"></th>
			      </tr>
		    	</thead>
		    	<tbody>
				    <%for (int i = 0; i < dtAsteCommissioni.Rows.Count; i++){ %>
				        <tr class="riga<%=i%2%>">
		              <td><input type="checkbox" class="checkrow" id="record<%=dtAsteCommissioni.Rows[i]["AsteCommissioni_Ky"].ToString()%>" data-value="<%=dtAsteCommissioni.Rows[i]["AsteCommissioni_Ky"].ToString()%>" /></td>
				          <td><a href="/admin/form.aspx?CoreModules_Ky=5&CoreEntities_Ky=63&CoreForms_Ky=185&Aste_Ky=<%=dtAsteCommissioni.Rows[i]["Aste_Ky"].ToString()%>&AsteCommissioni_Ky=<%=dtAsteCommissioni.Rows[i]["AsteCommissioni_Ky"].ToString()%>"><%=dtAsteCommissioni.Rows[i]["AsteCommissioni_Ky"].ToString()%></a></td>
	          			<td class="text-right"><%=dtAsteCommissioni.Rows[i]["AsteCommissioni_Da"].ToString()%> &euro;</td>
	          			<td class="text-right"><%=dtAsteCommissioni.Rows[i]["AsteCommissioni_A"].ToString()%> &euro;</td>
	          			<td class="text-right"><%=dtAsteCommissioni.Rows[i]["AsteCommissioni_Commissione"].ToString()%>%</td>
				          <td class="text-center nowrap"><a href="/admin/app/aste/crud/elimina-astecommissioni.aspx?azione=delete&sorgente=scheda-aste&AsteCommissioni_Ky=<%=dtAsteCommissioni.Rows[i]["AsteCommissioni_Ky"].ToString()%>&Aste_Ky=<%=dtAsteCommissioni.Rows[i]["Aste_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></td>
				        </tr>
				    <% } %>
			    	</tbody>
					  <% if (dtAsteCommissioni.Rows.Count<1){
					      	Response.Write("<tfoot><tr><td colspan=\"6\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
						} %> 
		    </table>
			</div>    
		</div>
	</div>
</div>
<% } %>
