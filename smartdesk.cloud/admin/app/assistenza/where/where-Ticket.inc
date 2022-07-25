<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="32" />
<input type="hidden" name="CoreEntities_Ky" value="221" />
<input type="hidden" name="CoreGrids_Ky" value="231" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="Ticket_Ky" class="large-text-right small-text-left middle">Codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Ticket_Ky" id="Ticket_Ky" class="input-group-field" placeholder="ricerca per Codice">
</div>
</div>
<div class="grid-x grid-padding-x data">
<div class="large-2 medium-2 small-4 cell">
<label for="Ticket_Data" class="large-text-right small-text-left middle">Data</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Ticket_Data" id="Ticket_Data" class="input-group-field" placeholder="ricerca per Data">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Ticket_Titolo" class="large-text-right small-text-left middle">Titolo</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Ticket_Titolo" id="Ticket_Titolo" class="input-group-field" placeholder="ricerca per Titolo">
</div>
</div>
<div class="grid-x grid-padding-x textarea">
<div class="large-2 medium-2 small-4 cell">
<label for="Ticket_Richiesta" class="large-text-right small-text-left middle">Richiesta</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Ticket_Richiesta" id="Ticket_Richiesta" class="input-group-field" placeholder="ricerca per Richiesta">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="TicketStati_Ky" class="large-text-right small-text-left middle">Stato</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="TicketStati_Ky" id="Ticket_Ky" placeholder="Stato">
<option></option>
<option value="2">
Chiuso</option>
<option value="1">
In lavorazione</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="TicketCategorie_Ky" class="large-text-right small-text-left middle">Categoria</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="TicketCategorie_Ky" id="Ticket_Ky" placeholder="Categoria">
<option></option>
<option value="1">
Hosting</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="Utenti_Ky" class="large-text-right small-text-left middle">Utente</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="Utenti_Ky" id="Ticket_Ky" placeholder="Utente">
<option></option>
<option value="1">
RSW Studio</option>
<option value="2">
Matteo Testoni</option>
<option value="3">
Mattia Gazzabin</option>
<option value="9">
Martina Paluan</option>
<option value="10">
Nico Bondesan</option>
<option value="12">
Elisa Cucco</option>
<option value="14">
Alessandro Bonini</option>
<option value="20">
Ilaria Zilli</option>
<option value="21">
Sofia Ghirardello</option>
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
