      <div class="divgrid">
        <div class="grid-x grid-padding-x">
          <div class="large-9 medium-9 small-12 cell">
      			<asp:Label ID="PaginaSotto" runat="server" class="paginazione"></asp:Label>
          </div>
          <div class="large-3 medium-3 small-4 cell end">
            <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
            <div class="input-group">
              <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
                <option value="">Azioni di gruppo</option>
                <option value="delete" data-action="/admin/app/attivita/crud/elimina-attivita.aspx">Elimina</option>
              </select>
              <div class="input-group-button">
                <input type="hidden" id="sorgente" name="sorgente" value="elenco-attivita">
                <input type="hidden" id="azione" name="azione" value="">
                <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
                <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
                <input type="submit" id="doaction" class="button secondary" value="Applica">
              </div>
            </div>
            </form>
          </div>
        </div>
				<table class="grid hover scroll" border="0" width="100%">
	    	<thead>
		      <tr>
	          <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
          	<th width="40" class="text-left">Cod.</th>
		        <th width="120" class="text-center">Data Consegna</th>
		        <th width="120" class="text-center">Data Chiusura</th>
		        <th width="150" data-orderable="false">Anagrafica</th>
		        <th width="150" data-orderable="false">Progetto</th>
		        <th width="350" data-orderable="false">Descrizione attivit&agrave;</th>
		        <th width="60" data-orderable="false" class="text-right">Ore</th>
      			<th width="80" class="text-right">Utente</th>
		        <th width="12" class="nowrap" data-orderable="false"></th>
		      </tr>
	    	</thead>
					<tbody>
				<%
				for (int i = 0; i < dtGridData.Rows.Count; i++){ %>
		        <tr class="riga<%=i%2%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtGridData.Rows[i]["Attivita_Ky"].ToString()%>" data-value="<%=dtGridData.Rows[i]["Attivita_Ky"].ToString()%>" /></td>
				      <td class="text-left nowrap"><a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=<%=dtGridData.Rows[i]["Attivita_Ky"].ToString()%>&Utenti_Ky=<%=dtGridData.Rows[i]["Utenti_Ky"].ToString()%>&sorgente=elenco-attivita"><%=dtGridData.Rows[i]["Attivita_Ky"].ToString()%></a></td>
		          <td class="text-center"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtGridData.Rows[i]["Attivita_Scadenza_IT"].ToString()%></td>
		          <td class="text-center"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtGridData.Rows[i]["Attivita_Chiusura_IT"].ToString()%></td>
		          <td>
								<div class="width200">
									<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtGridData.Rows[i]["Anagrafiche_Ky"].ToString()%>">
                  <% if (dtGridData.Rows[i]["Anagrafiche_SitoWeb"].ToString().Length>1){ %>
                  <img src="https://www.google.com/s2/favicons?domain=<%=dtGridData.Rows[i]["Anagrafiche_SitoWeb"].ToString()%>" width="16" height="16" border="0">
                  <% }else{ %>
                  <i class="fa-duotone fa-user fa-fw"></i>
                  <% } %>  
									<%=dtGridData.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
								</div>
							</td>
							<td>
								<% if (dtGridData.Rows[i]["Commesse_Ky"].ToString().Length>0 && dtGridData.Rows[i]["Commesse_Ky"].ToString()!="0"){ %>
								<div class="width200">
									<a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtGridData.Rows[i]["Commesse_Ky"].ToString()%>"><i class="fa-duotone fa-building fa-fw"></i><%=dtGridData.Rows[i]["Commesse_Riferimenti"].ToString()%></a>
								</div>
								<% } %>
							</td>
							<td>
								<div class="width350">
								<i class="fa-duotone <%=dtGridData.Rows[i]["AttivitaTipo_Icona"].ToString()%> fa-fw "></i>
							 	<% if (dtGridData.Rows[i]["Attivita_Trasferta"].Equals(true)){ %>
									<i class="fa-duotone fa-car fa-fw"></i>
							 	<% } %>
								<small><%=dtGridData.Rows[i]["Attivita_Descrizione"].ToString()%></small>
                </div>
							</td>
              <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><%=dtGridData.Rows[i]["Attivita_Ore"].ToString()%></td>
							<td class="text-right show-for-medium-up"><i class="fa-duotone fa-user-secret fa-fw"></i><%=dtGridData.Rows[i]["Utenti_Iniziali"].ToString()%></td>
		          <td><a href="/admin/app/attivita/crud/elimina-trasferta.aspx?azione=delete&Attivita_Ky=<%=dtGridData.Rows[i]["Attivita_Ky"].ToString()%>&Utenti_Ky=<%=dtGridData.Rows[i]["Utenti_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
		        </tr>
			    <%			
					} %>
				</tbody>
    		</table>
        </div>

