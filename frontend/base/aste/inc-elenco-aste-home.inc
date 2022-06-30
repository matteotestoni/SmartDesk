<div class="contenitore-aste">
			<div class="grid-x grid-padding-x elenco-aste small-up-1 medium-up-2 large-up-4 xlarge-up-5" data-equalizer="elenco-aste-home" data-equalizer data-equalize-on="medium" id="elenco-aste-home">
					<% for (int i = 0; i < dtAsteEsperimenti.Rows.Count; i++){
              strWHERENet = "Aste_Ky =" + dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString();
              strORDERNet = "Annunci_Ky";
              strFROMNet = "Annunci";
              dtLottiAsta = Smartdesk.Sql.getTablePage(strFROMNet, null, "Annunci_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
             
          %>
			      <div class="cell">
              <div class="scheda-asta-elenco">
                <div class="foto-elenco-aste" style="background-image:url('<%=dtAsteEsperimenti.Rows[i]["Aste_Foto1"].ToString()%>');">
                <a class="link" href="/frontend/base/aste/scheda-asta.aspx?AsteEsperimenti_Ky=<%=dtAsteEsperimenti.Rows[i]["AsteEsperimenti_Ky"].ToString()%>&Aste_Ky=<%=dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString()%>">
                </a>
                </div>
			          <span class="aggiungiwishlist" data-tooltip aria-haspopup="true" class="has-tip" data-disable-hover="false" tabindex="1" title="Segui asta"><a href="/frontend/base/wishlist/aggiungi-wishlist.aspx?Aste_Ky=<%=dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString()%>&azione=new&cosa=aste"><i class="fa-duotone fa-heart fa-lg fa-fw"></i></a></span>
			          <span class="percentuale-sconto">-<%=dtAsteEsperimenti.Rows[i]["AsteEsperimenti_PercentualeRibasso"].ToString()%>%</span>
			          <span class="numero-lotti">
                <%
                if (dtLottiAsta.Rows.Count>1){
                  Response.Write(dtLottiAsta.Rows.Count + " lotti");
                }else{
                  Response.Write(dtLottiAsta.Rows.Count + " lotto");
                } %>
                </span>
			          <div class="dettagli-asta-container align-middle">
  			          <div class="dettagli-asta" data-equalizer-watch="elenco-aste-home">
    			          <span class="titolo-asta"><%=dtAsteEsperimenti.Rows[i]["Aste_Titolo"].ToString()%></span>
    			          <div class="grid-x grid-padding-x collapse">
    			              <div class="large-12 medium-12 small-12 cell text-left">
    			              	<span class="valore-codice-asta">ID Asta: <%=dtAsteEsperimenti.Rows[i]["Aste_Numero"].ToString()%></span>
    			              </div>
    			          </div>
    			          <div class="grid-x grid-padding-x collapse">
    			              <div class="large-12 medium-12 small-12 cell text-left">
    			              	<span class="valore-categoria-asta"><%=dtAsteEsperimenti.Rows[i]["AsteCategorie_Titolo"].ToString()%></span>
    			              </div>
    			          </div>
    			          <div class="grid-x grid-padding-x collapse">
    			              <div class="large-12 medium-12 small-12 cell">
    			              	<span class="esperimento-asta">Esperimento: <%=dtAsteEsperimenti.Rows[i]["AsteEsperimenti_Numero"].ToString()%>&deg;</span>
    			              </div>
    			          </div>
    			          <div class="grid-x grid-padding-x collapse" style="margin-bottom:10px;">
    			              <div class="large-12 medium-12 small-12 cell">
    			              	<span class="esperimento-asta"><img src="/frontend/base/img/icona-ita.png" style="margin-right:5px"><%=dtAsteEsperimenti.Rows[i]["Comuni_Comune"].ToString()%></span>
    			              </div>
    			          </div>
    			          <div class="grid-x grid-padding-x collapse align-middle">
    			              <div class="large-2 medium-2 small-3 cell">
    			              	<i class="fa-duotone fa-timer fa-fw fa-2xl" style="--fa-secondary-color:#ff6c00;"></i>
    			              </div>
    			              <div class="large-10 medium-10 small-9 cell text-right">
                          <input type="hidden" id="datascadenzaasta-<%=dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString()%>" data-countdown="countdownasta-<%=dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString()%>" name="datascadenzaasta-<%=dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString()%>" value="<%=Convert.ToDateTime(dtAsteEsperimenti.Rows[i]["AsteEsperimenti_DataTermine"]).ToString("M/d/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":")%>" class="datascadenzaasta">
    			              	<div id="countdownasta-<%=dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString()%>" class="scadenza-asta"></div>
    			              </div>
    			          </div>
  			          </div>
                  <div class="text-center align-middle">
  			           <a class="button small warning" href="/frontend/base/aste/scheda-asta.aspx?AsteEsperimenti_Ky=<%=dtAsteEsperimenti.Rows[i]["AsteEsperimenti_Ky"].ToString()%>&Aste_Ky=<%=dtAsteEsperimenti.Rows[i]["Aste_Ky"].ToString()%>">Scopri i lotti<i class="fa-duotone fa-angle-right fa-fw"></i></a>
                  </div>
			          </div>
			        </div>
			      </div>
					<% } %>
			</div>                
</div>
