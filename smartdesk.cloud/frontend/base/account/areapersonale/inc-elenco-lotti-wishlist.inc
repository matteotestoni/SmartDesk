<% if (dtLottiWishlist.Rows.Count>0){ %>
<h2>I lotti che seguo</h2>
<hr>
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
    <% for (int i = 0; i < dtLottiWishlist.Rows.Count; i++){%>
    <div class="card">
      <div class="card-section">
      <div class="grid-x grid-padding-x">
            <div class="large-2 medium-3 xlarge-2 small-12 cell ">
              <img src="<%=dtLottiWishlist.Rows[i]["Annunci_Foto1"].ToString()%>" class="lazyload" loading="lazy">
                <a href="/frontend/base/aste/scheda-lotto.aspx?Annunci_Ky=<%=dtLottiWishlist.Rows[i]["Annunci_Ky"].ToString()%>" class="link"></a>
			          <span class="aggiungiwishlist" data-tooltip aria-haspopup="true" class="has-tip" data-disable-hover="false" tabindex="1" title="Non seguire lotto"><a href="/frontend/base/wishlist/rimuovi-wishlist.aspx?Annunci_Ky=<%=dtLottiWishlist.Rows[i]["Annunci_Ky"].ToString()%>&azione=delete&cosa=annunci"><i class="fa-duotone fa-circle-minus fa-lg fa-fw"></i></a></span>
                <span class="numerofotoelenco"><i class="fa-duotone fa-camera fa-fw"></i><%=dtLottiWishlist.Rows[i]["Annunci_NumeroFoto"].ToString()%></span>
            </div>
            <div class="large-8 medium-7 xlarge-8 small-12 cell">
                <div class="grid-x grid-padding-x">
                    <div class="large-12 medium-12 small-12 cell">
                     <a href="/scheda-lotto.aspx?Annunci_Ky=<%=dtLottiWishlist.Rows[i]["Annunci_Ky"].ToString()%>"><span class="titolo-lotto"><%=dtLottiWishlist.Rows[i]["Annunci_Titolo"].ToString()%></span></a>
                    </div>
                </div>
                <div class="grid-x grid-padding-x">
                    <div class="large-12 medium-12 small-12 cell">
                        <%
                        Response.Write(getAttributiAnnunci(dtLottiWishlist, i));
                        %>
                    </div>
                </div>
                <div class="localizzazione-elenco"><img src="/frontend/base/img/icona-ita.png" style="margin-right:5px"><%=dtLottiWishlist.Rows[i]["Nazioni_Codice"].ToString()%> / <%=dtLottiWishlist.Rows[i]["Regioni_Regione"].ToString()%> / <%=dtLottiWishlist.Rows[i]["Comuni_Comune"].ToString()%></div>
                <div class="label secondary"><span style="color: #ff6c00">ID ASTA:</span>&nbsp;<%=dtLottiWishlist.Rows[i]["Aste_Numero"].ToString()%></div>
                <div class="label secondary"><span style="color: #ff6c00">LOTTO:</span>&nbsp;<%=dtLottiWishlist.Rows[i]["Annunci_Numero"].ToString()%></div>
                <div class="label secondary"><span style="color: #ff6c00">CATEGORIA:</span>&nbsp;<%=dtLottiWishlist.Rows[i]["AnnunciCategorie_Titolo"].ToString()%></div>
            </div>
            <div class="large-2 medium-2 small-12 xlarge-2 cell text-right dettagli-lotto">
                <% if (dtLottiWishlist.Rows[i]["AnnunciOfferte_ValoreAttuale"].ToString().Length>0){ %>
                  <p class="text-center"><strong>&euro; <%=((decimal)dtLottiWishlist.Rows[i]["AnnunciOfferte_ValoreAttuale"]).ToString("N0", ci)%></strong></p>
                <% }else{ %> 
                  <p class="text-center"><strong>&euro; <%=((decimal)dtLottiWishlist.Rows[i]["Annunci_Valore"]).ToString("N0", ci)%></strong></p>
                <% } %> 
                <a href="/frontend/base/aste/scheda-lotto.aspx?Annunci_Ky=<%=dtLottiWishlist.Rows[i]["Annunci_Ky"].ToString()%>" class="button small radius warning expanded">Fai offerta</a>
            </div>
      </div>
    </div>
    </div>
    <% } %>
  </div>
</div>
<% } %>

