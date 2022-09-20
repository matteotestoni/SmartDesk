<%
decTot=0;
%>

<div class="card">					
	<div class="card-divider">
		<h2>Attivit&agrave; comerciali</h2>
		<div class="button-group tiny">
		</div>
	</div>
	<div class="card-section">
		<table class="grid hover scroll" border="0" width="100%" style="width:100%">
	    	<thead>
		      <tr>
				<th width="40" class="text-left">Cod.</th>
				<th width="200" class="text-left">Anagrafica</th>
				<th width="150">Telefono</th>
				<th>Descrizione</th>
				<th width="120" class="text-center">Progetto</th>
				<th width="110">Scadenza</th>
				<th width="40" class="text-center">gg</th>
				<th width="60" class="nowrap"></th>
		      </tr>
	    	</thead>
				<tbody>
	      <%
	      decTot=0;
	  	for (int j = 0; j < dtAttivitaCommerciali.Rows.Count; j++){ %>
	    <tr class="riga<%=i%2%>">
	    	<td class="small-text-left large-text-left show-for-medium-up"><a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=<%=dtAttivitaCommerciali.Rows[j]["Attivita_Ky"].ToString()%>&sorgente=home"><%=dtAttivitaCommerciali.Rows[j]["Attivita_Ky"].ToString()%></a></td>
	      <td>
	        <div class="width200">
						<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtAttivitaCommerciali.Rows[j]["Anagrafiche_Ky"].ToString()%>"><i class="fa-duotone fa-users fa-fw"></i><%=dtAttivitaCommerciali.Rows[j]["Anagrafiche_RagioneSociale"].ToString()%></a> 
	        </div>
	      </td>
				<td><div class="width150"><i class="fa-duotone fa-phone fa-fw"></i><%=dtAttivitaCommerciali.Rows[j]["Anagrafiche_Telefono"].ToString()%></div></td>
	      <td>
					<div class="width250">
	      	<i class="fa-duotone <%=dtAttivitaCommerciali.Rows[j]["AttivitaTipo_Icona"].ToString()%> fa-fw "></i>				                      
					<%
	          Response.Write(dtAttivitaCommerciali.Rows[j]["Attivita_Descrizione"].ToString());
	        %>
	        </div>
	      </td>
	      <td class="small-text-left large-text-center"><% if (dtAttivitaCommerciali.Rows[j]["Commesse_Ky"].ToString().Length>0){ %><i class="fa-duotone fa-circle-info fa-fw has-tip" data-tooltip title="<%=dtAttivitaCommerciali.Rows[j]["Commesse_Titolo"].ToString()%>"></i><% } %></td>
	      <td class="small-text-left large-text-center"><i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtAttivitaCommerciali.Rows[j]["Attivita_Scadenza_IT"].ToString()%></strong></td>
	      <td class="small-text-left large-text-center"><strong><%=Smartdesk.Functions.getGGDaFare(dtAttivitaCommerciali.Rows[j]["ggTrascorsi"].ToString())%></strong></td>
				<td class="show-for-medium-up small-text-left large-text-center nowrap">
					<a href="/admin/app/attivita/actions/attivita-completa.aspx?Anagrafiche_Ky=<%=dtAttivitaCommerciali.Rows[j]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaCommerciali.Rows[j]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivitaCommerciali.Rows[j]["AttivitaSettore_Ky"].ToString()%>&Attivita_Completo=1&sorgente=home" title="completo"><i class="fa-duotone fa-check fa-lg"></i></a>
	    		<a href="/admin/app/attivita/crud/elimina-attivita.aspx?azione=delete&Anagrafiche_Ky=<%=dtAttivitaCommerciali.Rows[j]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaCommerciali.Rows[j]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivitaCommerciali.Rows[j]["AttivitaSettore_Ky"].ToString()%>&sorgente=home" title="elimina"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
				</td>
	    </tr>
			<%
				decTot+=1;
			}
			%>
			</tbody>
			<tfoot>
				<tr class="totale">
	        <td colspan="8" class="text-right">Totale attivit&agrave; da fare: <strong><%=decTot.ToString("N0", ci)%></strong></td>
	        <td></td>
	      </tr>
			</tfoot>
		</table>
	</div>
</div>
