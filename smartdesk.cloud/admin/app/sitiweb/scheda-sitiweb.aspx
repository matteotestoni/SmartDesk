<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="scheda-SitiWeb.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Siti web > Scheda sito</title>
	<!--#include file="/admin/inc-head.aspx"-->
	<!--#include file="/admin/inc-head-highcharts.aspx"-->
	<script>
		jQuery(document).ready(function() {
		  jQuery("table.highchart").highchartTable();
		});
	</script>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-sitiweb" action="/admin/app/sitiweb/crud/salva-sitiweb.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
    <div class="grid-x grid-padding-x align-middle">
        <div class="large-4 medium-4 small-12 cell align-middle">
          <h1><i class="fa-duotone fa-browser fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtSitiWeb, "SitiWeb_Ky")%></span></h1>
        </div>
        <div class="large-8 medium-8 small-12 cell float-right align-middle">
  				<div class="stacked-for-small button-group small hide-for-print align-right">
  						<a href="/admin/view.aspx?CoreModules_Ky=27&CoreEntities_Ky=142&CoreGrids_Ky=126" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
  						<a href="/admin/app/sitiweb/scheda-SitiWeb.aspx?azione=new" class="tiny button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
  				    <button type="submit" value="salva" name="salva" class="button large success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
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
				<input type="hidden" name="SitiWeb_Ky" id="SitiWeb_Ky" value="<%=GetFieldValue(dtSitiWeb, "SitiWeb_Ky")%>">
      	<!--#include file=/admin/forms_messaggi.inc -->
				<!--#include file=/admin/app/sitiweb/forms/sitiweb_form.htm --> 
      </div>
  </div>
</div>
</form>

<!--#include file=/admin/app/sitiweb/scheda-sitiweb-passwordmanager.inc -->
<!--#include file=/admin/app/sitiweb/scheda-sitiweb-contatti.inc -->
<% if (strAzione!="new"){ %>
	<% if (dtSitiWeb.Rows[0]["SitiWeb_SEO_IT"].ToString()=="si"){ %>
		<!--#include file=/admin/app/sitiweb/scheda-sitiweb-seo.inc -->
		<!--#include file=/admin/app/sitiweb/scheda-sitiweb-grafici.inc -->
		<!--#include file=/admin/app/sitiweb/scheda-sitiweb-pagespeedlog.inc -->
	<% } %>
<% } %>
<!--#include file=/admin/app/sitiweb/scheda-sitiweb-log.inc -->

<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
