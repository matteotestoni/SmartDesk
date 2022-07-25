<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="12" />
<input type="hidden" name="CoreEntities_Ky" value="17" />
<input type="hidden" name="CoreGrids_Ky" value="16" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="Utenti_Ky" class="large-text-right small-text-left middle">Codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Utenti_Ky" id="Utenti_Ky" class="input-group-field" placeholder="ricerca per Codice">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Utenti_Email" class="large-text-right small-text-left middle">Email</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Utenti_Email" id="Utenti_Email" class="input-group-field" placeholder="ricerca per Email">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="Persone_Ky" class="large-text-right small-text-left middle">Persona</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="Persone_Ky" id="Utenti_Ky" placeholder="Persona">
<option></option>
<option value="15">
Alessandro - Bonini</option>
<option value="18">
Antonino - Merlo</option>
<option value="17">
Elena - Cugola</option>
<option value="11">
Elisa - Cucco</option>
<option value="6">
Francesca - La Malfa</option>
<option value="2">
Gianluca - Milan</option>
<option value="12">
Giorgia - Roversi</option>
<option value="20">
Ilaria - Zilli</option>
<option value="19">
Irene - Gozzo</option>
<option value="8">
Martina - Paluan</option>
<option value="3">
Matteo - Altieri</option>
<option value="1">
Matteo - Testoni</option>
<option value="10">
Mattia - Mazzaro</option>
<option value="4">
Mattia - Gazzabin</option>
<option value="9">
Nico - Bondesan</option>
<option value="16">
Patrizia - Manca</option>
<option value="13">
Serman - Nerjaku</option>
<option value="21">
Sofia - Ghirardello</option>
<option value="7">
Stefania - Ferrazzi</option>
<option value="5">
Vanessa - Garani</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Utenti_Codice" class="large-text-right small-text-left middle">Codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Utenti_Codice" id="Utenti_Codice" class="input-group-field" placeholder="ricerca per Codice">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Utenti_Cognome" class="large-text-right small-text-left middle">Cognome</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Utenti_Cognome" id="Utenti_Cognome" class="input-group-field" placeholder="ricerca per Cognome">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Utenti_Nome" class="large-text-right small-text-left middle">Nome</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Utenti_Nome" id="Utenti_Nome" class="input-group-field" placeholder="ricerca per Nome">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="UtentiGruppi_Ky" class="large-text-right small-text-left middle">Gruppo</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="UtentiGruppi_Ky" id="Utenti_Ky" placeholder="Gruppo">
<option></option>
<option value="1">
1 - Mattia</option>
<option value="3">
3 - Amministrazione</option>
<option value="6">
6 - Dipendenti</option>
<option value="8">
8 - Matteo</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="UtentiTipo_Ky" class="large-text-right small-text-left middle">id</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="UtentiTipo_Ky" id="Utenti_Ky" placeholder="id">
<option></option>
<option value="2">
Esterno</option>
<option value="1">
interno</option>
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
