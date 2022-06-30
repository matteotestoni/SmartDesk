<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/catalogo/scheda-prodottitipo.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>

<html class="no-js" lang="it">
<head>
	<title>Catalogo > Scheda tipo prodotto</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx -->
<div class="grid-x grid-padding-x">
  <div class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only"><!--#include file=/admin/impostazioni-sidebar.aspx --></div>
  <div class="large-10 medium-10 small-12 cell">
		<h1><i class="fa-duotone fa-table fa-lg fa-fw"></i>Scheda tipo prodotto: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtProdottiTipo, "ProdottiTipo_Ky")%></span></h1> 
		<form id="form-prodottitipo" action="/admin/app/catalogo/crud/salva-prodottitipo.aspx" method="post" enctype="multipart/form-data" data-abide novalidate>
      <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
      <input type="hidden" name="ProdottiTipo_Ky" id="ProdottiTipo_Ky" value="<%=GetFieldValue(dtProdottiTipo, "ProdottiTipo_Ky")%>">
			<div class="stacked-for-small button-group small hide-for-print align-right">
				<a href="/admin/view.aspx?CoreModules_Ky=8&CoreEntities_Ky=93&CoreGrids_Ky=76" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
				<a href="/admin/app/catalogo/scheda-prodottitipo.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a> 
        <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
			</div>
      <!--#include file=/admin/forms_messaggi.inc -->
 			<!--#include file=/admin/app/catalogo/forms/prodottitipo_form.htm -->
    </form>
  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
