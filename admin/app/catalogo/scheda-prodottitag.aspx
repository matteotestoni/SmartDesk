<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/catalogo/scheda-prodottitag.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>

<html class="no-js" lang="it">
<head>
	<title>Catalogo > Scheda tag</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx -->
<h1><i class="fa-duotone fa-tag fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtProdottiTag, "ProdottiTag_Ky")%></span></h1> 
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
		<form id="form-prodottitag" action="/admin/app/catalogo/crud/salva-prodottitag.aspx" method="post" enctype="multipart/form-data" data-abide novalidate>
      <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
      <input type="hidden" name="Ky" id="Ky" value="<%=GetFieldValue(dtProdottiTag, "ProdottiTag_Ky")%>">
      <input type="hidden" name="ProdottiTag_Ky" id="ProdottiTag_Ky" value="<%=GetFieldValue(dtProdottiTag, "ProdottiTag_Ky")%>">
			<div class="stacked-for-small button-group small hide-for-print align-right">
				<a href="/admin/view.aspx?CoreModules_Ky=8&CoreEntities_Ky=92&CoreGrids_Ky=75" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
				<a href="/admin/app/catalogo/scheda-prodottitag.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a> 
        <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
			</div>
      <!--#include file=/admin/forms_messaggi.inc -->
			<!--#include file=/admin/app/catalogo/forms/prodottitag_form.htm -->
    </form>
  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
