<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Progetti"].Equals(true)){ %>
<div class="grid-container" id="divprogetti" data-magellan-target="divprogetti">
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
	  <a name="progetti"></a>
		<div class="card">
		  <div class="card-divider">
	    		<h2><i class="fa-duotone fa-buildings fa-lg fa-fw"></i>Progetti (<% if (dtCommesse!=null){ Response.Write(dtCommesse.Rows.Count); } %>)</h2>
					<div class="button-group tiny">
						<a href="/admin/app/progetti/scheda-commesse.aspx?azione=new&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>Nuovo progetto</a>
			  	</div>
		  </div>
		  <div class="card-section">
		    <table class="grid hover scroll" border="0" width="100%">
		    	<thead>
			      <tr>
	        		<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
			        <th width="50">Id</th>
			        <th width="80">Codice</th>
			        <th width="120">Tipo</th>
			        <th width="100">Stato</th>
		        	<th width="110" class="text-center date">Data</th>
			        <th width="300" align="left">Titolo</th>
			        <th width="80" align="left">Attivit&agrave;</th>
			        <th width="80" class="text-center">Ore previste</th>
			        <th width="80" class="text-center">Ore impiegate</th>
			        <th width="80" class="text-center">Ore residue</th>
			        <th width="50" class="nowrap" data-orderable="false"></th>
			      </tr>
		    	</thead>
		    	<tbody>
				    <%for (int i = 0; i < dtCommesse.Rows.Count; i++){ %>
				        <tr class="riga<%=i%2%>">
		          		<td><input type="checkbox" class="checkrow" id="record<%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%>" data-value="<%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%>" /></td>
				          <td><a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%>"><%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%></a></td>
				          <td><%=dtCommesse.Rows[i]["Commesse_Riferimenti"].ToString()%></td>
				          <td><%=dtCommesse.Rows[i]["CommesseTipo_Titolo"].ToString()%></td>
				          <td><i class="<%=dtCommesse.Rows[i]["CommesseStato_Icona"].ToString()%> fa-fw"></i><%=dtCommesse.Rows[i]["CommesseStato_Titolo"].ToString()%></td>
				          <td><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtCommesse.Rows[i]["Commesse_Data"].ToString()%></td>
				          <td><a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%>"><i class="fa-duotone fa-file-lines fa-fw"></i><small><%=dtCommesse.Rows[i]["Commesse_Titolo"].ToString()%></small></a></td>
    		          <td><a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%>"><i class="fa-duotone fa-gears fa-fw"></i>Attivit&agrave;</a></td>
				          <td class="text-center"><%=dtCommesse.Rows[i]["Commesse_OrePreviste"].ToString()%></td>
				          <td class="text-center"><%=dtCommesse.Rows[i]["Commesse_OreImpiegate"].ToString()%></td>
				          <td class="text-center"><%=Smartdesk.Functions.GetOreResidue(dtCommesse.Rows[i]["Commesse_OreResidue"].ToString())%></td>
				          <td>
                    <a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%>" title="modifica" class="edit"><i class="fa-duotone fa-pen-to-square fa-fw"></i></a>
                    <a href="/admin/app/progetti/crud/elimina-commesse.aspx?azione=delete&sorgente=scheda-anagrafica&Commesse_Ky=<%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
                  </td>
				        </tr>
				    <% } %>
		    	</tbody>
				  <% if (dtCommesse.Rows.Count<1){
				      	Response.Write("<tfoot><tr><td colspan=\"11\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
					} %> 
		    </table>
				</div>
			</div>	
	</div>
</div>	
</div>
<% } %>
