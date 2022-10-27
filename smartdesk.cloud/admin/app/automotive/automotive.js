//javascript

jQuery.fn.serializeObject = function(){
  var o = {};
  var a = this.serializeArray();
  a.push({name: "ajax", value: true});
  jQuery.each(a, function() {
      if (o[this.name] !== undefined) {
          if (!o[this.name].push) {
              o[this.name] = [o[this.name]];
          }
          o[this.name].push(this.value || '');
      } else {
          o[this.name] = this.value || '';
      }
  });
  return o;
};

function gotoSchedaAnagrafica(){
  $strAnagrafiche_Ky=jQuery("#Anagrafiche_Ky").val();
  $strUrl="/admin/form.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198&CoreForms_Ky=197&custom=0&azione=edit&sorgente=scheda-preventiviauto&Anagrafiche_Ky=" + $strAnagrafiche_Ky;
  //console.log($strUrl);
  var win=window.open($strUrl, '_parent');
  win.focus();
}

function gotoSchedaTrattativa(){
  $strOpportunita_Ky=jQuery("#Opportunita_Ky").val();
  $strUrl="/admin/form.aspx?CoreModules_Ky=20&CoreEntities_Ky=138&CoreForms_Ky=202&Opportunita_Ky=" + $strOpportunita_Ky;
  //console.log($strUrl);
  var win=window.open($strUrl, '_parent');
  win.focus();
}

function inserisciAnagrafica(){
  jQuery("#formQuickEditAnagrafiche input[name=azione]").val("new");
  jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_RagioneSociale]").val("");
  jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_Nome]").val("");
  jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_Cognome]").val("");
  jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_EmailContatti]").val("");
  jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_Telefono]").val("");
  jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_Ky]").val("");
  jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_Privacy]").val("");
  jQuery("#formQuickEditAnagrafiche input[name=azione]").val("new");
}

function modificaAnagrafica(){
  jQuery("#formQuickEditAnagrafiche input[name=azione]").val("edit");
}

function salvaAnagraficaQuickEdit(){
  $strAnagrafiche_Ky=jQuery("#Anagrafiche_Ky").val();
  $strAction=jQuery("#formQuickEditAnagrafiche input[name=formaction]").val();
  $strAzione=jQuery("#formQuickEditAnagrafiche input[name=azione]").val();
      $data= { ajax:true, azione:$strAzione, Anagrafiche_Ky: jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_Ky]").val(), Utenti_Ky: jQuery("#formQuickEditAnagrafiche input[name=Utenti_Ky]").val(), AnagraficheTipo_Ky: jQuery("#formQuickEditAnagrafiche input[name=AnagraficheTipo_Ky]").val(), AnagraficheTipologia_Ky: jQuery("#formQuickEditAnagrafiche select[name=AnagraficheTipologia_Ky]").val(), Lingue_Ky: jQuery("#formQuickEditAnagrafiche input[name=Lingue_Ky]").val(), Nazioni_Ky: jQuery("#formQuickEditAnagrafiche input[name=Nazioni_Ky]").val(), Anagrafiche_RagioneSociale: jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_RagioneSociale]").val(), Anagrafiche_Nome: jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_Nome]").val(), Anagrafiche_Cognome: jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_Cognome]").val(), Anagrafiche_Telefono: jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_Telefono]").val(), Anagrafiche_EmailContatti: jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_EmailContatti]").val(), Anagrafiche_Privacy: jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_Privacy]").val(), Aziende_Ky: jQuery("#formQuickEditAnagrafiche input[name=Aziende_Ky]").val(), Anagrafiche_Attivo: jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_Attivo]").val(), Anagrafiche_Origine: "Preventivo auto" };
    	console.log($data);
    	jQuery.ajax({
    		type: "POST",
    		url: $strAction,
    		data: $data,
        contentType: "application/json"
    	})
    	.done(function( data ) {
        console.log(data);
        const $datajson = JSON.parse(data);
        if ($strAzione=="new"){
          jQuery("#Anagrafiche_Ky").val($datajson.Anagrafiche_Ky);
          jQuery("#Anagrafiche_RagioneSociale").val($datajson.Anagrafiche_RagioneSociale);
          jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_RagioneSociale]").val($datajson.Anagrafiche_RagioneSociale);
          jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_Nome]").val($datajson.Anagrafiche_Nome);
          jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_Cognome]").val($datajson.Anagrafiche_Cognome);
          jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_EmailContatti]").val($datajson.Anagrafiche_EmailContatti);
          jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_Telefono]").val($datajson.Anagrafiche_Telefono);
          jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_Ky]").val($datajson.Anagrafiche_Ky);
          jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_Privacy]").val($datajson.Anagrafiche_Privacy);
          jQuery("#formQuickEditAnagrafiche input[name=AnagraficheTipologia_Ky]").val($datajson.AnagraficheTipologia_Ky);
        }
        //info
        jQuery("#infoAnagrafiche_Nome").text($datajson.Anagrafiche_Nome);
        jQuery("#infoAnagrafiche_Cognome").text($datajson.Anagrafiche_Cognome);
        jQuery("#infoAnagrafiche_EmailContatti").text($datajson.Anagrafiche_EmailContatti);
        jQuery("#infoAnagrafiche_Telefono").text($datajson.Anagrafiche_Telefono);

        console.log($datajson.Anagrafiche_Ky);
        console.log($datajson.Anagrafiche_RagioneSociale);
        jQuery('#formQuickEditAnagrafiche').foundation('close');
      });	
}
function eliminaAccessorio(strPreventiviAutoProdotti_Ky){
  $strAction="/admin/app/automotive/crud/elimina-PreventiviAutoProdotti.aspx";
      $data= { ajax:true, azione: 'delete', Utenti_Ky: jQuery("#Utenti_Ky").val(), PreventiviAutoProdotti_Ky: strPreventiviAutoProdotti_Ky};
    	console.log($data);
    	jQuery.ajax({
    		type: "GET",
    		url: $strAction,
    		data: $data
    	})
    	.done(function( data ) {
        const $datajson = JSON.parse(data);
        jQuery('#row' + strPreventiviAutoProdotti_Ky).remove();
      });	
}

function salvaAccessorio(){
  $strAction="/admin/app/automotive/crud/salva-PreventiviAutoProdotti.aspx";
  $strAzione="new";
      $data= {ajax:true, azione:$strAzione, Utenti_Ky: jQuery("#Utenti_Ky").val(), PreventiviAuto_Ky: jQuery("#PreventiviAuto_Ky").val(), PreventiviAutoProdotti_Ky:"", PreventiviAutoProdotti_Descrizione: jQuery("#PreventiviAutoProdotti_Descrizione0").val(), PreventiviAutoProdotti_Prezzo: jQuery("#PreventiviAutoProdotti_Prezzo0").val()};
    	console.log($data);
    	jQuery.ajax({
    		type: "POST",
    		url: $strAction,
    		data: $data
    	})
    	.done(function( data ) {
        const $datajson = JSON.parse(data);
        jQuery('#tableAccessori tbody tr:last').after('<tr id="row' + $datajson.PreventiviAutoProdotti_Ky + '"><td class="hide"></td><td class="hide"></td><td>' + $datajson.PreventiviAutoProdotti_Descrizione + '</td><td>' + $datajson.PreventiviAutoProdotti_Prezzo + '</td><td><a title="elimina" onclick="eliminaAccessorio(' + $datajson.PreventiviAutoProdotti_Ky + ');"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td></tr>');
        jQuery("#PreventiviAutoProdotti_Descrizione0").val("");
        PreventiviAutoProdotti_Prezzo: jQuery("#PreventiviAutoProdotti_Prezzo0").val("");
      });	
}


function stampaDocumento(){
  var $strAzione=jQuery("#form-preventiviauto input[name=azione]").val();
  var $data = jQuery('#form-preventiviauto').serializeObject();
  //console.log($data);
  $strAction=jQuery("#form-preventiviauto input[name=formaction]").val();
  //console.log($strAction);
	jQuery.ajax({
		type: "POST",
		url: $strAction,
		data: $data
	})
	.done(function( $data ) {
    //console.log($data);
    const $datajson = JSON.parse($data);
  });	
  var $strPreventiviAuto_Ky=jQuery("#PreventiviAuto_Ky").val();
  var $strUrl = "/admin/app/automotive/report/rpt-preventiviauto.aspx?PreventiviAuto_Ky=" + $strPreventiviAuto_Ky;
  var win=window.open($strUrl, '_blank');
  win.focus();
}

function AnagraficheTipologia_Ky_Change(selectObject){
  $AnagraficheTipologia_Ky=selectObject.value;
  switch ($AnagraficheTipologia_Ky){
    case "1":
      jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_RagioneSociale]").hide();
      jQuery("#formQuickEditAnagrafiche #lblAnagrafiche_RagioneSocialeForm").hide();
      break;
    case "2":
      jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_RagioneSociale]").show();
      jQuery("#formQuickEditAnagrafiche #lblAnagrafiche_RagioneSocialeForm").show();
      break;
    case "3":
      jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_RagioneSociale]").show();
      jQuery("#formQuickEditAnagrafiche #lblAnagrafiche_RagioneSocialeForm").show();
      break;
    case "4":
      jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_RagioneSociale]").show();
      jQuery("#formQuickEditAnagrafiche #lblAnagrafiche_RagioneSocialeForm").show();
      break;
    case "5":
      jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_RagioneSociale]").show();
      jQuery("#formQuickEditAnagrafiche #lblAnagrafiche_RagioneSocialeForm").show();
      break;
    case "6":
      jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_RagioneSociale]").show();
      jQuery("#formQuickEditAnagrafiche #lblAnagrafiche_RagioneSocialeForm").show();
      break;
    case "7":
      jQuery("#formQuickEditAnagrafiche input[name=Anagrafiche_RagioneSociale]").show();
      jQuery("#formQuickEditAnagrafiche #lblAnagrafiche_RagioneSocialeForm").show();
      break;
  }
}

