<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" EnableViewStateMac=False CodeFile="scheda-immobile.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it-IT">
  <head>
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title><%=strTitle%></title>
	<meta property="og:title" content="<%=strTitle%>" />
	<meta name="description" content="<%=strMetaDescription%>" />
	<meta name="og:description" content="<%=strMetaDescription%>" />
  	<meta name="robots" content="index,follow" />
	<!--#include file="/frontend/base/inc-head.aspx"-->
  </head>
  <body>
	<!--#include file="/frontend/base/inc-tagmanager.aspx"-->
	<!--#include file="/frontend/base/inc-header.aspx"-->
	<div class="grid-container">
  <div class="grid-x grid-padding-x">
		<div class="large-12 medium-12 small-12 cell">
			<nav aria-label="Sei in:" role="navigation">
				<ul class="breadcrumbs" id="breadcrumb" itemscope itemtype="https://schema.org/BreadcrumbList">
				<li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem">
					<a href="/" title="Case, vendita e affitto appartamenti, annunci immobiliari, villette, rustici e uffici" itemtype="https://schema.org/Thing" itemprop="item">
						<span itemprop="name">Home</span>
					</a>
					<meta itemprop="position" content="1" />
				</li>
				<li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem">
					<a href="/<%=dtCasa.Rows[0]["Province_ProvinciaHTML"].ToString().ToLower()%>/vendita-case-provincia-<%=dtCasa.Rows[0]["Province_ProvinciaHTML"].ToString().ToLower()%>.html" title="case <%=dtCasa.Rows[0]["Province_Provincia"].ToString().ToLower()%>" itemtype="https://schema.org/Thing" itemprop="item">
						<span itemprop="name"><%=dtCasa.Rows[0]["Province_Provincia"].ToString().ToLower()%></span>
					</a>
					<meta itemprop="position" content="2" />
				</li>
				<li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem">
					<span itemprop="name"><%=dtCasa.Rows[0]["Comuni_Comune"].ToString().ToLower()%></span>
					<meta itemprop="position" content="3" />
				</li>
				</ul>
			</nav>  
		</div>
	</div>
	<div class="grid-x grid-padding-x">
		<div class="large-8 medium-8 small-12 cell" id="annunci">        
					    <div id="scheda" itemtype="https://schema.org/Product" itemscope>
    						<h1 itemprop="name"><%=strH1%></h1>
                <hr>
      
								<div class="grid-x grid-padding-x">
					        <div class="large-7 medium-7 small-12 cell">
					          <% if (dtCasa.Rows[0]["Immobili_Foto1"].ToString().Length>0){ %>
					            <script>strPathImmagine='<%=dtCasa.Rows[0]["Immobili_Foto1"].ToString()%>';</script>
					            <a href="<%=dtCasa.Rows[0]["Immobili_Foto1b"].ToString()%>" title="<%=strH1%>" id="f1" data-fancybox="galleriaannuncio" data-type="image" data-caption="<%=strH1%>">
                        <%
                        if (dtCasa.Rows[0]["Immobili_Foto1"].ToString().Length>0){
                        %>
                        <img src="<%=dtCasa.Rows[0]["Immobili_Foto1"].ToString()%>" alt="<%=dtCasa.Rows[0]["Immobili_Foto1"].ToString()%>" border="0" />
                        <% }else{ %>
                        <img src="https://via.placeholder.com/400x300.webp?text=nessun+immagine" alt="<%=strH1%>" border="0" width="300" height="150" style="width:300px;height:150px" itemprop="image" />
                        <% } %>
					            </a>
					          <% }else{ %>
					            <div class="noFotoScheda" id="anteprima"></div>
					          <% } %>
					        </div>
					        <div class="large-5 medium-5 small-12 cell">
					          <div class="grid-x grid-padding-x">
											<div class="large-4 medium-4 small-4 cell">
												<label>Prezzo:</label>
											</div>
											<div class="large-8 medium-8 small-8 cell">
								          <span class="price">
													<%
								          if ((dtCasa.Rows[0]["Immobili_ValoreNascondi"].Equals(true)) || (dtCasa.Rows[0]["Immobili_Valore"].Equals(null)) || (dtCasa.Rows[0]["Immobili_Valore"].Equals(0)))
								          {
								            Response.Write("<span itemprop=\"offers\" itemscope itemtype=\"https://schema.org/Offer\"><span itemprop=\"price\">Tratt. riservata</span></span>");
								          }
								          else
								          { 
								            Response.Write("<span itemprop=\"offers\" itemscope itemtype=\"https://schema.org/Offer\"><span itemprop=\"price\" content=\"" + ((decimal)dtCasa.Rows[0]["Immobili_Valore"]).ToString("N0", ci) + "\"><span itemprop=\"priceCurrency\" value=\"EUR\">&euro;</span> " + ((decimal)dtCasa.Rows[0]["Immobili_Valore"]).ToString("N0", ci) + "</span></span>");
								          }    
								          %> 
													</span>                   
											</div>
										</div>
					          <div class="grid-x grid-padding-x">
											<div class="large-4 medium-4 small-4 cell">
												<label>Tipologia:</label>
											</div>
											<div class="large-8 medium-8 small-8 cell">
												<strong><%=dtCasa.Rows[0]["ImmobiliTipologia_Descrizione"].ToString().Trim()%></strong>
											</div>
										</div>
					          <div class="grid-x grid-padding-x">
											<div class="large-4 medium-4 small-4 cell">
												<label>Contratto:</label>
											</div>
											<div class="large-8 medium-8 small-8 cell">
												<strong><%=dtCasa.Rows[0]["ImmobiliCategoria_Descrizione"].ToString().Trim()%></strong>
											</div>
										</div>
					          <div class="grid-x grid-padding-x">
											<div class="large-4 medium-4 small-4 cell">
												<label>Riferimento:</label>
											</div>
											<div class="large-8 medium-8 small-8 cell">
												<strong><%=dtCasa.Rows[0]["Immobili_Ky"].ToString().Trim()%></strong>
											</div>
										</div>
										<% if (dtCasa.Rows[0]["Immobili_Riferimento"].ToString().Trim().Length>0){ %>
										<div class="grid-x grid-padding-x">
											<div class="large-4 medium-4 small-4 cell">
												<label>Rif. agenzia:</label>
											</div>
											<div class="large-8 medium-8 small-8 cell">
												<strong><%=dtCasa.Rows[0]["Immobili_Riferimento"].ToString().Trim()%></strong>
											</div>
										</div>
										<% } %>
										<% if (dtCasa.Rows[0]["Immobili_NumeroLocali"].ToString().Trim().Length>0){ %>
					          			<div class="grid-x grid-padding-x">
											<div class="large-4 medium-4 small-4 cell">
												<label>Locali:</label>
											</div>
											<div class="large-8 medium-8 small-8 cell">
												<strong><i class="fa-duotone fa-map fa-fw"></i><%=dtCasa.Rows[0]["Immobili_NumeroLocali"].ToString().Trim()%></strong>
											</div>
										</div>
										<% } %>
										<% if (dtCasa.Rows[0]["Immobili_NumeroCamereLetto"].ToString().Trim().Length>0){ %>
										<div class="grid-x grid-padding-x">
											<div class="large-4 medium-4 small-4 cell">
												<label>Camere letto:</label>
											</div>
											<div class="large-8 medium-8 small-8 cell">
												<strong><i class="fa-duotone fa-bed fa-fw"></i>&nbsp;<%=dtCasa.Rows[0]["Immobili_NumeroCamereLetto"].ToString().Trim()%></strong>
											</div>
										</div>
										<% } %>
										<% if (dtCasa.Rows[0]["Immobili_NumeroBagni"].ToString().Trim().Length>0){ %>
					          			<div class="grid-x grid-padding-x">
											<div class="large-4 medium-4 small-4 cell">
												<label>Bagni:</label>
											</div>
											<div class="large-8 medium-8 small-8 cell">
												<strong><i class="fa-duotone fa-bath fa-fw"></i>&nbsp;<%=dtCasa.Rows[0]["Immobili_NumeroBagni"].ToString().Trim()%></strong>
											</div>
										</div>
										<% } %>
										<% if (dtCasa.Rows[0]["Immobili_NumeroPostiAuto"].ToString().Trim().Length>0){ %>
					          			<div class="grid-x grid-padding-x">
											<div class="large-4 medium-4 small-4 cell">
												<label>Posti auto:</label>
											</div>
											<div class="large-8 medium-8 small-8 cell">
												<strong><i class="fa-duotone fa-car fa-fw"></i>&nbsp;<%=dtCasa.Rows[0]["Immobili_NumeroPostiAuto"].ToString().Trim()%></strong>
											</div>
										</div>
										<% } %>
										<% if (dtCasa.Rows[0]["Immobili_ClasseEnergetica"].ToString().Trim().Length>0){ %>
					          			<div class="grid-x grid-padding-x">
											<div class="large-4 medium-4 small-4 cell">
												<label>Classe energ.:</label>
											</div>
											<div class="large-8 medium-8 small-8 cell">
												<strong><i class="fa-duotone fa-leaf fa-fw"></i>&nbsp;<%=dtCasa.Rows[0]["Immobili_ClasseEnergetica"].ToString().Trim()%></strong>
												<%
															if (dtCasa.Rows[0]["Immobili_Ipe"].ToString()!=""){
													Response.Write(" - ipe: " + dtCasa.Rows[0]["Immobili_Ipe"].ToString());
												}
												%>
											</div>
										</div>
										<% } %>
					          <div class="grid-x grid-padding-x">
											<div class="large-4 medium-4 small-4 cell">
												<label>Mq:</label>
											</div>
											<div class="large-8 medium-8 small-8 cell">
												<strong><%=dtCasa.Rows[0]["Immobili_Mq"].ToString().Trim().Replace(",0000","")%> m&sup2;</strong>
											</div>
										</div>
					        </div>
					      </div>
						  <div class="grid-x grid-padding-x">
								<div class="large-12 medium-12 small-12 cell">
									<p itemprop="description">
									<br>
									<%=dtCasa.Rows[0]["Immobili_Annuncio"].ToString().Trim()%>      
									<br><br>
									<!--#include file="/frontend/base/inc-adsense.aspx"-->
									</p>  
								</div>
							</div>						
							<div class="grid-x grid-padding-x">
					        	<div class="large-12 medium-12 small-12 cell">
					           
									<div class="row small-up-1 medium-up-1 large-up-1 text-center">
										<%
											for (i = 2; i < 10; i++){
												if (dtCasa.Rows[0]["Immobili_Foto" + i + "b"].ToString().Length>0){
													Response.Write("<div class=\"column\">");
													Response.Write("<a href=\"" + dtCasa.Rows[0]["Immobili_Foto" + i + "b"].ToString() + "\" title=\":: " + strH1 + "\" id=\"f" + i + "\" data-fancybox=\"galleriaannuncio\" data-type=\"image\" data-caption=\"" + strH1 + "\">");
													Response.Write("<img src=\"" + dtCasa.Rows[0]["Immobili_Foto" + i + "b"].ToString() + "\" itemprop=\"image\" class=\"thumbnail\" alt=\"" + strH1 + "\" />");
													Response.Write("</a>");
													Response.Write("</div>");
												
												}

											}
										%>
					            	</div>
					      		</div>
							</div>

					  </div>
					
						<% if (strIndirizzo!=null && strIndirizzo.Length>0){ %>
						<div class="grid-x grid-padding-x">
			        <div class="large-12 medium-12 small-12 cell">
								<div class="card">
								<iframe width="100%" style="width:100%;height:450px;border:0;" src="https://www.google.com/maps/embed/v1/place?key=AIzaSyCm4UkN3D3QC1QV8RzP10VYclgiTuqusN0&q=<%=strIndirizzo%>" allowfullscreen></iframe>
								</div>
							 </div>
						</div>
						<% } %>		
						<div class="grid-x grid-padding-x">
							<div class="large-12 medium-12 small-12 cell">        
								<!--#include file="/frontend/base/inc-adsense.aspx"-->
							 </div>
						</div>									  
		</div>
		<div class="large-4 medium-4 small-12 cell" data-sticky-container>
				    <aside class="sidebar" id="colonnadx"  data-sticky data-top-anchor="header:bottom" data-btm-anchor="footer:top">
				        <div class="callout" itemscope itemtype="https://schema.org/Organization">
					      	<h6>Venditore annuncio immobiliare</h6>
				          	<div class="grid-x">
								<div class="large-8 medium-8 small-8 cell">						          
										<ul class="fa-ul">
											<li>
												<span class="fa-li"><i class="fa-duotone fa-user-tie fa-fw"></i></span>
												<span class="nome" itemprop="name"><%=dtCasa.Rows[0]["Utenti_Nominativo"].ToString().Trim()%></span>
											</li>
											<li>
												<span class="fa-li"><i class="fa-duotone fa-map-marker-alt fa-fw"></i></span>
												<span itemprop="address" itemscope itemtype="https://schema.org/PostalAddress"></span>
												<span itemprop="streetAddress"><%=dtCasa.Rows[0]["Utenti_Indirizzo"].ToString().Trim()%></span>
												<span itemprop="addressLocality"><%=dtCasa.Rows[0]["ComuneVenditore"].ToString().Trim()%></span>
												<span itemprop="addressRegion"><%=dtCasa.Rows[0]["Province_Provincia"].ToString().Trim()%></span>
											</li>
											<li>
												<span class="fa-li"><i class="fa-duotone fa-phone fa-fw"></i></span>
												<span itemprop="telephone"><%=dtCasa.Rows[0]["Utenti_Telefono1"].ToString().Trim()%></span></li>
										</ul>							        
								</div>
								<div class="large-4 medium-4 small-4 cell">
									<% if (dtCasa.Rows[0]["Utenti_Logo"].ToString().Trim().Length>0){ %>
									<img src="<%=dtCasa.Rows[0]["Utenti_Logo"].ToString().Trim()%>" itemprop="image"
										alt="<%=dtCasa.Rows[0]["Utenti_Nominativo"].ToString()%>" />
									<% } %>
								</div>
							</div>
				        </div>
				            <form action="/form/form-contatti-immobile.aspx" runat="server" data-abide name="contattavenditore" id="contattavenditore" method="post" novalidate>
											<div data-abide-error class="alert callout" style="display: none;">
										    <p><i class="fa-duotone fa-exclamation-triangle fa-fw"></i> Ci sono errori nel tuo modulo.</p>
										  </div>
					            <div class="grid-x grid-padding-x">
					              <div class="large-4 medium-4 small-4 cell">
													<label for="nome" class="text-right middle">Nome:*&nbsp;</label>
												</div>
					              <div class="large-8 medium-8 small-8 cell">
						              <input type="text" name="nome" id="nome" placeholder="Nome" required="required" />
						              <span class="form-error">Obbligatorio</span>
						            </div>
				            	</div>
					            <div class="grid-x grid-padding-x">
					              <div class="large-4 medium-4 small-4 cell">
													<label for="email" class="text-right middle">Email:*&nbsp;</label>
												</div>
					              <div class="large-8 medium-8 small-8 cell">
						              <input type="text" name="email" id="email" placeholder="Email" required="required" />
						              <span class="form-error">Obbligatorio</span>
						            </div>
				            	</div>
					            <div class="grid-x grid-padding-x">
					              <div class="large-4 medium-4 small-4 cell">
													<label for="telefono" class="text-right middle">Telefono:*&nbsp;</label>
												</div>
					              <div class="large-8 medium-8 small-8 cell">
						              <input type="text" name="telefono" id="telefono" placeholder="Telefono" required="required" />
						              <span class="form-error">Obbligatorio</span>
						            </div>
				            	</div>
					        <div class="grid-x grid-padding-x">
								<div class="large-4 medium-4 small-4 cell">
										<label for="messaggio" class="text-right middle">Messaggio</label>
									</div>
							  <div class="large-8 medium-8 small-8 cell">
								  <textarea name="messaggio" id="messaggio" placeholder="Messaggio" rows="2"></textarea>
						              <span class="form-error">Obbligatorio</span>
						            </div>
							</div>	
							 <div class="grid-x grid-padding-x" id="trcaptcha">
								<div class="large-4 medium-4 small-4 cell">
									<label for="codice" class="text-right middle">Codice</label>
								</div>
							   <div class="large-4 medium-4 small-8 cell"><img src="/captcha-3.aspx" style="float:left;padding:0 20px;" alt="captcha" /></div>
							   <div class="large-4 medium-34 small-12 cell"><input type="text" name="codice" id="codice" maxlength="15" size="15" required="required" /></div> 
							 </div>								
				            <p class="text-center">
				            <input type="checkbox" name="privacy" id="privacy" checked="checked" value="si"/> Acconsento al trattamento dati (<a href="/pag/condizioni-del-servizio.html#privacy" target="_blank" rel="nofollow" class="pulsantescheda">info</a>)
				            <br />
							<input type="hidden" name="Immobili_Ky" id="Immobili_Ky" value="<%=dtCasa.Rows[0]["Immobili_Ky"].ToString()%>" />
							<input type="hidden" name="controllo" id="controllo" value="">
				            <asp:Button ID="btnSubmit" runat="server" Text="Invia contatto al venditore" class="button large alert" />
				            </p>
				            </form>
				
				
						</aside>    
  		</div>
  </div>
  </div>
  <!--#include file="/frontend/base/inc-footer.aspx"-->
  </body>
</html>
