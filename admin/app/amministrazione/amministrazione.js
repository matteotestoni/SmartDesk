//javascript
	var strContenuto;
	
	function aggTotale(){
		jQuery("#Spese_TotaleRighe").val(jQuery("#Spese_Totale").val()/122*100);
		jQuery("#Spese_TotaleIVA").val(jQuery("#Spese_Totale").val()/122*22);
	}

	function aggTotaleRighe(){
		//jQuery("#Spese_Totale").val(jQuery("#Spese_TotaleRighe").val()/100*122);
		//jQuery("#Spese_TotaleIVA").val(jQuery("#Spese_TotaleRighe").val()/100*22);
	}

	function aggTotaleIVA(){
		//jQuery("#Spese_Totale").val(jQuery("#Spese_TotaleIVA").val()/22*122);
		//jQuery("#Spese_TotaleRighe").val(jQuery("#Spese_TotaleIVA").val()/22*100);
	}

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

  function loadCentriDiCR(){
    var sHTML;
    var listField;
    var strWHERE;
    var strXML;
    
    if (document.getElementById("Anagrafiche_Ky").value.length>0){
      listField=document.getElementById("CentridiCR_Ky");
      strWHERE="Anagrafiche_Ky=" + document.getElementById("Anagrafiche_Ky").value;
      strXML="<db><rs><st>frk_Read<\/st><tb>Anagrafiche<\/tb><ky>Anagrafiche_Ky<\/ky><whr>" + strWHERE + "<\/whr><ord>Anagrafiche_Ky<\/ord><fields>Anagrafiche_Ky,CentridiCR_Ky<\/fields><\/rs><\/db>";
      strXML=jsHttpPost("/admin/frkStoreExecute.asp",strXML);
      var xmldoc=XMLDoc(strXML);
      var db = xmldoc.getElementsByTagName("rs");
      for(var i = 0; i < db.length; i++) {
        var e = db[i];
        if (jQuery("#CentridiCR_Ky").val()==null || jQuery("#CentridiCR_Ky").val().length<1){
          selectSet("CentridiCR_Ky",fnKy(getElementValue(e,"CentridiCR_Ky")));
        }
      }
    }
  };  
