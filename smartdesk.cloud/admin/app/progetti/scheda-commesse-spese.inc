<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Spese"].Equals(true)){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
  <a name="spese"></a>
	<div class="card">
	  <div class="card-divider">
  		<h2><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i>Spese del progetto (<% if (dtSpese!=null){ Response.Write(dtSpese.Rows.Count); } %>)</h2>
			<div class="button-group tiny">
					<a href="/admin/app/amministrazione/scheda-spese.aspx?CoreModules_Ky=2&CoreEntities_Ky=1&azione=new&Commesse_Ky=<%=strCommesse_Ky%>&Anagrafiche_Ky=<%=GetFieldValue(dtCommesse, "Anagrafiche_Ky")%>&sorgente=scheda-commessa" class="button secondary tiny"><i class="fa-duotone fa-square-plus fa-fw"></i>Nuova spesa</a>
	    </div>    
		</div>
	  <div class="card-section">
    <table class="grid hover scroll" border="0" width="100%">
    	<thead>
	      <tr>
	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	        <th width="50">Codice</th>
        	<th width="110" class="text-center date">Data</th>
	        <th width="250" align="left">Titolo</th>
        	<th width="200" class="text-left">Fornitore</th>
        	<th width="200" class="text-left">Centro di costo</th>
	        <th width="80" class="text-center">Totale</th>
	        <th width="80" class="text-center">Imponibile</th>
	        <th width="80" class="text-center">IVA</th>
	        <th width="250">Documento</th>
	        <th width="12" class="nowrap" data-orderable="false"></th>
	      </tr>
    	</thead>
    	<tbody>
		    <%for (int i = 0; i < dtSpese.Rows.Count; i++){ %>
		        <tr class="riga<%=i%2%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtSpese.Rows[i]["Spese_Ky"].ToString()%>" data-value="<%=dtSpese.Rows[i]["Spese_Ky"].ToString()%>" /></td>
		          <td><a href="/admin/app/amministrazione/scheda-spese.aspx?CoreModules_Ky=2&CoreEntities_Ky=1&Spese_Ky=<%=dtSpese.Rows[i]["Spese_Ky"].ToString()%>"><%=dtSpese.Rows[i]["Spese_Ky"].ToString()%></a></td>
		          <td><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtSpese.Rows[i]["Spese_Data_IT"].ToString()%></td>
		          <td><a href="/admin/app/amministrazione/scheda-spese.aspx?CoreModules_Ky=2&CoreEntities_Ky=1&Spese_Ky=<%=dtSpese.Rows[i]["Spese_Ky"].ToString()%>"><i class="fa-duotone fa-file-lines fa-fw"></i><%=dtSpese.Rows[i]["Spese_Titolo"].ToString()%></a></td>
		          <td>
								<div class="width200">
		            	<a href="/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=<%=dtSpese.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="Email: <%=dtSpese.Rows[i]["Anagrafiche_EmailAmministrazione"].ToString()%> - Telefono: <%=dtSpese.Rows[i]["Anagrafiche_Telefono"].ToString()%>"><i class="fa-duotone fa-users fa-fw"></i><%=dtSpese.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
								</div> 
		          </td>
		          <td><i class="fa-duotone fa-file-lines fa-fw"></i><%=dtSpese.Rows[i]["CentridiCR_Titolo"].ToString()%></td>
		          <td class="large-text-right small-text-left" style="padding-right:5px"><strong>&euro; <%=((decimal)dtSpese.Rows[i]["Spese_Totale"]).ToString("N2", ci)%></strong></td>
		          <td class="large-text-right small-text-left" style="padding-right:5px"><strong>&euro; <%=((decimal)dtSpese.Rows[i]["Spese_TotaleRighe"]).ToString("N2", ci)%></strong></td>
		          <td class="large-text-right small-text-left" style="padding-right:5px"><strong>&euro; <%=((decimal)dtSpese.Rows[i]["Spese_TotaleIVA"]).ToString("N2", ci)%></strong></td>
		          <td class="text-left">
							doc. n&deg; <%=dtSpese.Rows[i]["Spese_DocumentoNumero"].ToString()%> del <%=dtSpese.Rows[i]["Spese_DocumentoData_IT"].ToString()%>
							</td>

		          <td><a href="/admin/app/amministrazione/crud/elimina-spese.aspx?azione=delete&sorgente=elenco-spese&Spese_Ky=<%=dtSpese.Rows[i]["Spese_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
		        </tr>
		    <% } %>
    	</tbody>
		  <% if (dtSpese.Rows.Count<1){
		      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
			} %> 
    </table>
		</div>
	</div>
	</div>
</div>	
<% } %>
