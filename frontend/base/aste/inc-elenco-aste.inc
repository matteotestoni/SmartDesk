<div class="contenitore-aste">
			<div class="grid-x grid-padding-x elenco-aste small-up-1 medium-up-2 large-up-3 xlarge-up-4" data-equalizer="elenco-aste" data-equalizer data-equalize-on="medium" id="elenco-aste">
					<% for (int i = 0; i < dtAsteEsperimenti.Rows.Count; i++){
              strWHERENet = "Aste_Ky =" + dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString();
              strORDERNet = "Annunci_Ky";
              strFROMNet = "Annunci";    
              dtLottiAsta = Smartdesk.Sql.getTablePage(strFROMNet, null, "Annunci_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          %>
			      <div class="cell">
              <div class="card scheda-asta-elenco">
                <div class="card-divider"><strong><%=dtAsteEsperimenti.Rows[i]["Aste_Titolo"].ToString()%></strong></div>
                <a href="/frontend/base/aste/scheda-asta.aspx?AsteEsperimenti_Ky=<%=dtAsteEsperimenti.Rows[i]["AsteEsperimenti_Ky"].ToString()%>&Aste_Ky=<%=dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString()%>"><img src="<%=dtAsteEsperimenti.Rows[i]["Aste_Foto1"].ToString()%>" class="lazy" loading="lazy"></a>
                <div class="card-section">
    			          <span class="aggiungiwishlist" data-tooltip aria-haspopup="true" class="has-tip" data-disable-hover="false" tabindex="1" title="Segui asta"><a href="/frontend/base/wishlist/aggiungi-wishlist.aspx?Aste_Ky=<%=dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString()%>&azione=new&cosa=aste"><i class="fa-duotone fa-heart fa-fw"></i></a></span>
    			          <span class="label alert" data-tooltip aria-haspopup="true" class="has-tip" data-disable-hover="false" tabindex="1" title="Ribasso dall'inizio">-<%=dtAsteEsperimenti.Rows[i]["AsteEsperimenti_PercentualeRibasso"].ToString()%>%</span>
    			          <span class="label secondary">
                    <%
                    if (dtLottiAsta.Rows.Count>1){
                      Response.Write(dtLottiAsta.Rows.Count + " lotti");
                    }else{
                      Response.Write(dtLottiAsta.Rows.Count + " lotto");
                    } %>                
                    </span>
    			          <div class="align-middle">
      			          <div data-equalizer-watch="elenco-aste">
        			          <div class="grid-x grid-padding-x">
        			              <div class="large-12 medium-12 small-12 cell text-left">
        			              	<i class="fa-duotone fa-fw fa-key"></i>Codice: <%=dtAsteEsperimenti.Rows[i]["Aste_Numero"].ToString()%>
        			              </div>
        			          </div>
        			          <div class="grid-x grid-padding-x">
        			              <div class="large-12 medium-12 small-12 cell text-left">
        			              	<i class="fa-duotone fa-fw fa-tag"></i><%=dtAsteEsperimenti.Rows[i]["AsteCategorie_Titolo"].ToString()%>
        			              </div>
        			          </div>
        			          <div class="grid-x grid-padding-x">
        			              <div class="large-12 medium-12 small-12 cell">
        			              	<i class="fa-duotone fa-fw fa-hashtag"></i>Esperimento: <%=dtAsteEsperimenti.Rows[i]["AsteEsperimenti_Numero"].ToString()%>&deg;
        			              </div>
        			          </div>
        			          <div class="grid-x grid-padding-x" style="margin-bottom:10px;">
        			              <div class="large-12 medium-12 small-12 cell">
        			              	<span class="locazione-asta"><i class="fa-duotone fa-fw fa-location-dot"></i><img src="/frontend/base/img/icona-ita.png" style="margin-right:5px"><%=dtAsteEsperimenti.Rows[i]["Comuni_Comune"].ToString()%></span>
        			              </div>
        			          </div>
        			          <div class="grid-x grid-padding-x align-middle">
        			              <div class="large-3 medium-3 small-3 cell text-right">
        			              	<i class="fa-duotone fa-timer fa-fw fa-2xl" style="--fa-secondary-color:#ff6c00;"></i>
        			              </div>
        			              <div class="large-9 medium-9 small-9 cell text-left">
                              <input type="hidden" id="datascadenzaasta-<%=dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString()%>" data-countdown="countdownasta-<%=dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString()%>" name="datascadenzaasta-<%=dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString()%>" value="<%=Convert.ToDateTime(dtAsteEsperimenti.Rows[i]["AsteEsperimenti_DataTermine"]).ToString("M/d/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":")%>" class="datascadenzaasta">
        			              	<div id="countdownasta-<%=dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString()%>" style="text-align:left" class="scadenza-asta"></div>
        			              </div>
        			          </div>
      			          </div>
    			          </div>
                </div>
                <div class="card-divider align-middle">
      			      <div class="text-center" style="width:100%;">
                    <a class="button small warning" href="/frontend/base/aste/scheda-asta.aspx?AsteEsperimenti_Ky=<%=dtAsteEsperimenti.Rows[i]["AsteEsperimenti_Ky"].ToString()%>&Aste_Ky=<%=dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString()%>">Scopri i lotti<i class="fa-duotone fa-angle-right fa-fw"></i></a>
                  </div>
                </div>
                
                
			        </div>
    			  </div>
					<% } %>
			</div>                
</div>
