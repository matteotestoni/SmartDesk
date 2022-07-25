<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="5" />
<input type="hidden" name="CoreEntities_Ky" value="60" />
<input type="hidden" name="CoreGrids_Ky" value="50" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="Aste_Ky" class="large-text-right small-text-left middle">Codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Aste_Ky" id="Aste_Ky" class="input-group-field" placeholder="ricerca per Codice">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Aste_Titolo" class="large-text-right small-text-left middle">Titolo</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Aste_Titolo" id="Aste_Titolo" class="input-group-field" placeholder="ricerca per Titolo">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Aste_Descrizione" class="large-text-right small-text-left middle">Descrizione</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Aste_Descrizione" id="Aste_Descrizione" class="input-group-field" placeholder="ricerca per Descrizione">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Aste_Numero" class="large-text-right small-text-left middle">Numero</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Aste_Numero" id="Aste_Numero" class="input-group-field" placeholder="ricerca per Numero">
</div>
</div>
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="AsteCategorie_Ky" class="large-text-right small-text-left middle">id</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="AsteCategorie_Ky" id="AsteCategorie_Ky" class="input-group-field" placeholder="ricerca per id">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="AsteRitiri_Ky" class="large-text-right small-text-left middle">id</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="AsteRitiri_Ky" id="Aste_Ky" placeholder="id">
<option></option>
<option value="1">
Entro 10 giorni dal perfezionamento della vendita</option>
<option value="2">
Entro 20 giorni dal perfezionamento della vendita</option>
<option value="3">
Entro 30 giorni dal perfezionamento del pagamento</option>
<option value="4">
Leggere condizioni di vendita</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="AsteTipo_Ky" class="large-text-right small-text-left middle">id</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="AsteTipo_Ky" id="Aste_Ky" placeholder="id">
<option></option>
<option value="2">
Concorsuale</option>
<option value="1">
Privata</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="AsteNatura_Ky" class="large-text-right small-text-left middle">id</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="AsteNatura_Ky" id="Aste_Ky" placeholder="id">
<option></option>
<option value="2">
Immobiliare</option>
<option value="1">
Mobiliare</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="AsteVendita_Ky" class="large-text-right small-text-left middle">id</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="AsteVendita_Ky" id="Aste_Ky" placeholder="id">
<option></option>
<option value="4">
Pubblicita</option>
<option value="2">
Vendita asincrona telematica</option>
<option value="3">
Vendita sincrona mista</option>
<option value="1">
Vendita sincrona telematica</option>
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
