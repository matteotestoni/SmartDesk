<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/view.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Attivit&agrave; > Elenco attivit&agrave;</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-5 small-12 cell align-middle">
              <h1><i class="fa-duotone fa-calendar-days fa-lg fa-fw"></i><%=strH1%></h1>
              <!--#include file=/admin/view-inc-grids.aspx --> 
          </div>
          <div class="large-8 medium-7 small-12 cell float-right align-middle">
          		<div class="stacked-for-small button-group small hide-for-print align-right">
                <a class="button dropdown clear" data-toggle="print-dropdown"><i class="fa-duotone fa-print fa-lg fa-fw"></i>Stampa</a>
                <div class="dropdown-pane" id="print-dropdown" data-dropdown data-auto-focus="true">
            			<a href="/admin/app/attivita/report/rpt-attivita.aspx?Utenti_Ky=<%=dtLogin.Rows[0]["Utenti_Ky"].ToString()%>" target="_blank" class="clear"><i class="fa-duotone fa-print fa-fw"></i>Stampa attivit&agrave; persona</a><br>
            			<a href="/admin/app/attivita/report/rpt-attivita-planning.aspx?sorgente=elenco-attivita" class="clear" target="_blank"><i class="fa-duotone fa-print fa-lg fa-fw"></i>Stampa planning</a> 
                </div>      
          			<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new" class="tiny button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
          		</div>
        </div>
  	</div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-2 medium-3 small-12 cell" id="sidebarfilter" class="sidebar">
      <!--#include file=/admin/app/attivita/elenco-attivita-where.aspx -->
  </div>
  <div class="large-10 medium-9 small-12 cell">
	  <% if (dtGridData!=null && dtGridData.Rows.Count>0){ %>
      <ul class="tabs" data-tabs id="attivita-tabs">
        <li class="tabs-title is-active"><a href="#panel1" aria-selected="true"><i class="fa-duotone fa-calendar fa-fw"></i>Elenco attivit&agrave;</a></li>
        <li class="tabs-title"><a href="/admin/app/attivita/attivita-da-fare.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1"><i class="fa-duotone fa-square-kanban fa-fw"></i>Prospetto per scadenza</a></li>
        <li class="tabs-title"><a href="/admin/app/attivita/attivita-da-fare-stato.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1"><i class="fa-duotone fa-square-kanban fa-fw"></i>Prospetto per stato</a></li>
        <li class="tabs-title"><a href="/admin/app/attivita/calendario.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1"><i class="fa-duotone fa-calendar-days fa-fw"></i>Calendario</a></li>
      </ul>		  
      <div class="tabs-content" data-tabs-content="attivita-tabs">
        <div class="tabs-panel is-active" id="panel1">
          <!--#include file=/admin/app/attivita/elenco-attivita-grid.inc -->
        </div>
      </div>
      
	  <% } %>

  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
