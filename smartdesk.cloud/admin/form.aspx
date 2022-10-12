<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/form.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title><%=strH1%></title>
	<!--#include file="/admin/inc-head.aspx"-->
	<% if (boolWysiwyg==true){ %>
  	<script src="//cdn.ckeditor.com/4.19.1/full/ckeditor.js"></script>
	<% } %>
	<script src="/admin/app/<%=dtCoreModules.Rows[0]["CoreModules_Code"].ToString()%>/<%=dtCoreModules.Rows[0]["CoreModules_Code"].ToString()%>.js?id=<%=new Random().Next(0, 100)%>"></script>
</head>
<body class="form <%=dtCoreModules.Rows[0]["CoreModules_Code"].ToString()%>">
<!--#include file=/admin/inc-mainbar.aspx -->    
      	<form id="form-<%=dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString()%>"
      		action="<%=strFormAction%>"
      		enctype="multipart/form-data"
      		method="post" data-abide novalidate>
      	<header data-sticky-container style="width:100%">
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
        </header>
        
      <section class="grid-x grid-padding-x">
        <% if (dtCoreEntities.Rows[0]["CoreEntities_Config"].Equals(true) && boolAdmin==true){ %>
          <aside class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only">
          	<!--#include file=/admin/impostazioni-sidebar.aspx -->
          </aside>
          <div class="large-10 medium-10 small-12 cell">
        <% }else{ %>
        	<div class="large-12 medium-12 small-12 cell"> 
        <% } %>
              <div class="divform">
      					<input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
      					<input type="hidden" name="sorgente" id="sorgente" value="<%=strSorgente%>">
      					<input type="hidden" name="<%=dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()%>" id="<%=dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()%>" value="<%=GetFieldValue(dtFormsData, dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString())%>">
      					<input type="hidden" name="CoreModules_Ky" id="CoreModules_Ky" value="<%=intCoreModules_Ky%>">
      					<input type="hidden" name="CoreEntities_Ky" id="CoreEntities_Ky" value="<%=intCoreEntities_Ky%>">
      					<input type="hidden" name="CoreGrids_Ky" id="CoreGrids_Ky" value="<%=intCoreGrids_Ky%>">
      					<input type="hidden" name="CoreForms_Ky" id="CoreForms_Ky" value="<%=intCoreForms_Ky%>">
      					<% if (dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()!="Utenti_Ky"){ %>
                <input type="hidden" name="Utenti_Ky" id="Utenti_Ky" value="<%=Smartdesk.Session.CurrentUser.ToString()%>">
                <% } %>
      					<!--#include file=/admin/forms_messaggi.inc -->
      					<div class="formedit">
      						<% 
      			      if (dtCurrentCoreForms.Rows[0]["CoreForms_WhichFields"].ToString()=="1"){
      			        strWHERENet="CoreAttributes_System<>1 AND CoreAttributes_Key<>1 AND CoreAttributes_Code<>'" + dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString() + "'  AND CoreEntities_Ky=" + dtCoreEntities.Rows[0]["CoreEntities_Ky"].ToString();
      			        strORDERNet = "CoreAttributes_Order, CoreAttributes_Code";
      			        strFROMNet = "CoreAttributes_Vw";
      			        dtCoreAttributes = new System.Data.DataTable("CoreAttributes");
      			        dtCoreAttributes = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreAttributes_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      			        if (dtCoreAttributes.Rows.Count>0){
      			        		for (int iCoreAttributes = 0; iCoreAttributes < dtCoreAttributes.Rows.Count; iCoreAttributes++){
      			              Response.Write("<div class=\"grid-x grid-padding-x\" data-columns=\"12\">");
                          RenderField(dtCoreAttributes.Rows[iCoreAttributes], 12);
      			              Response.Write("</div>");
      			  					}
      			  			}
      			      }else{
      			        if (dtCoreFormsTabs.Rows.Count>1){
      			          Response.Write("<ul class=\"horizontal tabs\" data-responsive-accordion-tabs=\"tabs small-accordion medium-tabs large-tabs\" role=\"tablist\" id=\"anagrafica-tabs\">");
      			          for (int iCoreFormsTabs = 0; iCoreFormsTabs < dtCoreFormsTabs.Rows.Count; iCoreFormsTabs++){
      			    		    if (iCoreFormsTabs==0){
      			              strActive=" is-active";
      			            }else{
      			              strActive="";
      			            }
      			            Response.Write("<li class=\"tabs-title" + strActive + "\" role=\"presentational\"><a href=\"#tabs-" + dtCoreFormsTabs.Rows[iCoreFormsTabs]["CoreFormsTabs_Ky"].ToString() + "\"><i role=\"img\" class=\"" + dtCoreFormsTabs.Rows[iCoreFormsTabs]["CoreFormsTabs_Icon"].ToString() + " fa-lg fa-fw\"></i>" + dtCoreFormsTabs.Rows[iCoreFormsTabs]["CoreFormsTabs_Title"].ToString() + "</a></li>");
      								}
      			          Response.Write("</ul>");
      			          Response.Write("<div class=\"tabs-content\" data-tabs-content=\"anagrafica-tabs\">");
      			          for (int iCoreFormsTabs = 0; iCoreFormsTabs < dtCoreFormsTabs.Rows.Count; iCoreFormsTabs++){
      			    		    if (iCoreFormsTabs==0){
      			              strActive=" is-active";
      			            }else{
      			              strActive="";
      			            }
      			    				Response.Write("<section role=\"tabpanel\" aria-hidden=\"false\" class=\"tabs-panel" + strActive + "\" id=\"tabs-" + dtCoreFormsTabs.Rows[iCoreFormsTabs]["CoreFormsTabs_Ky"].ToString() + "\" name=\"tabs-" + dtCoreFormsTabs.Rows[iCoreFormsTabs]["CoreFormsTabs_Ky"].ToString() + "\">");
      			                strWHERENet="(CoreForms_Ky=" + intCoreForms_Ky + " AND CoreFormsTabs_Ky=" + dtCoreFormsTabs.Rows[iCoreFormsTabs]["CoreFormsTabs_Ky"].ToString() + ")";
      			        				strFROMNet = "CoreFormsFieldset";
      			        				strORDERNet = "CoreFormsFieldset_Order";
      			        				dtCoreFormsFieldset = new System.Data.DataTable("CoreFormsFieldset");
      			        				dtCoreFormsFieldset = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsFieldset_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      			                if (dtCoreFormsFieldset.Rows.Count>1){
                                for (int iCoreFormsFieldset = 0; iCoreFormsFieldset < dtCoreFormsFieldset.Rows.Count; iCoreFormsFieldset++){
  			                          Response.Write("<fieldset class=\"fieldset\"><legend>" + dtCoreFormsFieldset.Rows[iCoreFormsFieldset]["CoreFormsFieldset_Title"].ToString() + "</legend>");
  			                          strWHERENet="CoreAttributes_Key<>1 AND CoreAttributes_Code<>'" + dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString() + "' AND CoreEntities_Ky=" + dtCoreEntities.Rows[0]["CoreEntities_Ky"].ToString() + " AND CoreForms_Ky=" + intCoreForms_Ky + " AND CoreFormsFieldset_Ky=" + dtCoreFormsFieldset.Rows[iCoreFormsFieldset]["CoreFormsFieldset_Ky"].ToString() ;
  			                          //Response.Write(strWHERENet);
  			                          strORDERNet = "CoreFormsFields_Order, CoreAttributes_Order, CoreAttributes_Code";
  			                          strFROMNet = "CoreFormsFields_Vw";
  			                          dtCoreFormsFields = new System.Data.DataTable("CoreFormsFields");
  			                          dtCoreFormsFields = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsFields_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  			                          if (dtCoreFormsFields.Rows.Count>0){
                                    CiclaCoreFormsFields();
  			                    			}
  			                          Response.Write("</fieldset>");
  			                        }
      			                }else{
                                strWHERENet="CoreAttributes_Key<>1 AND CoreAttributes_Code<>'" + dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString() + "'  AND CoreEntities_Ky=" + dtCoreEntities.Rows[0]["CoreEntities_Ky"].ToString() + " AND CoreForms_Ky=" + intCoreForms_Ky + " AND CoreFormsTabs_Ky=" + dtCoreFormsTabs.Rows[iCoreFormsTabs]["CoreFormsTabs_Ky"].ToString() ;
			                          strORDERNet = "CoreFormsFields_Order, CoreAttributes_Order, CoreAttributes_Code";
			                          strFROMNet = "CoreFormsFields_Vw";
                                dtCoreFormsFields = new System.Data.DataTable("CoreFormsFields");
			                          dtCoreFormsFields = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsFields_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			                          if (dtCoreFormsFields.Rows.Count>0){
	                		              CiclaCoreFormsFields();
			                    			}
      			
      			                }   
      			    				Response.Write("</section>");
      								}
      			          Response.Write("</div>");
      			        }else{
      			          if (dtCoreFormsFieldset.Rows.Count>0){
      			              for (int iCoreFormsFieldset = 0; iCoreFormsFieldset < dtCoreFormsFieldset.Rows.Count; iCoreFormsFieldset++){
      			                Response.Write("<fieldset class=\"fieldset\"><legend>" + dtCoreFormsFieldset.Rows[iCoreFormsFieldset]["CoreFormsFieldset_Title"].ToString() + "</legend>");
      			                strWHERENet="CoreAttributes_Key<>1 AND CoreAttributes_Code<>'" + dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString() + "' AND CoreEntities_Ky=" + dtCoreEntities.Rows[0]["CoreEntities_Ky"].ToString() + " AND CoreForms_Ky=" + intCoreForms_Ky + " AND CoreFormsFieldset_Ky=" + dtCoreFormsFieldset.Rows[iCoreFormsFieldset]["CoreFormsFieldset_Ky"].ToString() ;
      			                strORDERNet = "CoreFormsFields_Order, CoreAttributes_Order, CoreAttributes_Code";
      			                strFROMNet = "CoreFormsFields_Vw";
      			                dtCoreFormsFields = new System.Data.DataTable("CoreFormsFields");
      			                dtCoreFormsFields = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsFields_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      			                if (dtCoreFormsFields.Rows.Count>0){
      			                		CiclaCoreFormsFields();
      			          			}
      			                Response.Write("</fieldset>");
      			              }
      			          
      			          }else{

  			                strWHERENet="CoreAttributes_Key<>1 AND CoreAttributes_Code<>'" + dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString() + "' AND CoreEntities_Ky=" + dtCoreEntities.Rows[0]["CoreEntities_Ky"].ToString() + " AND CoreForms_Ky=" + intCoreForms_Ky;
  			                strORDERNet = "CoreFormsFields_Order, CoreAttributes_Order, CoreAttributes_Code";
  			                strFROMNet = "CoreFormsFields_Vw";
  			                dtCoreFormsFields = new System.Data.DataTable("CoreFormsFields");
  			                dtCoreFormsFields = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsFields_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  			                if (dtCoreFormsFields.Rows.Count>0){
  			                		CiclaCoreFormsFields();
  			          			}

      			            /*
                        strWHERENet="CoreAttributes_System<>1 AND CoreAttributes_Key<>1 AND CoreAttributes_Code<>'" + dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString() + "' AND CoreEntities_Ky=" + dtCoreEntities.Rows[0]["CoreEntities_Ky"].ToString() + " AND CoreForms_Ky=" + intCoreForms_Ky;
      			            strORDERNet = "CoreFormsFields_Order, CoreAttributes_Order, CoreAttributes_Code";
      			            strFROMNet = "CoreFormsFields_Vw";
      			            dtCoreAttributes = new System.Data.DataTable("CoreAttributes");
      			            dtCoreAttributes = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreAttributes_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      			            if (dtCoreAttributes.Rows.Count>0){
  			                		intTotalColumns=0;
      			            		for (int iCoreAttributes = 0; iCoreAttributes < dtCoreAttributes.Rows.Count; iCoreAttributes++){
                                  Response.Write("<span data-columns=\"" + Convert.ToInt32(dtCoreAttributes.Rows[iCoreAttributes]["CoreFormsFields_Columns"]) + "\" data-totalcolumns=\"" + intTotalColumns + "\"></span>");
                                    if (intTotalColumns==0){
                                      Response.Write("<div class=\"grid-x grid-padding-x\" data-columns=\"" + Convert.ToInt32(dtCoreAttributes.Rows[iCoreAttributes]["CoreFormsFields_Columns"]) + "\" data-totalcolumns=\"" + intTotalColumns + "\">");
                                      RenderField(dtCoreAttributes.Rows[iCoreAttributes],Convert.ToInt32(dtCoreAttributes.Rows[iCoreAttributes]["CoreFormsFields_Columns"]));
                                    }
                                    if (intTotalColumns==6){
                                      RenderField(dtCoreAttributes.Rows[iCoreAttributes],Convert.ToInt32(dtCoreAttributes.Rows[iCoreAttributes]["CoreFormsFields_Columns"]));
                                    }
                                    if (intTotalColumns==12){
                                      intTotalColumns=0;
                                      Response.Write("</div><div class=\"grid-x grid-padding-x\" data-columns=\"" + Convert.ToInt32(dtCoreAttributes.Rows[iCoreAttributes]["CoreFormsFields_Columns"]) + "\" data-totalcolumns=\"" + intTotalColumns + "\">");
                                      RenderField(dtCoreAttributes.Rows[iCoreAttributes],Convert.ToInt32(dtCoreAttributes.Rows[iCoreAttributes]["CoreFormsFields_Columns"]));
                                    }
  	                                intTotalColumns+=Convert.ToInt32(dtCoreAttributes.Rows[iCoreAttributes]["CoreFormsFields_Columns"]);
      			      				}
      			      			}*/
                        
                        
                        
                        
      			          }
      			        
      			        
      			        }
      			
      			      }
            %>
      					</div>
      			</div>
      		</div>
        </div>
        </section>
      	</form>
      
      	<%
      	if (dtCoreFormsRelations.Rows.Count>0 && strAzione!="new"){
      		for (int iCoreFormsRelations = 0; iCoreFormsRelations < dtCoreFormsRelations.Rows.Count; iCoreFormsRelations++){
              strWHERENet="(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreGrids_Ky=" + dtCoreFormsRelations.Rows[iCoreFormsRelations]["CoreGrids_Ky"].ToString() + ")";
          		strFROMNet = "UsergroupsGrids_Vw";
          		strORDERNet = "CoreGrids_Ky";
          		dtCurrentCoreGrids = new System.Data.DataTable("CurrentCoreGrids");
          		dtCurrentCoreGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGrids_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  
                  if (dtCurrentCoreGrids.Rows.Count>0){
                    strWHERENet="(CoreEntities_Ky=" + dtCurrentCoreGrids.Rows[0]["CoreEntities_Ky"].ToString() + ")";
                    strFROMNet = "CoreEntities";
                    strORDERNet = "CoreEntities_Ky";
                    dtCoreEntitiesGrid = new System.Data.DataTable("CoreEntities");
                    dtCoreEntitiesGrid = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                    
                    strWHERENet="(CoreModules_Ky=" + dtCoreEntitiesGrid.Rows[0]["CoreModules_Ky"].ToString() + ")";
                    strFROMNet = "CoreModules";
                    strORDERNet = "CoreModules_Ky";
                    dtCoreModulesGrid = new System.Data.DataTable("CoreModules");
                    dtCoreModulesGrid = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModules_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      
                    intRecxPag = Convert.ToInt32(dtCurrentCoreGrids.Rows[0]["CoreGrids_Rows"].ToString());
                    strWHERENet = "(CoreGrids_Ky=" + dtCoreFormsRelations.Rows[iCoreFormsRelations]["CoreGrids_Ky"].ToString() + ")";
                    strFROMNet = "CoreGridsButtons";
                    strORDERNet = "CoreGridsButtons_Ky";
                    dtCoreGridsButtons = new  System.Data.DataTable("CoreGridsButtons");
                    dtCoreGridsButtons = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGridsButtons_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                    if (dtCurrentCoreGrids.Rows[0]["CoreGrids_Custom"].Equals(true)){
                      strViewUrl="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreEntitiesGrid.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1";
                    }else{
                      strViewUrl="/admin/view.aspx?CoreModules_Ky=" + intCoreModules_Ky + "&CoreEntities_Ky=" + intCoreEntities_Ky + "&CoreGrids_Ky=" + dtCoreFormsRelations.Rows[iCoreFormsRelations]["CoreGrids_Ky"].ToString() + "&custom=0";
                    }
                		strWHERENet="(CoreGrids_Ky=" + dtCoreFormsRelations.Rows[iCoreFormsRelations]["CoreGrids_Ky"].ToString() + ")";
                		strFROMNet = "CoreGridsColumns_Vw";
                		strORDERNet = "CoreGridsColumns_Order ASC";
                		dtCoreGridsColumns = new System.Data.DataTable("CoreGridsColumns");
                		dtCoreGridsColumns = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGridsColumns_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      intPage = 1;
              		strWHERENet = dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()+"=" + GetFieldValue(dtFormsData, dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString());
          			strORDERNet = dtCurrentCoreGrids.Rows[0]["CoreGrids_SQLOrder"].ToString();
          			strFROMNet = dtCurrentCoreGrids.Rows[0]["CoreGrids_SQLFrom"].ToString();
          			dtGridData = new System.Data.DataTable("GridData");
          			dtGridData = Smartdesk.Sql.getTablePage(strFROMNet, null, dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString(), strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          			strPaginationId="pagination-" + dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString();
                      //strPaginationText = Smartdesk.Grid.getPagination(dtGridData,System.IO.Path.GetFileName(Request.Url.AbsolutePath), intRecxPag,intNumRecords, intPage,Request.QueryString);						            
          			strPathWhere=Server.MapPath("/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/where/where-" + dtCoreEntitiesGrid.Rows[0]["CoreEntities_Code"].ToString() + ".inc");
          			dtGridDataChildren = new System.Data.DataTable("dtGridDataChildren");
      
      				if (dtCurrentCoreGrids.Rows[0]["CoreForms_Ky"].ToString().Length>0){
                        //form predefinito
                        intCoreForms_Ky=Convert.ToInt32(dtCurrentCoreGrids.Rows[0]["CoreForms_Ky"]);  
                        strWHERENet="(CoreForms_Ky=" + intCoreForms_Ky + ")";
                    }else{
                        //prendo il form default
                        strWHERENet="(CoreEntities_Ky=" + dtCurrentCoreGrids.Rows[0]["CoreEntities_Ky"].ToString() + ")";
                    }
											strFROMNet = "CoreForms_Vw";
											strORDERNet = "CoreForms_Default DESC, CoreForms_Ky DESC";
											dtCoreFormsGrid = new System.Data.DataTable("CoreFormsGrid");
											dtCoreFormsGrid = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreForms_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
											if (dtCoreFormsGrid.Rows.Count>0){
                        intCoreForms_Ky=Convert.ToInt32(dtCoreFormsGrid.Rows[0]["CoreForms_Ky"]);
                        if (dtCoreFormsGrid.Rows[0]["CoreForms_Custom"].Equals(true)){
                          strFormUrl="/admin/app/" + dtCoreModulesGrid.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreEntitiesGrid.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreModules_Ky=" + dtCurrentCoreGrids.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCurrentCoreGrids.Rows[0]["CoreEntities_Ky"].ToString() + "&CoreGrids_Ky=" + dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString() + "&CoreForms_Ky=" + intCoreForms_Ky + "&sorgente=form-" + dtCoreForms.Rows[i]["CoreForms_Ky"].ToString();
                        }else{
                          strFormUrl="/admin/form.aspx?CoreModules_Ky=" + dtCurrentCoreGrids.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCurrentCoreGrids.Rows[0]["CoreEntities_Ky"].ToString() + "&CoreGrids_Ky=" + dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString() + "&CoreForms_Ky=" + intCoreForms_Ky + "&custom=0" + "&sorgente=form-" + dtCoreForms.Rows[i]["CoreForms_Ky"].ToString();
                        }
                      }else{
                        strFormUrl="/admin/app/" + dtCoreModulesGrid.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreEntitiesGrid.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1" + "&sorgente=form-" + dtCoreForms.Rows[i]["CoreForms_Ky"].ToString();
                      }                    
                  %>
                      <div class="grid-x grid-padding-x">
                    		<div class="large-12 medium-12 small-12 cell">
                          <div class="divgrid"  id="grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>">
                            <div class="grid-x grid-padding-x">
                              <div class="large-9 medium-9 small-12 cell">
                                <h2><i class="<%=dtCurrentCoreGrids.Rows[0]["CoreEntities_Icon"].ToString()%>" fa-lg fa-fw"></i><%=dtCurrentCoreGrids.Rows[0]["CoreEntities_LabelPlural"].ToString()%> (<%=dtGridData.Rows.Count%>)&nbsp;&nbsp;<a href="<%=strFormUrl%>&azione=new&<%=dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()+"=" + GetFieldValue(dtFormsData, dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString())%>" class="small secondary button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Aggiungi nuovo</a></h2>      				            
                              </div>
                              <div class="large-3 medium-3 small-12 cell">
                                <form name="azionidigruppo-form" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>" class="form-azione" method="post" action="#">
                                <div class="input-group">
                                  <select class="input-group-field" name="azionidigruppo" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-azionidigruppo">
                                    <option value="">Azioni di gruppo</option>
                                    <option value="delete" data-action="/admin/app/<%=dtCoreModulesGrid.Rows[0]["CoreModules_Code"].ToString()%>/crud/elimina-<%=dtCoreEntitiesGrid.Rows[0]["CoreEntities_Code"].ToString()%>.aspx">Elimina</option>
                                  </select>
                                  <div class="input-group-button">
																		<input type="hidden" name="grid" value="table<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>">
																		<input type="hidden" id="<%=dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()%>" name="<%=dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()%>" value="<%=GetFieldValue(dtFormsData, dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString())%>">
																		<input type="hidden" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-sorgente" name="sorgente" value="scheda-<%=dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString()%>">
                                    <input type="hidden" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-azione" name="azione" value="">
                                    <input type="hidden" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-deletemultiplo" name="deletemultiplo" value="deletemultiplo">
                                    <input type="hidden" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-azionidigruppo-ids" name="azionidigruppo-ids" value="">
                                    <input type="hidden" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-CoreModules_Ky" name="CoreModules_Ky" value="<%=dtCurrentCoreGrids.Rows[0]["CoreModules_Ky"].ToString()%>">
                                    <input type="hidden" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-CoreEntities_Ky" name="CoreEntities_Ky" value="<%=dtCurrentCoreGrids.Rows[0]["CoreEntities_Ky"].ToString()%>">
                                    <input type="hidden" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-CoreGrids_Ky" name="CoreGrids_Ky" value="<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%> ">
                                    <input type="submit" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-doaction" class="button secondary doaction" value="Applica">
                                  </div>
                                </div>
                                </form>
                            </div>
                          </div>
                  			
                  	    <table id="table<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>" class="grid hover scroll" id="griddatatables">
                  	    	<thead>
                  	      <tr>
                          	<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
                  		    	<% 
                  						for (int iCoreGridsColumns = 0; iCoreGridsColumns < dtCoreGridsColumns.Rows.Count; iCoreGridsColumns++){
                  							   switch (dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributesType_Code"].ToString()){
                  								case "text":
                  										switch (dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributesFormat_Code"].ToString()){
                  											case "icon":
                  					  				           Response.Write("<th class=\"text-center " + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[iCoreGridsColumns]) + "</th>");
                  											   break;
                  											case "color":
                  					  				           Response.Write("<th class=\"text-center " + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[iCoreGridsColumns]) + "</th>");
                  											   break;
                  											case "text":
                  					  				           Response.Write("<th class=\"text-left " + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[iCoreGridsColumns]) + "</th>");
                  											   break;
                  											case "image":
                  					  				           Response.Write("<th class=\"text-center " + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[iCoreGridsColumns]) + "</th>");
                  											   break;
                  											case "link":
                  					  				           Response.Write("<th class=\"text-left " + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[iCoreGridsColumns]) + "</th>");
                  											   break;
                  											case "email":
                  					  				           Response.Write("<th class=\"text-left " + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[iCoreGridsColumns]) + "</th>");
                  											   break;
                  											case "phone":
                  					  				          Response.Write("<th class=\"text-left " + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[iCoreGridsColumns]) + "</th>");
                  											  break;
                  											case "password":
                  					  				          Response.Write("<th class=\"text-left " + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[iCoreGridsColumns]) + "</th>");
                  											  break;
                  											default:
                  					  				    Response.Write("<th class=\"text-left " + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[iCoreGridsColumns]) + "</th>");
                  											  break;
                                                }
                  									break;
                  								case "textarea":
                  					  				Response.Write("<th class=\"text-left " + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[iCoreGridsColumns]) + "</th>");
                  									break;
                  								case "data":
                  					  				Response.Write("<th class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[iCoreGridsColumns]) + "</th>");
                  									break;
                  								case "number":
                  					  				Response.Write("<th class=\"text-right " + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreGridsColumns_Width"].ToString() + "\" style=\"width:40px\" title=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[iCoreGridsColumns]) + "</th>");
                  									break;
                  								case "checkbox":
                  					  				Response.Write("<th class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[iCoreGridsColumns]) + "</th>");
                  									break;
                  								default:
                  					  				Response.Write("<th class=\"text-left " + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[iCoreGridsColumns]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[iCoreGridsColumns]) + "</th>");
                  									break;
                  							}
                  						}
                  					 %>
                          	<th width="40"></th>
                  	      </tr>
                  		   </thead>
                  		   <tbody>
                  		    <% for (int iGridData = 0; iGridData < dtGridData.Rows.Count; iGridData++){ %>
                  		        <tr id="record<%=i%>">
                  		          <td width="10"><input type="checkbox" class="checkrow" id="record<%=dtGridData.Rows[iGridData][dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString()].ToString()%>" data-value="<%=dtGridData.Rows[iGridData][dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString()].ToString()%>" /></td>
                  							<%
                  							for (int j = 0; j < dtCoreGridsColumns.Rows.Count; j++){
                  								if (dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString().ToLower()==dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString().ToLower() || dtCoreGridsColumns.Rows[j]["CoreGridsColumns_Link"].Equals(true)){
                  									strFieldValue="<td>";
                  									strFieldValue+="<a href=\"" + strFormUrl;
                  									strFieldValue+="&azione=edit";
                  									strFieldValue+="&" + dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString() + "=" + dtGridData.Rows[iGridData][dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString()].ToString();
                  									strFieldValue+="\" title=\"modifica\" class=\"edit\">";
                                                    switch (dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString()){
                  										case "icon":
                  									   strFieldValue+="<i class=\"" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + " fa-fw\"></i>";
                  										  break;
                  										case "color":
                  									    strFieldValue+="<div style=\"border:1px solid #000000;width:100%;height:20px;background-color:" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\"></div>";
                  										  break;
                  										case "text":
                  									      strFieldValue+="<i class=\"fa-duotone fa-file-lines fa-fw\"></i>" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString();
                  										  break;
                  										case "password":
                  									      strFieldValue+="<i class=\"fa-duotone fa-file-lines fa-fw\"></i><input type=\"password\" value=\"" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "\">";
                  										  break;
                  										case "image":
                  									    if (dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString().Length>0){
                                                              strFieldValue+="<img src=\"" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\" border=\"0\" width=\"100%\" width=\"30\" height=\"30\" style=\"width:30px;height:30px\">";
                                                        }
                  										  break;
                  										default:
                  									    strFieldValue+=dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString();
                  										  break;
                                                    }
                  									strFieldValue+="</a>";
                  									strFieldValue+="</td>";
                  									Response.Write(strFieldValue);
                  								}else{
                  							  	if (dtCoreGridsColumns.Rows[j]["CoreGridsColumns_Renderer"].ToString().Length<1){
                        										switch (dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString()){
                        											case "text":
                              										switch (dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString()){
                              											case "icon":
                        													    Response.Write("<td class=\"text-center " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + " fa-fw\"></i></td>");
                            												  break;
                              											case "color":
                        													    Response.Write("<td class=\"text-center " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><div style=\"border:1px solid #000000;width:100%;height:20px;background-color:" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\"></div></td>");
                            												  break;
                              											case "text":
                        													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-file-lines fa-fw\"></i>" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "</td>\n");
                            												  break;
                              											case "password":
                        													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-file-lines fa-fw\"></i><span id=\"passwordgrid" + iGridData + "\" class=\"passwordgrid\" data-password=\"" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "\">xxxxxxxxxxxxxxx</span><a><i onclick=\"showPasswordGrid('passwordgrid" + iGridData + "')\" class=\"fa-duotone fa-eye fa-fw\"></i></a><a><i onclick=\"copyToClipboard('passwordgrid" + iGridData + "',false)\" class=\"fa-duotone fa-copy fa-fw\"></i></a></td>\n");
                            												  break;
                              											case "phone":
                        													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><a href=\"tel:" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\"><i class=\"fa-duotone fa-phone fa-fw\"></i>" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "</a></td>\n");
                            												  break;
                              											case "email":
                        													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><a href=\"mailto:" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\"><i class=\"fa-duotone fa-envelope fa-fw\"></i>" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "</a></td>\n");
                            												  break;
                              											case "link":
                        													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><a href=\"" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\" target=\"_blank\"><i class=\"fa-duotone fa-up-right-from-square fa-fw\"></i>" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "</a></td>\n");
                            												  break;
                              											case "image":
                        													    if (dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString().Length>0){
                                                        Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><img src=\"" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\" border=\"0\" height=\"30\" style=\"max-width:100px;height:30px;max-height:30px\"></td>\n");
                                                      }else{
                                                        Response.Write("<td></td>");
                                                      }
                            												  break;
                              											default:
                        													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\">" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "</td>\n");
                            												  break;
                                                  }
                        												  break;
                        											case "textarea":
                        													Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-file-lines fa-fw\"></i>" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "</td>\n");
                        												  break;
                        											case "data":
                              										if (dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString().Length>=10){
                  																	switch (dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString()){
                  	            											case "date":
                  	      															Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-calendar-days fa-fw\"></i>" + Convert.ToDateTime(dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()]).ToString("dd/MM/yyyy") + "</td>\n");
                  	          												  break;
                  	            											case "datetime":
                  	      															Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-calendar-days fa-fw\"></i>" + Convert.ToDateTime(dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()]).ToString("dd/MM/yyyy HH:mm tt") + "</td>\n");
                  	      												  		break;
                  	            											default:
                  	      															Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-calendar-days fa-fw\"></i>" + Convert.ToDateTime(dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()]).ToString("dd/MM/yyyy") + "</td>\n");
                  	          												  break;
                  	      												  }
                        												  }else{
                  																 	Response.Write("<td></td>\n");
                  																}
                        												  break;
                        											case "number":
                              										switch (dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString()){
                              											case "number":
                        													    Response.Write("<td class=\"text-right " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\">" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "</td>\n");
                            												  break;
                              											case "integer":
                        													    Response.Write("<td class=\"text-right " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\">" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "</td>\n");
                            												  break;
                              											case "percent":
                                                       Response.Write("<td class=\"text-left\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\">");
                                    									 Response.Write("<div style=\"margin-top:5px\" class=\"progress success\" role=\"progressbar\" tabindex=\"0\" aria-valuenow=\"" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "\" aria-valuemin=\"0\" aria-valuetext=\"" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "%\" aria-valuemax=\"100\">");
                                    									 Response.Write("<span class=\"progress-meter\" style=\"width:" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "%\">");
                                    									 Response.Write("<p class=\"progress-meter-text\">" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "%</p>");
                                    									 Response.Write("</span>");
                                    									 Response.Write("</div>");
                        													     Response.Write("</td>\n");
                            												  break;
                              											default:
                        													    Response.Write("<td class=\"text-right " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\">" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "</td>");
                            												  break;
                                                  }
                        												break;
                        											case "checkbox":
                        												if (dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].Equals(true) || dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()=="True" || dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()=="si"  ){
                        													Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-check fa-lg fa-fw\" style=\"--fa-primary-color:green;--fa-primary-opacity: 1.0\"></i></td>");
                        												}else{
                        													Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-xmark fa-lg fa-fw\" style=\"--fa-secondary-color:red;--fa-secondary-opacity: 1.0\"></i></td>");
                        												}
                        												break;
                        											default:
                        												Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\">" + dtGridData.Rows[iGridData][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "</td>");
                        												break;
                        										}
                  									}else{
                  										strRenderer=dtCoreGridsColumns.Rows[j]["CoreGridsColumns_Renderer"].ToString();
                                      Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\">");
                                      Response.Write(render(strRenderer, dtGridData, i));
                                      Response.Write("</td>");
                  									}
                  								}
                  							}
                  							%>
                  		          <td>
                  								<a href="<%=strFormUrl%>&azione=edit&<%=dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString()%>=<%=dtGridData.Rows[iGridData][dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString()].ToString()%>" title="modifica" class="edit"><i class="fa-duotone fa-pen-to-square fa-fw"></i></a>
                  								<a href="/admin/app/<%=dtCoreModulesGrid.Rows[0]["CoreModules_Code"].ToString()%>/crud/elimina-<%=dtCoreEntitiesGrid.Rows[0]["CoreEntities_Code"].ToString()%>.aspx?azione=delete&<%=dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString()%>=<%=dtGridData.Rows[iGridData][dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString()].ToString()%>&sorgente=scheda-<%=dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString()%>&<%=dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()+"=" + GetFieldValue(dtFormsData, dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString())%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
                  							</td>
                  		        </tr>
                              <%
                                //record figlie del tree
                                if (dtCurrentCoreGrids.Rows[0]["CoreEntities_Tree"].Equals(true)){        				
                                  strWHERENet=dtCurrentCoreGrids.Rows[0]["CoreEntities_TreeAttribute"].ToString() + "=" + dtGridData.Rows[iGridData][dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString()].ToString();                
                                  strORDERNet=Request["orderby"];
                                  if ((strORDERNet==null || strORDERNet.Length<1) && (dtCurrentCoreGrids.Rows[0]["CoreGrids_SQLOrder"].ToString().Length>0)){
                          					strORDERNet = dtCurrentCoreGrids.Rows[0]["CoreGrids_SQLOrder"].ToString();
                          				}
                          				strFROMNet = dtCurrentCoreGrids.Rows[0]["CoreGrids_SQLFrom"].ToString();
                          				dtGridDataChildren = Smartdesk.Sql.getTablePage(strFROMNet, null, dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString(), strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                                  if (dtGridDataChildren.Rows.Count>0){ 
                                  for (int x = 0; x < dtGridDataChildren.Rows.Count; x++){
                                  %>
                        		        <tr>
                        		          <td width="10"><input type="checkbox" class="checkrow" id="record<%=dtGridDataChildren.Rows[x][dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString()].ToString()%>" data-value="<%=dtGridDataChildren.Rows[x][dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString()].ToString()%>" /></td>
                        							<%
                        							for (int j = 0; j < dtCoreGridsColumns.Rows.Count; j++){
                        								if (dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString().ToLower()==dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString().ToLower() || dtCoreGridsColumns.Rows[j]["CoreGridsColumns_Link"].Equals(true)){
                        									strFieldValue="<td>&nbsp;&nbsp;<i class=\"fa-duotone fa-angle-double-right fa-fw\" aria-hidden=\"true\"></i>";
                        									strFieldValue+="<a href=\"" + strFormUrl;
                        									strFieldValue+="&azione=edit";
                        									strFieldValue+="&" + dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString() + "=" + dtGridDataChildren.Rows[x][dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString()].ToString();
                        									strFieldValue+="\" title=\"modifica\" class=\"edit\">";
                                          switch (dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString()){
                        										case "icon":
                        									   strFieldValue+="<i class=\"" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + " fa-fw\"></i>";
                        										  break;
                        										case "color":
                        									    strFieldValue+="<div style=\"border:1px solid #000000;width:100%;height:20px;background-color:" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\"></div>";
                        										  break;
                        										case "text":
                        									    strFieldValue+="<i class=\"fa-duotone fa-file-lines fa-fw\"></i>" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString();
                        										  break;
                        										case "image":
                        									    if (dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString().Length>0){
                                                strFieldValue+="<img src=\"" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\" border=\"0\" width=\"100%\" width=\"30\" height=\"30\" style=\"width:30px;height:30px\">";
                                              }
                        										  break;
                        										default:
                        									    strFieldValue+=dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString();
                        										  break;
                                          }
                        									strFieldValue+="</a>";
                        									strFieldValue+="</td>";
                        									Response.Write(strFieldValue);
                        								}else{
                        							  	if (dtCoreGridsColumns.Rows[j]["CoreGridsColumns_Renderer"].ToString().Length<1){
                              										switch (dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString()){
                              											case "text":
                                    										switch (dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString()){
                                    											case "icon":
                              													    Response.Write("<td class=\"text-center " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + " fa-fw\"></i></td>");
                                  												  break;
                                    											case "color":
                              													    Response.Write("<td class=\"text-center " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><div style=\"border:1px solid #000000;width:100%;height:20px;background-color:" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\"></div></td>");
                                  												  break;
                                    											case "text":
                              													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-file-lines fa-fw\"></i>" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "</td>\n");
                                  												  break;
                                    											case "phone":
                              													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><a href=\"tel:" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\"><i class=\"fa-duotone fa-phone fa-fw\"></i>" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "</a></td>\n");
                                  												  break;
                                    											case "email":
                              													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><a href=\"mailto:" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\"><i class=\"fa-duotone fa-envelope fa-fw\"></i>" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "</a></td>\n");
                                  												  break;
                                    											case "link":
                              													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><a href=\"" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\" target=\"_blank\"><i class=\"fa-duotone fa-up-right-from-square fa-fw\"></i>" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "</a></td>\n");
                                  												  break;
                                    											case "image":
                              													    if (dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString().Length>0){
                                                              Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><img src=\"" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\" border=\"0\" height=\"30\" style=\"max-width:100px;height:30px;max-height:30px\"></td>\n");
                                                            }else{
                                                              Response.Write("<td></td>");
                                                            }
                                  												  break;
                                    											default:
                              													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\">" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "</td>\n");
                                  												  break;
                                                        }
                              												  break;
                              											case "textarea":
                              													Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-file-lines fa-fw\"></i>" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "</td>\n");
                              												  break;
                              											case "data":
                                    										if (dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString().Length>=10){
                        																	switch (dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString()){
                        	            											case "date":
                        	      															Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-calendar-days fa-fw\"></i>" + Convert.ToDateTime(dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()]).ToString("dd/MM/yyyy") + "</td>\n");
                        	          												  break;
                        	            											case "datetime":
                        	      															Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-calendar-days fa-fw\"></i>" + Convert.ToDateTime(dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()]).ToString("dd/MM/yyyy HH:mm tt") + "</td>\n");
                        	      												  		break;
                        	            											default:
                        	      															Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-calendar-days fa-fw\"></i>" + Convert.ToDateTime(dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()]).ToString("dd/MM/yyyy") + "</td>\n");
                        	          												  break;
                        	      												  }
                              												  }else{
                        																 	Response.Write("<td></td>\n");
                        																}
                              												  break;
                              											case "number":
                                    										switch (dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString()){
                                    											case "number":
                              													    Response.Write("<td class=\"text-right " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\">" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "</td>\n");
                                  												  break;
                                    											case "integer":
                              													    Response.Write("<td class=\"text-right " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\">" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "</td>\n");
                                  												  break;
                                    											case "percent":
                                                             Response.Write("<td class=\"text-left\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\">");
                                          									 Response.Write("<div style=\"margin-top:5px\" class=\"progress success\" role=\"progressbar\" tabindex=\"0\" aria-valuenow=\"" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "\" aria-valuemin=\"0\" aria-valuetext=\"" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "%\" aria-valuemax=\"100\">");
                                          									 Response.Write("<span class=\"progress-meter\" style=\"width:" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "%\">");
                                          									 Response.Write("<p class=\"progress-meter-text\">" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "%</p>");
                                          									 Response.Write("</span>");
                                          									 Response.Write("</div>");
                              													     Response.Write("</td>\n");
                                  												  break;
                                    											default:
                              													    Response.Write("<td class=\"text-right " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\">" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "</td>");
                                  												  break;
                                                        }
                              												break;
                              											case "checkbox":
                              												if (dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].Equals(true)){
                              													Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-check fa-lg fa-fw\" style=\"--fa-primary-color:green;--fa-primary-opacity: 1.0\"></i></td>");
                              												}else{
                              													Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-xmark fa-lg fa-fw\" style=\"--fa-secondary-color:red;--fa-secondary-opacity: 1.0\"></i></td>");
                              												}
                              												break;
                              											default:
                              												Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\">" + dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "</td>");
                              												break;
                              										}
                        									}else{
                        										Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Type"].ToString() + "\">");
                        										Response.Write(dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString());
                        										//Response.Write(Eval(dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreGridsColumns_Renderer"].ToString()].ToString()));
                                            Response.Write("</td>");
                        									}
                        								}
                        							}
                        							%>
                        		          <td>
                        								<a href="<%=strFormUrl%>&azione=edit&<%=dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString()%>=<%=dtGridDataChildren.Rows[x][dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString()].ToString()%>" title="modifica" class="edit"><i class="fa-duotone fa-pen-to-square fa-fw"></i></a>
                        								<a href="/admin/app/<%=dtCoreModules.Rows[0]["CoreModules_Code"].ToString()%>/crud/elimina-<%=dtCoreEntitiesGrid.Rows[0]["CoreEntities_Code"].ToString()%>.aspx?azione=delete&<%=dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString()%>=<%=dtGridDataChildren.Rows[x][dtCoreEntitiesGrid.Rows[0]["CoreEntities_Key"].ToString()].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
                        							</td>
                                      </tr>
                                 <% 
                                  }
                                  }
                                }
                              %>
                  		    <% } %>
                  		   </tbody>
                  		  </table>
                  
                  
                  
                  
                  		</div>
                  	</div>
                  </div>
    	<%
                  }
                
    		}
        }
    	%>
      </div>
  </div>
  </div>
<!--#include file=/admin/inc-footer.aspx -->
</body>

</html>
