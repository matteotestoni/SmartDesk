<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
	<legend>Cerca note</legend>
	<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/veicoli/elenco-veicoli.aspx">
    <div class="grid-x grid-padding-x">
	    <div class="large-2 medium-2 small-3 cell">
	      <label for="Veicoli_Annuncio" class="large-text-right small-text-left middle">Ricerca per annuncio</label>
	    </div>
    	<div class="large-8 medium-8 small-6 cell">
				<input type="text" name="Veicoli_Annuncio" id="Veicoli_Annuncio" size="28" placeholder="ricerca per marca" />
			</div>
	    <div class="cell shrink">
      	<button type="submit" value="cerca" name="cerca" class="button postfix secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
      </div>
    </div>
  </form>
	<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/veicoli/elenco-veicoli.aspx">
    <div class="grid-x grid-padding-x">
	    <div class="large-2 medium-2 small-3 cell">
	      <label for="Veicoli_Riferimento" class="large-text-right small-text-left middle">Ricerca per riferimento</label>
	    </div>
    	<div class="large-8 medium-8 small-6 cell">
				<input type="text" name="Veicoli_Riferimento" id="Veicoli_Riferimento" size="28" placeholder="ricerca per riferimento" />
			</div>
	    <div class="cell shrink">
      	<button type="submit" value="cerca" name="cerca" class="button postfix secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
      </div>
    </div>
  </form>
	<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/veicoli/elenco-veicoli.aspx">
    <div class="grid-x grid-padding-x">
	    <div class="large-2 medium-2 small-3 cell">
	      <label for="Veicoli_Targa" class="large-text-right small-text-left middle">Ricerca per targa</label>
	    </div>
    	<div class="large-8 medium-8 small-6 cell">
				<input type="text" name="Veicoli_Targa" id="Veicoli_Targa" size="28" placeholder="ricerca per targa" />
			</div>
	    <div class="cell shrink">
      	<button type="submit" value="cerca" name="cerca" class="button postfix secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
      </div>
    </div>
  </form>
</fieldset>
