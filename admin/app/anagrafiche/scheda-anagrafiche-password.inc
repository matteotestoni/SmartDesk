<% if (dtLogin.Rows[0]["UtentiGruppi_SitiWeb"].Equals(true) && strAzione!="new"){ %>
<div class="grid-container">
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
    <a name="contatti"></a>
		<div class="card">
		  <div class="card-divider">
					<h2><i class="fa-duotone fa-key fa-lg fa-fw"></i>Password (<%=dtPasswordmanager.Rows.Count%>)</h2>
					<div class="button-group tiny">
						<a href="/admin/form.aspx?CoreModules_Ky=30&CoreEntities_Ky=166&CoreForms_Ky=74&azione=new&sorgente=scheda-anagrafiche&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>nuova password</a>
			  	</div>
		  </div>
		  <div class="card-section">
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
        <tr>
	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	        <th width="30" align="left">Codice</th>
          <th align="left" width="250">Titolo</th>
          <th align="left" width="150">Categoria</th>
          <th align="left" width="150">Dominio</th>
					<th width="100" class="text-left">username</th>
					<th width="180" class="text-left">Password</th>
					<th width="12" class="nowrap" data-orderable="false"></th>
        </tr>
	    	</thead>
	    	<tbody>
        <%for (int i = 0; i < dtPasswordmanager.Rows.Count; i++){ %>
          <tr>
  		      <td><input type="checkbox" class="checkrow" id="record<%=dtPasswordmanager.Rows[i]["Passwordmanager_Ky"].ToString()%>" data-value="<%=dtPasswordmanager.Rows[i]["Passwordmanager_Ky"].ToString()%>" /></td>
            <td align="left" width="30"><a href="/admin/form.aspx?CoreModules_Ky=30&CoreEntities_Ky=166&CoreForms_Ky=74&Passwordmanager_Ky=<%=dtPasswordmanager.Rows[i]["Passwordmanager_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtPasswordmanager.Rows[i]["Anagrafiche_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtPasswordmanager.Rows[i]["Passwordmanager_Ky"].ToString()%></a></td>
            <td align="left" width="300"><a href="/admin/form.aspx?CoreModules_Ky=30&CoreEntities_Ky=166&CoreForms_Ky=74&Passwordmanager_Ky=<%=dtPasswordmanager.Rows[i]["Passwordmanager_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtPasswordmanager.Rows[i]["Anagrafiche_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtPasswordmanager.Rows[i]["Passwordmanager_Titolo"].ToString()%></a></td>
            <td class="text-left"><i class="<%=dtPasswordmanager.Rows[i]["PasswordmanagerCategorie_Icona"].ToString()%> fa-fw"></i><%=dtPasswordmanager.Rows[i]["PasswordmanagerCategorie_Titolo"].ToString()%></td>
            <td class="text-left"><%=dtPasswordmanager.Rows[i]["SitiWeb_Dominio"].ToString()%></td>
            <td class="text-left"><%=dtPasswordmanager.Rows[i]["Passwordmanager_Username"].ToString()%></td>
      			<td class="text text-left"><i class="fa-duotone fa-file-lines fa-fw"></i><span id="passwordgrid<%=i%>" class="passwordgrid" data-password="<%=dtPasswordmanager.Rows[i]["Passwordmanager_Password"].ToString()%>">xxxxxxxxxxxxxxx</span><a><i onclick="showPasswordGrid('passwordgrid<%=i%>')" class="fa-duotone fa-eye fa-fw"></i></a><a><i onclick="copyToClipboard('passwordgrid<%=i%>',true)" class="fa-duotone fa-copy fa-fw"></i></a></td>
            <td width="10">
              <a href="/admin/app/passwordmanager/crud/elimina-passwordmanager.aspx?azione=delete&Anagrafiche_Ky=<%=dtPasswordmanager.Rows[i]["Anagrafiche_Ky"].ToString()%>&Passwordmanager_Ky=<%=dtPasswordmanager.Rows[i]["Passwordmanager_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
            </td>
          </tr>
        <% } %>
	    	</tbody>
			  <% if (dtPasswordmanager.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"11\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
			</div>    
		</div>
	</div>    
</div>
</div>
<% } %>
