<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Ticket"].Equals(true)){ %>
<div class="grid-container" id="divticket" data-magellan-target="divticket">
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
	  <a name="ticket"></a>
		<div class="card">
		  <div class="card-divider">
    		<a name="SitiWeb"></a>
	    		<h2><i class="fa-duotone fa-inbox fa-lg fa-fw"></i>Ticket (<% if (dtTicket!=null){ Response.Write(dtTicket.Rows.Count); } %>)</h2>
					<div class="button-group tiny">
						<a href="/admin/form.aspx?CoreModules_Ky=32&CoreEntities_Ky=221&CoreGrids_Ky=231&CoreForms_Ky=147&azione=new&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>Nuovo ticket</a>
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
			        <th width="12" class="nowrap" data-orderable="false"></th>
			      </tr>
		    	</thead>
		    	<tbody>
				    <%for (int i = 0; i < dtTicket.Rows.Count; i++){ %>
				        <tr class="riga<%=i%2%>">
		          		<td><input type="checkbox" class="checkrow" id="record<%=dtTicket.Rows[i]["Ticket_Ky"].ToString()%>" data-value="<%=dtTicket.Rows[i]["Ticket_Ky"].ToString()%>" /></td>
				          <td><a href="/admin/form.aspx?CoreModules_Ky=32&CoreEntities_Ky=221&CoreGrids_Ky=231&CoreForms_Ky=147&Ticket_Ky=<%=dtTicket.Rows[i]["Ticket_Ky"].ToString()%>"><%=dtTicket.Rows[i]["Ticket_Ky"].ToString()%></a></td>
				          <td><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtTicket.Rows[i]["Ticket_Data"].ToString()%></td>
				          <td><a href="/admin/form.aspx?CoreModules_Ky=32&CoreEntities_Ky=221&CoreGrids_Ky=231&CoreForms_Ky=147&Ticket_Ky=<%=dtTicket.Rows[i]["Ticket_Ky"].ToString()%>"><i class="fa-duotone fa-file-lines fa-fw"></i><small><%=dtTicket.Rows[i]["Ticket_Titolo"].ToString()%></small></a></td>
									</td>
				          <td><a href="/admin/app/assistenza/crud/elimina-ticket.aspx?azione=delete&sorgente=elenco-ticket&Ticket_Ky=<%=dtTicket.Rows[i]["Ticket_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
				        </tr>
				    <% } %>
		    	</tbody>
				  <% if (dtTicket.Rows.Count<1){
				      	Response.Write("<tfoot><tr><td colspan=\"11\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
					} %> 
		    </table>
				</div>
			</div>	
	</div>
</div>	
</div>
<% } %>
