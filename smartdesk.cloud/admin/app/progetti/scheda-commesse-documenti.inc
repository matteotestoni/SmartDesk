<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Vendite"].Equals(true)){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
	<div class="card">
	  <div class="card-divider">
			<h2><i class="fa-duotone fa-file fa-lg fa-fw"></i>Documenti del progetto (<%=dtDocumenti.Rows.Count%>)</h2>
			<div class="button-group tiny">
					<a href="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&azione=new&Commesse_Ky=<%=strCommesse_Ky%>&Anagrafiche_Ky=<%=GetFieldValue(dtCommesse, "Anagrafiche_Ky")%>&sorgente=scheda-commessa" class="button secondary tiny"><i class="fa-duotone fa-square-plus fa-fw"></i> Nuovo documento</a>
			</div>
	  </div>
	  <div class="card-section">
		    <table class="grid hover scroll" border="0" width="100%">
		    	<thead>
			      <tr>
                    <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
			        <th width="30">Cod.</th>
        			<th width="40">Az.</th>
			        <th width="80">Tipo</th>
			        <th width="80" class="large-text-center small-text-left">Stato</th>
			        <th width="40">N&deg;</th>
			        <th width="110" class="text-center date">Data</th>
			        <th width="100" class="text-center">Imponibile &euro;</th>
			        <th width="90" class="text-center">IVA &euro;</th>
			        <th width="80" class="text-center">Totale &euro;</th>
			        <th width="200">Email fatture</th>
			        <th width="150">Riferimenti</th>
				      <th width="60">Utente</th>
			        <th width="60" class="text-center nowrap"></th>
			      </tr>
		    	</thead>
		    	<tbody>
				    <%
							decTot=0;
							decTotIVA=0;
							decTotServizi=0;
							for (int i = 0; i < dtDocumenti.Rows.Count; i++){
				      if (intAnno!=Convert.ToInt32(dtDocumenti.Rows[i]["Documenti_Anno"].ToString()) && i>1 && dtDocumenti.Rows.Count>0){
				      %>
								<tr>
				          <td class="large-text-right small-text-left" bgcolor="#cccccc" colspan="5">Totale:</td>
				          <td class="large-text-right small-text-left" bgcolor="#cccccc"><strong><%=decTotServizi.ToString("N2", ci)%></strong></td>
				          <td class="large-text-right small-text-left" bgcolor="#cccccc"><strong><%=decTotIVA.ToString("N2", ci)%></strong></td>
				          <td class="large-text-right small-text-left" bgcolor="#cccccc"><strong><%=decTot.ToString("N2", ci)%></strong></td>
				          <td colspan="4" bgcolor="#cccccc"></td>
				        </tr>
							<%						
								decTot=0;
								decTotIVA=0;
								decTotServizi=0;
							} %>
				        <tr class="riga<%=i%2%>">
                          <td><input type="checkbox" class="checkrow" id="record<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>" data-value="<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>" /></td>
				          <td>
				            <a href="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>&azione=modifica"><%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%></a> 
				          </td>
	          			<td class="large-text-center small-text-left"><%=dtDocumenti.Rows[i]["Aziende_Codice"].ToString()%></td>
				          <td class="large-text-center small-text-left"><%=dtDocumenti.Rows[i]["DocumentiTipo_Descrizione"].ToString()%></td>
	          			<td class="large-text-center small-text-left"><%=Smartdesk.Documenti.getStato(dtDocumenti.Rows[i]["DocumentiStato_Ky"].ToString(), dtDocumenti.Rows[i]["DocumentiStato_Descrizione"].ToString())%></td>
				          <td class="large-text-center small-text-left"><%=dtDocumenti.Rows[i]["Documenti_Numero"].ToString()%></td>
				          <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtDocumenti.Rows[i]["Documenti_Data_IT"].ToString()%></td>
				          <td class="large-text-right small-text-left"><%=((decimal)dtDocumenti.Rows[i]["Documenti_TotaleRighe"]).ToString("N2", ci)%></td>
				          <td class="large-text-right small-text-left"><%=((decimal)dtDocumenti.Rows[i]["Documenti_TotaleIVA"]).ToString("N2", ci)%></td>
				          <td class="large-text-right small-text-left"><%=((decimal)dtDocumenti.Rows[i]["Documenti_Totale"]).ToString("N2", ci)%></td>
				          <td><i class="fa-duotone fa-envelope fa-fw"></i><%=dtDocumenti.Rows[i]["Anagrafiche_EmailAmministrazione"].ToString()%></td>
				          <td class="text-left">
										<div class="width150">
										<%=dtDocumenti.Rows[i]["Documenti_Riferimenti"].ToString()%>
										<% if (dtDocumenti.Rows[i]["Commesse_Ky"].ToString().Length>0){ %>
											| Progetto:<a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtDocumenti.Rows[i]["Commesse_Ky"].ToString()%>&sorgente=scheda-commessa" title="<%=dtDocumenti.Rows[i]["Commesse_Titolo"].ToString()%>"><i class="fa-duotone fa-circle-info fa-fw"></i><%=dtDocumenti.Rows[i]["Commesse_Riferimenti"].ToString()%></a>
										<% } %>
										</div>
									</td>
				      		<td class="large-text-center small-text-left"><%=dtDocumenti.Rows[i]["Utenti_Iniziali"].ToString()%></td>
				          <td class="text-center nowrap"><a href="/admin/app/documenti/crud/elimina-documento.aspx?azione=delete&Documenti_Ky=<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></td>
				        </tr>
				    <%
				      intAnno=Convert.ToInt32(dtDocumenti.Rows[i]["Documenti_Anno"].ToString());
							intDocumenti_Ky=Convert.ToInt32(dtDocumenti.Rows[i]["Documenti_Ky"].ToString());
				      decTot+=Convert.ToDecimal(dtDocumenti.Rows[i]["Documenti_Totale"]);
				      decTotServizi+=Convert.ToDecimal(dtDocumenti.Rows[i]["Documenti_TotaleRighe"]);
				      decTotIVA+=Convert.ToDecimal(dtDocumenti.Rows[i]["Documenti_TotaleIVA"]);
				    } %>
					  <% if (dtDocumenti.Rows.Count>0){ %>
						<tr>
			        <td class="large-text-right small-text-left" bgcolor="#ffffff" colspan="5"></td>
			        <td class="large-text-right small-text-left" bgcolor="#cccccc">Totale:</td>
			        <td class="large-text-right small-text-left" bgcolor="#cccccc"><strong><%=decTotServizi.ToString("N2", ci)%></strong></td>
			        <td class="large-text-right small-text-left" bgcolor="#cccccc"><strong><%=decTotIVA.ToString("N2", ci)%></strong></td>
			        <td class="large-text-right small-text-left" bgcolor="#cccccc"><strong><%=decTot.ToString("N2", ci)%></strong></td>
			        <td colspan="4" class="text-right"></td>
			      </tr>
						<% } %> 
			    	</tbody>
					  <% if (dtDocumenti.Rows.Count<1){
					      	Response.Write("<tfoot><tr><td colspan=\"13\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
						} %> 
		    </table>
			</div>
		</div>
	</div>
</div>
	    <% } %>
