<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/frontend/base/aste/elenco-aste.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" dir="ltr" lang="it-IT">
  <head>
   	<title>Aste</title>
  	<meta name="description" content="Home"/>
		<meta name="robots" content="index,follow">
  	<!-- #include file ="/frontend/base/inc-head.aspx" -->
  </head>
  <body>
  	<!-- #include file ="/frontend/base/inc-header.aspx" -->
    <div class="grid-container">
        <div class="grid-x grid-padding-x">
         	<aside class="large-3 medium-4 small-12 cell hide-for-small-only"> 
		  	     <!-- #include file ="/frontend/base/aste/inc-elenco-aste-sidebar.inc" -->
          </aside> 
          <main class="large-9 medium-8 small-12 cell">
            <h1>Elenco Aste on line</h1>
            <hr>
          	<!-- #include file ="/frontend/base/aste/inc-elenco-aste.inc" -->
          </main>
        </div>
        <% if (dtAsteEsperimenti.Rows.Count>10){ %>  
            <div class="grid-x grid-padding-x">
            	<div class="large-12 medium-12 small-12 cell text-center">
                	<a href="elenco-aste.aspx" class="button warning radius">VEDI ALTRE ASTE IN SCADENZA <i class="fa-duotone fa-plus fa-lw"></i></a>
                </div>
            </div> 
        <% } %>
    </div>
  	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
  	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
  </body>
</html>
