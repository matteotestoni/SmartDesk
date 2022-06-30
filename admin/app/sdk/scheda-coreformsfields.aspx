<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/sdk/scheda-coreformsfields.aspx.cs" Inherits="_Default" Debug="true" validateRequest="false"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>SDK > <%=strH1%></title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-coreattributes" action="/admin/app/sdk/crud/salva-CoreFormsFields.aspx" method="post" data-abide novalidate>
<div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
    <div class="grid-x grid-padding-x align-middle">
        <div class="large-4 medium-4 small-12 cell align-middle">
			     <h1><i class="fa-duotone fa-code fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtCoreFormsFields, "CoreFormsFields_Ky")%></span></h1>
        </div>
        <div class="large-8 medium-8 small-12 cell float-right align-middle">
						<div class="stacked-for-small button-group small hide-for-print align-right">
							<a href="/admin/app/sdk/scheda-coremodules.aspx?CoreModules_Ky=<%=GetFieldValue(dtCoreFormsFields, "CoreModules_Ky")%>" class="button secondary"><i class="fa-duotone fa-backward fa-fw"></i>Torna al modulo</a>
							<a href="/admin/app/sdk/scheda-coreforms.aspx?CoreForms_Ky=<%=GetFieldValue(dtCoreForms, "CoreForms_Ky")%>&CoreModules_Ky=<%=GetFieldValue(dtCoreFormsFields, "CoreModules_Ky")%>&CoreEntities_Ky=<%=GetFieldValue(dtCoreFormsFields, "CoreEntities_Ky")%>" class="button secondary"><i class="fa-duotone fa-backward fa-fw"></i>Torna al form</a>
							<a href="/admin/app/sdk/scheda-coreentities.aspx?CoreGrids_Ky=<%=GetFieldValue(dtCoreFormsFields, "CoreGrids_Ky")%>&CoreModules_Ky=<%=GetFieldValue(dtCoreFormsFields, "CoreModules_Ky")%>&CoreEntities_Ky=<%=GetFieldValue(dtCoreFormsFields, "CoreEntities_Ky")%>" class="button secondary"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'entit&agrave;</a>
							<a href="/admin/app/sdk/scheda-coreattributes.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a> 
			        <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
						</div>
	      </div>
    </div>
</div>
<div class="grid-container fluid">
  <div class="grid-x grid-padding-x">
    <div class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only"><!--#include file=/admin/impostazioni-sidebar.aspx --></div>
    <div class="large-10 medium-10 small-12 cell contenuto">
			<div class="divform">
        <div class="grid-x grid-padding-x">
  			  <div class="large-12 medium-12 small-12 cell">
  			      <input type="hidden" name="sorgente" id="sorgente" value="<%=strSorgente%>">
  			      <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
  			      <input type="hidden" name="Utenti_Ky" id="Utenti_Ky" value="<%=Smartdesk.Session.CurrentUser.ToString()%>">
  			      <input type="hidden" name="CoreFormsFields_Ky" id="CoreFormsFields_Ky" value="<%=GetFieldValue(dtCoreFormsFields, "CoreFormsFields_Ky")%>">
  			      <input type="hidden" name="CoreForms_Ky" id="CoreForms_Ky" value="<%=GetFieldValue(dtCoreFormsFields, "CoreForms_Ky")%>">
  			      <input type="hidden" name="CoreModules_Ky" id="CoreModules_Ky" value="<%=GetFieldValue(dtCoreFormsFields, "CoreModules_Ky")%>">
  			      <input type="hidden" name="CoreEntities_Ky" id="CoreEntities_Ky" value="<%=GetFieldValue(dtCoreFormsFields, "CoreEntities_Ky")%>">
  			      <!--#include file=/admin/forms_messaggi.inc -->
  						<!--#include file=/admin/app/sdk/forms/CoreFormsFields_form.htm -->
  				</div>
  			</div>
      </div>
    </div>
 </div>
</div>
</form>	


<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
