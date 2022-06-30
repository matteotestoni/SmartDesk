<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/aste/scheda-aste.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Aste > Scheda asta</title>
	<!--#include file="/admin/inc-head.aspx"-->
	<script src="//cdn.ckeditor.com/4.19.0/full/ckeditor.js"></script>
	<script src="/lib/plupload2/js/plupload.full.min.js"></script>
	<script type="text/javascript" src="/lib/plupload2/js/i18n/it.js"></script>
	<script type="text/javascript" src="/lib/plupload2/js/jquery.ui.plupload/jquery.ui.plupload.js"></script>
	<link rel="stylesheet" href="/lib/plupload2/js/jquery.ui.plupload/css/jquery.ui.plupload.css" type="text/css" />
  <link type="text/css" rel="stylesheet" href="/lib/fancybox/jquery.fancybox.min.css" media="screen">
  <script type="text/javascript" src="/lib/fancybox/jquery.fancybox.min.js"></script>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-aste" enctype="multipart/form-data" action="/admin/app/aste/crud/salva-aste.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-gavel fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtAste, "Aste_Ky")%></span></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
			<div class="stacked-for-small button-group small hide-for-print align-right">
				<a href="/admin/view.aspx?CoreModules_Ky=5&CoreEntities_Ky=60&CoreGrids_Ky=50" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
  			    <% if (strAzione!="new"){ %>
				<a href="#" class="button secondary dropdown" data-toggle="dropdownsstampa"><i class="fa-duotone fa-print fa-fw"></i>Stampa</a>
				<div class="dropdown-pane" id="dropdownsstampa" data-dropdown data-hover="true" data-hover-pane="true">
				  <ul class="no-bullet">
  					<li><a href="/admin/app/aste/report/rpt-asta.aspx?Aste_Ky=<%=GetFieldValue(dtAste, "Aste_Ky")%>" target="_blank"><i class="fa-duotone fa-print fa-fw"></i>Stampa scheda</a></li>
  					<li><a href="/admin/app/aste/report/rpt-asta-catalogo.aspx?Aste_Ky=<%=GetFieldValue(dtAste, "Aste_Ky")%>" target="_blank"><i class="fa-duotone fa-print fa-fw"></i>Stampa catalogo</a></li>
  					<li><a href="/admin/app/aste/report/rpt-asta-verbale.aspx?Aste_Ky=<%=GetFieldValue(dtAste, "Aste_Ky")%>" target="_blank"><i class="fa-duotone fa-print fa-fw"></i>Stampa verbale asta</a></li>
  					<li><a href="/admin/app/aste/report/rpt-asta-cliente.aspx?Aste_Ky=<%=GetFieldValue(dtAste, "Aste_Ky")%>" target="_blank"><i class="fa-duotone fa-print fa-fw"></i>Stampa report cliente</a></li>
				  </ul>
				</div>
				<% } %>
				<a href="/admin/app/aste/scheda-aste.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
       <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
			</div>
  	      </div>
      </div>
  </div>
</div>

  <div class="grid-x grid-padding-x">
    <div class="large-12 medium-12 small-12 cell">
      <div class="divform">
        <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
        <input type="hidden" name="Aste_Ky" id="Aste_Ky" value="<%=GetFieldValue(dtAste, "Aste_Ky")%>">
        <!--#include file=/admin/forms_messaggi.inc -->
        <!--#include file=/admin/app/aste/forms/aste_form.htm -->
      </div>
    </div>
  </div>
</form>
<br>
<!--#include file=/admin/app/aste/scheda-aste-esperimenti.inc -->
<!--#include file=/admin/app/aste/scheda-aste-lotti.inc -->
<!--#include file=/admin/app/aste/scheda-aste-files.inc -->
<% if (strAzione!="new" && GetFieldValue(dtAste, "Aste_CommissioniTipo")=="1"){ %>
	<!--#include file=/admin/app/aste/scheda-aste-commissioni.inc -->
<% } %>
<% if (strAzione!="new" && GetFieldValue(dtAste, "AsteNatura_Ky")=="1"){ %>
	<!--#include file=/admin/app/aste/scheda-aste-cauzioni.inc -->
	<!--#include file=/admin/app/aste/scheda-aste-offerte.inc -->
	<!--#include file=/admin/app/aste/scheda-aste-proxybid.inc -->
<% } %>
<!--#include file=/admin/inc-footer.aspx -->
<script>
	jQuery("[data-fancybox]").fancybox({
  	thumbs : {
  		autoStart : true,
      infobar : true,
      lang : 'it'
  	}
  });
</script>
</body>
</html>
