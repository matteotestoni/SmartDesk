<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="CoreEntities"></a>
	    		<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Relations(<%=dtCoreFormsRelations.Rows.Count%>)</h2>
		  </div>
		  <div class="card-section">
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
	        <tr>
	          <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	          <th width="30" class="text-center">Code</th>
	          <th width="200" class="text-left">Grid</th>
	          <th width="30" class="text-left">Order</th>
			     <th width="50" class="text-center nowrap" data-orderable="false"></th>
	        </tr>
	      </thead>
	   		<tbody>
        <%for (int i = 0; i < dtCoreFormsRelations.Rows.Count; i++){ %>
            <tr>
	           <td><input type="checkbox" class="checkrow" id="record<%=dtCoreFormsRelations.Rows[i]["CoreFormsRelations_Ky"].ToString()%>" data-value="<%=dtCoreFormsRelations.Rows[i]["CoreFormsRelations_Ky"].ToString()%>" /></td>
              <td class="large-text-center small-text-left"><a href="/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=207&CoreGrids_Ky=215&CoreForms_Ky=120&CoreFormsRelations_Ky=<%=dtCoreFormsRelations.Rows[i]["CoreFormsRelations_Ky"].ToString()%>&sorgente=scheda-coreforms"><%=dtCoreFormsRelations.Rows[i]["CoreFormsRelations_Ky"].ToString()%></a></td>
              <td><%=dtCoreFormsRelations.Rows[i]["CoreGrids_Ky"].ToString()%> - <%=dtCoreFormsRelations.Rows[i]["CoreGrids_Title"].ToString()%></td>
              <td><%=dtCoreFormsRelations.Rows[i]["CoreFormsRelations_Order"].ToString()%></td>
              <td class="text-center nowrap"><a href="/admin/app/sdk/crud/elimina-coreformsrelations.aspx?azione=delete&CoreModules_Ky=26&CoreEntities_Ky=194&CoreFormsRelations_Ky=<%=dtCoreFormsRelations.Rows[i]["CoreFormsRelations_Ky"].ToString()%>&CoreForms_Ky=93&sorgente=scheda-coreforms" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
            </tr>
        <% } %>
	   		</tbody>
			  <% if (dtCoreFormsRelations.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
      <% if (strAzione!="new"){ %>
      <fieldset class="fieldset">
        <legend><i class="fa-duotone fa-square-plus fa-fw"></i>New relation</legend>
        <form id="form-CoreFormsRelations" action="/admin/app/sdk/crud/salva-coreformsrelations.aspx" enctype="multipart/form-data" method="post" data-abide novalidate>
          <input type="hidden" name="azione" id="azione" value="new">
          <input type="hidden" name="sorgente" id="sorgente" value="scheda-coreforms">
          <input type="hidden" name="CoreFormsRelations_Ky" id="CoreFormsRelations_Ky" value="">
          <input type="hidden" name="CoreForms_Ky" id="CoreForms_Ky" value="<%=strCoreForms_Ky%>">
          <div class="grid-x grid-padding-x">
            <div class="small-12 medium-3 large-3 cell">
              <select name="CoreGrids_Ky" id="CoreGrids_Ky" value="" placeholder="Tab">
                <option></option>
                <%for (int i = 0; i < dtCoreGrids.Rows.Count; i++){ %>
                  <option value="<%=dtCoreGrids.Rows[i]["CoreGrids_Ky"].ToString()%>"><%=dtCoreGrids.Rows[i]["CoreEntities_Code"].ToString()%> > <%=dtCoreGrids.Rows[i]["CoreGrids_Title"].ToString()%></option>
                <% } %>
              </select>
            </div>
            <div class="small-12 medium-3 large-3 cell">
              <input type="text" name="CoreFormsRelations_Title" id="CoreFormsRelations_Title" value="" placeholder="Title">
            </div>
             <div class="small-12 medium-3 large-3 cell">
             <input type="number" name="CoreFormsRelations_Order" id="CoreFormsRelations_Order" value="" placeholder="Order">
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
