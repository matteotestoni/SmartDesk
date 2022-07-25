<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="31" />
<input type="hidden" name="CoreEntities_Ky" value="198" />
<input type="hidden" name="CoreGrids_Ky" value="206" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="Campagne_Ky" class="large-text-right small-text-left middle">Codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Campagne_Ky" id="Campagne_Ky" class="input-group-field" placeholder="ricerca per Codice">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="CampagneTipo_Ky" class="large-text-right small-text-left middle">Tipo</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="CampagneTipo_Ky" id="Campagne_Ky" placeholder="Tipo">
<option></option>
<option value="3">
Service</option>
<option value="1">
Vendita</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="Documenti_Ky" class="large-text-right small-text-left middle">Documento</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<div class="grid-x grid-padding-x">
<div class="shrink cell hide-for-small-only"><input type="text" name="Documenti_Ky" id="Documenti_Ky" placeholder="Documento"></div>
<div class="auto cell"><input type="text" name="Documenti_Riferimenti" id="Documenti_Riferimenti" placeholder="Documento"></div>
<script type="text/javascript">
		jQuery("#Documenti_Riferimenti").autocomplete({
			source: "/admin/app/marketing/autosuggest-GetDocumenti-json.aspx",
			minLength: 2,
			select: function( event, ui ) {
				jQuery("#Documenti_Ky").val(ui.item.value);
				jQuery("#Documenti_Riferimenti").val(ui.item.label);
				return false;
			}
		});
</script>
</div>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="Opportunita_Ky" class="large-text-right small-text-left middle">Trattativa</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<div class="grid-x grid-padding-x">
<div class="shrink cell hide-for-small-only"><input type="text" name="Opportunita_Ky" id="Opportunita_Ky" placeholder="Trattativa"></div>
<div class="auto cell"><input type="text" name="Opportunita_Titolo" id="Opportunita_Titolo" placeholder="Trattativa"></div>
<script type="text/javascript">
		jQuery("#Opportunita_Titolo").autocomplete({
			source: "/admin/app/marketing/autosuggest-GetOpportunita-json.aspx",
			minLength: 2,
			select: function( event, ui ) {
				jQuery("#Opportunita_Ky").val(ui.item.value);
				jQuery("#Opportunita_Titolo").val(ui.item.label);
				return false;
			}
		});
</script>
</div>
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="utm_source" class="large-text-right small-text-left middle">utmsource</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="utm_source" id="utm_source" class="input-group-field" placeholder="ricerca per utmsource">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="utm_medium" class="large-text-right small-text-left middle">utmmedium</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="utm_medium" id="utm_medium" class="input-group-field" placeholder="ricerca per utmmedium">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="utm_campaign" class="large-text-right small-text-left middle">utm_campaign</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="utm_campaign" id="utm_campaign" class="input-group-field" placeholder="ricerca per utm_campaign">
</div>
</div>
<div class="grid-x grid-padding-x">
<div class="large-12 medium-12 small-12 text-center">
<button type="submit" name="Submit" class="button success"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</button>
</div>
</div>
</form>
</fieldset>
