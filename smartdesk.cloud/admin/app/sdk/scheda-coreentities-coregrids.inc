<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="CoreEntities"></a>
	    		<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Grids (<%=dtCoreGrids.Rows.Count%>)</h2>
					<div class="button-group tiny">
						<a href="/admin/app/sdk/scheda-coregrids.aspx?azione=new&CoreModules_Ky=<%=Smartdesk.Data.Field(dtCoreEntities, "CoreModules_Ky")%>&CoreEntities_Ky=<%=Smartdesk.Data.Field(dtCoreEntities, "CoreEntities_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button"><i class="fa-duotone fa-square-plus fa-fw"></i> New grid</a>
			  	</div>
		  </div>
		  <div class="card-section">
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
	        <tr>
	          <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	          <th width="30" align="left">id</th>
	          <th width="120" align="left">Code</th>
	          <th width="120" align="left">Title</th>
	          <th width="120" align="left">SQL From</th>
	          <th width="50" class="large-text-center small-text-left">Custom</th>
	          <th width="50" class="large-text-center small-text-left">Default</th>
	          <th width="50" align="left">Order</th>
						<th width="120" class="text-center nowrap" data-orderable="false"></th>
	        </tr>
	      </thead>
	   		<tbody>
        <%for (int i = 0; i < dtCoreGrids.Rows.Count; i++){ %>
            <tr>
  		        <td><input type="checkbox" class="checkrow" id="record<%=dtCoreGrids.Rows[i]["CoreGrids_Ky"].ToString()%>" data-value="<%=dtCoreGrids.Rows[i]["CoreGrids_Ky"].ToString()%>" /></td>
              <td class="text-left"><a href="/admin/app/sdk/scheda-coregrids.aspx?CoreGrids_Ky=<%=dtCoreGrids.Rows[i]["CoreGrids_Ky"].ToString()%>&CoreModules_Ky=<%=dtCoreGrids.Rows[i]["CoreModules_Ky"].ToString()%>&sorgente=scheda-entities"><%=dtCoreGrids.Rows[i]["CoreGrids_Ky"].ToString()%></a></td>
              <td class="text-left"><a href="/admin/app/sdk/scheda-coregrids.aspx?CoreGrids_Ky=<%=dtCoreGrids.Rows[i]["CoreGrids_Ky"].ToString()%>&CoreModules_Ky=<%=dtCoreGrids.Rows[i]["CoreModules_Ky"].ToString()%>&sorgente=scheda-entities"><%=dtCoreGrids.Rows[i]["CoreGrids_Code"].ToString()%></a></td>
              <td class="text-left"><a href="/admin/app/sdk/scheda-coregrids.aspx?CoreGrids_Ky=<%=dtCoreGrids.Rows[i]["CoreGrids_Ky"].ToString()%>&CoreModules_Ky=<%=dtCoreGrids.Rows[i]["CoreModules_Ky"].ToString()%>&sorgente=scheda-entities"><%=dtCoreGrids.Rows[i]["CoreGrids_Title"].ToString()%></a></td>
              <td class="text-left"><%=dtCoreGrids.Rows[i]["CoreGrids_SQLFrom"].ToString()%></td>
		          <td class="large-text-center small-text-left">
								<% if (dtCoreGrids.Rows[i]["CoreGrids_Custom"].Equals(true)){ %>
									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
								<% }else{ %>
									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
								<% } %>
							</td>
		          <td class="large-text-center small-text-left">
								<% if (dtCoreGrids.Rows[i]["CoreGrids_Default"].Equals(true)){ %>
									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
								<% }else{ %>
									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
								<% } %>
							</td>
              <td class="text-left"><%=dtCoreGrids.Rows[i]["CoreGrids_Order"].ToString()%></td>
              <td class="text-center nowrap">
              	<a href="/admin/view.aspx?CoreModules_Ky=<%=dtCoreGrids.Rows[i]["CoreModules_Ky"].ToString()%>&CoreEntities_Ky=<%=dtCoreGrids.Rows[i]["CoreEntities_Ky"].ToString()%>&CoreGrids_Ky=<%=dtCoreGrids.Rows[i]["CoreGrids_Ky"].ToString()%>" target="_blank"><i class="fa-duotone fa-eye fa-fw"></i>Preview</a> 
                <a href="/admin/app/sdk/crud/elimina-coregrids.aspx?azione=delete&CoreGrids_Ky=<%=dtCoreGrids.Rows[i]["CoreGrids_Ky"].ToString()%>&CoreEntities_Ky=<%=dtCoreGrids.Rows[i]["CoreEntities_Ky"].ToString()%>&sorgente=scheda-entities" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i>Delete</a>
              </td>
            </tr>
        <% } %>
	   		</tbody>
			  <% if (dtCoreGrids.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
		  </div>
		</div>
  </div>
</div>
