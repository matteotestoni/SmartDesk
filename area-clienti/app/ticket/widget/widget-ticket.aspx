<%
	System.Data.DataTable dtTicket;
  strWHERENet="(Anagrafiche_Ky=" + strAnagrafiche_Ky + ")";
	strFROMNet = "Ticket_Vw";
	strORDERNet = "Ticket_Data DESC";
	dtTicket = new System.Data.DataTable("Ticket");
	dtTicket = Smartdesk.Sql.getTablePage(strFROMNet, null, "Ticket_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
 %>            
<div class="card" id="sectionTicket">
	<div class="card-divider">
    <h2>
        Le tue richieste di assistenza
        &nbsp;&nbsp;<a href="/area-clienti/app/ticket/scheda-ticket.aspx?azione=new" class="small button"><i class="fa-duotone fa-square-plus fa-fw"></i>Nuova Richiesta</a>
    </h2>
  </div>		  
	<div class="card-section">
			<% if (dtTicket.Rows.Count>0){ %>
			<table id="rswgrid" class="grid stack hover" border="0">
      	<thead>
  	      <tr>
  	        <th width="30">Codice</th>
	        	<th width="150">Stato</th>
  	        <th width="300">Titolo</th>
  	        <th width="300">Richiesta</th>
  	        <th width="80" class="text-center">Messaggi</th>
  	        <th width="80">Matricola</th>
  	        <th width="160">Data</th>
            <th width="60"></th>
  	      </tr>
      	</thead>
      	<tbody>
  		    <% for (int i = 0; i < dtTicket.Rows.Count; i++){ 
						strWHERENet="(Ticket_Ky=" + dtTicket.Rows[i]["Ticket_Ky"].ToString() + ")";
						strFROMNet = "Attivita_Vw";
						strORDERNet = "Attivita_Inizio DESC";
						System.Data.DataTable dtAttivita = new System.Data.DataTable("Attivita");
						dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
						%>


							<tr class="riga<%=i%2%>">
  		          <td><%=dtTicket.Rows[i]["Ticket_Ky"].ToString()%></td>
				  			<td class="text-left"><i class="<%=dtTicket.Rows[i]["TicketStati_Icona"].ToString()%> fa-fw" style="color:<%=dtTicket.Rows[i]["TicketStati_Colore"].ToString()%>"></i></i><%=dtTicket.Rows[i]["TicketStati_Titolo"].ToString()%></div></td>
  		          <td><%=dtTicket.Rows[i]["Ticket_Titolo"].ToString()%></td>
  		          <td><%=dtTicket.Rows[i]["Ticket_Richiesta"].ToString()%></td>
  		          <td class="text-center"><span class="badge"><%=dtAttivita.Rows.Count%></span></td>
								<td class="text-left"><%=dtTicket.Rows[i]["AnagraficheProdotti_Matricola"].ToString()%></td>
  		          <td class="text-left"><%=dtTicket.Rows[i]["Ticket_Data"].ToString()%></td>
                  <td class="text-left">
                    <% if (dtTicket.Rows[i]["TicketStati_Ky"].ToString()=="1"){ %>
                        <a href="/area-clienti/app/ticket/scheda-ticket.aspx?Ticket_Ky=<%=dtTicket.Rows[i]["Ticket_Ky"].ToString()%>"><i class="fa-duotone fa-edit fa-fw"></i>Modifica</a>
                    <% }else { %>
											<a href="/area-clienti/app/ticket/scheda-ticket.aspx?Ticket_Ky=<%=dtTicket.Rows[i]["Ticket_Ky"].ToString()%>"><i class="fa-duotone fa-eye fa-fw"></i>Visualizza</a>
										<% } %>
                  </td>
  		        </tr>
  		    <% } %>
      	</tbody>
      </table>
			<% }else{ %>
				<p><i class="fa-duotone fa-info-circle fa-fw"></i>Non hai nessuna richiesta di assistenza attiva</p>
			<% } %>
  </div>		  
</div>
