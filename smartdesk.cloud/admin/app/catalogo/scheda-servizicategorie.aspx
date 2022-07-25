<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="scheda-ServiziCategorie.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Catalogo > Scheda categoria servizio</title>
	<!--#include file="/admin/inc-head.aspx"-->
	<script src="//cdn.ckeditor.com/4.19.1/full/ckeditor.js"></script>
	<script src="https://cdn.smartdesk.cloud/lib/jquery-file-upload/js/jquery.fileupload.js"></script>	
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<h1><i class="fa-duotone fa-cube fa-lg fa-fw"></i>Scheda categoria servizio:<span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtServiziCategorie, "ServiziCategorie_Ky")%></span></h1>
<div class="grid-x grid-padding-x">
	<div class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only"><!--#include file=/admin/impostazioni-sidebar.aspx --></div>
	<div class="large-10 medium-10 small-12 cell">
		<form id="form-servizicategorie" action="/admin/app/catalogo/crud/salva-servizicategorie.aspx" method="post" data-abide novalidate>
	    <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
	    <input type="hidden" name="ServiziCategorie_Ky" id="ServiziCategorie_Ky" value="<%=GetFieldValue(dtServiziCategorie, "ServiziCategorie_Ky")%>">
			<div class="stacked-for-small button-group small hide-for-print align-right">
				<a href="/admin/view.aspx?CoreModules_Ky=8&CoreEntities_Ky=196&CoreGrids_Ky=204" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
				<% if (strAzione!="new"){ %>
					<a href="/admin/app/catalogo/scheda-servizicategorie.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
				<% } %>
	      <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
			</div>
      <!--#include file=/admin/forms_messaggi.inc -->
 			<!--#include file=/admin/app/catalogo/forms/servizicategorie_form.htm -->
    </form>
  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
