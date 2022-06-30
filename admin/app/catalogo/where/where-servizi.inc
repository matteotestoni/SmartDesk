			<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
					<legend>Cerca</legend>
					<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/catalogo/elenco-servizi.aspx">
            <input type="hidden" name="CoreModules_Ky" value="8" />
            <input type="hidden" name="CoreEntities_Ky" value="195" />
            <input type="hidden" name="CoreGrids_Ky" value="203" />
						<div class="grid-x grid-padding-x">
					    <div class="large-2 medium-2 small-3 cell">
					      <label for="right-label" class="large-text-right small-text-left middle">Ricerca per titolo</label>
					    </div>
					    <div class="large-8 medium-8 small-6 cell">
						  	<input type="text" class="input-group-field" name="ricercatitolo" id="ricercatitolo" placeholder="ricerca per titolo" />
					    </div>
					    <div class="large-2 medium-2 small-3 cell">
						    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
					    </div>
					  </div>
				  </form>
 				  <form id="formRicerca" class="formRicerca" method="get" action="/admin/app/catalogo/elenco-servizi.aspx">
						<div class="grid-x grid-padding-x">
					    <div class="large-2 medium-2 small-3 cell">
					      <label for="right-label" class="large-text-right small-text-left middle">Ricerca per codice</label>
					    </div>
					    <div class="large-8 medium-8 small-6 cell">
						  	<input type="text" class="input-group-field" name="ricercacodice" id="ricercacodice" placeholder="ricerca per codice" />
					    </div>
					    <div class="large-2 medium-2 small-3 cell">
						    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
					    </div>
					  </div>
				  </form>
      </fieldset>
