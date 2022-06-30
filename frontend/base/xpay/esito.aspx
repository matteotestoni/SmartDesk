<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="esito.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html class="no-js" dir="ltr" lang="it-IT">
  <head>
		<title>Esito pagamento</title>
  	<!--#include file="/frontend/base/inc-head.aspx"--> 
  </head>
  <body>
  	<!-- #include file ="/frontend/base/inc-header.aspx" -->
	         <div class="grid-x grid-padding-x">
	          <div class="large-12 medium-12 small-12 cell">
              <h1>Esito pagamento</h1>
              <%
              if (strEsito=="OK"){%>
                <div class="callout success"><p>Il pagamento della cauzione &egrave; stato eseguito. Ora puoi procedere a fare un offerta al lotto interessato.</div>
              <% }else{ %>
                <div class="callout alert"><p>Il pagamento della cauzione NON &egrave; stato eseguito. Ritenta.</div>
              <% } %>
              <a href="/scheda-asta.aspx?AsteEsperimenti_Ky=<%=strAsteEsperimenti_Ky%>&Aste_Ky=<%=strAste_Ky%>" class="button large warning">Vai alla scheda dell'asta <i class="fa fa-arrow-right fa-fw"></i></a>
              <hr>
              debug<br>
              <%
              foreach(string key in Request.QueryString.Keys ) 
              {
                 Response.Write (key + ":" + Request.QueryString[key] + "<br>");
              }              
              %>
	          </div>                
         	</div>           
          <p class="hide-for-small-only"><br><br></p> 
					<div class="js-off-canvas-exit"></div>
        </div> 
			</div>
  	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
  	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
  </body>
</html>
