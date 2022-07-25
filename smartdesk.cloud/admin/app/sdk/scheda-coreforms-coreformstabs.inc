<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="CoreFormsTabs"></a>
	    		<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Tabs del form (<%=dtCoreFormsTabs.Rows.Count%>)</h2>
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
        <%for (int i = 0; i < dtCoreFormsTabs.Rows.Count; i++){ %>
            <tr>
  		        <td><input type="checkbox" class="checkrow" id="record<%=dtCoreFormsTabs.Rows[i]["CoreFormsTabs_Ky"].ToString()%>" data-value="<%=dtCoreFormsTabs.Rows[i]["CoreFormsTabs_Ky"].ToString()%>" /></td>
              <td class="large-text-center small-text-left"><a href="/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=194&CoreForms_Ky=93&CoreFormsTabs_Ky=<%=dtCoreFormsTabs.Rows[i]["CoreFormsTabs_Ky"].ToString()%>&sorgente=scheda-coreforms"><%=dtCoreFormsTabs.Rows[i]["CoreFormsTabs_Ky"].ToString()%></a></td>
              <td><a href="/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=194&CoreForms_Ky=93&CoreFormsTabs_Ky=<%=dtCoreFormsTabs.Rows[i]["CoreFormsTabs_Ky"].ToString()%>&sorgente=scheda-coreforms"><%=dtCoreFormsTabs.Rows[i]["CoreFormsTabs_Title"].ToString()%></a></td>
              <td><i class="<%=dtCoreFormsTabs.Rows[i]["CoreFormsTabs_Icon"].ToString()%> fa-fw"></i></td>
              <td><%=dtCoreFormsTabs.Rows[i]["CoreFormsTabs_Order"].ToString()%></td>
              <td class="text-center nowrap"><a href="/admin/app/sdk/crud/elimina-CoreFormsTabs.aspx?azione=delete&CoreModules_Ky=26&CoreEntities_Ky=194&CoreFormsTabs_Ky=<%=dtCoreFormsTabs.Rows[i]["CoreFormsTabs_Ky"].ToString()%>&CoreForms_Ky=93&sorgente=scheda-coreforms" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
            </tr>
        <% } %>
	   		</tbody>
			  <% if (dtCoreFormsTabs.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
      <% if (strAzione!="new"){ %>
      <fieldset class="fieldset">
        <legend><i class="fa-duotone fa-square-plus fa-fw"></i>New tab</legend>
        <form id="form-CoreFormsTabs" action="/admin/app/sdk/crud/salva-CoreFormsTabs.aspx" enctype="multipart/form-data" method="post" data-abide novalidate>
          <input type="hidden" name="azione" id="azione" value="new">
          <input type="hidden" name="sorgente" id="sorgente" value="scheda-coreforms">
          <input type="hidden" name="CoreFormsTabs_Ky" id="CoreFormsTabs_Ky" value="">
          <input type="hidden" name="CoreForms_Ky" id="CoreForms_Ky" value="<%=strCoreForms_Ky%>">
          <div class="grid-x grid-padding-x">
            <div class="small-12 medium-3 large-3 cell">
              <input type="text" name="CoreFormsTabs_Title" id="CoreFormsTabs_Title" value="" placeholder="Title">
            </div>
            <div class="small-12 medium-3 large-3 cell">
              <input type="text" name="CoreFormsTabs_Icon" id="CoreFormsTabs_Icon" value="" placeholder="Icon">
            </div>
             <div class="small-12 medium-3 large-3 cell">
             <input type="number" name="CoreFormsTabs_Order" id="CoreFormsTabs_Order" value="" placeholder="Order">
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
