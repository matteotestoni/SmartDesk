<div class="grid-x grid-padding-x small-up-1 medium-up-2 large-up-4" data-equalizer data-equalize-on="medium" id="news-eq">
		<% for (int i = 0; i < dtContenuti.Rows.Count; i++){ %>
		<div class="cell CMSCategorie<%=dtContenuti.Rows[i]["CMSCategorie_Ky"].ToString()%>">
			<div class="ad-box">
				<div class="grid-x">
					<div class="ad-box-media xlarge-12 large-12 cell">
						<div class="lazyload" data-bg="<%=dtContenuti.Rows[i]["CMSContenuti_Foto"].ToString()%>" style="background-size:cover;width:100%;height:100%;max-height:260px;min-height:260px;background-repeat:no-repeat;background-position:center center;">
							<a href="/pag/<%=dtContenuti.Rows[i]["CMSContenuti_UrlKey"].ToString()%>.html" title="<%=dtContenuti.Rows[i]["CMSContenuti_Titolo"].ToString()%>">
							</a>
						</div>
					</div>
					<div class="ad-box-content xlarge-12 cell">
						<div class="ad-box-text" data-equalizer-watch>
							<div class="ad-box-header">
								<h3 class="ad-box-title"><a href="/pag/<%=dtContenuti.Rows[i]["CMSContenuti_UrlKey"].ToString()%>.html" title="<%=dtContenuti.Rows[i]["CMSContenuti_Titolo"].ToString()%>"><%=dtContenuti.Rows[i]["CMSContenuti_Titolo"].ToString()%></a></h3>
							</div>
						</div>
						<div class="ad-box-details">
							<div class="grid-x grid-padding-x">
								<div class="large-12 medium-12 small-12 cell">
									<a href="/pag/<%=dtContenuti.Rows[i]["CMSContenuti_UrlKey"].ToString()%>.html" class="button expanded" title="<%=dtContenuti.Rows[i]["CMSContenuti_Titolo"].ToString()%>">Leggi <i class="fa-duotone fa-angle-right fa-fw"></i></a>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
  <% } %>
</div>
<div class="grid-x grid-padding-x actions align-center">
	<a class="button secondary large radius" href="/elenco-articoli.aspx">Leggi tutti i suggerimenti dei nostri esperti <i class="fa-duotone fa-angle-right fa-fw"></i></a>
</div>

