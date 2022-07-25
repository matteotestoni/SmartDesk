<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="32" />
<input type="hidden" name="CoreEntities_Ky" value="237" />
<input type="hidden" name="CoreGrids_Ky" value="252" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="Knowledgebase_Ky" class="large-text-right small-text-left middle">Codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Knowledgebase_Ky" id="Knowledgebase_Ky" class="input-group-field" placeholder="ricerca per Codice">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Knowledgebase_Titolo" class="large-text-right small-text-left middle">Titolo</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Knowledgebase_Titolo" id="Knowledgebase_Titolo" class="input-group-field" placeholder="ricerca per Titolo">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="KnowledgebaseCategorie_Ky" class="large-text-right small-text-left middle">Categoria</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="KnowledgebaseCategorie_Ky" id="Knowledgebase_Ky" placeholder="Categoria">
<option></option>
<option value="1">
Categoria KB 1</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x data">
<div class="large-2 medium-2 small-4 cell">
<label for="Knowledgebase_Data" class="large-text-right small-text-left middle">Data</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Knowledgebase_Data" id="Knowledgebase_Data" class="input-group-field" placeholder="ricerca per Data">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="Lingue_Ky" class="large-text-right small-text-left middle">Lingua</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="Lingue_Ky" id="Knowledgebase_Ky" placeholder="Lingua">
<option></option>
<option value="5">
francese FR</option>
<option value="3">
inglese GB</option>
<option value="2">
inglese US</option>
<option value="1">
italiano IT</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x textarea">
<div class="large-2 medium-2 small-4 cell">
<label for="Knowledgebase_Keywords" class="large-text-right small-text-left middle">Keywords</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Knowledgebase_Keywords" id="Knowledgebase_Keywords" class="input-group-field" placeholder="ricerca per Keywords">
</div>
</div>
<div class="grid-x grid-padding-x">
<div class="large-12 medium-12 small-12 text-center">
<button type="submit" name="Submit" class="button success"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</button>
</div>
</div>
</form>
</fieldset>
