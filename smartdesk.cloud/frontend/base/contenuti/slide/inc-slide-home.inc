<div id="slick-home">
	<% for (int islide = 0; islide < dtCMSSlide.Rows.Count; islide++){ %>
  	<div class="slide-wrapper">
  		<img src="<%=dtCMSSlide.Rows[islide]["CMSSlide_Foto"].ToString()%>">
  	</div>
	<% } %>
</div>
