<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="scheda-auto.aspx.cs" Inherits="_Default" Debug="false"%>
<!doctype html>
<html class="no-js" lang="it">
	<head>
		<meta charset="utf-8" />
		<title><%=strTitle%></title>
		<meta name="description" content="<%=strMetaDescription%>"/>
		<meta property="og:title" content="<%=strTitle%>" />
		<meta property="og:description" content="<%=strMetaDescription%>" />		
	  <!-- #include file ="/frontend/base/inc-head.aspx" -->
	</head>
	<body class="bodyschedauto <%=strUtm_source%>">
		<!--#include file="/frontend/base/inc-header.aspx"-->
			<div class="grid-container" id="breadcrumbs">
				<div class="grid-x grid-padding-x">
					<div class="large-11 medium-10 small-8 cell">
						<br>
						<nav class="breadcrumbs">
							<li><a href="/home.aspx">Home</a></li>
							<li><a href="/auto/<%=dtVeicolo.Rows[0]["VeicoliMarca_UrlKey"].ToString().ToLower()%>.html"><%=dtVeicolo.Rows[0]["VeicoliMarca_Titolo"].ToString()%></a></li>
							<li><span class="current"><%=strTitle%></span></li>
						</nav>
					</div>
					<div class="large-1 medium-2 small-4 cell">
						<div class="scheda-links text-right">
							<% if (strPreferitiCookie.Contains(dtVeicolo.Rows[0]["Veicoli_Ky"].ToString())){ %>
								<a href="#" onclick="aggiungiPreferiti(<%=dtVeicolo.Rows[0]["Veicoli_Ky"].ToString()%>);return false;" data-tooltip title="Veicolo nei preferiti"><i id="iconapreferiti<%=dtVeicolo.Rows[0]["Veicoli_Ky"].ToString()%>" class="fa-solid fa-heart" style="color:red"></i></a>
							<% }else{ %>
								<a href="#" onclick="aggiungiPreferiti(<%=dtVeicolo.Rows[0]["Veicoli_Ky"].ToString()%>);return false;"><i id="iconapreferiti<%=dtVeicolo.Rows[0]["Veicoli_Ky"].ToString()%>" class="fa-duotone fa-heart"></i></a>
							<% } %>
							<% if (strConfrontoCookie.Contains(dtVeicolo.Rows[0]["Veicoli_Ky"].ToString())){ %>
								<a href="#" onclick="aggiungiConfronto(<%=dtVeicolo.Rows[0]["Veicoli_Ky"].ToString()%>);return false;" data-tooltip title="Veicolo nel confronto"><i id="iconaconfronto<%=dtVeicolo.Rows[0]["Veicoli_Ky"].ToString()%>" class="fa-solid fa-plus-square"></i></a>
							<% }else{ %>
								<a href="#" onclick="aggiungiConfronto(<%=dtVeicolo.Rows[0]["Veicoli_Ky"].ToString()%>);return false;"><i id="iconaconfronto<%=dtVeicolo.Rows[0]["Veicoli_Ky"].ToString()%>" class="fa-duotone fa-plus-square"></i></a>
							<% } %>
						</div>
					</div>
				</div>
			</div>
			
			<%if (Request["inviato"]=="inviato"){ %>
			<div class="grid-container">
				<div class="grid-x grid-padding-x">
					<div class="large-12 medium-12 small-12 cell">
						<div id="messaggioinviato" data-reveal class="reveal callout success">
							<i class="fa-duotone fa-info-circle fa-fw fa-4x fa-pull-left"></i>La vostra richiesta &egrave; stata inviata con successo.<br>Sarete ricontattati al pi&ugrave; presto. Grazie.<br>Spazio.
							<button class="close-button" data-close aria-label="Close modal" type="button">
								<span aria-hidden="true">&times;</span>
							</button>
						</div>
					</div>
				</div>
			</div>
			<% } %>
			<%if (Request["inviato"]=="no"){ %>
			<div class="grid-container">
				<div class="grid-x grid-padding-x">
					<div class="large-12 medium-12 small-12 cell">
						<div data-alert class="alert-box warning">
							<i class="fa-duotone fa-info-circle fa-fw fa-2x fa-pull-left"></i>La vostra richiesta NON &egrave; stata inviata. Ritenta controllando di aver inserite il codice di contatto corretto. Grazie.<br>Spazio.
							<a href="#" class="close">&times;</a>
						</div>
					</div>
				</div>
			</div>
			<% } %>	
        		
			<div class="grid-container" id="main">
				<div class="grid-x grid-padding-x grid-padding-y align-middle" id="titolo">		
					<div class="large-1 medium-2 small-2 cell auto text-center hide-for-small-only">
						<img src="https://cdn.spaziogroup.com/spazio2019/img/marchi/96x96/logo-<%=dtVeicolo.Rows[0]["VeicoliMarca_Titolo"].ToString().Trim().ToLower()%>.png" alt="auto usate <%=dtVeicolo.Rows[0]["VeicoliMarca_Titolo"].ToString().Trim().ToLower()%>" class="logo lazyload" width="75" height="75" loading="lazy">
					</div>
					<div class="cell auto align-middle">
						<h1><%=strH1%></h1>
            <hr>
					</div>
				</div>

				<div class="scheda-auto">
					<div class="grid-x grid-padding-x align-top">
						<div class="large-8 medium-12 small-12 cell">
							<div class="grid-x grid-padding-x scheda-auto">
								<div class="large-7 medium-7 small-12 cell">
									<!--#include file="scheda-auto-foto.aspx"-->
								</div>
								<div class="large-5 medium-5 small-12 cell">
									<div class="scheda-price <% if(dtVeicolo.Rows[0]["Veicoli_BestPrice"].Equals(true)){ %>bestprice<% } %>">
									<%
									if ((dtVeicolo.Rows[0]["Veicoli_ValoreNascondi"].Equals(true)) || (dtVeicolo.Rows[0]["Veicoli_Valore"].Equals(null))){
										Response.Write("Trattativa riservata");
									}else{ 
                    Response.Write("<div itemprop=\"makesOffer\" itemscope itemtype=\"https://schema.org/Offer\" itemref=\"veicolo" + dtVeicolo.Rows[0]["Veicoli_Ky"].ToString() + "\">");
                    Response.Write("<span itemprop=\"priceSpecification\" itemscope itemtype=\"https://schema.org/UnitPriceSpecification\">");
                  
										if (dtVeicoloOfferteAuto.Rows.Count>0){
											if ((decimal)dtVeicoloOfferteAuto.Rows[0]["Veicoli_ValoreTagliato"]>0){
                        Response.Write("<span class=\"oldprice\">&euro; " + ((decimal)dtVeicoloOfferteAuto.Rows[0]["Veicoli_ValoreTagliato"]).ToString("N0", ci) + "</span>");
												Response.Write("<span class=\"discount\">-&euro; " + (((decimal)dtVeicoloOfferteAuto.Rows[0]["Veicoli_ValoreTagliato"])-((decimal)dtVeicoloOfferteAuto.Rows[0]["Veicoli_ValoreInOfferta"])).ToString("N0", ci) + "* </span>");
												Response.Write("<span class=\"prezzo specialprice\"><meta itemprop=\"priceCurrency\" content=\"EUR\">&euro; <meta itemprop=\"price\" content=\"" + ((decimal)dtVeicoloOfferteAuto.Rows[0]["Veicoli_ValoreInOfferta"]).ToString("N0", ci).Replace(".","") + "\">" + ((decimal)dtVeicoloOfferteAuto.Rows[0]["Veicoli_ValoreInOfferta"]).ToString("N0", ci) + "</span>");											
											}else{
												if ((decimal)dtVeicoloOfferteAuto.Rows[0]["Veicoli_ValoreInOfferta"]!=(decimal)dtVeicolo.Rows[0]["Veicoli_Valore"]){
													Response.Write("<span class=\"prezzo specialprice\"><meta itemprop=\"priceCurrency\" content=\"EUR\">&euro; <meta itemprop=\"price\" content=\"" + ((decimal)dtVeicoloOfferteAuto.Rows[0]["Veicoli_ValoreInOfferta"]).ToString("N0", ci).Replace(".","") + "\">" + ((decimal)dtVeicoloOfferteAuto.Rows[0]["Veicoli_ValoreInOfferta"]).ToString("N0", ci) + "</span>");
													Response.Write("<span class=\"oldprice\">&euro; " + ((decimal)dtVeicolo.Rows[0]["Veicoli_Valore"]).ToString("N0", ci) + "</span>");
													Response.Write("<span class=\"discount\">-&euro; " + (((decimal)dtVeicolo.Rows[0]["Veicoli_Valore"])-((decimal)dtVeicoloOfferteAuto.Rows[0]["Veicoli_ValoreInOfferta"])).ToString("N0", ci) + "* </span>");
												}else{
													if (dtVeicolo.Rows[0]["Veicoli_Valore"]!=null && dtVeicolo.Rows[0]["Veicoli_Valore"].ToString().Length>0){
														Response.Write("<span class=\"prezzo\"><meta itemprop=\"priceCurrency\" content=\"EUR\">&euro; <meta itemprop=\"price\" content=\"" + ((decimal)dtVeicolo.Rows[0]["Veicoli_Valore"]).ToString("N0", ci).Replace(".","") + "\">" + ((decimal)dtVeicolo.Rows[0]["Veicoli_Valore"]).ToString("N0", ci) + "</span>");
													}
												}
											}
										}else{
                        if (dtVeicolo.Rows[0]["Veicoli_ValoreIniziale"]!=null && (decimal)dtVeicolo.Rows[0]["Veicoli_ValoreIniziale"]-(decimal)dtVeicolo.Rows[0]["Veicoli_Valore"]>=500){
    											Response.Write("<span class=\"oldprice bestprice\">&euro; " + ((decimal)dtVeicolo.Rows[0]["Veicoli_ValoreIniziale"]).ToString("N0", ci) + "</span>");
    											Response.Write("<span class=\"discount bestprice\">-&euro; " + (((decimal)dtVeicolo.Rows[0]["Veicoli_ValoreIniziale"])-((decimal)dtVeicolo.Rows[0]["Veicoli_Valore"])).ToString("N0", ci) + " </span>");
    											Response.Write("<span class=\"prezzo bestprice\"><meta itemprop=\"priceCurrency\" content=\"EUR\">&euro; <meta itemprop=\"price\" content=\"" + ((decimal)dtVeicolo.Rows[0]["Veicoli_Valore"]).ToString("N0", ci).Replace(".","") + "\">" + ((decimal)dtVeicolo.Rows[0]["Veicoli_Valore"]).ToString("N0", ci) + "</span>");											
                        }else{
                          if (dtVeicolo.Rows[0]["Veicoli_Valore"]!=null && dtVeicolo.Rows[0]["Veicoli_Valore"].ToString().Length>0){
      											Response.Write("<span class=\"prezzo\"><meta itemprop=\"priceCurrency\" content=\"EUR\">&euro; <meta itemprop=\"price\" content=\"" + ((decimal)dtVeicolo.Rows[0]["Veicoli_Valore"]).ToString("N0", ci).Replace(".","") + "\">" + ((decimal)dtVeicolo.Rows[0]["Veicoli_Valore"]).ToString("N0", ci) + "</span>");
      										}
                        }
										}
                    Response.Write("</span>");
                    Response.Write("</div>");
                    
									}                        
									%>
										<small>IVA incl.</small><br>
									</div>
                  <div id="veicolo<%=dtVeicolo.Rows[0]["Veicoli_Ky"].ToString()%>" itemprop="itemOffered" itemscope itemtype="https://schema.org/Car">
    									<div class="scheda-details grid-x">
    										<div class="detail detail-km large-6 medium-6 small-6 cell">
    											<%=dtVeicolo.Rows[0]["Veicoli_KM"].ToString()%> Km
    										</div>
    										<div class="detail detail-immatricolazione large-6 medium-6 small-6 cell">
    											<%=dtVeicolo.Rows[0]["Veicoli_DataPrimaImmatricolazione"].ToString()%>
    										</div>
    										<div class="detail detail-alimentazione large-6 medium-6 small-6 cell">
    											<%=dtVeicolo.Rows[0]["VeicoliCarburante_Descrizione"].ToString().Trim()%>
    										</div>
    										<%if (dtVeicolo.Rows[0]["Veicoli_NumeroPorte"].ToString().Trim().Length>0){ %>
    										<div class="detail detail-porte large-6 medium-6 small-6 cell">
    											<%=dtVeicolo.Rows[0]["Veicoli_NumeroPorte"].ToString().Trim()%>
    										</div>
    										<% } %>
    										<%if (dtVeicolo.Rows[0]["Veicoli_TipoCambio"].ToString().Trim().Length>0){ %>
    										<div class="detail detail-cambio large-12 medium-12 small-12 cell">
    											<%=dtVeicolo.Rows[0]["VeicoliCambio_Descrizione"].ToString()%>
    											<%if (dtVeicolo.Rows[0]["Veicoli_NumeroMarce"].ToString().Trim().Length>0){ %>
    											 <%=dtVeicolo.Rows[0]["Veicoli_NumeroMarce"].ToString()%> Marce
    											<% } %>
    										</div>
    										<% } %>
    									</div>
    									<br>
    									<div class="hgroup text-center">
    										<h4>Informazioni <span class="grassetto">Tecniche</span></h4>
    										<span class="linea-divisoria"><span></span></span>
    									</div>
    									<table class="tableelenco hover">
    										<tbody>
    											<%if (dtVeicolo.Rows[0]["VeicoliNormativeEuro_Descrizione"].ToString().Trim().Length>0){ %>
    											<tr>
    												<td>Normativa:</td>
    												<td class="text-left">
    													<strong><%=dtVeicolo.Rows[0]["VeicoliNormativeEuro_Descrizione"].ToString().Trim()%></strong>
    												</td>
    											</tr>
    											<% } %>
                          
    											<%if (dtVeicolo.Rows[0]["Veicoli_EmissioniCO2"].ToString().Trim().Length>0){ %>
    											<tr>
    												<td>Emissioni di CO2:</td>
    												<td class="text-left">
    													<strong><%=dtVeicolo.Rows[0]["Veicoli_EmissioniCO2"].ToString().Trim()%>g CO2/km (comb.)</strong>
    												</td>
    											</tr>
    											<% } %>
    											<%if (dtVeicolo.Rows[0]["Veicoli_ConsumoUrbano"].ToString().Trim().Length>0){ %>
    											<tr>
    												<td>Consumo urbano:</td>
    												<td class="text-left">
    													<strong><%=dtVeicolo.Rows[0]["Veicoli_ConsumoUrbano"].ToString().Trim()%> l/100 km</strong>
    												</td>
    											</tr>
    											<% } %>
    											<%if (dtVeicolo.Rows[0]["Veicoli_ConsumoExtraUrbano"].ToString().Trim().Length>0){ %>
    											<tr>
    												<td>Consumo extra:</td>
    												<td class="text-left">
    													<strong><%=dtVeicolo.Rows[0]["Veicoli_ConsumoExtraUrbano"].ToString().Trim()%> l/100 km</strong>
    												</td>
    											</tr>
    											<% } %>
    											<%if (dtVeicolo.Rows[0]["Veicoli_ConsumoCombinato"].ToString().Trim().Length>0){ %>
    											<tr>
    												<td>Consumo combinato:</td>
    												<td class="text-left">
    													<strong><%=dtVeicolo.Rows[0]["Veicoli_ConsumoCombinato"].ToString().Trim()%> l/100 km</strong>
    												</td>
    											</tr>
    											<% } %>
    											<%if (dtVeicolo.Rows[0]["Veicoli_CV"].ToString().Trim().Length>0){ %>
    											<tr>
    												<td>Potenza in CV/KW:</td>
    												<td class="text-left">
    													<strong><%=dtVeicolo.Rows[0]["Veicoli_CV"].ToString()%>/<%=dtVeicolo.Rows[0]["Veicoli_CVKW"].ToString().Trim()%></strong>
    												</td>
    											</tr>
    											<% } %>
    											<%if (dtVeicolo.Rows[0]["Veicoli_Trazione"].ToString().Trim().Length>0){ %>
    											<tr>
    												<td>Trazione:</td>
    												<td class="text-left"><strong><%=dtVeicolo.Rows[0]["Veicoli_Trazione"].ToString().Trim()%></strong>
    												</td>
    											</tr>
    											<% } %>
    											<%if (dtVeicolo.Rows[0]["Veicoli_Cilindrata"].ToString().Trim().Length>0){ %>
    											<tr>
    												<td>Cilindrata:</td>
    												<td class="text-left">
    													<strong><%=dtVeicolo.Rows[0]["Veicoli_Cilindrata"].ToString().Trim()%></strong></td>
    											</tr>
    											<% } %>
    											<%if (dtVeicolo.Rows[0]["Veicoli_Riferimento"].ToString().Trim().Length>0){ %>
    											<tr>
    												<td>Codice Veicolo:</td>
    												<td class="text-left <%=dtVeicolo.Rows[0]["Veicoli_Targa"].ToString().Trim()%>">
    													<strong><%=dtVeicolo.Rows[0]["Veicoli_Riferimento"].ToString().Trim()%></strong></td>
    											</tr>
    											<% } %>
    											<%if (dtVeicolo.Rows[0]["Veicoli_Carrozzeria"].ToString().Trim().Length>0 && dtVeicolo.Rows[0]["Veicoli_Carrozzeria"].ToString()!="Altro"){ %>
    											<tr>
    												<td>Tipo carrozzeria:</td>
    												<td class="text-left"><strong><%=dtVeicolo.Rows[0]["Veicoli_Carrozzeria"].ToString()%></strong></td>
    											</tr>
    											<% } %>
    											<%if (dtVeicolo.Rows[0]["VeicoliColore_Descrizione"].ToString().Trim().Length>0){ %>
    											<tr>
    												<td>Colore:</td>
    												<td class="text-left">
    													<strong><%=dtVeicolo.Rows[0]["VeicoliColore_Descrizione"].ToString().Trim()%></strong></td>
    											</tr>
    											<% } %>
    										</tbody>
    									</table>
                    </div>
                  </div>
							</div>

							<!--#include file="scheda-auto-optionals.aspx"-->
						</div>
						<div class="large-4 medium-4 small-12 cell">
							<!--#include file="scheda-auto-sidebar.aspx"-->
						</div>
					</div>
				</div>
		</div>
	
		<!--#include file="scheda-auto-contatti.aspx"-->
			
			<% if (strDipendentifca==null && strDipendentifca!="1"){ %>
			<% if (dtVeicoli.Rows.Count>0){ %>
			<div class="grid-x grid-padding-x"> 
				<div class="large-12 medium-12 small-12 cell primary-column elenco-auto" id="annunci">
					<h2>Offerte per <%=dtVeicolo.Rows[0]["VeicoliMarcaSpazioGroup_Marca"].ToString()%> <%=dtVeicolo.Rows[0]["VeicoliModelloSpazioGroup_Modello"].ToString()%></h2>
					<ul class="small-block-grid-1 medium-block-grid-4 large-block-grid-4" data-equalizer>
						<% for (i = 0; i < dtVeicoli.Rows.Count; i++){
							strScheda=GetUrlScheda(dtVeicoli);
							strAlt=dtVeicoli.Rows[i]["VeicoliMarcaSpazioGroup_Marca"].ToString().Trim() + " " + dtVeicoli.Rows[i]["VeicoliModelloSpazioGroup_Modello"].ToString().Trim();
							strAlt+=" " + dtVeicoli.Rows[i]["VeicoliCategoria_DescrizioneWEB"].ToString() + " a " + dtVeicoli.Rows[i]["Comuni_Comune"].ToString();
							if (dtVeicoli.Rows[i]["Veicoli_Foto1s"].ToString().Trim().Length>0){
							strImg=dtVeicoli.Rows[i]["Veicoli_Foto1s"].ToString().Trim();
							}else{
							strImg="https://cdn.spaziogroup.com/spazio2016/img/placeholder-350x263.png";
							}
						%>
						
						<li class="wow fadeInUp <% if (i+1==dtVeicoli.Rows.Count){ Response.Write ("end");}%>">
							<div class="panelofferta">
								<div class="brand-<%=dtVeicoli.Rows[i]["VeicoliMarca_Descrizione"].ToString().Trim()%>"></div>
								<div class="imgscheda" style="background-image:url(<%=strImg%>);">
									<a href="<%=strScheda%>" title="<%=strAlt%>">
										<img src="<%=strImg%>" style="visibility: hidden;" alt="<%=strAlt%>" class="lazyload" loading="lazy"/>
									</a>
								</div>
								<div class="panelrosso">
								    <%
										if ((dtVeicoli.Rows[i]["Veicoli_ImportazioneRiferimento"].ToString().Trim()=="823273")){
										Response.Write("Abarth 695 Tributo Ferrari");
										}
										else{ 
										Response.Write(dtVeicoli.Rows[i]["Veicoli_Allestimento"].ToString().Trim());
										}                        
									%>
								</div>
								<div class="large-12 medium-12 small-12 panelinfoofferta">
									<table class="tableelenco">
										<tbody>
											<tr>
												<td class="text-left">Immatricolaz.</td>
												<td class="text-left"><%=dtVeicoli.Rows[i]["Veicoli_DataPrimaImmatricolazione"].ToString()%></td>
											</tr>
											<tr>
												<td class="text-left">Km</td>
												<td class="text-left"><%=dtVeicoli.Rows[i]["Veicoli_KM"].ToString()%></td>
											</tr>
											<tr>
												<td class="text-left">Carburante</td>
												<td class="text-left"> <%=dtVeicoli.Rows[i]["VeicoliCarburante_Descrizione"].ToString().Trim()%> </td>
											</tr>
											<tr>
												<td>Prezzo</td>
												<td class="text-left azzurro"><span class="prezzo"><%
													if ((dtVeicoli.Rows[i]["Veicoli_ValoreNascondi"].Equals(true)) || (dtVeicoli.Rows[i]["Veicoli_Valore"].Equals(null))){
													Response.Write("Trattativa riservata");
													}
													else{ 
													Response.Write("&euro; " + ((decimal)dtVeicoli.Rows[i]["Veicoli_Valore"]).ToString("N0", ci));
													}                        
												%></span></td>
											</tr>
										</tbody>
									</table>
								</div>
								<a href="<%=strScheda%>" title="<%=strAlt%>" class="button expanded small scheda">SCHEDA ANNUNCIO <i class="fa-duotone fa-angle-right fa-fw"></i></a>
							</div>
						</li>
						
						<% } %>
					</ul>
					<asp:Label ID="PaginaSotto" runat="server" class="grid-x grid-padding-x"></asp:Label>
				</div>
			</div>
			<% } %>
			<% } %>
		</div>
		<%if (Request["inviato"]=="inviato"){ %>
			<script>jQuery('#messaggioinviato').foundation('open');</script>
		<% } %>

  	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
  	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
	</body>
</html>