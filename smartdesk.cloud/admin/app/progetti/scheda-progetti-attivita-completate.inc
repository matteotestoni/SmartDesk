<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
    <a name="attivitacompletate"></a>
	<br>
  <div class="divgrid">
      <div class="grid-x grid-padding-x">
        <div class="small-12 medium-2 large-2 cell">
      			<h2><i class="fa-duotone fa-person-digging fa-lg fa-fw"></i>Attivit&agrave; completate</h2>
        </div>
        <div class="small-12 medium-3 large-3 cell">
              <div class="button-group tiny">
      			     <a href="/admin/app/attivita/elenco-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreGrids_Ky=62&Commesse_Ky=<%=Smartdesk.Data.Field(dtCommesse, "Commesse_Ky")%>&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtCommesse, "Anagrafiche_Ky")%>&Attivita_Completo=si&sorgente=scheda-progetti" class="tiny button secondary"><i class="fa-duotone fa-eye fa-fw"></i> Tutte le attivit&agrave; completate</a>
    			       <a class="button tiny secondary hide" data-toggle="filtri"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Filtra</a>
    			       <a href="/admin/app/progetti/scheda-progetti.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreGrids_Ky=62&Commesse_Ky=<%=Smartdesk.Data.Field(dtCommesse, "Commesse_Ky")%>#attivitacompletate" class="button tiny secondary" data-toggle="filtri"><i class="fa-duotone fa-filter-slash fa-lg fa-fw"></i>Rimuovi filtri</a>
              </div>
            </h2>
        </div>
        <div class="small-12 medium-3 large-3 cell">
            <form name="azionidigruppo-form" id="azionidigruppo-form-attivitacompletate" class="form-azione" method="post" action="#">
            <div class="input-group">
              <select class="input-group-field" name="azionidigruppo">
                <option value="">Azioni di gruppo</option>
                <option value="fatturato" data-action="/admin/app/progetti/actions/attivita-fatturato.aspx">Segna come fatturato</option>
                <option value="nonfatturato" data-action="/admin/app/progetti/actions/attivita-fatturato.aspx">Segna come non fatturato</option>
              </select>
              <div class="input-group-button">
                <input type="hidden" name="grid" value="attivitacompletate">
                <input type="hidden" name="sorgente" value="">
                <input type="hidden" name="azione" value="">
                <input type="hidden" name="azionidigruppo-ids" value="">
                <button name="doaction" class="button secondary doaction">Applica</button>
              </div>
            </div>
            </form>
        </div>
        <div class="small-12 medium-4 large-4 cell">
          <!--#include file=/admin/app/progetti/scheda-progetti-datarange.aspx --> 
        </div>
      </div>
				
	      <table id="attivitacompletate" class="grid hover scroll" border="0" width="100%">
		    	<thead>
	        <tr>
            <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	          <th width="40" class="text-left">Cod.</th>
						<% if (GetCheckValue(dtCommesse, "Commesse_AbilitaCampagna")){ %>
						<th width="220" align="center" class="text-center">Campagna</th>
            <% } %>
	          <th width="400" align="left">Descrizione</th>
						<% if (GetCheckValue(dtCommesse, "Commesse_AbilitaBudget")){ %>
				    <th width="80" align="center" class="text-center">Budget</th>
            <% } %>
						<th width="150" align="center" class="text-center">Categoria</th>
						<% if (GetCheckValue(dtCommesse, "Commesse_AbilitaFatturato") || dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(false)){ %>
						<th width="100" align="center" class="text-center">Fatturato</th>
            <% } %>
						<th width="100" align="center" class="text-center">Chiusura</th>
						<th width="80" align="right" class="text-right">Ore</th>
						<th width="90" align="center">Assegnata a</th>
						<th width="80" class="text-center nowrap"></th>
	        </tr>
          <form id="quicksearch" action="/admin/app/progetti/scheda-progetti.aspx" method="get">
          <input type="hidden" name="Commesse_Ky" value="<%=Smartdesk.Data.Field(dtCommesse, "Commesse_Ky")%>">
	        <tr>
            <th width="10"></th>
	          <th width="40" class="text-left"></th>
						<% if (GetCheckValue(dtCommesse, "Commesse_AbilitaCampagna")){ %>
						<th width="220" align="center" class="text-center"><input type="text" name="Attivita_Campagna" value="<%=Request["Attivita_Campagna"]%>" onchange="document.getElementById('quicksearch').submit();"></th>
            <% } %>
	          <th width="400" align="left"><input type="text" name="Attivita_Descrizione" value="<%=Request["Attivita_Descrizione"]%>" onchange="document.getElementById('quicksearch').submit();"></th>
						<% if (GetCheckValue(dtCommesse, "Commesse_AbilitaBudget")){ %>
				    <th width="80" align="center" class="text-center"></th>
            <% } %>
						<th width="150" align="center" class="text-center">
              <select name="AttivitaCategorie_Ky" onchange="document.getElementById('quicksearch').submit();">
              <option value="" selected>Filtra</option>
              <!--#include file="/var/cache/AttivitaCategorie-options.htm"-->
              </select>
            </th>
						<th width="100" align="center" class="text-center"></th>
						<th width="100" align="center" class="text-center"></th>
						<th width="80" align="right" class="text-right"></th>
						<th width="90" align="center">
              <select name="Utenti_Ky" class="select2" onchange="document.getElementById('quicksearch').submit();">
                <option value=""></option>
                <!--#include file="/var/cache/Utenti-options-select2.htm"--> 
              </select>
            </th>
						<th width="80" class="text-center nowrap"></th>
	        </tr>
          </form>
		    	</thead>
		    	<tbody>
	        <%
						decTot=0;
						for (int i = 0; i < dtAttivitaCompletate.Rows.Count; i++){ %>
	            <tr id="trattivita<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>">
                <td><input type="checkbox" class="checkrow" id="record<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>" data-value="<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>" /></td>
		            <td class="text-left nowrap"><a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=1217&Attivita_Ky=<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-progetti"><%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%></a></td>
						    <% if (GetCheckValue(dtCommesse, "Commesse_AbilitaCampagna")){ %>
	              <td class="text-left nowrap">
				           <input type="text" style="margin:0;width:100%" id="Attivita_Campagna<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>" name="Attivita_Campagna" value="<%=dtAttivitaCompletate.Rows[i]["Attivita_Campagna"].ToString()%>" onchange="attivitaAggiorna('Attivita_Campagna','string',<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>)">
				        </td>
                <% } %>
	              <td class="text-left nowrap">
							    <input type="text" style="margin:0;width:100%" id="Attivita_Descrizione<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>" name="Attivita_Descrizione" value="<%=dtAttivitaCompletate.Rows[i]["Attivita_Descrizione"].ToString()%>" onchange="attivitaAggiorna('Attivita_Descrizione','string',<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>)">
								</td>
						    <% if (GetCheckValue(dtCommesse, "Commesse_AbilitaBudget")){ %>
	              <td class="text-left nowrap">
                  <% if (dtAttivitaCompletate.Rows[i]["Attivita_Budget"]!=System.DBNull.Value){ %>
				           <input type="text" inputmode="numeric" min="0" step="1" style="margin:0;" id="Attivita_Budget<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>" name="Attivita_Budget" value="<%=Convert.ToDouble(dtAttivitaCompletate.Rows[i]["Attivita_Budget"]).ToString("N0")%>" onchange="attivitaAggiorna('Attivita_Budget','int',<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>)">
                  <% }else{ %>
				           <input type="number" inputmode="numeric" min="0" step="1" style="margin:0;" id="Attivita_Budget<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>" name="Attivita_Budget" value="0" onchange="attivitaAggiorna('Attivita_Budget','int',<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>)">
                  <% } %>
				        </td>
                <% } %>
	              <td class="large-text-center small-text-left">
                  <select id="AttivitaCategorie_Ky<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>" name="AttivitaCategorie_Ky" class="select2" style="width:100%" onchange="attivitaAggiorna('AttivitaCategorie_Ky','int',<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>)"><option value=""></option><!--#include file="/var/cache/AttivitaCategorie-options-select2.htm"--></select>
          				<script type="text/javascript">
          					selectSet('AttivitaCategorie_Ky<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>', '<%=dtAttivitaCompletate.Rows[i]["AttivitaCategorie_Ky"].ToString()%>');
          				</script>
                </td>
						    <% if (GetCheckValue(dtCommesse, "Commesse_AbilitaFatturato") || dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(false)){ %>
  		          <td class="large-text-center small-text-left">
  								<% if (dtAttivitaCompletate.Rows[i]["Attivita_Fatturato"].Equals(true)){ %>
  									<a href="/admin/app/attivita/actions/attivita-fatturato.aspx?Attivita_Ky=<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>&Commesse_Ky=<%=dtAttivitaCompletate.Rows[i]["Commesse_Ky"].ToString()%>&azione=nonfatturato&azionidigruppo=nonfatturato"><i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i></a>
  								<% }else{ %>
  									<a href="/admin/app/attivita/actions/attivita-fatturato.aspx?Attivita_Ky=<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>&Commesse_Ky=<%=dtAttivitaCompletate.Rows[i]["Commesse_Ky"].ToString()%>&azione=fatturato&azionidigruppo=fatturato"><i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i></a>
  								<% } %>
  							</td>
                <% } %>
	              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivitaCompletate.Rows[i]["Attivita_Chiusura"].ToString()%></td>
	              <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><%=dtAttivitaCompletate.Rows[i]["Attivita_Ore"].ToString()%></td>
	              <td class="text-left">
                <% if (dtAttivitaCompletate.Rows[i]["Utenti_Logo"].ToString().Length>0){ %>
                  <img src="<%=dtAttivitaCompletate.Rows[i]["Utenti_Logo"].ToString()%>" width="30" height="30" align="left" style="width:30px;height:30px;border-radius:50%;margin-right:5px;">
                <% }else{ %>
                  <i class="fa-duotone fa-user fa-fw" style="color:<%=dtAttivitaCompletate.Rows[i]["Utenti_Colore"].ToString()%>"></i>
                <% } %>
                
                <span style="color:<%=dtAttivitaCompletate.Rows[i]["Utenti_Colore"].ToString()%>"><%=dtAttivitaCompletate.Rows[i]["Utenti_Iniziali"].ToString()%></span></td>
	              <td class="text-center nowrap">
                  <% if (strAzione!="new" && dtCommesse.Rows[0]["CommesseStato_Ky"].ToString()!="6"){ %>
									<a href="/admin/app/attivita/actions/attivita-completa.aspx?CoreForms_Ky=1217&Commesse_Ky=<%=dtAttivitaCompletate.Rows[i]["Commesse_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAttivitaCompletate.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>&AttivitaSettore_Ky=<%=dtAttivitaCompletate.Rows[i]["AttivitaSettore_Ky"].ToString()%>&Attivita_Completo=0&sorgente=scheda-progetti" title="da fare"><i class="fa-duotone fa-undo fa-fw"></i></a>
	              	<a href="/admin/app/attivita/crud/elimina-attivita.aspx?CoreForms_Ky=1217&azione=delete&Commesse_Ky=<%=dtAttivitaCompletate.Rows[i]["Commesse_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtAttivitaCompletate.Rows[i]["Anagrafiche_Ky"].ToString()%>&Attivita_Ky=<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-progetti" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
	              	<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=1217&Attivita_Ky=<%=dtAttivitaCompletate.Rows[i]["Attivita_Ky"].ToString()%>&sorgente=scheda-progetti" title="modifica" class="edit"><i class="fa-duotone fa-edit fa-fw"></i></a>
                  <% } %>
								</td>
	            </tr>
	        <%
						if (dtAttivitaCompletate.Rows[i]["Attivita_Ore"]!=System.DBNull.Value){
							decTot+=Convert.ToDecimal(dtAttivitaCompletate.Rows[i]["Attivita_Ore"]);
						}
						} %>
		    	</tbody>
				  <% if (dtAttivitaCompletate.Rows.Count<1){
		      	          Response.Write("<tfoot><tr><td colspan=\"11\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
					} %> 
				  <% if (dtAttivitaCompletate.Rows.Count>0){ %>
		    	<tfoot>
			      <tr class="totale">
			        <td class="large-text-right small-text-left" colspan="<%=intColonne%>">Totali</td>
			        <td class="large-text-right small-text-left" style="padding-right:5px"><%=decTot.ToString("N2", ci)%></td>
			        <td class="large-text-right small-text-left" colspan="2"></td>
			      </tr>
    			</tfoot>
					<% } %> 
	      </table>
		</div>
	</div>
</div>
<% } %>
