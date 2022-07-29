<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="scheda-lotto.aspx.cs" Inherits="_Default" Debug="true"%>
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
		<div class="grid-container scheda-lotto">				
      <div class="grid-x grid-padding-x">
        <div class="large-6 medium-6 small-12 cell topasta large-text-left" id="topastatitolo">
        	<h1><%=dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString()%></h1>
        </div>
        <div class="large-6 medium-6 small-12 cell topasta large-text-right" id="topastavalori">
            <div class="label secondary"><a href="/frontend/base/aste/scheda-asta.aspx?Aste_Ky=<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>&AsteEsperimenti_Ky=<%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Ky"].ToString()%>"><span style="color: #ff6c00">ID ASTA:</span> <strong><%=dtAsteEsperimenti.Rows[0]["Aste_Numero"].ToString()%></strong></a></div>
            <div class="label secondary"><span style="color: #ff6c00">ESP.:</span> <strong><%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Numero"].ToString()%></strong></div>
            <div class="label secondary"><span style="color: #ff6c00">LOTTO:</span> <strong><%=dtAnnuncio.Rows[0]["Annunci_Numero"].ToString()%></strong></div>
            <div class="label secondary"><span style="color: #ff6c00">CATEGORIA:</span> <strong><%=dtAnnuncio.Rows[0]["AnnunciCategorie_Titolo"].ToString()%></strong></div>
            <div class="label secondary"><span style="color: #ff6c00">RIBASSO:</span> <strong>-<span data-tooltip aria-haspopup="true" class="has-tip" data-disable-hover="false" tabindex="1" title="I prezzi attuali dei vari lotti sono stati ribassati della % indicata rispetto all'esperimento precedente"><%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_PercentualeRibasso"].ToString()%>%</span></strong></div>
            <div class="label secondary"><span style="color: #ff6c00">VISITE:</span> <strong><%=dtAnnuncio.Rows[0]["Annunci_Visite"].ToString()%></strong></div>
          	<div class="label secondary"><span style="color: #ff6c00" title="Segui lotto"><a href="/frontend/base/wishlist/aggiungi-wishlist.aspx?Annunci_Ky=<%=dtAnnuncio.Rows[0]["Annunci_Ky"].ToString()%>&azione=new&cosa=annunci"><i class="fa-duotone fa-heart fa-lg fa-fw" style="color:#48c6f4"></i>segui</a></span></div>
        </div>
  		</div>
      <hr>
			<div class="grid-x grid-padding-x">
  			<div class="large-8 medium-up-12 small-12 cell">
          	<a href="<%=dtAnnuncio.Rows[0]["Annunci_Foto1"].ToString()%>" data-fancybox="galleriaannuncio" data-type="image" data-caption="<%=dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString()%>">
              <img src="<%=dtAnnuncio.Rows[0]["Annunci_Foto1"].ToString()%>" class="lazyload" loading="lazy">
            </a>
            <div class="grid-x grid-margin-x grid-padding-y small-up-2 medium-up-4 large-up-5 slider-nav">
              <% 
              string strTemp="";
              string strClass="";
              int intNumeroFoto=Convert.ToInt32(dtAnnuncio.Rows[0]["Annunci_NumeroFoto"].ToString());
              for (int i = 2; i < 21; i++){
                strTemp="Annunci_Foto" + i;
                strClass="";
                if (i>2){
                  strClass=" hide-for-small-only";
                }
			          if (boolLogin==false){
                  if (i>5){
                    strClass+=" hide-for-large";
                  }
                }else{
                  if (i>10){
                    strClass+=" hide-for-large";
                  }
                }
                if (i<intNumeroFoto-1){
                    if (dtAnnuncio.Rows[0][strTemp].ToString().Length>0){
                      Response.Write("<div class=\"cell" + strClass + "\"><a href=\"" + dtAnnuncio.Rows[0][strTemp].ToString()  + "\" data-fancybox=\"galleriaannuncio\" data-type=\"image\" data-caption=\"" + dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString() + "\"><img src=\"" + dtAnnuncio.Rows[0][strTemp].ToString()  + "\" height=\"150\" width=\"100\" style=\"width:150px;height:100px;\" alt=\"" + dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString() + "\"></a></div>");
                    }
                }else{
                    if (i==intNumeroFoto){
                      if (dtAnnuncio.Rows[0][strTemp].ToString().Length>0){
                        Response.Write("<div class=\"column column-block\"><a href=\"" + dtAnnuncio.Rows[0][strTemp].ToString() + "\" style=\"position:relative\" data-fancybox=\"galleriaannuncio\" data-type=\"image\" data-caption=\"" + dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString() + "\" id=\"" + strTemp  + "\"><img src=\"" + dtAnnuncio.Rows[0][strTemp].ToString()  + "\" height=\"150\" width=\"100\" style=\"width:150px;height:100px;filter: brightness(40%);\" alt=\"" + dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString() + "\"><div style=\"position:absolute;left:30%;top:0;color:#ffffff;padding:0.25rem;\"><i class=\"fa-duotone fa-camera fa-fw fa-lg\" style=\"color:#ffffff;\"></i>" + dtAnnuncio.Rows[0]["Annunci_NumeroFoto"].ToString() + "</div></a></div>");
                      }
                    }else{
                      if (dtAnnuncio.Rows[0][strTemp].ToString().Length>0){
                        Response.Write("<div class=\"cell" + strClass + "\"><a href=\"" + dtAnnuncio.Rows[0][strTemp].ToString() + "\" data-fancybox=\"galleriaannuncio\" data-type=\"image\" data-caption=\"" + dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString() + "\"><img src=\"" + dtAnnuncio.Rows[0][strTemp].ToString()  + "\" height=\"150\" width=\"100\" style=\"width:150px;height:100px;\" alt=\"" + dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString() + "\"></a></div>");
                      }
                    }
                }
              }
              %>
            </div>
            <h2><b>DESCRIZIONE</b> DEL LOTTO</h2>
            <hr>
            <div class="grid-x grid-padding-x">
              <div class="large-12 medium-12 small-12 cell descrizione-asta">
                <fieldset class="fieldset">
                  <legend class="text-left">Informazioni principali</legend>
                  <table class="hover" style="border:1px solid #ededed;">
                    <tr>
                      <th width="180" class="text-right">Marca:</th>
                      <td><strong><%=dtAnnuncio.Rows[0]["AnnunciMarca_Titolo"].ToString()%></strong></td>
                    </tr>
                    <tr>
                      <th class="text-right">Modello:</th>
                      <td><strong>
                      <% 
                      if (dtAnnuncio.Rows[0]["Annunci_Modello"].ToString().Length>0){
                        Response.Write(dtAnnuncio.Rows[0]["Annunci_Modello"].ToString());
                      }else{
                        Response.Write(dtAnnuncio.Rows[0]["AnnunciModello_Titolo"].ToString());
                      }
                      
                      %>
                      </strong></td>
                    </tr>
                  </table>
                  <% Response.Write(getAttributiTable()); %>
                </fieldset>
              </div>
            </div>
            
            <div class="grid-x grid-padding-x">
              <div class="large-12 medium-12 small-12 cell descrizione-asta">
                <fieldset class="fieldset note">
                  <legend class="text-left">Note</legend>
                  <%=dtAnnuncio.Rows[0]["Annunci_Descrizione"].ToString()%>
                  <%
									if (dtAnnuncio.Rows[0]["Annunci_Video"].ToString().Length>0){
										Response.Write("<iframe width=\"100%\" height=\"315\" src=\"https://www.youtube.com/embed/" + dtAnnuncio.Rows[0]["Annunci_Video"].ToString() + "\" frameborder=\"0\" gesture=\"media\" allow=\"encrypted-media\" allowfullscreen></iframe>");
									}
									%>
                </fieldset>
              </div>
            </div>
            <%if (dtFilesAsta.Rows.Count>0 || dtFilesLotto.Rows.Count>0){%>
						<a name="documentidivendita"></a>
		        <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell">
		                <h2><b>DOCUMENTI DI VENDITA</b></h2>
		                <hr class="linea-arancio"/>
		            </div>
		        </div>
		        <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell descrizione-asta">
          					<% 
                      Response.Write("<ul class=\"menu vertical\">");
                      for (int i = 0; i < dtFilesAsta.Rows.Count; i++){
                        Response.Write("<li><a href=\"" + dtFilesAsta.Rows[i]["Files_Path"].ToString().Replace(" ","/") + "\" target=\"_blank\"><i class=\"fa-duotone fa-external-link fa-fw\"></i>" + dtFilesAsta.Rows[i]["Files_Titolo"].ToString() + "</a></li>");
          					  }
                      for (int i = 0; i < dtFilesLotto.Rows.Count; i++){
                        Response.Write("<li><a href=\"" + dtFilesLotto.Rows[i]["Files_Path"].ToString().Replace(" ","/") + "\" target=\"_blank\"><i class=\"fa-duotone fa-external-link fa-fw\"></i>" + dtFilesLotto.Rows[i]["Files_Titolo"].ToString() + "</a></li>");
          					  }
                      Response.Write("</ul>");
                    %>
										<br><br>
		            </div>
		        </div>
            <% } %>
            
						<a name="referenteasta"></a>
		        <section id="referenteasta">
            <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell">
		                <h2><b>DETTAGLI DEL REFERENTE</b> DEL LOTTO</h2>
		                <hr class="linea-arancio"/>
		            </div>
		        </div>
		        <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell descrizione-asta">
										<i class="fa-duotone fa-user fa-fw"></i><%=dtAsteEsperimenti.Rows[0]["Aste_Referente"].ToString()%><br>
										<i class="fa-duotone fa-mobile-phone fa-fw"></i><a href="tel:<%=dtAsteEsperimenti.Rows[0]["Aste_CellulareReferente"].ToString()%>"><%=dtAsteEsperimenti.Rows[0]["Aste_CellulareReferente"].ToString()%></a><br>
										<i class="fa-duotone fa-envelope fa-fw"></i><a href="mailto:<%=dtAsteEsperimenti.Rows[0]["Aste_EmailReferente"].ToString()%>"><%=dtAsteEsperimenti.Rows[0]["Aste_EmailReferente"].ToString()%></a><br>
                    <br><br>
		            </div>
		        </div>
            </section>
						<a name="localizzazionelotto"></a>
		        <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell">
		                <h2><b>LOCALIZZAZIONE</b> DEL LOTTO</h2>
		                <hr class="linea-arancio"/>
		            </div>
		        </div>
		        <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell descrizione-asta">
										<%
                      strIndirizzo=dtAnnuncio.Rows[0]["Annunci_Indirizzo"].ToString();
                      if (strIndirizzo.Length>0){
                        strIndirizzo=strIndirizzo.Replace(" ","+");
                        strIndirizzo=strIndirizzo + ",";
                      }
                      strIndirizzo=strIndirizzo + dtAnnuncio.Rows[0]["Comuni_Comune"].ToString();
                      strIndirizzo=strIndirizzo + "," + dtAnnuncio.Rows[0]["Province_Provincia"].ToString();
                      //Response.Write(strIndirizzo);
                    %>
                    <iframe
                      width="100%"
                      height="450"
                      frameborder="0" style="border:0"
                      src="https://www.google.com/maps/embed/v1/place?key=AIzaSyAES_hH89T1by4uvK9_fJaAZ2aKvsDkJ2I&q=<%=strIndirizzo%>&zoom=8" allowfullscreen>
                    </iframe>
                    <br><br>
		            </div>
		        </div>

			      <% if (Convert.ToInt32(dtAsteEsperimenti.Rows[0]["Aste_CommissioniTipo"])==1){ %>
						<a name="commissioni"></a>
		        <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell">
		                <h2><b>COMMISSIONI</b> DI ACQUISTO DEL LOTTO</h2>
		                <hr class="linea-arancio"/>
		            </div>
		        </div>
		        <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell descrizione-asta">
   					        <!-- #include file ="/frontend/base/aste/inc-commissioni.inc" -->
										<br><br>
		            </div>
		        </div>
		        <% } %>
    		 <%if (dtAnnunci.Rows.Count>0){%>
         <div class="grid-x grid-padding-x">
         	<div class="large-12 medium-12 small-12 cell">
              <!-- #include file ="/frontend/base/aste/inc-lotti-asta.inc" -->
       		</div>
         </div>
         <% } %>
            
        </div>
        <div class="large-4 medium-up-12 small-12 cell">
            	<div data-sticky-container>
                  <div class="callout primary sticky" data-sticky data-stick-to="top" data-top-anchor="topasta:bottom" data-btm-anchor="footer:top" data-margin-top="0">
                    <div class="grid-x grid-padding-x">
                    		<div class="large-12 medium-6 small-12 cell">
    			              	  <div class="align-middle text-center">
                              <i class="fa-duotone fa-timer fa-fw fa-2xl" style="--fa-secondary-color:#ff6c00;"></i>
        			              	<input type="hidden" id="datascadenzaasta-<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>" data-countdown="countdownasta-<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>" name="datascadenzaasta-<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>" value="<%=Convert.ToDateTime(dtAsteEsperimenti.Rows[0]["AsteEsperimenti_DataTermine"]).ToString("M/d/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":")%>" class="datascadenzaasta">
        			              	<span id="countdownasta-<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>" class="scadenza-scheda-asta"></span>
                            </div>
                    		</div>
                    </div>
                    <hr>
                    <div class="grid-x grid-padding-x">
                          <div class="large-12 medium-12 small-12 cell text-center">
    			              	  <div class="align-middle">
                             
                            <% 
                            switch (dtAnnuncio.Rows[0]["AnnunciTipo_Ky"].ToString()){
                              case "1":
                              	Response.Write("<a class=\"button large expanded warning radius\" href=\"#documentidivendita\">Partecipa<br><small>scarica il bando</small></a>");
                                break;
                              case "2":
  														  if (boolCauzione==false && boolAstaScaduta==false){
                                  Response.Write("<a class=\"button large expanded warning radius\" href=\"/frontend/base/aste/partecipa-asta.aspx?Annunci_Ky=" + dtAnnuncio.Rows[0]["Annunci_Ky"].ToString() + "&Aste_Ky=" + dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString() + "&AsteEsperimenti_Ky=" + dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Ky"].ToString() + "\">FAI OFFERTA</a>");
                                }
                                break;
                              case "3":
                              	Response.Write("<a class=\"button large expanded warning radius\" href=\"#documentidivendita\">Partecipa<br><small>scarica il bando</small></a>");
                                break;
                            }%>                             
                             
                            </div>
                      		</div>                                                                                                                                                           
               		      </div> 
            	            <% 
													if (boolCauzione==true && Convert.ToDateTime(dtAsteEsperimenti.Rows[0]["AsteEsperimenti_DataTermine"])>DateTime.Now){ %>
                            <h2>Fai la tua offerta per il lotto</h2>
                            <% if (dtAnnunciOfferte.Rows.Count>0){
                                 if (dtAnnunciOfferte.Rows[0]["Anagrafiche_Ky"].ToString()==strUtentiLogin){%>
                                  <div id="statoasta" class="callout success statoasta wow slideInRight"><i class="fa-duotone fa-info-circle fa-fw fa-lg"></i>Stai vincendo l'asta</div>
                                  <% }else{ %>
                                  <div id="statoasta" class="callout alert statoasta wow slideInRight"><i class="fa-duotone fa-info-circle fa-fw fa-lg"></i>Non stai vincendo l'asta. La tua offerta &egrave; stata superata.</div>
                                 <% }
                               }else{%>
                                  <div id="statoasta" class="callout alert statoasta wow slideInRight"><i class="fa-duotone fa-info-circle fa-fw fa-lg"></i>Non stai vincendo l'asta. La tua offerta &egrave; stata superata.</div>
                               <% } %>
														<div class="grid-x grid-padding-x">
                                <div class="large-4 medium-4 small-6 cell">
                                    Prezzo attuale:
                                </div>
                                <div class="large-8 medium-8 small-6 cell text-right">
                                    <div class="text-right" style="font-size:1.5rem" >
                                    <% if (dtAnnunciOfferte.Rows.Count>0){ %>
                                      <strong id="valoreattuale">&euro; <%=((decimal)dtAnnunciOfferte.Rows[0]["AnnunciOfferte_Valore"]).ToString("N0", ci)%></strong>
                                    <% }else{ %>
                                      <strong id="valoreattuale">&euro; <%=((decimal)dtAnnuncio.Rows[0]["Annunci_Valore"]).ToString("N0", ci)%></strong>
                                    <% } %>
                                    </div>
                                </div>
                            </div>
														<div class="grid-x grid-padding-x">
                                <div class="large-4 medium-4 small-6 cell">
                                    Commissione:
                                </div>
                                <div class="large-8 medium-8 small-6 cell text-right">
                        			      <strong id="valorecommissione">+<%=getCommissione()%>%</strong>
                                </div>
                            </div>
														<div class="grid-x grid-padding-x">
                                <div class="large-4 medium-4 small-6 cell">
                                    Rilancio minimo:
                                </div>
                                <div class="large-8 medium-8 small-6 cell text-right">
                        			      <strong id="rilancio" data-value="<%=((decimal)dtAnnuncio.Rows[0]["Annunci_Rilancio"]).ToString("N0", ci)%>">&euro; <%=((decimal)dtAnnuncio.Rows[0]["Annunci_Rilancio"]).ToString("N0", ci)%></strong>
                                </div>
                            </div>
														<div class="grid-x grid-padding-x">
                                <div class="large-4 medium-4 small-6 cell">
                                   Offerte ricevute:
                                </div>
                                <div class="large-8 medium-8 small-6 cell text-right">
                        			      <strong id="offertericevute"><%=dtAnnunciOfferte.Rows.Count%></strong>
                                </div>
                            </div>
                            <%
                            if (strErrore!=null && strErrore.Length>0){
                            %>
                            <div class="callout alert"><%=strErrore%></div>
                            <%
                            }
                            %>
														<ul class="tabs" data-tabs id="tabsofferta" style="margin-top:0.75rem;">
														  <li class="tabs-title is-active"><a href="#panel1" aria-selected="true"><i class="fa-duotone fa-hand-paper-o fa-fw"></i>Offerta manuale</a></li>
														  <li class="tabs-title"><a data-tabs-target="panel2" href="#panel2"  data-tooltip aria-haspopup="true" class="has-tip" data-disable-hover="false" tabindex="1" title="Con questa funzione puoi impostare il prezzo massimo che sei disposto a pagare. Ogni volta che qualcuno supera la tua offerta, il sistema rilancer&agrave; automaticamente per te col valore minimo fino al raggiungimento del prezzo massimo che hai impostato."><i class="fa-duotone fa-calculator fa-fw"></i>Offerta automatica (proxy bid)</a></li>
														</ul>
														<div class="tabs-content" data-tabs-content="tabsofferta">
														  <div class="tabs-panel is-active" id="panel1">
			                            <form name="formOffertaLotto" class="formOffertaLotto" method="post" action="/frontend/base/aste/form/form-offerta-lotto.aspx" data-abide novalidate>
																		<input type="hidden" name="azione" value="new">
			                              <input type="hidden" name="Aste_Ky" value="<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>">
			                              <input type="hidden" name="AsteEsperimenti_Ky" value="<%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Ky"].ToString()%>">
			                              <input type="hidden" name="Annunci_Ky" value="<%=dtAnnuncio.Rows[0]["Annunci_Ky"].ToString()%>">
		                              	<input type="hidden" name="Anagrafiche_Ky" value="<%=strUtentiLogin%>">
			                              <div class="input-group radius">
			                                <%
			                                  if (dtAnnunciOfferte.Rows.Count>0){
			                                    decValoreOffertaMinima=((decimal)dtAnnunciOfferte.Rows[0]["AnnunciOfferte_Valore"])+((decimal)dtAnnuncio.Rows[0]["Annunci_Rilancio"]);
			                                  }else{
			                                    decValoreOffertaMinima=((decimal)dtAnnuncio.Rows[0]["Annunci_Valore"]);
			                                  }
			                                %>
			                                <input id="offertalotto" name="offertalotto" class="input-group-field input-big" type="text" min="<%=decValoreOffertaMinima.ToString().Replace(",0000","")%>" value="<%=decValoreOffertaMinima.ToString().Replace(",0000","")%>" step="1" required="required" onchange="controllaofferta()">
			                                <div class="input-group-button">
			                                  <button class="button warning wow pulse animated" data-wow-iteration="100">Offri ora</button>
			                                </div>
			                              </div>
			                              <div id="messaggioofferta"></div>
			                            </form>
														  </div>
														  <div class="tabs-panel" id="panel2">
			                            <form name="formOffertaLottoProxybid" class="formOffertaLottoProxybid" method="post" action="/frontend/base/aste/form/form-offerta-lotto-proxybid.aspx" data-abide novalidate>
																		<input type="hidden" name="azione" value="new">
																		<input type="hidden" name="AsteProxyBid_Ky" value="">
																		<input type="hidden" name="Aste_Ky" value="<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>">
			                              <input type="hidden" name="AsteEsperimenti_Ky" value="<%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Ky"].ToString()%>">
			                              <input type="hidden" name="Annunci_Ky" value="<%=dtAnnuncio.Rows[0]["Annunci_Ky"].ToString()%>">
			                              <input type="hidden" name="Anagrafiche_Ky" value="<%=strUtentiLogin%>">
			                              <div class="input-group radius">
			                                <%
			                                  if (dtAnnunciOfferte.Rows.Count>0){
			                                    decValoreOffertaMinima=((decimal)dtAnnunciOfferte.Rows[0]["AnnunciOfferte_Valore"])+((decimal)dtAnnuncio.Rows[0]["Annunci_Rilancio"]);
			                                  }else{
			                                    decValoreOffertaMinima=((decimal)dtAnnuncio.Rows[0]["Annunci_Valore"]);
			                                  }
			                                %>
			                                <input id="AsteProxyBid_ValoreMax" name="AsteProxyBid_ValoreMax" class="input-group-field input-big" type="text" min="<%=decValoreOffertaMinima.ToString().Replace(",0000","")%>" value="<%=decValoreOffertaMinima.ToString().Replace(",0000","")%>" step="1" required="required" onchange="controllaoffertaproxybid()">
			                                <div class="input-group-button">
			                                  <button class="button warning">Imposta prezzo Max ora</button>
			                                </div>
			                              </div>
			                              <div id="messaggiooffertaproxybid"></div>
			                            </form>
														  </div>
														</div>
                            <small>Con l'effettuazione dell'offerta affermo di accettare le condizioni di vendita</small>
                    </div>
                    <div class="dettagli-scheda-asta-container">
                        <div class="dettagli-asta">
                          <h2>Dettagli del lotto</h2>
                        <% }else{ %>
														<div class="grid-x grid-padding-x">
                                <div class="large-3 medium-3 small-6 cell">
                                    <span class="dettaglio-asta" style="font-size:1.25rem">Prezzo attuale:</span>
                                </div>
                                <div class="large-9 medium-9 small-6 cell text-right">
                                    <div class="text-right" style="font-size:1.5rem" >
                                    <% if (dtAnnunciOfferte.Rows.Count>0){ %>
                                      <strong id="valoreattuale">&euro; <%=((decimal)dtAnnunciOfferte.Rows[0]["AnnunciOfferte_Valore"]).ToString("N0", ci)%></strong>
                                    <% }else{ %>
                                      <strong id="valoreattuale">&euro; <%=((decimal)dtAnnuncio.Rows[0]["Annunci_Valore"]).ToString("N0", ci)%></strong>
                                    <% } %>
                                    </div>
                                </div>
                            </div>
														<div class="grid-x grid-padding-x">
                                <div class="large-3 medium-3 small-6 cell">
                                    <span class="dettaglio-asta">Offerte ricevute:</span>
                                </div>
                                <div class="large-9 medium-9 small-6 cell text-right">
                        			      <strong id="offertericevute"><%=dtAnnunciOfferte.Rows.Count%></strong>
                                </div>
                            </div>
                        <% } %>

														<div class="grid-x grid-padding-x">
                                <div class="large-4 medium-4 small-6 cell">
                                   Cauzione:
                                </div>
                                <div class="large-8 medium-8 small-6 cell text-right">
                        			      <% if (boolCauzione==true){ %>
                                      <span style="color:green"><i class="fa-duotone fa-check-square fa-fw"></i>PAGATA</span>
                                    <% }else{ %>
                                      <span style="color:red"><i class="fa-duotone fa-exclamation-triangle fa-fw" data-tooltip aria-haspopup="true" class="has-tip" data-disable-hover="false" tabindex="1" title="La cauzione necessaria per essere abilitati a fare offerte non &egrave; ancora stata versata"></i>NON PAGATA</span>
                                    <% } %>
                                </div>
                            </div>

														<div class="grid-x grid-padding-x">
                                <div class="large-4 medium-4 small-6 cell">
                                    Prezzo di riserva:
                                </div>
                                <div class="large-8 medium-8 small-6 cell text-right">
                                    <div id="riserva"><%=getRiserva()%></div>
                                </div>
                            </div>
                            <div class="grid-x grid-padding-x">
                                <div class="large-4 medium-4 small-6 cell">
                                    Iniziata il:
                                </div>
                                <div class="large-8 medium-8 small-6 cell text-right">
                                    <i class="fa-duotone fa-calendar-days fa-fw"></i><%=Convert.ToDateTime(dtAsteEsperimenti.Rows[0]["AsteEsperimenti_DataInizio"]).ToString("d/M/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture)%>
                                </div>
                            </div>
                            <div class="grid-x grid-padding-x">
                                <div class="large-4 medium-4 small-6 cell">
                                    Scadenza:
                                </div>
                                <div class="large-8 medium-8 small-6 cell text-right">
                                    <i class="fa-duotone fa-calendar-days fa-fw"></i><%=Convert.ToDateTime(dtAsteEsperimenti.Rows[0]["AsteEsperimenti_DataTermine"]).ToString("d/M/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture)%>
                                </div>
                            </div>

                            <div class="grid-x grid-padding-x">
                                <div class="large-4 medium-4 small-6 cell">
                                    Esperimento:
                                </div>
                                <div class="large-8 medium-8 small-6 cell text-right">
                                    <%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Numero"].ToString()%>&deg;
                                </div>
                            </div>
                            <div class="grid-x grid-padding-x">
                                <div class="large-5 medium-5 small-6 cell">
                                    <span class="dettaglio-asta">Commissioni <small>(oltre IVA)</small>:</span>
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
                            <div class="grid-x grid-padding-x">
                                <div class="large-4 medium-4 small-6 cell">
                                    <span class="dettaglio-asta">Termine pagamento:</span>
                                </div>
                                <div class="large-8 medium-8 small-6 cell text-right">
                                    <span class="dettaglio-asta">Entro il <%=dtAsteEsperimenti.Rows[0]["Aste_DataPagamento"].ToString()%></span>
                                </div>
                            </div>
                            <div class="grid-x grid-padding-x">
                                <div class="large-4 medium-4 small-6 cell">
                                    <span class="dettaglio-asta">Metodo pagamento:</span>
                                </div>
                                <div class="large-8 medium-8 small-6 cell text-right">
                                    <span class="dettaglio-asta"><%=dtAsteEsperimenti.Rows[0]["PagamentiMetodo_Descrizione"].ToString()%></span>
                                </div>
                            </div>
                            <div class="grid-x grid-padding-x">
                                <div class="large-2 medium-2 small-6 cell">
                                    <span class="dettaglio-asta">Ritiro:</span>
                                </div>
                                <div class="large-10 medium-10 small-6 cell text-right">
                                    <span class="dettaglio-asta"><%=dtAsteEsperimenti.Rows[0]["AsteRitiri_Titolo"].ToString()%></span>
                                </div>
                            </div>
                            <div class="grid-x grid-padding-x">
                                <div class="large-3 medium-3 small-6 cell">
                                    <span class="dettaglio-asta">Visione:</span>
                                </div>
                                <div class="large-9 medium-9 small-6 cell text-right">
                                    <span class="dettaglio-asta"><%=dtAnnuncio.Rows[0]["Annunci_Visione"].ToString()%></span>
                                </div>
                            </div>
                            <div class="grid-x grid-padding-x">
                                <div class="large-3 medium-3 small-6 cell">
                                    <span class="dettaglio-asta">Localizzazione:</span>
                                </div>
                                <div class="large-9 medium-9 small-6 cell text-right">
                                    <span class="dettaglio-asta"><img src="https://cdn.smartdesk.cloud/img/flags/it.png" style="margin-right:5px"><%=dtAnnuncio.Rows[0]["Nazioni_Codice"].ToString()%> / <%=dtAnnuncio.Rows[0]["Regioni_Regione"].ToString()%> / <%=dtAnnuncio.Rows[0]["Comuni_Comune"].ToString()%></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="large-text-right small-text-left">
								* i prezzi indicati sono IVA esclusa
								</div>
            </div>
            </div>


           
        </div>       
         
         
        
			</div>
		<!-- #include file ="/frontend/base/inc-footer.aspx" -->
		<!-- #include file ="/frontend/base/inc-foot.aspx" -->
    <script type="text/javascript">
      var strPathJson;
      var strValore;
      var intValore;
      var intCommissione;
      var intOffertaLotto;
      var intRilancio; 
      var arrayCommissioni;
    	
			<% 
			if (Convert.ToInt32(dtAsteEsperimenti.Rows[0]["Aste_CommissioniTipo"])==1){%>
	    	arrayCommissioni= new Array(<%=dtAsteCommissioni.Rows.Count%>);
				<% for (int i = 0; i < dtAsteCommissioni.Rows.Count; i++){ %>
				  arrayCommissioni[<%=i%>] = new Array(<%=Convert.ToDecimal(dtAsteCommissioni.Rows[i]["AsteCommissioni_Da"]).ToString().Replace(",",".")%>,<%=Convert.ToDecimal(dtAsteCommissioni.Rows[i]["AsteCommissioni_A"]).ToString().Replace(",",".")%>,<%=Convert.ToDecimal(dtAsteCommissioni.Rows[i]["AsteCommissioni_Commissione"]).ToString().Replace(",",".")%>);
				<% 
				}
			}else{ %>
	      arrayCommissioni= new Array(1);
				arrayCommissioni[0]=new Array(0,9999999999999,<%=dtAsteEsperimenti.Rows[0]["Aste_Commissione"].ToString()%>);
			<% } %>

			
			function controllaofferta(){
        var intValoreAttuale=jQuery("#valoreattuale").text().replace("+","").replace(".","");
        if (jQuery("#offertalotto").val()>(intValoreAttuale*2)){
          jQuery("#messaggioofferta").html("<div class=\"label alert\"><i class=\"fa-duotone fa-exclamation-triangle fa-fw\"></i>ATTENZIONE: Offerta pi+ del doppio del valore attuale</label>");
        }else{
          jQuery("#messaggioofferta").html("");
        } 
        return true;
      }

      function controllaoffertaproxybid(){
        var intValoreAttuale=jQuery("#valoreattuale").text().replace("+","").replace(".","");
        if (jQuery("#offertalottoproxybid").val()>(intValoreAttuale*2)){
          jQuery("#messaggioofferta").html("<div class=\"label alert\"><i class=\"fa-duotone fa-exclamation-triangle fa-fw\"></i>ATTENZIONE: Offerta piu' del doppio del valore attuale</label>");
        }else{
          jQuery("#messaggioofferta").html("");
        } 
        return true;
      }
      
      jQuery('#offertalotto').number( true, 0, ",","." );
      //jQuery('#AsteProxyBid_ValoreMax').number( true, 0, ",","." );
     
      //console.log("1");
      jQuery("[data-fancybox]").fancybox({
      	thumbs : {
      		autoStart : false,
          buttons : [
            'slideShow',
            'fullScreen',
            'thumbs',
            'close'
          ],          
          infobar : true,
          lang : 'it',
          loop : true
      	}
      });
      
      window.setInterval(function(){
        strPathJson="/frontend/base/annunci/getAnnunci-ValoreAttuale-json.aspx?Annunci_Ky=<%=dtAnnuncio.Rows[0]["Annunci_Ky"].ToString()%>&AsteEsperimenti_Ky=<%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Ky"].ToString()%>";
        jQuery.getJSON(strPathJson, null, function(data) {
            jQuery.each(data.valoreattuale, function(index, item) {
                //console.log(item.valoreoffertaminima);
                //console.log(item.valoreattuale);
						    strIdDataScadenza="#datascadenzaasta-<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>";
						    strIdCountdown="countdownasta-<%=dtAsteEsperimenti.Rows[0]["Aste_Ky"].ToString()%>";
						    strValue=jQuery(strIdDataScadenza).val();
                jQuery("#valoreattuale").html("&euro; " + item.valoreattuale);
                jQuery("#offertericevute").text(item.numeroofferte);
                if (strValue!=item.datascadenzaasta){
									jQuery(strIdDataScadenza).val(item.datascadenzaasta);
									clearInterval(jQuery("#" + strIdCountdown).attr("data-timer"));
									CountDownTimer(item.datascadenzaasta, strIdCountdown);
								}
                intOffertaLotto=parseInt(item.valoreattuale.replace(".",""));
                intRilancio=parseInt(jQuery("#rilancio").data("value"));
                if (parseInt(item.numeroofferte)>0){
                  if (jQuery("#offertalotto").val()<(intOffertaLotto+intRilancio)){
                    if (jQuery("#offertalotto").is(":focus")) {
                      jQuery("#messaggioofferta").html("<div class=\"label success\"><i class=\"fa-duotone fa-info-circle fa-fw\"></i>ATTENZIONE: Valore minimo: " + parseInt(intOffertaLotto+intRilancio) + "</label>");
                      jQuery("#messaggiooffertaproxybid").html("<div class=\"label success\"><i class=\"fa-duotone fa-info-circle fa-fw\"></i>ATTENZIONE: Valore minimo: " + parseInt(intOffertaLotto+intRilancio) + "</label>");
                    }else{
                      jQuery("#offertalotto").val(intOffertaLotto+intRilancio);
                      jQuery("#AsteProxyBid_ValoreMax").val(intOffertaLotto+intRilancio);
                      jQuery("#messaggioofferta").html("<div class=\"label success\"><i class=\"fa-duotone fa-info-circle fa-fw\"></i>ATTENZIONE: Offerta aggiornata con il valore minimo</label>");
                      jQuery("#messaggiooffertaproxybid").html("<div class=\"label success\"><i class=\"fa-duotone fa-info-circle fa-fw\"></i>ATTENZIONE: Offerta aggiornata con il valore minimo</label>");
                    }
                  }
                }else{
                  if (jQuery("#offertalotto").val()<(intOffertaLotto)){
                    if (jQuery("#offertalotto").is(":focus")) {
                      jQuery("#messaggioofferta").html("<div class=\"label success\"><i class=\"fa-duotone fa-info-circle fa-fw\"></i>ATTENZIONE: Valore minimo: " + parseInt(intOffertaLotto) + "</label>");
                      jQuery("#messaggiooffertaproxybid").html("<div class=\"label success\"><i class=\"fa-duotone fa-info-circle fa-fw\"></i>ATTENZIONE: Valore minimo: " + parseInt(intOffertaLotto) + "</label>");
                    }else{
                      jQuery("#offertalotto").val(intOffertaLotto);
                      jQuery("#AsteProxyBid_ValoreMax").val(intOffertaLotto);
                      jQuery("#messaggioofferta").html("<div class=\"label success\"><i class=\"fa-duotone fa-info-circle fa-fw\"></i>ATTENZIONE: Offerta aggiornata con il valore minimo</label>");
                      jQuery("#messaggiooffertaproxybid").html("<div class=\"label success\"><i class=\"fa-duotone fa-info-circle fa-fw\"></i>ATTENZIONE: Offerta aggiornata con il valore minimo</label>");
                    }
                  }
                }
                <% if (boolLogin){ %>
                if (item.vincitore==<%=strUtentiLogin%>){
                  jQuery("#statoasta").removeClass("alert");
                  jQuery("#statoasta").addClass("success");
                  jQuery("#statoasta").html("<i class=\"fa-duotone fa-info-circle fa-fw fa-lg\"></i>Stai vincendo l'asta");
                }else{
                  jQuery("#statoasta").addClass("alert");
                  jQuery("#statoasta").removeClass("success");
                  jQuery("#statoasta").html("<i class=\"fa-duotone fa-exclamation-triangle fa-fw fa-lg\"></i>Non stai vincendo l'asta. La tua offerta &egrave; stata superata.");
                }
                <% } %>
                
								
                strValore=item.valoreattuale;
                strValore=strValore.replace(".","",)
								intValore=parseInt(strValore)
								var arrayLength = arrayCommissioni.length;
								for (var i = 0; i < arrayLength; i++) {
										//console.log(intValore);	
										//console.log(parseInt(arrayCommissioni[i][0]));	
										//console.log(parseInt(arrayCommissioni[i][1]));	
										if (intValore>=parseInt(arrayCommissioni[i][0]) && intValore<=parseInt(arrayCommissioni[i][1])){
										  intCommissione=arrayCommissioni[i][2];
										}	
								}								
                jQuery("#valorecommissione").html("+" + intCommissione + "%");
            });
        });
      }, 2000);      
    </script>
  </body>
</html>
