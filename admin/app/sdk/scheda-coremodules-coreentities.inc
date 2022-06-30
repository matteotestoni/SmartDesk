<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="CoreEntities"></a>
	    		<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Entities (<%=dtCoreEntities.Rows.Count%>)</h2>
					<div class="button-group tiny">
						<a href="/admin/app/sdk/scheda-coreentities.aspx?azione=new&CoreModules_Ky=<%=Smartdesk.Data.Field(dtCoreModules, "CoreModules_Ky")%>&sorgente=scheda-coremodules" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i> New Entity</a>
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
	          <th width="60" class="text-left">Config</th>
	          <th width="60" class="text-left">In Menu</th>
	          <th width="90" class="text-left">Custom Save</th>
	          <th width="90" class="text-left">Custom Delete</th>
	          <th width="40" class="text-left">Order</th>
						<th width="50" class="text-center nowrap" data-orderable="false"></th>
	        </tr>
	      </thead>
	   		<tbody>
        <%for (int i = 0; i < dtCoreEntities.Rows.Count; i++){ %>
            <tr>
  		        <td><input type="checkbox" class="checkrow" id="record<%=dtCoreEntities.Rows[i]["CoreEntities_Ky"].ToString()%>" data-value="<%=dtCoreEntities.Rows[i]["CoreEntities_Ky"].ToString()%>" /></td>
              <td class="large-text-center small-text-left"><a href="/admin/app/sdk/scheda-coreentities.aspx?CoreModules_Ky=<%=dtCoreEntities.Rows[i]["CoreModules_Ky"].ToString()%>&CoreEntities_Ky=<%=dtCoreEntities.Rows[i]["CoreEntities_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtCoreEntities.Rows[i]["CoreEntities_Ky"].ToString()%></a></td>
              <td class="text-left"><a href="/admin/app/sdk/scheda-coreentities.aspx?CoreModules_Ky=<%=dtCoreEntities.Rows[i]["CoreModules_Ky"].ToString()%>&CoreEntities_Ky=<%=dtCoreEntities.Rows[i]["CoreEntities_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><i class="<%=dtCoreEntities.Rows[i]["CoreEntities_Icon"].ToString()%> fa-fw"></i><%=dtCoreEntities.Rows[i]["CoreEntities_Code"].ToString()%></a></td>
              <td class="text-left"><%=dtCoreEntities.Rows[i]["CoreEntities_Title"].ToString()%></td>
	          <td class="large-text-center small-text-left">
  					<% if (dtCoreEntities.Rows[i]["CoreEntities_Config"].Equals(true)){ %>
  						<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
  					<% }else{ %>
  						<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
  					<% } %>
  			  </td>
	          <td class="large-text-center small-text-left">
  					<% if (dtCoreEntities.Rows[i]["CoreEntities_InMenu"].Equals(true)){ %>
  						<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
  					<% }else{ %>
  						<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
  					<% } %>
  			  </td>
          <td class="large-text-center small-text-left">
  					<% if (dtCoreEntities.Rows[i]["CoreEntities_CustomSave"].Equals(true)){ %>
  						<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
  					<% }else{ %>
  						<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
  					<% } %>
  			  </td>
          <td class="large-text-center small-text-left">
  					<% if (dtCoreEntities.Rows[i]["CoreEntities_CustomDelete"].Equals(true)){ %>
  						<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
  					<% }else{ %>
  						<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
  					<% } %>
  			  </td>


          <td class="text-left">
    				<div class="input-group">
    					<input class="input-group-field" type="number" name="CoreEntities_Order<%=i%>" id="CoreEntities_Order<%=i%>" style="width:30px" size="2" value="<%=dtCoreEntities.Rows[i]["CoreEntities_Order"].ToString()%>" onchange="saveOrder(<%=dtCoreEntities.Rows[i]["CoreEntities_Ky"].ToString()%>, <%=i%>)">
    					<div class="input-group-button">
    						<button class="tiny button secondary hide" onclick="saveOrder(<%=dtCoreEntities.Rows[i]["CoreEntities_Ky"].ToString()%>, <%=i%>)"><i class="fa-duotone fa-floppy-disk fa-fw"></i></button>
    					</div>
    				</div>
           </td>
              <td class="text-center nowrap"><a href="/admin/app/sdk/crud/elimina-coreentities.aspx?azione=delete&CoreModules_Ky=<%=dtCoreEntities.Rows[i]["CoreModules_Ky"].ToString()%>&CoreEntities_Ky=<%=dtCoreEntities.Rows[i]["CoreEntities_Ky"].ToString()%>&sorgente=scheda-coremodules" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
            </tr>
        <% } %>
	   		</tbody>
			  <% if (dtCoreEntities.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
		  </div>
		</div>
  </div>
</div>
<script>
function saveOrder(intCoreEntities_ky, intRow){
	$url="/admin/app/sdk/actions/coreentities-changeorder.aspx";
	$orderfield="#CoreEntities_Order" + intRow + "";
	console.log($orderfield);
	$ordine=jQuery($orderfield).val();
	console.log($ordine);
	console.log($url);
	$data= { ajax:true, CoreEntities_Ky: intCoreEntities_ky, CoreEntities_Order: $ordine };
	console.log($data);
	jQuery.ajax({
		type: "POST",
		url: $url,
		data: $data
	})
	.done(function( data ) {
    	jQuery($orderfield).css('border-color', "green");
		//alert( "salvato");
  	});	

}
</script>
