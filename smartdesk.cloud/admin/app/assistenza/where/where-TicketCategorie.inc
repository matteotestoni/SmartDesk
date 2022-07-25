<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="32" />
<input type="hidden" name="CoreEntities_Ky" value="219" />
<input type="hidden" name="CoreGrids_Ky" value="229" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="TicketCategorie_Ky" class="large-text-right small-text-left middle">Id</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="TicketCategorie_Ky" id="TicketCategorie_Ky" class="input-group-field" placeholder="ricerca per Id">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="TicketCategorie_Titolo" class="large-text-right small-text-left middle">Titolo</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="TicketCategorie_Titolo" id="TicketCategorie_Titolo" class="input-group-field" placeholder="ricerca per Titolo">
</div>
</div>
<div class="grid-x grid-padding-x">
<div class="large-12 medium-12 small-12 text-center">
<button type="submit" name="Submit" class="button success"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</button>
</div>
</div>
</form>
</fieldset>
