<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="2" />
<input type="hidden" name="CoreEntities_Ky" value="36" />
<input type="hidden" name="CoreGrids_Ky" value="39" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="CentridiCR_Ky" class="large-text-right small-text-left middle">Codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="CentridiCR_Ky" id="CentridiCR_Ky" class="input-group-field" placeholder="ricerca per Codice">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="CentridiCR_Titolo" class="large-text-right small-text-left middle">Titolo</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="CentridiCR_Titolo" id="CentridiCR_Titolo" class="input-group-field" placeholder="ricerca per Titolo">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="CentridiCR_Descrizione" class="large-text-right small-text-left middle">Descrizione</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="CentridiCR_Descrizione" id="CentridiCR_Descrizione" class="input-group-field" placeholder="ricerca per Descrizione">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="CentridiCR_Padre" class="large-text-right small-text-left middle">Padre</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="CentridiCR_Padre" id="CentridiCR_Ky" placeholder="Padre">
<option></option>
<option value="0">
53 - Amministratori</option>
<option value="0">
36 - Amministrazione</option>
<option value="0">
31 - Attivit&agrave; commerciali</option>
<option value="0">
22 - Attrezzature e Macchinari</option>
<option value="0">
34 - Costi del personale</option>
<option value="0">
35 - Immobili</option>
<option value="0">
37 - Produzione (per clienti)</option>
<option value="0">
9 - Spese ufficio</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x">
<div class="large-12 medium-12 small-12 text-center">
<button type="submit" name="Submit" class="button success"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</button>
</div>
</div>
</form>
</fieldset>
