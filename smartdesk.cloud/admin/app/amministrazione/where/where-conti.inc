<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="2" />
<input type="hidden" name="CoreEntities_Ky" value="105" />
<input type="hidden" name="CoreGrids_Ky" value="40" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="Conti_Ky" class="large-text-right small-text-left middle">Codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Conti_Ky" id="Conti_Ky" class="input-group-field" placeholder="ricerca per Codice">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Conti_Titolo" class="large-text-right small-text-left middle">Titolo</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Conti_Titolo" id="Conti_Titolo" class="input-group-field" placeholder="ricerca per Titolo">
</div>
</div>
<div class="grid-x grid-padding-x data">
<div class="large-2 medium-2 small-4 cell">
<label for="Conti_Data" class="large-text-right small-text-left middle">Data</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Conti_Data" id="Conti_Data" class="input-group-field" placeholder="ricerca per Data">
</div>
</div>
<div class="grid-x grid-padding-x">
<div class="large-12 medium-12 small-12 text-center">
<button type="submit" name="Submit" class="button success"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</button>
</div>
</div>
</form>
</fieldset>
