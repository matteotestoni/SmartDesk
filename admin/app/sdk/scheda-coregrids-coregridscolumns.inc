<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="CoreEntities"></a>
	    		<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Colonne (<%=dtCoreGridsColumns.Rows.Count%>)</h2>
					<div class="button-group tiny">
						<a href="/admin/app/sdk/scheda-coregrids-addcolumns.aspx?azione=new&CoreEntities_Ky=<%=Smartdesk.Data.Field(dtCoreGrids, "CoreEntities_Ky")%>&CoreModules_Ky=<%=Smartdesk.Data.Field(dtCoreModules, "CoreModules_Ky")%>&CoreGrids_Ky=<%=Smartdesk.Data.Field(dtCoreGrids, "CoreGrids_Ky")%>&sorgente=scheda-coregrids" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>Gestisci colonne</a>
						<a href="/admin/app/sdk/scheda-coregrids-ordercolumns.aspx?azione=new&CoreEntities_Ky=<%=Smartdesk.Data.Field(dtCoreGrids, "CoreEntities_Ky")%>&CoreModules_Ky=<%=Smartdesk.Data.Field(dtCoreModules, "CoreModules_Ky")%>&CoreGrids_Ky=<%=Smartdesk.Data.Field(dtCoreGrids, "CoreGrids_Ky")%>&sorgente=scheda-coregrids" class="tiny button secondary"><i class="fa-duotone fa-sort-alpha-down fa-fw"></i>Ordine colonne</a>
			  	</div>
		  </div>
		  <div class="card-section">
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
	        <tr>
	          <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	          <th width="30" class="text-center">Id</th>
	          <th width="200" class="text-left">Codice</th>
	          <th width="200" class="text-left">Titolo attributo</th>
	          <th width="40" class="text-left">Link</th>
	          <th width="200" class="text-left">Etichetta griglia</th>
	          <th width="30" class="text-left">Larghezza</th>
	          <th width="30" class="text-left">Ordine</th>
						<th width="50" class="text-center nowrap" data-orderable="false"></th>
	        </tr>
	      </thead>
	   		<tbody>
        <%for (int i = 0; i < dtCoreGridsColumns.Rows.Count; i++){ %>
            <tr>
  		        <td><input type="checkbox" class="checkrow" id="record<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Ky"].ToString()%>" data-value="<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Ky"].ToString()%>" /></td>
              <td class="large-text-center small-text-left"><a href="/admin/app/sdk/scheda-coregridscolumns.aspx?CoreGridsColumns_Ky=<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Ky"].ToString()%>&CoreGrids_Ky=<%=dtCoreGridsColumns.Rows[i]["CoreGrids_Ky"].ToString()%>&CoreModules_Ky=<%=dtCoreGridsColumns.Rows[i]["CoreModules_Ky"].ToString()%>&sorgente=scheda-coregrids"><%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Ky"].ToString()%></a></td>
              <td><a href="/admin/app/sdk/scheda-coregridscolumns.aspx?CoreGridsColumns_Ky=<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Ky"].ToString()%>&CoreGrids_Ky=<%=dtCoreGridsColumns.Rows[i]["CoreGrids_Ky"].ToString()%>&CoreModules_Ky=<%=dtCoreGridsColumns.Rows[i]["CoreModules_Ky"].ToString()%>&sorgente=scheda-coregrids"><%=dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString()%></a></td>
              <td><%=dtCoreGridsColumns.Rows[i]["CoreAttributes_Title"].ToString()%></td>
		          <td class="large-text-center small-text-left">
								
                <% if (dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Link"].Equals(true)){ %>
									<a href="/admin/app/sdk/actions/coregridscolumns-changelink.aspx?CoreGridsColumns_Ky=<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Ky"].ToString()%>&CoreGrids_Ky=<%=Smartdesk.Data.Field(dtCoreGrids, "CoreGrids_Ky")%>&CoreGridsColumns_Link=0" name="CoreGridsColumns_Link<%=i%>" id="CoreGridsColumns_Link<%=i%>" onclick="saveLabel(<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Ky"].ToString()%>, <%=i%>)"><i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i></a>
								<% }else{ %>
									<a href="/admin/app/sdk/actions/coregridscolumns-changelink.aspx?CoreGridsColumns_Ky=<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Ky"].ToString()%>&CoreGrids_Ky=<%=Smartdesk.Data.Field(dtCoreGrids, "CoreGrids_Ky")%>&CoreGridsColumns_Link=1" name="CoreGridsColumns_Link<%=i%>" id="CoreGridsColumns_Link<%=i%>" onclick="saveLabel(<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Ky"].ToString()%>, <%=i%>)"><i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i></a>
								<% } %>
                
							</td>
              <td>
        				<div class="input-group">
        					<input class="input-group-field" type="text" name="CoreGridsColumns_Label<%=i%>" id="CoreGridsColumns_Label<%=i%>" style="width:30px" size="2" value="<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Label"].ToString()%>" onchange="saveLabel(<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Ky"].ToString()%>, <%=i%>)">
        					<div class="input-group-button">
        						<button class="tiny button secondary hide" onclick="saveLabel(<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Ky"].ToString()%>, <%=i%>)"><i class="fa-duotone fa-floppy-disk fa-fw"></i></button>
        					</div>
        				</div>              
              </td>
              <td>
        				<div class="input-group">
        					<input class="input-group-field" type="number" name="CoreGridsColumns_Width<%=i%>" id="CoreGridsColumns_Width<%=i%>" style="width:30px" size="2" value="<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Width"].ToString()%>" onchange="saveWidth(<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Ky"].ToString()%>, <%=i%>)">
        					<div class="input-group-button">
        						<button class="tiny button secondary hide" onclick="saveWidth(<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Ky"].ToString()%>, <%=i%>)"><i class="fa-duotone fa-floppy-disk fa-fw"></i></button>
        					</div>
        				</div>              
              </td>
              <td>
        				<div class="input-group">
        					<input class="input-group-field" type="number" name="CoreGridsColumns_Order<%=i%>" id="CoreGridsColumns_Order<%=i%>" style="width:30px" size="2" value="<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Order"].ToString()%>" onchange="saveOrder(<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Ky"].ToString()%>, <%=i%>)">
        					<div class="input-group-button">
        						<button class="tiny button secondary hide" onclick="saveOrder(<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Ky"].ToString()%>, <%=i%>)"><i class="fa-duotone fa-floppy-disk fa-fw"></i></button>
        					</div>
        				</div>
              </td>
              <td class="text-center nowrap"><a href="/admin/app/sdk/crud/elimina-coregridscolumns.aspx?azione=delete&CoreModules_Ky=<%=dtCoreGridsColumns.Rows[i]["CoreModules_Ky"].ToString()%>&CoreGridsColumns_Ky=<%=dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Ky"].ToString()%>&CoreGrids_Ky=<%=dtCoreGridsColumns.Rows[i]["CoreGrids_Ky"].ToString()%>&sorgente=scheda-coregrids" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
            </tr>
        <% } %>
	   		</tbody>
			  <% if (dtCoreGridsColumns.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
		  </div>
		</div>
  </div>
</div>
<script>
  function saveOrder(intCoreGridsColumns_Ky, intRow){
  	$url="/admin/app/sdk/actions/coregridscolumns-changeorder.aspx";
  	$field="#CoreGridsColumns_Order" + intRow + "";
  	$ordine=jQuery($field).val();
  	$data= { ajax:true, CoreGridsColumns_Ky: intCoreGridsColumns_Ky, CoreGridsColumns_Order: $ordine };
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

  function saveWidth(intCoreGridsColumns_Ky, intRow){
  	$url="/admin/app/sdk/actions/coregridscolumns-changewidth.aspx";
  	$field="#CoreGridsColumns_Width" + intRow + "";
  	$ordine=jQuery($field).val();
  	$data= { ajax:true, CoreGridsColumns_Ky: intCoreGridsColumns_Ky, CoreGridsColumns_Width: $ordine };
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

  function saveLabel(intCoreGridsColumns_Ky, intRow){
  	$url="/admin/app/sdk/actions/coregridscolumns-changelabel.aspx";
  	$field="#CoreGridsColumns_Label" + intRow + "";
  	$ordine=jQuery($field).val();
  	$data= { ajax:true, CoreGridsColumns_Ky: intCoreGridsColumns_Ky, CoreGridsColumns_Label: $ordine };
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

  function saveLink(intCoreGridsColumns_Ky, intRow){
  	$url="/admin/app/sdk/actions/coregridscolumns-changelink.aspx";
  	$field="#CoreGridsColumns_Link" + intRow + "";
  	$ordine=jQuery($field).val();
  	$data= { ajax:true, CoreGridsColumns_Ky: intCoreGridsColumns_Ky, CoreGridsColumns_Link: $ordine };
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
</script>
