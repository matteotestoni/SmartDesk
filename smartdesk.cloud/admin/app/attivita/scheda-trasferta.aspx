<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/attivita/scheda-trasferta.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Attivit&agrave; > Scheda trasferta</title>
	<!--#include file="/admin/inc-head.aspx"-->
	<script src="/admin/app/attivita/attivita.js?id=<%=new Random().Next(0, 100)%>"></script>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-attivita" action="/admin/app/attivita/crud/salva-attivita.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtAttivita, "Attivita_Ky")%></span></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
      			<div class="stacked-for-small button-group small hide-for-print align-right">
      				<a href="/admin/app/attivita/elenco-attivita-trasferte.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreGrids_Ky=273&Utenti_Ky=<%=strUtenti_Ky%>" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
      				<% if (strAzione!="new"){ %>
                <a href="/admin/app/attivita/crud/elimina-attivita.aspx?azione=delete&Anagrafiche_Ky=<%=GetFieldValue(dtAttivita, "Anagrafiche_Ky")%>&Attivita_Ky=<%=GetFieldValue(dtAttivita, "Attivita_Ky")%>&sorgente=<%=strSorgente%>" title="elimina" class="button secondary"><i class="fa-duotone fa-trash-can fa-fw"></i>Elimina</a>
      					<a href="/admin/app/attivita/scheda-trasferta.aspx?azione=new&Anagrafiche_Ky=<%=strAnagrafiche_Ky%>&Utenti_Ky=<%=strUtenti_Ky%>&sorgente=scheda-trasferta" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a> 
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
        <input type="hidden" name="AttivitaTipo_Ky" id="AttivitaTipo_Ky" value="4">
        <input type="hidden" name="sorgente" id="sorgente" value="scheda-trasferta">
        <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
        <input type="hidden" name="Utenti_Ky" id="Utenti_Ky" value="<%=Smartdesk.Session.CurrentUser.ToString()%>">
        <input type="hidden" name="Attivita_Ky" id="Attivita_Ky" value="<%=GetFieldValue(dtAttivita, "Attivita_Ky")%>">
        <input type="hidden" name="Priorita_Ky" id="Attivita_Ky" value="1">
        <input type="hidden" name="Attivita_Completo" id="Attivita_Completo" value="on" checked="checked" />
        <input type="hidden" name="Attivita_Scadenza" id="Attivita_Scadenza" value="<%=GetFieldValue(dtAttivita, "Attivita_Scadenza")%>" size="10">
        <input type="hidden" name="Attivita_Chiusura" id="Attivita_Chiusura" value="<%=GetFieldValue(dtAttivita, "Attivita_Chiusura")%>" size="10">
        <!--#include file=/admin/forms_messaggi.inc -->
        <!--#include file=/admin/app/attivita/forms/trasferta_form.htm -->
      </div>
    </div>
  </div> 
</form>

<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
