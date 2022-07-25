<% if (strAzione!="new"){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
    <table class="grid hover scroll" border="0" width="100%">
    	<thead>
      <tr>
        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
        <th width="30" align="left">Codice</th>
        <th width="150">Nome</th>
        <th width="200">Indirizzo</th>
        <th width="150">Comune</th>
				<th width="100">Povincia</th>
				<th width="40">CAP</th>
				<th width="100">Telefono</th>
				<th width="100">Partita IVA</th>
				<th width="100">Codice Fiscale</th>
				<th width="80">Fatturazione</th>
				<th width="80">Spedizione</th>
				<th width="12" class="nowrap" data-orderable="false"></th>
      </tr>
    	</thead>
    	<tbody>
      <%for (int i = 0; i < dtAnagraficheIndirizzi.Rows.Count; i++){ %>
        <tr>
		      <td><input type="checkbox" class="checkrow" id="record<%=dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_Ky"].ToString()%>" data-value="<%=dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_Ky"].ToString()%>" /></td>
          <td align="left"><a href="/admin/form.aspx?CoreModules_Ky=1&CoreEntities_Ky=26&CoreForms_Ky=107&AnagraficheIndirizzi_Ky=<%=dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAnagraficheIndirizzi.Rows[i]["Anagrafiche_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_Ky"].ToString()%></a></td>
          <td align="left"><a href="/admin/form.aspx?CoreModules_Ky=1&CoreEntities_Ky=26&CoreForms_Ky=107&AnagraficheIndirizzi_Ky=<%=dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAnagraficheIndirizzi.Rows[i]["Anagrafiche_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_Nome"].ToString()%></a></td>
          <td class="text-left"><%=dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_Indirizzo"].ToString()%></td>
          <td class="text-left"><%=dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_Comune"].ToString()%></td>
          <td class="text-left"><%=dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_Provincia"].ToString()%></td>
          <td class="text-left"><%=dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_CAP"].ToString()%></td>
          <td class="text-left"><a href="tel:<%=dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_Telefono"].ToString()%>"><%=dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_Telefono"].ToString()%></a></td>
          <td class="text-left"><%=dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_PartitaIVA"].ToString()%></td>
          <td class="text-left"><%=dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_CodiceFiscale"].ToString()%></td>
          <td class="text-center">
							<% if (dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_DefaultFatturazione"].Equals(true)){ %>
								<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
							<% }else{  %>
								<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
							<% } %>
					</td>
          <td class="text-center">
							<% if (dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_DefaultSpedizione"].Equals(true)){ %>
								<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
							<% }else{  %>
								<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
							<% } %>
					</td>
          <td width="10">
            <a href="/admin/app/anagrafiche/crud/elimina-anagraficheindirizzi.aspx?azione=delete&Anagrafiche_Ky=<%=dtAnagraficheIndirizzi.Rows[i]["Anagrafiche_Ky"].ToString()%>&AnagraficheIndirizzi_Ky=<%=dtAnagraficheIndirizzi.Rows[i]["AnagraficheIndirizzi_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
          </td>
        </tr>
      <% } %>
    	</tbody>
		  <% if (dtAnagraficheIndirizzi.Rows.Count<1){
		      	Response.Write("<tfoot><tr><td colspan=\"13\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
			} %> 
    </table>
	</div>    
</div>
<% } %>
