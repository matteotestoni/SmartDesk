<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
  <a name="attivita"></a>
	<br>
	<div class="card">
	  <div class="card-divider">
			<h2><i class="fa-duotone fa-calendar-days fa-lg fa-fw"></i>Attivit&agrave;</h2>
		</div>
	  <div class="card-section">
							<table class="grid hover scroll" border="0" width="100%">
					    	<thead>
				        <tr>
                  <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
                  <th width="30" class="text-left">Cod.</th>
                  <th width="300" align="left">Descrizione</th>
									<th width="100" class="text-center">Priorit&agrave;</th>
									<th width="100" class="text-center">Stato</th>
									<th width="70" align="center">Scadenza</th>
									<th width="40" align="center">gg</th>
									<th width="60" align="center">Ore</th>
									<th width="60" align="center">Settore</th>
									<th width="120" align="center">Per chi</th>
									<th width="40" class="text-center nowrap"></th>
				        </tr>
					    	</thead>
					    	<tbody>
				        <%for (int i = 0; i < dtAttivita.Rows.Count; i++){ %>
				            <tr>
                      <td><input type="checkbox" class="checkrow" id="record<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>" data-value="<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>" /></td>
					            <td class="text-left nowrap"><a href="/area-clienti/app/attivita/scheda-attivita.aspx?Attivita_Ky=<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-progetti"><%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%></a></td>
				              <td class="text-left nowrap">
							     <input type="text" id="Attivita_Descrizione<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>" name="Attivita_Descrizione" value="<%=dtAttivita.Rows[i]["Attivita_Descrizione"].ToString()%>" onchange="attivitaAggiorna('Attivita_Descrizione','string',<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>)">
							  </td>
				              <td class="large-text-center small-text-left">
                        <select id="Priorita_Ky<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>" name="Priorita_Ky" style="width:100%" onchange="attivitaAggiorna('Priorita_Ky','string',<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>,<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>)"><option value=""></option><!--#include file="/var/cache/Priorita-options.htm"--></select>
                				<script type="text/javascript">
                					selectSet('Priorita_Ky<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>', '<%=dtAttivita.Rows[i]["Priorita_Ky"].ToString()%>');
                				</script>
                      </td>
				              <td class="large-text-left small-text-left">
                        <select id="AttivitaStati_Ky<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>" name="AttivitaStati_Ky" style="width:100%" required="required" onchange="attivitaAggiorna('AttivitaStati_Ky','int',<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>)"><option value=""></option><!--#include file="/var/cache/AttivitaStati-options.htm"--></select>
                				<script type="text/javascript">
                					selectSet('AttivitaStati_Ky<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>', '<%=dtAttivita.Rows[i]["AttivitaStati_Ky"].ToString()%>');
                				</script>
                      </td>
				              <td class="large-text-left small-text-left">
                        <input type="text" id="Attivita_Scadenza<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>" name="Attivita_Scadenza" value="<%=dtAttivita.Rows[i]["Attivita_Scadenza_IT"].ToString()%>" class="fdatepicker" required="required" onchange="attivitaAggiorna('Attivita_Scadenza','string',<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>)">
                      </td>
		        					<td class="large-text-center small-text-left"><strong><%=Smartdesk.Functions.getGGDaFare(dtAttivita.Rows[i]["ggTrascorsi"].ToString())%></strong></td>
				              <td class="large-text-left small-text-left">
                          <select id="Attivita_OrePreviste<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>" name="Attivita_OrePreviste0" required="required" onchange="attivitaAggiorna('Attivita_OrePreviste','int',<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>)">
                            <option value="" selected="selected"></option>
                            <!--#include file="/var/cache/Ore-options.htm"--> 
                          </select>
                  				<script type="text/javascript">
                  					selectSet('Attivita_OrePreviste<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>', '<%=Convert.ToDecimal(dtAttivita.Rows[i]["Attivita_OrePreviste"]).ToString("N1", cien)%>');
                  				</script>
                    </td>
				              <td class="large-text-left small-text-left">
                          <select id="AttivitaSettore_Ky<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>" name="AttivitaSettore_Ky" onchange="attivitaAggiorna('AttivitaSettore_Ky','int',<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>)">
                            <option value="" selected="selected"></option>
                            <!--#include file="/var/cache/AttivitaSettore-options.htm"--> 
                          </select>
                  				<script type="text/javascript">
                  					selectSet('AttivitaSettore_Ky<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>', '<%=dtAttivita.Rows[i]["AttivitaSettore_Ky"].ToString()%>');
                  				</script>
                      </td>
				              <td class="text-left">
                				<select id="Utenti_Ky<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>" name="Utenti_Ky" value="<%=GetFieldValue(dtAttivita, "Utenti_Ky")%>" required="required" onchange="attivitaAggiorna('Utenti_Ky','int',<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>)">
                          <option value=""></option>
                          <!--#include file="/var/cache/Utenti-options.htm"--> 
                        </select>
                				<script type="text/javascript">
                					selectSet('Utenti_Ky<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>', '<%=dtAttivita.Rows[i]["Utenti_Ky"].ToString()%>');
                				</script>
                      </td>
				              <td class="text-right nowrap">
												<a href="/area-clienti/app/attivita/actions/attivita-completa.aspx?Commesse_Ky=<%=dtAttivita.Rows[i]["Commesse_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAttivita.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivita.Rows[i]["AttivitaSettore_Ky"].ToString()%>&Attivita_Completo=1&sorgente=scheda-progetti" title="completo"><i class="fa-duotone fa-check fa-fw"></i></a>
											</td>
				            </tr>
				        <% } %>
                    <form id="form-attivita" action="/area-clienti/app/attivita/crud/salva-attivita.aspx" method="post" data-abide novalidate>
                    <input type="hidden" name="sorgente" value="scheda-progetti">
                    <input type="hidden" name="azione" value="new">
                    <input type="hidden" name="Attivita_Ky" value="">                
                    <input type="hidden" name="AttivitaTipo_Ky" value="1">                
                    <input type="hidden" name="Commesse_Ky" value="<%=GetFieldValue(dtCommesse, "Commesse_Ky")%>">                
                    <input type="hidden" name="Anagrafiche_Ky" value="<%=GetFieldValue(dtCommesse, "Anagrafiche_Ky")%>">                
                    <input type="hidden" name="Utenti_Ky" value="<%=dtLogin.Rows[0]["Utenti_Ky"].ToString()%>">                
    		            <tr class="newrecord">
                      <td class="text-right"></td>
    			            <td class="text-right nowrap"></td>
    		              <td class="text-left nowrap"><input type="text" id="Attivita_Descrizione" name="Attivita_Descrizione" value="" required="required" style="margin-bottom:0"></td>
    		              <td class="text-left nowrap">
                        <select id="Priorita_Ky0" name="Priorita_Ky" style="margin-bottom:0"><option value=""></option><!--#include file="/var/cache/Priorita-options.htm"--></select>
                				<script type="text/javascript">
                					selectSet('Priorita_Ky0', '2');
                				</script>
                      </td>
    		              <td class="text-left nowrap">
                          <input type="hidden" name="AttivitaStati_Ky" id="AttivitaStati_Ky0" value="1">
                      </td>
    		              <td class="text-left nowrap"><input type="text" id="Attivita_Scadenza0" name="Attivita_Scadenza" value="" class="fdatepicker" required="required" style="margin-bottom:0"></td>
     		              <td class="text-left nowrap"></td>
    		              <td class="text-left nowrap">
                          <select name="Attivita_OrePreviste" id="Attivita_OrePreviste0" value="" required="required" style="margin-bottom:0">
                            <option value="" selected="selected"></option>
                            <!--#include file="/var/cache/Ore-options.htm"--> 
                          </select>
                      </td>
    		              <td class="text-left nowrap">
                          <input type="hidden" name="AttivitaSettore_Ky" id="AttivitaSettore_Ky0" value="1">
                      </td>
    		              <td class="text-left nowrap">
                      </td>
    		              <td class="text-right nowrap">
												<button type="submit"><i class="fa-duotone fa-floppy-disk fa-fw fa-lg"></i></button>
                      </td>
    		            </tr>
                    </form>
					    	</tbody>
				      </table>
		</div>
	</div>
<% } %>
<script>
  function attivitaAggiorna(strFieldName, strFieldType, intAttivita_Ky){
  	$url="/area-clienti/app/progetti/actions/attivita-update.aspx";
  	$field="#" + strFieldName + intAttivita_Ky + "";
  	$value=jQuery($field).val();
  	$data= { ajax:true, fieldname: strFieldName, fieldtype: strFieldType, fieldvalue: $value, Attivita_Ky: intAttivita_Ky };
    console.log($data);
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
