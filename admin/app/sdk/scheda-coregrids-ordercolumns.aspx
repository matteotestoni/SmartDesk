<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/sdk/scheda-coregrids-ordercolumns.aspx.cs" Inherits="_Default" Debug="true" validateRequest="false"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>SDK > <%=strH1%></title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div class="grid-container fluid">
<div class="grid-x grid-padding-x">
  <div class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only"><!--#include file=/admin/impostazioni-sidebar.aspx --></div>
  <div class="large-10 medium-10 small-12 cell contenuto">
			<h1><i class="fa-duotone fa-code fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtCoreGrids, "CoreGrids_Ky")%></span></h1>
			<div class="grid-x grid-padding-x">
			  <div class="large-12 medium-12 small-12 cell">
					<form id="form-coreattributes" action="/admin/app/sdk/crud/salva-coregrids-addcolumns.aspx" method="post" data-abide novalidate>
			      <input type="hidden" name="sorgente" id="sorgente" value="<%=strSorgente%>">
			      <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
			      <input type="hidden" name="Utenti_Ky" id="Utenti_Ky" value="<%=Smartdesk.Session.CurrentUser.ToString()%>">
			      <input type="hidden" name="CoreGrids_Ky" id="CoreGrids_Ky" value="<%=GetFieldValue(dtCoreGrids, "CoreGrids_Ky")%>">
			      <input type="hidden" name="CoreModules_Ky" id="CoreModules_Ky" value="<%=GetFieldValue(dtCoreGrids, "CoreModules_Ky")%>">
			      <input type="hidden" name="CoreEntities_Ky" id="CoreEntities_Ky" value="<%=GetFieldValue(dtCoreGrids, "CoreEntities_Ky")%>">
						<div class="stacked-for-small button-group small hide-for-print align-right">
							<a href="/admin/app/sdk/scheda-coremodules.aspx?CoreModules_Ky=<%=GetFieldValue(dtCoreGrids, "CoreModules_Ky")%>" class="button secondary"><i class="fa-duotone fa-backward fa-fw"></i>Torna al modulo</a>
							<a href="/admin/app/sdk/scheda-coreentities.aspx?CoreModules_Ky=<%=GetFieldValue(dtCoreGrids, "CoreModules_Ky")%>&CoreEntities_Ky=<%=GetFieldValue(dtCoreGrids, "CoreEntities_Ky")%>" class="button secondary"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'entit&agrave;</a>
							<a href="/admin/view.aspx?CoreModules_Ky=<%=GetFieldValue(dtCoreGrids, "CoreModules_Ky")%>&CoreEntities_Ky=<%=GetFieldValue(dtCoreGrids, "CoreEntities_Ky")%>&CoreGrids_Ky=<%=GetFieldValue(dtCoreGrids, "CoreGrids_Ky")%>" class="button warning" target="_blank"><i class="fa-duotone fa-eye fa-fw"></i>Visualizza</a> 
			        <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
						</div>
			      <!--#include file=/admin/forms_messaggi.inc -->
			    </form>	
								
				</div>
			</div>


  </div>
 </div>
</div>


<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
