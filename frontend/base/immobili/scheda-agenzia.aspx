<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="scheda-agenzia.aspx.cs" Inherits="_Default" Debug="true"%>
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
  <body>
  <!--#include file="/frontend/base/inc-tagmanager.aspx"-->
  <!--#include file="/frontend/base/inc-header.aspx"-->
  <div class="grid-x grid-padding-x" id="corpoannunciimmobiliari">
  <div class="large-8 medium-8 small-12 cell" id="corposcheda">
    <div id="scheda">
      <ul class="breadcrumbs" id="breadcrumb" itemscope itemtype="https://schema.org/BreadcrumbList">
        <li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem">
            <a href="/" title="Case, vendita e affitto appartamenti, annunci immobiliari, villette, rustici e uffici" itemprop="url" class="breadcrumb"><span itemprop="name">Annunci Immobiliari</span></a>
            <meta itemprop="position" content="1" />
        </li>
        <li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem">
          <a href="/<%=dtUtente.Rows[0]["Province_ProvinciaHTML"].ToString().ToLower()%>/agenzie-immobiliari-provincia-<%=dtUtente.Rows[0]["Province_ProvinciaHTML"].ToString().ToLower()%>.html" title="agenzie immobiliari a <%=dtUtente.Rows[0]["Province_Provincia"].ToString().ToLower()%>" itemprop="url" class="breadcrumb"><span itemprop="name"><%=dtUtente.Rows[0]["Province_Provincia"].ToString().ToLower()%></span></a>
          <meta itemprop="position" content="2" />
        </li>
        <li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem">
          <a href="/<%=dtUtente.Rows[0]["Province_ProvinciaHTML"].ToString().ToLower()%>/agenzie-immobiliari-<%=dtUtente.Rows[0]["Comuni_ComuneHTML"].ToString().ToLower()%>.html" title="agenzie immobiliari a <%=dtUtente.Rows[0]["Comuni_Comune"].ToString().ToLower()%>" itemprop="url" class="breadcrumb"><span itemprop="name"><%=dtUtente.Rows[0]["Comuni_Comune"].ToString().ToLower()%></span></a>
          <meta itemprop="position" content="3" />
        </li>
        <li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem">
          <span itemprop="name"><%=dtUtente.Rows[0]["Utenti_Nominativo"].ToString()%></span>
          <meta itemprop="position" content="4" />
        </li>
      </ul>
      <main class="card">
        <div class="card-section">
          <div class="contattaagenzia" itemscope itemtype="https://schema.org/Organization"></div>
          <h1 itemprop="name"><%=dtUtente.Rows[0]["Utenti_Nominativo"].ToString().Trim()%></h1>
          <span itemprop="address" itemscope itemtype="https://schema.org/PostalAddress">
            <span itemprop="streetAddress"><i class="fa-duotone fa-map-marker-alt fa-fw"></i><%=dtUtente.Rows[0]["Utenti_Indirizzo"].ToString().Trim()%></span>
            <span itemprop="addressLocality"><%=dtUtente.Rows[0]["Comuni_Comune"].ToString().Trim()%></span>
            <span itemprop="addressRegion"><%=dtUtente.Rows[0]["Province_Provincia"].ToString().Trim()%></span>
          </span>
          <i class="fa-duotone fa-phone fa-fw"></i><%=dtUtente.Rows[0]["Utenti_Telefono1"].ToString()%><br>
          <%if (dtUtente.Rows[0]["Utenti_Logo"].ToString().Trim().Length>0){%>
          <img src="<%=dtUtente.Rows[0]["Utenti_Logo"].ToString().Trim()%>" itemprop="image" width="60" border="0" align="left"
            alt="<%=dtUtente.Rows[0]["Utenti_Nominativo"].ToString()%>" />
          <%}%>
          <hr>
          <h2>Contatta l'agenzia</h2>
          <form action="/form/form-contatti-immobile.aspx" name="contattavenditore" id="contattavenditore" method="post" data-abide>
            <div class="input-group">
              <span class="input-group-label">Il tuo nome:&nbsp;</span>
              <input type="text" name="nome" id="nome" class="input-group-field" required="required" />
            </div>
            <div class="input-group">
              <span class="input-group-label">Email:&nbsp;</span>
              <input type="text" name="email" id="email" class="input-group-field" required="required" />
            </div>
            <div class="input-group">
              <span class="input-group-label">Telefono:&nbsp;</span>
              <input type="text" name="telefono" id="telefono" class="input-group-field" required="required" />
            </div>
            <div class="input-group">
              <span class="input-group-label">Richiesta:&nbsp;</span>
              <input type="text" name="messaggio" id="messaggio" class="input-group-field" />
            </div>
            <div class="input-group">
              <input type="checkbox" name="privacy" id="privacy" checked="checked" value="si" required="required" /> Acconsento al trattamento dati
              (<a href="/pag/condizioni-del-servizio.html#privacy" target="_blank" rel="nofollow" class="pulsantescheda">info</a>)
              <input type="hidden" name="Utenti_Ky" id="Utenti_Ky" value="<%=dtUtente.Rows[0]["Utenti_Ky"].ToString()%>" />
              <input type="submit" name="invia" id="invia" value="Contatta il venditore" class="button large success" />
            </div>
          </form>
        </div>
        </main>
                

        <div class="ads-lista">
          <!--#include file="/frontend/base/inc-adsense.aspx"-->
        </div>


    </div>
    </div>
    <aside class="large-4 medium-4 small-12 cell sidebar" id="colonnadx">
			<!--#include file="/frontend/base/inc-adsense.aspx"-->
    </aside>    
  </div>
  <!--#include file="/frontend/base/inc-footer.aspx"-->
  </body>
</html>
