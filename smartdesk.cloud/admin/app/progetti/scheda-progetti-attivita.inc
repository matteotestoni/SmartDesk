<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true) && dtCommesse.Rows[0]["CommesseStato_Ky"].ToString()!="6"){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
  <a name="attivita"></a>
	<br>
	<div class="card">
	  <div class="card-divider">
			<h2><i class="fa-duotone fa-calendar-days fa-lg fa-fw"></i>Attivit&agrave; da fare</h2>
		</div>
	  <div class="card-section">
							<table class="grid hover scroll" border="0" width="100%">
					    	<thead>
				        <tr>
                  <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
                  <th width="30" class="text-left">Cod.</th>
                  <th width="300" align="left">Descrizione</th>
									<th width="120" align="center">Data</th>
									<th width="100" class="text-center">Priorit&agrave;</th>
									<th width="100" class="text-center">Stato</th>
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
					            <td class="text-left nowrap"><a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&Attivita_Ky=<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-progetti"><%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%></a></td>
				              <td class="text-left nowrap">
							     <input type="text" id="Attivita_Descrizione<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>" name="Attivita_Descrizione" value="<%=dtAttivita.Rows[i]["Attivita_Descrizione"].ToString()%>" onchange="attivitaAggiorna('Attivita_Descrizione','string',<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>)">
							  </td>
				              <td class="large-text-left small-text-left">
                        <input type="text" id="Attivita_Scadenza<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>" name="Attivita_Scadenza" value="<%=dtAttivita.Rows[i]["Attivita_Scadenza"].ToString()%>" class="fdatetimepicker" required="required" onchange="attivitaAggiorna('Attivita_Scadenza','string',<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>)">
                      </td>
				              <td class="large-text-center small-text-left">
                        <select id="Priorita_Ky<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>" name="Priorita_Ky" class="select2" style="width:100%" onchange="attivitaAggiorna('Priorita_Ky','string',<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>,<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>)"><option value=""></option><!--#include file="/var/cache/Priorita-options-select2.htm"--></select>
                				<script type="text/javascript">
                					selectSet('Priorita_Ky<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>', '<%=dtAttivita.Rows[i]["Priorita_Ky"].ToString()%>');
                				</script>
                      </td>
				              <td class="large-text-left small-text-left">
                        <select id="AttivitaStati_Ky<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>" name="AttivitaStati_Ky" class="select2" style="width:100%" required="required" onchange="attivitaAggiorna('AttivitaStati_Ky','int',<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>)"><option value=""></option><!--#include file="/var/cache/AttivitaStati-options-select2.htm"--></select>
                				<script type="text/javascript">
                					selectSet('AttivitaStati_Ky<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>', '<%=dtAttivita.Rows[i]["AttivitaStati_Ky"].ToString()%>');
                				</script>
                      </td>
		        					<td class="large-text-center small-text-left"><strong><%=Smartdesk.Functions.getGGDaFare(dtAttivita.Rows[i]["ggTrascorsi"].ToString())%></strong></td>
				              <td class="large-text-left small-text-left">
                          <select id="Attivita_Ore<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>" name="Attivita_Ore0" required="required" onchange="attivitaAggiorna('Attivita_Ore','int',<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>)">
                            <option value="" selected="selected"></option>
                            <!--#include file="/var/cache/Ore-options.htm"--> 
                          </select>
                  				<script type="text/javascript">
                  					selectSet('Attivita_Ore<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>', '<%=Convert.ToDecimal(dtAttivita.Rows[i]["Attivita_Ore"]).ToString("N1", cien)%>');
                  				</script>
                    </td>
				              <td class="large-text-left small-text-left">
                          <select id="AttivitaSettore_Ky<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>" name="AttivitaSettore_Ky" class="select2" onchange="attivitaAggiorna('AttivitaSettore_Ky','int',<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>)">
                            <option value="" selected="selected"></option>
                            <!--#include file="/var/cache/AttivitaSettore-options.htm"--> 
                          </select>
                  				<script type="text/javascript">
                  					selectSet('AttivitaSettore_Ky<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>', '<%=dtAttivita.Rows[i]["AttivitaSettore_Ky"].ToString()%>');
                  				</script>
                      </td>
				              <td class="text-left">
                				<select id="Utenti_Ky<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>" name="Utenti_Ky" value="<%=GetFieldValue(dtAttivita, "Utenti_Ky")%>" required="required" class="select2" onchange="attivitaAggiorna('Utenti_Ky','int',<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>)">
                          <option value=""></option>
                          <!--#include file="/var/cache/Utenti-options-select2.htm"--> 
                        </select>
                				<script type="text/javascript">
                					selectSet('Utenti_Ky<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>', '<%=dtAttivita.Rows[i]["Utenti_Ky"].ToString()%>');
                				</script>
                      </td>
				              <td class="text-right nowrap">
						            <a href="/admin/app/attivita/crud/elimina-attivita.aspx?azione=delete&Commesse_Ky=<%=dtAttivita.Rows[i]["Commesse_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAttivita.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-progetti" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
												<a href="/admin/app/attivita/actions/attivita-completa.aspx?Commesse_Ky=<%=dtAttivita.Rows[i]["Commesse_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAttivita.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivita.Rows[i]["AttivitaSettore_Ky"].ToString()%>&Attivita_Completo=1&sorgente=scheda-progetti" title="completo"><i class="fa-duotone fa-check fa-fw"></i></a>
											</td>
				            </tr>
				        <% } %>
					    	</tbody>
				      </table>
		</div>
	</div>
<% } %>

<% if (strAzione!="new" && dtCommesse.Rows[0]["CommesseStato_Ky"].ToString()!="6"){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
    <a name="nuovaattivita"></a>
  	<br>
  	<div class="card">
  	  <div class="card-divider">
  			<h2><i class="fa-duotone fa-calendar-days fa-lg fa-fw"></i>Nuova Attivit&agrave;</h2>
  		</div>
  	  <div class="card-section">
              <form id="form-attivita" action="/admin/app/attivita/crud/salva-attivita.aspx" method="post" data-abide novalidate>
              <input type="hidden" name="sorgente" value="scheda-progetti">
              <input type="hidden" name="azione" value="new">
              <input type="hidden" id="Attivita_Ky0" name="Attivita_Ky" value="">                
              <input type="hidden" id="Attivita_Chiusura0" name="Attivita_Chiusura" value="<%=DateTime.Now.ToString("dd-MM-yyyy HH:mm")%>">                
              <input type="hidden" id="AttivitaTipo_Ky0" name="AttivitaTipo_Ky" value="1">                
              <input type="hidden" id="Commesse_Ky0" name="Commesse_Ky" value="<%=GetFieldValue(dtCommesse, "Commesse_Ky")%>">                
              <input type="hidden" id="Anagrafiche_Ky0" name="Anagrafiche_Ky" value="<%=GetFieldValue(dtCommesse, "Anagrafiche_Ky")%>">                
							<table class="grid hover scroll" border="0" width="100%">
					    	<thead>
				        <tr>
                  <th width="10"></th>
                  <th width="30" class="text-left"></th>
                  <th width="330" align="left">Descrizione</th>
									<th width="100" align="center">Data</th>
									<th width="100" class="text-center">Priorit&agrave;</th>
									<th width="100" class="text-center">Stato</th>
									<th width="40" align="center">gg</th>
									<th width="60" align="center">Ore</th>
									<th width="60" align="center">Settore</th>
									<th width="120" align="center">Per chi</th>
									<th width="40" class="text-center nowrap"></th>
				        </tr>
					    	</thead>
					    	<tbody>
    		            <tr class="newrecord">
    		              <td class="text-left nowrap" colspan="3"><input type="text" id="Attivita_Descrizione" name="Attivita_Descrizione" value="" required="required" style="margin-bottom:0"></td>
    		              <td class="text-left nowrap"><input type="text" id="Attivita_Scadenza0" name="Attivita_Scadenza" value="<%=DateTime.Now.ToString("dd-MM-yyyy HH:mm")%>" class="fdatetimepicker" required="required" style="margin-bottom:0" autocomplete="off"></td>
    		              <td class="text-left nowrap">
                        <select id="Priorita_Ky0" name="Priorita_Ky" class="select2" style="margin-bottom:0"><option value=""></option><!--#include file="/var/cache/Priorita-options-select2.htm"--></select>
                				<script type="text/javascript">
                					selectSet('Priorita_Ky0', '2');
                				</script>
                      </td>
    		              <td class="text-left nowrap">
                        <select id="AttivitaStati_Ky0" name="AttivitaStati_Ky" required="required" class="select2" style="margin-bottom:0" onchange="chgAttivitaStati_Ky(this)"><option value=""></option><!--#include file="/var/cache/AttivitaStati-options-select2.htm"--></select>
                				<script type="text/javascript">
                					selectSet('AttivitaStati_Ky0', '5');
                				</script>
                      </td>
     		              <td class="text-left nowrap"></td>
    		              <td class="text-left nowrap">
                          <select name="Attivita_Ore" id="Attivita_Ore0" value="" required="required" style="margin-bottom:0">
                            <option value="" selected="selected"></option>
                            <!--#include file="/var/cache/Ore-options.htm"--> 
                          </select>
                      </td>
    		              <td class="text-left nowrap">
                          <select name="AttivitaSettore_Ky" id="AttivitaSettore_Ky0" value="" class="select2" style="margin-bottom:0">
                            <option value="" selected="selected"></option>
                            <!--#include file="/var/cache/AttivitaSettore-options.htm"--> 
                          </select>
                				<script type="text/javascript">
                					selectSet('AttivitaSettore_Ky0', '1');
                				</script>
                      </td>
    		              <td class="text-left nowrap">
                				<select name="Utenti_Ky" id="Utenti_Ky0" value="<%=GetFieldValue(dtAttivita, "Utenti_Ky")%>" required="required" class="select2" style="margin-bottom:0">
                          <option value="" selected="selected"></option>
                          <!--#include file="/var/cache/Utenti-options-select2.htm"--> 
                        </select>
                				<script type="text/javascript">
                					selectSet('Utenti_Ky0', '<%=dtLogin.Rows[0]["Utenti_Ky"].ToString()%>');
                				</script>
                      </td>
    		              <td class="text-right nowrap">
												<button type="submit" class="primary clear"><i class="fa-duotone fa-floppy-disk fa-fw fa-lg primary" style="--fa-primary-color: white;--fa-secondary-color: #1a73e8;"></i></button>
                      </td>
    		            </tr>
					    	</tbody>
				      </table>
              </form>


  		</div>
  	</div>
  </div>
</div>
<% } %>



<script>
  function attivitaAggiorna(strFieldName, strFieldType, intAttivita_Ky){
  	$url="/admin/app/progetti/actions/attivita-update.aspx";
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
  
  function chgAttivitaStati_Ky(selectObject){
    var value = selectObject.value;  
    switch (value){
      case "1":
        jQuery("#Attivita_Chiusura0").val("");
        break;
      case "2":
        jQuery("#Attivita_Chiusura0").val("");
        break;
      case "3":
        jQuery("#Attivita_Chiusura0").val("");
        break;
      case "4":
        jQuery("#Attivita_Chiusura0").val("");
        break;
      case "5":
        jQuery("#Attivita_Chiusura0").val(jQuery("#Attivita_Scadenza0").val());
        break;
    }
    
  }
  
</script>
