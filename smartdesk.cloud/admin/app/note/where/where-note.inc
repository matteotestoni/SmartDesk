<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="19" />
<input type="hidden" name="CoreEntities_Ky" value="161" />
<input type="hidden" name="CoreGrids_Ky" value="106" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="Note_Ky" class="large-text-right small-text-left middle">Ky</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Note_Ky" id="Note_Ky" class="input-group-field" placeholder="ricerca per Ky">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Note_Titolo" class="large-text-right small-text-left middle">Titolo</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Note_Titolo" id="Note_Titolo" class="input-group-field" placeholder="ricerca per Titolo">
</div>
</div>
<div class="grid-x grid-padding-x textarea">
<div class="large-2 medium-2 small-4 cell">
<label for="Note_Descrizione" class="large-text-right small-text-left middle">Descrizione</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Note_Descrizione" id="Note_Descrizione" class="input-group-field" placeholder="ricerca per Descrizione">
</div>
</div>
<div class="grid-x grid-padding-x data">
<div class="large-2 medium-2 small-4 cell">
<label for="Note_Data" class="large-text-right small-text-left middle">Data</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Note_Data" id="Note_Data" class="input-group-field" placeholder="ricerca per Data">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="Note_Tags" class="large-text-right small-text-left middle">Tags</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="Note_Tags" id="Note_Tags" placeholder="Tags" multiple class="select2">
<option></option>
<option value="amministrazione">amministrazione</option>
<option value="Commerciale">Commerciale</option>
<option value="Tecnico">Tecnico</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="NoteCategorie_Ky" class="large-text-right small-text-left middle">Categorie</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="NoteCategorie_Ky" id="Note_Ky" placeholder="Categorie">
<option></option>
<option value="4">
Amministrazione</option>
<option value="5">
Commerciale</option>
<option value="1">
magento</option>
<option value="6">
Tecnica</option>
<option value="2">
Woocommerce</option>
<option value="3">
Wordpress</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="Anagrafiche_Ky" class="large-text-right small-text-left middle">Anagrafiche</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<div class="grid-x grid-padding-x">
<div class="shrink cell hide-for-small-only"><input type="text" name="Anagrafiche_Ky" id="Anagrafiche_Ky" placeholder="Anagrafiche"></div>
<div class="auto cell"><input type="text" name="Anagrafiche_RagioneSociale" id="Anagrafiche_RagioneSociale" placeholder="Anagrafiche"></div>
<script type="text/javascript">
		jQuery("#Anagrafiche_RagioneSociale").autocomplete({
			source: "/admin/app/note/autosuggest-GetAnagrafiche-json.aspx",
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
<div class="grid-x grid-padding-x">
<div class="large-12 medium-12 small-12 text-center">
<button type="submit" name="Submit" class="button success"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</button>
</div>
</div>
</form>
</fieldset>
