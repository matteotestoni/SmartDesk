<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/commerciale/scheda-opportunita.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title><%=strH1%></title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-opportunita" action="/admin/app/commerciale/crud/salva-opportunita.aspx" method="post" data-abide="" novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-5 medium-5 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtOpportunita, "Opportunita_Ky")%></span></h1>
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
          <div class="large-7 medium-7 small-12 cell float-right align-middle">
        			<div class="stacked-for-small button-group small hide-for-print align-right">
        				<a href="/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=138&CoreGrids_Ky=107" class="button clear"><i class="fa-duotone fa-table fa-fw"></i>Vai all'elenco</a>
        				<a href="/admin/app/commerciale/elenco-opportunita-prospetto.aspx" class="button clear"><i class="fa-duotone fa-square-kanban fa-fw"></i>Vai al prospetto</a>
        				<a href="/admin/app/commerciale/scheda-opportunita.aspx?azione=new&Anagrafiche_Ky=<%=strAnagrafiche_Ky%>&sorgente=<%=strSorgente%>" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a> 
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
        <input type="hidden" name="Opportunita_Ky" id="Opportunita_Ky" value="<%=GetFieldValue(dtOpportunita, "Opportunita_Ky")%>">
        <!--#include file=/admin/forms_messaggi.inc -->
  			<!--#include file=/admin/app/commerciale/forms/opportunita_form.htm -->
      </div>
    </div>
  </div>
</form>

<!--#include file=/admin/app/commerciale/scheda-opportunita-preventiviauto.inc -->
<!--#include file=/admin/app/commerciale/scheda-opportunita-attivita.inc -->
<!--#include file=/admin/app/commerciale/scheda-opportunita-documenti.inc -->

<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
