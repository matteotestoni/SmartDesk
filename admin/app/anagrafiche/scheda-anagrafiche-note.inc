<% if (dtLogin.Rows[0]["UtentiGruppi_Note"].Equals(true) && strAzione!="new"){ %>
<div class="grid-container">
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="Note"></a>
	    		<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Note (<%=dtNote.Rows.Count%>)</h2>
					<div class="button-group tiny">
						<a href="/admin/app/note/scheda-note.aspx?azione=new&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i> Nuova nota</a>
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
	          <th width="300" align="left">Titolo</th>
						<th width="110" class="text-center date">Data</th>
						<th width="80" class="text-center">Priorit&agrave;</th>
						<th width="110" class="text-center">Di chi</th>
						<th width="60" class="text-center">Utente</th>
						<th width="50" class="text-center nowrap" data-orderable="false"></th>
	        </tr>
	      </thead>
	   		<tbody>
        <%for (int i = 0; i < dtNote.Rows.Count; i++){ %>
            <tr>
  		        <td><input type="checkbox" class="checkrow" id="record<%=dtNote.Rows[i]["Note_Ky"].ToString()%>" data-value="<%=dtNote.Rows[i]["Note_Ky"].ToString()%>" /></td>
              <td class="large-text-center small-text-left"><a href="/admin/app/note/scheda-note.aspx?Note_Ky=<%=dtNote.Rows[i]["Note_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtNote.Rows[i]["Note_Ky"].ToString()%></a></td>
              <td class="text-left"><%=dtNote.Rows[i]["Note_Titolo"].ToString()%></td>
              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><a href="/admin/app/note/scheda-note.aspx?Note_Ky=<%=dtNote.Rows[i]["Note_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtNote.Rows[i]["Note_Data_IT"].ToString()%></a></td>
              <td class="large-text-center small-text-left"><%=dtNote.Rows[i]["Priorita_Descrizione"].ToString()%></td>
              <td class="large-text-center small-text-left"><i class="fa-duotone fa-user fa-fw" style="color:<%=dtNote.Rows[i]["Utenti_Colore"].ToString()%>"></i><%=dtNote.Rows[i]["Utenti_Nominativo"].ToString()%></td>
		          <td class="text-center show-for-medium-up"><i class="fa-duotone fa-user-secret fa-fw"></i><%=dtNote.Rows[i]["Utenti_Iniziali"].ToString()%></td>
              <td class="text-center nowrap"><a href="/admin/app/note/crud/elimina-note.aspx?azione=delete&Anagrafiche_Ky=<%=dtNote.Rows[i]["Anagrafiche_Ky"].ToString()%>&Note_Ky=<%=dtNote.Rows[i]["Note_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
            </tr>
        <% } %>
	   		</tbody>
			  <% if (dtNote.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
		  </div>
		</div>
  </div>
</div>
</div>
<% } %>
