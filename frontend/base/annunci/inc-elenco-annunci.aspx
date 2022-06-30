<div class="grid-x small-up-1 medium-up-1 large-up-1">
		<% for (int i = 0; i < dtAnnunci.Rows.Count; i++){ %>

		<%  if (dtAnnunci.Rows[i]["Annunci_Vetrina"].Equals(true)){ 
				strClass="vetrina";
			}	else{
				strClass="";
			}
		%>
		<article class="cell annuncitipo<%=dtAnnunci.Rows[i]["AnnunciTipo_Ky"].ToString()%> <%=strClass%>">
			<div class="ad-box">
				<div class="grid-x">
					<div class="ad-box-media xlarge-5 large-5 medium-5 small-12 cell">
						<%
							string strFoto=dtAnnunci.Rows[i]["Annunci_Foto1"].ToString();
							if (strFoto.Length<5){
								strFoto="/img/no-image800x600.jpg";
							}
						%>
						<div class="lazyload" data-bg="<%=strFoto%>" style="background-size:cover;width:100%;height:100%;max-height:260px;min-height:260px;background-repeat:no-repeat;background-position:center center;">
							<a href="/annuncio/<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>.html" title="<%=dtAnnunci.Rows[i]["Annunci_Titolo"].ToString()%>">
								<span class="counter"><i class="fa-duotone fa-fw fa-camera-retro"></i> <%=dtAnnunci.Rows[i]["Annunci_NumeroFoto"].ToString()%></span>
        				<% if (dtAnnunci.Rows[i]["Annunci_Video"].ToString().Length>0){ %>
								  <span class="video"><i class="fa-solid fa-fw fa-video" style="color:orange"></i></span>
                <% } %>
							</a>
						</div>
					</div>
					<div class="ad-box-content xlarge-7 large-7 medium-7 small-12 cell">
						<div class="ad-box-text">
							<div class="ad-box-header">
								<h3 class="ad-box-title"><a href="/annuncio/<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>.html" title="<%=dtAnnunci.Rows[i]["Annunci_Titolo"].ToString()%>"><%=dtAnnunci.Rows[i]["Annunci_Titolo"].ToString()%></a></h3>
								<p class="ad-box-subtitle"><i class="fa-duotone fa-fw fa-location-dot text-primary"></i><img src="/img/flags/it.png" style="margin-right:5px" alt="italia"><%=dtAnnunci.Rows[i]["Nazioni_Codice"].ToString()%> / <%=dtAnnunci.Rows[i]["Regioni_Regione"].ToString()%> / <%=dtAnnunci.Rows[i]["Comuni_Comune"].ToString()%></p>
							</div>
							<div class="ad-box-info">
							<%  if (dtAnnunci.Rows[i]["Annunci_Vetrina"].Equals(true)){ %>
									<div class="ad-vetrina">VETRINA</div>
							<% } %>


								<%
                Response.Write(getAttributi(i, dtAnnunci));
                %>
                <div>
                <%
								if (dtAnnunci.Rows[i]["Annunci_Descrizione"].ToString()!=null && StripHTML(dtAnnunci.Rows[i]["Annunci_Descrizione"].ToString()).Length>150){
									Response.Write(StripHTML(dtAnnunci.Rows[i]["Annunci_Descrizione"].ToString()).Substring(0,150) + "...");
								}else{
									Response.Write(StripHTML(dtAnnunci.Rows[i]["Annunci_Descrizione"].ToString()));
								}
								%>
                </div>
							</div>
						</div>
						<div class="ad-box-details">
								<div class="grid-x align-middle">
									<div class="large-6 medium-6 small-8 cell">
										<% if ((dtAnnunci.Rows[i]["Annunci_Valore"].ToString().Length>0) && ((decimal)dtAnnunci.Rows[i]["Annunci_Valore"])!=0){ %>
										<span class="ad-price">&euro; <%=((decimal)dtAnnunci.Rows[i]["Annunci_Valore"]).ToString("N0", ci)%></span>
										<% } %>
									</div>
									<div class="large-6 medium-6 small-4 cell text-right">
										<a href="/frontend/base/wishlist/aggiungi-wishlist.aspx?Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>&azione=new&cosa=annunci" rel="nofollow" data-tooltip aria-haspopup="true" class="has-tip" title="aggiungi ai preferiti"><i class="fa-duotone fa-heart-o fa-lg fa-fw"></i></a>
										<a href="/annuncio/<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>.html" class="button small">Dettagli <i class="fa-duotone fa-angle-right fa-fw"></i></a>
									</div>
								</div>
						</div>
					</div>
				</div>
			
			</div>
		</article>
  <% } %>
</div>
<asp:Label ID="PaginaSotto" runat="server" class="paginazione"></asp:Label>
