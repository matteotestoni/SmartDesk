<% if (dtAsteEsperimentiWishlist.Rows.Count>0){ %>
<h2>Le aste che seguo</h2>
<hr>
<div class="contenitore-aste">
			<div class="grid-x grid-padding-x elenco-aste small-up-1 medium-up-2 large-up-3 xlarge-up-4">
					<% for (int i = 0; i < dtAsteEsperimentiWishlist.Rows.Count; i++){%>
			      <div class="cell">
              <div class="card">
			          <div class="card-divider"><strong><%=dtAsteEsperimentiWishlist.Rows[i]["Aste_Titolo"].ToString()%></strong></div>
                <a class="link" href="/frontend/base/aste/scheda-asta.aspx?AsteEsperimenti_Ky=<%=dtAsteEsperimentiWishlist.Rows[i]["AsteEsperimenti_Ky"].ToString()%>&Aste_Ky=<%=dtAsteEsperimentiWishlist.Rows[i]["Aste_Ky"].ToString()%>">
                  <img src="<%=dtAsteEsperimentiWishlist.Rows[i]["Aste_Foto1"].ToString()%>" class="lazyload" loading="lazy">
                </a>
                <div class="card-section">
    			          <span class="aggiungiwishlist" data-tooltip aria-haspopup="true" class="has-tip" data-disable-hover="false" tabindex="1" title="Non seguire asta"><a href="/frontend/base/wishlist/rimuovi-wishlist.aspx?AsteEsperimenti_Ky=<%=dtAsteEsperimentiWishlist.Rows[i]["AsteEsperimenti_Ky"].ToString()%>&Aste_Ky=<%=dtAsteEsperimentiWishlist.Rows[i]["Aste_Ky"].ToString()%>&azione=delete&cosa=aste"><i class="fa-duotone fa-circle-minus fa-lg fa-fw"></i></a></span>
    			          <span class="label alert">-<%=dtAsteEsperimentiWishlist.Rows[i]["AsteEsperimenti_PercentualeRibasso"].ToString()%>%</span>
    			          <span class="label secondary">1 lotto</span>
    			          <div class="align-middle">
         			          <div class="grid-x grid-padding-x collapse">
        			              <div class="large-12 medium-12 small-12 cell text-left">
        			              	<i class="fa-duotone fa-fw fa-key"></i>Codice: <%=dtAsteEsperimentiWishlist.Rows[i]["Aste_Numero"].ToString()%>
        			              </div>
        			          </div>
        			          <div class="grid-x grid-padding-x collapse">
        			              <div class="large-12 medium-12 small-12 cell text-left">
        			              	<i class="fa-duotone fa-fw fa-tag"></i><%=dtAsteEsperimentiWishlist.Rows[i]["AsteCategorie_Titolo"].ToString()%>
        			              </div>
        			          </div>
        			          <div class="grid-x grid-padding-x collapse" style="margin-bottom:10px;">
        			              <div class="large-12 medium-12 small-12 cell">
        			              	<i class="fa-duotone fa-fw fa-hashtag"></i>Esperimento: <%=dtAsteEsperimentiWishlist.Rows[i]["AsteEsperimenti_Numero"].ToString()%>&deg;
        			              </div>
        			          </div>
        			          <div class="grid-x grid-padding-x" style="margin-bottom:10px;">
        			              <div class="large-12 medium-12 small-12 cell">
        			              	<span class="locazione-asta"><i class="fa-duotone fa-fw fa-location-dot"></i><img src="/frontend/base/img/icona-ita.png" style="margin-right:5px"><%=dtAsteEsperimentiWishlist.Rows[i]["Comuni_Comune"].ToString()%></span>
        			              </div>
        			          </div>
        			          <div class="grid-x grid-padding-x align-middle">
        			              <div class="large-3 medium-3 small-3 cell text-right">
        			              	<i class="fa-duotone fa-timer fa-fw fa-2xl" style="--fa-secondary-color:#ff6c00;"></i>
        			              </div>
        			              <div class="large-9 medium-9 small-9 cell text-left">
                              <input type="hidden" id="datascadenzaasta-<%=dtAsteEsperimentiWishlist.Rows[i]["Aste_Ky"].ToString()%>" data-countdown="countdownasta-<%=dtAsteEsperimentiWishlist.Rows[i]["Aste_Ky"].ToString()%>" name="datascadenzaasta-<%=dtAsteEsperimentiWishlist.Rows[i]["Aste_Ky"].ToString()%>" value="<%=Convert.ToDateTime(dtAsteEsperimentiWishlist.Rows[i]["AsteEsperimenti_DataTermine"]).ToString("M/d/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":")%>" class="datascadenzaasta">
        			              	<div id="countdownasta-<%=dtAsteEsperimentiWishlist.Rows[i]["Aste_Ky"].ToString()%>" style="text-align:left" class="scadenza-asta"></div>
        			              </div>
        			          </div>
    			        </div>
                </div>
                <div class="card-divider align-middle">
      			      <div class="text-center" style="width:100%;">
    			          <a class="button small warning btn-offerta" href="/frontend/base/aste/scheda-asta.aspx?AsteEsperimenti_Ky=<%=dtAsteEsperimentiWishlist.Rows[i]["AsteEsperimenti_Ky"].ToString()%>&Aste_Ky=<%=dtAsteEsperimentiWishlist.Rows[i]["Aste_Ky"].ToString()%>">Scopri i lotti</a>
                  </div>
                </div>
                
              </div>
			      </div>
					<% } %>
			
			</div>                
</div>
<% } %>
