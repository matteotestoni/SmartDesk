<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="9" />
<input type="hidden" name="CoreEntities_Ky" value="96" />
<input type="hidden" name="CoreGrids_Ky" value="79" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="CMSContenuti_Ky" class="large-text-right small-text-left middle">id</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="CMSContenuti_Ky" id="CMSContenuti_Ky" class="input-group-field" placeholder="ricerca per id">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="CMSContenuti_Titolo" class="large-text-right small-text-left middle">Titolo</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="CMSContenuti_Titolo" id="CMSContenuti_Titolo" class="input-group-field" placeholder="ricerca per Titolo">
</div>
</div>
<div class="grid-x grid-padding-x data">
<div class="large-2 medium-2 small-4 cell">
<label for="CMSContenuti_Data" class="large-text-right small-text-left middle">Data</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="CMSContenuti_Data" id="CMSContenuti_Data" class="input-group-field" placeholder="ricerca per Data">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="CMSContenuti_UrlKey" class="large-text-right small-text-left middle">UrlKey</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="CMSContenuti_UrlKey" id="CMSContenuti_UrlKey" class="input-group-field" placeholder="ricerca per UrlKey">
</div>
</div>
<div class="grid-x grid-padding-x checkbox">
<div class="large-2 medium-2 small-4 cell">
<label for="CMSContenuti_InMenu" class="large-text-right small-text-left middle">InMenu</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="checkbox" name="CMSContenuti_InMenu" id="CMSContenuti_InMenu" class="input-group-field" placeholder="ricerca per InMenu" value="1">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="CMSCategorie_Ky" class="large-text-right small-text-left middle">id</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="CMSCategorie_Ky" id="CMSContenuti_Ky" placeholder="id">
<option></option>
<option value="1">
1 - Amministrazione</option>
<option value="2">
2 - Produzione</option>
<option value="3">
3 - Commerciale</option>
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
