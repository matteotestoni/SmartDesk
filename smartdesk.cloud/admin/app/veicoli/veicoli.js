// JavaScript Document
  function gotoSchedaAnagrafica(){
    $strAnagrafiche_Ky=jQuery("#Anagrafiche_Ky").val();
    $strUrl="/admin/form.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198&CoreForms_Ky=197&custom=0&azione=edit&sorgente=scheda-preventiviauto&Anagrafiche_Ky=" + $strAnagrafiche_Ky;
    //console.log($strUrl);
    var win=window.open($strUrl, '_parent');
    win.focus();
  }

  function printPrenotazione(){
    var strKy=jQuery("#VeicoliPrenotazioni_Ky").val();
    var strUrl="/admin/app/veicoli/report/rpt-VeicoliPrenotazioni.aspx?VeicoliPrenotazioni_Ky=" + strKy;
    //console.log(strUrl);
    window.open(strUrl,'_blank');
  };


  function XMLDoc(strXML){
    if (document.implementation.createDocument){ 
      var parser = new DOMParser(); 
      var xmldoc = parser.parseFromString(strXML, "text/xml"); 
    }
    else if (window.ActiveXObject) { 
      var xmldoc = new ActiveXObject("Microsoft.XMLDOM");   
      //xmldoc.async=false;
      xmldoc.loadXML(strXML);                                     
    }
    return xmldoc;
  };

  function getElementValue(xmlDoc, strName){
      try{ 
        return xmlDoc.getElementsByTagName(strName)[0].textContent;
      }catch(e){
        return "";
      }
  };


  function jsHttpPost(sUrl, strXML){
    var xmlhttp=false;
    var sR;
    sR='';
    try{
		  try {
			  xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
		  } catch (e) {
			  try {
			    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
			  } catch (e) {}
		  }
    }catch (e) {
      xmlhttp = false;
    }
    if (!xmlhttp && typeof XMLHttpRequest!='undefined') { //firefox e altri
      xmlhttp = new XMLHttpRequest();
      xmlhttp.open("POST", sUrl,false);
      xmlhttp.send(strXML);
      sR=xmlhttp.responseText;
      return sR;
    }
    else{                                                 //internet explorer
      xmlhttp.open("POST", sUrl,false);
      xmlhttp.send(strXML); 
      return xmlhttp.ResponseText;
    }
  };

  function fnKy(nV){
    return nV.replace(".", "");
  };

  function caricaVeicoliModello_Ky(strFieldMarca, strFieldModello){
    var sHTML;
    var listField;
    var strWHERE;
    var strXML;
    
    if (document.getElementById(strFieldMarca).value.length>0){
      listField=document.getElementById(strFieldModello);
      listField.length=0;
      strWHERE="VeicoliMarca_Ky=" + document.getElementById(strFieldMarca).value;
      strXML="<db><rs><st>frk_Read<\/st><tb>VeicoliModello_SpazioGroup_Vw<\/tb><ky>VeicoliModello_Ky<\/ky><whr>" + strWHERE + "<\/whr><ord>VeicoliModello_Descrizione<\/ord><fields>VeicoliModello_Ky,VeicoliModello_Titolo,VeicoliModello_Descrizione<\/fields><\/rs><\/db>";
      strXML=jsHttpPost("/admin/frkStoreExecute.asp",strXML);
      var xmldoc=XMLDoc(strXML);
      var db = xmldoc.getElementsByTagName("rs");
      var len = listField.length++; 
      listField.options[len].value = '';
      listField.options[len].text = 'Qualsiasi'; 
      for(var i = 0; i < db.length; i++) {
        var len = listField.length++; 
        var e = db[i];
        listField.options[len].value = fnKy(getElementValue(e,"VeicoliModello_Ky"));
        listField.options[len].text = getElementValue(e,"VeicoliModello_Titolo");
      }
    }
  };  
  

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
  console.log($AnagraficheTipologia_Ky);
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
    		data: $data
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
  
