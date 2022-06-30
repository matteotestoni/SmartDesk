<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/pagamenti/scheda-pagamenti.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Pagamenti > Scheda pagamento</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-pagamento" action="/admin/app/pagamenti/crud/salva-pagamento.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtPagamenti, "Pagamenti_Ky")%></span></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
      			<div class="stacked-for-small button-group small hide-for-print align-right">
      				<a href="/admin/app/pagamenti/elenco-pagamenti.aspx" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
      				<a href="/admin/app/pagamenti/scheda-pagamenti.aspx?azione=new&Anagrafiche_Ky=<%=strAnagrafiche_Ky%>&sorgente=scheda-pagamento" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a> 
              <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva il pagamento</button>
      			</div>
  	      </div>
      </div>
  </div>
</div>

  <div class="grid-x grid-padding-x">
    <div class="large-12 medium-12 small-12 cell">
      <div class="divform">
        <input type="hidden" name="sorgente" id="sorgente" value="<%=strSorgente%>">
        <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
        <input type="hidden" name="Spese_Ky" id="Spese_Ky" value="<%=GetFieldValue(dtPagamenti, "Spese_Ky")%>">
        <input type="hidden" name="Pagamenti_Ky" id="Pagamenti_Ky" value="<%=GetFieldValue(dtPagamenti, "Pagamenti_Ky")%>">
        <!--#include file=/admin/forms_messaggi.inc -->
  	 		<!--#include file=/admin/app/pagamenti/forms/pagamenti_form.htm -->
      </div>
    </div>
  </div>
</form>

<!--#include file=/admin/app/pagamenti/scheda-pagamento-attivita.inc -->

<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
