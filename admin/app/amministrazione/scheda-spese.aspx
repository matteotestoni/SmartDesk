<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="scheda-spese.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title><%=strH1%></title>
	<!--#include file="/admin/inc-head.aspx"-->
  <script type="text/javascript" src="/admin/app/amministrazione/amministrazione.js?id=2"></script>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-spesa" action="/admin/crud/salva.aspx" method="post" data-abide novalidate>
      	<div data-sticky-container style="width:100%">
        <div class="content-header sticky" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      		<div class="grid-x grid-padding-x">
      			<div class="large-6 medium-6 small-12 cell">
      				<h1><i role="img" class="<%=dtCoreEntities.Rows[0]["CoreModules_Icon"].ToString()%> fa-fw"></i>
      					<%=dtCurrentCoreForms.Rows[0]["CoreModules_Title"].ToString()%> >
      					<i role="img" class="<%=dtCoreEntities.Rows[0]["CoreEntities_Icon"].ToString()%> fa-fw"></i><%=dtCurrentCoreForms.Rows[0]["CoreForms_Title"].ToString()%>: <span class="badge large secondary"><i role="img" class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtFormsData, dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString())%></span>
      				</h1>
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
  						<% if (boolAdmin==true){ %>
      				<a href="/admin/app/sdk/scheda-coreforms.aspx?CoreModules_Ky=1&CoreForms_Ky=<%=dtCurrentCoreForms.Rows[0]["CoreForms_Ky"].ToString()%>"
      					class="grid-edit-icon secondary" onclick="showFormEditor(this);"><i role="img" class="fa-duotone fa-pen-to-square fa-fw"
      						data-fa-transform="down-2"></i></a>
      							<% } %>
      			</div>
      			<div class="large-6 medium-6 small-12 cell float-right">
            
      					<div class="stacked-for-small button-group small hide-for-print align-right">
      						<a href="<%=strViewUrl%>" class="button clear"><i role="img" class="fa-duotone fa-backward fa-fw"></i>Vai all'elenco</a>
      						<%
      						if (dtCoreFormsButtons.Rows.Count>0){
      							for (int iCoreFormsButtons = 0; iCoreFormsButtons < dtCoreFormsButtons.Rows.Count; iCoreFormsButtons++){ 
      								strAction=dtCoreFormsButtons.Rows[iCoreFormsButtons]["CoreFormsButtons_Action"].ToString();
                      if (strAction.Contains("javascript")){
                          
                      }else{
                          strAction=strAction + "?" + dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString() + "=" + GetFieldValue(dtFormsData, dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString());
                      }
                      %>  
                      <a href="<%=strAction%>" class="button clear" data-number="<%=iCoreFormsButtons%>" data-order="<%=dtCoreFormsButtons.Rows[iCoreFormsButtons]["CoreFormsButtons_Order"].ToString()%>"><i role="img" class="<%=dtCoreFormsButtons.Rows[iCoreFormsButtons]["CoreFormsButtons_Icon"].ToString()%> fa-fw"></i><%=dtCoreFormsButtons.Rows[iCoreFormsButtons]["CoreFormsButtons_Title"].ToString()%></a>
      							<%
      							}
      						}
                  %>
      						<a href="<%=strFormUrl%>&azione=new" class="button"><i role="img" class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
      						<button type="submit" value="salva" name="salva" class="button success"><i role="img" class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
      					</div>
      			</div>
      		</div>
      	</div>
        </div>

  <div class="grid-x grid-padding-x">
    <div class="large-12 medium-12 small-12 cell">
      <div class="divform">
        <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
        <input type="hidden" name="Spese_Ky" id="Spese_Ky" value="<%=GetFieldValue(dtFormsData, "Spese_Ky")%>">
        <input type="hidden" name="CoreModules_Ky" id="CoreModules_Ky" value="2">
        <input type="hidden" name="CoreEntities_Ky" id="CoreEntities_Ky" value="1">
        <input type="hidden" name="CoreForms_Ky" id="CoreForms_Ky" value="211">
        <!--#include file=/admin/forms_messaggi.inc -->
  			<!--#include file=/admin/app/amministrazione/forms/spese_form.htm --> 
      </div>
    </div>
  </div>
</form>

<!--#include file=/admin/app/amministrazione/scheda-spese-pagamenti.inc -->

<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
