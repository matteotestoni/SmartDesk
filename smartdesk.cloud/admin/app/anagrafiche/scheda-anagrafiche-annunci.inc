<% if (dtLogin.Rows[0]["UtentiGruppi_Catalogo"].Equals(true) && strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Annunci"].Equals(true)){ %>
<div class="grid-container" id="divannunci" data-magellan-target="divannunci">
	<div class="grid-x grid-padding-x">
		<div class="small-12 medium-12 large-12 cell">
			<div class="card">
			  <div class="card-divider">
	    		<a name="SitiWeb"></a>
  					<h2><i class="fa-duotone fa-bullhorn fa-lg fa-fw"></i>Ultimi 5 annunci dell'anagrafica (<%=dtAnnunci.Rows.Count%>)</h2>
						<div class="button-group tiny">
							<a href="/admin/app/annunci/elenco-annunci.aspx?CoreModules_Ky=3&CoreEntities_Ky=48&CoreGrids_Ky=42&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button secondary"><i class="fa-duotone fa-eye fa-fw"></i> Visualizza tutti</a>
							<a href="/admin/app/annunci/scheda-annunci.aspx?CoreModules_Ky=3&CoreEntities_Ky=48&CoreGrids_Ky=42&azione=new&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button"><i class="fa-duotone fa-square-plus fa-fw"></i> Nuovo annuncio</a>
				  	</div>
			  </div>
			  <div class="card-section">
		    <table class="grid hover scroll" border="0" width="100%">
		    	<thead>
			      <tr>
					<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
					<th width="100"></th>
					<th width="30">Codice/N&deg;</th>
					<th width="300">Titolo</th>
					<th width="200">Tipo / Categoria</th>
					<th width="200">Localizzazione</th>
					<th width="60" class="text-right">Cerco</th>
					<th width="60" class="text-right">Offro</th>
					<th width="80" class="text-center">Stato</th>
					<th width="60" class="text-right">Foto</th>
					<th width="60" class="text-right">Visite</th>
					<th width="12" class="nowrap" data-orderable="false"></th>
			      </tr>
		    	</thead>
		    	<tbody>
				    <%
					for (int i = 0; i < dtAnnunci.Rows.Count; i++){ %>
		        <tr class="riga<%=i%2%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>" data-value="<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>" /></td>
							<td class="text-center">
							<% if (dtAnnunci.Rows[i]["Annunci_Foto1"].ToString().Length>10){ %>
	          		<span data-tooltip aria-haspopup="true" data-allow-html="true" data-disable-hover="false" class="has-tip" title="<img src='<%=dtAnnunci.Rows[i]["Annunci_Foto1"].ToString()%>'>"><img src="<%=dtAnnunci.Rows[i]["Annunci_Foto1"].ToString()%>" width="100" height="75" style="width:100px;max-width:100px;height:75px;max-height:75px"></span>
							<% }else{ %>
								<i class="fa-duotone fa-bullhorn fa-fw fa-lg"></i>
							<% } %>
							</td>
		          <td>
								<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%><BR>
								<%=dtAnnunci.Rows[i]["Annunci_Numero"].ToString()%>
							</td>
		          <td>
								<div class="width300">
									<a href="/admin/app/annunci/scheda-annunci.aspx?Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>"><%=dtAnnunci.Rows[i]["Annunci_Titolo"].ToString()%></a><br>
								</div>
								<div style="max-height:70px;overflow:hidden;line-height:1rem;">
									<small><%=dtAnnunci.Rows[i]["Annunci_Descrizione"].ToString()%></small>
								</div>
							</td>
		          <td>
								<%=dtAnnunci.Rows[i]["AnnunciTipo_Titolo"].ToString()%><br>
		          	<%=dtAnnunci.Rows[i]["AnnunciCategorie_Titolo"].ToString()%>
							</td>
		          <td><div class="width300"><img src="https://cdn.smartdesk.cloud/img/flags/<%=dtAnnunci.Rows[i]["Nazioni_Codice"].ToString()%>.png" hspace="4" vspace="2" align="left"><%=dtAnnunci.Rows[i]["Nazioni_Codice"].ToString()%>/<%=dtAnnunci.Rows[i]["Regioni_Regione"].ToString()%>/<%=dtAnnunci.Rows[i]["Comuni_Comune"].ToString()%></div></td>
        			<td class="text-center">
								<% if (dtAnnunci.Rows[i]["Annunci_Cerco"].Equals(true)){ %>
									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
								<% }else{  %>
									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
								<% } %>
              </td>
        			<td class="text-center">
								<% if (dtAnnunci.Rows[i]["Annunci_Offro"].Equals(true)){ %>
									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
								<% }else{  %>
									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
								<% } %>
              </td>
		          <td class="text-center"><span class="label" style="background-color:<%=dtAnnunci.Rows[i]["AnnunciStato_Colore"].ToString()%>"><i class="fa-duotone <%=dtAnnunci.Rows[i]["AnnunciStato_icona"].ToString()%> fa-fw"></i><%=dtAnnunci.Rows[i]["AnnunciStato_Titolo"].ToString()%></span></td>
		          <td class="text-right"><%=dtAnnunci.Rows[i]["Annunci_NumeroFoto"].ToString()%></td>
		          <td class="text-right"><span class="badge"><%=dtAnnunci.Rows[i]["Annunci_Visite"].ToString()%></span></td>
		          <td><a href="/admin/app/annunci/crud/elimina-annunci.aspx?azione=delete&sorgente=elenco-annunci&Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>&Aste_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
		        </tr>
						<% } %> 
					</tbody>
					  <% if (dtAnnunci.Rows.Count<1){
					      	Response.Write("<tfoot><tr><td colspan=\"12\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
						} %> 
		    </table>
			</div>
		</div>
	</div>
</div>
</div>
<% } %>
