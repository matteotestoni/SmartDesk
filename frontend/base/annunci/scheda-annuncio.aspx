<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="scheda-annuncio.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" dir="ltr" lang="it-IT">
  <head>
  	<title><%=strH1%></title>
    <!--#include file="/frontend/base/inc-head.aspx"--> 
  </head>
  <body>
  	<!-- #include file ="/frontend/base/inc-header.aspx" -->
					<div class="grid-x grid-padding-x">
	            <div class="large-12 medium-12 small-12 cell">
	            	<h1><%=dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString()%></h1>
	                <div class="attributi-asta"><span style="color:#406f9c">ID ANNUNCIO:</span> <strong><%=dtAnnuncio.Rows[0]["Annunci_Ky"].ToString()%></strong></div>
	                <div class="attributi-asta"><span style="color:#406f9c">CATEGORIA:</span> <strong><%=dtAnnuncio.Rows[0]["AnnunciCategorie_Titolo"].ToString()%></strong></div>
	            </div>
	        </div>
					<div class="grid-x grid-padding-x" data-equalizer>
        	<div class="xlarge-6 medium-up-12 large-6 small-12 cell">
            <div data-equalizer-watch>
                  <div class="callout-scheda-foto" style="background-image:url(<%=dtAnnuncio.Rows[0]["Annunci_Foto1"].ToString()%>);max-height:400px">
                      <a style="display:block;width:100%;max-height:100%" href="<%=dtAnnuncio.Rows[0]["Annunci_Foto1"].ToString()%>" data-fancybox="galleriaannuncio" data-type="image" data-caption="<%=dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString()%>">&nbsp</a>
                  </div>
                  <div class="row small-up-2 medium-up-4 large-up-5 slider-nav">
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
                      if (i>5){
                        strClass+=" hide-for-large";
                      }
                      if (i<intNumeroFoto-1){
                          if (dtAnnuncio.Rows[0][strTemp].ToString().Length>0){
                            Response.Write("<div class=\"cell" + strClass + "\"><a href=\"" + dtAnnuncio.Rows[0][strTemp].ToString()  + "\" data-fancybox=\"galleriaannuncio\" data-type=\"image\" data-caption=\"" + dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString() + "\"><img src=\"" + dtAnnuncio.Rows[0][strTemp].ToString() + "\" height=\"150\" width=\"100\" style=\"width:150px;height:100px;\" alt=\"" + dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString() + "\"></a></div>");
                          }
                      }else{
                          if (i==intNumeroFoto){
                            if (dtAnnuncio.Rows[0][strTemp].ToString().Length>0){
                              Response.Write("<div class=\"column column-block\"><a href=\"" + dtAnnuncio.Rows[0][strTemp].ToString()  + "\" style=\"position:relative\" data-fancybox=\"galleriaannuncio\" data-type=\"image\" data-caption=\"" + dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString() + "\" id=\"" + strTemp  + "\"><img src=\"" + dtAnnuncio.Rows[0][strTemp].ToString()  + "\" height=\"150\" width=\"100\" style=\"width:150px;height:100px;filter: brightness(40%);\" alt=\"" + dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString() + "\"><div style=\"position:absolute;left:30%;top:0;color:#ffffff;padding:0.25rem;\"><i class=\"fa-duotone fa-camera fa-fw fa-lg\" style=\"color:#ffffff;\"></i>" + dtAnnuncio.Rows[0]["Annunci_NumeroFoto"].ToString() + "</div></a></div>");
                            }
                          }else{
                            if (dtAnnuncio.Rows[0][strTemp].ToString().Length>0){
                              Response.Write("<div class=\"cell" + strClass + "\"><a href=\"" + dtAnnuncio.Rows[0][strTemp].ToString()  + "\" data-fancybox=\"galleriaannuncio\" data-type=\"image\" data-caption=\"" + dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString() + "\"><img src=\"" + dtAnnuncio.Rows[0][strTemp].ToString()  + "\" height=\"150\" width=\"100\" style=\"width:150px;height:100px;\" alt=\"" + dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString() + "\"></a></div>");
                            }
                          }
                      }
                    }
                    %>
                  </div> 
             </div>             
            </div>
            <div class="xlarge-6 medium-up-12 large-6 small-12 cell">
            	<div class="callout-scheda-dettagli" data-equalizer-watch>
                      <div class="dettagli-scheda-asta-container">
                          <div class="dettagli-annuncio">
                             <div class="grid-x grid-padding-x" style="margin-top: 14px;">
                          		<div class="large-12 medium-12 small-12 cell text-center">
                          		  <span class="scadenza-scheda-asta"><i class="fa-duotone fa-tag fa-fw fa-lg fa-flip-horizontal" style="color:#345a7f"></i> &euro; <%=((decimal)dtAnnuncio.Rows[0]["Annunci_Valore"]).ToString("N0", ci)%></span>
                          		</div>
                     		    </div> 
                            <hr class="hr-scheda-asta hide-for-small-only">
                              <div class="grid-x grid-padding-x">
                                  <div class="large-6 medium-6 small-12 cell">
                                    <p>
                                    <small><%=dtAnnuncio.Rows[0]["AnagraficheTipologia_Titolo"].ToString()%></small><br>    
                                    <%=dtAnnuncio.Rows[0]["Anagrafiche_RagioneSociale"].ToString()%><br>    
                                    <%=dtAnnuncio.Rows[0]["Anagrafiche_Indirizzo"].ToString()%><br>    
                                    <%=dtAnnuncio.Rows[0]["Comuni_Comune"].ToString()%> - <%=dtAnnuncio.Rows[0]["Province_Provincia"].ToString()%><br>    
                                    <% if (boolPremium){ %>
                                    <span class="label" style="background-color:#1da1f2"><i class="fa-duotone fa-user fa-fw"></i>azienda premium</span>
                                    <% } %> 
                                    </p>
                                  </div>
                                  <div class="large-6 medium-6 small-12 cell text-center">
                                    <a href="#contattavenditore" class="button small buttonannunci radius expanded"><i class="fa-duotone fa-envelope fa-fw"></i>Contatta il venditore</a>
                                    <a href="tel:<%=dtAnnuncio.Rows[0]["Anagrafiche_Telefono"].ToString()%>" class="button small radius buttonannunci expanded telefonoannuncio"><i class="fa-duotone fa-phone-square fa-fw"></i><%=dtAnnuncio.Rows[0]["Anagrafiche_Telefono"].ToString()%></a>
                                  </div>
                              </div>
                              <div class="grid-x grid-padding-x">
                                  <div class="large-3 medium-3 small-4 cell">
                                      <span class="dettaglio-asta">Marca:</span>
                                  </div>
                                  <div class="large-9 medium-9 small-8 cell text-right">
                                      <span class="dettaglio-asta"><%=dtAnnuncio.Rows[0]["AnnunciMarca_Titolo"].ToString()%></span>
                                  </div>
                              </div>
                              <div class="grid-x grid-padding-x">
                                  <div class="large-3 medium-3 small-4 cell">
                                      <span class="dettaglio-asta">Modello:</span>
                                  </div>
                                  <div class="large-9 medium-9 small-8 cell text-right">
                                      <span class="dettaglio-asta">
                                      <% 
                                      if (dtAnnuncio.Rows[0]["Annunci_Modello"].ToString().Length>0){
                                        Response.Write(dtAnnuncio.Rows[0]["Annunci_Modello"].ToString());
                                      }else{
                                        Response.Write(dtAnnuncio.Rows[0]["AnnunciModello_Titolo"].ToString());
                                      }
                                      
                                      %>
                                      </span>
                                  </div>
                              </div>
                              <div class="grid-x grid-padding-x">
                                  <div class="large-3 medium-3 small-4 cell">
                                      <span class="dettaglio-asta">Anno:</span>
                                  </div>
                                  <div class="large-9 medium-9 small-8 cell text-right">
                                      <span class="dettaglio-asta">
                                      <%
                                      if (dtAnnuncio.Rows[0]["Annunci_Anno"].ToString()=="0" || dtAnnuncio.Rows[0]["Annunci_Anno"].ToString()=="sconosciuto"){
                                        Response.Write("sconosciuto");                            
                                      }else{
                                        Response.Write(dtAnnuncio.Rows[0]["Annunci_Anno"].ToString());
                                      }
                                      %>
                                      </span>
                                  </div>
                              </div>
                              <% if (dtAnnuncio.Rows[0]["Annunci_Km"].ToString().Length>0 && dtAnnuncio.Rows[0]["Annunci_Km"].ToString()!="0"){ %>
                              <div class="grid-x grid-padding-x">
                                  <div class="large-3 medium-3 small-4 cell">
                                      <span class="dettaglio-asta">Km:</span>
                                  </div>
                                  <div class="large-9 medium-9 small-12 cell text-right">
                                      <span class="dettaglio-asta"><%=dtAnnuncio.Rows[0]["Annunci_Km"].ToString()%></span>
                                  </div>
                              </div>
                              <% } %>
                              <div class="grid-x grid-padding-x">
                                  <div class="large-3 medium-3 small-4 cell">
                                      <span class="dettaglio-asta">Localizzazione:</span>
                                  </div>
                                  <div class="large-9 medium-9 small-8 cell text-right">
                                      <span class="dettaglio-asta"><img src="/img/icona-ita.png" style="margin-right:5px"><%=dtAnnuncio.Rows[0]["Nazioni_Codice"].ToString()%> / <%=dtAnnuncio.Rows[0]["Regioni_Regione"].ToString()%> / <%=dtAnnuncio.Rows[0]["Comuni_Comune"].ToString()%></span>
                                  </div>
                              </div>
                          	  <div class="grid-x grid-padding-x" style="margin-top: 15px;">
                                  <div class="large-6 medium-6 small-12 cell text-right">
                                  </div>
                                  <div class="large-6 medium-6 small-12 cell text-right">
                                    <a class="button hollow secondary expanded wow slideInDown" href="#descrizioneannuncio"><i class="fa-duotone fa-file-text fa-lg" aria-hidden="true"></i> VEDI INFO AGGIUNTIVE</a>
                                  </div>
                              </div>
                          </div>                      
                      </div>
                </div>
            </div>
            </div>
		        <a name="descrizioneannuncio"></a>
            <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell">
		                <h2><b>DESCRIZIONE</b> DELL'ANNUNCIO</h2>
		                <hr class="linea-blu"/>
		            </div>
            </div>
            <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell">
                    <div class="grid-x grid-padding-x" data-equalizer>
                      <div class="large-5 medium-5 small-12 cell">
                          <fieldset class="fieldset" data-equalizer-watch>
                            <legend class="text-left">Informazioni principali</legend>
                            <% Response.Write(getAttributiTable()); %>
                          </fieldset>
                      </div>
                      <div class="large-7 medium-7 small-12 cell">
                          <fieldset class="fieldset note" data-equalizer-watch>
                            <legend class="text-left">Note</legend>
                            <%=dtAnnuncio.Rows[0]["Annunci_Descrizione"].ToString()%>
                          </fieldset>
                      </div>
                    </div>
        						<%if (boolLogin==false){%>
    		          	<div class="text-center" style="margin-bottom: 40px">
    		            	<a class="button success large" href="/login.aspx?ReturnUrl=/scheda-annuncio.aspx?Annunci_Ky=2017"><i class="fa-duotone fa-user-shield fa-3" aria-hidden="true"></i> <strong>ACCEDI</strong> PER VEDERE TUTTE LE INFORMAZIONI</a>
    		            </div>
                    <%}%>
		            </div>
		        </div>       
		        <a name="contattavenditore"></a>
            <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell">
		                <h2><b>CONTATTA</b> IL VENDITORE</h2>
		                <hr class="linea-blu"/>
		            </div>
            </div>
            <div class="grid-x grid-padding-x">
		            <div class="large-12 medium-12 small-12 cell">
								<p>Compila il seguente modulo di richiesta di informazioni per contattare il venditore.</p>
								<form method="post" action="/form/form-contattiannuncio.aspx" name="formContatti" id="formContatti" data-abide novalidate>
                  <input type="hidden" name="Annunci_Ky" id="Annunci_Ky" value="<%=dtAnnuncio.Rows[0]["Annunci_Ky"].ToString()%>">
                  <input type="hidden" name="Anagrafiche_Ky" id="Anagrafiche_Ky" value="<%=dtAnnuncio.Rows[0]["Anagrafiche_Ky"].ToString()%>">
                  <input type="hidden" name="proteggi" id="proteggi" value="">
									<fieldset>
										<div class="grid-x grid-padding-x">
											<div class="large-2 medium-2 small-12 cell"><label for="nome">Il tuo nome e cognome*:</label></div>
											<div class="large-10 medium-10 small-12 cell">
                        <input type="text" name="nome" id="nome" tabindex="1" required="required">
                        <span class="form-error">Obbligatorio</span>
                      </div>
										</div>	
										<div class="grid-x grid-padding-x">
											<div class="large-2 medium-2 small-12 cell"><label for="email">Email*:</label></div>
											<div class="large-10 medium-10 small-12 cell">
                        <input type="email" name="email" id="email" tabindex="1" required="required">
                        <span class="form-error">Obbligatorio</span>
                      </div>
										</div>
										<div class="grid-x grid-padding-x">
											<div class="large-2 medium-2 small-12 cell"><label for="telefono">Cellulare/Tel.*:</label></div>
											<div class="large-10 medium-10 small-12 cell">
                        <input type="text" name="telefono" id="telefono" tabindex="1" required="required">
                        <span class="form-error">Obbligatorio</span>
                      </div>
										</div>
										<div class="grid-x grid-padding-x">
											<div class="large-2 medium-2 small-12 cell"><label for="messaggio">Messaggio*:</label></div>
											<div class="large-10 medium-10 small-12 cell">
                        <textarea name="messaggio" id="messaggio" required="required" rows="4"></textarea>
                        <span class="form-error">Obbligatorio</span>
                      </div>
										</div>
										<div class="grid-x grid-padding-x">
											<div class="large-2 medium-2 small-12 cell">
												<p><label for="privacy"><a href="/contenuto.aspx?CMSContenuti_Ky=4">Accetto il trattamento dei miei dati personali ai sensi del D.Lgs 196/2003</a></label></p>
											</div>
											<div class="large-10 medium-10 small-12 cell">
                        <input name="consenso" id="consenso" type="checkbox" required="required" checked="checked" />
                        <span class="form-error">Obbligatorio</span>
                      </div>
										</div>
										<div class="grid-x grid-padding-x">
											<div class="large-12 medium-12 small-12 cell text-center">
												<button type="submit"  class="button large radius success">Contatta ora il venditore <i class="fa-duotone fa-angle-right fa-fw"></i></button>
											</div>
										</div>
									</fieldset>								
								</form>							
		            </div>
		        </div>       
		        <% if (dtAnnunciSimili.Rows.Count>0){%>
             <div class="grid-x grid-padding-x">
		         	<div class="large-12 medium-12 small-12 cell">
		               <a name="elenco-lotti"></a> <h2><b>TI POTREBBE INTERESSARE ANCHE</b></h2>
		               <hr class="linea-blu"/>
            	     <!-- #include file ="/frontend/base/annunci/inc-elenco-annunci-simili.inc" -->
		       		</div>
		         </div>
            <% } %>
        		<p class="hide-for-small-only"><br><br></p>
					<div class="js-off-canvas-exit"></div>
        </div>
			</div>
  	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
  	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
    <script type="text/javascript">
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
    </script>
  </body>
</html>
