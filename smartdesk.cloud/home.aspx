<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="_Default" Debug="true"%><!doctype html>
<html class="no-js" lang="it">
  <head>
    	<title><%=dtHome.Rows[0]["CMSContenuti_Title"].ToString()%></title>
    	<meta name="description" content="<%=dtHome.Rows[0]["CMSContenuti_Description"].ToString()%>"/>
  		<meta name="robots" content="<%=dtHome.Rows[0]["CMSContenuti_Robots"].ToString()%>">
	     <!-- #include file ="/frontend/base/inc-head.aspx" -->
  </head>
  <body>
  <% Response.WriteFile("/frontend/" + strTheme + "/inc-header.aspx"); %>          
	<!-- #include file ="/frontend/base/contenuti/slide/inc-slide-home.inc" -->
	<section class="aste-grid grid-container">
    <h2>Aste online in evidenza</h2>
    <!-- #include file ="/frontend/base/aste/inc-elenco-aste-home.inc" -->
  </section>
	<section class="annunci-grid grid-container">
  	<h2>Annunci online in evidenza</h2>
  	<!-- #include file ="/frontend/base/annunci/inc-elenco-annunci.inc" -->
  </section>
	<section class="prodotti-grid grid-container">
  	<h2>Prodotti in evidenza</h2>
  	<!-- #include file ="/frontend/base/catalogo/inc-elenco-prodotti.inc" -->
  </section>
  <% Response.WriteFile("/frontend/" + strTheme + "/inc-newsletter.aspx"); %>          
	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
  </body>
</html>

