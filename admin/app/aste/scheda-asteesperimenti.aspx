<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/aste/scheda-asteesperimenti.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Aste > Elenco esperimenti aste</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx -->
<form id="form-asteesperimenti" action="/admin/app/aste/crud/salva-asteesperimenti.aspx" method="post" enctype="multipart/form-data" data-abide novalidate>
<div data-sticky-container>
	<div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
		<div class="grid-x grid-padding-x">
			<div class="large-4 medium-6 small-12 cell">
        <h1><i class="fa-duotone fa-table fa-lg fa-fw"></i>Scheda esperimento: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtAsteEsperimenti, "AsteEsperimenti_Ky")%></span></h1> 
      </div>
			<div class="large-8 medium-6 small-12 cell float-right">

  			<div class="stacked-for-small button-group small hide-for-print align-right">
  				<a href="/admin/app/aste/scheda-aste.aspx?Aste_Ky=<%=GetFieldValue(dtAsteEsperimenti, "Aste_Ky")%>" class="button secondary"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'asta</a>
  		    <% if (boolAdmin && strAzione!="new"){ %>
  				<a href="#" class="button secondary dropdown" data-toggle="dropdownsstampa"><i class="fa-duotone fa-print fa-fw"></i>Stampa</a>
  				<div class="dropdown-pane" id="dropdownsstampa" data-dropdown data-hover="true" data-hover-pane="true">
  				  <ul class="no-bullet">
      				<li><a href="/admin/app/aste/report/rpt-asteesperimenti.aspx?AsteEsperimenti_Ky=<%=GetFieldValue(dtAsteEsperimenti, "AsteEsperimenti_Ky")%>&Aste_Ky=<%=GetFieldValue(dtAsteEsperimenti, "Aste_Ky")%>" target="_blank"><i class="fa-duotone fa-print fa-fw"></i>Stampa dettaglio</a></li>
      				<li><a href="/admin/app/aste/report/rpt-asta.aspx?AsteEsperimenti_Ky=<%=GetFieldValue(dtAsteEsperimenti, "AsteEsperimenti_Ky")%>&Aste_Ky=<%=GetFieldValue(dtAsteEsperimenti, "Aste_Ky")%>" target="_blank"><i class="fa-duotone fa-print fa-fw"></i>Stampa scheda</a></li>
      				<li><a href="/admin/app/aste/report/rpt-asta-catalogo.aspx?AsteEsperimenti_Ky=<%=GetFieldValue(dtAsteEsperimenti, "AsteEsperimenti_Ky")%>&Aste_Ky=<%=GetFieldValue(dtAsteEsperimenti, "Aste_Ky")%>" target="_blank"><i class="fa-duotone fa-print fa-fw"></i>Stampa catalogo</a></li>
      				<li><a href="/admin/app/aste/report/rpt-asta-verbale.aspx?AsteEsperimenti_Ky=<%=GetFieldValue(dtAsteEsperimenti, "AsteEsperimenti_Ky")%>&Aste_Ky=<%=GetFieldValue(dtAsteEsperimenti, "Aste_Ky")%>" target="_blank"><i class="fa-duotone fa-print fa-fw"></i>Stampa verbale asta</a></li>
      				<li><a href="/admin/app/aste/report/rpt-asta-cliente.aspx?AsteEsperimenti_Ky=<%=GetFieldValue(dtAsteEsperimenti, "AsteEsperimenti_Ky")%>&Aste_Ky=<%=GetFieldValue(dtAsteEsperimenti, "Aste_Ky")%>" target="_blank"><i class="fa-duotone fa-print fa-fw"></i>Stampa report cliente</a></li>
  				  </ul>
  				</div>

  		    <% } %>
  				<a href="/admin/app/aste/scheda-asteesperimenti.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a> 
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
      <input type="hidden" name="AsteEsperimenti_Ky" id="AsteEsperimenti_Ky" value="<%=GetFieldValue(dtAsteEsperimenti, "AsteEsperimenti_Ky")%>">
      <input type="hidden" name="Aste_Ky" id="Aste_Ky" value="<%=strAste_Ky%>">
      <!--#include file=/admin/forms_messaggi.inc -->
 			<!--#include file=/admin/app/aste/forms/asteesperimenti_form.htm -->
    </div>
  </div>
</div>
</form>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
