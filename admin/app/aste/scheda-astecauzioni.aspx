<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/aste/scheda-astecauzioni.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Aste > Elenco cauzioni aste</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx -->
<form id="form-astecauzioni" action="/admin/app/aste/crud/salva-astecauzioni.aspx" method="post" enctype="multipart/form-data" data-abide novalidate>
<div data-sticky-container>
	<div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
		<div class="grid-x grid-padding-x">
			<div class="large-4 medium-6 small-12 cell">
        <h1><i class="fa-duotone fa-table fa-lg fa-fw"></i>Scheda Cauzione: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtAsteCauzioni, "AsteCauzioni_Ky")%></span></h1> 
      </div>
			<div class="large-8 medium-6 small-12 cell float-right">

  			<div class="stacked-for-small button-group small hide-for-print align-right">
  				<a href="/admin/app/aste/scheda-aste.aspx?Aste_Ky=<%=strAste_Ky%>" class="button secondary"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'asta</a>
  				<a href="/admin/app/aste/elenco-astecauzioni.aspx?CoreModules_Ky=5&CoreEntities_Ky=62&CoreGrids_Ky=52" class="button secondary"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco cauzioni</a>
  				<a href="/admin/app/aste/scheda-astecauzioni.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a> 
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
      <input type="hidden" name="AsteCauzioni_Ky" id="AsteCauzioni_Ky" value="<%=GetFieldValue(dtAsteCauzioni, "AsteCauzioni_Ky")%>">
      <input type="hidden" name="Aste_Ky" id="Aste_Ky" value="<%=strAste_Ky%>">
      <!--#include file=/admin/forms_messaggi.inc -->
 			<!--#include file=/admin/app/aste/forms/astecauzioni_form.htm -->
    </div>
  </div>
</div>
</form>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
