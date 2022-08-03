  jQuery.noConflict();
  
	function radioSet(idOggetto, strValue){
		jQuery('input:radio[name="' + idOggetto + '"][value="' + strValue + '"]').click();
	};

	function checkSet(idOggetto, strValue){
		jQuery(idOggetto).prop( "checked", strValue );
	};

	function selectSet(idOggetto, strValue){
		obj=document.getElementById(idOggetto);
	  for (i=0; i<obj.length; i++){
	    if(obj[i].value.toLowerCase() == strValue.toLowerCase())
	      obj.selectedIndex = i;
	    }
	};
    
  function caricaComuni_Ky(strFieldProvincia, strFieldComune){
    var sHTML;
    var listField;
    var strWHERE;
    var strXML;
    
    if (document.getElementById(strFieldProvincia).value.length>0){
      listField=document.getElementById(strFieldComune);
      listField.length=0;
      strWHERE="Province_Ky=" + document.getElementById(strFieldProvincia).value;
      strXML="<db><rs><st>frk_Read<\/st><tb>Comuni<\/tb><ky>Comuni_Ky<\/ky><whr>" + strWHERE + "<\/whr><ord>Comuni_Comune<\/ord><fields>Comuni_Ky,Comuni_Comune<\/fields><\/rs><\/db>";
      strXML=jsHttpPost("/frk/db/SQLServer/frkStoreExecute.asp",strXML);
      var xmldoc=XMLDoc(strXML);
      var db = xmldoc.getElementsByTagName("rs");
      var len = listField.length++; 
      listField.options[len].value = '';
      listField.options[len].text = 'Qualsiasi'; 
      for(var i = 0; i < db.length; i++) {
        var len = listField.length++; 
        var e = db[i];
        listField.options[len].value = fnKy(getElementValue(e,"Comuni_Ky"));
        listField.options[len].text = getElementValue(e,"Comuni_Comune");
      }
    }
  };  

  function CountDownTimer(dt, id){
      var end = new Date(dt);
  
      var _second = 1000;
      var _minute = _second * 60;
      var _hour = _minute * 60;
      var _day = _hour * 24;
      var timer;
  
      function showRemaining() {
          var now = new Date();
          var distance = end - now;
          if (distance < 0) {
  
              clearInterval(timer);
              document.getElementById(id).innerHTML = 'ASTA SCADUTA';
  
              return;
          }
          var days = Math.floor(distance / _day);
          var hours = Math.floor((distance % _day) / _hour);
          var minutes = Math.floor((distance % _hour) / _minute);
          var seconds = Math.floor((distance % _minute) / _second);
          var result = days + 'g ' + hours + 'h ' + minutes + 'm ' + seconds + 's';
          document.getElementById(id).innerHTML = days + 'g ';
          document.getElementById(id).innerHTML += hours + 'h ';
          document.getElementById(id).innerHTML += minutes + 'm ';
          document.getElementById(id).innerHTML += seconds + 's';
      }
      timer = setInterval(showRemaining, 1000);
      jQuery("#" + id).attr("data-timer",timer);
  };
  
  function formatDate(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    if (minutes.toString().length<2){
     minutes="0"+minutes;
    }
    var strTime = hours + ':' + minutes;
    return date.getDate() + "/" + (date.getMonth()+1) + "/" + date.getFullYear() + " " + strTime;
  }

jQuery(document).ready(function() {
	jQuery(document).foundation();
  //jQuery('#prezzoda').number( true, 0, ",","." );
  //jQuery('#prezzoa').number( true, 0, ",","." );
  
  jQuery(".datascadenzaasta").each(function() {
    strId=jQuery(this).attr('id');
    console.log(strId);
    strValue=document.getElementById(strId).value;
    var date1 = new Date(strValue);
    var today = new Date();
    var timeDiff = Math.abs(today.getTime() - date1.getTime());
    var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24)); 
    strCountDown=jQuery(this).data('countdown');
    if (diffDays<=30){
      CountDownTimer(strValue, strCountDown);
    }else{
      var strData = new Date(strValue);
      jQuery("#" + strCountDown).text(formatDate(strData));
    }
  });  
  /*
	jQuery('.select2').select2({
	  theme: "rswstudio",
		placeholder: 'Scegli un opzione',
	  allowClear: true
	});*/
  
	if (jQuery('#slick-categorie').length>0){
      jQuery('#slick-categorie').slick({
    	dots: false,
    	infinite: true,
    	autoplay: true,
    	autoplaySpeed: 4000,
    	slidesToShow: 5,
    	slidesToScroll: 1,
    	responsive: [
    		{
    			breakpoint: 1024,
    			settings: {
    			slidesToShow: 4,
    			slidesToScroll: 1,
    			infinite: true,
    			dots: false
    			}
    		},
    	
    		{
    			breakpoint: 768,
    			settings: {
    			slidesToShow: 2,
    			slidesToScroll: 1
    			}
    		},
    		{
    			breakpoint: 480,
    			settings: {
    			slidesToShow: 1,
    			slidesToScroll: 1
    			}
    		}
    	]
    	});
  }
  
	if (jQuery('#slick-home').length>0){
    	jQuery('#slick-home').slick({
    		dots: true,
    		arrows: true,
    		infinite: true,
    		speed: 500,
    		fade: true,
    		cssEase: 'linear',
    		autoplay: true,
    		autoplaySpeed: 4000
    	});
  }
});
