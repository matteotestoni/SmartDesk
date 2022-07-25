<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="21" />
<input type="hidden" name="CoreEntities_Ky" value="75" />
<input type="hidden" name="CoreGrids_Ky" value="233" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="Pagamenti_Ky" class="large-text-right small-text-left middle">id</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Pagamenti_Ky" id="Pagamenti_Ky" class="input-group-field" placeholder="ricerca per id">
</div>
</div>
<div class="grid-x grid-padding-x join">
  <div class="large-2 medium-2 small-4 cell">
    <label for="Anagrafiche_Ky" class="large-text-right small-text-left middle">Anagrafica</label>
  </div>
  <div class="large-10 medium-10 small-8 cell">
    <div class="grid-x grid-padding-x">
    <div class="auto cell"><input type="text" name="Anagrafiche_RagioneSociale" id="Anagrafiche_RagioneSociale" placeholder="Anagrafica"></div>
    <script type="text/javascript">
    		jQuery("#Anagrafiche_RagioneSociale").autocomplete({
    			source: "/admin/app/pagamenti/autosuggest-GetAnagrafiche-json.aspx",
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
<label for="Conti_Ky" class="large-text-right small-text-left middle">Conto</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="Conti_Ky" id="Pagamenti_Ky" placeholder="Conto">
<option></option>
<option value="1">
C/C Banca Annia</option>
<option value="2">
C/C TFM</option>
<option value="3">
Cassa</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x data">
<div class="large-2 medium-2 small-4 cell">
<label for="Pagamenti_Data" class="large-text-right small-text-left middle">Scadenza</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Pagamenti_Data" id="Pagamenti_Data" class="input-group-field" placeholder="ricerca per Scadenza">
</div>
</div>
<div class="grid-x grid-padding-x data">
<div class="large-2 medium-2 small-4 cell">
<label for="Pagamenti_DataPagato" class="large-text-right small-text-left middle">Pagato il</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Pagamenti_DataPagato" id="Pagamenti_DataPagato" class="input-group-field" placeholder="ricerca per Pagato il">
</div>
</div>

<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Pagamenti_Riferimenti" class="large-text-right small-text-left middle">Riferimenti</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Pagamenti_Riferimenti" id="Pagamenti_Riferimenti" class="input-group-field" placeholder="ricerca per Riferimenti">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="PagamentiMetodo_Ky" class="large-text-right small-text-left middle">Metodo pagamento</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="PagamentiMetodo_Ky" id="Pagamenti_Ky" placeholder="Metodo pagamento">
<option></option>
<option value="2">
Assegno</option>
<option value="1">
Bonifico</option>
<option value="4">
Carta di Credito</option>
<option value="3">
Contanti</option>
<option value="6">
Paypal</option>
<option value="7">
RID</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="PagamentiTipo_Ky" class="large-text-right small-text-left middle">Tipo pagamento</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="PagamentiTipo_Ky" id="Pagamenti_Ky" placeholder="Tipo pagamento">
<option></option>
<option value="1">
in entrata</option>
<option value="2">
In uscita</option>
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
