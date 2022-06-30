		<div class="grid-x grid-padding-x">
			<div class="large-4 medium-4 small-12 cell">
		      <form id="formRicerca" class="formRicerca" method="get" action="/admin/app/anagrafiche/elenco-anagrafiche-da-fatturare.aspx">
						<input type="hidden" name="CoreModules_Ky" value="1">
						<input type="hidden" name="CoreEntities_Ky" value="162">
		        <div class="grid-x grid-padding-x">
					    <div class="large-3 medium-3 small-4 cell">
					      <label for="Anagrafiche_RagioneSociale" class="large-text-right small-text-left middle">Anagrafica</label>
					    </div>
		        	<div class="large-8 medium-8 small-7 cell">
				        <input type="text" name="Anagrafiche_RagioneSociale" id="Anagrafiche_RagioneSociale" placeholder="Ragione Sociale" size="35">
							</div>
							<div class="small-1 medium-1 large-1 cell left">
				        <button type="submit" value="cerca" name="cerca" class="button postfix secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
			        </div>
			      </div>
		      </form>
			</div>
			<div class="large-3 medium-3 small-12 cell">
		      <form id="formRicerca" class="formRicerca" method="get" action="/admin/app/anagrafiche/elenco-anagrafiche-da-fatturare.aspx">
						<input type="hidden" name="CoreModules_Ky" value="1">
						<input type="hidden" name="CoreEntities_Ky" value="162">
		        <div class="grid-x grid-padding-x">
					    <div class="large-3 medium-3 small-4 cell">
					      <label for="mese" class="large-text-right small-text-left middle">Per Mese</label>
					    </div>
		        	<div class="large-8 medium-8 small-7 cell">
			          <select name="mese" id="mese" onchange="this.form.submit()">
			            <option value=""></option>
			            <!--#include file="/var/cache/Mesi-options.htm"--> 
			          </select>
							</div>
							<div class="medium-1 large-1 small-1 cell left">
				        <button type="submit" value="cerca" name="cerca" class="button postfix secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
			        </div>
			      </div>
		      </form>
			</div>
			<div class="large-3 medium-3 small-12 cell">
		      <form id="formRicerca" class="formRicerca" method="get" action="/admin/app/anagrafiche/elenco-anagrafiche-da-fatturare.aspx">
						<input type="hidden" name="CoreModules_Ky" value="1">
						<input type="hidden" name="CoreEntities_Ky" value="162">
		        <div class="grid-x grid-padding-x">
					    <div class="large-3 medium-3 small-4 cell">
					      <label for="Servizi_Ky" class="large-text-right small-text-left middle">Per servizio</label>
					    </div>
		        	<div class="large-8 medium-8 small-7 cell">
			          <select name="Servizi_Ky" id="Servizi_Ky" onchange="this.form.submit()">
			            <option value=""></option>
			            <!--#include file="/var/cache/Servizi-options.htm"--> 
			          </select>
							</div>
							<div class="small-1 medium-1 large-1 cell left">
				        <button type="submit" value="cerca" name="cerca" class="button postfix secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
			        </div>
			      </div>
		      </form>
			</div>
 			<div class="large-2 medium-2 small-12 cell text-center">
 				<a href="/admin/app/anagrafiche/elenco-anagrafiche-da-fatturare.aspx?tutti=tutti" class="button secondary"><i class="fa-duotone fa-filter fa-fw"></i>TUTTI</a>
			</div>
		</div>
