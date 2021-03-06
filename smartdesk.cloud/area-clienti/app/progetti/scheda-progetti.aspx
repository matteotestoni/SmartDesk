<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/area-clienti/app/progetti/scheda-progetti.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Progetti > Scheda progetto</title>
	<!--#include file="/area-clienti/inc-head.aspx"-->
</head>
<body>
<!--#include file=/area-clienti/inc-mainbar.aspx --> 
<form id="form-commesse" action="/area-clienti/app/progetti/crud/salva-commesse.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-building fa-lg fa-fw"></i><%=strH1%>:<span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtCommesse, "Commesse_Ky")%></span></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
        			<div class="stacked-for-small button-group small hide-for-print align-right">
        				<% if (strAzione!="new"){ %>
        				<a href="#" class="button secondary dropdown" data-toggle="dropdownsstampa"><i class="fa-duotone fa-print fa-fw"></i>Stampa</a>
        				<div class="dropdown-pane" id="dropdownsstampa" data-dropdown data-hover="true" data-hover-pane="true">
        				  <ul class="no-bullet">
        		      	<li><a href="/area-clienti/app/progetti/report/rpt-commesse.aspx?Commesse_Ky=<%=GetFieldValue(dtCommesse, "Commesse_Ky")%>&periodo=mese" target="_blank" id="print2"><i class="fa-duotone fa-print fa-fw"></i>Report ultimo mese (per cliente)</a></li>
        		      	<li><a href="/area-clienti/app/progetti/report/rpt-commesse.aspx?Commesse_Ky=<%=GetFieldValue(dtCommesse, "Commesse_Ky")%>&periodo=tutti" target="_blank" id="print3"><i class="fa-duotone fa-print fa-fw"></i>Tutte le attivita (per cliente)</a></li>
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
        <!--#include file=/area-clienti/forms_messaggi.inc -->
  			<!--#include file=/area-clienti/app/progetti/forms/progetti_readonly_form.htm -->
      </div>
  	</div>
  </div>
</form>

<% if (GetFieldValue(dtCommesse, "CommesseStato_Ky")=="4"){ %>
<!--#include file=/area-clienti/app/progetti/scheda-progetti-attivita.inc -->
<% } %>
<!--#include file=/area-clienti/app/progetti/scheda-progetti-attivita-completate.inc -->

<!--#include file=/area-clienti/inc-footer.aspx -->
</body>
</html>
