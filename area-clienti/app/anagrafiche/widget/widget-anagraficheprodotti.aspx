<%
	System.Data.DataTable dtAnagraficheProdotti;
    strWHERENet="(Anagrafiche_Ky=" + strAnagrafiche_Ky + ")";
	strFROMNet = "AnagraficheProdotti_Vw";
	strORDERNet = "AnagraficheProdotti_DataAcquisto DESC";
	dtAnagraficheProdotti = new System.Data.DataTable("AnagraficheProdotti");
	dtAnagraficheProdotti = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheProdotti_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
 %>            
<% if (dtAnagraficheProdotti.Rows.Count>0){ %>
<div class="card" id="sectionanagraficheprodotti">
	<div class="card-divider">
    <h2>I tuoi prodotti
        &nbsp;&nbsp;<a href="/area-clienti/app/anagrafiche/scheda-anagraficheprodotti.aspx?azione=new" class="small button"><i class="fa-duotone fa-square-plus fa-fw"></i>Registra prodotto</a>
    </h2>
  </div>		  
	<div class="card-section">
      <table id="rswgrid" class="grid stack hover" border="0" style="width: 100%;">
      	<thead>
  	      <tr>
  	        <th width="30">Codice</th>
  	        <th width="300">Titolo</th>
  	        <th width="300">Descrizione</th>
  	        <th width="100">Matricola</th>
  	        <th width="100">Data Acquisto</th>
  	        <th width="150">Rivenditore</th>
            <th width="60"></th>
  	      </tr>
      	</thead>
      	<tbody>
  		    <% for (int i = 0; i < dtAnagraficheProdotti.Rows.Count; i++){ %>
  		        <tr class="riga<%=i%2%>">
  		          <td><%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_Ky"].ToString()%></td>
  		          <td><div class="Titologrid"><%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_Titolo"].ToString()%></div></td>
  		          <td><div class="Titologrid"><%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_Descrizione"].ToString()%></div></td>
  				  		<td class="text-left"><%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_Matricola"].ToString()%></td>
  		          <td class="text-left"><%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_DataAcquisto"].ToString()%></td>
  		          <td class="text-left"><%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_Rivenditore"].ToString()%></td>
								<td class="text-left"><a href="/area-clienti/app/anagrafiche/scheda-anagraficheprodotti.aspx?AnagraficheProdotti_Ky=<%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_Ky"].ToString()%>"><i class="fa-duotone fa-edit fa-fw"></i>Modifica</a></td>
						</tr>
  		    <% } %>
      	</tbody>
      </table>
  </div>		  
</div>
<% }else{ %>
	<div class="card" id="sectionanagraficheprodotti">
		<div class="card-divider">
			<h2>I tuoi prodotti
					&nbsp;&nbsp;<a href="/area-clienti/app/anagrafiche/scheda-anagraficheprodotti.aspx?azione=new" class="small button"><i class="fa-duotone fa-square-plus fa-fw"></i>Registra prodotto</a>
			</h2>
		</div>		  
		<div class="card-section">
			<p><i class="fa-duotone fa-info-circle fa-fw"></i>Non hai nessun prodotto registrato. Con la registrazione potrai:
					<ul>
							<li>Attivare la tua garanzia</li>
							<li>Richiedere assistenza tramite ticket</li>
					</ul>	
			</p>
		</div>		  
	</div>
		

<% } %>

