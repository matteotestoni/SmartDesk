<% if (dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(true) && strAzione!="new"){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<br>
		<div class="card">
		  <div class="card-divider">
      	<h2>Assenze anno <%=intYear%> (<%=dtAssenze.Rows.Count%>)</h2>
				<div class="button-group tiny">
          <a href="/admin/form.aspx?CoreModules_Ky=22&CoreEntities_Ky=39&CoreForms_Ky=106&azione=new&Persone_Ky=<%=GetFieldValue(dtPersone, "Persone_Ky")%>" class="tiny button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>Aggiungi assenza</a>
        </div>
      </div>
	  	<div class="card-section">
          <%  if (dtAssenze.Rows.Count>0){
	              decTotAssenze=0;
	              decTotPianificate=0;
	              decTotRecuperi=0;
					%>
              <table class="grid hover scroll" border="0" width="100%">
                  <thead>
                      <tr>
                          <th width="110" class="text-center date">Data</th>
                          <th width="80" class="text-center">Giorno</th>
                          <th width="100">Settimana</th>
                          <th width="130" class="text-center">Anno<br>di compentenza</th>
                          <th width="350" align="left">Descrizione</th>
                          <th width="40">Ore</th>
                          <th width="110">Progressivo ore</th>
                          <th width="40">Tipo</th>
                          <th width="90">GG Trascorsi</th>
                          <th width="12" class="nowrap"></th>
                      </tr>
                  </thead>
                  <tbody>
                          <% for (int i = 0; i < dtAssenze.Rows.Count; i++){ %>
                              <tr class="riga<%=i%2%>">
                                  <td>
                                      <i class="fa-duotone fa-calendar-days fa-fw"></i>
                                      <a href="/admin/form.aspx?CoreModules_Ky=22&CoreEntities_Ky=39&CoreForms_Ky=106&PersoneAssenze_Ky=<%=dtAssenze.Rows[i]["PersoneAssenze_Ky"].ToString()%>">
                                          <%=dtAssenze.Rows[i]["PersoneAssenze_Data_IT"].ToString()%>
                                      </a>
                                  </td>
                                  <td class="large-text-center small-text-left">
                                      <%=Smartdesk.Functions.GetGiorno(dtAssenze.Rows[i]["PersoneAssenze_Data"].ToString())%>
                                  </td>
                                  <td class="large-text-center small-text-left">
                                      <%=Smartdesk.Functions.GetSettimana(dtAssenze.Rows[i]["PersoneAssenze_Data"].ToString())%>
                                  </td>
                                  <td class="large-text-center small-text-left">
                                      <%=dtAssenze.Rows[i]["PersoneAssenze_Anno"].ToString()%>
                                  </td>
                                  <td>
                                      <%=dtAssenze.Rows[i]["PersoneAssenze_Descrizione"].ToString()%>
                                  </td>
                                  <td class="large-text-center small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=dtAssenze.Rows[i]["PersoneAssenzeTipo_Segno"].ToString()%><%=dtAssenze.Rows[i]["PersoneAssenze_Ore"].ToString()%></strong></td>
                                  <td class="large-text-center small-text-left">
                                      <%=getOre(decTotProgressivo)%>
                                  </td>
                                  <td class="large-text-center small-text-left"><strong><%=dtAssenze.Rows[i]["PersoneAssenzeTipo_Descrizione"].ToString()%></strong></td>
                                  <td class="large-text-center small-text-left"><strong><%=dtAssenze.Rows[i]["ggTrascorsi"].ToString()%></strong></td>
                                  <td><a href="/admin/app/persone/crud/elimina-personeassenze.aspx?PersoneAssenze_Ky=<%=dtAssenze.Rows[i]["PersoneAssenze_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
                              </tr>
                                <%
											        switch (Convert.ToInt32(dtAssenze.Rows[i]["PersoneAssenzeTipo_Ky"])){
																case 1:
																	decTotAssenze+=Convert.ToDecimal(dtAssenze.Rows[i]["PersoneAssenze_Ore"]);
											  					decTotProgressivo+=Convert.ToDecimal(dtAssenze.Rows[i]["PersoneAssenze_Ore"]);
																	break;
																case 2:
																	decTotRecuperi+=Convert.ToDecimal(dtAssenze.Rows[i]["PersoneAssenze_Ore"]);
																	decTotAssenze-=Convert.ToDecimal(dtAssenze.Rows[i]["PersoneAssenze_Ore"]);
											  					decTotProgressivo-=Convert.ToDecimal(dtAssenze.Rows[i]["PersoneAssenze_Ore"]);
																	break;
															}
												      intPersone_Ky=Convert.ToInt32(dtAssenze.Rows[i]["Persone_Ky"].ToString());				
														} %>
                        </tbody>
                        <tfoot>
                            <tr class="totale">
                                <td colspan="5" class="text-right">Totale assenze</td>
                                <td class="large-text-right small-text-left"><strong><%=decTotAssenze.ToString("N2", ci)%></strong></td>
                                <td colspan="4"></td>
                            </tr>
                            <tr class="totale">
                                <td colspan="5" class="text-right" ">Totale assenze pianificate</td>
											          <td class="text-right "><strong><%=decTotPianificate.ToString("N2 ", ci)%></strong></td>
											          <td colspan="4"></td>
											        </tr>
															<tr class="totale ">
											          <td colspan="5 " class="text-right ">Totale recuperi</td>
											          <td class="text-right "><strong><%=decTotRecuperi.ToString("N2 ", ci)%></strong></td>
											          <td colspan="4"></td>
											        </tr>
														</tfoot>
										</table>
  
					<% }else{
					  Response.Write("<div class=\"grid-x grid-padding-x\"><div class=\"small-12 large-12 medium-12 cell\"><span class=\"messaggio\"><i class=\"fa-duotone fa-circle-info fa-fw\"></i>Nessun dato</span></div></div>");
						} 
					%>

	
	</div>
  </div>
  </div>
</div>
<% } %>
