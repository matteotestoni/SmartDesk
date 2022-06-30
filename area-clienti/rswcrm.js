//area clienti
	jQuery.noConflict();
	jQuery(function() {
    jQuery('.delete').click(function(evt) {
        boolReturn=false;
        deleteid=jQuery(this).attr('id');
        deletehref=jQuery(this).attr('href');
        //evt.preventDefault();
        confirm("Sei sicuro di eliminare il dato?","Clicca 'Si' se sei sicuro.", function() {
          window.location.replace(deletehref);
          boolReturn=true;
        });
        return boolReturn;
    });
    
  	function confirm(title, message, callback) {
  		// create your modal template    
  		var modal = '<div class="reveal small" id="confirmation">'+
  			     		'<h2>'+title+'</h2>'+
  			   		  '<p class="lead">'+message+'</p>'+
           			'<button class="button success yes"><i class="fa-duotone fa-check-square fa-fw"></i>Si</button>'+
  			    		'<button class="button alert align-right" data-close><i class="fa-duotone fa-times fa-fw"></i>No</button>'+
  		       		'</div>';
  		// appending new reveal modal to the page
  		jQuery('body').append(modal);
  		// registergin this modal DOM as Foundation reveal    
  		var confirmation = new Foundation.Reveal(jQuery('#confirmation'));
  		// open
  		confirmation.open();
  		// listening for yes click
      
  		jQuery('#confirmation').children('.yes').on('click', function() {
  			// close and REMOVE FROM DOM to avoid multiple binding
  			confirmation.close();
  			jQuery('#confirmation').remove();
        	// calling the function to process
        	callback.call();
      	});
  		jQuery(document).on('closed.zf.reveal', '#confirmation', function() {
  			// remove from dom when closed
  			jQuery('#confirmation').remove();
  		});
  
  	};
  	
		jQuery('.select2').select2({
			theme: "rswstudio",
			placeholder: 'Scegli un opzione',
			allowClear: true
		});
		
    	jQuery('.fdatepicker').fdatepicker({
    		format: 'dd-mm-yyyy',
    		closeButton: false,
    		weekStart: 1      ,
    		viewMode: 2,
    		minViewMode: 2,
    		language: 'it',
    		pickTime: false
    	});
    	jQuery('.timepicker').fdatepicker({
    		format: 'hh:ii',
    		closeButton: false,
    		weekStart: 1      ,
    		viewMode: 0,
    		startView: 0,
    		minViewMode: 0,
    		maxViewMode: 0,
    		language: 'it',
    		pickTime: true
    	});		
    	jQuery('.datetimepicker').fdatepicker({
    		format: 'dd-mm-yyyy hh:ii',
    		weekStart: 1,
    		viewMode: 1,
    		startView: 0,
    		language: 'it',
    		pickTime: true
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
	if (jQuery("#Attivita_Completo").attr('checked')=='checked'){
		selectSet("AttivitaStato_Ky","5");
		jQuery("#Attivita_Chiusura").value=new Date();
	}
}


function attivaTrasferta(){
	if (jQuery("#Attivita_Trasferta").attr('checked')=='checked'){
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
