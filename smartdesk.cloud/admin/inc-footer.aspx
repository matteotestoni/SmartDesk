	<footer id="footer" class="grid-container fluid footer text-center hide-for-print">
	  <div class="grid-x grid-margin-x">
          <div class="small-12 medium-12 large-12 cell">
            &copy; <%=DateTime.Now.Year.ToString()%>
            <abbr title="realizzazione siti web">RSW</abbr> Studio s.n.c. - 
            <i class="fa-duotone fa-phone fa-fw"></i>Tel: +39 0425.460364<br>
            <i class="fa-duotone fa-location-dot fa-fw"></i> Sede legale: Via G. Matteotti 42 - 45031 Arqu&agrave; Polesine (RO) | REA: RO - 148409 | P.I. 01349210292
            <i class="fa-duotone fa-location-dot fa-fw"></i> Sede operativa: Via Danieli 57 - 45021 Badia Polesine (Rovigo)
  	     </div>
    </div>
	</footer>
	<script type="text/javascript">
	  jQuery.noConflict();
		jQuery(document).foundation();

    if (jQuery('#message').length){
      jQuery('#message').foundation('open');
    	window.setTimeout(function(){ jQuery("#message button.close-button").click(); }, 1000);
    }
  </script>	
  
