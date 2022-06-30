//javascript
function gotoSchedaAnagrafica(){
  $strAnagrafiche_Ky=jQuery("#Anagrafiche_Ky").val();
  $strUrl="/admin/form.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198&CoreForms_Ky=197&custom=0&azione=edit&sorgente=scheda-preventiviauto&Anagrafiche_Ky=" + $strAnagrafiche_Ky;
  //console.log($strUrl);
  var win=window.open($strUrl, '_parent');
  win.focus();
}

function inserisciAnagrafica(){
  console.log("inserisci");
}

function modificaAnagrafica(){
  console.log("modifica");
}

