<div class="grid-x grid-padding-x small-up-1 medium-up-2 large-up-4" data-equalizer data-equalize-on="medium" id="news-eq">
		<% for (int i = 0; i < dtCMSContenuti.Rows.Count; i++){ %>
		<div class="cell CMSCategorie<%=dtCMSContenuti.Rows[i]["CMSCategorie_Ky"].ToString()%>">
			<div class="card">
				<div class="card-divider">
					<h3 class="ad-box-title"><a href="/pag/<%=dtContenuti.Rows[i]["CMSContenuti_UrlKey"].ToString()%>.html" title="<%=dtContenuti.Rows[i]["CMSContenuti_Titolo"].ToString()%>"><%=dtCMSContenuti.Rows[i]["CMSContenuti_Titolo"].ToString()%></a></h3>
        </div>
				<img src="<%=dtCMSContenuti.Rows[i]["CMSContenuti_Foto"].ToString()%>">
        <div class="card-section">
					<%=dtContenuti.Rows[i]["CMSContenuti_Contenuto"].ToString()%>
					<a href="/pag/<%=dtContenuti.Rows[i]["CMSContenuti_UrlKey"].ToString()%>.html" class="button expanded" title="<%=dtContenuti.Rows[i]["CMSContenuti_Titolo"].ToString()%>">Leggi <i class="fa-duotone fa-angle-right fa-fw"></i></a>
        </div>
			</div>
		</div>
  <% } %>
</div>
<asp:Label ID="PaginaSotto" runat="server" class="paginazione"></asp:Label>


