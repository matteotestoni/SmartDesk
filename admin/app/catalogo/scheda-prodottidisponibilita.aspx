<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/catalogo/scheda-prodottidisponibilita.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>

<html class="no-js" lang="it">
<head>
	<title>Catalogo > Scheda disponibilit-</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<h1><i class="fa-duotonefa-cog fa-lg fa-fw"></i>Scheda disponibilita <span class="badge large secondary"><i class="fa-duotonefa-database fa-fw"></i><%=GetFieldValue(dtProdottiDisponibilita, "ProdottiDisponibilita_Ky")%></span></h1>
<div class="grid-x grid-padding-x">
  <div class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only"><!--#include file=/admin/impostazioni-sidebar.aspx --></div>
  <div class="large-10 medium-10 small-12 cell">
		<form id="form-prodottidisponibilita" action="/admin/app/catalogo/crud/salva-prodottidisponibilita.aspx" method="post" enctype="multipart/form-data" data-abide novalidate>
      <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
      <input type="hidden" name="ProdottiDisponibilita_Ky" id="ProdottiDisponibilita_Ky" value="<%=GetFieldValue(dtProdottiDisponibilita, "ProdottiDisponibilita_Ky")%>">
			<div class="stacked-for-small button-group small hide-for-print align-right">
				<a href="/admin/view.aspx?CoreModules_Ky=8&CoreEntities_Ky=88&CoreGrids_Ky=71" class="button secondary"><i class="fa-duotonefa-backward fa-fw"></i>Torna all'elenco</a>
				<a href="/admin/app/catalogo/scheda-prodottidisponibilita.aspx?azione=new" class="button"><i class="fa-duotonefa-plus-square fa-fw"></i>Aggiungi nuovo</a>
        <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotonefa-save fa-lg fa-fw"></i>Salva</button>
			</div>
      <!--#include file=/admin/forms_messaggi.inc -->
 			<!--#include file=/admin/app/catalogo/forms/ProdottiDisponibilita_form.htm -->
    </form>
  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
