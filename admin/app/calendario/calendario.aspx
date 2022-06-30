<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/calendario/calendario.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
  <title>Calendario</title>
	<!--#include file="/admin/inc-head.aspx"-->
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/fullcalendar@5.11.0/main.min.css" integrity="sha256-5veQuRbWaECuYxwap/IOE/DAwNxgm4ikX7nrgsqYp88=" crossorigin="anonymous">
  <script src="https://cdn.jsdelivr.net/npm/fullcalendar@5.11.0/main.min.js" integrity="sha256-XCdgoNaBjzkUaEJiauEq+85q/xi/2D4NcB3ZHwAapoM=" crossorigin="anonymous"></script>
  <script src="https://cdn.jsdelivr.net/npm/fullcalendar@5.11.0/locales-all.min.js" integrity="sha256-GcByKJnun2NoPMzoBsuCb4O2MKiqJZLlHTw3PJeqSkI=" crossorigin="anonymous"></script>
  <script src="/admin/app/calendario/calendario5.js?id=2" type="text/javascript"></script>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-5 small-12 cell align-middle">
              <h1><i class="fa-duotone fa-calendar-days fa-lg fa-fw"></i>Calendario</h1>
          </div>
          <div class="large-8 medium-7 small-12 cell float-right align-middle">
        			<div class="stacked-for-small button-group small float-right">
        				<a href="/admin/app/attivita/elenco-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreGrids_Ky=62" class="tiny button clear"><i class="fa-duotone fa-table fa-fw"></i>Elenco attivit&agrave;</a>
        				<a href="/admin/app/attivita/attivita-da-fare.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1" class="tiny button clear"><i class="fa-duotone fa-columns fa-fw"></i>Prospetto attivit&agrave; per scadenza</a>
        				<a href="/admin/app/attivita/attivita-da-fare-stato.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1" class="tiny button clear"><i class="fa-duotone fa-columns fa-fw"></i>Prospetto attivit&agrave; per stato</a>
                <a class="button dropdown" data-toggle="nuovo-dropdown"><i class="fa-duotone fa-square-plus fa-fw"></i>Nuova</a>
                <div class="dropdown-pane" id="nuovo-dropdown" data-dropdown data-auto-focus="true">
          				<a href="/admin/form.aspx?CoreModules_Ky=22&CoreEntities_Ky=39&CoreForms_Ky=106&azione=new" class="clear"><i class="fa-duotone fa-square-plus fa-fw"></i>Nuova assenza</a><br>
          				<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new" class="secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>Nuova attivit&agrave;</a>
                </div>      
        			</div>
        </div>
  	</div>
  </div>
</div>

<div class="divcalendar">
  <div class="grid-x grid-padding-x">
    <div class="large-12 medium-12 small-12 cell">
  			<div class="grid-x grid-padding-x">
  			  <div class="small-12 large-10 medium-10 cell">
  			    <div id="calendar" style="height:100%;"></div>
  				</div>
  		  	<div class="small-12 large-2 medium-2 cell">
	            <ul class="no-bullet align-middle">
  		            <li><i class="fa-duotone fa-user fa-fw"></i><a href="/admin/app/calendario/calendario.aspx">Tutti</a><div style="width:12px;height:12px;float:right;background-color:#ff0000;"></div></li>
  		            <li><i class="fa-duotone fa-user fa-fw"></i><a href="#">Festa</a> <div style="width:12px;height:12px;float:right;background-color:#ff0000;"></div></li>
  		            <li><hr></li>
		            <%  for (int i = 0; i < dtPersone.Rows.Count; i++){ %>
  		            <li class="align-middle">
                    <% if (dtPersone.Rows[i]["Persone_Foto"].ToString().Length>0){
                    Response.Write("<img src=\"" + dtPersone.Rows[i]["Persone_Foto"].ToString() + "\" width=\"24\" height=\"24\" style=\"border-radius:50%\" loading=\"lazy\">");
                    }else{
                    Response.Write("<i class=\"fa-duotone fa-user fa-fw\" style=\"color:" + dtPersone.Rows[i]["Persone_Colore"].ToString() + "\"></i>");
                    } %>
                    <a href="/admin/app/calendario/calendario.aspx?Persone_Ky=<%=dtPersone.Rows[i]["Persone_Ky"].ToString()%>&amp;sorgente=calendario"><%=dtPersone.Rows[i]["Persone_Nome"].ToString()%> <%=dtPersone.Rows[i]["Persone_Cognome"].ToString()%></a> <div style="width:12px;height:12px;float:right;background-color:<%=dtPersone.Rows[i]["Persone_Colore"].ToString()%>"></div></li>
		            <% } %>
	            </ul>
  		  	</div>
  			</div>
  		</div>
	</div>
</div>
	<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
