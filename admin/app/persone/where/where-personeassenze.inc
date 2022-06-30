			<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
					<legend>Cerca</legend>
					<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/persone/elenco-personeassenze.aspx">
      	  	<input type="hidden" name="CoreModules_Ky" value="22" />
      	  	<input type="hidden" name="CoreEntities_Ky" value="39" />
      	  	<input type="hidden" name="CoreGrids_Ky" value="115" />
						<div class="grid-x grid-padding-x align-middle">
	            <% if (boolAdmin==true){ %>
              <div class="cell shrink align-middle">
									<label for="Persone_Ky" class="large-text-right small-text-left align-middle">Ricerca per Persona</label>
							</div>
							<div class="auto cell align-middle">
									<select name="Persone_Ky" id="Persone_Ky">
										<option value=""></option>
										<!--#include file="/var/cache/Persone-options.htm"--> 
									</select>
							</div>
              <% } %>
							<div class="cell shrink align-middle">
									<label for="anno" class="large-text-right small-text-left align-middle">Ricerca per anno</label>
							</div>
							<div class="auto cell align-middle">
									<select name="anno" id="anno">
										<option value="tutti"></option>
										<%
											for (int i=DateTime.Now.Year-5;i<=DateTime.Now.Year+1;i++){
												Response.Write("<option value=\"" + i + "\">" + i + "</option>");
											}
										%>
									</select>
							</div>
							<div class="cell shrink align-middle">
									<label for="mese" class="large-text-right small-text-left align-middle">Ricerca per mese</label>
							</div>
							<div class="auto cell align-middle">
									<select name="mese" id="mese">
										<option value="tutti">tutti</option>
										<%
											for (int i=1;i<13;i++){
												Response.Write("<option value=\"" + i + "\">" + i + "</option>");
											}
										%>
									</select>
							</div>
							<div class="auto cell align-middle">
										<button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
							</div>
						</div>
				  </form>
  		</fieldset>
