<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Prodotti"].Equals(true)){ %>
<div class="grid-container">
<div class="grid-x grid-padding-x">
	<div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<h2><i class="fa-duotone fa-cube fa-lg fa-fw"></i>Prodotti attivi del cliente (<%=dtAnagraficheProdotti.Rows.Count%>)</h2>
				<div class="button-group tiny">
					<a href="/admin/form.aspx?CoreModules_Ky=1&CoreEntities_Ky=226&CoreForms_Ky=162&azione=new&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>Nuovo prodotto</a>
				</div>
		  </div>
		  <div class="card-section">
					<table class="grid hover scroll" border="0" width="100%">
			    	<thead>
              <tr>
                <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
                <th align="left" width="30">Cod</th>
                <th width="30">Qt&agrave;</th>
                <th width="350">Prodotto</th>
                <th width="80">Acquistato il</th>
                <th width="150">Acquistato da</th>
                <th width="80">Matricola</th>
                <th width="80" class="text-center nowrap" data-orderable="false"></th>
              </tr>
			    	</thead>
			   		<tbody>
		        <%
							for (int i = 0; i < dtAnagraficheProdotti.Rows.Count; i++){ %>
		            <tr>
        		      <td><input type="checkbox" class="checkrow" id="record<%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_Ky"].ToString()%>" data-value="<%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_Ky"].ToString()%>" /></td>
					         <td class="text-left nowrap"><a href="/admin/form.aspx?CoreModules_Ky=1&CoreEntities_Ky=226&CoreForms_Ky=162&AnagraficheProdotti_Ky=<%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_Ky"].ToString()%></a></td>
		              <td class="text-center" style="padding-right:5px"><%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_Qta"].ToString()%></td>
		              <td>
      						<div class="width350"><a href="/admin/form.aspx?CoreModules_Ky=1&CoreEntities_Ky=226&CoreForms_Ky=162&AnagraficheProdotti_Ky=<%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_Titolo"].ToString()%></a></div>
      					  </td>
		              <td><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_DataAcquisto"].ToString()%></td>
		              <td><div class="width150"><%=dtAnagraficheProdotti.Rows[i]["Anagrafiche_RagioneSociale_Rivenditore"].ToString()%> <%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_Rivenditore"].ToString()%></div></td>
		              <td><%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_Matricola"].ToString()%></td>
		              <td class="text-center nowrap">
      					   <a href="/admin/app/anagrafiche/crud/elimina-anagraficheprodotti.aspx?azione=delete&Anagrafiche_Ky=<%=dtAnagraficheProdotti.Rows[i]["Anagrafiche_Ky"].ToString()%>&AnagraficheProdotti_Ky=<%=dtAnagraficheProdotti.Rows[i]["AnagraficheProdotti_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
      				    </td>
		            </tr>
		        <%
						} %>
			   		</tbody>
					  <% if (dtAnagraficheProdotti.Rows.Count<1){
					      	Response.Write("<tfoot><tr><td colspan=\"12\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
						} %> 
		      </table>
  		</div>
  	</div>
  </div>
</div>
</div>    
<% } %>

