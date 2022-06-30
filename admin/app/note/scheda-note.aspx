<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/note/scheda-note.aspx.cs" Inherits="_Default" Debug="true" validateRequest="false"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Note > Scheda nota</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-note" action="/admin/app/note/crud/salva-note.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-notes fa-fw"></i>Note > <i class="fa-duotone fa-notes fa-fw"></i> <%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtNote, "Note_Ky")%></span></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
      			<div class="stacked-for-small button-group small hide-for-print align-right">
      				<a href="/admin/view.aspx?CoreModules_Ky=19&CoreEntities_Ky=161&CoreGrids_Ky=106" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
      				<a href="/admin/app/note/report/rpt-note.aspx?Note_Ky=<%=GetFieldValue(dtNote,"Note_Ky")%>" target="_blank" class="tiny button secondary"><i class="fa-duotone fa-print fa-fw"></i>Stampa</a>
      				<a href="/admin/app/note/scheda-note.aspx?azione=new&Anagrafiche_Ky=<%=strAnagrafiche_Ky%>&sorgente=<%=strSorgente%>" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a> 
              <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
      			</div>
  	      </div>
      </div>
  </div>
</div>

  <div class="grid-x grid-padding-x">
    <div class="large-12 medium-12 small-12 cell">
      <div class="divform">
        <input type="hidden" name="sorgente" id="sorgente" value="<%=strSorgente%>">
        <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
        <input type="hidden" name="Utenti_Ky" id="Utenti_Ky" value="<%=Smartdesk.Session.CurrentUser.ToString()%>">
        <input type="hidden" name="Note_Ky" id="Note_Ky" value="<%=GetFieldValue(dtNote, "Note_Ky")%>">
  			<input type="hidden" name="Documenti_Ky" id="Documenti_Ky" value="<%=GetFieldValue(dtNote, "Documenti_Ky")%>" size="3">
        <!--#include file=/admin/forms_messaggi.inc -->
  			<!--#include file=/admin/app/note/forms/note_form.htm -->
      </div>
    </div>
  </div>
</form>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
