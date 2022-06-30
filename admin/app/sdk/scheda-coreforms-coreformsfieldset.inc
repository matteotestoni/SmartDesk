<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="CoreFormsFieldset"></a>
	    		<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Fieldset del form (<%=dtCoreFormsFieldset.Rows.Count%>)</h2>
		  </div>
		  <div class="card-section">
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
	        <tr>
	          <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	          <th width="30" class="text-center">Id</th>
	          <th width="150" class="text-left">Titolo</th>
	          <th width="80" class="text-left">Attributi</th>
	          <th width="100" class="text-left">Tab</th>
	          <th width="30" class="text-left">Ordine</th>
			  <th width="50" class="text-center nowrap" data-orderable="false"></th>
	        </tr>
	      </thead>
	   		<tbody>
        <%for (int i = 0; i < dtCoreFormsFieldset.Rows.Count; i++){ %>
            <tr>
  		        <td><input type="checkbox" class="checkrow" id="record<%=dtCoreFormsFieldset.Rows[i]["CoreFormsFieldset_Ky"].ToString()%>" data-value="<%=dtCoreFormsFieldset.Rows[i]["CoreFormsFieldset_Ky"].ToString()%>" /></td>
              <td class="large-text-center small-text-left"><a href="/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=193&CoreForms_Ky=92&CoreFormsFieldset_Ky=<%=dtCoreFormsFieldset.Rows[i]["CoreFormsFieldset_Ky"].ToString()%>&sorgente=scheda-coreforms"><%=dtCoreFormsFieldset.Rows[i]["CoreFormsFieldset_Ky"].ToString()%></a></td>
              <td><a href="/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=193&CoreForms_Ky=92&CoreFormsFieldset_Ky=<%=dtCoreFormsFieldset.Rows[i]["CoreFormsFieldset_Ky"].ToString()%>&sorgente=scheda-coreforms"><%=dtCoreFormsFieldset.Rows[i]["CoreFormsFieldset_Title"].ToString()%></a></td>
  		      <td>
                <%
              	System.Data.DataTable dtAttributixFieldset;
              	dtAttributixFieldset = new System.Data.DataTable("AttributixFieldset");
              	dtAttributixFieldset = Smartdesk.Sql.getTablePage("CoreFormsFields", null, "CoreFormsFields_Ky", "CoreFormsFieldset_Ky=" + dtCoreFormsFieldset.Rows[i]["CoreFormsFieldset_Ky"].ToString(), "CoreFormsFields_Ky", 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                Response.Write(dtAttributixFieldset.Rows.Count);
                %>
                </td>
              <td>
      				<select id="CoreFormsTabs_Ky<%=i%>" name="CoreFormsTabs_Ky" value="<%=dtCoreFormsFieldset.Rows[i]["CoreFormsTabs_Ky"].ToString()%>" onchange="saveTabCoreFormsFieldset(this, <%=dtCoreFormsFieldset.Rows[i]["CoreFormsFieldset_Ky"].ToString()%>)">
      					<option value=""></option>
      					<% for (int j = 0; j < dtCoreFormsTabs.Rows.Count; j++){ %>
      						<% if (dtCoreFormsFieldset.Rows[i]["CoreFormsTabs_Ky"].ToString()==dtCoreFormsTabs.Rows[j]["CoreFormsTabs_Ky"].ToString()){ %>
      							<option selected="selected" value="<%=dtCoreFormsTabs.Rows[j]["CoreFormsTabs_Ky"].ToString()%>"><%=dtCoreFormsTabs.Rows[j]["CoreFormsTabs_Title"].ToString()%></option>
      						<% }else{ %>
      							<option value="<%=dtCoreFormsTabs.Rows[j]["CoreFormsTabs_Ky"].ToString()%>"><%=dtCoreFormsTabs.Rows[j]["CoreFormsTabs_Title"].ToString()%></option>
      						<% } %>
      					<% } %>
      				</select>  
      			  </td>
              <td>
      				<div class="input-group">
      					<input class="input-group-field" type="number" name="CoreFormsFieldset_Order<%=i%>" id="CoreFormsFieldset_Order<%=i%>" style="width:30px" size="2" value="<%=dtCoreFormsFieldset.Rows[i]["CoreFormsFieldset_Order"].ToString()%>" onchange="saveOrderCoreFormsFieldset(<%=dtCoreFormsFieldset.Rows[i]["CoreFormsFieldset_Ky"].ToString()%>, <%=i%>)">
      				</div>
              </td>
              <td class="text-center nowrap"><a href="/admin/app/sdk/crud/elimina-CoreFormsFieldset.aspx?azione=delete&CoreModules_Ky=<%=dtCoreFormsFieldset.Rows[i]["CoreModules_Ky"].ToString()%>&CoreFormsFieldset_Ky=<%=dtCoreFormsFieldset.Rows[i]["CoreFormsFieldset_Ky"].ToString()%>&CoreForms_Ky=<%=dtCoreFormsFieldset.Rows[i]["CoreForms_Ky"].ToString()%>&sorgente=scheda-coreforms" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
            </tr>
        <% } %>
	   		</tbody>
			  <% if (dtCoreFormsFieldset.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun fieldset</div></td></tr></foot>");
				} %> 
      </table>
      
      <% if (strAzione!="new"){ %>
      <fieldset class="fieldset">
        <legend><i class="fa-duotone fa-square-plus fa-fw"></i>New fieldset</legend>
        <form id="form-CoreFormsFieldset" action="/admin/app/sdk/crud/salva-CoreFormsFieldset.aspx" enctype="multipart/form-data" method="post" data-abide novalidate>
          <input type="hidden" name="azione" id="azione" value="new">
          <input type="hidden" name="sorgente" id="sorgente" value="scheda-coreforms">
          <input type="hidden" name="CoreFormsFieldset_Ky" id="CoreFormsFieldset_Ky" value="">
          <input type="hidden" name="CoreForms_Ky" id="CoreForms_Ky" value="<%=strCoreForms_Ky%>">
          <div class="grid-x grid-padding-x">
            <div class="small-12 medium-3 large-3 cell">
              <select name="CoreFormsTabs_Ky" id="CoreFormsTabs_Ky" value="" placeholder="Tab">
                <option></option>
                <%for (int i = 0; i < dtCoreFormsTabs.Rows.Count; i++){ %>
                  <option value="<%=dtCoreFormsTabs.Rows[i]["CoreFormsTabs_Ky"].ToString()%>"><%=dtCoreFormsTabs.Rows[i]["CoreFormsTabs_Title"].ToString()%></option>
                <% } %>
              </select>
            </div>
            <div class="small-12 medium-3 large-3 cell">
              <input type="text" name="CoreFormsFieldset_Title" id="CoreFormsFieldset_Title" value="" placeholder="Title">
            </div>
             <div class="small-12 medium-3 large-3 cell">
             <input type="number" name="CoreFormsFieldset_Order" id="CoreFormsFieldset_Order" value="" placeholder="Order">
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
<script>
function saveOrderCoreFormsFieldset(intCoreFormsFieldset_Ky, intRow){
	$url="/admin/app/sdk/actions/coreformsfieldset-changeorder.aspx";
	$orderfield="#CoreFormsFieldset_Order" + intRow + "";
	console.log($orderfield);
	$ordine=jQuery($orderfield).val();
	console.log($ordine);
	console.log($url);
	$data= { ajax:true, CoreFormsFieldset_Ky: intCoreFormsFieldset_Ky, CoreFormsFieldset_Order: $ordine, CoreEntities_Ky: <%=Smartdesk.Data.Field(dtCoreForms, "CoreEntities_Ky")%>, CoreModules_Ky:<%=Smartdesk.Data.Field(dtCoreModules, "CoreModules_Ky")%> };
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

function saveTabCoreFormsFieldset(selectObject, intCoreFormsFieldset_Ky){
	$url="/admin/app/sdk/actions/coreformsfieldset-changetab.aspx";
	$value=selectObject.value;
	console.log($value);
	console.log($url);
	$data= { ajax:true, CoreFormsFieldset_Ky: intCoreFormsFieldset_Ky, CoreFormsTabs_Ky: $value, CoreEntities_Ky: <%=Smartdesk.Data.Field(dtCoreForms, "CoreEntities_Ky")%>, CoreModules_Ky:<%=Smartdesk.Data.Field(dtCoreModules, "CoreModules_Ky")%> };
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

