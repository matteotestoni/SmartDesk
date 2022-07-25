<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="27" />
<input type="hidden" name="CoreEntities_Ky" value="142" />
<input type="hidden" name="CoreGrids_Ky" value="126" />
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="Anagrafiche_Ky" class="large-text-right small-text-left middle">Anagrafica</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<div class="grid-x grid-padding-x">
<div class="shrink cell hide-for-small-only"><input type="text" name="Anagrafiche_Ky" id="Anagrafiche_Ky" placeholder="Anagrafica"></div>
<div class="auto cell"><input type="text" name="Anagrafiche_RagioneSociale" id="Anagrafiche_RagioneSociale" placeholder="Anagrafica"></div>
<script type="text/javascript">
		jQuery("#Anagrafiche_RagioneSociale").autocomplete({
			source: "/admin/app/sitiweb/autosuggest-GetAnagrafiche-json.aspx",
			minLength: 2,
			select: function( event, ui ) {
				jQuery("#Anagrafiche_Ky").val(ui.item.value);
				jQuery("#Anagrafiche_RagioneSociale").val(ui.item.label);
				return false;
			}
		});
</script>
</div>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="Providers_Ky" class="large-text-right small-text-left middle">Provider</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="Providers_Ky" id="Anagrafiche_Ky" placeholder="Provider">
<option></option>
<option value="3">
Artera</option>
<option value="1">
Aruba</option>
<option value="12">
Aruba Business</option>
<option value="7">
Del cliente</option>
<option value="10">
eurologon</option>
<option value="5">
Hetzner</option>
<option value="11">
ipage</option>
<option value="8">
Nessun provider</option>
<option value="2">
PegasoHosting</option>
<option value="6">
Register</option>
<option value="4">
Server Plan</option>
<option value="13">
Welcome Italia</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="SitiWeb_IP" class="large-text-right small-text-left middle">IP</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="SitiWeb_IP" id="SitiWeb_IP" class="input-group-field" placeholder="ricerca per IP">
</div>
</div>
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="SitiWeb_Ky" class="large-text-right small-text-left middle">Codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="SitiWeb_Ky" id="SitiWeb_Ky" class="input-group-field" placeholder="ricerca per Codice">
</div>
</div>
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="SitiWeb_PageSpeedScore" class="large-text-right small-text-left middle">PageSpeedScore</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="SitiWeb_PageSpeedScore" id="SitiWeb_PageSpeedScore" class="input-group-field" placeholder="ricerca per PageSpeedScore">
</div>
</div>
<div class="grid-x grid-padding-x checkbox">
<div class="large-2 medium-2 small-4 cell">
<label for="SitiWeb_SEO" class="large-text-right small-text-left middle">SEO</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="checkbox" name="SitiWeb_SEO" id="SitiWeb_SEO" class="input-group-field" placeholder="ricerca per SEO" value="1">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="SitiWeb_Url" class="large-text-right small-text-left middle">Url</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="SitiWeb_Url" id="SitiWeb_Url" class="input-group-field" placeholder="ricerca per Url">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="SitiWeb_Versione" class="large-text-right small-text-left middle">Versione</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="SitiWeb_Versione" id="SitiWeb_Versione" class="input-group-field" placeholder="ricerca per Versione">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="SitiWebTipo_Ky" class="large-text-right small-text-left middle">Tipo</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="SitiWebTipo_Ky" id="Anagrafiche_Ky" placeholder="Tipo">
<option></option>
<option value="8">
Drupal</option>
<option value="7">
Joomla</option>
<option value="2">
Linux</option>
<option value="4">
Magento</option>
<option value="5">
php</option>
<option value="6">
redirect</option>
<option value="1">
Windows</option>
<option value="3">
Wordpress</option>
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
