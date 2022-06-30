<% if (dtLogin.Rows[0]["UtentiGruppi_Aste"].Equals(true) && strAzione!="new"){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
	  <a name="files"></a>
		<div class="card">
		  <div class="card-divider">
			  <h2><i class="fa-duotone fa-file-pdf fa-lg fa-fw"></i>Doumenti dell'asta (<%=dtFiles.Rows.Count%>)</h2>
				<div class="button-group tiny">
					<a href="/admin/app/contenuti/scheda-files.aspx?azione=new&sorgente=scheda-aste&Aste_Ky=<%=GetFieldValue(dtAste, "Aste_Ky")%>" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>nuovo file</a>
		  	</div>
		  </div>
		  <div class="card-section">
		    <table class="grid hover scroll" border="0" width="100%">
		    	<thead>
			      <tr>
							<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
							<th width="100">File</th>
							<th width="40">Cod.</th>
		    			<th width="300">Titolo</th>
							<th width="40" class="large-text-center small-text-left">Tipo</th>
							<th width="60" class="large-text-center small-text-left">Estensione</th>
							<th width="60" class="large-text-center small-text-left">Content Type</th>
							<th width="60">Lingua</th>
			        <th width="60" class="text-center nowrap"></th>
			      </tr>
		    	</thead>
		    	<tbody>
				    <%for (int i = 0; i < dtFiles.Rows.Count; i++){ %>
				    <tr class="riga<%=i%2%>">
		              <td><input type="checkbox" class="checkrow" id="record<%=dtFiles.Rows[i]["Files_Ky"].ToString()%>" data-value="<%=dtFiles.Rows[i]["Files_Ky"].ToString()%>" /></td>
					  <td>
						<% if (dtFiles.Rows[i]["FilesTipo_Ky"].ToString()=="1"){ %>
							<a href="<%=dtFiles.Rows[i]["Files_Path"].ToString()%>" target="blank"><img src="<%=dtFiles.Rows[i]["Files_Path"].ToString()%>" width="75" height="50" /></a>
						<% }else{ %>
							<a href="<%=dtFiles.Rows[i]["Files_Path"].ToString()%>" target="blank"><i class="fa-duotone fa-up-right-from-square fa-fw"></i><%=dtFiles.Rows[i]["Files_Extension"].ToString()%></a>
						<% } %>
                
					  </td>
				      <td><a href="/admin/app/contenuti/scheda-files.aspx?azione=modifica&sorgente=scheda-aste&Aste_Ky=<%=dtFiles.Rows[i]["Chiave_Ky"].ToString()%>&Files_Ky=<%=dtFiles.Rows[i]["Files_Ky"].ToString()%>"><%=dtFiles.Rows[i]["Files_Ky"].ToString()%></a></td>
				      <td><a href="/admin/app/contenuti/scheda-files.aspx?azione=modifica&sorgente=scheda-aste&Aste_Ky=<%=dtFiles.Rows[i]["Chiave_Ky"].ToString()%>&Files_Ky=<%=dtFiles.Rows[i]["Files_Ky"].ToString()%>"><%=dtFiles.Rows[i]["Files_Titolo"].ToString()%></a></td>
	          	<td class="large-text-center small-text-left"><%=dtFiles.Rows[i]["FilesTipo_Titolo"].ToString()%></td>
						  <td class="large-text-center small-text-left"><%=dtFiles.Rows[i]["Files_Extension"].ToString()%></td>
						  <td class="large-text-center small-text-left"><%=dtFiles.Rows[i]["Files_ContentType"].ToString()%></td>
						  <td><i class="fa-duotone fa-language fa-fw"></i><%=dtFiles.Rows[i]["Lingue_Titolo"].ToString()%></td>
				      <td class="text-center nowrap"><a href="/admin/app/contenuti/crud/elimina-files.aspx?azione=delete&sorgente=scheda-aste&Files_Ky=<%=dtFiles.Rows[i]["Files_Ky"].ToString()%>&Aste_Ky=<%=GetFieldValue(dtAste, "Aste_Ky")%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></td>
				    </tr>
				    <% } %>
			    	</tbody>
					  <% if (dtFiles.Rows.Count<1){
					      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
						} %> 
		    </table>
			</div>    
		</div>
	</div>
</div>
<% } %>
