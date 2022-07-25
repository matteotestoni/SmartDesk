<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="elenco-immobili.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it-IT">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title><%=strTitle%></title>
	<meta property="og:title" content="<%=strTitle%>" />
	<meta name="description" content="<%=strMetaDescription%>" />
	<meta name="og:description" content="<%=strMetaDescription%>" />
	<meta name="robots" content="<%=strMetaRobots%>" />
	<% if (strCanonical.Length>0){ %>
	<link rel="canonical" href="<%=strCanonical%>" />
	<% } %>
	<!--#include file="/frontend/base/inc-head.aspx"-->
</head>
<body itemtype="https://schema.org/SearchResultsPage" itemscope>
	<!--#include file="/frontend/base/inc-tagmanager.aspx"-->
	<!--#include file="/frontend/base/inc-header.aspx"-->
	<div class="grid-container">

  	<div class="grid-x grid-padding-x">
  		<div class="large-9 medium-9 small-12 cell" id="annunci">
  			<nav aria-label="Sei in:" role="navigation">
  				<ul class="breadcrumbs" id="breadcrumb" itemscope itemtype="https://schema.org/BreadcrumbList">
  					<li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem">
  						<a href="/" itemtype="https://schema.org/Thing" itemprop="item" title="Case, vendita e affitto appartamenti, annunci immobiliari, villette, rustici e uffici">
  							<span itemprop="name">Home</span>
  						</a>
  						<meta itemprop="position" content="1" />
  					</li>
  					<% if (strComuni_Ky!=null && strComuni_Ky.Length>0){ %>
  					<li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem">
  						<a href="/immobili/<%=strNomeProvinciaHTML%>/vendita-case-provincia-<%=strNomeProvinciaHTML%>.html" itemtype="https://schema.org/Thing" itemprop="item" title="case <%=strNomeProvinciaHTML%>">
  							<span itemprop="name"><%=strNomeProvinciaHTML%></span>
  						</a>
  						<meta itemprop="position" content="2" />
  					</li>
  					<li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem">
  						<span itemprop="name">
  						<%=strNomeComune%>&nbsp; <%=intNumRecords%> annunci immobiliari
  						</span>
  						<meta itemprop="position" content="3" />
  					</li>
  					<% }else{ %>
  					<li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem">
  						<span itemprop="name">
  							<%=strNomeProvincia%>&nbsp; <%=intNumRecords%> annunci immobiliari
  						</span>
  						<meta itemprop="position" content="2" />
  					</li>
  					<% } %>
  				</ul>
  			</nav>
  
        <div class="grid-x grid-padding-x">
      		<div class="large-12 medium-12 small-12 cell">
      			<h1 itemprop="name"><%=strH1%></h1>
            <hr>
      			<p itemprop="description">
      				<%=strP1%>
      			</p>
      		</div>
      	</div>

  			<%
          if (intNumRecords>0){ %>
  			<%
            for (i = 0; i < intRecxPag; i++){
              if (i < dtImmobili.Rows.Count){
                if ((i==5 || i==9 || i==15 || i==20 || i==30)){ %>
  				<div class="ads-lista">
  					<!--#include file="/frontend/base/inc-adsense.aspx"-->
  				</div>
  			 <% 
                }
                strScheda="/immobile/" + dtImmobili.Rows[i]["Immobili_Ky"].ToString().Trim() + ".html";
                strAlt=dtImmobili.Rows[i]["ImmobiliTipologia_Descrizione"].ToString().Trim() + " " + dtImmobili.Rows[i]["ImmobiliSottotipologia_Descrizione"].ToString().Trim() + " in " + dtImmobili.Rows[i]["ImmobiliCategoria_Descrizione"].ToString().Trim() + " a " + dtImmobili.Rows[i]["Comuni_Comune"].ToString() + " " + dtImmobili.Rows[i]["ImmobiliZona_Descrizione"].ToString().Trim();
                %>
  			<article class="card immobile radius" itemscope itemtype="https://schema.org/Product">
  				<meta itemprop="brand" content="smartannunci" />
  				<div class="grid-x grid-padding-x">
  				<div class="large-4 medium-5 small-12 cell" itemprop="image" style="background-image:url(<%=dtImmobili.Rows[i]["Immobili_Foto1"].ToString().Trim()%>);background-size:cover;background-repeat:no-repeat;">
  						<a href="<%=strScheda%>" title="<%=strAlt%>" class="thumb" itemprop="url">
              <%
              if (dtImmobili.Rows[i]["Immobili_Foto1"].ToString().Length>0){
              %>
              <img src="<%=dtImmobili.Rows[i]["Immobili_Foto1"].ToString()%>" alt="<%=dtImmobili.Rows[i]["Immobili_Foto1"].ToString()%>" border="0" />
              <% }else{ %>
              <img src="https://via.placeholder.com/400x300.webp?text=nessun+immagine" alt="<%=strAlt%>" border="0" width="300" height="150" style="width:300px;height:150px" />
              <% } %>
              </a>
          </div>
          <div class="large-8 medium-7 small-12 cell">
  					<div class="listingcontent">
  						<div class="grid-x grid-padding-x">
  							<div class="large-9 medium-7 small-12 cell">
  								<h3 itemprop="name"><a href="<%=strScheda%>" title="<%=strAlt%>" class="h3annuncio" itemprop="url">
  									<%=strAlt%></a>
  								</h3>
  								<div itemprop="availableAtOrFrom" itemscope itemtype="https://schema.org/Place">
  									<div itemprop="address" itemscope itemtype="https://schema.org/PostalAddress" class="location">
  										<span itemprop="addressLocality" class="locality"><i class="fa-duotone fa-map-marker-alt fa-fw"></i><%=dtImmobili.Rows[i]["Comuni_Comune"].ToString()%></span>
  										<% if (!(dtImmobili.Rows[i]["Immobili_IndirizzoNascondi"].Equals(true)) && dtImmobili.Rows[i]["Immobili_Indirizzo"].ToString().Length>0){
  									Response.Write("<span itemprop=\"streetAddress\" class=\"street-address\">" + dtImmobili.Rows[i]["Immobili_Indirizzo"].ToString() + "</span>");
  									}%>
  									</div>
  								</div>
  								<div itemprop="offers" itemscope itemtype="https://schema.org/Offer">
  								<link itemprop="availability" href="https://schema.org/InStock" />
  								<%
  								if ((dtImmobili.Rows[i]["Immobili_ValoreNascondi"].Equals(true)) || (dtImmobili.Rows[i]["Immobili_Valore"].Equals(null))){
  									Response.Write("<div class=\"trattris\">Tratt. riservata</div>");
  									Response.Write("<meta itemprop=\"price\" content=\"0\" />");
  								}
  								else{ 
  									if (dtImmobili.Rows[i]["Immobili_Valore"]!=System.DBNull.Value){
  										Response.Write("<div class=\"price\" ><span itemprop=\"priceCurrency\" content=\"EUR\">&euro;</span> <span itemprop=\"price\"> " + ((decimal)dtImmobili.Rows[i]["Immobili_Valore"]).ToString("N0", ci) + "</span></div>");
  									}else{
  											Response.Write("<div class=\"price\">Trattativa Riservata</div>");
  											Response.Write("<meta itemprop=\"price\" content=\"0\" />");
  											Response.Write("<meta itemprop=\"priceCurrency\" content=\"EUR\" />");
  									}
  								}                        
  								%>	
  								</div>
  							</div>
  							<div class="large-3 medium-5 small-12 cell">
  								<div itemprop="seller" itemscope itemtype="https://schema.org/RealEstateAgent">
  									<% if (dtImmobili.Rows[i]["Utenti_Logo"].ToString().Trim().Length>0){ %>
  									<img src="<%=dtImmobili.Rows[i]["Utenti_Logo"].ToString().Trim()%>" itemprop="image" height="100" style="max-height:100px;border:0;" alt="<%=dtImmobili.Rows[i]["Utenti_Nominativo"].ToString()%>" />
  									<meta itemprop="name" content="<%=dtImmobili.Rows[i]["Utenti_Nominativo"].ToString()%>" />
  									<% }else{ %>
  										<div class="boxvenditore">
  											<span itemprop="name"><%=dtImmobili.Rows[i]["Utenti_Nominativo"].ToString()%></span>
  										</div>
  									<% } %>
  								</div>
  							</div>
  						</div>
  
  
  						
  						<ul class="menu">
  							<%
  							if (dtImmobili.Rows[i]["Immobili_NumeroLocali"].ToString()!="0"){
  								Response.Write("<li><span class=\"label secondary transparent\">" + dtImmobili.Rows[i]["Immobili_NumeroLocali"].ToString().Replace(",0000","") + " locali</span></li>");
  							}
  							if (dtImmobili.Rows[i]["Immobili_Mq"].ToString()!="0"){
  								Response.Write("<li><span class=\"label secondary transparent\">" + dtImmobili.Rows[i]["Immobili_Mq"].ToString().Replace(",0000","") + " m&sup2;</span></li>");
  							}
  							if (dtImmobili.Rows[i]["Immobili_NumeroCamereLetto"].ToString()!=null && dtImmobili.Rows[i]["Immobili_NumeroCamereLetto"].ToString().Trim().Length>0 && dtImmobili.Rows[i]["Immobili_NumeroCamereLetto"].ToString()!="0"){
  								Response.Write("<li><span class=\"label secondary transparent\"><i class=\"fa-duotone fa-bed fa-fw\" style=\"--fa-secondary-color: #85b500;\"></i>&nbsp;" + dtImmobili.Rows[i]["Immobili_NumeroCamereLetto"].ToString() + " letti</span></li>");
  							}
  							if (dtImmobili.Rows[i]["Immobili_NumeroBagni"].ToString()!=null && dtImmobili.Rows[i]["Immobili_NumeroBagni"].ToString()!="0"){
  								Response.Write("<li><span class=\"label secondary transparent\"><i class=\"fa-duotone fa-bath fa-fw\" style=\"--fa-primary-color: #85b500;\"></i>&nbsp;" + dtImmobili.Rows[i]["Immobili_NumeroBagni"].ToString() + " bagni</span></li>");
  							}
  							if (dtImmobili.Rows[i]["Immobili_NumeroPostiAuto"].ToString()!=null && dtImmobili.Rows[i]["Immobili_NumeroPostiAuto"].ToString()!="0" && dtImmobili.Rows[i]["Immobili_NumeroPostiAuto"].ToString()!=""){
  								Response.Write("<li><span class=\"label secondary transparent\"><i class=\"fa-duotone fa-car fa-fw\" style=\"--fa-primary-color: #85b500;\"></i>&nbsp;" + dtImmobili.Rows[i]["Immobili_NumeroPostiAuto"].ToString() + " posti auto</span></li>");
  							}
  							if (dtImmobili.Rows[i]["Immobili_ClasseEnergetica"].ToString()!=""){
  								Response.Write("<li><span class=\"label secondary transparent\"><i class=\"fa-duotone fa-leaf fa-fw\" style=\"--fa-primary-color: #85b500;\"></i>&nbsp;Classe energetica:&nbsp;" + dtImmobili.Rows[i]["Immobili_ClasseEnergetica"].ToString());
  								if (dtImmobili.Rows[i]["Immobili_Ipe"].ToString()!=""){
  								Response.Write(" - ipe: " + dtImmobili.Rows[i]["Immobili_Ipe"].ToString());
  								}
  								Response.Write("</span></li>");
  							}
  							%>
  						</ul>										
  						<div class="testoannuncio" itemprop="description">
  							<%
  								Response.Write(getAnnuncio(dtImmobili.Rows[i]["Immobili_Annuncio"].ToString().ToLower().Trim(),dtImmobili.Rows[i]["Comuni_Comune"].ToString(),dtImmobili.Rows[i]["ImmobiliTipologia_Descrizione"].ToString().ToLower()));
  							%>
  						</div>
  						<div class="grid-x">
  							<div class="large-8 medium-8 small-12 cell">
  								<div class="riferimento">
  									rif. <span itemprop="productID"><%=dtImmobili.Rows[i]["Immobili_Ky"].ToString()%></span> - rif. agenzia <span itemprop="sku"><%=dtImmobili.Rows[i]["Immobili_Riferimento"].ToString()%></span>
  								</div>
  							</div>
  							<div class="large-4 medium-4 small-12 cell">
  								<a href="<%=strScheda%>" title="<%=strAlt%>" class="button small success expanded">Scheda annuncio <i class="fa-duotone fa-angle-right fa-fw"></i></a>
  							</div>
  							
  						</div>
  					</div> 	
  					</div>
  				</div>
  			</article>
  			<%
               } 
              }%>
  			<%                  
          }else{ %>
  			<div class="boxtesto">
  				<i class="fa-duotone fa-info-circle fa-fw"></i>Nessun annuncio di <strong><%=strH1%></strong> trovato.
  			</div>
  			<font color="#00b02c"><strong>Consigli:</strong></font><br />
  			<font color="#000000">
  				<ul>
  					<li>Cambia localit&agrave;</li>
  					<li>Prova a cercare tutte le case della localit&agrave; di <%=strNomeComune%>;</li>
  					<li>Prova a iniziare dalla home page che ti guider&agrave; a visualizzare case di
  						<%=strNomeProvincia%> <%=strNomeComune%> per affitti <%=strNomeComune%>, vendita case <%=strNomeProvincia%>  <%=strNomeComune%>,
  						locazioni <%=strNomeProvincia%> oppure attraverso una ricerca geografica pi&ugrave; generica;
  					</li>
  					<li>Esempi di chiavi di ricerca dove troverai sicuramente case sono "appartamenti
  						<%=strNomeProvincia%> <%=strNomeComune%>", "vendita appartamenti <%=strNomeComune%>", "affitto appartamenti
  						<%=strNomeProvincia%> <%=strNomeComune%>", "nuove costruzioni <%=strNomeComune%>";</li>
  					<li>Le tipologie pi&ugrave; cercate tra le case sono <strong>appartamenti <%=strNomeProvincia%></strong>,
  						<strong>monolocali <%=strNomeProvincia%> <%=strNomeComune%></strong>, <strong>bilocali <%=strNomeProvincia%></strong>,rustici
  						<%=strNomeProvincia%>,villette <%=strNomeProvincia%> <%=strNomeComune%>,<strong>case <%=strNomeProvincia%> <%=strNomeComune%></strong>,
  						<strong>uffici e negozi <%=strNomeProvincia%> <%=strNomeComune%></strong>, <strong>commerciali <%=strNomeProvincia%> <%=strNomeComune%></strong>,
  						<strong>affitti <%=strNomeProvincia%> <%=strNomeComune%></strong>.</li>
  				</ul>
  			</font>
  			<div class="ads-lista">
  				<!--#include file="/frontend/base/inc-adsense.aspx"-->
  			</div>
  			<div class="ads-lista">
  				<!--#include file="/frontend/base/inc-adsense.aspx"-->
  			</div>
  			<% } %>
          <asp:Label ID="PaginaSotto" runat="server" class="paginazione"></asp:Label>
      </div>
  	<aside class="large-3 medium-3 small-12 cell">
      	<div id="colonnadx" class="sidebar radius">
  			<!--#include file="/frontend/base/immobili/inc-sidericerca.aspx"-->
  			<br>	
  			<div class="linkseo">
  				<%
  				if (strComuni_Ky!=null && strComuni_Ky.Length>0){
  					Response.Write("<h5>Immobili a " + strNomeComune + "</h5>");
  					Response.Write(strComuniLink);
  				}else{
  					Response.Write("<h5>Immobili a " + strNomeProvincia + "</h5>");
  					Response.Write(strProvinciaLink);
  					Response.Write("<hr><h5>Cerco casa a:</h5>");
  					Response.Write("<ul class=\"no-bullet\">");
  					Response.WriteFile("/frontend/base/immobili/comuni/annunci-immobiliari/" + strNomeProvinciaHTML + ".htm");
  					Response.Write("</ul>");
  				}
  			%>		
  			</div>
  		</div>
  	</aside>
  	</div>
  
  
  	<div class="grid-x grid-padding-x">
  		<div class="large-12 medium-12 small-12 cell">
  				<%
  	      if (strComuni_Ky!=null && strComuni_Ky.Length>0){
  					Response.Write(strTitle);
  				}else{
  					Response.WriteFile("/frontend/base/immobili/descrizioneprovince/annunci-immobiliari/" + strNomeProvinciaHTML + ".htm");
  				}
  				%>
  		</div>
  	</div>
  </div>

	<!--#include file="/frontend/base/inc-footer.aspx"-->

</body>

</html>