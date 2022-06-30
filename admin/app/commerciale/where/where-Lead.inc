<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="20" />
<input type="hidden" name="CoreEntities_Ky" value="185" />
<input type="hidden" name="CoreGrids_Ky" value="175" />
<div class="grid-x grid-padding-x number">
  <div class="large-2 medium-2 small-4 cell">
  <label for="Lead_Ky" class="large-text-right small-text-left middle">Codice</label>
  </div>
  <div class="large-10 medium-10 small-8 cell">
  <input type="text" name="Lead_Ky" id="Lead_Ky" class="input-group-field" placeholder="ricerca per Codice">
  </div>
</div>
<div class="grid-x grid-padding-x text">
  <div class="large-2 medium-2 small-4 cell">
  <label for="Lead_Titolo" class="large-text-right small-text-left middle">Titolo</label>
  </div>
  <div class="large-10 medium-10 small-8 cell">
  <input type="text" name="Lead_Titolo" id="Lead_Titolo" class="input-group-field" placeholder="ricerca per Titolo">
  </div>
</div>
<div class="grid-x grid-padding-x data">
  <div class="large-2 medium-2 small-4 cell">
  <label for="Lead_Data" class="large-text-right small-text-left middle">Data</label>
  </div>
  <div class="large-10 medium-10 small-8 cell">
  <input type="text" name="Lead_Data" id="Lead_Data" class="input-group-field" placeholder="ricerca per Data">
  </div>
</div>
<div class="grid-x grid-padding-x join">
  <div class="large-2 medium-2 small-4 cell">
  <label for="LeadTipo_Ky" class="large-text-right small-text-left middle">Tipo</label>
  </div>
  <div class="large-10 medium-10 small-8 cell">
    <select name="LeadTipo_Ky" id="LeadTipo_Ky" placeholder="Tipo">
    </select>
    <script>
    console.log(window.location.hostname);
    jQuery(document).ready(function(){
        console.log("LeadTipo.json");
        url='https://' + window.location.hostname + '/var/cache/json/LeadTipo.json';
        console.log(url);
        let dropdown = jQuery('#LeadTipo_Ky');
        dropdown.empty();
        dropdown.append('<option selected="true" disabled></option>');
        dropdown.prop('selectedIndex', 0);
        jQuery.getJSON(url, function (data) {
          console.log(data);
          jQuery.each(data, function (key, entry) {
            dropdown.append(jQuery('<option></option>').attr('value', entry.LeadTipo_Ky).text(entry.LeadTipo_Titolo));
          })
        });
    });
    </script>  
  </div>
</div>
<div class="grid-x grid-padding-x join">
  <div class="large-2 medium-2 small-4 cell">
  <label for="LeadStato_Ky" class="large-text-right small-text-left middle">Stato</label>
  </div>
  <div class="large-10 medium-10 small-8 cell">
    <select name="LeadStato_Ky" id="LeadStato_Ky" placeholder="Sorgente">
    </select>
    <script>
    jQuery(document).ready(function(){
        console.log("LeadStato.json");
        let dropdown = jQuery('#LeadStato_Ky');
        dropdown.empty();
        dropdown.append('<option selected="true" disabled></option>');
        dropdown.prop('selectedIndex', 0);
        jQuery.getJSON('/var/cache/json/LeadStato.json', function (data) {
        console.log(data);
          jQuery.each(data, function (key, entry) {
           console.log(entry);
           dropdown.append(jQuery('<option></option>').attr('value', entry.LeadStato_Ky).text(entry.LeadStato_Titolo));
          })
        });
    });
    </script>  
  </div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="LeadSorgenti_Ky" class="large-text-right small-text-left middle">Sorgente</label>
</div>
<div class="large-10 medium-10 small-8 cell">
  <select name="LeadSorgenti_Ky" id="LeadSorgenti_Ky" placeholder="Sorgente">
  </select>
  <script>
  jQuery(document).ready(function(){
      console.log("LeadSorgenti.json");
      let dropdown = jQuery('#LeadSorgenti_Ky');
      dropdown.empty();
      dropdown.append('<option selected="true" disabled></option>');
      dropdown.prop('selectedIndex', 0);
      jQuery.getJSON('/var/cache/json/LeadSorgenti.json', function (data) {
        jQuery.each(data, function (key, entry) {
          dropdown.append(jQuery('<option></option>').attr('value', entry.LeadSorgenti_Ky).text(entry.LeadSorgenti_Titolo));
        })
      });
  });
  </script>  
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="LeadCategorie_Ky" class="large-text-right small-text-left middle">Categoria</label>
</div>
<div class="large-10 medium-10 small-8 cell">
  <select name="LeadCategorie_Ky" id="LeadCategorie_Ky" placeholder="Categoria">
  </select>
  <script>
  jQuery(document).ready(function(){
      console.log("LeadCategorie.json");
      let dropdown = jQuery('#LeadCategorie_Ky');
      dropdown.empty();
      dropdown.append('<option selected="true" disabled></option>');
      dropdown.prop('selectedIndex', 0);
      jQuery.getJSON('/var/cache/json/LeadCategorie.json', function (data) {
        jQuery.each(data, function (key, entry) {
          dropdown.append(jQuery('<option></option>').attr('value', entry.LeadCategorie_Ky).text(entry.LeadCategorie_Titolo));
        })
      });
  });
  </script>  
</div>
</div>
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 text-center">
    <button type="submit" name="Submit" class="button success"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</button>
  </div>
</div>
</form>
</fieldset>
