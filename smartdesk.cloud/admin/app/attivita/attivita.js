//javascript
function chgData(){
  var strData=jQuery("#Attivita_Inizio").val();
  //strData=strData.replace(" ","T");
  //console.log(strData);
  jQuery("#Attivita_Scadenza").val(strData);
  jQuery("#Attivita_Chiusura").val(strData);
  jQuery("#Attivita_Inizio").val(strData);
  if (jQuery("#Attivita_Ore").val()==null || jQuery("#Attivita_Ore").val()==undefined){
    selectSet("Attivita_Ore","1.0");
  }


}

