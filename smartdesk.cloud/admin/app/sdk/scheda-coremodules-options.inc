<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="coremodulesoptions"></a>
	    		<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Opzioni (<%=dtCoreModulesOptions.Rows.Count%>)</h2>
					<div class="button-group tiny">
						<a href="/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=229&CoreGrids_Ky=241&CoreForms_Ky=163&custom=0&azione=new" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i> New Option</a>
                        
			  	</div>
		  </div>
		  <div class="card-section">
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
	        <tr>
	          <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	          <th width="30" class="text-center">Id</th>
	          <th width="200" class="text-left">Code</th>
	          <th width="200" class="text-left">Title</th>
	          <th width="200" class="text-left">Description</th>
	          <th width="80" class="text-left">Type</th>
	          <th width="40" class="text-left">Ordine</th>
			  <th width="50" class="text-center nowrap" data-orderable="false"></th>
	        </tr>
	      </thead>
	   		<tbody>
        <%for (int i = 0; i < dtCoreModulesOptions.Rows.Count; i++){ %>
            <tr>
  		      <td><input type="checkbox" class="checkrow" id="record<%=dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Ky"].ToString()%>" data-value="<%=dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Ky"].ToString()%>" /></td>
              <td class="large-text-center small-text-left"><a href="/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=229&CoreGrids_Ky=241&CoreForms_Ky=163&custom=0&azione=edit&CoreModulesOptions_Ky=<%=dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Ky"].ToString()%>&sorgente=scheda-modules"><%=dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Ky"].ToString()%></a></td>
              <td class="text-left"><a href="/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=229&CoreGrids_Ky=241&CoreForms_Ky=163&custom=0&azione=edit&CoreModulesOptions_Ky=<%=dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Ky"].ToString()%>&sorgente=scheda-modules"><i class="<%=dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Icon"].ToString()%> fa-fw"></i><%=dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Code"].ToString()%></a></td>
              <td class="text-left"><%=dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Title"].ToString()%></td>
              <td class="text-left"><%=dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Description"].ToString()%></td>
              <td class="text-left"><%=dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Type"].ToString()%></td>
              <td class="text-left"><%=dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Order"].ToString()%></td>
              <td class="text-center nowrap"><a href="/admin/app/sdk/crud/elimina-coremodulesoptions.aspx?azione=delete&CoreModules_Ky=<%=dtCoreModulesOptions.Rows[i]["CoreModules_Ky"].ToString()%>&CoreModulesOptions_Ky=<%=dtCoreModulesOptions.Rows[i]["CoreModulesOptions_Ky"].ToString()%>&sorgente=scheda-coremodules" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
            </tr>
        <% } %>
	   		</tbody>
			  <% if (dtCoreModulesOptions.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
		  </div>
		</div>
  </div>
</div>
