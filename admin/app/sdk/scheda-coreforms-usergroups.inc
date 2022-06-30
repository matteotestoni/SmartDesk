<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="UsergroupsForms" id="UsergroupsForms"></a>
	    		<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Groups can use this form(<%=dtUsergroupsForms.Rows.Count%>)</h2>
					<div class="button-group tiny">
			  	</div>
		  </div>
		  <div class="card-section">
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
	        <tr>
	          <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	          <th width="30" class="text-center">Code</th>
	          <th width="200" class="text-left">User Group</th>
			     <th width="50" class="text-center nowrap" data-orderable="false"></th>
	        </tr>
	      </thead>
	   		<tbody>
        <%for (int i = 0; i < dtUsergroupsForms.Rows.Count; i++){ %>
            <tr>
	           <td><input type="checkbox" class="checkrow" id="record<%=dtUsergroupsForms.Rows[i]["UsergroupsForms_Ky"].ToString()%>" data-value="<%=dtUsergroupsForms.Rows[i]["UsergroupsForms_Ky"].ToString()%>" /></td>
              <td class="large-text-center small-text-left"><a href="/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=207&CoreForms_Ky=215&CoreForms_Ky=120&UsergroupsForms_Ky=<%=dtUsergroupsForms.Rows[i]["UsergroupsForms_Ky"].ToString()%>&sorgente=scheda-coreforms"><%=dtUsergroupsForms.Rows[i]["UsergroupsForms_Ky"].ToString()%></a></td>
              <td><%=dtUsergroupsForms.Rows[i]["UtentiGruppi_Descrizione"].ToString()%></td>
              <td class="text-center nowrap"><a href="/admin/app/sdk/crud/elimina-UsergroupsForms.aspx?azione=delete&CoreModules_Ky=26&CoreEntities_Ky=194&UsergroupsForms_Ky=<%=dtUsergroupsForms.Rows[i]["UsergroupsForms_Ky"].ToString()%>&CoreForms_Ky=<%=strCoreForms_Ky%>&sorgente=scheda-coreforms" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
            </tr>
        <% } %>
	   		</tbody>
			  <% if (dtUsergroupsForms.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
      <% if (strAzione!="new"){ %>
      <fieldset class="fieldset">
        <legend><i class="fa-duotone fa-square-plus fa-fw"></i>Add user group</legend>
        <form id="form-CoreFormsFieldset" action="/admin/app/sdk/crud/salva-UsergroupsForms.aspx" enctype="multipart/form-data" method="post" data-abide novalidate>
          <input type="hidden" name="azione" id="azione" value="new">
          <input type="hidden" name="sorgente" id="sorgente" value="scheda-coreforms">
          <input type="hidden" name="UsergroupsForms_Ky" id="UsergroupsForms_Ky" value="">
          <input type="hidden" name="CoreForms_Ky" id="CoreForms_Ky" value="<%=strCoreForms_Ky%>">
          <div class="grid-x grid-padding-x">
            <div class="small-12 medium-9 large-9 cell">
              <select name="UtentiGruppi_Ky" id="UtentiGruppi_Ky" value="" placeholder="Tab">
                <option></option>
                <%for (int i = 0; i < dtUtentiGruppi.Rows.Count; i++){ %>
                  <option value="<%=dtUtentiGruppi.Rows[i]["UtentiGruppi_Ky"].ToString()%>"><%=dtUtentiGruppi.Rows[i]["UtentiGruppi_Descrizione"].ToString()%></option>
                <% } %>
              </select>
            </div>
            <div class="small-12 medium-3 large-3 cell">
              <button type="submit" value="salva" name="salva" class="button success"><i role="img" class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
            </div>
         </form>
      </fieldset>
      <% } %>
      
		  </div>
		</div>
  </div>
</div>
