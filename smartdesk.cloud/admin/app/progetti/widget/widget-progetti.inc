 <%
	System.Data.DataTable dtCommesse;
  string strWHERENet="";
	strWHERENet="(CommesseStato_Ky=4 AND Commesse_Importante=1)";
	string strFROMNet = "Commesse_Vw";
	string strORDERNet = "Commesse_Data DESC";
	dtCommesse = new System.Data.DataTable("Commesse");
	dtCommesse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
  %>
    <div class="divgrid">
			<table class="grid hover scroll" border="0" width="100%">
    	<thead>
	      <tr>
	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	        <th width="100">Codice</th>
	        <th width="220">Date</th>
	        <th width="300">Progetto</th>
	        <th width="120">Attivit&agrave;</th>
	        <th width="250">Stato</th>
	        <th width="120">Ore</th>
	      	<% if (boolAdmin && dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(true)){ %>
	        <th width="100" class="text-right">Valore</th>
	        <% } %>
	        <th width="60" class="nowrap" data-orderable="false"></th>
	      </tr>
    	</thead>
    	<tbody>
		    <%
					for (int j = 0; j < dtCommesse.Rows.Count; j++){ %>
		        <tr class="riga<%=i%2%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtCommesse.Rows[j]["Commesse_Ky"].ToString()%>" data-value="<%=dtCommesse.Rows[j]["Commesse_Ky"].ToString()%>" /></td>
		          <td class="show-for-medium-up text-center nowrap">
								<div class="width100"><%=dtCommesse.Rows[j]["Commesse_Riferimenti"].ToString()%></div>
							</td>
		          <td>
								<div style="float:left;width:70px;text-align:right">Inserita:</div><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtCommesse.Rows[j]["Commesse_Data_IT"].ToString()%><br>
								<% if (dtCommesse.Rows[j]["Commesse_DataConsegna_IT"].ToString().Length>0){ %>
                <div style="float:left;width:70px;text-align:right">Consegna:</div><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtCommesse.Rows[j]["Commesse_DataConsegna_IT"].ToString()%>
                <% } %>
							</td>
		          <td>
								<div class="width300">
									<a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtCommesse.Rows[j]["Commesse_Ky"].ToString()%>"><i class="fa-duotone fa-building fa-fw"></i><strong><%=dtCommesse.Rows[j]["Commesse_Titolo"].ToString()%></strong></a><br>
								</div>
	            	<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtCommesse.Rows[j]["Anagrafiche_Ky"].ToString()%>" title="Telefono: <%=dtCommesse.Rows[j]["Anagrafiche_Telefono"].ToString()%>"><i class="fa-duotone fa-user fa-fw"></i><%=dtCommesse.Rows[j]["Anagrafiche_RagioneSociale"].ToString()%></a>
							</td>
		          <td>
								<a href="/admin/app/progetti/scheda-progetti.aspx?Commesse_Ky=<%=dtCommesse.Rows[j]["Commesse_Ky"].ToString()%>"><i class="fa-duotone fa-gears fa-fw"></i>Attivit&agrave;</a><br>
							</td>
							<td>
									<div class="width250">
                      <i class="fa-duotone fa-user fa-fw"></i> <%=dtCommesse.Rows[j]["Utenti_Iniziali"].ToString()%>
									</div> 
									<div style="margin-top:5px" class="progress success" role="progressbar" tabindex="0" aria-valuenow="<%=dtCommesse.Rows[j]["Commesse_Avanzamento"].ToString()%>" aria-valuemin="0" aria-valuetext="<%=dtCommesse.Rows[j]["Commesse_Avanzamento"].ToString()%>%" aria-valuemax="100">
									  <span class="progress-meter" style="width:<%=dtCommesse.Rows[j]["Commesse_Avanzamento"].ToString()%>%">
									    <p class="progress-meter-text"><%=dtCommesse.Rows[j]["Commesse_Avanzamento"].ToString()%>%</p>
									  </span>
									</div>
							</td>
							<td class="large-text-right small-text-left">
								previste: <i class="fa-duotone fa-clock fa-fw"></i> <%=dtCommesse.Rows[j]["Commesse_OrePreviste"].ToString()%><br>
								ore impiegate: <i class="fa-duotone fa-clock fa-fw"></i> <%=dtCommesse.Rows[j]["Commesse_OreImpiegate"].ToString()%>
							</td>
			      	<% if (boolAdmin && dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(true)){ %>
		          <td class="large-text-right small-text-left" style="padding-right:4px">&euro; <%=dtCommesse.Rows[j]["Commesse_Valore_IT"].ToString()%></td>
	        		<% } %>
		          <td class="show-for-medium-up text-center nowrap">
                <a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtCommesse.Rows[j]["Commesse_Ky"].ToString()%>" title="modifica" class="edit"><i class="fa-duotone fa-pen-to-square fa-fw"></i></a>
                <a href="/admin/app/progetti/crud/elimina-commesse.aspx?azione=delete&Commesse_Ky=<%=dtCommesse.Rows[j]["Commesse_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
              </td>
		        </tr>
					<% } %>
    	</tbody>
    </table>
	</div>
