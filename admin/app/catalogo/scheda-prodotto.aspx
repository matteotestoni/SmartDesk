<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/catalogo/scheda-prodotto.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Catalogo > Scheda prodotto</title>
	<!--#include file="/admin/inc-head.aspx"-->
	<script src="//cdn.ckeditor.com/4.19.0/full/ckeditor.js"></script>
	<script src="/lib/jquery-ui/jquery.ui.widget.js"></script>
	<script src="/lib/jquery-file-upload/js/jquery.iframe-transport.js"></script>
	<script src="/lib/jquery-file-upload/js/jquery.fileupload.js"></script>	

	<script src="/lib/plupload2/js/plupload.full.min.js"></script>
	<script type="text/javascript" src="/lib/plupload2/js/i18n/it.js"></script>
	<script type="text/javascript" src="/lib/plupload2/js/jquery.ui.plupload/jquery.ui.plupload.js"></script>
	<link rel="stylesheet" href="/lib/plupload2/js/jquery.ui.plupload/css/jquery.ui.plupload.css" type="text/css" />

	<style>
	#gallery { float: left; width: 65%; min-height: 12em; } * html #gallery { height: 12em; } /* IE6 */
	.gallery.custom-state-active { background: #eee; }
	.gallery li { float: left; min-height:120px; ;width: 96px; padding: 0.4em; margin: 0 0.4em 0.4em 0; text-align: center; }
	.gallery li h5 { margin: 0 0 0.4em; }
	.gallery li img { }
	</style>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-prodotti" enctype="multipart/form-data" action="/admin/app/catalogo/crud/salva-prodotti.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-cube fa-lg fa-fw"></i>Scheda prodotto:<span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtProdotto, "Prodotti_Ky")%></span></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
        			<div class="stacked-for-small button-group small hide-for-print align-right">
        				<a href="/admin/app/catalogo/elenco-prodotti.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
        			  <a href="/admin/app/catalogo/crud/elimina-prodotto.aspx?azione=delete&Prodotti_Ky=<%=GetFieldValue(dtProdotto, "Prodotti_Ky")%>" class="button secondary" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i>Elimina</a>
        				<button class="button secondary" onclick="duplicaRecord('form-prodotti', 'Prodotti_Ky');"><i class="fa-duotone fa-clone fa-fw"></i>Duplica</button>
        				<a href="/admin/app/catalogo/scheda-prodotto.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
        				<button type="submit" value="salva" name="salva" class="button success" onclick="document.getElementById('form-prodotti').submit();"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
        			</div>	
  	      </div>
      </div>
  </div>
</div>

  <div class="grid-x grid-padding-x">
    <div class="large-12 medium-12 small-12 cell">
      <div class="divform">
        <!--#include file=/admin/forms_messaggi.inc -->
				<input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
				<input type="hidden" name="Prodotti_Ky" id="Prodotti_Ky" value="<%=GetFieldValue(dtProdotto, "Prodotti_Ky")%>">
				<input type="hidden" name="Utenti_Ky" id="Utenti_Ky" value="<%=Smartdesk.Session.CurrentUser.ToString()%>">
				<!--#include file=/admin/app/catalogo/forms/prodotti_form.htm -->
      </div>
  	</div>
  </div>
</form>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
