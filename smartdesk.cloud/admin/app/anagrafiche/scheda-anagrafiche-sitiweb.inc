<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_SitiWeb"].Equals(true)){ %>
<div class="grid-container">
 	 <div class="grid-x grid-padding-x">
  		<div class="small-12 large-12 medium-12 cell">
				<div class="card">
				  <div class="card-divider">
		    		<a name="SitiWeb"></a>
						<h2><i class="fa-duotone fa-globe fa-lg fa-fw"></i>Siti Web gestiti (<%=dtSitiWeb.Rows.Count%>)</h2>
							<div class="button-group tiny">
				   			<% if (dtSitiWeb!=null && dtSitiWeb.Rows.Count>0){ %>
								<a href="/admin/app/sitiweb/sitiweb-pagespeed.aspx?Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button secondary"><i class="fa-duotone fa-sync fa-fw"></i>Rileva pagespeed</a>
					      <a href="/admin/app/sitiweb/sitiweb-generator.aspx?Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button secondary"><i class="fa-duotone fa-sync fa-fw"></i>Rileva generator</a>
					      <a href="/admin/app/sitiweb/sitiweb-ip.aspx?Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button secondary"><i class="fa-duotone fa-sync fa-fw"></i>Rileva IP</a>
								<% } %>
								<a href="/admin/app/sitiweb/scheda-sitiweb.aspx?azione=new&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>nuovo sito web</a>
					  	</div>
				  </div>
				  <div class="card-section">
		      <table class="grid hover scroll" border="0" width="100%">
			    	<thead>
		        <tr>
	        		<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
		          <th width="40" class="text-left">Cod.</th>
		          <th width="350" class="text-left">Dominio</th>
							<th width="100" class="text-left">Tipo</th>
							<th width="80" class="text-center">Provider</th>
							<th width="60" class="text-center">IP</th>
							<th width="100" class="text-left">Versione</th>
							<th width="70" class="text-center">PageSpeed</th>
							<th width="40" class="text-center">SEO</th>
							<th width="50" class="text-center nowrap" data-orderable="false"></th>
		        </tr>
			    	</thead>
			    	<tbody>
		        <%for (int i = 0; i < dtSitiWeb.Rows.Count; i++){ %>
		            <tr>
		          		<td><input type="checkbox" class="checkrow" id="record<%=dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString()%>" data-value="<%=dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString()%>" /></td>
		              <td class="text-left"><a href="/admin/app/sitiweb/scheda-SitiWeb.aspx?SitiWeb_Ky=<%=dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtSitiWeb.Rows[i]["Anagrafiche_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString()%></a></td>
		              <td class="text-left">
										<a href="<%=dtSitiWeb.Rows[i]["SitiWeb_Url"].ToString()%>" target="_blank"><i class="fa-duotone fa-up-right-from-square fa-fw"></i></a>
										<a href="/admin/app/sitiweb/scheda-SitiWeb.aspx?SitiWeb_Ky=<%=dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtSitiWeb.Rows[i]["Anagrafiche_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtSitiWeb.Rows[i]["SitiWeb_Dominio"].ToString()%></a>
									</td>
		              <td class="text-left">
		              <i class="<%=dtSitiWeb.Rows[i]["SitiWebTipo_Icona"].ToString()%> fa-lg fa-fw"></i>
									<%=dtSitiWeb.Rows[i]["SitiWebTipo_Titolo"].ToString()%></td>
			          	<td class="large-text-center small-text-left">
		              <%=dtSitiWeb.Rows[i]["Providers_Descrizione"].ToString()%></td>
		              <td class="large-text-center small-text-left"><%=dtSitiWeb.Rows[i]["SitiWeb_IP"].ToString()%></td>
		              <td class="text-left"><%=dtSitiWeb.Rows[i]["SitiWeb_Versione"].ToString()%></td>
		              <td class="large-text-center small-text-left"><i class="fa-duotone fa-chart-waterfall fa-fw"></i><%=Smartdesk.Functions.GetValorePageSpeed(dtSitiWeb.Rows[i]["SitiWeb_PageSpeedScore"].ToString())%></td>
					  			<td>
											<% if (dtSitiWeb.Rows[i]["SitiWeb_SEO"].Equals(true)){ %>
												<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
											<% }else{ %>
												<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
											<% } %>
									</td>
		              <td class="text-center nowrap">
		                <a href="/admin/app/sitiweb/crud/elimina-sitiweb.aspx?azione=delete&Anagrafiche_Ky=<%=dtSitiWeb.Rows[i]["Anagrafiche_Ky"].ToString()%>&SitiWeb_Ky=<%=dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
		              </td>
		            </tr>
		        <% } %>
			    	</tbody>
					  <% if (dtSitiWeb.Rows.Count<1){
					      	Response.Write("<tfoot><tr><td colspan=\"10\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
						} %> 
		      </table>
		      </div>
		    </div>
		      
		      
		      
		  </div>
		</div>
</div>
<% } %>
