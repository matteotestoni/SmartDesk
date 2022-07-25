<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
		<legend>Cerca</legend>
			<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/attivita/elenco-attivita-trasferte.aspx">
        <input type="hidden" name="CoreModules_Ky" value="6" />
        <input type="hidden" name="CoreEntities_Ky" value="79" />
        <input type="hidden" name="CoreGrids_Ky" value="273" />
				<div class="grid-x grid-padding-x">
	        <div class="cell shrink">
							<label for="Utenti_Ky" class="large-text-right small-text-left middle">Di chi</label>
					</div>
					<div class="auto cell">
            <select name="Utenti_Ky" id="Utenti_Ky">
              <option value=""></option>
              <!--#include file="/var/cache/Utenti-options.htm"--> 
            </select>
            <script type="text/javascript">
              selectSet('Utenti_Ky', '<%=Request["Utenti_Ky"]%>');
            </script>
					</div>
	        <div class="cell shrink">
							<label for="anno" class="large-text-right small-text-left middle">Anno</label>
					</div>
					<div class="auto cell">
	          <select name="anno" id="anno">
	            <option value="">tutti</option>
	            <%
	            	for (int i=DateTime.Now.Year-2;i<=DateTime.Now.Year+2;i++){
	            		Response.Write("<option value=\"" + i + "\">" + i + "</option>");
								}
							%>
	          </select>
            <script type="text/javascript">
              selectSet('anno', '<%=Request["anno"]%>');
            </script>
					</div>
	        <div class="cell shrink">
							<label for="mese" class="large-text-right small-text-left middle">Mese</label>
					</div>
					<div class="auto cell">
	          <select name="mese" id="mese">
	            <option value=""></option>
	            <!--#include file="/var/cache/Mesi-options.htm"--> 
	          </select>
            <script type="text/javascript">
              selectSet('mese', '<%=Request["mese"]%>');
            </script>
					</div>
	        <div class="auto cell">
	          <button type="submit" value="cerca" name="cerca" class="tiny button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</button>
					</div>
	        <div class="cell shrink">
	    				<a href="/admin/app/attivita/elenco-attivita-trasferte.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreGrids_Ky=273&tutti=tutti" class="button secondary tiny"><i class="fa-duotone fa-filter-slash fa-fw"></i>Rimuovi filtri</a>
					</div>
				</div>
	    </form>
</fieldset>
