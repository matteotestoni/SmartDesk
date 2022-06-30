<% if (strAzione!="new"){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
  <a name="note"></a>
	<div class="card">
	  <div class="card-divider">
			<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Note sul progetto (<%=dtNote.Rows.Count%>)</h2>
			<div class="button-group tiny">
				<a href="/admin/app/note/scheda-note.aspx?azione=new&Anagrafiche_Ky=<%=GetFieldValue(dtCommesse, "Anagrafiche_Ky")%>&Commesse_Ky=<%=GetFieldValue(dtCommesse, "Commesse_Ky")%>&sorgente=scheda-commessa" class="button secondary tiny"><i class="fa-duotone fa-square-plus fa-fw"></i> nuova nota</a>
			</div>
	  </div>
	  <div class="card-section">
    <table class="grid hover scroll" border="0" width="100%">
    	<thead>
        <tr>
	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
			<th width="40" class="text-center">Codice</th>
            <th width="350" align="left">Titolo</th>
			<th width="110" class="text-center date">Data</th>
			<th width="80" class="text-center">Priorit&agrave;</th>
			<th width="110" class="text-center">Di chi</th>
			<th width="110" class="text-center">Lingua</th>
			<th width="12" class="text-center nowrap"></th>
        </tr>
      </thead>
   		<tbody>
      <%for (int i = 0; i < dtNote.Rows.Count; i++){ %>
          <tr>
            <td><input type="checkbox" class="checkrow" id="record<%=dtNote.Rows[i]["Note_Ky"].ToString()%>" data-value="<%=dtNote.Rows[i]["Note_Ky"].ToString()%>" /></td>
            <td class="text-left"><a href="/admin/app/note/scheda-note.aspx?Note_Ky=<%=dtNote.Rows[i]["Note_Ky"].ToString()%>&sorgente=scheda-commessa"><%=dtNote.Rows[i]["Note_Ky"].ToString()%></a></td>
            <td class="text-left"><a href="/admin/app/note/scheda-note.aspx?Note_Ky=<%=dtNote.Rows[i]["Note_Ky"].ToString()%>&sorgente=scheda-commessa"><%=dtNote.Rows[i]["Note_Titolo"].ToString()%></a></td>
            <td class="large-text-center small-text-left"><a href="/admin/app/note/scheda-note.aspx?Note_Ky=<%=dtNote.Rows[i]["Note_Ky"].ToString()%>&sorgente=scheda-commessa"><%=dtNote.Rows[i]["Note_Data_IT"].ToString()%></a></td>
            <td class="large-text-center small-text-left"><%=dtNote.Rows[i]["Priorita_Descrizione"].ToString()%></td>
            <td class="large-text-center small-text-left"><i class="fa-duotone fa-user fa-fw" style="color:<%=dtNote.Rows[i]["Utenti_Colore"].ToString()%>"></i><%=dtNote.Rows[i]["Utenti_Nominativo"].ToString()%></td>
            <td class="large-text-center small-text-left"><i class="fa-duotone fa-language fa-fw"></i><%=dtNote.Rows[i]["Lingue_Titolo"].ToString()%></td>
            <td class="text-center nowrap"><a href="/admin/app/note/elimina-Note.aspx?Anagrafiche_Ky=<%=dtNote.Rows[i]["Anagrafiche_Ky"].ToString()%>&Note_Ky=<%=dtNote.Rows[i]["Note_Ky"].ToString()%>&sorgente=scheda-commessa&Commesse_Ky=<%=GetFieldValue(dtCommesse, "Commesse_Ky")%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
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
<% } %>
