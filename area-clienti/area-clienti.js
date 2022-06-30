jQuery.noConflict();
	jQuery(function() {
		jQuery(".contenuto" ).tooltip({
			show: {
				duration: "fast"
			},
			hide: {
				effect: "blind"
			},
			position: {
				my: "center bottom-20",
				at: "center top",
				using: function( position, feedback ) {
					jQuery( this ).css( position );
					jQuery( "<div>" )
						.addClass( "arrow" )
						.addClass( feedback.vertical )
						.addClass( feedback.horizontal )
						.appendTo( this );
				}
			}
			
		});
		jQuery( "#beginning" ).button({
			text: false,
			icons: {
				primary: "ui-icon-seek-start"
			}
		});
		jQuery( "#rewind" ).button({
			text: false,
			icons: {
				primary: "ui-icon-seek-prev"
			}
		});
		jQuery( "#forward" ).button({
			text: false,
			icons: {
				primary: "ui-icon-seek-next"
			}
		});
		jQuery( "#end" ).button({
			text: false,
			icons: {
				primary: "ui-icon-seek-end"
			}
		});		
		jQuery(".tabs" ).tabs();
		jQuery(".radio").buttonset();
		jQuery(".spinner" ).spinner();
		//jQuery(".selectmenu" ).selectmenu();
		jQuery("input:submit", ".contenuto" ).button();
		jQuery(".ui-button-primary").button({
			text: true,
			icons: {
				primary: "ui-icon-plusthick"
			}
		});		
		jQuery(".button").button({
			text: true,
			icons: {
				primary: null,secondary: null
			}
		});
		jQuery(".salva").button({
			text: true,
			icons: {
				primary: "ui-icon-disk"
			}
		});
		jQuery(".inserisci").button({
			text: true,
			icons: {
				primary: "ui-icon-plusthick"
			}
		});
		jQuery(".nuovo").button({
			text: true,
			icons: {
				primary: "ui-icon-plusthick"
			}
		});
		jQuery(".print").button({
			text: true,
			icons: {
				primary: "ui-icon-print"
			}
		});
		jQuery(".cerca").button({
			text: true,
			icons: {
				primary: "ui-icon-search"
			}
		});
		jQuery.datepicker.setDefaults(jQuery.datepicker.regional['it']);
		jQuery(".datepicker" ).datepicker({
			showOn: 'focus',
			firstDay: 1,
      regional: 'it',
      showAnim: 'slideDown',
			changeMonth: true,
			changeYear: true,
			showWeek: false,
			numberOfMonths: 3,
			stepMonths: 3,
			buttonImageOnly: true,
			showButtonPanel: true
		});
		jQuery(".datetimepicker" ).datetimepicker({
			timeFormat: 'h:m',
			hour: 09,
			minute: 00,
			hourText:'ora',
			minuteText:'minuti',
			currentText:'adesso',
			closeText: 'fatto',
			showOn: "focus",
			firstDay: 1,
      regional: 'it',
      showAnim: 'slideDown',
			changeMonth: true,
			changeYear: true,
			showWeek: false,
			numberOfMonths: 3,
			stepMonths: 3,
			buttonImageOnly: true,
			showButtonPanel: true
		});
		jQuery(".timepicker" ).timepicker({
			timeFormat: 'h:m',
			hour: 09,
			minute: 00,
			hourText:'ora',
			minuteText:'minuti',
			currentText:'adesso',
			closeText: 'fatto',
			showOn: "focus"
		});


	});

function aggiornaSpese(){
var dblTotale;
var dblTotaleCarburante;
	dblTotale=0;
	dblTotaleCarburante=0;
	if (jQuery("#Attivita_Km").val()!=null && jQuery("#Attivita_CostoCarburante").val()!=null){
		dblTotaleCarburante=parseFloat(jQuery("#Attivita_Km").val())*parseFloat(jQuery("#Attivita_CostoCarburante").val());
		jQuery("#Attivita_SpeseCarburante").val(dblTotaleCarburante);
		dblTotale+=parseFloat(dblTotaleCarburante);
	}
	if (jQuery("Attivita_SpeseCarburante").val()!=null){
		dblTotale+=parseFloat(jQuery("#Attivita_SpeseCarburante").val());
	}
	if (jQuery("#Attivita_SpeseAutostrada").val()!=null){
		dblTotale+=parseFloat(jQuery("#Attivita_SpeseAutostrada").val());
	}
	if (jQuery("#Attivita_SpeseParcheggi").val()!=null){
		dblTotale+=parseFloat(jQuery("#Attivita_SpeseParcheggi").val());
	}
	if (jQuery("#Attivita_SpesePasti").val()!=null){
		dblTotale+=parseFloat(jQuery("#Attivita_SpesePasti").val());
	}
	jQuery("#Attivita_SpeseTotali").val(dblTotale);
}

function chgCompleto(){
var dtDate;
var strDate;
var strOra;
var intMese;
var intGiorno;
var intAnno;
	dtDate=new Date();
	intMese=parseInt(dtDate.getMonth())+1
	if(intMese<10){intMese='0'+intMese}
	intAnno=dtDate.getFullYear();
	intGiorno=dtDate.getDate();
	if(intGiorno<10){intGiorno='0'+intGiorno}
	strDate=intGiorno + "/" + intMese + "/" + intAnno;
	strOra=dtDate.getHours() + ":" + dtDate.getMinutes();
	
	//alert(jQuery("#Attivita_Completo").prop('checked'));
	if (jQuery("#Attivita_Completo").prop('checked')==true){
		selectSet("AttivitaStato_Ky","5");
		jQuery("#Attivita_Chiusura").val(strDate);
		jQuery("#Attivita_OraScadenza").val(strOra);
	}
}


function attivaTrasferta(){
	if (jQuery("#Attivita_Trasferta").prop('checked')==true){
		jQuery("#datitrasferta").show("highlight");
	}else{
		jQuery("#datitrasferta").hide("highlight");
	}
}

function MostraNascondi(idOggetto){
	obj=document.getElementById(idOggetto);
	if (obj.style.display=="" || obj.style.display=="block"){
		jQuery("#"+idOggetto).hide("highlight");
	}else{
		jQuery("#"+idOggetto).show("clip");
	}
}
function radioSet(idOggetto, strValue){
	jQuery('input:radio[name="' + idOggetto + '"][value="' + strValue + '"]').click();
}
function selectSet(idOggetto, strValue){
	obj=document.getElementById(idOggetto);
  for (i=0; i<obj.length; i++){
    if(obj[i].value == strValue)
      obj.selectedIndex = i;
    }
}
function GeneraPassword(length, special, strField) {
  var iteration = 0;
  var password = "";
  var randomNumber;
  if(special == undefined){
      var special = false;
  }
  while(iteration < length){
    randomNumber = (Math.floor((Math.random() * 100)) % 94) + 33;
    if(!special){
      if ((randomNumber >=33) && (randomNumber <=47)) { continue; }
      if ((randomNumber >=58) && (randomNumber <=64)) { continue; }
      if ((randomNumber >=91) && (randomNumber <=96)) { continue; }
      if ((randomNumber >=123) && (randomNumber <=126)) { continue; }
    }
    iteration++;
    password += String.fromCharCode(randomNumber);
  }
  jQuery("#"+strField).val(password);
}