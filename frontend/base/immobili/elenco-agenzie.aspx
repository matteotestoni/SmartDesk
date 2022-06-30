<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="elenco-agenzie.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it-IT">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title><%=strTitle%></title>
  <meta property="og:title" content="<%=strTitle%>" />
	<meta name="description" content="<%=strMetaDescription%>" />
  <meta name="og:description" content="<%=strMetaDescription%>" />
	<meta name="robots" content="<%=strMetaRobots%>" />
	<!--#include file="/frontend/base/inc-head.aspx"-->
</head>
<body itemtype="https://schema.org/SearchResultsPage" itemscope>
	<!--#include file="/frontend/base/inc-tagmanager.aspx"-->
	<!--#include file="/frontend/base/inc-header.aspx"-->

  <div class="grid-x grid-padding-x">
    <div class="large-12 medium-12 small-12 cell">
       <h1 itemprop="name"><%=strH1%></h1>
    </div>
  </div>

  <div class="grid-x grid-padding-x" id="corpoannunciimmobiliari">
    <div class="large-9 medium-9 small-12 cell" id="annunci">
      <nav aria-label="Sei in:" role="navigation">
        <ul class="breadcrumbs" id="breadcrumb" itemscope itemtype="https://schema.org/BreadcrumbList">
          <li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem">
            <a href="/" itemtype="https://schema.org/Thing" itemprop="item" title="Case, vendita e affitto appartamenti, annunci immobiliari, villette, rustici e uffici">
              <span itemprop="name">Home</span>
            </a>
            <meta itemprop="position" content="1" />
          </li>
          <% if (strNomeComuneHTML!=null && strNomeComuneHTML.Length>0){ %>
          <li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem">
            <a href="/<%=strNomeProvinciaHTML%>/agenzie-immobiliari-provincia-<%=strNomeProvinciaHTML%>.html" itemtype="https://schema.org/Thing" itemprop="item" title="agenzie immobiliari <%=strNomeProvinciaHTML%>">
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
              <%=strNomeProvincia%>&nbsp; <%=intNumRecords%> agenzie immobiliari
            </span>
            <meta itemprop="position" content="2" />
          </li>
          <% } %>
        </ul>
      </nav>


        <%if (intNumRecords>0){
            for (i = 0; i < intRecxPag; i++){
              if (i < dtAgenzie.Rows.Count){
                strScheda="/scheda-agenzia.aspx?Utenti_Ky=" + dtAgenzie.Rows[i]["Utenti_Ky"].ToString();
                strAlt="agenzia immobiliare a " + dtAgenzie.Rows[i]["Comuni_Comune"].ToString().Trim();
                if ((i==5 || i==9 || i==15 || i==20 || i==30)){ %>
                  <div class="ads-lista">
			              <!--#include file="/frontend/base/inc-adsense.aspx"-->
                  </div>
                <%
                }%>
                <article class="annuncio" itemscope itemtype="https://schema.org/Organization">
                  <div class="grid-x grid-padding-x">
                      <div class="large-3 medium-3 small-12 cell">
                        <%if (dtAgenzie.Rows[i]["UtentiGruppi_Descrizione"].ToString().Trim().Length>0){%>
                          <div class="noFoto" itemprop="image" style="background-repeat:no-repeat;background-size:contain;background-image:url(<%=dtAgenzie.Rows[i]["Utenti_Logo"].ToString().Trim()%>);"></div>
                        <%}else{%>
                          <div class="noFoto" itemprop="image" style="background-repeat:no-repeat;background-size:contain;background-image:url(<%=dtAgenzie.Rows[i]["Utenti_Logo"].ToString().Trim()%>);"></div>
                        <%}%>
                      </div>
                      <div class="large-9 medium-9 small-12 cell">
                        <div class="listingcontent">
                          <h2 class="h3annuncio">
                            <a href="<%=strScheda%>" title="<%=strAlt%>" class="h2annuncio" rel="nofollow"><%=strAlt%><%if (dtAgenzie.Rows[i]["Comuni_Comune"].ToString().Trim()!=dtAgenzie.Rows[i]["Province_Provincia"].ToString().Trim()){Response.Write(" (" + dtAgenzie.Rows[i]["Province_Provincia"].ToString().Trim() + ")");}%></a>
                          </h2>
                            <div itemprop="name"><%=dtAgenzie.Rows[i]["Utenti_Nominativo"].ToString().Trim()%></div>
                            <span itemprop="address" itemscope itemtype="https://schema.org/PostalAddress">
                              <span itemprop="streetAddress"><i class="fa-duotone fa-map-marker-alt fa-fw"></i><%=dtAgenzie.Rows[i]["Utenti_Indirizzo"].ToString().Trim()%></span>, 
                              <span itemprop="addressLocality"><%=dtAgenzie.Rows[i]["Comuni_Comune"].ToString().Trim()%></span>, 
                              <span itemprop="addressRegion"><%=dtAgenzie.Rows[i]["Province_Provincia"].ToString().Trim()%></span>.
                            </span>
                          <%
                            if (dtAgenzie.Rows[i]["UtentiGruppi_Descrizione"].ToString().Trim().Length>0){
                              Response.Write("rif. " + dtAgenzie.Rows[i]["Utenti_Ky"].ToString().Trim() + " - " + dtAgenzie.Rows[i]["Utenti_CodiceGestionale"].ToString().Trim());
                            }
                          %>
                          <br style="clear:both;">
                          <a href="/elenco-immobili.aspx?page=1&Province_Ky=<%=dtAgenzie.Rows[i]["Province_Ky"].ToString().Trim()%>&Comuni_Ky=<%=dtAgenzie.Rows[i]["Comuni_Ky"].ToString().Trim()%>&Utenti_Ky=<%=dtAgenzie.Rows[i]["Utenti_Ky"].ToString().Trim()%>" title="<%=strAlt%>" class="button hollow tiny" rel="nofollow">Annunci immobiliari<i class="fa-duotone fa-arrow-right fa-fw"></i></a> 
                          <a href="/scheda-agenzia.aspx?Utenti_Ky=<%=dtAgenzie.Rows[i]["Utenti_Ky"].ToString().Trim()%>" title="<%=strAlt%>" class="button tiny" rel="nofollow">Contatta agenzia<i class="fa-duotone fa-arrow-right fa-fw"></i></a><br />
                        </div>
                      </div>
                    </div>
                </article>
                <%
               } 
              }
        }else{%>
              Nessuna agenzia immobiliare trovato.
              <font color="#00b02c"><strong>Consigli:</strong></font><br />
              <font color="#000000">
               <ul>
                <li>Cambia localit&agrave;</li>
                <li>Prova a cercare agenzie immobiliari della localit&agrave; di <%=strNomeProvincia%>;</li>
                <li>Prova a iniziare dalla home page che ti guider&agrave; a visualizzare agenzie immobiliari di <%=strNomeProvincia%>  oppure attraverso una ricerca geografica pi&ugrave; generica.</li>
                </ul>
              </font>
            <div class="annuncio" itemscope itemtype="https://schema.org/Organization">
			              <!--#include file="/frontend/base/inc-adsense.aspx"-->
            </div>

        <%}%>
        <asp:Label ID="PaginaSotto" runat="server" class="paginazione"></asp:Label>
    </div>
    <aside class="large-3 medium-3 small-12 cell sidebar" id="colonnadx">
			<!--#include file="/frontend/base/inc-adsense.aspx"-->
      <h4>Cerca agenzie immobiliari in provincia</h4>
		  <ul class="no-bullet">
		    <%Response.WriteFile("/contenuti/comuni/agenzie-immobiliari/" + strNomeProvinciaHTML + ".htm");%>
      </ul>
   
    </aside>
  </div>

	<!--#include file="/frontend/base/inc-footer.aspx"-->
  </body>
</html>
