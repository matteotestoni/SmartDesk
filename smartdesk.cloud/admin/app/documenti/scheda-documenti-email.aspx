<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/documenti/scheda-documenti-email.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
    <title>Documenti > <%=strH1%></title>
    <!--#include file="/admin/inc-head.aspx"-->
	<% if (boolWysiwyg==true){ %>
	<script src="//cdn.ckeditor.com/4.19.1/full/ckeditor.js"></script>
	<% } %>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<h1><i class="fa-duotone fa-file fa-lg fa-fw"></i><%=strH1%></h1>
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
    <form id="form-documento" action="/admin/app/documenti/actions/invia-documento.aspx" method="post" data-abide novalidate>
			<input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
			<input type="hidden" name="Utenti_Ky" id="Utenti_Ky" value="<%=Smartdesk.Session.CurrentUser.ToString()%>">
			<input type="hidden" name="Documenti_Ky" id="Documenti_Ky" value="<%=GetFieldValue(dtDocumenti, "Documenti_Ky")%>">
			<div class="stacked-for-small button-group small hide-for-print align-right">
		        <a href="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=<%=GetFieldValue(dtDocumenti, "Documenti_Ky")%>" class="button secondary"><i class="fa-duotone fa-backward fa-fw"></i>Torna al documento</a>
			    <button type="submit" value="Invia" name="salva" class="button success"><i class="fa-duotone fa-envelope fa-fw"></i>Invia documento</button>
			</div>
            <!--#include file=/admin/forms_messaggi.inc -->
 			<!--#include file=/admin/app/documenti/forms/documenti-email_form.htm -->
		</form>  
	</div>
</div>
  					      
  <% if (strAlert!=null && strAlert.Length>0){ %>
	<div id="dialog" title="Attenzione">
		<i class="fa-duotone fa-triangle-exclamation-circle fa-fw"></i>
		<%=strAlert%>
	</div>
	<script>
	jQuery(function() {
		jQuery("#dialog" ).dialog({modal: true});
	});
	</script>				
	<% } %> 
    <!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
