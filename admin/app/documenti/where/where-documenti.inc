			<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
					<legend>Cerca</legend>
					<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/documenti/elenco-documenti.aspx">
						<div class="grid-x grid-padding-x">
					    <div class="large-2 medium-2 small-3 cell">
					      <label for="Aziende_Ky" class="large-text-right small-text-left middle">Ricerca per azienda</label>
					    </div>
					    <div class="large-8 medium-8 small-6 cell">
			          <select name="Aziende_Ky" id="Aziende_Ky" onchange="this.form.submit()">
			            <option value=""></option>
			            <!--#include file="/var/cache/Aziende-options.htm"--> 
			          </select>
					    </div>
					    <div class="large-2 medium-2 small-3 cell">
						    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
					    </div>
					  </div>
				  </form>
					<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/documenti/elenco-documenti.aspx">
						<div class="grid-x grid-padding-x">
					    <div class="large-2 medium-2 small-3 cell">
					      <label for="DocumentiTipo_Ky" class="large-text-right small-text-left middle">Ricerca per tipo</label>
					    </div>
					    <div class="large-8 medium-8 small-6 cell">
			          <select name="DocumentiTipo_Ky" id="DocumentiTipo_Ky" onchange="this.form.submit()">
			            <option value=""></option>
			            <!--#include file="/var/cache/DocumentiTipo-options.htm"--> 
			          </select>
					    </div>
					    <div class="large-2 medium-2 small-3 cell">
						    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
					    </div>
					  </div>
				  </form>

					<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/documenti/elenco-documenti.aspx">
						<div class="grid-x grid-padding-x">
					    <div class="large-2 medium-2 small-3 cell">
					      <label for="Anagrafiche_RagioneSociale" class="large-text-right small-text-left middle">Ricerca per Ragione sociale</label>
					    </div>
					    <div class="large-8 medium-8 small-6 cell">
						  	<input type="text" name="Anagrafiche_RagioneSociale" id="Anagrafiche_RagioneSociale" placeholder="ricerca per ragione sociale" />
					    </div>
					    <div class="large-2 medium-2 small-3 cell">
						    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
					    </div>
					  </div>
				  </form>
					<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/documenti/elenco-documenti.aspx">
						<div class="grid-x grid-padding-x">
					    <div class="large-2 medium-2 small-3 cell">
					      <label for="anno" class="large-text-right small-text-left middle">Per anno<i class="fa-duotone fa-calendar-days fa-fw"></i></label>
					    </div>
					    <div class="large-8 medium-8 small-6 cell">
			          <select name="anno" id="anno" onchange="this.form.submit()">
			            <option value="tutti"></option>
			            <%
			            	for (int i=DateTime.Now.Year-2;i<=DateTime.Now.Year+2;i++){
			            		Response.Write("<option value=\"" + i + "\">" + i + "</option>");
										}
									%>
			          </select>
					    </div>
					    <div class="large-2 medium-2 small-3 cell">
						    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
					    </div>
					  </div>
				  </form>
					<div class="grid-x grid-padding-x">
						<div class="large-12 medium-12 small-12 cell text-center">
      				<a href="/admin/app/documenti/elenco-documenti.aspx?tutti=tutti">TUTTI</a></td>
      			</div>
      		</div>
			</fieldset>
