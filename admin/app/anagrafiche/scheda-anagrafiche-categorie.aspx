<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/anagrafiche/scheda-anagrafiche-categorie.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>

<html class="no-js" lang="it">
<head>
	<title>Anagrafiche > Scheda categoria anagrafica</title>
	<!--#include file="/admin/inc-head.aspx"-->
	<% if (boolWysiwyg==true){ %>
  	<script src="//cdn.ckeditor.com/4.19.0/full/ckeditor.js"></script>
	<% } %>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<h1><i class="fa-duotone fa-building fa-lg fa-fw"></i>Categoria anagrafica: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtAnagraficheCategorie, "AnagraficheCategorie_Ky")%></span></h1>
<div class="grid-x grid-padding-x">
  <div class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only"><!--#include file=/admin/impostazioni-sidebar.aspx --></div>
  <div class="large-10 medium-10 small-12 cell">
			<form id="form-anagrafichecategorie" action="/admin/app/anagrafiche/crud/salva-anagrafichecategorie.aspx" method="post" data-abide novalidate>
		    <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
        <input type="hidden" name="AnagraficheCategorie_Ky" id="AnagraficheCategorie_Ky" value="<%=GetFieldValue(dtAnagraficheCategorie, "AnagraficheCategorie_Ky")%>">
				<div class="stacked-for-small button-group small hide-for-print align-right">
					<a href="/admin/app/anagrafiche/elenco-anagrafichecategorie.aspx" class="button secondary"><i class="fa-duotone fa-backward success fa-fw"></i>Torna all'elenco</a>
					<a href="/admin/app/anagrafiche/scheda-anagrafiche-categorie.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
					<button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-fw"></i>salva</button>
				</div>
      <!--#include file=/admin/forms_messaggi.inc -->
      <!--#include file=/admin/app/anagrafiche/forms/anagrafichecategorie_form.htm -->
  		</form>
  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
