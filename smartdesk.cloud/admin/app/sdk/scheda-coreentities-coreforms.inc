<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="CoreEntities"></a>
	    		<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Forms (<%=dtCoreForms.Rows.Count%>)</h2>
					<div class="button-group tiny">
						<a href="/admin/app/sdk/genera-form.aspx?CoreModules_Ky=<%=Smartdesk.Data.Field(dtCoreEntities, "CoreModules_Ky")%>&CoreEntities_Ky=<%=Smartdesk.Data.Field(dtCoreEntities, "CoreEntities_Ky")%>&sorgente=scheda-coreentities" class="tiny button clear"><i class="fa-duotone fa-square-plus fa-fw"></i>Generate Form</a>
						<a href="/admin/app/sdk/genera-where.aspx?CoreModules_Ky=<%=Smartdesk.Data.Field(dtCoreEntities, "CoreModules_Ky")%>&CoreEntities_Ky=<%=Smartdesk.Data.Field(dtCoreEntities, "CoreEntities_Ky")%>&sorgente=scheda-coreentities" class="tiny button clear"><i class="fa-duotone fa-filter fa-fw"></i>Generate Where Form</a>
						<a href="/admin/app/sdk/scheda-coreForms.aspx?azione=new&CoreModules_Ky=<%=Smartdesk.Data.Field(dtCoreEntities, "CoreModules_Ky")%>&CoreEntities_Ky=<%=Smartdesk.Data.Field(dtCoreEntities, "CoreEntities_Ky")%>&sorgente=scheda-coreentities" class="tiny button"><i class="fa-duotone fa-square-plus fa-fw"></i> New Form</a>
			  	</div>
		  </div>
		  <div class="card-section">
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
	        <tr>
	          <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	          <th width="30" align="left">id</th>
	          <th width="150" align="left">Title</th>
	          <th width="120" align="left">SQL From</th>
	          <th width="50" class="large-text-center small-text-left">Custom</th>
	          <th width="50" class="large-text-center small-text-left">Default</th>
	          <th width="50" class="large-text-center small-text-left">Fields</th>
	          <th width="50" align="left">Order</th>
						<th width="50" class="text-center nowrap" data-orderable="false"></th>
	        </tr>
	      </thead>
	   		<tbody>
        <%for (int i = 0; i < dtCoreForms.Rows.Count; i++){ %>
            <tr>
  		        <td><input type="checkbox" class="checkrow" id="record<%=dtCoreForms.Rows[i]["CoreForms_Ky"].ToString()%>" data-value="<%=dtCoreForms.Rows[i]["CoreForms_Ky"].ToString()%>" /></td>
              <td class="text-left"><a href="/admin/app/sdk/scheda-CoreForms.aspx?CoreForms_Ky=<%=dtCoreForms.Rows[i]["CoreForms_Ky"].ToString()%>&CoreModules_Ky=<%=dtCoreForms.Rows[i]["CoreModules_Ky"].ToString()%>&sorgente=scheda-entities"><%=dtCoreForms.Rows[i]["CoreForms_Ky"].ToString()%></a></td>
              <td class="text-left"><a href="/admin/app/sdk/scheda-CoreForms.aspx?CoreForms_Ky=<%=dtCoreForms.Rows[i]["CoreForms_Ky"].ToString()%>&CoreModules_Ky=<%=dtCoreForms.Rows[i]["CoreModules_Ky"].ToString()%>&sorgente=scheda-entities"><%=dtCoreForms.Rows[i]["CoreForms_Title"].ToString()%></a></td>
              <td class="text-left"><%=dtCoreForms.Rows[i]["CoreForms_SQLFrom"].ToString()%></td>
		          <td class="large-text-center small-text-left">
								<% if (dtCoreForms.Rows[i]["CoreForms_Custom"].Equals(true)){ %>
									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
								<% }else{ %>
									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
								<% } %>
							</td>
		          <td class="large-text-center small-text-left">
								<% if (dtCoreForms.Rows[i]["CoreForms_Default"].Equals(true)){ %>
									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
								<% }else{ %>
									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
								<% } %>
							</td>
		          <td class="large-text-center small-text-left">
								<% if (dtCoreForms.Rows[i]["CoreForms_WhichFields"].Equals(1)){ %>
									All
								<% }else{ %>
									Selected
								<% } %>
							</td>
              <td class="text-left"><%=dtCoreForms.Rows[i]["CoreForms_Order"].ToString()%></td>
              <td class="text-center nowrap"><a href="/admin/app/sdk/crud/elimina-CoreForms.aspx?azione=delete&CoreForms_Ky=<%=dtCoreForms.Rows[i]["CoreForms_Ky"].ToString()%>&CoreEntities_Ky=<%=dtCoreForms.Rows[i]["CoreEntities_Ky"].ToString()%>&sorgente=scheda-entities" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
            </tr>
        <% } %>
	   		</tbody>
			  <% if (dtCoreForms.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
		  </div>
		</div>
  </div>
</div>
