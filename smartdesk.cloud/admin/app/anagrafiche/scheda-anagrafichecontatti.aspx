<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/anagrafiche/scheda-anagrafichecontatti.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Anagrafiche > Scheda contatto</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-anagraficacontatto" action="/admin/app/anagrafiche/crud/salva-anagraficacontatto.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-user fa-lg fa-fw"></i>Contatto: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtAnagraficheContatti, "AnagraficheContatti_Ky")%></span></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
      			<div class="stacked-for-small button-group small hide-for-print align-right">
      				<% if (dtAnagraficheContatti!=null){ %>
      				<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=GetFieldValue(dtAnagraficheContatti, "Anagrafiche_Ky")%>" class="button secondary"><i class="fa-duotone fa-backward fa-fw"></i>Torna alla scheda</a>
      				<% } %>
      				<a href="/admin/app/anagrafiche/scheda-anagrafichecontatti.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
            	<button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
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
        <input type="hidden" name="AnagraficheContatti_Ky" id="AnagraficheContatti_Ky" value="<%=GetFieldValue(dtAnagraficheContatti, "AnagraficheContatti_Ky")%>">
        <!--#include file=/admin/forms_messaggi.inc -->
      	<!--#include file=/admin/app/anagrafiche/forms/anagrafichecontatti_form.htm -->
      </div>
    </div>
  </div>
</form>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
