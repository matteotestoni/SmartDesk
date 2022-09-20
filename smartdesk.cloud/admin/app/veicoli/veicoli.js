// JavaScript Document

function printPrenotazione(){
  var strKy=jQuery("#VeicoliPrenotazioni_Ky").val();
  var strUrl="/admin/app/veicoli/report/rpt-VeicoliPrenotazioni.aspx?VeicoliPrenotazioni_Ky=" + strKy;
  //console.log(strUrl);
  window.open(strUrl,'_blank');
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
