<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
		<legend>Cerca</legend>
		<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/progetti/elenco-commesse.aspx">
	  	<input type="hidden" name="CoreModules_Ky" value="24" />
	  	<input type="hidden" name="CoreEntities_Ky" value="107" />
	  	<input type="hidden" name="CoreGrids_Ky" value="118" />
			<div class="grid-x grid-padding-x">
		    <div class="large-2 medium-2 small-3 cell">
		      <label for="right-label" class="large-text-right small-text-left middle" for="Commesse_Riferimenti">Ricerca per riferimento</label>
		    </div>
		    <div class="large-8 medium-8 small-6 cell">
			  	<input type="text" class="input-group-field" name="Commesse_Riferimenti" id="Commesse_Riferimenti" placeholder="ricerca per riferimento" />
		    </div>
		    <div class="large-2 medium-2 small-3 cell">
			    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
		    </div>
		  </div>
	  </form>
		<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/progetti/elenco-commesse.aspx">
	  	<input type="hidden" name="CoreModules_Ky" value="24" />
	  	<input type="hidden" name="CoreEntities_Ky" value="107" />
	  	<input type="hidden" name="CoreGrids_Ky" value="118" />
			<div class="grid-x grid-padding-x">
		    <div class="large-2 medium-2 small-3 cell">
		      <label for="right-label" class="large-text-right small-text-left middle" for="Commesse_Titolo">Ricerca per titolo</label>
		    </div>
		    <div class="large-8 medium-8 small-6 cell">
			  	<input type="text" class="input-group-field" name="Commesse_Titolo" id="Commesse_Titolo" placeholder="ricerca per titolo" />
		    </div>
		    <div class="large-2 medium-2 small-3 cell">
			    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
		    </div>
		  </div>
	  </form>
		<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/progetti/elenco-commesse.aspx">
	  	<input type="hidden" name="CoreModules_Ky" value="24" />
	  	<input type="hidden" name="CoreEntities_Ky" value="107" />
	  	<input type="hidden" name="CoreGrids_Ky" value="118" />
			<div class="grid-x grid-padding-x">
		    <div class="large-2 medium-2 small-3 cell">
		      <label for="CommesseStato_Ky" class="large-text-right small-text-left middle">Ricerca per stato</label>
		    </div>
		    <div class="large-8 medium-8 small-6 cell">
          <select name="CommesseStato_Ky" id="CommesseStato_Ky" value="" required="required">
            <!--#include file="/var/cache/CommesseStato-options.htm"--> 
          </select>
		    </div>
		    <div class="large-2 medium-2 small-3 cell">
			    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
		    </div>
		  </div>
	  </form>
		<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/progetti/elenco-commesse.aspx">
	  	<input type="hidden" name="CoreModules_Ky" value="24" />
	  	<input type="hidden" name="CoreEntities_Ky" value="107" />
	  	<input type="hidden" name="CoreGrids_Ky" value="118" />
			<div class="grid-x grid-padding-x">
		    <div class="large-2 medium-2 small-3 cell">
		      <label for="Commesse_Tags" class="large-text-right small-text-left middle">Ricerca per Tag</label>
		    </div>
		    <div class="large-8 medium-8 small-6 cell">
          <select name="Commesse_Tags" id="Commesse_Tags" value="" required="required">
            <!--#include file="/var/cache/CommesseTags-options.htm"--> 
          </select>
		    </div>
		    <div class="large-2 medium-2 small-3 cell">
			    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
		    </div>
		  </div>
	  </form>
		<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/progetti/elenco-commesse.aspx">
	  	<input type="hidden" name="CoreModules_Ky" value="24" />
	  	<input type="hidden" name="CoreEntities_Ky" value="107" />
	  	<input type="hidden" name="CoreGrids_Ky" value="118" />
			<div class="grid-x grid-padding-x">
		    <div class="large-2 medium-2 small-3 cell">
		      <label for="anno" class="large-text-right small-text-left middle">Ricerca per anno</label>
		    </div>
		    <div class="large-8 medium-8 small-6 cell">
			  	<input type="text" class="input-group-field" name="anno" id="anno" placeholder="ricerca per anno" />
		    </div>
		    <div class="large-2 medium-2 small-3 cell">
			    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
		    </div>
		  </div>
	  </form>
		<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/progetti/elenco-commesse.aspx">
	  	<input type="hidden" name="CoreModules_Ky" value="24" />
	  	<input type="hidden" name="CoreEntities_Ky" value="107" />
	  	<input type="hidden" name="CoreGrids_Ky" value="118" />
			<div class="grid-x grid-padding-x">
		    <div class="large-2 medium-2 small-3 cell">
		      <label for="Commesse_Riferimenti" class="large-text-right small-text-left middle">Ricerca per Riferimento</label>
		    </div>
		    <div class="large-8 medium-8 small-6 cell">
			  	<input type="text" name="Commesse_Riferimenti" id="Commesse_Riferimenti" placeholder="ricerca per riferimento" />
		    </div>
				<div class="large-2 medium-2 small-3 cell">
			    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
		    </div>
			</div>
	  </form>
		<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/progetti/elenco-commesse.aspx">
	  	<input type="hidden" name="CoreModules_Ky" value="24" />
	  	<input type="hidden" name="CoreEntities_Ky" value="107" />
	  	<input type="hidden" name="CoreGrids_Ky" value="118" />
			<div class="grid-x grid-padding-x">
		    <div class="large-2 medium-2 small-3 cell">
		      <label for="Anagrafiche_RagioneSociale" class="large-text-right small-text-left middle">Ricerca per Ragione sociale</label>
		    </div>
		    <div class="large-8 medium-8 small-6 cell">
			  	<input type="text" name="Anagrafiche_RagioneSociale" id="Anagrafiche_RagioneSociale" placeholder="ricerca per ragione sociale" />
		    </div>
		    <div class="large-2 medium-2 small-3 cell">
			    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
		    </div>
		  </div>
	  </form>
</fieldset>
