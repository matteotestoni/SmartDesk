 <%
	System.Data.DataTable dtOfficina;
	System.Data.DataTable dtLeadxMarca;

  string strCoreGrids_Ky="247";
  string strCoreForms_Ky="166";
	
  string strWHERENet="";
	strWHERENet="Officina_DataAccettazione>=GETDATE()-90";
	string strFROMNet = "Officina_Giornalieri_Vw";
	string strORDERNet = "Officina_DataAccettazione ASC";
	dtOfficina = new System.Data.DataTable("Officina");
	dtOfficina = Smartdesk.Sql.getTablePage(strFROMNet, null, "Officina_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  
  
  if (dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString()=="3"){
    strCoreGrids_Ky="244";
    strCoreForms_Ky="166";
  }else{
    strCoreGrids_Ky="247";
    strCoreForms_Ky="169";
  }
%>
    <div class="divgridcard">
	   	<div id="graficoofficina1" style="width:100%;height:250px;margin: 0 auto;"></div>    
	  </div>
	<script>
		jQuery(function() {
	    var chart;
	    jQuery(document).ready(function() {
	        
          //grafico 1
          chart = new Highcharts.Chart({
	            chart: {
	                renderTo: 'graficoofficina1',
	                type: 'areaspline',
	            },
	            title: {
	                text: 'Andamento officina'
	            },
	            subtitle: {
	                text: 'Ultimi 90 giorni'
	            },
              xAxis: {
                  categories: [
                  <% for (int j = 0; j < dtOfficina.Rows.Count; j++){
  					            	Response.Write("'" + dtOfficina.Rows[j]["Officina_DataAccettazione"].ToString() + "',");
  									 } %>
                  ]
              },
	            yAxis: {
	                min: 0,
	                title: {
	                    text: 'Numero richieste'
	                }
	            },
              plotOptions: {
                      line: {
                          dataLabels: {
                              enabled: true
                          },
                          enableMouseTracking: false
                      }
              },              
              series: [{
                name: '<%=DateTime.Now.Year%>',
                data: [<% for (int j = 0; j < dtOfficina.Rows.Count; j++){
					           Response.Write(dtOfficina.Rows[j]["NumeroOfficina"].ToString() + ",");
							   } %>]},

							]
	        });      
      });
		});
	</script>

	<div class="divgridcard hide">
		<table class="grid hover scroll" border="0" width="100%">
			<thead>
				<tr>
      	<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
				<th width="110" class="text-center date">Data</th>
				<th align="left" width="250">Numero officina</th>
				</tr>
			</thead>
    		<tbody>
        <%
			  for (int j = 0; j < dtOfficina.Rows.Count; j++){
			  %>

		        <tr id="<%=dtOfficina.Rows[j]["Officina_Ky"].ToString()%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtOfficina.Rows[j]["Officina_Ky"].ToString()%>" data-value="<%=dtOfficina.Rows[j]["Officina_Ky"].ToString()%>" /></td>
		          <td><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtOfficina.Rows[j]["Officina_DataAccettazione"].ToString()%></td>
		          <td class="text-left"><%=dtOfficina.Rows[i]["NumeroOfficina"].ToString()%></td>
		        </tr>
		    <%
				}
				%>
    </table>
	</div>

  <div class="grid-x grid-padding-x">
    <div class="large-12 medium-12 small-12 cell">
  			<fieldset class="filtri fieldset hide-for-print" id="filtri" data-toggler=".hide" style="padding:0.25rem">
  					<legend>Cerca officina</legend>
            <div class="grid-x">
              <div class="large-4 medium-4 small-12 cell">
                  <form id="formRicerca1" class="formRicerca" method="get" action="/admin/view.aspx">
        						<input type="hidden" name="CoreModules_Ky" value="33">
        						<input type="hidden" name="CoreEntities_Ky" value="231">
        						<input type="hidden" name="CoreGrids_Ky" value="<%=strCoreGrids_Ky%>">		
                    <div class="input-group">
                      <span class="input-group-label" style="min-width:100px">Nominativo</span>
                      <input class="input-group-field" type="text" name="Officina_Nominativo" id="Officina_Nominativo">
                      <div class="input-group-button">
        						    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
                      </div>
                    </div>
                  </form>
              </div>
              <div class="large-4 medium-4 small-12 cell">
        					<form id="formRicerca2" class="formRicerca" method="get" action="/admin/view.aspx">
        						<input type="hidden" name="CoreModules_Ky" value="33">
        						<input type="hidden" name="CoreEntities_Ky" value="231">
        						<input type="hidden" name="CoreGrids_Ky" value="<%=strCoreGrids_Ky%>">		
                    <div class="input-group">
                      <span class="input-group-label" style="min-width:100px">Targa</span>
                      <input class="input-group-field" type="text" name="Officina_TargaVettura" id="Officina_TargaVettura">
                      <div class="input-group-button">
        						    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
                      </div>
                    </div>
                  </form>
              </div>
              <div class="large-4 medium-4 small-12 cell">
                <ul class="menu horizontal">
                  <li><a href="/admin/view.aspx?CoreModules_Ky=33&CoreEntities_Ky=231&CoreGrids_Ky=<%=strCoreGrids_Ky%>&OfficinaTipoauto_Ky=1">Auto nuove</a></li>
                  <li><a href="/admin/view.aspx?CoreModules_Ky=33&CoreEntities_Ky=231&CoreGrids_Ky=<%=strCoreGrids_Ky%>&OfficinaTipoauto_Ky=2">Auto usate</a></li>
                  <li><a href="/admin/view.aspx?CoreModules_Ky=33&CoreEntities_Ky=231&CoreGrids_Ky=<%=strCoreGrids_Ky%>&OfficinaTipoauto_Ky=3">Auto km 0</a></li>
                </ul>
              </div>
            </div>
    </div>
  </div>
