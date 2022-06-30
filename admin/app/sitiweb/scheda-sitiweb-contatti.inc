<% if (dtLogin.Rows[0]["UtentiGruppi_AnagraficheContatti"].Equals(true) && strAzione!="new"){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
    <a name="contatti"></a>
		<div class="card">
		  <div class="card-divider">
				<h2><i class="fa-duotone fa-users fa-lg fa-fw"></i>Contatti (<%=dtAnagraficheContatti.Rows.Count%>)</h2>
				<div class="button-group tiny"> 
					<a href="/admin/app/anagrafiche/scheda-anagrafichecontatti.aspx?azione=new&sorgente=scheda-sitiweb&Anagrafiche_Ky=<%=GetFieldValue(dtSitiWeb, "Anagrafiche_Ky")%>&SitiWeb_Ky=<%=GetFieldValue(dtSitiWeb, "SitiWeb_Ky")%>" class="tiny button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>nuovo contatto</a>
					<a href="/admin/app/sitiweb/report/rpt-configurazione-email.aspx?Anagrafiche_Ky=<%=GetFieldValue(dtSitiWeb, "Anagrafiche_Ky")%>&SitiWeb_Ky=<%=GetFieldValue(dtSitiWeb, "SitiWeb_Ky")%>" target="_blank" class="tiny button secondary"><i class="fa-duotone fa-print fa-lg fa-fw"></i>stampa configurazione</a>
				</div>
			</div>        
	  	<div class="card-section">
    	<% if (dtAnagraficheContatti!=null && dtAnagraficheContatti.Rows.Count>0){ %>
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
        <tr>
	       	<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
          <th align="left" width="40">Codice</th>
          <th width="200" class="text-left">Nominativo</th>
          <th align="left" width="200">Email / Username</th>
					<th width="200" class="text-left">Password</th>
					<th width="40" class="text-center">PEC</th>
					<th width="40" class="text-center">Escludi</th>
					<th class="text-center" width="150">Alias</th>
					<th class="text-center" width="150">Inoltro</th>
					<th class="text-center" width="150">Tipo</th>
					<th width="12" class="text-center nowrap"></th>
        </tr>
	    	</thead>
	    	<tbody>
        <%for (int j = 0; j < dtAnagraficheContatti.Rows.Count; j++){ %>
            <tr>
		          <td><input type="checkbox" class="checkrow" id="record<%=dtAnagraficheContatti.Rows[j]["AnagraficheContatti_Ky"].ToString()%>" data-value="<%=dtAnagraficheContatti.Rows[j]["AnagraficheContatti_Ky"].ToString()%>" /></td>
              <td class="text-left"><%=dtAnagraficheContatti.Rows[j]["AnagraficheContatti_Ky"].ToString()%></td>
              <td class="text-left"><%=dtAnagraficheContatti.Rows[j]["AnagraficheContatti_Nome"].ToString()%> <%=dtAnagraficheContatti.Rows[j]["AnagraficheContatti_Cognome"].ToString()%></td>
              <td align="left" width="300"><a href="/admin/app/anagrafiche/scheda-anagrafichecontatti.aspx?AnagraficheContatti_Ky=<%=dtAnagraficheContatti.Rows[j]["AnagraficheContatti_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAnagraficheContatti.Rows[j]["Anagrafiche_Ky"].ToString()%>&SitiWeb_Ky=<%=GetFieldValue(dtSitiWeb, "SitiWeb_Ky")%>&sorgente=scheda-sitoweb"><%=dtAnagraficheContatti.Rows[j]["AnagraficheContatti_Email"].ToString()%></a></td>

      			  <td class="text text-left"><i class="fa-duotone fa-file-lines fa-fw"></i><span id="contattipasswordgrid<%=j%>" class="passwordgrid" data-password="<%=dtAnagraficheContatti.Rows[j]["AnagraficheContatti_Password"].ToString()%>">xxxxxxxxxxxxxxx</span><a><i onclick="showPasswordGrid('contattipasswordgrid<%=j%>')" class="fa-duotone fa-eye fa-fw"></i></a><a><i onclick="copyToClipboard('contattipasswordgrid<%=j%>',true)" class="fa-duotone fa-copy fa-fw"></i></a></td>

              <td class="large-text-center small-text-left">
								<% 
								if (dtAnagraficheContatti.Rows[j]["AnagraficheContatti_PEC"].Equals(true)){ %>
									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
								<% }else{  %>
									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
								<% } %>
							</td>
              <td class="large-text-center small-text-left">
								<% 
									if (dtAnagraficheContatti.Rows[j]["AnagraficheContatti_Stampa"].Equals(true)){ %>
									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
								<% }else{  %>
									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
								<% } %>
							</td>
              <td class="text-left"><%=dtAnagraficheContatti.Rows[j]["AnagraficheContatti_Alias"].ToString()%></td>
              <td class="text-left"><%=dtAnagraficheContatti.Rows[j]["AnagraficheContatti_Inoltro"].ToString()%></td>
              <td class="large-text-center small-text-left"><%=dtAnagraficheContatti.Rows[j]["AnagraficheContattiTipo_Descrizione"].ToString()%></td>
              <td class="text-center nowrap">
                <a href="/admin/app/anagrafiche/crud/elimina-anagrafichecontatti.aspx?azione=delete&Anagrafiche_Ky=<%=dtAnagraficheContatti.Rows[j]["Anagrafiche_Ky"].ToString()%>&AnagraficheContatti_Ky=<%=dtAnagraficheContatti.Rows[j]["AnagraficheContatti_Ky"].ToString()%>&SitiWeb_Ky=<%=GetFieldValue(dtSitiWeb, "SitiWeb_Ky")%>&sorgente=scheda-sitoweb" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
              </td>
            </tr>
        <% } %>
	    	</tbody>
      </table>
    <% }else{
      Response.Write("<span class=\"messaggio\">Nessun contatto</span>");
    } %>
    </div>
  </div>
</div>
</div>
<% } %>
