<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a id="CoreFormsFields" name="CoreFormsFields"></a>
	    		<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Campi del form (<%=dtCoreFormsFields.Rows.Count%>)</h2>
					<div class="button-group tiny">
						<a href="/admin/app/sdk/scheda-coreforms-addcolumns.aspx?azione=new&CoreEntities_Ky=<%=Smartdesk.Data.Field(dtCoreForms, "CoreEntities_Ky")%>&CoreModules_Ky=<%=Smartdesk.Data.Field(dtCoreModules, "CoreModules_Ky")%>&CoreForms_Ky=<%=Smartdesk.Data.Field(dtCoreForms, "CoreForms_Ky")%>&sorgente=scheda-coreforms" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>Gestisci colonne</a>
						<a href="/admin/app/sdk/scheda-coreforms-genera-form.aspx?CoreEntities_Ky=<%=Smartdesk.Data.Field(dtCoreForms, "CoreEntities_Ky")%>&CoreModules_Ky=<%=Smartdesk.Data.Field(dtCoreModules, "CoreModules_Ky")%>&CoreForms_Ky=<%=Smartdesk.Data.Field(dtCoreForms, "CoreForms_Ky")%>&sorgente=scheda-coreforms" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>Genera form</a>
						<a href="/admin/app/sdk/scheda-coreforms-ordercolumns.aspx?azione=new&CoreEntities_Ky=<%=Smartdesk.Data.Field(dtCoreForms, "CoreEntities_Ky")%>&CoreModules_Ky=<%=Smartdesk.Data.Field(dtCoreModules, "CoreModules_Ky")%>&CoreForms_Ky=<%=Smartdesk.Data.Field(dtCoreForms, "CoreForms_Ky")%>&sorgente=scheda-coreforms" class="tiny button secondary"><i class="fa-duotone fa-sort-alpha-down fa-fw"></i>Ordine colonne</a>
			  	</div>
		  </div>
		  <div class="card-section">
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
	        <tr>
	          <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	          <th width="30" class="text-center">Id</th>
	          <th width="30" class="text-left">Id Attributo</th>
	          <th width="200" class="text-left">Codice</th>
	          <th width="120" class="text-left">Title</th>
	          <th width="120" class="text-left">Label</th>
	          <th width="100" class="text-left">Tab</th>
	          <th width="140" class="text-left">Fieldset</th>
	          <th width="40" class="text-left">Columns</th>
	          <th width="40" class="text-left">Hidden</th>
	          <th width="40" class="text-left">Readonly</th>
	          <th width="30" class="text-left">Order</th>
			  <th width="50" class="text-center nowrap" data-orderable="false"></th>
	        </tr>
	      </thead>
	   		<tbody>
        <%for (int i = 0; i < dtCoreFormsFields.Rows.Count; i++){ %>
            <tr>
  		      <td><input type="checkbox" class="checkrow" id="record<%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Ky"].ToString()%>" data-value="<%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Ky"].ToString()%>" /></td>
              <td class="large-text-center small-text-left"><a href="/admin/app/sdk/scheda-coreformsfields.aspx?CoreFormsFields_Ky=<%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Ky"].ToString()%>&CoreForms_Ky=<%=dtCoreFormsFields.Rows[i]["CoreForms_Ky"].ToString()%>&CoreModules_Ky=<%=dtCoreFormsFields.Rows[i]["CoreModules_Ky"].ToString()%>&CoreEntities_Ky=<%=dtCoreFormsFields.Rows[i]["CoreEntities_Ky"].ToString()%>&sorgente=scheda-coreforms"><%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Ky"].ToString()%></a></td>
              <td><%=dtCoreFormsFields.Rows[i]["CoreAttributes_Ky"].ToString()%></td>
              <td><a href="/admin/app/sdk/scheda-coreformsfields.aspx?CoreFormsFields_Ky=<%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Ky"].ToString()%>&CoreForms_Ky=<%=dtCoreFormsFields.Rows[i]["CoreForms_Ky"].ToString()%>&CoreModules_Ky=<%=dtCoreFormsFields.Rows[i]["CoreModules_Ky"].ToString()%>&sorgente=scheda-coreforms"><%=dtCoreFormsFields.Rows[i]["CoreAttributes_Code"].ToString()%></a></td>
              <td><%=dtCoreFormsFields.Rows[i]["CoreAttributes_Title"].ToString()%></td>
              <td>
      				<div class="input-group">
      					<input class="input-group-field" type="text" name="CoreFormsFields_Label<%=i%>" id="CoreFormsFields_Label<%=i%>" style="width:90px" value="<%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Label"].ToString()%>" onchange="saveLabelCoreFormsFields(<%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Ky"].ToString()%>, <%=i%>)">
      				</div>
      
      			  </td>
              <td>
      				<select id="CoreFormsTabs_Ky<%=i%>" name="CoreFormsTabs_Ky" value="<%=dtCoreFormsFields.Rows[i]["CoreFormsTabs_Ky"].ToString()%>" onchange="saveTabCoreFormsFields(this, <%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Ky"].ToString()%>)">
      					<option value=""></option>
      					<% for (int j = 0; j < dtCoreFormsTabs.Rows.Count; j++){ %>
      						<% if (dtCoreFormsFields.Rows[i]["CoreFormsTabs_Ky"].ToString()==dtCoreFormsTabs.Rows[j]["CoreFormsTabs_Ky"].ToString()){ %>
      							<option selected="selected" value="<%=dtCoreFormsTabs.Rows[j]["CoreFormsTabs_Ky"].ToString()%>"><%=dtCoreFormsTabs.Rows[j]["CoreFormsTabs_Title"].ToString()%></option>
      						<% }else{ %>
      							<option value="<%=dtCoreFormsTabs.Rows[j]["CoreFormsTabs_Ky"].ToString()%>"><%=dtCoreFormsTabs.Rows[j]["CoreFormsTabs_Title"].ToString()%></option>
      						<% } %>
      					<% } %>
      				</select>  
      			  </td>
              <td>
				<select id="CoreFormsFieldset_Ky<%=i%>" name="CoreFormsFieldset_Ky<%=i%>" value="<%=dtCoreFormsFields.Rows[i]["CoreFormsFieldset_Ky"].ToString()%>" onchange="saveFieldsetCoreFormsFields(<%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Ky"].ToString()%>, <%=i%>)">
					<option value=""></option>
					<% for (int j = 0; j < dtCoreFormsFieldset.Rows.Count; j++){ %>
						<% if (dtCoreFormsFields.Rows[i]["CoreFormsFieldset_Ky"].ToString().Trim()==dtCoreFormsFieldset.Rows[j]["CoreFormsFieldset_Ky"].ToString().Trim()){ %>
							<option selected="selected" value="<%=dtCoreFormsFieldset.Rows[j]["CoreFormsFieldset_Ky"].ToString()%>"><%=dtCoreFormsFieldset.Rows[j]["CoreFormsFieldset_Title"].ToString()%></option>
						<% } else { %>
							<option value="<%=dtCoreFormsFieldset.Rows[j]["CoreFormsFieldset_Ky"].ToString()%>"><%=dtCoreFormsFieldset.Rows[j]["CoreFormsFieldset_Title"].ToString()%></option>
						<% } %>
					<% } %>
				</select>  
			 </td>
              <td>
				<div class="input-group">
					<input class="input-group-field" type="number" name="CoreFormsFields_Columns<%=i%>" id="CoreFormsFields_Columns<%=i%>" style="width:30px" size="2" value="<%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Columns"].ToString()%>" onchange="saveColumnsCoreFormsFields(<%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Ky"].ToString()%>, <%=i%>)">
				</div>

			  </td>
        <td class="large-text-center small-text-left">
          <% if (dtCoreFormsFields.Rows[i]["CoreFormsFields_Hidden"].Equals(true)){ %>
          <a onclick="saveHiddenCoreFormsFields(<%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Ky"].ToString()%>, <%=i%>, 0)"><i name="CoreFormsFields_Hidden<%=i%>" id="CoreFormsFields_Hidden<%=i%>" class="fa-duotone fa-square-check success fa-fw"></i></a>
          <% }else{ %>
          <a onclick="saveHiddenCoreFormsFields(<%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Ky"].ToString()%>, <%=i%>, 1)"><i name="CoreFormsFields_Hidden<%=i%>" id="CoreFormsFields_Hidden<%=i%>" class="fa-duotone fa-square alert fa-fw"></i></a>
          <% } %>
        </td>
        <td class="large-text-center small-text-left">
          <% if (dtCoreFormsFields.Rows[i]["CoreFormsFields_Readonly"].Equals(true)){ %>
          <a onclick="saveReadonlyCoreFormsFields(<%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Ky"].ToString()%>, <%=i%>, 0)"><i name="CoreFormsFields_Readonly<%=i%>" id="CoreFormsFields_Readonly<%=i%>" class="fa-duotone fa-square-check success fa-fw"></i></a>
          <% }else{ %>
          <a onclick="saveReadonlyCoreFormsFields(<%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Ky"].ToString()%>, <%=i%>, 1)"><i name="CoreFormsFields_Readonly<%=i%>" id="CoreFormsFields_Readonly<%=i%>" class="fa-duotone fa-square alert fa-fw"></i></a>
          <% } %>
        </td>
        <td>
				<div class="input-group">
					<input class="input-group-field" type="number" name="CoreFormsFields_Order<%=i%>" id="CoreFormsFields_Order<%=i%>" style="width:30px" size="2" value="<%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Order"].ToString()%>" onchange="saveOrderCoreFormsFields(<%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Ky"].ToString()%>, <%=i%>)">
				</div>

			  </td>
              <td class="text-center nowrap"><a href="/admin/app/sdk/crud/elimina-CoreFormsFields.aspx?azione=delete&CoreModules_Ky=<%=dtCoreFormsFields.Rows[i]["CoreModules_Ky"].ToString()%>&CoreFormsFields_Ky=<%=dtCoreFormsFields.Rows[i]["CoreFormsFields_Ky"].ToString()%>&CoreForms_Ky=<%=dtCoreFormsFields.Rows[i]["CoreForms_Ky"].ToString()%>&sorgente=scheda-coreforms" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
            </tr>
        <% } %>
	   		</tbody>
			  <% if (dtCoreFormsFields.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
		  </div>
		</div>
  </div>
</div>
<script>
function saveOrderCoreFormsFields(intCoreFormsFields_Ky, intRow){
	$url="/admin/app/sdk/actions/coreformsfields-changeorder.aspx";
	$orderfield="#CoreFormsFields_Order" + intRow + "";
	console.log($orderfield);
	$ordine=jQuery($orderfield).val();
	console.log($ordine);
	console.log($url);
	$data= { ajax:true, CoreFormsFields_Ky: intCoreFormsFields_Ky, CoreFormsFields_Order: $ordine, CoreEntities_Ky: <%=Smartdesk.Data.Field(dtCoreForms, "CoreEntities_Ky")%>, CoreModules_Ky:<%=Smartdesk.Data.Field(dtCoreModules, "CoreModules_Ky")%> };
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

function saveLabelCoreFormsFields(intCoreFormsFields_Ky, intRow){
	$url="/admin/app/sdk/actions/coreformsfields-changelabel.aspx";
	$labelfield="#CoreFormsFields_Label" + intRow + "";
	$label=jQuery($labelfield).val();
	$data= { ajax:true, CoreFormsFields_Ky: intCoreFormsFields_Ky, CoreFormsFields_Label: $label, CoreEntities_Ky: <%=Smartdesk.Data.Field(dtCoreForms, "CoreEntities_Ky")%>, CoreModules_Ky:<%=Smartdesk.Data.Field(dtCoreModules, "CoreModules_Ky")%> };
	jQuery.ajax({
		type: "POST",
		url: $url,
		data: $data
	})
	.done(function( data ) {
    	jQuery($labelfield).css('border-color', "green");
  	});	
}


function saveColumnsCoreFormsFields(intCoreFormsFields_Ky, intRow){
	$url="/admin/app/sdk/actions/coreformsfields-changecolumns.aspx";
	$columnsfield="#CoreFormsFields_Columns" + intRow + "";
	console.log($columnsfield);
	$columns=jQuery($columnsfield).val();
	console.log($columns);
	console.log($url);
	$data= { ajax:true, CoreFormsFields_Ky: intCoreFormsFields_Ky, CoreFormsFields_Columns: $columns, CoreEntities_Ky: <%=Smartdesk.Data.Field(dtCoreForms, "CoreEntities_Ky")%>, CoreModules_Ky:<%=Smartdesk.Data.Field(dtCoreModules, "CoreModules_Ky")%> };
	console.log($data);
	jQuery.ajax({
		type: "POST",
		url: $url,
		data: $data
	})
	.done(function( data ) {
    	jQuery($columnsfield).css('border-color', "green");
		//alert( "salvato");
  	});	
}

function saveHiddenCoreFormsFields(intCoreFormsFields_Ky, intRow, intValue){
	$url="/admin/app/sdk/actions/coreformsfields-changehidden.aspx";
	$data= { ajax:true, CoreFormsFields_Ky: intCoreFormsFields_Ky, CoreFormsFields_Hidden: intValue, CoreEntities_Ky: <%=Smartdesk.Data.Field(dtCoreForms, "CoreEntities_Ky")%>, CoreModules_Ky:<%=Smartdesk.Data.Field(dtCoreModules, "CoreModules_Ky")%> };
	$hiddenfield="#CoreFormsFields_Hidden" + intRow + "";
	console.log($data);
	jQuery.ajax({
		type: "POST",
		url: $url,
		data: $data
	})
	.done(function( data ) {
    if (intValue==1){
      jQuery($hiddenfield).addClass('fa-check-square').removeClass('fa-square').css('border-color', "green");
    }else{
      jQuery($hiddenfield).addClass('fa-square').removeClass('fa-check-square').css('border-color', "green");
    }
		//alert( "salvato");
  	});	
}

function saveReadonlyCoreFormsFields(intCoreFormsFields_Ky, intRow, intValue){
	$url="/admin/app/sdk/actions/coreformsfields-changereadonly.aspx";
	$data= { ajax:true, CoreFormsFields_Ky: intCoreFormsFields_Ky, CoreFormsFields_Readonly: intValue, CoreEntities_Ky: <%=Smartdesk.Data.Field(dtCoreForms, "CoreEntities_Ky")%>, CoreModules_Ky:<%=Smartdesk.Data.Field(dtCoreModules, "CoreModules_Ky")%> };
	$readonlyfield="#CoreFormsFields_Readonly" + intRow + "";
	console.log($data);
	jQuery.ajax({
		type: "POST",
		url: $url,
		data: $data
	})
	.done(function( data ) {
    if (intValue==1){
      jQuery($readonlyfield).addClass('fa-check-square').removeClass('fa-square').css('border-color', "green");
    }else{
      jQuery($readonlyfield).addClass('fa-square').removeClass('fa-check-square').css('border-color', "green");
    }
		//alert( "salvato");
  	});	
}

function saveFieldsetCoreFormsFields(intCoreFormsFields_Ky, intRow){
	$url="/admin/app/sdk/actions/coreformsfields-changefieldset.aspx";
	$field="#CoreFormsFieldset_Ky" + intRow + "";
	console.log($field);
	$value=jQuery($field).val();
	console.log($value);
	console.log($url);
	$data= { ajax:true, CoreFormsFields_Ky: intCoreFormsFields_Ky, CoreFormsFieldset_Ky: $value, CoreEntities_Ky: <%=Smartdesk.Data.Field(dtCoreForms, "CoreEntities_Ky")%>, CoreModules_Ky:<%=Smartdesk.Data.Field(dtCoreModules, "CoreModules_Ky")%> };
	console.log($data);
	jQuery.ajax({
		type: "POST",
		url: $url,
		data: $data
	})
	.done(function( data ) {
    	jQuery($field).css('border-color', "green");
		//alert( "salvato");
  	});	
}

function saveTabCoreFormsFields(selectObject, intCoreFormsFields_Ky){
	$url="/admin/app/sdk/actions/coreformsfields-changetab.aspx";
	$value=selectObject.value;
	console.log($value);
	console.log($url);
	$data= { ajax:true, CoreFormsFields_Ky: intCoreFormsFields_Ky, CoreFormsTabs_Ky: $value, CoreEntities_Ky: <%=Smartdesk.Data.Field(dtCoreForms, "CoreEntities_Ky")%>, CoreModules_Ky:<%=Smartdesk.Data.Field(dtCoreModules, "CoreModules_Ky")%> };
	console.log($data);
	jQuery.ajax({
		type: "POST",
		url: $url,
		data: $data
	})
	.done(function( data ) {
    	$field="#";
        $field=$field.concat(selectObject.id);
        jQuery($field).css('border-color', "green");
  	});	
}

</script>

