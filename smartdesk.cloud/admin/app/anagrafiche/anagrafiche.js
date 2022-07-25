//javascript
function AnagraficheTipologia_Ky_Change(selectObject){
  $AnagraficheTipo_Ky=selectObject.value;
  switch ($AnagraficheTipo_Ky){
    case "1":
      jQuery("#Anagrafiche_PartitaIVA").hide();
      jQuery("#lblAnagrafiche_PartitaIVA").hide();
      break;
    case "2":
      jQuery("#Anagrafiche_PartitaIVA").show();
      jQuery("#lblAnagrafiche_PartitaIVA").show();
      break;
    case "3":
      jQuery("#Anagrafiche_PartitaIVA").show();
      jQuery("#lblAnagrafiche_PartitaIVA").show();
      break;
    case "4":
      jQuery("#Anagrafiche_PartitaIVA").show();
      jQuery("#lblAnagrafiche_PartitaIVA").show();
      break;
    case "5":
      jQuery("#Anagrafiche_PartitaIVA").show();
      jQuery("#lblAnagrafiche_PartitaIVA").show();
      break;
    case "6":
      jQuery("#Anagrafiche_PartitaIVA").show();
      jQuery("#lblAnagrafiche_PartitaIVA").show();
      break;
    case "7":
      jQuery("#Anagrafiche_PartitaIVA").show();
      jQuery("#lblAnagrafiche_PartitaIVA").show();
      break;
  }
  console.log($AnagraficheTipo_Ky);
}
