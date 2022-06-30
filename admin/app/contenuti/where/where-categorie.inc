<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
	<legend>Cerca Preferiti</legend>
	<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
    <input type="hidden" name="CoreModules_Ky" value="9">
    <input type="hidden" name="CoreEntities_Ky" value="100">
    <input type="hidden" name="CoreGrids_Ky" value="83">
    <div class="grid-x grid-padding-x">
	    <div class="large-2 medium-2 small-3 cell">
	      <label for="CMSCategorie_Descrizione" class="large-text-right small-text-left middle">Ricerca per titolo</label>
	    </div>
    	<div class="large-8 medium-8 small-6 cell">
				<input type="text" name="CMSCategorie_Descrizione" id="CMSCategorie_Descrizione" size="28" placeholder="ricerca per titolo" />
			</div>
	    <div class="cell shrink">
      	<button type="submit" value="cerca" name="cerca" class="button postfix secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
      </div>
    </div>
  </form>
</fieldset>
