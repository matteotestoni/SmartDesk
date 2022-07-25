<%@ Page ResponseEncoding="utf-8" Language="C#" AutoEventWireup="true" CodeFile="scheda-contenuti.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" dir="ltr" lang="it-IT">
  <head>
  	<title><%=dtCMSContenuti.Rows[0]["CMSContenuti_Title"].ToString()%></title>
  	<meta name="description" content="<%=dtCMSContenuti.Rows[0]["CMSContenuti_Description"].ToString()%>">
  	<meta name="robots" content="<%=dtCMSContenuti.Rows[0]["CMSContenuti_Robots"].ToString()%>">
  	<!-- #include file ="/frontend/base/inc-head.aspx" -->
  </head>
  <body>
 	<!-- #include file ="/frontend/base/inc-header.aspx" -->
		<div class="grid-container">
      		<div class="grid-x grid-padding-x">
					<div class="large-9 medium-9 small-12 cell">
						<main>
						  <h1><%=dtCMSContenuti.Rows[0]["CMSContenuti_Titolo"].ToString()%></h1>
						  <%=dtCMSContenuti.Rows[0]["CMSContenuti_Contenuto"].ToString()%>
						</main>
					</div>  
					<aside class="large-3 medium-3 small-12 cell sidebar">
						<br>
						<h4 class="title">Informazioni generali</h4>	
						<ul class="menu vertical">
							<li><a href="/pag/chi-siamo.html">Chi siamo</a></li>
							<li><a href="/contatti/contatti.html" rel="nofollow">Contattaci</a></li>
							<li><a href="/pag/vendi-con-noi.html" rel="nofollow">Vendi con noi</a></li>
						</ul>
						<h4 class="title">Informazioni legali</h4>
						<ul class="menu vertical">
							<li><a href="/pag/condizioni-generali.html" rel="nofollow">Condizioni generali</a></li>
							<li><a href="/pag/condizioni-generali-banner.html" rel="nofollow">Condizioni generali banner</a></li>
							<li><a href="/pag/privacy-policy.html" rel="nofollow">Privacy</a></li>
							<li><a href="/pag/cookie-policy.html" rel="nofollow">Cookies</a></li>
						</ul>								
					</aside> 					              
			</div>
		</div>
  	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
  	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
  </body>
</html>
