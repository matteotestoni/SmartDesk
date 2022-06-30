<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Commerciale"].Equals(true) && dtLogin.Rows[0]["UtentiGruppi_PreventiviAuto"].Equals(true)){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
  	<a name="documenti"></a>
		<div class="divgrid" id="divgrid">
		  <h2><i class="fa-duotone fa-file fa-lg fa-fw" style="--fa-primary-color:red;--fa-primary-opacity: 1.0"></i> Preventivi (<%=dtPreventiviAuto.Rows.Count%>)</h2> 
          <div class="button-group tiny">
            <a href="/admin/app/automotive/scheda-PreventiviAuto.aspx?custom=1&CoreModules_Ky=35&CoreEntities_Ky=249&CoreGrids_Ky=270&CoreForms_Ky=196&azione=new&Opportunita_Ky=<%=Smartdesk.Data.Field(dtOpportunita, "Opportunita_Ky")%>&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtOpportunita, "Anagrafiche_Ky")%>&sorgente=scheda-opportunita" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>Nuovo preventivo auto</a>
          </div>
    
    <% if (dtPreventiviAuto.Rows.Count>0){ %>
			<table class="grid hover scroll" border="0" width="100%">
	    	<thead>
        <tr>
          <th width="40" class="text-left">Cod.</th>
          <th width="40" align="left">Numero</th>
          <th width="120" align="left">Data</th>
          <th width="150" align="left">Marca</th>
          <th width="150" align="left">Modello</th>
          <th width="90" class="text-center">Prezzo</th>
          <th width="90" class="text-center">Sconto</th>
          <th width="40" class="text-center">Voltura</th>
          <th width="40" class="text-center">Immatricolazione</th>
          <th width="130" class="text-center">Assegnato a</th>
          <th width="60" class="text-center nowrap"></th>
        </tr>
	    	</thead>
	    	<tbody>
        <%for (int i = 0; i < dtPreventiviAuto.Rows.Count; i++){ %>
            <tr>
	          <td class="text-left nowrap"><a href="/admin/app/automotive/scheda-PreventiviAuto.aspx?custom=1&CoreModules_Ky=35&CoreEntities_Ky=249&CoreGrids_Ky=270&CoreForms_Ky=196&custom=0&PreventiviAuto_Ky=<%=dtPreventiviAuto.Rows[i]["PreventiviAuto_Ky"].ToString()%>&sorgente=scheda-opportunita"><%=dtPreventiviAuto.Rows[i]["PreventiviAuto_Ky"].ToString()%></a></td>
              <td class="text-left nowrap"><%=dtPreventiviAuto.Rows[i]["PreventiviAuto_Numero"].ToString()%></td>
              <td class="text-left nowrap"><a href="/admin/app/automotive/scheda-PreventiviAuto.aspx?custom=1&CoreModules_Ky=35&CoreEntities_Ky=249&CoreGrids_Ky=270&CoreForms_Ky=196&custom=0&PreventiviAuto_Ky=<%=dtPreventiviAuto.Rows[i]["PreventiviAuto_Ky"].ToString()%>&sorgente=scheda-opportunita"><%=dtPreventiviAuto.Rows[i]["PreventiviAuto_Data"].ToString()%></a></td>
              <td class="text-left nowrap"><div class="width150"><%=dtPreventiviAuto.Rows[i]["PreventiviAuto_Marca"].ToString()%></div></td>
              <td class="text-left nowrap"><div class="width150"><%=dtPreventiviAuto.Rows[i]["PreventiviAuto_Modello"].ToString()%></div></td>
              <td class="large-text-right small-text-left" style="padding-right:5px"><small>&euro; <%=((decimal)dtPreventiviAuto.Rows[i]["PreventiviAuto_Prezzo"]).ToString("N2", ci)%></small></td>
              <td class="large-text-right small-text-left" style="padding-right:5px"><small>&euro; <%=((decimal)dtPreventiviAuto.Rows[i]["PreventiviAuto_Sconto"]).ToString("N2", ci)%></small></td>
              <td class="text-center nowrap">
				<% if (Convert.ToBoolean(dtPreventiviAuto.Rows[i]["PreventiviAuto_Voltura"])==true){ %>
					<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
				<% }else{ %>
					<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
				<% } %>
              </td>
              <td class="text-center nowrap">
				<% if (Convert.ToBoolean(dtPreventiviAuto.Rows[i]["PreventiviAuto_Immatricolazione"])==true){ %>
					<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
				<% }else{ %>
					<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
				<% } %>
              </td>
              <td class="text-left nowrap"><%=dtPreventiviAuto.Rows[i]["Utenti_Nominativo"].ToString()%></td>
              <td class="text-center nowrap">
              	<a href="/admin/app/documenti/crud/elimina-documenti.aspx?azione=delete&Opportunita_Ky=<%=dtPreventiviAuto.Rows[i]["Opportunita_Ky"].ToString()%>&PreventiviAuto_Ky=<%=dtPreventiviAuto.Rows[i]["PreventiviAuto_Ky"].ToString()%>&sorgente=scheda-opportunita" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
			  </td>
            </tr>
        <% } %>
	    	</tbody>
      </table>
    <% }else{
			Response.Write("<div class=\"messaggio\"><i class=\"fa-duotone fa-circle-info fa-fw\"></i>Nessun documento<br><br></div>");
    } %>
    </div>
	</div>
</div>
<% } %>
