<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
	<legend>Cerca</legend>
	<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
    <input type="hidden" name="apertachiusa" id="apertachiusa" value="3">
    <input type="hidden" name="CoreModules_Ky" id="CoreModules_Ky" value="20">
    <input type="hidden" name="CoreEntities_Ky" id="CoreEntities_Ky" value="138">
    <input type="hidden" name="CoreGrids_Ky" id="CoreGrids_Ky" value="107">
		<div class="grid-x grid-padding-x">
	    <div class="large-2 medium-2 small-3 cell">
	      <label for="Anagrafiche_RagioneSociale" class="large-text-right small-text-left middle">Ricerca per Ragione sociale</label>
	    </div>
	    <div class="large-10 medium-10 small-9 cell">
		  	<input type="text" name="Anagrafiche_RagioneSociale" id="Anagrafiche_RagioneSociale" placeholder="ricerca per ragione sociale" />
	    </div>
	  </div>

		<div class="grid-x grid-padding-x">
	    <div class="large-2 medium-2 small-3 cell">
	      <label for="Opportunita_Titolo" class="large-text-right small-text-left middle">Ricerca per titolo</label>
	    </div>
	    <div class="large-10 medium-10 small-9 cell">
		  	<input type="text" name="Opportunita_Titolo" id="Opportunita_Titolo" placeholder="ricerca per titolo" />
	    </div>
	  </div>


    <div class="grid-x grid-padding-x">
	    <div class="large-2 medium-2 small-3 cell">
	      <label for="OpportunitaStati_Ky" class="large-text-right small-text-left middle">Ricerca per stato</label>
	    </div>
    	<div class="small-10 large-10 medium-9 cell">
        <select name="OpportunitaStati_Ky" id="OpportunitaStati_Ky" onchange="this.form.submit()">
          <option value=""></option>
          <!--#include file="/var/cache/OpportunitaStati-options.htm"--> 
        </select>
        <script type="text/javascript">
          selectSet('OpportunitaStati_Ky', '<%=Request["OpportunitaStati_Ky"]%>');
        </script>
			</div>
    </div>

    <div class="grid-x grid-padding-x">
	    <div class="large-2 medium-2 small-3 cell">
	      <label for="mese" class="large-text-right small-text-left middle">Ricerca per mese</label>
	    </div>
    	<div class="small-10 large-10 medium-9 cell">
        <select name="mese" id="mese" onchange="this.form.submit()">
          <option value=""></option>
          <!--#include file="/var/cache/Mesi-options.htm"--> 
        </select>
        <script type="text/javascript">
          selectSet('mese', '<%=Request["mese"]%>');
        </script>
			</div>
    </div>

    <div class="grid-x grid-padding-x">
	    <div class="large-2 medium-2 small-3 cell">
	      <label for="mese" class="large-text-right small-text-left middle">Ricerca per sorgente</label>
	    </div>
    	<div class="small-10 large-10 medium-9 cell">
        <select name="OpportunitaSorgenti_Ky" id="OpportunitaSorgenti_Ky" onchange="this.form.submit()">
          <option value=""></option>
          <!--#include file="/var/cache/OpportunitaSorgenti-options.htm"--> 
        </select>
        <script type="text/javascript">
          selectSet('OpportunitaSorgenti_Ky', '<%=Request["OpportunitaSorgenti_Ky"]%>');
        </script>
			</div>
    </div>

		<div class="grid-x grid-padding-x">
			<div class="small-12 large-12 medium-12 cell text-center">
	     	  <a href="/admin/app/commerciale/elenco-opportunita.aspx?tutti=tutti" class="button secondary"><i class="fa-duotone fa-filter fa-fw"></i>Tutti</a>
				<button type="submit" value="cerca" name="cerca" class="button postfix cerca"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</button>
			</div>
		</div>
  </form>
</fieldset>
