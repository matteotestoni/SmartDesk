<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="12" />
<input type="hidden" name="CoreEntities_Ky" value="20" />
<input type="hidden" name="CoreGrids_Ky" value="19" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="Aziende_Ky" class="large-text-right small-text-left middle">Codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Aziende_Ky" id="Aziende_Ky" class="input-group-field" placeholder="ricerca per Codice">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Aziende_RagioneSociale" class="large-text-right small-text-left middle">Ragione Sociale</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Aziende_RagioneSociale" id="Aziende_RagioneSociale" class="input-group-field" placeholder="ricerca per Ragione Sociale">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Aziende_Telefono" class="large-text-right small-text-left middle">Telefono</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Aziende_Telefono" id="Aziende_Telefono" class="input-group-field" placeholder="ricerca per Telefono">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Aziende_PartitaIVA" class="large-text-right small-text-left middle">Partita IVA</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Aziende_PartitaIVA" id="Aziende_PartitaIVA" class="input-group-field" placeholder="ricerca per Partita IVA">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Aziende_CodiceFiscale" class="large-text-right small-text-left middle">Codice Fiscale</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Aziende_CodiceFiscale" id="Aziende_CodiceFiscale" class="input-group-field" placeholder="ricerca per Codice Fiscale">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Aziende_Codice" class="large-text-right small-text-left middle">Codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Aziende_Codice" id="Aziende_Codice" class="input-group-field" placeholder="ricerca per Codice">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="AliquoteIVA_Ky" class="large-text-right small-text-left middle">Aliquota IVA</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="AliquoteIVA_Ky" id="Aziende_Ky" placeholder="Aliquota IVA">
<option></option>
<option value="10">
10 - 10,0000</option>
<option value="21">
21 - 21,0000</option>
<option value="43">
43 - 22,0000</option>
<option value="41">
41 - 23,0000</option>
<option value="4">
4 - 4,0000</option>
<option value="46">
46 - 0,0000</option>
<option value="40">
40 - 0,0000</option>
<option value="7">
7 - 0,0000</option>
<option value="44">
44 - 0,0000</option>
<option value="45">
45 - </option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Aziende_Email" class="large-text-right small-text-left middle">Email</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Aziende_Email" id="Aziende_Email" class="input-group-field" placeholder="ricerca per Email">
</div>
</div>
<div class="grid-x grid-padding-x">
<div class="large-12 medium-12 small-12 text-center">
<button type="submit" name="Submit" class="button success"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</button>
</div>
</div>
</form>
</fieldset>
