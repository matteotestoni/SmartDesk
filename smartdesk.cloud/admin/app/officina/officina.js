//javascript

jQuery( document ).ready(function() {
    jQuery("input[type=radio][name=OfficinaTipoauto_Ky]") .change(function () {    
      switch (this.value){
        case "1":
          jQuery("#Officina_Mapo").prop('checked', true);
          break;
        case "2":
          jQuery("#Officina_Mapo").prop('checked', false);
          break;
        case "3":
          jQuery("#Officina_Mapo").prop('checked', true);
          break;
      }
    });  
    
  /*
  jQuery('#Officina_TargaVettura').on('change',function(e){
      if (jQuery(#azione).val()=="new"){
      
      }
      alert(jQuery(this).val());
      
  });*/  
});

function printschedaofficina(){
  var strKy=jQuery("#Officina_Ky").val();
  var strUrl="/admin/app/officina/report/rpt-scheda-officina.aspx?Officina_Ky=" + strKy;
  //console.log(strUrl);
  window.open(strUrl,'_blank');
}

function printschedaofficinaaccettazione(){
  var strKy=jQuery("#Officina_Ky").val();
  var strUrl="/admin/app/officina/report/rpt-scheda-officina-accettazione.aspx?Officina_Ky=" + strKy;
  //console.log(strUrl);
  window.open(strUrl,'_blank');
}

function printschedaofficinapreparazione(){
  var strKy=jQuery("#Officina_Ky").val();
  var strUrl="/admin/app/officina/report/rpt-scheda-officina-preparazione.aspx?Officina_Ky=" + strKy;
  //console.log(strUrl);
  window.open(strUrl,'_blank');
}
function dapreparare(){
  var strUtenti_Ky=jQuery("#Utenti_Ky").val();
  var strKy=jQuery("#Officina_Ky").val();
  var strValue=jQuery('input[name=OfficinaStati_Ky]:checked').val();
  //console.log(strUtenti_Ky);
  //console.log(strKy);
  //console.log(strValue);
	$url="/admin/app/officina/actions/officina-cambiastato.aspx";
	$data= { ajax:true, Officina_Ky: strKy, OfficinaStati_Ky: 1, Utenti_Ky: strUtenti_Ky };
	//console.log($data);
	jQuery.ajax({
		type: "POST",
		url: $url,
		data: $data,
    contentType: "application/json"
	})
	.done(function( data ) {
    jQuery('input:radio[name="OfficinaStati_Ky"]').filter('[value="'+ strValue + '"]').attr('checked', false);
    jQuery('input:radio[name="OfficinaStati_Ky"]').filter('[value="1"]').attr('checked', true);
		alert( "Auto da preparare per i preparatori.");
    location.reload();
  	});	
}

function consegnata(){
  var strUtenti_Ky=jQuery("#Utenti_Ky").val();
  var strKy=jQuery("#Officina_Ky").val();
  var strValue=jQuery('input[name=OfficinaStati_Ky]:checked').val();
  //console.log(strUtenti_Ky);
  //console.log(strKy);
  //console.log(strValue);
	$url="/admin/app/officina/actions/officina-cambiastato.aspx";
	$data= { ajax:true, Officina_Ky: strKy, OfficinaStati_Ky: 4, Utenti_Ky: strUtenti_Ky };
	console.log($data);
	jQuery.ajax({
		type: "POST",
		url: $url,
		data: $data,
    contentType: "application/json"
	})
	.done(function( data ) {
    jQuery('input:radio[name="OfficinaStati_Ky"]').filter('[value="'+ strValue + '"]').attr('checked', false);
    jQuery('input:radio[name="OfficinaStati_Ky"]').filter('[value="4"]').attr('checked', true);
		alert( "Auto consegnata ed intervento officina chiuso.");
    location.reload();
  	});	
}

function inlavorazione(){
  var strUtenti_Ky=jQuery("#Utenti_Ky").val();
  var strKy=jQuery("#Officina_Ky").val();
  var strValue=jQuery('input[name=OfficinaStati_Ky]:checked').val();
	$url="/admin/app/officina/actions/officina-cambiastato.aspx";
	$data= { ajax:true, Officina_Ky: strKy, OfficinaStati_Ky: 2, Utenti_Ky: strUtenti_Ky };
	//console.log($data);
	jQuery.ajax({
		type: "POST",
		url: $url,
		data: $data,
    contentType: "application/json"
	})
	.done(function( data ) {
    jQuery('input:radio[name="OfficinaStati_Ky"]').filter('[value="'+ strValue + '"]').attr('checked', false);
    jQuery('input:radio[name="OfficinaStati_Ky"]').filter('[value="2"]').attr('checked', true);
		alert( "Auto in lavorazione. Il preparatore dovrà ora procedere con gli interventi richiesti.");
    location.reload();
  	});	
}

function pronta(){
  var strUtenti_Ky=jQuery("#Utenti_Ky").val();
  var strKy=jQuery("#Officina_Ky").val();
  var strValue=jQuery('input[name=OfficinaStati_Ky]:checked').val();
	$url="/admin/app/officina/actions/officina-cambiastato.aspx";
	$data= { ajax:true, Officina_Ky: strKy, OfficinaStati_Ky: 3, Utenti_Ky: strUtenti_Ky };
	//console.log($data);
	jQuery.ajax({
		type: "POST",
		url: $url,
		data: $data,
    contentType: "application/json"
	})
	.done(function( data ) {
    jQuery('input:radio[name="OfficinaStati_Ky"]').filter('[value="'+ strValue + '"]').attr('checked', false);
    jQuery('input:radio[name="OfficinaStati_Ky"]').filter('[value="3"]').attr('checked', true);
		alert( "Auto pronta. L'accettazione dovrà ora fissare l'appuntamento con il cliente per la consegna.");
    location.reload();
  	});	
}

