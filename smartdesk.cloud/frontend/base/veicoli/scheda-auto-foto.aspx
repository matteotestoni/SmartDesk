<%if (dtVeicolo.Rows[0]["Veicoli_Foto1"].ToString().Length>0){ %>
<div class="imgscheda" style="position:relative;">
    <div class="corner-ribbon">
		<% if (dtVeicolo.Rows[0]["VeicoliNormativeEuro_Ecoincentivi"].Equals(true) 
            && ((decimal)dtVeicolo.Rows[0]["Veicoli_Valore"]<25000) 
            && (dtVeicolo.Rows[0]["VeicoliCarburante_Ky"].ToString()!="6")){ %>
            <span class="ecoincentiviribbon hide">Ecoincentivo statale</span><br>
        <% } %>
        <% if(dtVeicolo.Rows[0]["Veicoli_BestPrice"].Equals(true)){ %><span class="bestpriceribbon"></span><br><% } %>
        <% if(dtVeicolo.Rows[0]["Veicoli_Premium"].Equals(true)){ %><span class="topcarribbon">Topcar</span><br><% } %>
        <% if(dtVeicolo.Rows[0]["VeicoliCarburante_Ecologico"].Equals(true)){ %><span class="ecoribbon">Eco <i class="fa-solid fa-leaf text-primary"></i></span><br><% } %>
        <% if(dtVeicolo.Rows[0]["VeicoliCategoria_Ky"].ToString() == "7"){ %><span class="km0ribbon">KM 0</span><br><% } %>
        <% if(dtVeicolo.Rows[0]["Veicoli_Neopatentati"].Equals(true)){ %><span class="neopatentatiribbon">Neopatentati</span><br><% } %>
        <%
												if (dtVeicoloOfferteAuto.Rows.Count>0 && dtVeicoloOfferteAuto.Rows[0]["VeicoliOfferte_Mostraetichetta"].Equals(true)){
														Response.Write("<span class=\"promoribbon\" style=\"color:" + dtVeicoloOfferteAuto.Rows[0]["VeicoliOfferte_ColoreTesto"].ToString() + ";background-color:" + dtVeicoloOfferteAuto.Rows[0]["VeicoliOfferte_ColoreSfondo"].ToString() + "\">");
														Response.Write(dtVeicoloOfferteAuto.Rows[0]["VeicoliOfferte_Etichetta"].ToString() + "</span><br>");
													}
																		
													if (dtLandi.Rows.Count > 0)
													{
													Response.Write("<span class=\"landiribbon\">Impianto GPL Landi</span>");
													}
												%>
    </div>
    
    <a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto1"].ToString()%>" data-fancybox="gallery" class="gallery"
        rel="gallery"><img src="/frontend/spazio/img/icon-soddisfatto-o-cambiauto.svg" alt="Soddisfatto o cambi auto" class="badge-soddisfatto-scheda" width="100" height="100"><img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto1"].ToString()%>" border="0" alt="<%=strH1%>" class="lazyload" loading="lazy" width="503" height="377" /></a>
    <% if (strDipendentifca=="1" && (dtVeicolo.Rows[0]["VeicoliMarcaSpazioGroup_Marca"].ToString().ToLower().Trim().Equals("fiat") || dtVeicoli.Rows[i]["VeicoliMarcaSpazioGroup_Marca"].ToString().ToLower()=="alfa romeo" || dtVeicoli.Rows[i]["VeicoliMarcaSpazioGroup_Marca"].ToString().ToLower()=="abarth" || dtVeicoli.Rows[i]["VeicoliMarcaSpazioGroup_Marca"].ToString().ToLower()=="jeep" || dtVeicoli.Rows[i]["VeicoliMarcaSpazioGroup_Marca"].ToString().ToLower()=="alfa" || dtVeicoli.Rows[i]["VeicoliMarcaSpazioGroup_Marca"].ToString().ToLower()=="lancia")){ %><div class="sconto-<%=dtVeicoli.Rows[i]["VeicoliModello_Tipo"].ToString().Trim().ToLower()%>"></div><% } %>
    <a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto1"].ToString()%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f0">
        <span class="counter"><i class="fa-duotone fa-fw fa-camera"></i> <%=GetNumeroFotoVeicolo(dtVeicolo.Rows[0])%> foto</span>
    </a>
</div>
<%}else{ %>
<div class="noFotoScheda" width="350" height="263" id="anteprima">
    <img src="https://via.placeholder.com/503x377.webp?text=nessun+immagine" class="lazyload" loading="lazy" width="503" height="377">
</div>
<% } %>
<div class="scheda-gallery hide-for-small-only">
    <div class="grid-x grid-padding-x small-up-2 medium-up-4 large-up-6">
        <%if (dtVeicolo.Rows[0]["Veicoli_Foto2"].ToString().Length>0){ %>
          <div class="cell">
            <a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto2"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f2">
              <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto2"].ToString()%>" border="0" alt="<%=strH1%>" class="thumbnail lazyload" loading="lazy" width="59" height="44" />
            </a>
          </div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto3"].ToString().Length>0){ %>
        <div class="cell">
          <a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto3"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f3">
            <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto3"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
          </a>
        </div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto4"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto4"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f4">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto4"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto5"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto5"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f5">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto5"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto6"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto6"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f6">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto6"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto7"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto7"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f7">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto7"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto8"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto8"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f8">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto8"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto9"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto9"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f9">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto9"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto10"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto10"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f10">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto10"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto11"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto11"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f11">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto11"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto12"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto12"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f12">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto12"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto13"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto13"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f13">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto13"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto14"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto14"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f14">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto14"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto15"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto15"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f15">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto15"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto16"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto16"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f16">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto16"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto17"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto17"].ToString()%>" title="<%=strH1%>" ata-fancybox="gallery" class="gallery" rel="gallery" id="f17">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto17"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto18"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto18"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f18">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto18"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto19"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto19"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f19">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto19"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <%}if (dtVeicolo.Rows[0]["Veicoli_Foto20"].ToString().Length>0){ %>
        <div class="cell"><a href="<%=dtVeicolo.Rows[0]["Veicoli_Foto20"].ToString()%>" title="<%=strH1%>" data-fancybox="gallery" class="gallery" rel="gallery" id="f20">
                <img src="<%=dtVeicolo.Rows[0]["Veicoli_Foto20"].ToString()%>" border="0" alt="<%=strH1%>" width="59" height="44" style="width:100px;height:50px" class="thumbnail lazyload" loading="lazy" />
            </a></div>
        <% } %>
    </div>
</div>