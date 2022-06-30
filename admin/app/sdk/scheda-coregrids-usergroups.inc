<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="UsergroupsGrids" id="UsergroupsGrids"></a>
	    		<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Groups can use this grid (<%=dtUsergroupsGrids.Rows.Count%>)</h2>
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
        <%for (int i = 0; i < dtUsergroupsGrids.Rows.Count; i++){ %>
            <tr>
	           <td><input type="checkbox" class="checkrow" id="record<%=dtUsergroupsGrids.Rows[i]["UsergroupsGrids_Ky"].ToString()%>" data-value="<%=dtUsergroupsGrids.Rows[i]["UsergroupsGrids_Ky"].ToString()%>" /></td>
              <td class="large-text-center small-text-left"><a href="/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=207&CoreGrids_Ky=215&CoreGrids_Ky=120&UsergroupsGrids_Ky=<%=dtUsergroupsGrids.Rows[i]["UsergroupsGrids_Ky"].ToString()%>&sorgente=scheda-coregrids"><%=dtUsergroupsGrids.Rows[i]["UsergroupsGrids_Ky"].ToString()%></a></td>
              <td><%=dtUsergroupsGrids.Rows[i]["UtentiGruppi_Descrizione"].ToString()%></td>
              <td class="text-center nowrap"><a href="/admin/app/sdk/crud/elimina-UsergroupsGrids.aspx?azione=delete&CoreModules_Ky=26&CoreEntities_Ky=194&UsergroupsGrids_Ky=<%=dtUsergroupsGrids.Rows[i]["UsergroupsGrids_Ky"].ToString()%>&CoreGrids_Ky=<%=strCoreGrids_Ky%>&sorgente=scheda-coregrids" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
            </tr>
        <% } %>
	   		</tbody>
			  <% if (dtUsergroupsGrids.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
      <% if (strAzione!="new"){ %>
      <fieldset class="fieldset">
        <legend><i class="fa-duotone fa-square-plus fa-fw"></i>Add user group</legend>
        <form id="form-CoreGridsFieldset" action="/admin/app/sdk/crud/salva-UsergroupsGrids.aspx" enctype="multipart/form-data" method="post" data-abide novalidate>
          <input type="hidden" name="azione" id="azione" value="new">
          <input type="hidden" name="sorgente" id="sorgente" value="scheda-coregrids">
          <input type="hidden" name="UsergroupsGrids_Ky" id="UsergroupsGrids_Ky" value="">
          <input type="hidden" name="CoreGrids_Ky" id="CoreGrids_Ky" value="<%=strCoreGrids_Ky%>">
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
