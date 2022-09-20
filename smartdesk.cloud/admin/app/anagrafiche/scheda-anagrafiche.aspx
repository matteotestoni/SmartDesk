<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/anagrafiche/scheda-anagrafiche.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>	
	<title>Anagrafiche > <%=strH1%></title>
	<!--#include file="/admin/inc-head.aspx"-->
	<% if (boolWysiwyg==true){ %>
  	<script src="//cdn.ckeditor.com/4.19.1/full/ckeditor.js"></script>
	<% } %>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 

<form id="form-anagrafiche" action="/admin/app/anagrafiche/crud/salva-anagrafiche.aspx" method="post" enctype="multipart/form-data" data-abide novalidate>
<div data-sticky-container>
	<div class="content-header" id="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
		<div class="grid-x grid-padding-x">
			<div class="large-4 medium-6 small-12 cell">
          <% if (Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Logo").Length>0){ %>
          <h1>
           <% if (dtAnagrafiche.Rows[i]["Anagrafiche_SitoWeb"].ToString().Length>1){ %>
          	<img src="https://www.google.com/s2/favicons?domain=<%=dtAnagrafiche.Rows[i]["Anagrafiche_SitoWeb"].ToString()%>&size=16" width="16" height="16" border="0">
            <% }else{ %>
            <img class="logo" src="<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Logo")%>" height="30" style="height:30px;padding:0;margin:0 5px;" class="text-left">
            <% } %>  
            <%=strH1%>
          	<span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%></span>
          </h1>
          <% }else{ %>
          <h1>
            <% if (Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_SitoWeb").ToString().Length>1){ %>
            <img src="https://www.google.com/s2/favicons?domain=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_SitoWeb")%>" width="16" height="16" border="0">
            <% }else{ %>
            <i class="fa-duotone fa-user fa-fw"></i>
            <% } %>  
            <%=strH1%><span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%></span>
          </h1>
          <% } %>
						<% 
            if (boolCambioForm && dtCoreForms.Rows.Count>1){ %>
    				<a href="#" class="grid-switch-icon secondary" data-toggle="grids-dropdown"><i role="img" class="fa-duotone fa-angle-down fa-lg fa-fw" data-fa-transform="down-4"></i></a>
    					<div class="dropdown-pane" id="grids-dropdown" data-dropdown data-auto-focus="true">
    						<ul class="menu">
              <% 
              for (int i = 0; i < dtCoreForms.Rows.Count; i++){ %>
  						    <li><a href="/admin/form.aspx?CoreModules_Ky=<%=dtCoreForms.Rows[i]["CoreModules_Ky"].ToString()%>&CoreEntities_Ky=<%=dtCoreForms.Rows[i]["CoreEntities_Ky"].ToString()%>&CoreForms_Ky=<%=dtCoreForms.Rows[i]["CoreForms_Ky"].ToString()%>&<%=dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()%>=<%=GetFieldValue(dtFormsData, dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString())%>"><i role="img" class="fa-duotone fa-table fa-fw"></i><%=dtCoreForms.Rows[i]["CoreForms_Title"].ToString()%></a></li>
  						<% 
              }

						  if (boolAdmin==true){ %>
							<li><a href="/admin/app/sdk/scheda-coreforms.aspx?CoreModules_Ky=<%=dtCurrentCoreForms.Rows[0]["CoreModules_Ky"].ToString()%>&CoreEntities_Ky=<%=dtCurrentCoreForms.Rows[0]["CoreEntities_Ky"].ToString()%>&CoreForms_Ky=<%=dtCurrentCoreForms.Rows[0]["CoreForms_Ky"].ToString()%>"><i role="img" class="fa-duotone fa-pen-to-square fa-fw"></i>Personalizza form</a></li>
							<li><a href="/admin/app/sdk/scheda-coreforms.aspx?CoreModules_Ky=<%=dtCurrentCoreForms.Rows[0]["CoreModules_Ky"].ToString()%>&CoreEntities_Ky=<%=dtCurrentCoreForms.Rows[0]["CoreEntities_Ky"].ToString()%>&CoreForms_Ky=<%=dtCurrentCoreForms.Rows[0]["CoreForms_Ky"].ToString()%>"><i role="img" class="fa-duotone fa-square-plus fa-fw"></i>Nuovo form</a></li>
							<%
              } %>
  						</ul>
  					</div>
            <% } %>
      </div>
			<div class="large-8 medium-6 small-12 cell float-right">

    			<div class="stacked-for-small button-group small hide-for-print align-right">
    		    <a href="/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
    		    <% if (boolAdmin && strAzione!="new"){ %>
      		    <% if (GetCheckValue(dtAnagrafiche, "Anagrafiche_Lock")){ %>
    			    <a href="/admin/app/anagrafiche/actions/lock-anagrafica.aspx?Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&lock=0&sorgente=scheda-anagrafiche" class="button clear"><i class="fa-duotone fa-pen-to-square fa-fw"></i>modifica</a>
    			    <% }else{ %>
    			    <a href="/admin/app/anagrafiche/actions/lock-anagrafica.aspx?Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>&lock=1&sorgente=scheda-anagrafiche" class="button clear" id="lock"><i class="fa-duotone fa-lock fa-fw"></i>blocca</a>
    			    <% if (boolAdmin && strAzione!="new"){ %>
    			    <a href="/admin/app/anagrafiche/crud/elimina-anagrafiche.aspx?azione=delete&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>" class="button clear"><i class="fa-duotone fa-trash-can fa-fw"></i>elimina</a>
    			    <% } %>
    			    <% } %>
    		    <% } %>
    		    <% if (boolAdmin && strAzione!="new"){ %>
    		    <a href="/admin/app/anagrafiche/report/rpt-scheda-anagrafiche.aspx?Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>" target="_blank" class="button clear" id="print"><i class="fa-duotone fa-print fa-fw"></i>stampa</a>
    		    <% } %>
    				<% if (strAzione!="new"){ %>
      			<a href="/admin/form.aspx?CoreModules_Ky=1&CoreEntities_Ky=26&CoreForms_Ky=107&azione=new&sorgente=scheda-anagrafiche&Anagrafiche_Ky=<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>" class="tiny button clear"><i class="fa-duotone fa-square-plus fa-fw"></i>nuovo indirizzo</a>
    		    <a href="/admin/goto-form.aspx?CoreEntities_Ky=162&azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a> 
    				<% } %>
    				<button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
    	    </div>
			</div>
		</div>
	</div>
</div>
  
  <div data-sticky-container class="hide">  
  		<div class="grid-x grid-padding-x" data-sticky  data-stick-to="bottom" data-top-anchor="content-header" data-btm-anchor="footer:top" id="magellan">
  			<div class="large-12 medium-12 small-12 cell">
             <ul class="menu horizontal" data-magellan>
              <li><a href="#divscheda" class="">Scheda</a></li>
              <li><a href="#divticket" class="">Ticket</a></li>
              <li><a href="#divannunci" class="">Annunci</a></li>
              <li><a href="#divservizi" class="">Servizi</a></li>
            </ul>
        </div>
      </div>  
  </div>
   
  
  <div class="grid-container">
 		<div class="divform" id="divscheda" data-magellan-target="divscheda">
      <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
			<input type="hidden" name="Utenti_Ky" id="Utenti_Ky" value="<%=Smartdesk.Session.CurrentUser.ToString()%>">
			<input type="hidden" name="Anagrafiche_Ky" id="Anagrafiche_Ky" value="<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Ky")%>">
      <!--#include file=/admin/forms_messaggi.inc -->
		  <!--#include file=/admin/app/anagrafiche/forms/anagrafiche_form.htm -->
  	</div>
  </div>
</form>

<!--#include file=/admin/app/anagrafiche/scheda-anagrafiche-ticket.inc -->
<!--#include file=/admin/app/anagrafiche/scheda-anagrafiche-progetti.inc -->
<!--#include file=/admin/app/anagrafiche/scheda-anagrafiche-annunci.inc -->
<!--#include file=/admin/app/anagrafiche/scheda-anagrafiche-servizi.inc -->
<!--#include file=/admin/app/anagrafiche/scheda-anagrafiche-prodotti.inc -->
<!--#include file=/admin/app/anagrafiche/scheda-anagrafiche-sitiweb.inc -->
<!--#include file=/admin/app/anagrafiche/scheda-anagrafiche-password.inc -->
<!--#include file=/admin/app/anagrafiche/scheda-anagrafiche-attivita.inc -->
<!--#include file=/admin/app/anagrafiche/scheda-anagrafiche-documenti.inc -->
<!--#include file=/admin/app/anagrafiche/scheda-anagrafiche-pagamenti.inc -->
<!--#include file=/admin/app/anagrafiche/scheda-anagrafiche-spese.inc -->
<!--#include file=/admin/app/anagrafiche/scheda-anagrafiche-contatti.inc -->
<!--#include file=/admin/app/anagrafiche/scheda-anagrafiche-note.inc -->
<!--#include file=/admin/app/anagrafiche/scheda-anagrafiche-officina.inc -->


<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
