<div class="grid-x grid-padding-x">
	<div class="large-12 medium-12 small-12 cell">
    <a name="elenco-lotti"></a> <h2 class="h2-aste-online"><b>LOTTI</b> DELL'ASTA COD. <%=dtAsteEsperimenti.Rows[0]["Aste_Numero"].ToString()%></h2>
    <hr>

			<% for (int j = 0; j < dtAnnunci.Rows.Count; j++){%>
        <div class="card">
          <div class="card-section">
          	<div class="grid-x grid-padding-x">
              <div class="large-3 medium-3 small-12 cell ">
                 <a href="/frontend/base/aste/scheda-lotto.aspx?AsteEsperimenti_Ky=<%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Ky"].ToString()%>&Aste_Ky=<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>&Annunci_Ky=<%=dtAnnunci.Rows[j]["Annunci_Ky"].ToString()%>" class="link">
                 <% 
            			if (dtAnnunci.Rows[j]["Annunci_Foto1"].ToString().Length>0){
            				strFoto=dtAnnunci.Rows[j]["Annunci_Foto1"].ToString();	
            			}else{
            				strFoto="https://static.pexels.com/photos/248064/pexels-photo-248064.jpeg";	
            			}
                %>
                <img src="<%=strFoto%>" class="lazyload" loading="lazy">
                </a>
                <span class="aggiungiwishlist" data-tooltip aria-haspopup="true" class="has-tip" data-disable-hover="false" tabindex="1" title="Segui lotto"><a href="/frontend/base/wishlist/aggiungi-wishlist.aspx?Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>&azione=new&cosa=annunci"><i class="fa-duotone fa-heart fa-lg fa-fw"></i></a></span>
  	            <span class="numerofotoelenco"><i class="fa-duotone fa-camera fa-fw"></i><%=dtAnnunci.Rows[j]["Annunci_NumeroFoto"].ToString()%></span>
                <span class="percentuale-sconto-lotto">-<%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_PercentualeRibasso"].ToString()%>%</span>
              </div>
              <div class="large-6 medium-6 small-12 cell">
                 <div class="titololotto">
                 <% 
  							 switch (dtAnnunci.Rows[j]["AnnunciTipo_Ky"].ToString()){
  							 	case "1":%>
                  		<a href="/frontend/base/aste/scheda-annuncio.aspx?AsteEsperimenti_Ky=<%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Ky"].ToString()%>&Aste_Ky=<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>&Annunci_Ky=<%=dtAnnunci.Rows[j]["Annunci_Ky"].ToString()%>"><span class="titolo-lotto"><%=dtAnnunci.Rows[j]["Annunci_Titolo"].ToString()%></span></a>
  									 <%break;
  							 	case "2":%>
                  		<a href="/frontend/base/aste/scheda-lotto.aspx?AsteEsperimenti_Ky=<%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Ky"].ToString()%>&Aste_Ky=<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>&Annunci_Ky=<%=dtAnnunci.Rows[j]["Annunci_Ky"].ToString()%>"><span class="titolo-lotto"><%=dtAnnunci.Rows[j]["Annunci_Titolo"].ToString()%></span></a>
  							 		<%break;
  							 	case "3":%>
                  		<a href="/frontend/base/aste/scheda-immobile.aspx?AsteEsperimenti_Ky=<%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Ky"].ToString()%>&Aste_Ky=<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>&Annunci_Ky=<%=dtAnnunci.Rows[j]["Annunci_Ky"].ToString()%>"><span class="titolo-lotto"><%=dtAnnunci.Rows[j]["Annunci_Titolo"].ToString()%></span></a>
  							 		<%break;
  							 }%>
                 </div>
                <%
                Response.Write(getAttributi(j));
                %>
                <div class="localizzazione-lotto">
                  <i class="fa-duotone fa-location-dot fa-fw"></i><%=dtAnnunci.Rows[i]["Nazioni_Nazione"].ToString()%> / <%=dtAnnunci.Rows[i]["Regioni_Regione"].ToString()%> / <%=dtAnnunci.Rows[i]["Comuni_Comune"].ToString()%>
                </div>
                <div class="attributi-lotto">
                  <span style="color: #ff6c00">ASTA:</span>&nbsp;<%=dtAsteEsperimenti.Rows[0]["Aste_Numero"].ToString()%> - 
                  <span style="color: #ff6c00">LOTTO:</span>&nbsp;<%=dtAnnunci.Rows[j]["Annunci_Numero"].ToString()%> - 
                  <span style="color: #ff6c00">CATEGORIA:</span>&nbsp;<%=dtAnnunci.Rows[j]["AnnunciCategorie_Titolo"].ToString()%>
                </div>
              </div>
              <div class="large-3 medium-3 small-12 xlarge-2 cell text-center">
                  <% if (dtAsteEsperimenti.Rows[0]["AsteEsperimenti_DataTermine"]!=null){ %>
                     <span style="color: #ff6c00">SCADE IL:</span><br><%=(dtAsteEsperimenti.Rows[0]["AsteEsperimenti_DataTermine"]).ToString()%><br>
                  <% } %>
                  <% if (dtAnnunci.Rows[j]["AnnunciOfferte_ValoreAttuale"].ToString().Length>0){ %>
                    <p class="text-center"><strong>&euro; <%=((decimal)dtAnnunci.Rows[j]["AnnunciOfferte_ValoreAttuale"]).ToString("N0", ci)%></strong></p>
                  <% }else{ %> 
                    <p class="text-center"><strong>&euro; <%=((decimal)dtAnnunci.Rows[j]["Annunci_Valore"]).ToString("N0", ci)%></strong></p>
                  <% } %> 
                 <a href="/frontend/base/aste/scheda-lotto.aspx?AsteEsperimenti_Ky=<%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Ky"].ToString()%>&Aste_Ky=<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>&Annunci_Ky=<%=dtAnnunci.Rows[j]["Annunci_Ky"].ToString()%>" class="button small radius warning expanded">Vedi lotto</a>
              </div>
						</div>
          </div>
        </div>
      	<% } %>
	</div>
</div>
