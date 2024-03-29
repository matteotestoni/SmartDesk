<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/progetti/scheda-progetti.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title><%=strH1%></title>
	<!--#include file="/admin/inc-head.aspx"-->
  <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/js-cookie@3.0.1/dist/js.cookie.min.js" integrity="sha256-0H3Nuz3aug3afVbUlsu12Puxva3CP4EhJtPExqs54Vg=" crossorigin="anonymous"></script>
  <script type="text/javascript" src="https://cdn.jsdelivr.net/momentjs/latest/moment.min.js"></script>
  <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js"></script>
  <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css" />
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-commesse" action="/admin/app/progetti/crud/salva-commesse.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="<%=GetFieldValue(dtCommesse, "CommesseTipo_Icona")%> fa-lg fa-fw"></i><%=strH1%>:<span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtCommesse, "Commesse_Ky")%></span></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
        			<div class="stacked-for-small button-group small hide-for-print align-right">
        				<a href="/admin/app/progetti/elenco-commesse.aspx?custom=1&CoreGrids_Ky=118" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
        				<% if (strAzione!="new"){ %>
                <a href="#" class="button secondary dropdown" data-toggle="dropdownsstampa"><i class="fa-duotone fa-print fa-fw"></i>Stampa</a>
        				<div class="dropdown-pane" id="dropdownsstampa" data-dropdown data-hover="true" data-hover-pane="true">
        				  <ul class="no-bullet">
        		      	<li><a href="/admin/app/progetti/report/rpt-commesse-campagna.aspx?Commesse_Ky=<%=GetFieldValue(dtCommesse, "Commesse_Ky")%>&periodo=mese" target="_blank" id="print2"><i class="fa-duotone fa-print fa-fw"></i>Report (mese corrente)</a></li>
        		      	<li><a href="/admin/app/progetti/report/rpt-commesse-campagna.aspx?Commesse_Ky=<%=GetFieldValue(dtCommesse, "Commesse_Ky")%>&periodo=meseprecedente" target="_blank" id="print2"><i class="fa-duotone fa-print fa-fw"></i>Report (mese precedente)</a></li>
        		      	<li><a href="/admin/app/progetti/report/rpt-commesse-campagna.aspx?Commesse_Ky=<%=GetFieldValue(dtCommesse, "Commesse_Ky")%>&periodo=tutti" target="_blank" id="print3"><i class="fa-duotone fa-print fa-fw"></i>Report (tutto)</a></li>
        		      	<li><a href="/admin/app/progetti/report/rpt-commesse-campagna.aspx?Commesse_Ky=<%=GetFieldValue(dtCommesse, "Commesse_Ky")%>&periodo=tutti&tipo=trasferte" target="_blank" id="print4"><i class="fa-duotone fa-print fa-fw"></i>Trasferte</a></li>
        				  </ul>
        				</div>
        				<% } %>
        			</div>
  	      </div>
      </div>
  </div>
</div>

  <div class="grid-x grid-padding-x">
    <div class="large-12 medium-12 small-12 cell">
      <div class="divform">
        <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
        <input type="hidden" name="Utenti_Ky" id="Utenti_Ky" value="<%=Smartdesk.Session.CurrentUser.ToString()%>">
        <input type="hidden" name="Commesse_Ky" id="Commesse_Ky" value="<%=GetFieldValue(dtCommesse, "Commesse_Ky")%>">
        <!--#include file=/admin/forms_messaggi.inc -->
  			<!--#include file=/admin/app/progetti/forms/progetti_readonly_form.htm -->
      </div>
  	</div>
  </div>
</form>

  <div class="grid-x grid-padding-x">
    <div class="large-12 medium-12 small-12 cell">
        <ul class="tabs horizontal" data-tabs id="progetto-tabs">
          <li class="tabs-title is-active"><a href="#tab-attivita" aria-selected="true">Attivit&agrave;</a></li>
          <li class="tabs-title"><a data-tabs-target="tab-uploads" href="#tab-uploads">Files</a></li>
        </ul>
        <div class="tabs-content" data-tabs-content="progetto-tabs">
          <div class="tabs-panel is-active" id="tab-attivita">
              <!--#include file=/admin/app/progetti/scheda-progetti-attivita.inc -->
              <!--#include file=/admin/app/progetti/scheda-progetti-attivita-completate.inc -->
          </div>
          <div class="tabs-panel" id="tab-uploads">
          </div>
        </div>
  	</div>
  </div>



<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
