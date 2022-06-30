<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="30" />
<input type="hidden" name="CoreEntities_Ky" value="166" />
<input type="hidden" name="CoreGrids_Ky" value="153" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="Passwordmanager_Ky" class="large-text-right small-text-left middle">id</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Passwordmanager_Ky" id="Passwordmanager_Ky" class="input-group-field" placeholder="ricerca per id">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Passwordmanager_Titolo" class="large-text-right small-text-left middle">Titolo</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Passwordmanager_Titolo" id="Passwordmanager_Titolo" class="input-group-field" placeholder="ricerca per Titolo">
</div>
</div>
<div class="grid-x grid-padding-x textarea">
<div class="large-2 medium-2 small-4 cell">
<label for="Passwordmanager_Descrizione" class="large-text-right small-text-left middle">Descrizione</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Passwordmanager_Descrizione" id="Passwordmanager_Descrizione" class="input-group-field" placeholder="ricerca per Descrizione">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="PasswordmanagerCategorie_Ky" class="large-text-right small-text-left middle">Categoria</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="PasswordmanagerCategorie_Ky" id="Passwordmanager_Ky" placeholder="Categoria">
<option></option>
<option value="5">
Accesso Cpanel</option>
<option value="7">
Accesso Facebook</option>
<option value="1">
Accesso ftp</option>
<option value="18">
Accesso Google</option>
<option value="15">
Accesso Instagram</option>
<option value="3">
Accesso Magento</option>
<option value="14">
Accesso mailchimp</option>
<option value="16">
Accesso MailUp</option>
<option value="12">
Accesso MySql</option>
<option value="13">
Accesso PEC</option>
<option value="4">
Accesso Plesk</option>
<option value="11">
Accesso postmaster</option>
<option value="10">
Accesso Prestashop</option>
<option value="9">
Accesso sito</option>
<option value="6">
Accesso ssh</option>
<option value="8">
Accesso Vimeo</option>
<option value="17">
Accesso WiFi</option>
<option value="2">
Accesso Wordpress</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Passwordmanager_Username" class="large-text-right small-text-left middle">Username</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Passwordmanager_Username" id="Passwordmanager_Username" class="input-group-field" placeholder="ricerca per Username">
</div>
</div>
<div class="grid-x grid-padding-x">
<div class="large-12 medium-12 small-12 text-center">
<button type="submit" name="Submit" class="button success"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</button>
</div>
</div>
</form>
</fieldset>
