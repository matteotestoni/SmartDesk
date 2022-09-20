jQuery.noConflict();
jQuery(function () {		

    jQuery('form').submit(function (event) {
        jQuery('input[type=checkbox]').prop('checked', function (index, value) {
            this.value = (value) ? "True" : "False"
            return value;
            });
    });

    jQuery('.delete').click(function(evt) {
        boolReturn=false;
        deleteid=jQuery(this).attr('id');
        deletehref=jQuery(this).attr('href');
        evt.preventDefault();
        confirm("Sei sicuro di eliminare il dato?","Clicca 'Si' se sei sicuro.", function() {
          window.location.replace(deletehref);
          boolReturn=true;
        });
        return boolReturn;
    });
    
  	function confirm(title, message, callback) {
  		// create your modal template    
  		var modal = '<div class="reveal small" id="confirmation" data-reveal>'+
  			     		'<h2>'+title+'</h2>'+
  			   		  '<p class="lead">'+message+'</p>'+
           			'<button class="button success float-left yes"><i class="fa-duotone fa-square-check fa-fw"></i>Si</button>'+
  			    		'<button class="button alert float-right no" data-close><i class="fa-duotone fa-times fa-fw"></i>No</button>'+
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
		placeholder: 'Scegli un opzione',
    width: "100%",
    minimumResultsForSearch: -1,
		allowClear: true,
    allowHtml: true,
    templateSelection: iformat,
		templateResult: iformat    
	});
  
  function iformat(icon, color, img) {
  	var originalOption = icon.element;
    //console.log(jQuery(originalOption).data('img'));
  	if (jQuery(originalOption).data('img')!=null){
      //console.log("1");
      return jQuery('<span><img src="' + jQuery(originalOption).data('img') + '" width="22" style="width:24px;height:24px;border-radius:50%;margin-right:5px;margin-top:-8px"> ' + icon.text + '</span>');
    }else{
      //console.log("2");
      return jQuery('<span style="color:' + jQuery(originalOption).data('color') + '"><i class="' + jQuery(originalOption).data('icon') + '"></i> ' + icon.text + '</span>');
    }
  }
  
  
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
	jQuery('.fdatetimepicker').fdatepicker({
		format: 'dd-mm-yyyy hh:ii:00',
		closeButton: false,
		weekStart: 1,
		startView: 2,
		language: 'it',
		pickTime: true
	});		
	jQuery('.datetimepicker').fdatepicker({
		format: 'dd-mm-yyyy hh:ii:00',
		closeButton: false,
		weekStart: 1,
		startView: 2,
		language: 'it',
		pickTime: true
	});		

	oTable = jQuery('#griddatatables').dataTable({
		paging: false,
		info: false,
		searching: false,
		ordering: true,
		responsive: false
	});

	oTable = jQuery('.griddatatables').dataTable({
		paging: true,
		info: false,
		searching: true,
		ordering: false,
		responsive: false
	});
});

function gotoScheda(strCoreEntities_Code, strCoreEntities_Key, strFormUrl){
  $strKey=jQuery("#" + strCoreEntities_Key).val();
  $strUrl= strFormUrl + "&" + strCoreEntities_Key + "=" + $strKey;
  //console.log($strUrl);
  var win=window.open($strUrl, '_parent');
  win.focus();

}


function showPasswordForm(strIdField){
var x = document.getElementById(strIdField);
    if (x.type === "password") {
      x.type = "text";
    } else {
      x.type = "password";
    }
}

function copyToClipboard(strIdField, boolText=false){
  //console.log(strIdField);
  if (boolText==true){
    strClipboardText=document.getElementById(strIdField).dataset.password;
    strClipboard="";
    console.log("Password: " + strClipboardText);
    navigator.permissions.query({name: "clipboard-write"}).then(result => {
      if (result.state == "granted" || result.state == "prompt") {
        navigator.clipboard.writeText(strClipboardText).then(function() {
          /* clipboard successfully set */
          tempAlert("Password copiata: " + strClipboardText,3000);
          //alert("Password copiata: " + strClipboardText);
        }, function() {
          /* clipboard write failed */
          console.log("Password NON copiata");
        });

      }else{
          console.log("Password NON copiata");
      }
    });
  }else{
    strClipboardText=document.getElementById(strIdField).value;
    strClipboard="";
    console.log("Password: " + strClipboardText);
    navigator.permissions.query({name: "clipboard-write"}).then(result => {
      if (result.state == "granted" || result.state == "prompt") {
        navigator.clipboard.writeText(strClipboardText).then(function() {
          /* clipboard successfully set */
          tempAlert("Password copiata: " + strClipboardText,3000);
          //alert("Password copiata: " + strClipboardText);
        }, function() {
          /* clipboard write failed */
          console.log("Password NON copiata");
        });

      }else{
          console.log("Password NON copiata");
      }
    });
  }
}

function tempAlert(msg,duration)
{
 console.log("temp alert");
 var el = document.createElement("div");
 el.setAttribute("id", "divTempAlert");
 el.setAttribute("style","display: flex;justify-content: center;align-items: center;text-align: center;position:fixed;top:45%;left:45%;border-radius:8px;padding:1.5rem;box-shadow:0 2px 2px 0 rgba(0,0,0,0.14), 0 3px 1px -2px rgba(0,0,0,0.12), 0 1px 5px 0 rgba(0,0,0,0.2);background-color:#ffffff;color:black;margin:auto;border: 0px solid black;font-size:1.125rem;font-weight:700");
 el.innerHTML = msg;
 setTimeout(function(){
  el.parentNode.removeChild(el);
 },duration);
 document.body.appendChild(el);
}

function showPasswordGrid(strIdField){
    document.getElementById(strIdField).textContent=document.getElementById(strIdField).dataset.password;
}

function generatePassword(strIdForm){
    var length = 10,
    charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@!",
    retVal = "";
    boolReturn=false;
    var r=confirm("Sei sicuro creare una nuova password?","Clicca 'Si' se sei sicuro.");
    if (r == true) {
      for (var i = 0, n = charset.length; i < length; ++i) {
          retVal += charset.charAt(Math.floor(Math.random() * n));
      }
      document.getElementById(strIdForm).value = retVal;
      boolReturn=true;
    }
    return boolReturn;
 }
	
function duplicaRecord(strIdForm, strKey){
	jQuery("#azione").val("new");
	jQuery("#" + strKey).val("");
    document.getElementById(strIdForm).submit();
}



function roundTo(decimalpositions){
	var i = this * Math.pow(10,decimalpositions);
	i = Math.round(i);
	return i / Math.pow(10,decimalpositions);
}
Number.prototype.roundTo = roundTo; 

function aggiornaSpese(fAlert){
var dblTotale;
var dblTotaleCarburante;
	dblTotale=0;
	dblTotaleKm=0;
		
	if (jQuery("#Attivita_Km").val()!=null && jQuery("#Attivita_RimborsoKm").val()!=null){
		dblTotaleKm=jQuery("#Attivita_Km").val().replace(',', '.') * jQuery("#Attivita_RimborsoKm").val().replace(',', '.');
		dblTotaleKm=dblTotaleKm.roundTo(4);
		jQuery("#Attivita_SpeseKm").val(dblTotaleKm);
		dblTotale+=parseFloat(dblTotaleKm);
		if (fAlert){
			alert(dblTotaleCarburante);
		}
	}
	if (jQuery("Attivita_SpeseCarburante").val()!=null){
		dblTotale+=parseFloat(jQuery("#Attivita_SpeseCarburante").val().replace(',', '.'));
	}
	if (jQuery("#Attivita_SpeseAutostrada").val()!=null){
		dblTotale+=parseFloat(jQuery("#Attivita_SpeseAutostrada").val().replace(',', '.'));
	}
	if (jQuery("#Attivita_SpeseParcheggi").val()!=null){
		dblTotale+=parseFloat(jQuery("#Attivita_SpeseParcheggi").val().replace(',', '.'));
	}
	if (jQuery("#Attivita_SpesePasti").val()!=null){
		dblTotale+=parseFloat(jQuery("#Attivita_SpesePasti").val().replace(',', '.'));
	}
if (jQuery("#Attivita_SpeseMezziPubblici").val()!=null){
		dblTotale+=parseFloat(jQuery("#Attivita_SpeseMezziPubblici").val().replace(',', '.'));
	}
	dblTotale=dblTotale.roundTo(4);
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
	jQuery("#Attivita_Chiusura").val(jQuery("#Attivita_Scadenza").val());
	jQuery("#Attivita_OraScadenza").val(strOra);
	jQuery("#AttivitaStati_Ky").val(5);
	jQuery("#attivitastati-5").click();
  
  
	
}
}


function attivaTrasferta(){
if (jQuery("#Attivita_Trasferta").prop('checked')==true){
	jQuery("#datitrasferta").show("highlight");
}else{
	jQuery("#datitrasferta").hide("highlight");
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
jQuery("#"+idOggetto).val(strValue);
}

function selectSetMultiple(idOggetto, strValue){
var strField;
strField="#"+idOggetto;
jQuery.each(strValue.split(","), function(i,e){
    jQuery(strField + " option[value='" + e + "']").prop("selected", true);
});

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
};
  
var keyStr = "ABCDEFGHIJKLMNOP" +
            "QRSTUVWXYZabcdef" +
            "ghijklmnopqrstuv" +
            "wxyz0123456789+/" +
            "=";

function encode64(input) {
    input = escape(input);
    var output = "";
    var chr1, chr2, chr3 = "";
    var enc1, enc2, enc3, enc4 = "";
    var i = 0;

    do {
    chr1 = input.charCodeAt(i++);
    chr2 = input.charCodeAt(i++);
    chr3 = input.charCodeAt(i++);

    enc1 = chr1 >> 2;
    enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
    enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
    enc4 = chr3 & 63;

    if (isNaN(chr2)) {
        enc3 = enc4 = 64;
    } else if (isNaN(chr3)) {
        enc4 = 64;
    }

    output = output +
        keyStr.charAt(enc1) +
        keyStr.charAt(enc2) +
        keyStr.charAt(enc3) +
        keyStr.charAt(enc4);
    chr1 = chr2 = chr3 = "";
    enc1 = enc2 = enc3 = enc4 = "";
    } while (i < input.length);

    return output;
};

function decode64(input) {
    var output = "";
    var chr1, chr2, chr3 = "";
    var enc1, enc2, enc3, enc4 = "";
    var i = 0;

    // remove all characters that are not A-Z, a-z, 0-9, +, /, or =
    var base64test = /[^A-Za-z0-9\+\/\=]/g;
    if (base64test.exec(input)) {
    alert("There were invalid base64 characters in the input text.\n" +
            "Valid base64 characters are A-Z, a-z, 0-9, '+', '/',and '='\n" +
            "Expect errors in decoding.");
    }
    input = input.replace(/[^A-Za-z0-9\+\/\=]/g, "");

    do {
    enc1 = keyStr.indexOf(input.charAt(i++));
    enc2 = keyStr.indexOf(input.charAt(i++));
    enc3 = keyStr.indexOf(input.charAt(i++));
    enc4 = keyStr.indexOf(input.charAt(i++));

    chr1 = (enc1 << 2) | (enc2 >> 4);
    chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
    chr3 = ((enc3 & 3) << 6) | enc4;

    output = output + String.fromCharCode(chr1);

    if (enc3 != 64) {
        output = output + String.fromCharCode(chr2);
    }
    if (enc4 != 64) {
        output = output + String.fromCharCode(chr3);
    }

    chr1 = chr2 = chr3 = "";
    enc1 = enc2 = enc3 = enc4 = "";

    } while (i < input.length);

    return unescape(output);
};

function loadAnnunciModelli(strAnnunciMarca_Ky, strValoreSelezionato){
var strPath;
var strValore;
  
if (strAnnunciMarca_Ky==null || strAnnunciMarca_Ky==undefined || strAnnunciMarca_Ky.Length<1){
    strAnnunciMarca_Ky=jQuery("#AnnunciMarca_Ky").val();
}
if (strAnnunciMarca_Ky!=""){
    strValore=jQuery("#AnnunciModello_Ky").val();
    strPath="/admin/app/annunci/getAnnunciModello-json.aspx?AnnunciMarca_Ky=" + strAnnunciMarca_Ky;
    jQuery.getJSON(strPath, null, function(data) {
        jQuery("#AnnunciModello_Ky option").remove();
        jQuery.each(data.modelli, function(index, item) {
            jQuery("#AnnunciModello_Ky").append(
                jQuery("<option></option>")
                    .text(item.label)
                    .val(item.id)
                    .prop('selected', strValoreSelezionato == item.id)
            );
        });
    });
}  
};
  
function loadAttributi(strAnnunciCategorie_Ky, strValoreSelezionato){
var strPath;
var strValore;
  
if (strAnnunciCategorie_Ky==null || strAnnunciCategorie_Ky==undefined || strAnnunciCategorie_Ky.Length<1){
    strAnnunciCategorie_Ky=jQuery("#AnnunciCategorie_Ky").val();
}
if (strAnnunciCategorie_Ky!=""){
    strPath="/admin/app/annunci/getAttributiAnnunci-html.aspx?Annunci_Ky=" + jQuery("#Annunci_Ky").val() + "&AnnunciCategorie_Ky=" + strAnnunciCategorie_Ky;
    jQuery.get(strPath, function( data ) {
        jQuery("#attributi").html( data );
    });
}  
};

function loadCoreComuniZone(strComuni_Ky, strValoreSelezionato){
var strPath;
var strValore;

if (strComuni_Ky==null || strComuni_Ky==undefined || strComuni_Ky.Length<1){
    strComuni_Ky=jQuery("#Comuni_Ky").val();
}
if (strComuni_Ky!=""){
    strValore=jQuery("#Comuni_Ky").val();
    strPath="/admin/app/core/getCoreComuniZone-json.aspx?Comuni_Ky=" + strComuni_Ky;
    jQuery.getJSON(strPath, null, function(data) {
        jQuery("#ComuniZone_Ky option").remove();
        jQuery("#ComuniZone_Ky").append(jQuery("<option></option>"));
        jQuery.each(data, function(index, item) {
            jQuery("#ComuniZone_Ky").append(
                jQuery("<option></option>")
                    .text(item.label)
                    .val(item.id)
                    .prop('selected', strValoreSelezionato == item.id)
            );
        });
    });
}  
};
   
function loadCoreComuni(strProvince_Ky, strValoreSelezionato){
var strPath;
var strValore;

if (strProvince_Ky==null || strProvince_Ky==undefined || strProvince_Ky.Length<1){
    strProvince_Ky=jQuery("#Province_Ky").val();
}
if (strProvince_Ky!=""){
    strValore=jQuery("#Comuni_Ky").val();
    strPath="/admin/app/core/getCoreComuni-json.aspx?Province_Ky=" + strProvince_Ky;
    jQuery.getJSON(strPath, null, function(data) {
        jQuery("#Comuni_Ky option").remove();
        jQuery("#Comuni_Ky").append(jQuery("<option></option>"));
        jQuery.each(data, function(index, item) {
            jQuery("#Comuni_Ky").append(
                jQuery("<option></option>")
                    .text(item.label)
                    .val(item.id)
                    .prop('selected', strValoreSelezionato == item.id)
            );
        });
    });
}  
};

function loadCoreRegioni(strNazioni_Ky, strValoreSelezionato){
var strPath;
var strValore;
        
if (strNazioni_Ky==null || strNazioni_Ky==undefined || strNazioni_Ky.Length<1){
    strNazioni_Ky=jQuery("#Nazioni_Ky").val();
}
if (strNazioni_Ky!=""){
    strValore=jQuery("#Regioni_Ky").val();
    strPath="/admin/app/core/getCoreRegioni-json.aspx?Nazioni_Ky=" + strNazioni_Ky;
    jQuery.getJSON(strPath, null, function(data) {
        jQuery("#Regioni_Ky option").remove(); 
        jQuery("#Regioni_Ky").append(jQuery("<option></option>"));
        jQuery.each(data, function(index, item) {
            jQuery("#Regioni_Ky").append(
                jQuery("<option></option>")
                    .text(item.label)
                    .val(item.id)
                    .prop('selected', strValoreSelezionato == item.id)
            );
        });
    });
}  
};

function loadCoreProvince(strRegioni_Ky, strValoreSelezionato){
var strPath;
var strValore;
        
if (strRegioni_Ky==null || strRegioni_Ky==undefined || strRegioni_Ky.Length<1){
    strRegioni_Ky=jQuery("#Regioni_Ky").val();
}
if (strRegioni_Ky!=""){
    strValore=jQuery("#Province_Ky").val();
    strPath="/admin/app/core/getCoreProvince-json.aspx?Regioni_Ky=" + strRegioni_Ky;
    jQuery.getJSON(strPath, null, function(data) {
        jQuery("#Province_Ky option").remove(); 
        jQuery("#Province_Ky").append(jQuery("<option></option>"));
        jQuery.each(data, function(index, item) {
            jQuery("#Province_Ky").append(
                jQuery("<option></option>")
                    .text(item.label)
                    .val(item.id)
                    .prop('selected', strValoreSelezionato == item.id)
            );
        });
    });
}  
};


jQuery(document).ready(function() {  

jQuery('#selectall').on( "click", function() {
    if(document.getElementById('selectall').checked) {
    	jQuery('.checkrow').prop("checked", true);
    }else{
    	jQuery('.checkrow').prop("checked", false);
    }
});
    
jQuery('.doaction').on( "click", function() {
    var strIds;
    var intI = 0;
    var strIdForm;
    var strAction;
   
    strIdForm = "#" + this.form.id
    intI = 0;
    jQuery('.grid input[type=checkbox].checkrow:checked').each(function () {
        if (intI>0){
            strIds=strIds + "," + jQuery(this).attr('data-value');
        }else{
            strIds=jQuery(this).attr('data-value');
        }
        intI=intI+1;
    }); 
    //console.log(strIds);
    jQuery(strIdForm + '-azionidigruppo-ids').val(strIds);
    /*
    jQuery(strIdForm).submit(function (e) {
        e.preventDefault();
    });*/
      
    if (strIds!=undefined && strIds.length>0){
        strAction = jQuery(strIdForm).find(':selected').attr('data-action');
        //console.log(strAction);   
        console.log(strIdForm + '-azionidigruppo');
        switch (jQuery(strIdForm + '-azionidigruppo').val()) {
            case "delete":
                jQuery(strIdForm + '-azione').val("delete");
                jQuery(strIdForm + '-sorgente').val(document.URL);
                jQuery(strIdForm).attr('action',strAction );
                jQuery(strIdForm).submit();
                break;
        }
        return false;
    }
      
});

jQuery('#selectallfoto').on( "click", function() {
    var strId=this.id;
		var strFormid = jQuery(this).closest("form").attr("id");
		var strSelect='#' + strFormid + ' .checkrow';		
		if(document.getElementById(strId).checked) {
    	jQuery(strSelect).prop("checked", true);
    }else{
    	jQuery(strSelect).prop("checked", false);
    }
});

jQuery('#doactionfoto').on( "click", function() {
	var strSelect='';
    var strIds;
    var intI=0;
    var strIdForm;

    strIdForm = "#" + this.form.id
      
    intI=0;
    strSelect = strIdForm + ' input[type=checkbox].checkrow:checked';
	jQuery(strSelect).each(function () {
        if (intI>0){
            strIds=strIds + "," + jQuery(this).attr('data-value');
        }else{
            strIds=jQuery(this).attr('data-value');
        }
        intI=intI+1;
    }); 
      
	console.log(strIds);
    strSelect = strIdForm + ' .azionidigruppo-ids';
    jQuery(strSelect).val(strIds);
      
    if (strIds!=undefined && strIds.length>0){
        jQuery(strIdForm + ' .azione').val("delete");
        jQuery(strIdForm + ' .sorgente').val(document.URL);
        console.log(jQuery(strIdForm).find(':selected').attr('data-action'));
        jQuery(strIdForm).attr('action', jQuery(strIdForm).find(':selected').attr('data-action'));
        //jQuery('#' + strFormid).submit();
    }
    return false;
      
});

    
    
});  
