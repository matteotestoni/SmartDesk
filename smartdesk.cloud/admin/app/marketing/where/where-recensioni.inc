<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="31" />
<input type="hidden" name="CoreEntities_Ky" value="211" />
<input type="hidden" name="CoreGrids_Ky" value="219" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="Recensioni_Ky" class="large-text-right small-text-left middle">Codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Recensioni_Ky" id="Recensioni_Ky" class="input-group-field" placeholder="ricerca per Codice">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Recensioni_Titolo" class="large-text-right small-text-left middle">Titolo</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Recensioni_Titolo" id="Recensioni_Titolo" class="input-group-field" placeholder="ricerca per Titolo">
</div>
</div>
<div class="grid-x grid-padding-x textarea">
<div class="large-2 medium-2 small-4 cell">
<label for="Recensioni_Descrizione" class="large-text-right small-text-left middle">Descrizione</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Recensioni_Descrizione" id="Recensioni_Descrizione" class="input-group-field" placeholder="ricerca per Descrizione">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="RecensioniTipo_Ky" class="large-text-right small-text-left middle">Tipo recensione</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="RecensioniTipo_Ky" id="Recensioni_Ky" placeholder="Tipo recensione">
<option></option>
<option value="1">
Amministratore</option>
<option value="2">
Ospite</option>
<option value="3">
Utente</option>
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
