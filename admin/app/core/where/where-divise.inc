<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="12" />
<input type="hidden" name="CoreEntities_Ky" value="16" />
<input type="hidden" name="CoreGrids_Ky" value="15" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="Divise_Ky" class="large-text-right small-text-left middle">Codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Divise_Ky" id="Divise_Ky" class="input-group-field" placeholder="ricerca per Codice">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Divise_Descrizione" class="large-text-right small-text-left middle">Descrizione</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Divise_Descrizione" id="Divise_Descrizione" class="input-group-field" placeholder="ricerca per Descrizione">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Divise_Codice" class="large-text-right small-text-left middle">Codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Divise_Codice" id="Divise_Codice" class="input-group-field" placeholder="ricerca per Codice">
</div>
</div>
<div class="grid-x grid-padding-x">
<div class="large-12 medium-12 small-12 text-center">
<button type="submit" name="Submit" class="button success"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</button>
</div>
</div>
</form>
</fieldset>