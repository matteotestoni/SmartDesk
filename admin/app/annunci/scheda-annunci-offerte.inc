<% if (dtLogin.Rows[0]["UtentiGruppi_Aste"].Equals(true) && strAzione!="new"){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
	  <a name="offerte"></a>
		<div class="card">
		  <div class="card-divider">
			    <h2><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i>Offerte del lotto (<%=dtAnnunciOfferte.Rows.Count%>)</h2>
		  </div>
		  <div class="card-section">
		    <table class="grid hover scroll" border="0" width="100%">
		    	<thead>
			      <tr>
              <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
			        <th width="30">Cod.</th>
			        <th width="60">Asta</th>
			        <th width="60">Esperimento</th>
        			<th width="40">Anagrafica</th>
        			<th width="110" class="text-center date">Data</th>
        			<th width="40">Sec./Millisec.</th>
        			<th width="40">Valore</th>
			        <th width="60" class="text-center nowrap"></th>
			      </tr>
		    	</thead>
		    	<tbody>
				    <%for (int i = 0; i < dtAnnunciOfferte.Rows.Count; i++){ %>
				        <tr class="riga<%=i%2%>">
		              <td><input type="checkbox" class="checkrow" id="record<%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Ky"].ToString()%>" data-value="<%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Ky"].ToString()%>" /></td>
				          <td><a href="/admin/app/annunci/scheda-annunciofferte.aspx?Annunci_Ky=<%=dtAnnunciOfferte.Rows[i]["Annunci_Ky"].ToString()%>&AnnunciOfferte_Ky=<%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Ky"].ToString()%>"><%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Ky"].ToString()%></a></td>
				          <td><a href="/admin/app/aste/scheda-aste.aspx?Aste_Ky=<%=dtAnnunciOfferte.Rows[i]["Aste_Ky"].ToString()%>"><%=dtAnnunciOfferte.Rows[i]["Aste_Titolo"].ToString()%></a></td>
				          <td><a href="/admin/app/aste/scheda-aste.aspx?Aste_Ky=<%=dtAnnunciOfferte.Rows[i]["Aste_Ky"].ToString()%>"><%=dtAnnunciOfferte.Rows[i]["AsteEsperimenti_Ky"].ToString()%></a></td>
	          			<td class="text-left"><%=dtAnnunciOfferte.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></td>
	          			<td class="text-left"><%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Data"].ToString()%></td>
	          			<td class="text-left"><%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Secondi"].ToString()%>:<%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Millisecondi"].ToString()%></td>
	          			<td class="text-left"><%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Valore"].ToString()%></td>
				          <td class="text-center nowrap"><a href="/admin/app/aste/crud/elimina-annunciofferte.aspx?azione=delete&AnnunciOfferte_Ky=<%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></td>
				        </tr>
				    <% } %>
			    	</tbody>
					  <% if (dtAnnunciOfferte.Rows.Count<1){
					      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
						} %> 
		    </table>
			</div>    
		</div>
	</div>
</div>
<% } %>
