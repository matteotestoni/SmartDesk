<div id="slick-home">
	<% for (int islide = 0; islide < dtCMSSlide.Rows.Count; islide++){ %>
  	<div class="slide-wrapper">
  		<a href="<%=dtCMSSlide.Rows[islide]["CMSSlide_Url"].ToString()%>"><img src="<%=dtCMSSlide.Rows[islide]["CMSSlide_Foto"].ToString()%>"></a>
  	</div>
	<% } %>
</div>
<script>
  jQuery(document).ready(function() {
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
</script>
