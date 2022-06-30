<% if (dtLogin.Rows[0]["UtentiGruppi_Aste"].Equals(true) && strAzione!="new"){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
	  <a name="lotti"></a>
		<div class="card">
		  <div class="card-divider">
			  <h2><i class="fa-duotone fa-building fa-lg fa-fw"></i>Lotti dell'asta (<%=dtAnnunci.Rows.Count%>)</h2>
				<div class="button-group tiny">
					<a href="/admin/app/annunci/scheda-annunci.aspx?azione=new&sorgente=scheda-aste&Aste_Ky=<%=GetFieldValue(dtAste, "Aste_Ky")%>" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>nuovo lotto</a>
		  	</div>
		  </div>
		  <div class="card-section">
		    <table class="grid hover scroll" border="0" width="100%">
		    	<thead>
			      <tr>
              <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
			        <th width="35"></th>
			        <th width="30">Cod.</th>
			        <th width="30">N&deg; lotto</th>
        			<th width="80" class="text-left">Stato</th>
        			<th width="100">Titolo</th>
        			<th width="80">Categoria</th>
        			<th width="80">Valore</th>
        			<th width="80">Riserva</th>
        			<th width="80">Cauzione</th>
        			<th width="80">Rilancio</th>
        			<th width="40">N&deg; foto</th>
			        <th width="60" class="text-center nowrap"></th>
			      </tr>
		    	</thead>
		    	<tbody>
				    <%for (int i = 0; i < dtAnnunci.Rows.Count; i++){ %>
				        <tr class="riga<%=i%2%>">
		              <td><input type="checkbox" class="checkrow" id="record<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>" data-value="<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>" /></td>
									<td class="text-center">
									<% if (dtAnnunci.Rows[i]["Annunci_Foto1"].ToString().Length>10){ %>
			          		<span data-tooltip aria-haspopup="true" data-allow-html="true" data-disable-hover="false" class="has-tip" title="<img src='<%=dtAnnunci.Rows[i]["Annunci_Foto1"].ToString()%>'>"><img src="<%=dtAnnunci.Rows[i]["Annunci_Foto1"].ToString()%>" width="35" height="30" style="width:35px;max-width:35px;height:30px;max-height:30px"></span>
									<% }else{ %>
										<i class="fa-duotone fa-bullhorn fa-fw fa-lg"></i>
									<% } %>
									</td>
	          			<td><%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%></td>
	          			<td><a href="/admin/app/annunci/scheda-annunci.aspx?Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>&Aste_Ky=<%=dtAnnunci.Rows[i]["Aste_Ky"].ToString()%>&sorgente=scheda-aste"><%=dtAnnunci.Rows[i]["Annunci_Numero"].ToString()%></a></td>
	          			<td class="text-left"><span class="label" style="background-color:<%=dtAnnunci.Rows[i]["AnnunciStato_Colore"].ToString()%>"><i class="<%=dtAnnunci.Rows[i]["AnnunciStato_Icona"].ToString()%> fa-fw"></i><%=dtAnnunci.Rows[i]["AnnunciStato_Titolo"].ToString()%></span></td>
				          <td><%=dtAnnunci.Rows[i]["Annunci_Titolo"].ToString()%></td>
				          <td><%=dtAnnunci.Rows[i]["AnnunciCategorie_Titolo"].ToString()%></td>
				          <td>&euro; <%=Convert.ToDecimal(dtAnnunci.Rows[i]["Annunci_Valore"]).ToString("N2", ci)%></td>
				          <td>&euro; <%=Convert.ToDecimal(dtAnnunci.Rows[i]["Annunci_PrezzoRiserva"]).ToString("N2", ci)%></td>
				          <td>&euro; <%=Convert.ToDecimal(dtAnnunci.Rows[i]["Annunci_Cauzione"]).ToString("N2", ci)%></td>
				          <td>&euro; <%=Convert.ToDecimal(dtAnnunci.Rows[i]["Annunci_Rilancio"]).ToString("N2", ci)%></td>
				          <td><%=dtAnnunci.Rows[i]["Annunci_NumeroFoto"].ToString()%></td>
				          <td class="text-center nowrap"><a href="/admin/app/annunci/crud/elimina-annunci.aspx?sorgente=scheda-aste&azione=delete&Aste_Ky=<%=dtAnnunci.Rows[i]["Aste_Ky"].ToString()%>&Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></td>
				        </tr>
				    <% } %>
			    	</tbody>
					  <% if (dtAnnunci.Rows.Count<1){
					      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
						} %> 
		    </table>
			</div>    
		</div>
	</div>
</div>
<% } %>
