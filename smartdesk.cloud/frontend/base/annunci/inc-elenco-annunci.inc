<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
    <% for (int i = 0; i < dtAnnunci.Rows.Count; i++){%>
      <div class="listaannunci annuncitipo<%=dtAnnunci.Rows[i]["AnnunciTipo_Ky"].ToString()%>">
      <div class="grid-x grid-padding-x">
            <div class="large-2 medium-3 xlarge-2 small-12 cell ">
                  <div class="foto-elenco-annunnci" style="background-image:url('<%=dtAnnunci.Rows[i]["Annunci_Foto1"].ToString()%>');">
                   <% if (dtAnnunci.Rows[i]["AnnunciTipo_Ky"].ToString()=="1"){ %>
                     <a href="/scheda-annuncio.aspx?Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>" class="link">
                   <% }else{ %>
                     <a href="/scheda-lotto.aspx?Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>" class="link">
                   <% } %>
                  </a>
			             <span class="aggiungiwishlist" data-tooltip aria-haspopup="true" class="has-tip" data-disable-hover="false" tabindex="1" title="Segui annuncio"><a href="/frontend/base/wishlist/aggiungi-wishlist.aspx?Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>&azione=new&cosa=annunci"><i class="fa-duotone fa-heart fa-lg fa-fw"></i></a></span>
			             <span class="numerofotoelenco"><i class="fa-duotone fa-camera fa-fw"></i><%=dtAnnunci.Rows[i]["Annunci_NumeroFoto"].ToString()%></span>
                  </div>
            </div>
            <div class="large-8 medium-7 xlarge-8 small-12 cell">
                <div class="grid-x grid-padding-x">
                    <div class="large-12 medium-12 small-12 cell">
                     <span class="titolo-annunci-simili">
                     <% if (dtAnnunci.Rows[i]["AnnunciTipo_Ky"].ToString()=="1"){ %>
                       <a href="/scheda-annuncio.aspx?Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>"><%=dtAnnunci.Rows[i]["Annunci_Titolo"].ToString()%></a>
                     <% }else{ %>
                       <a href="/scheda-lotto.aspx?Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>"><%=dtAnnunci.Rows[i]["Annunci_Titolo"].ToString()%></a>
                     <% } %>
                     </span>
                    </div>
                </div>
                <div class="grid-x grid-padding-x">
                    <div class="large-12 medium-12 small-12 cell">
                      <div style="min-height:1.5rem">
                        <%
                        Response.Write(getAttributi(i));
                        %>
                      </div>
                    </div>
                </div>
                <div class="grid-x grid-padding-x" style="margin-top:1.5rem;">
                    <div class="large-12 medium-12 small-12 cell">
                       <span class="localizzazione-elenco"><img src="https://cdn.smartdesk.cloud/img/flags/it.png" style="margin-right:5px"><%=dtAnnunci.Rows[i]["Nazioni_Codice"].ToString()%> / <%=dtAnnunci.Rows[i]["Regioni_Regione"].ToString()%> / <%=dtAnnunci.Rows[i]["Comuni_Comune"].ToString()%></span>
                    </div>
                </div>
                <div class="grid-x grid-padding-x" style="margin-top:0.5rem;">
                    <div class="large-12 medium-12 small-12 cell">
                     <% if (dtAnnunci.Rows[i]["AnnunciTipo_Ky"].ToString()=="1"){ %>
                        <div class="attributi-lotto hide-for-small-only"><span>ID ANNUNCIO:</span> <%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%></div>
                        <div class="attributi-lotto"><span>CATEGORIA:</span> <%=dtAnnunci.Rows[i]["AnnunciCategorie_Titolo"].ToString()%></div>
                        <div class="attributi-lotto"></div>
                     <% }else{ %>
                        <div class="attributi-lotto"><span style="color: #ff6c00">ID ASTA:</span>&nbsp;<%=dtAnnunci.Rows[i]["Aste_Numero"].ToString()%></div>
                        <div class="attributi-lotto"><span style="color: #ff6c00">LOTTO:</span>&nbsp;<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%></div>
                        <div class="attributi-lotto"><span style="color: #ff6c00">CATEGORIA:</span>&nbsp;<%=dtAnnunci.Rows[i]["AnnunciCategorie_Titolo"].ToString()%></div>
                     <% } %>
                    </div>
                </div>
            </div>
            <div class="large-2 medium-2 small-12 xlarge-2 cell text-right dettagli-lotto">
                <p class="text-center"><strong>&euro; <%=((decimal)dtAnnunci.Rows[i]["Annunci_Valore"]).ToString("N0", ci)%></strong></p>
                 <% if (dtAnnunci.Rows[i]["AnnunciTipo_Ky"].ToString()=="1"){ %>
                   <a href="/scheda-annuncio.aspx?Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>" class="button small radius buttonannunci expanded">Vedi annuncio</a>
                 <% }else{ %>
                   <a href="/scheda-lotto.aspx?Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>" class="button small radius warning expanded">Fai offerta</a>
                 <% } %>
            </div>
      </div>
    </div>
    <% } %>
  </div>
</div>
  
