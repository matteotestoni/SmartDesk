<% if (dtLogin.Rows[0]["UtentiGruppi_AnagraficheContatti"].Equals(true) && strAzione!="new"){ %>
<div class="grid-container">
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
    <a name="contatti"></a>
		<div class="card">
		  <div class="card-divider">
					<h2><i class="fa-duotone fa-users fa-lg fa-fw"></i>Contatti (<%=dtAnagraficheContatti.Rows.Count%>)</h2>
					<div class="button-group tiny">
						<a href="/admin/app/anagrafiche/scheda-anagrafichecontatti.aspx?azione=new&sorgente=scheda-anagrafiche&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>nuovo contatto</a>
			  	</div>
		  </div>
		  <div class="card-section">
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
        <tr>
	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	        <th width="30" align="left">Codice</th>
          <th align="left" width="250">Email</th>
          <th align="left" width="100">Telefono</th>
          <th align="left" width="150">Dominio</th>
					<th width="180" class="text-left">Password</th>
					<th width="40" class="text-center">PEC</th>
					<th width="40" class="text-center">Escludi</th>
					<th class="text-center" width="150">Alias</th>
					<th class="text-center" width="150">Inoltro</th>
					<th class="text-center" width="150">Tipo</th>
					<th width="12" class="nowrap" data-orderable="false"></th>
        </tr>
	    	</thead>
	    	<tbody>
        <%for (int i = 0; i < dtAnagraficheContatti.Rows.Count; i++){ %>
          <tr>
  		      <td><input type="checkbox" class="checkrow" id="record<%=dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Ky"].ToString()%>" data-value="<%=dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Ky"].ToString()%>" /></td>
            <td align="left" width="30"><a href="/admin/app/anagrafiche/scheda-anagrafichecontatti.aspx?AnagraficheContatti_Ky=<%=dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAnagraficheContatti.Rows[i]["Anagrafiche_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Ky"].ToString()%></a></td>
            <td align="left" width="300"><a href="/admin/app/anagrafiche/scheda-anagrafichecontatti.aspx?AnagraficheContatti_Ky=<%=dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAnagraficheContatti.Rows[i]["Anagrafiche_Ky"].ToString()%>&sorgente=scheda-anagrafiche">	<i class="fa-duotone fa-envelope fa-lg fa-fw"></i><%=dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Email"].ToString()%></a></td>
            <td class="text-left"><a href="tel:<%=dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Telefono"].ToString()%>"><%=dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Telefono"].ToString()%></a></td>
            <td class="text-left"><%=dtAnagraficheContatti.Rows[i]["SitiWeb_Dominio"].ToString()%></td>
      			<td class="text text-left"><i class="fa-duotone fa-file-lines fa-fw"></i><span id="contattipasswordgrid<%=i%>" class="passwordgrid" data-password="<%=dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Password"].ToString()%>">xxxxxxxxxxxxxxx</span><a><i onclick="showPasswordGrid('contattipasswordgrid<%=i%>')" class="fa-duotone fa-eye fa-fw"></i></a><a><i onclick="copyToClipboard('contattipasswordgrid<%=i%>',true)" class="fa-duotone fa-copy fa-fw"></i></a></td>
            <td class="large-text-center small-text-left">
							<% 
								if (dtAnagraficheContatti.Rows[i]["AnagraficheContatti_PEC"].Equals(true)){ %>
								<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
							<% }else{  %>
								<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
							<% } %>
						</td>
            <td class="large-text-center small-text-left">
							<% if (dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Stampa"].Equals(true)){ %>
								<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
							<% }else{  %>
								<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
							<% } %>
						</td>
            <td class="text-left"><%=dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Alias"].ToString()%></td>
            <td class="text-left"><%=dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Inoltro"].ToString()%></td>
            <td class="large-text-center small-text-left"><%=dtAnagraficheContatti.Rows[i]["AnagraficheContattiTipo_Descrizione"].ToString()%></td>
            <td width="10">
              <a href="/admin/app/anagrafiche/crud/elimina-anagrafichecontatti.aspx?azione=delete&Anagrafiche_Ky=<%=dtAnagraficheContatti.Rows[i]["Anagrafiche_Ky"].ToString()%>&AnagraficheContatti_Ky=<%=dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
            </td>
          </tr>
        <% } %>
	    	</tbody>
			  <% if (dtAnagraficheContatti.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"11\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
			</div>    
		</div>
	</div>    
</div>
</div>
<% } %>
