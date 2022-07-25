<% if (dtLogin.Rows[0]["UtentiGruppi_Vendite"].Equals(true) && strAzione!="new"){ %>
<div class="grid-container">
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="SitiWeb"></a>
	    		<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i>Veicoli in offerta (<%=dtVeicoliOfferteAuto.Rows.Count%>)</h2>
				<div class="button-group tiny">
    				<a href="/admin/form.aspx?CoreModules_Ky=29&CoreEntities_Ky=206&CoreForms_Ky=119&azione=new&VeicoliOfferte_Ky=<%=Smartdesk.Data.Field(dtVeicoliOfferte, "VeicoliOfferte_Ky")%>&sorgente=scheda-veicoliofferte" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i> Nuova auto in offerta</a>
    				<a href="/admin/app/veicoli/scheda-veicoliofferteauto.aspx?azione=new&VeicoliOfferte_Ky=<%=Smartdesk.Data.Field(dtVeicoliOfferte, "VeicoliOfferte_Ky")%>&sorgente=scheda-veicoliofferte" class="tiny button secondary"><i class="fa-duotone fa-file-csv fa-fw"></i> Importa CSV con offerte</a>
    				<a href="/admin/app/veicoli/actions/associa-veicoli-offerta.aspx?VeicoliOfferte_Ky=<%=Smartdesk.Data.Field(dtVeicoliOfferte, "VeicoliOfferte_Ky")%>&sorgente=scheda-veicoliofferte" class="tiny button secondary"><i class="fa-duotone fa-plus fa-fw"></i> Associa tutti veicoli all'offerta</a>
    				<a href="/admin/app/veicoli/actions/dissocia-veicoli-offerta.aspx?VeicoliOfferte_Ky=<%=Smartdesk.Data.Field(dtVeicoliOfferte, "VeicoliOfferte_Ky")%>&sorgente=scheda-veicoliofferte" class="tiny button secondary"><i class="fa-duotone fa-minus fa-fw"></i> Dissocia tutti i veicoli all'offerta</a>
			  	</div>
		  </div>
		  <div class="card-section">
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
	        <tr>
              <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
              <th width="30">Codice</th>
              <th width="120" class="text-left">Targa</th>
              <th width="120" class="text-left">Marca</th>
              <th width="120" class="text-left">Modello</th>
              <th width="120" class="text-left">Immatricolazione</th>
              <th width="350" class="text-left">Allestimento</th>
              <th width="150" class="text-left">Prezzo</th>
              <th width="150" class="text-center">Sconto</th>
              <th width="150" class="text-center">Prezzo in offerta</th>
              <th></th>
	        </tr>
	      </thead>
	   		<tbody>
        <%for (int i = 0; i < dtVeicoliOfferteAuto.Rows.Count; i++){ %>
            <tr>
  		        <td><input type="checkbox" class="checkrow" id="record<%=dtVeicoliOfferteAuto.Rows[i]["VeicoliOfferteAuto_Ky"].ToString()%>" data-value="<%=dtVeicoliOfferteAuto.Rows[i]["VeicoliOfferteAuto_Ky"].ToString()%>" /></td>
                <td class="large-text-center small-text-left"><a href="/admin/form.aspx?CoreModules_Ky=29&CoreEntities_Ky=206&CoreForms_Ky=119&VeicoliOfferteAuto_Ky=<%=dtVeicoliOfferteAuto.Rows[i]["VeicoliOfferteAuto_Ky"].ToString()%>&sorgente=scheda-veicoliofferte"><%=dtVeicoliOfferteAuto.Rows[i]["VeicoliOfferteAuto_Ky"].ToString()%></a></td>
                <td class="text-left"><%=dtVeicoliOfferteAuto.Rows[i]["Veicoli_Targa"].ToString()%></td>
                <td class="text-left"><%=dtVeicoliOfferteAuto.Rows[i]["VeicoliMarca_Titolo"].ToString()%></td>
                <td class="text-left"><%=dtVeicoliOfferteAuto.Rows[i]["VeicoliModello_Titolo"].ToString()%></td>
                <td class="text-left"><%=dtVeicoliOfferteAuto.Rows[i]["Veicoli_DataPrimaImmatricolazione"].ToString()%> <%=dtVeicoliOfferteAuto.Rows[i]["Veicoli_ImmatricolazioneAnno"].ToString()%> </td>
                <td class="text-left"><%=dtVeicoliOfferteAuto.Rows[i]["Veicoli_Allestimento"].ToString()%></td>
                <td class="text-left"><%=dtVeicoliOfferteAuto.Rows[i]["Veicoli_Valore"].ToString()%>&euro;</td>
                <td class="text-center"><%=dtVeicoliOfferteAuto.Rows[i]["Veicoli_Sconto"].ToString()%>&euro;</td>
                <td class="text-center"><%=dtVeicoliOfferteAuto.Rows[i]["Veicoli_ValoreInOfferta"].ToString()%>&euro;</td>
              <td class="text-center nowrap"><a href="/admin/app/veicoli/crud/elimina-veicoliofferteauto.aspx?azione=delete&VeicoliOfferte_Ky=<%=dtVeicoliOfferteAuto.Rows[i]["VeicoliOfferte_Ky"].ToString()%>&VeicoliOfferteAuto_Ky=<%=dtVeicoliOfferteAuto.Rows[i]["VeicoliOfferteAuto_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
            </tr>
        <% } %>
	   		</tbody>
			  <% if (dtVeicoliOfferteAuto.Rows.Count<1){
			      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
				} %> 
      </table>
		  </div>
		</div>
  </div>
</div>
</div>
<% } %>
