<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/documenti/scheda-documenti.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
    <title>Documenti > Scheda documento</title>
    <!--#include file="/admin/inc-head.aspx"-->
    <script type="text/javascript" src="/admin/app/documenti/documenti.js?id=2"></script>
    <script type="text/javascript">
  	    function stampaDocumento(){
			    var sel = document.getElementById('DocumentiTipo_Ky');
			    var selected = sel.options[sel.selectedIndex];
			    var extra = selected.getAttribute('report');
			    var url = "/admin/app/documenti/report/" + extra + "?Documenti_Ky=<%=GetFieldValue(dtDocumenti, "Documenti_Ky")%>"
		      var win=window.open(url, '_blank');
		      win.focus();
				}
		
        function  chgAzienda(){
        //Documenti_Numero
        }
	  </script>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-documento" action="/admin/app/documenti/crud/salva-documento.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-5 medium-5 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-file fa-lg fa-fw"></i>Scheda Documento</h1>
          </div>
          <div class="large-7 medium-7 small-12 cell float-right align-middle">
          			<div class="stacked-for-small button-group small hide-for-print align-right">
        		        <a href="/admin/app/documenti/elenco-documenti.aspx" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
                  	<% if (strAzione!="new"){ %>
            			    <a href="#" class="tiny button dropdown secondary" data-toggle="dropdowntipodocumenti"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
            			    <div class="dropdown-pane" id="dropdowntipodocumenti" data-dropdown data-hover="true" data-hover-pane="true">
            				    <ul class="no-bullet">
            					<% for (int i = 0; i < dtDocumentiTipo.Rows.Count; i++){ %>
            						<li><a href="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&azione=new&DocumentiTipo_Ky=<%=dtDocumentiTipo.Rows[i]["DocumentiTipo_Ky"].ToString()%>" class="tiny"><i class="fa-duotone fa-square-plus fa-fw"></i><%=dtDocumentiTipo.Rows[i]["DocumentiTipo_Descrizione"].ToString()%></a></li>
            					<% } %>
            				    </ul>
            			    </div>
            			    <a href="#" class="button secondary" id="print" onclick="stampaDocumento();"><i class="fa-duotone fa-print fa-lg fa-fw"></i>Stampa</a>
            			    <!-- <a href="/admin/app/documenti/actions/stampa-documento.aspx?Documenti_Ky=<%=GetFieldValue(dtDocumenti, "Documenti_Ky")%>" class="button secondary" id="print" target="blank"><i class="fa-duotone fa-file-pdf fa-lg fa-fw"></i>Stampa pdf</a> -->
            	        <% if (GetFieldValue(dtDocumenti, "Documenti_PDF").Length>0){ %>
                          <a href="/admin/app/documenti/scheda-documenti-email.aspx?Documenti_Ky=<%=GetFieldValue(dtDocumenti, "Documenti_Ky")%>" id="email" class="tiny button secondary"><i class="fa-duotone fa-envelope fa-fw"></i>Invia</a>
            	        <% } %>
                    <% } %>
          			    <button type="submit" value="salva e aggiorna totali" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-fw"></i>Salva</button>
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
  			<input type="hidden" name="Documenti_Ky" id="Documenti_Ky" value="<%=GetFieldValue(dtDocumenti, "Documenti_Ky")%>">
        <!--#include file=/admin/forms_messaggi.inc -->
   			<!--#include file=/admin/app/documenti/forms/documenti_form.htm -->
      </div>
  	</div>
  </div>
</form>  
  					      
	<% if (strAzione!="new"){ %>
	<!--#include file=/admin/app/documenti/scheda-documenti-corpo.inc -->
	<!--#include file=/admin/app/documenti/scheda-documenti-pagamenti.inc -->
	<!--#include file=/admin/app/documenti/scheda-documenti-totali.inc -->
	<!--#include file=/admin/app/documenti/scheda-documenti-attivita.inc -->
	<!--#include file=/admin/app/documenti/scheda-documenti-note.inc -->
	<% } %>
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
