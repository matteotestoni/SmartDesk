<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="12" />
<input type="hidden" name="CoreEntities_Ky" value="10" />
<input type="hidden" name="CoreGrids_Ky" value="11" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="Priorita_Ky" class="large-text-right small-text-left middle">id</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Priorita_Ky" id="Priorita_Ky" class="input-group-field" placeholder="ricerca per id">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Priorita_Descrizione" class="large-text-right small-text-left middle">Descrizione</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Priorita_Descrizione" id="Priorita_Descrizione" class="input-group-field" placeholder="ricerca per Descrizione">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Priorita_Colore" class="large-text-right small-text-left middle">Colore</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Priorita_Colore" id="Priorita_Colore" class="input-group-field" placeholder="ricerca per Colore">
</div>
</div>
<div class="grid-x grid-padding-x">
<div class="large-12 medium-12 small-12 text-center">
<button type="submit" name="Submit" class="button success"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</button>
</div>
</div>
</form>
</fieldset>
