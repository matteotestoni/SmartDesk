<% if (dtLogin.Rows[0]["UtentiGruppi_SitiWeb"].Equals(true) && strAzione!="new"){ %>
<br>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
    <a name="contatti"></a>
		<div class="card">
		  <div class="card-divider">
				<h2><i class="fa-duotone fa-key fa-lg fa-fw"></i>Password (<%=dtPasswordmanager.Rows.Count%>)</h2>
				<div class="button-group tiny"> 
					<a href="/admin/form.aspx?CoreModules_Ky=30&CoreEntities_Ky=166&CoreForms_Ky=74&azione=new&sorgente=scheda-sitiweb&SitiWeb_Ky=<%=GetFieldValue(dtSitiWeb, "SitiWeb_Ky")%>&Anagrafiche_Ky=<%=GetFieldValue(dtSitiWeb, "Anagrafiche_Ky")%>" class="tiny button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>nuova password</a>
				</div>
			</div>        
	  	<div class="card-section">
    	<% if (dtPasswordmanager!=null && dtPasswordmanager.Rows.Count>0){ %>
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
        <tr>
	       	<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
          <th width="40" class="text-left">Codice</th>
          <th width="200" class="text-left">Titolo</th>
          <th width="200" class="text-left">Username</th>
					<th width="200" class="text-left">Password</th>
					<th width="200" class="text-left">Categoria</th>
					<th width="12" class="text-center nowrap"></th>
        </tr>
	    	</thead>
	    	<tbody>
        <%for (int j = 0; j < dtPasswordmanager.Rows.Count; j++){ %>
            <tr>
		          <td><input type="checkbox" class="checkrow" id="record<%=dtPasswordmanager.Rows[j]["Passwordmanager_Ky"].ToString()%>" data-value="<%=dtPasswordmanager.Rows[j]["Passwordmanager_Ky"].ToString()%>" /></td>
              <td class="text-left"><%=dtPasswordmanager.Rows[j]["Passwordmanager_Ky"].ToString()%></td>
              <td class="text-left" width="200"><a href="/admin/form.aspx?CoreModules_Ky=30&CoreEntities_Ky=166&CoreForms_Ky=74&Passwordmanager_Ky=<%=dtPasswordmanager.Rows[j]["Passwordmanager_Ky"].ToString()%>&SitiWeb_Ky=<%=GetFieldValue(dtSitiWeb, "SitiWeb_Ky")%>&sorgente=scheda-sitoweb"><%=dtPasswordmanager.Rows[j]["Passwordmanager_Titolo"].ToString()%></a></td>
              <td class="text-left" width="150"><%=dtPasswordmanager.Rows[j]["Passwordmanager_username"].ToString()%></td>
      			  <td class="text text-left"><i class="fa-duotone fa-file-lines fa-fw"></i><span id="passwordgrid<%=j%>" class="passwordgrid" data-password="<%=dtPasswordmanager.Rows[j]["Passwordmanager_Password"].ToString()%>">xxxxxxxxxxxxxxx</span><a><i onclick="showPasswordGrid('passwordgrid<%=j%>')" class="fa-duotone fa-eye fa-fw"></i></a><a><i onclick="copyToClipboard('passwordgrid<%=j%>',true)" class="fa-duotone fa-copy fa-fw"></i></a></td>
              <td class="text-left" width="200"><i class="<%=dtPasswordmanager.Rows[j]["PasswordmanagerCategorie_Icona"].ToString()%> fa-fw fa-lg"></i><%=dtPasswordmanager.Rows[j]["PasswordmanagerCategorie_Titolo"].ToString()%></td>
              <td class="text-center nowrap">
                <a href="/admin/app/passwordmanager/crud/elimina-Passwordmanager.aspx?azione=delete&Passwordmanager_Ky=<%=dtPasswordmanager.Rows[j]["Passwordmanager_Ky"].ToString()%>&SitiWeb_Ky=<%=GetFieldValue(dtSitiWeb, "SitiWeb_Ky")%>&sorgente=scheda-sitoweb" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
              </td>
            </tr>
        <% } %>
	    	</tbody>
      </table>
    <% }else{
      Response.Write("<span class=\"messaggio\">Nessuna password</span>");
    } %>
    </div>
  </div>
</div>
</div>
<% } %>
