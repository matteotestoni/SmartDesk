<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="CoreEntities"></a>
	    		<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Buttons del grid (<%=dtCoreGridsButtons.Rows.Count%>)</h2>
					<div class="button-group tiny">
						<a href="/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=218&CoreForms_Ky=142&CoreGrids_Ky=<%=GetFieldValue(dtCoreGrids, "CoreGrids_Ky")%>&sorgente=scheda-coregrids&azione=new" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>Aggiungi button</a>
			  	</div>
		  </div>
		  <div class="card-section">
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
	        <tr>
	          <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	          <th width="30" class="text-center">Code</th>
	          <th width="200" class="text-left">Titolo</th>
	          <th width="40" class="text-left">Icona</th>
	          <th width="30" class="text-left">Ordine</th>
						<th width="50" class="text-center nowrap" data-orderable="false"></th>
	        </tr>
	      </thead>
	   		<tbody>
        <%for (int i = 0; i < dtCoreGridsButtons.Rows.Count; i++){ %>
            <tr>
  		        <td><input type="checkbox" class="checkrow" id="record<%=dtCoreGridsButtons.Rows[i]["CoreGridsButtons_Ky"].ToString()%>" data-value="<%=dtCoreGridsButtons.Rows[i]["CoreGridsButtons_Ky"].ToString()%>" /></td>
              <td class="large-text-center small-text-left"><a href="/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=207&CoreGrids_Ky=215&CoreGrids_Ky=120&CoreGridsButtons_Ky=<%=dtCoreGridsButtons.Rows[i]["CoreGridsButtons_Ky"].ToString()%>&sorgente=scheda-coregrids"><%=dtCoreGridsButtons.Rows[i]["CoreGridsButtons_Ky"].ToString()%></a></td>
              <td><a href="/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=218&CoreForms_Ky=142&CoreGridsButtons_Ky=<%=dtCoreGridsButtons.Rows[i]["CoreGridsButtons_Ky"].ToString()%>&sorgente=scheda-coregrids"><%=dtCoreGridsButtons.Rows[i]["CoreGridsButtons_Title"].ToString()%></a></td>
              <td><i class="<%=dtCoreGridsButtons.Rows[i]["CoreGridsButtons_Icon"].ToString()%> fa-fw"></i></td>
              <td><%=dtCoreGridsButtons.Rows[i]["CoreGridsButtons_Order"].ToString()%></td>
              <td class="text-center nowrap"><a href="/admin/app/sdk/crud/elimina-CoreGridsButtons.aspx?azione=delete&CoreModules_Ky=26&CoreEntities_Ky=194&CoreGridsButtons_Ky=<%=dtCoreGridsButtons.Rows[i]["CoreGridsButtons_Ky"].ToString()%>&CoreGrids_Ky=93&sorgente=scheda-coregrids" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
            </tr>
        <% } %>
	   		</tbody>
			  <% if (dtCoreGridsButtons.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
		  </div>
		</div>
  </div>
</div>
