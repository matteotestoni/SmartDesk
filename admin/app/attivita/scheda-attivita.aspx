<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/attivita/scheda-attivita.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Attivit&agrave; > Scheda attivit&agrave;</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-attivita" action="/admin/app/attivita/crud/salva-attivita.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-person-digging fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtAttivita, "Attivita_Ky")%></span></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
      			<div class="stacked-for-small button-group small hide-for-print align-right">
      				<a href="/admin/app/attivita/attivita-da-fare.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1" class="tiny button clear"><i class="fa-duotone fa-square-kanban fa-fw"></i>Prospetto per scadenza</a>
      				<a href="/admin/app/attivita/attivita-da-fare-stato.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1" class="tiny button clear"><i class="fa-duotone fa-square-kanban fa-fw"></i>Prospetto per stato</a>
      				<a href="/admin/app/attivita/elenco-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreGrids_Ky=62" class="tiny button clear"><i class="fa-duotone fa-list-check fa-fw"></i>Elenco</a>
      				<a href="/admin/app/calendario/calendario.aspx" class="tiny button clear"><i class="fa-duotone fa-calendar-days fa-fw"></i>Calendario</a>
      				<% if (strAzione!="new"){ %>
      			    <a href="/admin/app/attivita/crud/elimina-attivita.aspx?azione=delete&Anagrafiche_Ky=<%=GetFieldValue(dtAttivita, "Anagrafiche_Ky")%>&Attivita_Ky=<%=GetFieldValue(dtAttivita, "Attivita_Ky")%>&sorgente=<%=strSorgente%>" title="elimina" class="button secondary"><i class="fa-duotone fa-trash-can fa-fw"></i>Elimina</a>
      					<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new&Anagrafiche_Ky=<%=strAnagrafiche_Ky%>&AttivitaTipo_Ky=<%=strAttivitaTipo_Ky%>&Attivita_Trasferta=<%=strAttivita_Trasferta%>&AttivitaSettore_Ky=<%=strAttivitaSettore_Ky%>&sorgente=scheda-attivita" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a> 
      				<% } %>
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
        <input type="hidden" name="Attivita_Ky" id="Attivita_Ky" value="<%=GetFieldValue(dtAttivita, "Attivita_Ky")%>">
        <input type="hidden" name="Documenti_Ky" id="Documenti_Ky" value="<%=GetFieldValue(dtAttivita, "Documenti_Ky")%>">
        <input type="hidden" name="Pagamenti_Ky" id="Pagamenti_Ky" value="<%=GetFieldValue(dtAttivita, "Pagamenti_Ky")%>">
        <!--#include file=/admin/forms_messaggi.inc -->
        <!--#include file=/admin/app/attivita/forms/attivita_form.htm -->
      </div>
    </div>
  </div>
</form>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
