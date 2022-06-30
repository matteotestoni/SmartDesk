<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="CoreEntities"></a>
	    		<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Attributi (<%=dtCoreAttributes.Rows.Count%>)</h2>
					<div class="button-group tiny">
						<a href="/admin/app/sdk/scheda-coreattributes.aspx?azione=new&CoreModules_Ky=<%=Smartdesk.Data.Field(dtCoreEntities, "CoreModules_Ky")%>&CoreEntities_Ky=<%=Smartdesk.Data.Field(dtCoreEntities, "CoreEntities_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i> Nuovo attributo</a>
			  	</div>
		  </div>
		  <div class="card-section">
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
	        <tr>
	          <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	          <th width="30" align="left">id</th>
	          <th width="120" align="left">Codice</th>
	          <th width="80" align="left">Tipo</th>
	          <th width="60" align="left">Formato</th>
	          <th width="150" align="left">Titolo</th>
	          <th width="60" class="large-text-center small-text-left">Ricercabile</th>
	          <th width="60" class="large-text-center small-text-left">Sistema</th>
	          <th width="60" class="large-text-center small-text-left">Chiave</th>
	          <th width="40" align="left">Ordine</th>
						<th width="50" class="text-center nowrap" data-orderable="false"></th>
	        </tr>
	      </thead>
	   		<tbody>
        <%for (int i = 0; i < dtCoreAttributes.Rows.Count; i++){ %>
            <tr>
  		        <td><input type="checkbox" class="checkrow" id="record<%=dtCoreAttributes.Rows[i]["CoreAttributes_Ky"].ToString()%>" data-value="<%=dtCoreAttributes.Rows[i]["CoreAttributes_Ky"].ToString()%>" /></td>
              <td class="text-left"><a href="/admin/app/sdk/scheda-coreattributes.aspx?CoreAttributes_Ky=<%=dtCoreAttributes.Rows[i]["CoreAttributes_Ky"].ToString()%>&sorgente=scheda-entities"><%=dtCoreAttributes.Rows[i]["CoreAttributes_Ky"].ToString()%></a></td>
              <td class="text-left"><a href="/admin/app/sdk/scheda-coreattributes.aspx?CoreAttributes_Ky=<%=dtCoreAttributes.Rows[i]["CoreAttributes_Ky"].ToString()%>&sorgente=scheda-entities"><%=dtCoreAttributes.Rows[i]["CoreAttributes_Code"].ToString()%></a></td>
              <td class="text-left"><i class="<%=dtCoreAttributes.Rows[i]["CoreAttributesType_Icon"].ToString()%> fa-fw"></i><%=dtCoreAttributes.Rows[i]["CoreAttributesType_Code"].ToString()%></td>
              <td class="text-left"><i class="<%=dtCoreAttributes.Rows[i]["CoreAttributesFormat_Icon"].ToString()%> fa-fw"></i><%=dtCoreAttributes.Rows[i]["CoreAttributesFormat_Code"].ToString()%></td>
              <td class="text-left"><%=dtCoreAttributes.Rows[i]["CoreAttributes_Title"].ToString()%></td>
		          <td class="large-text-center small-text-left">
								<a href="/admin/app/sdk/actions/coreattributes-makesearchable.aspx?CoreAttributes_Ky=<%=dtCoreAttributes.Rows[i]["CoreAttributes_Ky"].ToString()%>&CoreEntities_Ky=<%=dtCoreAttributes.Rows[i]["CoreEntities_Ky"].ToString()%>">
								<% if (dtCoreAttributes.Rows[i]["CoreAttributes_Search"].Equals(true)){ %>
									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
								<% }else{ %>
									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
								<% } %>
								</a>
							</td>
		          <td class="large-text-center small-text-left">
								<% if (dtCoreAttributes.Rows[i]["CoreAttributes_System"].Equals(true)){ %>
									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
								<% }else{ %>
									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
								<% } %>
							</td>
		          <td class="large-text-center small-text-left">
								<a href="/admin/app/sdk/actions/coreattributes-makekey.aspx?CoreAttributes_Ky=<%=dtCoreAttributes.Rows[i]["CoreAttributes_Ky"].ToString()%>&CoreEntities_Ky=<%=dtCoreAttributes.Rows[i]["CoreEntities_Ky"].ToString()%>">
								<% if (dtCoreAttributes.Rows[i]["CoreAttributes_Key"].Equals(true)){ %>
									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
								<% }else{ %>
									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
								<% } %>
								</a>
							</td>
              <td class="text-left">
				<div class="input-group">
					<input class="input-group-field" type="number" name="CoreAttributes_Order<%=i%>" id="CoreAttributes_Order<%=i%>" style="width:30px" size="2" value="<%=dtCoreAttributes.Rows[i]["CoreAttributes_Order"].ToString()%>" onchange="saveOrder(<%=dtCoreAttributes.Rows[i]["CoreAttributes_Ky"].ToString()%>, <%=i%>)">
					<div class="input-group-button">
						<button class="tiny button secondary hide" onclick="saveOrder(<%=dtCoreAttributes.Rows[i]["CoreAttributes_Ky"].ToString()%>, <%=i%>)"><i class="fa-duotone fa-floppy-disk fa-fw"></i></button>
					</div>
				</div>
			  </td>
              <td class="text-center nowrap">
				<a href="/admin/app/sdk/crud/elimina-coreattributes.aspx?azione=delete&CoreAttributes_Ky=<%=dtCoreAttributes.Rows[i]["CoreAttributes_Ky"].ToString()%>&CoreEntities_Ky=<%=dtCoreAttributes.Rows[i]["CoreEntities_Ky"].ToString()%>&CoreModules_Ky=<%=dtCoreAttributes.Rows[i]["CoreModules_Ky"].ToString()%>&sorgente=scheda-coreentities" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
				<a href="/admin/app/sdk/actions/coreattributes-makekey.aspx?azione=makekey&CoreAttributes_Ky=<%=dtCoreAttributes.Rows[i]["CoreAttributes_Ky"].ToString()%>&CoreEntities_Ky=<%=dtCoreAttributes.Rows[i]["CoreEntities_Ky"].ToString()%>&CoreModules_Ky=<%=dtCoreAttributes.Rows[i]["CoreModules_Ky"].ToString()%>&sorgente=scheda-coreentities" title="chiave principale" class="key"><i class="fa-duotone fa-key fa-fw"></i></a>
			  </td>
            </tr>
        <% } %>
	   		</tbody>
			  <% if (dtCoreAttributes.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
		  </div>
		</div>
  </div>
</div>
<script>
function saveOrder(intCoreAttributes_ky, intRow){
	$url="/admin/app/sdk/actions/coreattributes-changeorder.aspx";
	$orderfield="#CoreAttributes_Order" + intRow + "";
	console.log($orderfield);
	$ordine=jQuery($orderfield).val();
	console.log($ordine);
	console.log($url);
	$data= { ajax:true, CoreAttributes_Ky: intCoreAttributes_ky, CoreAttributes_Order: $ordine, CoreEntities_Ky: 161, CoreModules_Ky:19 };
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
