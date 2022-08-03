<div class="grid-x grid-padding-x elenco-aste small-up-1 medium-up-2 large-up-4 xlarge-up-5" data-equalizer="elenco-aste-home" data-equalizer data-equalize-on="medium" id="elenco-aste-home">
    <% for (int i = 0; i < dtProdotti.Rows.Count; i++){%>
			<div class="cell">
        <div class="card prodottitipo<%=dtProdotti.Rows[i]["ProdottiTipo_Ky"].ToString()%>">
          <div class="card-divider">
            <a href="/fronted/base/catalogo/scheda-prodotti.aspx?Prodotti_Ky=<%=dtProdotti.Rows[i]["Prodotti_Ky"].ToString()%>"><%=dtProdotti.Rows[i]["Prodotti_Titolo"].ToString()%></a>
          </div>
          <div class="card-img">
             <img src="<%=dtProdotti.Rows[i]["Prodotti_Foto1"].ToString()%>">
             <span class="aggiungiwishlist" data-tooltip aria-haspopup="true" class="has-tip" data-disable-hover="false" tabindex="1" title="Segui"><a href="/frontend/base/wishlist/aggiungi-wishlist.aspx?Prodotti_Ky=<%=dtProdotti.Rows[i]["Prodotti_Ky"].ToString()%>&azione=new&cosa=annunci"><i class="fa-duotone fa-heart fa-lg fa-fw"></i></a></span>
          </div>
          <div class="card-section">
            <p class="text-center"><strong>&euro; <%=((decimal)dtProdotti.Rows[i]["Prodotti_Prezzo"]).ToString("N0", ci)%></strong></p>
            <a href=/fronted/base/catalogo/scheda-prodotti.aspx?Prodotti_Ky=<%=dtProdotti.Rows[i]["Prodotti_Ky"].ToString()%>" class="button small radius buttonannunci expanded">Vedi</a>
          </div>
        </div>
      </div>
    <% } %>
</div>
  
