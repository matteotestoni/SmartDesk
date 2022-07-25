		function assegnaLead(intLead_Ky){
      var strUtenti_Ky=jQuery("#Utenti_Ky-" + intLead_Ky).val();
      console.log("Lead:" + intLead_Ky);
      console.log("Utente:" + strUtenti_Ky);
    	$url="/admin/app/commerciale/actions/lead-assegna-utente.aspx";
    	$data= { ajax:true, Lead_Ky: intLead_Ky, Utenti_Ky: strUtenti_Ky };
    	console.log($data);
    	jQuery.ajax({
    		type: "POST",
    		url: $url,
    		data: $data
    	})
    	.done(function( data ) {
        jQuery("#trLead" + intLead_Ky).remove();
      });	
		}
