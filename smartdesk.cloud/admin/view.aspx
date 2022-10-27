<%@ Page codepage="65001" Language="C#" AutoEventWireup="true"  CodeFile="/admin/view.aspx.cs" Inherits="_Default" Debug="true" %>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>	
  <title><%=strH1%></title>
  <!--#include file="/admin/inc-head.aspx"-->
</head>
<body> 
<!--#include file=/admin/inc-mainbar.aspx --> 
<div class="grid-container fluid" id="grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>">
	<div class="grid-x grid-padding-x">
	  <% if (dtCoreEntities.Rows[0]["CoreEntities_Config"].Equals(true) && boolAdmin==true){ %>
				<div class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only"><!--#include file=/admin/impostazioni-sidebar.aspx --></div>
			  <div class="large-10 medium-10 small-12 cell">
		<% }else{ %>
				<div class="large-12 medium-12 small-12 cell">
		<% }
		%>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-5 medium-6 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-fw <%=dtCurrentCoreGrids.Rows[0]["CoreEntities_Icon"].ToString()%>"></i><%=strH1%></h1>
            <!--#include file=/admin/view-inc-grids.aspx --> 
          </div>
          <div class="large-7 medium-6 small-12 cell float-right align-middle">
  			<div class="stacked-for-small button-group small hide-for-print float-right align-middle">
  	      <% if (boolWhere){ %>
  					<button class="button clear" data-toggle="filtri"><i class="fa-duotone fa-magnifying-glass fa-lg fa-fw"></i>Cerca <%=dtCoreEntities.Rows[0]["CoreEntities_LabelPlural"].ToString()%></button>
  				<% } %>
  				<%
  				if (dtCoreGridsButtons.Rows.Count>0){
  					for (int iCoreGridsButtons = 0; iCoreGridsButtons < dtCoreGridsButtons.Rows.Count; iCoreGridsButtons++){ %>
  						<a href="/admin/app/<%=dtCoreModules.Rows[0]["CoreModules_Code"].ToString()%>/<%=dtCoreGridsButtons.Rows[iCoreGridsButtons]["CoreGridsButtons_Action"].ToString()%>" class="button clear"><i class="<%=dtCoreGridsButtons.Rows[iCoreGridsButtons]["CoreGridsButtons_Icon"].ToString()%> fa-fw"></i><%=dtCoreGridsButtons.Rows[iCoreGridsButtons]["CoreGridsButtons_Title"].ToString()%></a>
  					<%
  					}
  				}
  				%>
  				<a href="<%=strFormUrl%>&azione=new&sorgente=elenco-<%=dtCurrentCoreGrids.Rows[0]["CoreEntities_Code"].ToString().ToLower()%>" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Aggiungi nuovo</a>
  			</div>        
          </div>
  	</div>
  </div>
</div>

			<div class="divgrid">
	    <% if (dtCoreEntities.Rows[0]["CoreEntities_Description"].ToString().Length>0){ %>
    	<div class="callout small info" data-closable="slide-out-right">
        <i class="fa-duotone fa-circle-info fa-fw"></i>
        <%=dtCoreEntities.Rows[0]["CoreEntities_Description"].ToString()%>
        <button class="close-button" aria-label="Chiudi" type="button" data-close>
          <span aria-hidden="true">&times;</span>
        </button>
    	</div>
	   	<% } %>
			 <div class="divgridtop">
            <div class="grid-x grid-padding-x">
              <div class="large-9 medium-9 small-12 cell">
          			<asp:Label ID="PaginaSotto" runat="server" class="paginazione"></asp:Label>
              </div>
              <div class="large-3 medium-3 small-12 cell">
                <form name="azionidigruppo-form" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>" class="form-azione" method="post" action="#">
                <div class="input-group">
                  <select class="input-group-field" name="azionidigruppo" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-azionidigruppo">
                    <option value="">Azioni di gruppo</option>
                    <option value="delete" data-action="<%=strDeleteAction%>">Elimina</option>
                  </select>
                  <div class="input-group-button">
                    <input type="hidden" name="grid" value="table<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>">
                    <input type="hidden" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-ajax" name="ajax" value="">
                    <input type="hidden" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-sorgente" name="sorgente" value="elenco-<%=dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString()%>">
                    <input type="hidden" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-azione" name="azione" value="">
                    <input type="hidden" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-deletemultiplo" name="deletemultiplo" value="deletemultiplo">
                    <input type="hidden" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-azionidigruppo-ids" name="azionidigruppo-ids" value="">
                    <input type="hidden" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-CoreModules_Ky" name="CoreModules_Ky" value="<%=dtCoreGrids.Rows[0]["CoreModules_Ky"].ToString()%>">
                    <input type="hidden" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-CoreEntities_Ky" name="CoreEntities_Ky" value="<%=dtCoreGrids.Rows[0]["CoreEntities_Ky"].ToString()%>">
                    <input type="hidden" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-CoreGrids_Ky" name="CoreGrids_Ky" value="<%=dtCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%> ">
                    <input type="submit" id="azionidigruppo-grid-<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>-doaction" class="button secondary doaction" value="Applica">
                  </div>
                </div>
                </form>
              </div>
            </div>
        </div>
      <% if (boolWhere){
				Response.WriteFile(strPathWhere, true);
			} %>
	    <table id="table<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>" class="grid hover scroll" id="griddatatableszz">
	    	<thead>
	      <tr>
        	<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
		    	<% 
						for (int i = 0; i < dtCoreGridsColumns.Rows.Count; i++){
							if (strORDERNet!=null && strORDERNet.Length>0){
                if (strORDERNet.Contains(dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString())){
                  strCaret="<i class=\"fa-duotone fa-caret-down fa-xs fa-fw\" style=\"--fa-secondary-color:#1a73e8;\"></i>";
                }else{
                  strCaret="";
                }
              }
              strLinkOrder="/admin/view.aspx?CoreEntities_Ky=" + intCoreEntities_Ky + "&CoreGrids_Ky=" + intCoreGrids_Ky + "&orderby=" + dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString();
              
              switch (dtCoreGridsColumns.Rows[i]["CoreAttributesType_Code"].ToString()){
								case "text":
										switch (dtCoreGridsColumns.Rows[i]["CoreAttributesFormat_Code"].ToString()){
											case "icon":
					  				    Response.Write("<th class=\"text-center " + dtCoreGridsColumns.Rows[i]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[i]["CoreAttributesFormat_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[i]) + strCaret + "</th>");
											  break;
											case "color":
					  				    Response.Write("<th class=\"text-center " + dtCoreGridsColumns.Rows[i]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[i]["CoreAttributesFormat_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[i]) + strCaret + "</th>");
											  break;
											case "text":
					  				    Response.Write("<th class=\"text-left " + dtCoreGridsColumns.Rows[i]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[i]["CoreAttributesFormat_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString() + "\"><a href=\"" + strLinkOrder + "\">" + getLabel(dtCoreGridsColumns.Rows[i]) + strCaret + "</a></th>");
											  break;
											case "image":
					  				    Response.Write("<th class=\"text-center " + dtCoreGridsColumns.Rows[i]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[i]["CoreAttributesFormat_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[i]) + strCaret + "</th>");
											  break;
											case "link":
					  				    Response.Write("<th class=\"text-left " + dtCoreGridsColumns.Rows[i]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[i]["CoreAttributesFormat_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString() + "\"><a href=\"" + strLinkOrder + "\">" + getLabel(dtCoreGridsColumns.Rows[i]) + strCaret + "</a></th>");
											  break;
											case "email":
					  				    Response.Write("<th class=\"text-left " + dtCoreGridsColumns.Rows[i]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[i]["CoreAttributesFormat_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString() + "\"><a href=\"" + strLinkOrder + "\">" + getLabel(dtCoreGridsColumns.Rows[i]) + strCaret + "</a></th>");
											  break;
											case "phone":
					  				    Response.Write("<th class=\"text-left " + dtCoreGridsColumns.Rows[i]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[i]["CoreAttributesFormat_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString() + "\"><a href=\"" + strLinkOrder + "\">" + getLabel(dtCoreGridsColumns.Rows[i]) + strCaret + "</a></th>");
											  break;
											case "password":
					  				    Response.Write("<th class=\"text-left " + dtCoreGridsColumns.Rows[i]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[i]["CoreAttributesFormat_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString() + "\"><a href=\"" + strLinkOrder + "\">" + getLabel(dtCoreGridsColumns.Rows[i]) + strCaret + "</a></th>");
											  break;
											default:
					  				    Response.Write("<th class=\"text-left " + dtCoreGridsColumns.Rows[i]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[i]["CoreAttributesFormat_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString() + "\"><a href=\"" + strLinkOrder + "\">" + getLabel(dtCoreGridsColumns.Rows[i]) + strCaret + "</a></th>");
											  break;
                    }
									break;
								case "textarea":
					  				Response.Write("<th class=\"text-left " + dtCoreGridsColumns.Rows[i]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString() + "\"><a href=\"" + strLinkOrder + "\">" + getLabel(dtCoreGridsColumns.Rows[i]) + strCaret + "</a></th>");
									break;
								case "data":
					  				Response.Write("<th class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[i]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString() + "\"><a href=\"" + strLinkOrder + "\">" + getLabel(dtCoreGridsColumns.Rows[i]) + strCaret + "</a></th>");
									break;
								case "number":
					  				Response.Write("<th class=\"text-right " + dtCoreGridsColumns.Rows[i]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Width"].ToString() + "\" style=\"width:40px\" title=\"" + dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString() + "\"><a href=\"" + strLinkOrder + "\">" + getLabel(dtCoreGridsColumns.Rows[i]) + strCaret + "</a></th>");
									break;
								case "checkbox":
					  				Response.Write("<th class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[i]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString() + "\">" + getLabel(dtCoreGridsColumns.Rows[i]) + strCaret + "</th>");
									break;
								default:
					  				Response.Write("<th class=\"text-left " + dtCoreGridsColumns.Rows[i]["CoreAttributesType_Code"].ToString() + "\" width=\"" + dtCoreGridsColumns.Rows[i]["CoreGridsColumns_Width"].ToString() + "\" title=\"" + dtCoreGridsColumns.Rows[i]["CoreAttributes_Code"].ToString() + "\"><a href=\"" + strLinkOrder + "\">" + getLabel(dtCoreGridsColumns.Rows[i]) + strCaret + "</a></th>");
									break;
							}
						}
					 %>
        	<th width="40"></th>
	      </tr>
		   </thead>
		   <tbody>
		    <% for (int i = 0; i < dtGridData.Rows.Count; i++){ %>
		        <tr id="record<%=i%>">
		          <td width="10"><input type="checkbox" class="checkrow" id="record<%=dtGridData.Rows[i][dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()].ToString()%>" data-value="<%=dtGridData.Rows[i][dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()].ToString()%>" /></td>
							<%
							for (int j = 0; j < dtCoreGridsColumns.Rows.Count; j++){
								if (dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString().ToLower()==dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString().ToLower() || dtCoreGridsColumns.Rows[j]["CoreGridsColumns_Link"].Equals(true)){
									strFieldValue="<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\">";
									strFieldValue+="<a href=\"" + strFormUrl;
									strFieldValue+="&azione=edit&sorgente=elenco-" + dtCurrentCoreGrids.Rows[0]["CoreEntities_Code"].ToString().ToLower();
									strFieldValue+="&" + dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString() + "=" + dtGridData.Rows[i][dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()].ToString();
									strFieldValue+="\" title=\"modifica\" class=\"edit\">";
                  switch (dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString()){
										case "icon":
									   strFieldValue+="<i class=\"" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + " fa-fw\"></i>";
										  break;
										case "color":
									    strFieldValue+="<div style=\"border:1px solid #000000;width:100%;height:20px;background-color:" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\"></div>";
										  break;
										case "text":
									      strFieldValue+="<i class=\"fa-duotone fa-file-lines fa-fw\"></i>" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString();
										  break;
										case "password":
									      strFieldValue+="<i class=\"fa-duotone fa-file-lines fa-fw\"></i><input type=\"password\" value=\"" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "\">";
										  break;
										case "image":
									    if (dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString().Length>0){
                                            strFieldValue+="<img src=\"" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\" border=\"0\" width=\"100%\" width=\"30\" height=\"30\" style=\"width:30px;height:30px\">";
                      }
										  break;
										default:
									    strFieldValue+=dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString();
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
      													    Response.Write("<td class=\"text-center " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\"><i class=\"" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + " fa-lg fa-fw\"></i></td>");
          												  break;
            											case "color":
      													    Response.Write("<td class=\"text-center " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\"><div style=\"border:1px solid #000000;width:100%;height:20px;background-color:" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\"></div></td>");
          												  break;
            											case "text":
      													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\"><i class=\"fa-duotone fa-file-lines fa-fw\"></i>" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "</td>\n");
          												  break;
            											case "password":
      													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\"><i class=\"fa-duotone fa-file-lines fa-fw\"></i><span id=\"passwordgrid" + i + "\" class=\"passwordgrid\" data-password=\"" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "\">xxxxxxxxxxxxxxx</span><a title=\"mostra password\" data-tooltip><i onclick=\"showPasswordGrid('passwordgrid" + i + "')\" class=\"fa-duotone fa-eye fa-fw\"></i></a><a title=\"copia password\" data-tooltip><i onclick=\"copyToClipboard('passwordgrid" + i + "',true)\" class=\"fa-duotone fa-copy fa-fw\"></i></a></td>\n");
          												  break;
            											case "phone":
      													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\"><a href=\"tel:" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\"><i class=\"fa-duotone fa-phone fa-fw\"></i>" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "</a></td>\n");
          												  break;
            											case "email":
      													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\"><a href=\"mailto:" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\"><i class=\"fa-duotone fa-envelope fa-fw\"></i>" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "</a></td>\n");
          												  break;
            											case "link":
      													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\"><a href=\"" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\" target=\"_blank\"><i class=\"fa-duotone fa-up-right-from-square fa-fw\"></i>" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "</a></td>\n");
          												  break;
            											case "image":
      													    if (dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString().Length>0){
                                      Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\"><img src=\"" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "\" border=\"0\" height=\"30\" style=\"max-width:100px;height:30px;max-height:30px\"></td>\n");
                                    }else{
                                      Response.Write("<td></td>");
                                    }
          												  break;
            											default:
      													    Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\">" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()  + "</td>\n");
          												  break;
                                }
      												  break;
      											case "textarea":
      													Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\"><i class=\"fa-duotone fa-file-lines fa-fw\"></i>" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "</td>\n");
      												  break;
      											case "data":
            										if (dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString().Length>=10){
																	switch (dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString()){
	            											case "date":
	      															Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\"><i class=\"fa-duotone fa-calendar fa-fw\"></i>" + Convert.ToDateTime(dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()]).ToString("dd/MM/yyyy") + "</td>\n");
	          												  break;
	            											case "datetime":
	      															Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\"><i class=\"fa-duotone fa-calendar fa-fw\"></i>" + Convert.ToDateTime(dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()]).ToString("dd/MM/yyyy HH:mm tt") + "</td>\n");
	      												  		break;
	            											default:
	      															Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\"><i class=\"fa-duotone fa-calendar fa-fw\"></i>" + Convert.ToDateTime(dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()]).ToString("dd/MM/yyyy") + "</td>\n");
	          												  break;
	      												  }
      												  }else{
																 	Response.Write("<td></td>\n");
																}
      												  break;
      											case "number":
            										switch (dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString()){
            											case "number":
      													    Response.Write("<td class=\"text-right " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\">" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "</td>\n");
          												  break;
            											case "integer":
      													    Response.Write("<td class=\"text-right " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\">" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "</td>\n");
          												  break;
            											case "percent":
                                     Response.Write("<td class=\"text-right\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\">");
                  									 Response.Write("<div style=\"margin-top:5px\" class=\"progress success\" role=\"progressbar\" tabindex=\"0\" aria-valuenow=\"" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "\" aria-valuemin=\"0\" aria-valuetext=\"" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "%\" aria-valuemax=\"100\">");
                  									 Response.Write("<span class=\"progress-meter\" style=\"width:" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "%\">");
                  									 Response.Write("<p class=\"progress-meter-text\">" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "%</p>");
                  									 Response.Write("</span>");
                  									 Response.Write("</div>");
      													     Response.Write("</td>\n");
          												  break;
            											default:
      													    Response.Write("<td class=\"text-right " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\">" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "</td>");
          												  break;
                                }
      												break;
      											case "checkbox":
      												if (dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].Equals(true) || dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()=="True" || dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString()=="si"  ){
      													Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\"><i class=\"fa-duotone fa-check fa-lg fa-fw\" style=\"--fa-primary-color:green;--fa-primary-opacity: 1.0\"></i></td>");
      												}else{
      													Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\"><i class=\"fa-duotone fa-xmark fa-lg fa-fw\" style=\"--fa-secondary-color:red;--fa-secondary-opacity: 1.0\"></i></td>");
      												}
      												break;
      											default:
      												Response.Write("<td class=\"" + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + " " + dtCoreGridsColumns.Rows[j]["CoreAttributesFormat_Code"].ToString() + "\">" + dtGridData.Rows[i][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()].ToString() + "</td>");
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
								<a href="<%=strFormUrl%>&azione=edit&<%=dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()%>=<%=dtGridData.Rows[i][dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()].ToString()%>" title="modifica" class="edit"><i class="fa-duotone fa-pen-to-square fa-fw"></i></a>
								<a href="<%=strDeleteAction%>?azione=delete&ajax=&CoreGrids_Ky=<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>&<%=dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()%>=<%=dtGridData.Rows[i][dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
							</td>
		        </tr>
            <%
              //record figlie del tree
              if (dtCurrentCoreGrids.Rows[0]["CoreEntities_Tree"].Equals(true)){        				
                strWHERENet=dtCurrentCoreGrids.Rows[0]["CoreEntities_TreeAttribute"].ToString() + "=" + dtGridData.Rows[i][dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()].ToString();                
                strORDERNet=Request["orderby"];
                if ((strORDERNet==null || strORDERNet.Length<1) && (dtCurrentCoreGrids.Rows[0]["CoreGrids_SQLOrder"].ToString().Length>0)){
        					strORDERNet = dtCurrentCoreGrids.Rows[0]["CoreGrids_SQLOrder"].ToString();
        				}
        				strFROMNet = dtCurrentCoreGrids.Rows[0]["CoreGrids_SQLFrom"].ToString();
        				dtGridDataChildren = Smartdesk.Sql.getTablePage(strFROMNet, null, dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString(), strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtGridDataChildren.Rows.Count>0){ 
                for (int x = 0; x < dtGridDataChildren.Rows.Count; x++){
                %>
      		        <tr>
      		          <td width="10"><input type="checkbox" class="checkrow" id="record<%=dtGridDataChildren.Rows[x][dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()].ToString()%>" data-value="<%=dtGridDataChildren.Rows[x][dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()].ToString()%>" /></td>
      							<%
      							for (int j = 0; j < dtCoreGridsColumns.Rows.Count; j++){
      								if (dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString().ToLower()==dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString().ToLower() || dtCoreGridsColumns.Rows[j]["CoreGridsColumns_Link"].Equals(true)){
      									strFieldValue="<td>&nbsp;&nbsp;<i class=\"fa-duotone fa-angle-double-right fa-fw\" aria-hidden=\"true\"></i>";
      									strFieldValue+="<a href=\"" + strFormUrl;
      									strFieldValue+="&azione=edit";
      									strFieldValue+="&" + dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString() + "=" + dtGridDataChildren.Rows[x][dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()].ToString();
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
      	      															Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-calendar fa-fw\"></i>" + Convert.ToDateTime(dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()]).ToString("dd/MM/yyyy") + "</td>\n");
      	          												  break;
      	            											case "datetime":
      	      															Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-calendar fa-fw\"></i>" + Convert.ToDateTime(dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()]).ToString("dd/MM/yyyy HH:mm tt") + "</td>\n");
      	      												  		break;
      	            											default:
      	      															Response.Write("<td class=\"large-text-center small-text-left " + dtCoreGridsColumns.Rows[j]["CoreAttributesType_Code"].ToString() + "\"><i class=\"fa-duotone fa-calendar fa-fw\"></i>" + Convert.ToDateTime(dtGridDataChildren.Rows[x][dtCoreGridsColumns.Rows[j]["CoreAttributes_Code"].ToString()]).ToString("dd/MM/yyyy") + "</td>\n");
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
      								<a href="<%=strFormUrl%>&azione=edit&<%=dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()%>=<%=dtGridDataChildren.Rows[x][dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()].ToString()%>" title="modifica" class="edit"><i class="fa-duotone fa-pen-to-square fa-fw"></i></a>
      								<a href="<%=strDeleteAction%>?azione=delete&ajax=&CoreGrids_Ky=<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>&<%=dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()%>=<%=dtGridDataChildren.Rows[x][dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString()].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
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
  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
