<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
	<legend>Cerca avanzamento forms</legend>
  <form id="formRicerca" class="formRicerca" method="get" action="/admin/app/forms/elenco-forms-avanzamento.aspx">
	  <input type="hidden" name="CoreModules_Ky" value="16" />
	  <input type="hidden" name="CoreEntities_Ky" value="147" />
	  <input type="hidden" name="CoreGrids_Ky" value="97" />
    <div class="grid-x grid-padding-x">
      <div class="large-2 medium-2 small-3 cell">
  	    <label for="Anagrafiche_RagioneSociale" class="large-text-right small-text-left middle">Ricerca per Ragione Sociale</label>
      </div>
      <div class="large-8 medium-8 small-6 cell">
  	    <input type="text" class="input-group-field" name="Anagrafiche_RagioneSociale" id="Anagrafiche_RagioneSociale" placeholder="ricerca per ragione sociale" />
      </div>
      <div class="large-2 medium-2 small-3 cell">
  	    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
      </div>
    </div>
  </form>
</fieldset>
