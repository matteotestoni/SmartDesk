<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="20" />
<input type="hidden" name="CoreEntities_Ky" value="180" />
<input type="hidden" name="CoreGrids_Ky" value="170" />
<div class="grid-x grid-padding-x">
<div class="large-2 medium-2 small-4 cell">
<label for="LeadTipo_Codice" class="large-text-right small-text-left middle">Codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="LeadTipo_Codice" id="LeadTipo_Codice" class="input-group-field" placeholder="ricerca per Codice">
</div>
</div>
<div class="grid-x grid-padding-x">
<div class="large-2 medium-2 small-4 cell">
<label for="LeadTipo_Ky" class="large-text-right small-text-left middle">Codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="LeadTipo_Ky" id="LeadTipo_Ky" class="input-group-field" placeholder="ricerca per Codice">
</div>
</div>
<div class="grid-x grid-padding-x">
<div class="large-2 medium-2 small-4 cell">
<label for="LeadTipo_Titolo" class="large-text-right small-text-left middle">Titolo</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="LeadTipo_Titolo" id="LeadTipo_Titolo" class="input-group-field" placeholder="ricerca per Titolo">
</div>
</div>
<div class="grid-x grid-padding-x">
<div class="large-12 medium-12 small-12 text-center">
<button type="submit" name="Submit" class="button success"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</button>
</div>
</div>
</form>
</fieldset>
