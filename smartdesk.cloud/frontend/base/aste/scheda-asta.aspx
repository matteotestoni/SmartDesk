<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="scheda-asta.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" dir="ltr" lang="it-IT">
  <head>
  	<title><%=strH1%></title>
    <meta name="description" content="<%=strH1%>"/>
    <meta name="robots" content="noindex,nofollow">
    <meta http-equiv="refresh" content="60">
    <!--#include file="/frontend/base/inc-head.aspx"--> 
  </head>
  <body>
		<!-- #include file ="/frontend/base/inc-header.aspx" -->
    <div class="grid-container scheda-asta">
		  <div id="topasta">
        <div class="grid-x grid-padding-x">
          	<div class="large-6 medium-6 small-12 cell">
              <h1><%=dtAsteEsperimenti.Rows[0]["Aste_Titolo"].ToString()%></h1>
            </div>
          	<div class="large-6 medium-6 small-12 cell">
                  <span class="label secondary"><%=dtAnnunci.Rows.Count%> Lotti disponibili</span>
                  <a href="#elenco-lotti"><button class="vedilotti hollow button" >VEDI TUTTI I LOTTI <i class="fa-duotone fa-angle-down fa-3" aria-hidden="true"></i></button></a>
  			          <span class="aggiungiwishlist" data-tooltip aria-haspopup="true" class="has-tip" data-disable-hover="false" tabindex="1" title="Segui asta"><a href="/frontend/base/wishlist/aggiungi-wishlist.aspx?Aste_Ky=<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>&azione=new&cosa=aste"><i class="fa-duotone fa-heart fa-lg fa-fw"></i></a></span>
            </div>
        </div>
        <hr>
      </div>
    
		  <div class="grid-x grid-padding-x align-top">
        	<div class="xlarge-8 medium-up-12 large-6 small-12 cell">
          	<img src="<%=dtAsteEsperimenti.Rows[0]["Aste_Foto1"].ToString()%>" class="lazyload" loading="lazy">
		        <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell">
		                <h2><b>DESCRIZIONE</b> DELL'ASTA</h2>
		                <hr>
                    <%=dtAsteEsperimenti.Rows[0]["Aste_Descrizione"].ToString()%>
                    <%
										if (dtAsteEsperimenti.Rows[0]["Aste_Video"].ToString().Length>0){
											Response.Write("<iframe width=\"100%\" height=\"315\" src=\"https://www.youtube.com/embed/" + dtAsteEsperimenti.Rows[0]["Aste_Video"].ToString() + "\" frameborder=\"0\" gesture=\"media\" allow=\"encrypted-media\" allowfullscreen></iframe>");
										}
										%>
		            </div>
		        </div>
            <%if (dtFiles.Rows.Count>0){%>
						<a name="documentidivendita"></a>
		        <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell">
		                <h2><b>DOCUMENTI DI VENDITA</b> DELL'ASTA</h2>
		                <hr>
		            </div>
		        </div>
		        <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell">
          					<% 
                      Response.Write("<ul class=\"menu vertical\">");
                      for (int i = 0; i < dtFiles.Rows.Count; i++){
                        Response.Write("<li><a href=\"" + dtFiles.Rows[i]["Files_Path"].ToString().Replace(" ","/") + "\" target=\"_blank\"><i class=\"fa-duotone fa-external-link fa-fw\"></i>" + dtFiles.Rows[i]["Files_Titolo"].ToString() + "</a></li>");
          					  }
                      Response.Write("</ul>");
                    %>
										<br><br>
		            </div>
		        </div>
            <% } %>
						<a name="referenteasta"></a>
		        <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell">
		                <h2><b>DETTAGLI DEL REFERENTE</b> DELL'ASTA</h2>
		                <hr>
										<i class="fa-duotone fa-user fa-fw"></i><%=dtAsteEsperimenti.Rows[0]["Aste_Referente"].ToString()%><br>
										<i class="fa-duotone fa-mobile-phone fa-fw"></i><a href="tel:<%=dtAsteEsperimenti.Rows[0]["Aste_CellulareReferente"].ToString()%>"><%=dtAsteEsperimenti.Rows[0]["Aste_CellulareReferente"].ToString()%></a><br>
										<i class="fa-duotone fa-envelope fa-fw"></i><a href="mailto:<%=dtAsteEsperimenti.Rows[0]["Aste_EmailReferente"].ToString()%>"><%=dtAsteEsperimenti.Rows[0]["Aste_EmailReferente"].ToString()%></a><br>
                    <br><br>
		            </div>
		        </div>
						<a name="localizzazioneasta"></a>
		        <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell">
		                <h2><b>LOCALIZZAZIONE</b> DELL'ASTA</h2>
		                <hr>
		            </div>
		        </div>
		        <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell">
										<%
                      strIndirizzo=dtAsteEsperimenti.Rows[0]["Aste_Indirizzo"].ToString();
                      if (strIndirizzo.Length>0){
                        strIndirizzo=strIndirizzo.Replace(" ","+");
                        strIndirizzo=strIndirizzo + ",";
                      }
                      strIndirizzo=strIndirizzo + dtAsteEsperimenti.Rows[0]["Comuni_Comune"].ToString();
                      strIndirizzo=strIndirizzo + "," + dtAsteEsperimenti.Rows[0]["Province_Provincia"].ToString();
                      //Response.Write(strIndirizzo);
                    %>
                    <iframe
                      width="100%"
                      height="450"
                      style="border:0"
                      loading="lazy"
                      allowfullscreen
                      src="https://www.google.com/maps/embed/v1/place?key=AIzaSyAES_hH89T1by4uvK9_fJaAZ2aKvsDkJ2I&q=<%=strIndirizzo%>">
                    </iframe>                    
		            </div>
		        </div>
			      <% if (Convert.ToInt32(dtAsteEsperimenti.Rows[0]["Aste_CommissioniTipo"])==1){ %>
						<a name="commissioni"></a>
		        <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell">
		                <h2><b>COMMISSIONI</b> DELL'ASTA</h2>
		                <hr>
		            </div>
		        </div>
		        <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell">
   					        <!-- #include file ="/frontend/base/aste/inc-commissioni.inc" -->
										<br><br>
		            </div>
		        </div>
		        <% } %>
		        
    				<%if (dtAnnunci.Rows.Count>0){%>
   					  <!-- #include file ="/frontend/base/aste/inc-lotti-asta.inc" -->
            <% } %>
          </div>
          <div class="xlarge-4 medium-up-12 large-6 small-12 cell">
            	<div data-sticky-container>
                  <div class="callout primary sticky" data-sticky data-stick-to="top" data-top-anchor="topasta:bottom" data-btm-anchor="footer:top" data-margin-top="0">
                      <div class="grid-x grid-padding-x grid-padding-y">
                    		<div class="large-12 medium-12 small-12 cell text-center">
                          <i class="fa-duotone fa-timer fa-fw fa-2xl" style="--fa-secondary-color:#ff6c00;"></i>
                          <input type="hidden" id="datascadenzaasta-<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>" data-countdown="countdownasta-<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>" name="datascadenzaasta-<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>" value="<%=Convert.ToDateTime(dtAsteEsperimenti.Rows[0]["AsteEsperimenti_DataTermine"]).ToString("M/d/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":")%>" class="datascadenzaasta">
    			              	<span id="countdownasta-<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>" class="scadenza-scheda-asta text-left align-middle"></span>
                        </div>
                      </div>
                      <div class="grid-x grid-padding-x grid-padding-y">
                        <div class="large-12 medium-21 small-12 cell text-center">
    			              	<div class="align-middle">
                              <%if (dtAnnunci.Rows.Count>0){ %>
                          			<% if (dtAsteEsperimenti.Rows[0]["AsteNatura_Ky"].ToString()=="1"){ %>
																 <% if (boolCauzione==true){ %>
                                  <span class="scadenza-asta"><a class="button large radius warning expanded" href="#elenco-lotti">GUARDA I LOTTI<i class="fa-duotone fa-angle-right fa-fw fa-xl"></i></a></span>
                                 <% }else{ %>
                                  <span class="scadenza-asta"><a class="button large radius warning expanded" href="/partecipa-asta.aspx?Aste_Ky=<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>&AsteEsperimenti_Ky=<%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Ky"].ToString()%>">PARTECIPA ALL'ASTA<i class="fa-duotone fa-angle-right fa-fw fa-xl"></i></a></span>
                                 <% } %>
                                <% }else{ %>
                                  <span class="scadenza-asta"><a class="button large radius warning expanded" href="#elenco-lotti">PARTECIPA ALL'ASTA<i class="fa-duotone fa-angle-right fa-fw fa-xl"></i></a></span>
																<% } %>
                              <% }else{ %>
                                <label class="label alert">Lotti da pubblicare</label>
                              <% } %>
                          </div>
                      	</div>
                 		  </div> 

                          <div class="grid-x align-middle">
                              <div class="large-3 medium-3 small-6 cell">
                                  <span class="dettaglio-asta">Iniziata il:</span>
                              </div>
                              <div class="large-9 medium-9 small-6 cell text-right">
                                  <span class="dettaglio-asta"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=Convert.ToDateTime(dtAsteEsperimenti.Rows[0]["AsteEsperimenti_DataInizio"]).ToString("d/M/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture)%></span>
                              </div>
                          </div>
                          <div class="grid-x align-middle">
                              <div class="large-3 medium-3 small-6 cell">
                                  <span class="dettaglio-asta">Scadenza:</span>
                              </div>
                              <div class="large-9 medium-9 small-6 cell text-right">
                                  <span class="dettaglio-asta"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=Convert.ToDateTime(dtAsteEsperimenti.Rows[0]["AsteEsperimenti_DataTermine"]).ToString("d/M/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture)%></span>
                              </div>
                          </div>
                    			<% if (dtAsteEsperimenti.Rows[0]["AsteNatura_Ky"].ToString()=="1"){ %>
													<div class="grid-x align-middle">
                              <div class="large-3 medium-3 small-6 cell">
                                  <span class="dettaglio-asta">Cauzione:</span>
                              </div>
                              <div class="large-9 medium-9 small-6 cell text-right">
                      			      <% if (boolCauzione==true){ %>
                                    <span class="dettaglio-asta" style="color:green"><i class="fa-duotone fa-check-square fa-fw"></i>PAGATA</span>
                                  <% }else{ %>
                                    <span class="dettaglio-asta" style="color:red"><i class="fa-duotone fa-exclamation-triangle fa-fw" data-tooltip aria-haspopup="true" class="has-tip" data-disable-hover="false" tabindex="1" title="La cauzione necessaria per essere abilitati a fare offerte non &egrave; ancora stata versata"></i>NON PAGATA</span>
                                  <% } %>
                              </div>
                          </div>
                          <% } %>
	                        <div class="grid-x align-middle">
                              <div class="large-3 medium-3 small-6 cell">
                                  <span class="dettaglio-asta">Esperimento:</span>
                              </div>
                              <div class="large-9 medium-9 small-6 cell text-right">
	                            	<span class="esperimento-asta"><%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Numero"].ToString()%>&deg;</span>
	                            </div>
	                        </div>
                          <div class="grid-x align-middle">
                              <div class="large-5 medium-5 small-6 cell">
                                  <span class="dettaglio-asta">Commissioni <small class="hide-for-small-only">(oltre IVA)</small>:</span>
                              </div>
                              <div class="large-7 medium-7 small-6 cell text-right">
                      			      <% 
																	if (Convert.ToInt32(dtAsteEsperimenti.Rows[0]["Aste_CommissioniTipo"])==1){
																		//a scaglioni
                                    Response.Write("<span class=\"dettaglio-asta\"><a href=\"#commissioni\">vedi dettagli <i class=\"fa-duotone fa-angle-right fa-fw\"></i></a></span>");
																	}else{
																		//fissa
																		if ((decimal)dtAsteEsperimenti.Rows[0]["Aste_Commissione"]==0){
	                                    Response.Write("<span style=\"color:green\"><i class=\"fa-duotone fa-check-square fa-fw\"></i>NESSUNA COMMISSIONE</span>");
	                                  }else{
	                                    Response.Write("<span class=\"dettaglio-asta\"><a href=\"#commissioni\">vedi dettagli <i class=\"fa-duotone fa-angle-right fa-fw\"></i></a></span>");
	                                  }
																	}
																	%>
	                              </div>
                          </div>
                          <div class="grid-x align-middle">
                              <div class="large-4 medium-4 small-6 cell">
                                  <span class="dettaglio-asta">Termine pagamento:</span>
                              </div>
                              <div class="large-8 medium-8 small-6 cell text-right">
                                  <span class="dettaglio-asta">Entro il <%=dtAsteEsperimenti.Rows[0]["Aste_DataPagamento"].ToString()%></span>
                              </div>
                          </div>
                          <div class="grid-x align-middle">
                              <div class="large-4 medium-4 small-6 cell">
                                  <span class="dettaglio-asta">Metodo pagamento:</span>
                              </div>
                              <div class="large-8 medium-8 small-6 cell text-right">
                                  <span class="dettaglio-asta"><%=dtAsteEsperimenti.Rows[0]["PagamentiMetodo_Descrizione"].ToString()%></span>
                              </div>
                          </div>
                          <div class="grid-x align-middle">
                              <div class="large-2 medium-2 small-6 cell">
                                  <span class="dettaglio-asta">Ritiro:</span>
                              </div>
                              <div class="large-10 medium-10 small-6 cell text-right">
                                  <span class="dettaglio-asta"><%=dtAsteEsperimenti.Rows[0]["AsteRitiri_Titolo"].ToString()%></span>
                              </div>
                          </div>
                          <div class="grid-x align-middle">
                              <div class="large-3 medium-3 small-6 cell">
                                  <span class="dettaglio-asta">Localizzazione:</span>
                              </div>
                              <div class="large-9 medium-9 small-6 cell text-right">
                                  <span class="dettaglio-asta"><img src="/frontend/base/img/icona-ita.png"><%=dtAsteEsperimenti.Rows[0]["Nazioni_Codice"].ToString()%> / <%=dtAsteEsperimenti.Rows[0]["Regioni_Regione"].ToString()%> / <%=dtAsteEsperimenti.Rows[0]["Comuni_Comune"].ToString()%></span>
                              </div>
                          </div>
                  </div>
                </div>
            </div>
        </div>
      </div>
		<!-- #include file ="/frontend/base/inc-footer.aspx" -->
		<!-- #include file ="/frontend/base/inc-foot.aspx" -->
  </body>
</html>
