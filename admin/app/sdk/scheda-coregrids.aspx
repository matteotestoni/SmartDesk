<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/sdk/scheda-coregrids.aspx.cs" Inherits="_Default" Debug="true" validateRequest="false"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>SDK > <%=strH1%></title>
	<!--#include file="/admin/inc-head.aspx"-->
	<script type="text/javascript" src="/lib/jquery-querybuilder/interact.min.js"></script>
	<script type="text/javascript" src="/lib/jquery-querybuilder/jQuery.extendext.min.js"></script>
	<script type="text/javascript" src="/lib/jquery-querybuilder/doT.min.js"></script>
	<link rel="stylesheet" href="/lib/jquery-querybuilder/css/query-builder.default.min.css">
	<script type="text/javascript" src="/lib/jquery-querybuilder/js/query-builder.standalone.min.js"></script>
	<script type="text/javascript" src="/lib/jquery-querybuilder/i18n/query-builder.it.js"></script>
	<style>
		.query-builder, .query-builder * {
		  margin: 0;
		  padding: 0;
		  box-sizing: border-box;
		}
		
		.query-builder {
		  font-family: sans-serif;
		}
		
		.query-builder .hide {
		  display: none;
		}
		
		.query-builder .pull-right {
		  float: right !important;
		}
		
		.query-builder .btn {
		  text-transform: none;
		  display: inline-block;
		  padding: 6px 12px;
		  margin-bottom: 0px;
		  font-size: 14px;
		  font-weight: 400;
		  line-height: 1.42857;
		  text-align: center;
		  white-space: nowrap;
		  vertical-align: middle;
		  touch-action: manipulation;
		  cursor: pointer;
		  user-select: none;
		  background-image: none;
		  border: 1px solid transparent;
		  border-radius: 4px;
		}
		
		.query-builder .btn.focus, .query-builder .btn:focus, .query-builder .btn:hover {
		  color: #333;
		  text-decoration: none;
		}
		
		.query-builder .btn.active, .query-builder .btn:active {
		  background-image: none;
		  outline: 0px none;
		  box-shadow: 0px 3px 5px rgba(0, 0, 0, 0.125) inset;
		}
		
		.query-builder .btn-success {
		  color: #FFF;
		  background-color: #5CB85C;
		  border-color: #4CAE4C;
		}
		
		.query-builder .btn-primary {
		  color: #FFF;
		  background-color: #337AB7;
		  border-color: #2E6DA4;
		}
		
		.query-builder .btn-danger {
		  color: #FFF;
		  background-color: #D9534F;
		  border-color: #D43F3A;
		}
		
		.query-builder .btn-success.active, .query-builder .btn-success.focus,
		.query-builder .btn-success:active, .query-builder .btn-success:focus,
		.query-builder .btn-success:hover {
		  color: #FFF;
		  background-color: #449D44;
		  border-color: #398439;
		}
		
		.query-builder .btn-primary.active, .query-builder .btn-primary.focus,
		.query-builder .btn-primary:active, .query-builder .btn-primary:focus,
		.query-builder .btn-primary:hover {
		  color: #FFF;
		  background-color: #286090;
		  border-color: #204D74;
		}
		
		.query-builder .btn-danger.active, .query-builder .btn-danger.focus,
		.query-builder .btn-danger:active, .query-builder .btn-danger:focus,
		.query-builder .btn-danger:hover {
		  color: #FFF;
		  background-color: #C9302C;
		  border-color: #AC2925;
		}
		
		.query-builder .btn-group {
		  position: relative;
		  display: inline-block;
		  vertical-align: middle;
		}
		
		.query-builder .btn-group > .btn {
		  position: relative;
		  float: left;
		}
		
		.query-builder .btn-group > .btn:first-child {
		  margin-left: 0px;
		}
		
		.query-builder .btn-group > .btn:first-child:not(:last-child) {
		  border-top-right-radius: 0px;
		  border-bottom-right-radius: 0px;
		}
		
		.query-builder .btn-group > .btn:last-child:not(:first-child) {
		  border-top-left-radius: 0px;
		  border-bottom-left-radius: 0px;
		}
		
		.query-builder .btn-group .btn + .btn, .query-builder .btn-group .btn + .btn-group,
		.query-builder .btn-group .btn-group + .btn, .query-builder .btn-group .btn-group + .btn-group {
		  margin-left: -1px;
		}
		
		.query-builder .btn-xs, .query-builder .btn-group-xs > .btn {
		  padding: 1px 5px;
		  font-size: 12px;
		  line-height: 1.5;
		  border-radius: 3px;
		}	
	</style>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div class="grid-container fluid">
  <div class="grid-x grid-padding-x">
    <div class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only"><!--#include file=/admin/impostazioni-sidebar.aspx --></div>
    <div class="large-10 medium-10 small-12 cell contenuto">
      <form id="form-coreattributes" action="/admin/app/sdk/crud/salva-coregrids.aspx" method="post" data-abide novalidate>
          <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
              <div class="grid-x grid-padding-x align-middle">
                  <div class="large-4 medium-4 small-12 cell align-middle">
                    <h1><i class="fa-duotone fa-code fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtCoreGrids, "CoreGrids_Ky")%></span></h1>
                  </div>
                  <div class="large-8 medium-8 small-12 cell float-right align-middle">
              			<div class="stacked-for-small button-group small hide-for-print align-right">
              				<a href="/admin/app/sdk/scheda-coremodules.aspx?CoreModules_Ky=<%=GetFieldValue(dtCoreGrids, "CoreModules_Ky")%>" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna al modulo</a>
              				<a href="/admin/app/sdk/scheda-coreentities.aspx?CoreModules_Ky=<%=GetFieldValue(dtCoreGrids, "CoreModules_Ky")%>&CoreEntities_Ky=<%=GetFieldValue(dtCoreGrids, "CoreEntities_Ky")%>" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'entit&agrave;</a>
              				<a href="/admin/app/sdk/scheda-coreattributes.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-fw"></i>Nuovo</a> 
              				<a href="/admin/app/sdk/actions/duplicate-grid.aspx?CoreModules_Ky=<%=GetFieldValue(dtCoreGrids, "CoreModules_Ky")%>&CoreEntities_Ky=<%=GetFieldValue(dtCoreGrids, "CoreEntities_Ky")%>&CoreGrids_Ky=<%=GetFieldValue(dtCoreGrids, "CoreGrids_Ky")%>" class="button"><i class="fa-duotone fa-copy fa-fw"></i>Duplica</a> 
              				<a href="/admin/view.aspx?CoreModules_Ky=<%=GetFieldValue(dtCoreGrids, "CoreModules_Ky")%>&CoreEntities_Ky=<%=GetFieldValue(dtCoreGrids, "CoreEntities_Ky")%>&CoreGrids_Ky=<%=GetFieldValue(dtCoreGrids, "CoreGrids_Ky")%>" class="button warning" target="_blank"><i class="fa-duotone fa-eye fa-fw"></i>Visualizza</a> 
          	          <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
          			     </div>
          	      </div>
              </div>
          </div>
         <div class="divform">
          <input type="hidden" name="sorgente" id="sorgente" value="<%=strSorgente%>">
          <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
          <input type="hidden" name="Utenti_Ky" id="Utenti_Ky" value="<%=Smartdesk.Session.CurrentUser.ToString()%>">
          <input type="hidden" name="CoreGrids_Ky" id="CoreGrids_Ky" value="<%=GetFieldValue(dtCoreGrids, "CoreGrids_Ky")%>">
          <input type="hidden" name="CoreModules_Ky" id="CoreModules_Ky" value="<%=GetFieldValue(dtCoreGrids, "CoreModules_Ky")%>">
          <input type="hidden" name="CoreEntities_Ky" id="CoreEntities_Ky" value="<%=GetFieldValue(dtCoreGrids, "CoreEntities_Ky")%>">
          <!--#include file=/admin/forms_messaggi.inc -->
          <!--#include file=/admin/app/sdk/forms/coregrids_form.htm -->
		    </div>
      </form>	
      <% if (strAzione!="new"){ %>
  			<!--#include file=/admin/app/sdk/scheda-coregrids-coregridscolumns.inc -->
  		  <!--#include file=/admin/app/sdk/scheda-coregrids-coregridsbuttons.inc -->
    		<!--#include file=/admin/app/sdk/scheda-coregrids-usergroups.inc -->
      <% } %>
    </div>
   </div>
</div>


<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
