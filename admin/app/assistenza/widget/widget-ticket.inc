 <%
	System.Data.DataTable dtTicket;

	string strWHERENet="";
	strWHERENet="TicketStati_Ky=1";
	string strFROMNet = "Ticket_Vw";
	string strORDERNet = "Ticket_Ky DESC";
	dtTicket = new System.Data.DataTable("Ticket");
	dtTicket = Smartdesk.Sql.getTablePage(strFROMNet, null, "Ticket_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
%>
		<div class="divgridcard">
		<table class="grid hover scroll" border="0" width="100%">
			<thead>
				<tr>
      	<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
				<th width="110" class="text-center date">Data</th>
				<th align="left" width="250">Titolo</th>
				<th align="left" width="250">Anagrafica</th>
				<th width="12" class="nowrap" data-orderable="false"></th>
				</tr>
			</thead>
    		<tbody>
        <%
			  for (int j = 0; j < dtTicket.Rows.Count; j++){
			  %>

		        <tr class="riga<%=i%2%>" id="<%=dtTicket.Rows[j]["Ticket_Ky"].ToString()%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtTicket.Rows[j]["Ticket_Ky"].ToString()%>" data-value="<%=dtTicket.Rows[j]["Ticket_Ky"].ToString()%>" /></td>
		          <td><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtTicket.Rows[j]["Ticket_Data"].ToString()%></td>
		          <td class="text-left"><div class="width300"><a href="/admin/form.aspx?CoreModules_Ky=32&CoreEntities_Ky=221&CoreGrids_Ky=231&CoreForms_Ky=147&Ticket_Ky=<%=dtTicket.Rows[i]["Ticket_Ky"].ToString()%>"><%=dtTicket.Rows[j]["Ticket_Titolo"].ToString()%></a></div></td>
		          <td class="text-left"><div class="width300"><%=dtTicket.Rows[j]["Anagrafiche_RagioneSociale"].ToString()%></div></td>
      				<td>
      					<a href="/admin/app/persone/crud/elimina-Ticket.aspx?azione=delete&Ticket_Ky=<%=dtTicket.Rows[j]["Ticket_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtTicket.Rows[j]["Anagrafiche_Ky"].ToString()%>&sorgente=elenco-Ticket" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
      				</td>
		        </tr>
		    <%
				}
				%>
    </table>

	</div>
