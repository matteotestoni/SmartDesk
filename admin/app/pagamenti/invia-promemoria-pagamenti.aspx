<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="invia-promemoria-pagamenti.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Pagamenti > Invia promemoria pagamenti</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i><%=strH1%></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
      			<div class="stacked-for-small button-group small hide-for-print align-right">
      				<a href="/admin/app/pagamenti/elenco-pagamenti.aspx" class="button clear"><i class="fa-duotone fa-backward success fa-fw"></i> Torna all'elenco</a>
      			</div>
  	      </div>
      </div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
        <% 
        if (strAnteprima=="anteprima"){ 
          Response.Write(strHTML);
        }else{ %>
          <h2>Esito di invio per promemoria pagamenti futuri</h2>
    			<%=strRisultatoFuturi%>
        	<h2>Esito di invio per solleciti pagamenti scaduti</h2>
    			<%=strRisultatoScaduti%>
        <% } %>
  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
