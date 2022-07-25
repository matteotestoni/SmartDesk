<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
	<legend>Cerca spese</legend>
    <% if (dtLogin.Rows[0]["UtentiGruppi_Anagrafiche"].Equals(true)){ %>
		<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/amministrazione/elenco-spese.aspx">
      <input type="hidden" name="CoreModules_Ky" value="2">
      <input type="hidden" name="CoreEntities_Ky" value="1">
      <input type="hidden" name="CoreGrids_Ky" value="1">
			<div class="grid-x grid-padding-x">
		    <div class="large-2 medium-2 small-3 cell">
		      <label for="Anagrafiche_RagioneSociale" class="large-text-right small-text-left middle">Ricerca per Fornitore</label>
		    </div>
		    <div class="large-8 medium-8 small-6 cell">
			  	<input type="text" name="Anagrafiche_RagioneSociale" id="Anagrafiche_RagioneSociale" placeholder="ricerca per Fornitore" />
		    </div>
		    <div class="large-2 medium-2 small-3 cell">
			    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
		    </div>
		  </div>
	  </form>
    <% } %>
    <% if (dtLogin.Rows[0]["UtentiGruppi_Anagrafiche"].Equals(true)){ %>
		<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/amministrazione/elenco-spese.aspx">
      <input type="hidden" name="CoreModules_Ky" value="2">
      <input type="hidden" name="CoreEntities_Ky" value="1">
      <input type="hidden" name="CoreGrids_Ky" value="1">
			<div class="grid-x grid-padding-x">
		    <div class="large-2 medium-2 small-3 cell">
		      <label for="Anagrafiche_ClienteRagioneSociale" class="large-text-right small-text-left middle">Ricerca per Cliente</label>
		    </div>
		    <div class="large-8 medium-8 small-6 cell">
			  	<input type="text" name="Anagrafiche_ClienteRagioneSociale" id="Anagrafiche_ClienteRagioneSociale" placeholder="ricerca per Cliente" />
		    </div>
		    <div class="large-2 medium-2 small-3 cell">
			    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
		    </div>
		  </div>
	  </form>
    <% } %>
		<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/amministrazione/elenco-spese.aspx">
      <input type="hidden" name="CoreModules_Ky" value="2">
      <input type="hidden" name="CoreEntities_Ky" value="1">
      <input type="hidden" name="CoreGrids_Ky" value="1">
			<div class="grid-x grid-padding-x">
		    <div class="large-2 medium-2 small-3 cell">
		      <label for="CentridiCR_Ky" class="large-text-right small-text-left middle">Ricerca per centro di costo</label>
		    </div>
		    <div class="large-8 medium-8 small-6 cell">
        	<select name="CentridiCR_Ky" id="CentridiCR_Ky" required="required" placeholder="Centro di costo">
            <option value=""></option>
						<!--#include file="/var/cache/CentridiCR-options.htm"--> 
          </select>
		    </div>
		    <div class="large-2 medium-2 small-3 cell">
			    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
		    </div>
		  </div>
	  </form>
		<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/amministrazione/elenco-spese.aspx">
      <input type="hidden" name="CoreModules_Ky" value="2">
      <input type="hidden" name="CoreEntities_Ky" value="1">
      <input type="hidden" name="CoreGrids_Ky" value="1">
			<div class="grid-x grid-padding-x">
		    <div class="large-2 medium-2 small-3 cell">
		      <label for="Conti_Ky" class="large-text-right small-text-left middle">Ricerca per conto</label>
		    </div>
		    <div class="large-8 medium-8 small-6 cell">
        	<select name="Conti_Ky" id="Conti_Ky" required="required" placeholder="Conto">
            <option value=""></option>
						<!--#include file="/var/cache/Conti-options.htm"--> 
          </select>
		    </div>
		    <div class="large-2 medium-2 small-3 cell">
			    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
		    </div>
		  </div>
	  </form>
		<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/amministrazione/elenco-spese.aspx">
      <input type="hidden" name="CoreModules_Ky" value="2">
      <input type="hidden" name="CoreEntities_Ky" value="1">
      <input type="hidden" name="CoreGrids_Ky" value="1">
			<div class="grid-x grid-padding-x">
		    <div class="large-2 medium-2 small-3 cell">
		      <label for="CentridiCR_Titolo" class="large-text-right small-text-left middle">Ricerca per titolo</label>
		    </div>
		    <div class="large-8 medium-8 small-6 cell">
          <input type="text" name="CentridiCR_Titolo" id="CentridiCR_Titolo" title="Titolo" value="" size="60">
		    </div>
		    <div class="large-2 medium-2 small-3 cell">
			    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
		    </div>
		  </div>
	  </form>
</fieldset>		    
