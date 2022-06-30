<% if (dtLogin.Rows[0]["UtentiGruppi_Officina"].Equals(true) && strAzione!="new"){ %>
<div class="grid-container">
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="Officina"></a>
	    		<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Officina (<%=dtOfficina.Rows.Count%>)</h2>
					<div class="button-group tiny">
						<a href="/admin/app/officina/scheda-officina.aspx?azione=new&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i> Nuovo intervento officina</a>
			  	</div>
		  </div>
		  <div class="card-section">
      <table class="grid hover scroll" border="0" width="100%">
				<colgroup>
					<col width="30">
					<col width="80">
					<col width="350">
					<col width="80">
					<col width="110">
					<col width="40">
				</colgroup>
	    	<thead>
	        <tr>
	          <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	          <th width="30" align="left">Codice</th>
	          <th width="140" align="left">Data Accettazione</th>
						<th width="140" class="text-center date">Data Consegna</th>
						<th width="80" class="text-center">Priorit&agrave;</th>
						<th width="150" class="text-center">Tipo auto</th>
						<th width="300" class="text-center">Vettura</th>
						<th width="60" class="text-center">Targa</th>
						<th width="120" class="text-center">Stato</th>
						<th width="50" class="text-center nowrap" data-orderable="false"></th>
	        </tr>
	      </thead>
	   		<tbody>
        <%for (int i = 0; i < dtOfficina.Rows.Count; i++){ %>
            <tr>
  		        <td><input type="checkbox" class="checkrow" id="record<%=dtOfficina.Rows[i]["Officina_Ky"].ToString()%>" data-value="<%=dtOfficina.Rows[i]["Officina_Ky"].ToString()%>" /></td>
              <td class="large-text-center small-text-left"><a href="/admin/app/Officina/scheda-Officina.aspx?Officina_Ky=<%=dtOfficina.Rows[i]["Officina_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtOfficina.Rows[i]["Officina_Ky"].ToString()%></a></td>
              <td class="text-left"><%=dtOfficina.Rows[i]["Officina_DataAccettazione"].ToString()%></td>
              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><a href="/admin/app/Officina/scheda-Officina.aspx?Officina_Ky=<%=dtOfficina.Rows[i]["Officina_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtOfficina.Rows[i]["Officina_DataConsegna"].ToString()%></a></td>
              <td class="large-text-center small-text-left"><%=dtOfficina.Rows[i]["Priorita_Descrizione"].ToString()%></td>
              <td class="large-text-center small-text-left"><%=dtOfficina.Rows[i]["OfficinaTipoauto_Titolo"].ToString()%></td>
              <td class="large-text-center small-text-left"><%=dtOfficina.Rows[i]["Officina_Vettura"].ToString()%></td>
		          <td class="text-center show-for-medium-up"><%=dtOfficina.Rows[i]["Officina_TargaVettura"].ToString()%></td>
		          <td class="text-center show-for-medium-up"><%=dtOfficina.Rows[i]["OfficinaStati_Titolo"].ToString()%></td>
              <td class="text-center nowrap"><a href="/admin/app/Officina/crud/elimina-Officina.aspx?azione=delete&Anagrafiche_Ky=<%=dtOfficina.Rows[i]["Anagrafiche_Ky"].ToString()%>&Officina_Ky=<%=dtOfficina.Rows[i]["Officina_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
            </tr>
        <% } %>
	   		</tbody>
			  <% if (dtOfficina.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
		  </div>
		</div>
  </div>
</div>
</div>
<% } %>
