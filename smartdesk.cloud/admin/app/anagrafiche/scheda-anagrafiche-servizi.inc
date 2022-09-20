<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Servizi"].Equals(true)){ 

System.Data.DataTable dtAttributixServizi = Smartdesk.Sql.getTablePage("Attributi_Vw", null, "Attributi_Ky", "Attributi_Servizi=1", "Attributi_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
string strCodiceAttributo;
string strValoreAttributo;

%>
<div class="grid-container" id="divservizi">
<div class="grid-x grid-padding-x">
	<div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<h2><i class="fa-duotone fa-cube fa-lg fa-fw"></i>Servizi da rinnovare e Fatture da emettere (<%=dtAnagraficheServiziAttivi.Rows.Count%>)</h2>
				<div class="button-group tiny">
					<a href="/admin/app/anagrafiche/scheda-anagraficheservizi.aspx?azione=new&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&sorgente=scheda-anagrafiche" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>nuovo servizio da rinnovare</a>
				</div>
		  </div>
		  <div class="card-section">
    	<ul class="tabs" data-responsive-accordion-tabs="tabs small-accordion medium-tabs large-tabs" role="tablist" id="servizi-tabs">
    		<li class="tabs-title is-active" role="presentational"><a href="#tabservizi-1"><i class="fa-duotone fa-triangle-exclamation fa-lg fa-fw" style="--fa-primary-color:red;--fa-primary-opacity: 1.0"></i> Servizi attivi (<%=dtAnagraficheServiziAttivi.Rows.Count%>)</a></li>
    		<li class="tabs-title" role="presentational"><a href="#tabservizi-2"><i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i> Servizi chiusi (<%=dtAnagraficheServiziChiusi.Rows.Count%>)</a></li>
    	</ul>
	  	<div class="tabs-content" data-tabs-content="servizi-tabs">
			<div class="tabs-panel is-active" id="tabservizi-1">
					<table class="grid hover scroll" border="0" width="100%">
			    	<thead>
		        <tr>
    		      <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
					    <th align="left" width="30">Cod</th>
		          <th width="450">Servizio</th>
							<th width="100" class="text-right">Prezzo &euro;</th>
					    <th class="text-center" width="5"></th>
		          <th width="30">Qt&agrave;</th>
					    <th class="text-center" width="5"></th>
							<th width="100">Importo &euro;</th>
							<th width="120" class="text-center">Valido dal al</th>
							<th width="120" class="text-center">Scadenza</th>
							<th width="80" class="text-center nowrap" data-orderable="false"></th>
		        </tr>
			    	</thead>
			   		<tbody>
		        <%
							decTot=0;
							decTotQta=0;
							decTotIVA=0;
							decTotServizi=0;
							for (int i = 0; i < dtAnagraficheServiziAttivi.Rows.Count; i++){ %>
		            <tr>
        		      <td><input type="checkbox" class="checkrow" id="record<%=dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Ky"].ToString()%>" data-value="<%=dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Ky"].ToString()%>" /></td>
						      <td class="text-left nowrap"><a href="/admin/app/anagrafiche/scheda-anagraficheservizi.aspx?AnagraficheServizi_Ky=<%=dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Ky"].ToString()%></a></td>
		              <td>
										<div class="width450">
											<%=dtAnagraficheServiziAttivi.Rows[i]["Servizi_Titolo"].ToString()%><br>
											<small>
												<% if (dtAnagraficheServiziAttivi.Rows[i]["Commesse_Ky"].ToString().Length>0){ %><a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtAnagraficheServiziAttivi.Rows[i]["Commesse_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="progetto"><i class="fa-duotone fa-circle-info fa-fw"></i><%=dtAnagraficheServiziAttivi.Rows[i]["Commesse_Riferimenti"].ToString()%></a><% } %>
											</small>
											<small>
												<%
                                                  if (dtAnagraficheServiziAttivi.Rows[i]["SitiWeb_Dominio"].ToString().Length>0){
                                                    Response.Write("Dominio: " + dtAnagraficheServiziAttivi.Rows[i]["SitiWeb_Dominio"].ToString());
                                                  }
                                                  %>
												&nbsp;<%=dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Descrizione"].ToString()%>
                                                <% for (int j = 0; j < dtAttributixServizi.Rows.Count; j++){
                                                    strCodiceAttributo="attr-" + dtAttributixServizi.Rows[j]["Attributi_Codice"].ToString();
                                                    strValoreAttributo=dtAnagraficheServiziAttivi.Rows[i][strCodiceAttributo].ToString();
                                                    if (strValoreAttributo.Length>0){
                                                        Response.Write("<br>" + dtAttributixServizi.Rows[j]["Attributi_Titolo"].ToString() + ":&nbsp;" + dtAnagraficheServiziAttivi.Rows[i][strCodiceAttributo].ToString());
                                                    }
                                                 } %>
                                                
											</small>
										</div>
									</td>
		              <td class="large-text-right small-text-left" style="line-height:1rem;padding-right:5px">
										&euro; <%=dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Prezzo"].ToString()%><br>
										<small><%=GetTipoRinnovo(dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Rinnovo"].ToString())%></small>
									</td>
		              <td class="large-text-center small-text-left">x</td>
		              <td class="text-center" style="padding-right:5px"><%=dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Qta"].ToString()%></td>
		              <td class="large-text-center small-text-left">=</td>
		              <td class="large-text-right small-text-left" style="padding-right:5px"><strong>&euro; <%=dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Importo"].ToString()%></strong></td>
		              <td class="large-text-center small-text-left">
										<i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Inizio_IT"].ToString()%>
									</td>
		              <td class="large-text-center small-text-left">
										<i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Scadenza_IT"].ToString()%></strong><br>
										<%
										if (DateTime.Now<=Convert.ToDateTime(dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Scadenza"])){
											Response.Write("<span class=\"label success\">Servizio attivo</span>");
										}else{
											Response.Write("<span class=\"label alert animate__animated animate__headShake animate__infinite infinite\">Servizio NON attivo</span>");
										}
										%>
									</td>
		              <td class="text-center nowrap">
										<a href="/admin/app/amministrazione/servizio-chiuso.aspx?Anagrafiche_Ky=<%=dtAnagraficheServiziAttivi.Rows[i]["Anagrafiche_Ky"].ToString()%>&AnagraficheServizi_Ky=<%=dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="Chiudi servizi"><i class="fa-duotone fa-lock fa-fw"></i></a>
		              	<a href="/admin/app/amministrazione/servizio-fatturato.aspx?Anagrafiche_Ky=<%=dtAnagraficheServiziAttivi.Rows[i]["Anagrafiche_Ky"].ToString()%>&AnagraficheServizi_Ky=<%=dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="Segna come fattura emessa"><i class="fa-duotone fa-check fa-fw"></i></a>
		              	<a href="/admin/app/amministrazione/servizio-non-fatturato.aspx?Anagrafiche_Ky=<%=dtAnagraficheServiziAttivi.Rows[i]["Anagrafiche_Ky"].ToString()%>&AnagraficheServizi_Ky=<%=dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="fattura non emessa"><i class="fa-duotone fa-undo fa-fw"></i></a>
									</td>
		            </tr>
		        <%
							decTotQta+=Convert.ToDecimal(dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Qta"]);
							decTot+=Convert.ToDecimal(dtAnagraficheServiziAttivi.Rows[i]["AnagraficheServizi_Importo"]);
						} %>
			   		</tbody>
					  <% if (dtAnagraficheServiziAttivi.Rows.Count<1){
					      	Response.Write("<tfoot><tr><td colspan=\"12\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
						} %> 
					  <% if (dtAnagraficheServiziAttivi.Rows.Count>0){ %>
			    	<tfoot>
				      <tr class="totale">
				        <td bgcolor="#ffffff" colspan="3"></td>
				        <td class="large-text-right small-text-left" colspan="2">Totali</td>
				        <td class="text-center" style="padding-right:5px"><%=decTotQta.ToString("N0", ci)%></td>
				        <td class="large-text-right small-text-left" style="padding-right:5px" colspan="2">&euro; <%=decTot.ToString("N2", ci)%></td>
				        <td colspan="3" bgcolor="#ffffff" ></td>
				      </tr>
			    	</tfoot>
						<% } %> 
		      </table>
			</div>
	  	<div class="tabs-panel" id="tabservizi-2">
					<table class="grid hover scroll" border="0" width="100%">
			    	<thead>
		        <tr>
    		      <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
					    <th width="40" class="text-left">Cod.</th>
		          <th width="400">Servizio</th>
							<th width="100">Prezzo &euro;</th>
					    <th class="text-center" width="5"></th>
		          <th width="30">Qt&agrave;</th>
					    <th class="text-center" width="5"></th>
							<th width="100">Importo &euro;</th>
							<th class="text-center" width="120">Valido</th>
							<th class="text-center" width="120">Data chisura</th>
							<th width="80"></th>
		        </tr>
			    	</thead>
			   		<tbody>
		        <%
							decTot=0;
		        	decTotQta=0;
							for (int i = 0; i < dtAnagraficheServiziChiusi.Rows.Count; i++){ %>
		            <tr>
        		      <td><input type="checkbox" class="checkrow" id="record<%=dtAnagraficheServiziChiusi.Rows[i]["AnagraficheServizi_Ky"].ToString()%>" data-value="<%=dtAnagraficheServiziChiusi.Rows[i]["AnagraficheServizi_Ky"].ToString()%>" /></td>
						      <td class="text-left nowrap"><a href="/admin/app/anagrafiche/scheda-anagraficheservizi.aspx?AnagraficheServizi_Ky=<%=dtAnagraficheServiziChiusi.Rows[i]["AnagraficheServizi_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtAnagraficheServiziChiusi.Rows[i]["AnagraficheServizi_Ky"].ToString()%></a></td>
		              <td>
										<div class="width400"><%=dtAnagraficheServiziChiusi.Rows[i]["Servizi_Titolo"].ToString()%></div>
										<small>
											<% if (dtAnagraficheServiziChiusi.Rows[i]["Commesse_Ky"].ToString().Length>0){ %><a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtAnagraficheServiziChiusi.Rows[i]["Commesse_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="progetto"><i class="fa-duotone fa-circle-info fa-fw"></i><%=dtAnagraficheServiziChiusi.Rows[i]["Commesse_Riferimenti"].ToString()%></a><% } %>
										</small>
										<small>
											Dominio: <%=dtAnagraficheServiziChiusi.Rows[i]["SitiWeb_Dominio"].ToString()%> - 
											<%=dtAnagraficheServiziChiusi.Rows[i]["AnagraficheServizi_Descrizione"].ToString()%>
										</small>
									</td>
		              <td class="large-text-right small-text-left" style="line-height:1rem;padding-right:5px">
										<strong>&euro; <%=dtAnagraficheServiziChiusi.Rows[i]["AnagraficheServizi_Prezzo"].ToString()%></strong><br>
										<small><%=GetTipoRinnovo(dtAnagraficheServiziChiusi.Rows[i]["AnagraficheServizi_Rinnovo"].ToString())%></small>
									</td>
		              <td class="large-text-center small-text-left">x</td>
		              <td class="text-center" style="padding-right:5px"><%=dtAnagraficheServiziChiusi.Rows[i]["AnagraficheServizi_Qta"].ToString()%></td>
		              <td class="large-text-center small-text-left">=</td>
		              <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=dtAnagraficheServiziChiusi.Rows[i]["AnagraficheServizi_Importo"].ToString()%></td>
		              <td class="large-text-center small-text-left">
										<i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAnagraficheServiziChiusi.Rows[i]["AnagraficheServizi_Inizio_IT"].ToString()%><br>
										<i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAnagraficheServiziChiusi.Rows[i]["AnagraficheServizi_Scadenza_IT"].ToString()%>
									</td>
		              <td class="large-text-center small-text-left">
										<i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtAnagraficheServiziChiusi.Rows[i]["AnagraficheServizi_DataChiusura_IT"].ToString()%></strong>
									</td>
		              <td class="large-text-center small-text-left"><a href="/admin/app/catalogo/crud/elimina-servizio.aspx?azione=delete&Anagrafiche_Ky=<%=dtAnagraficheServiziChiusi.Rows[i]["Anagrafiche_Ky"].ToString()%>&AnagraficheServizi_Ky=<%=dtAnagraficheServiziChiusi.Rows[i]["AnagraficheServizi_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
		            </tr>
		        <%
							decTotQta+=Convert.ToDecimal(dtAnagraficheServiziChiusi.Rows[i]["AnagraficheServizi_Qta"]);
							decTot+=Convert.ToDecimal(dtAnagraficheServiziChiusi.Rows[i]["AnagraficheServizi_Importo"]);
						} %>
			   		</tbody>
					  <% if (dtAnagraficheServiziChiusi.Rows.Count<1){
					      	Response.Write("<tfoot><tr><td colspan=\"15\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
						} %> 
					  <% if (dtAnagraficheServiziChiusi.Rows.Count>0){ %>
			    	<tfoot>
				      <tr class="totale">
				        <td class="large-text-right small-text-left" colspan="5">Totali</td>
				        <td class="text-center" style="padding-right:5px"><%=decTotQta.ToString("N0", ci)%></td>
				        <td class="text-right" style="padding-right:5px" colspan="2">&euro; <%=decTot.ToString("N2", ci)%></td>
				        <td colspan="3" bgcolor="#ffffff"></td>
				      </tr>
			    	</tfoot>
						<% } %> 
		      </table>
		  	</div>
			</div>
  		</div>
  	</div>
  </div>
</div>
</div>    
<% } %>

