<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/view.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Contenuti > Elenco contenuti</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-5 medium-5 small-12 cell align-middle">
          	<h1><i class="fa-duotone fa-image fa-lg fa-fw"></i><%=strH1%></h1>
            <!--#include file=/admin/view-inc-grids.aspx --> 
          </div>
          <div class="large-7 medium-7 small-12 cell float-right align-middle">
        		<div class="stacked-for-small button-group small hide-for-print align-right">
        			<button class="button clear" data-toggle="filtri"><i class="fa-duotone fa-magnifying-glass fa-lg fa-fw"></i>Cerca</button>
        			<a href="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=99&CoreGrids_Ky=82" class="button clear"><i class="fa-duotone fa-table fa-fw"></i>Elenco zone banner</a>
        			<a href="/admin/app/contenuti/scheda-cmsads.aspx?azione=new" class="tiny button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
        		</div>
  	      </div>
      </div>
  </div>
</div>

<div class="grid-container fluid">
<div class="divgrid ">
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
    <!--#include file=/admin/app/contenuti/where/where-cmsads.inc --> 
    <div class="grid-x grid-padding-x">
      <div class="large-3 medium-3 small-8 cell end">
        <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
        <div class="input-group">
          <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
            <option value="">Azioni di gruppo</option>
            <option value="delete" data-action="/admin/app/contenuti/crud/elimina-cmsads.aspx">Elimina</option>
          </select>
          <div class="input-group-button">
            <input type="hidden" id="sorgente" name="sorgente" value="elenco-cmsads">
            <input type="hidden" id="azione" name="azione" value="">
            <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
            <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
            <button id="doaction" class="button secondary">Applica</button>
          </div>
        </div>
        </form>
      </div>
    </div>

    <table class="grid hover scroll" border="0" width="100%">
    	<thead>
	      <tr>
	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	        <th width="80">Foto</th>
	        <th width="40">Codice</th>
	        <th width="600">Titolo</th>
	        <th width="80">Lingua</th>
	        <th width="100">Zone</th>
			<th width="40">Click</th>
	        <th width="40">Pubblicato</th>
	        <th width="12" class="nowrap" data-orderable="false"></th>
	      </tr>
    	</thead>
    	<tbody>
		    <%for (int i = 0; i < dtGridData.Rows.Count; i++){ %>
	        <tr class="riga<%=i%2%>">
	          <td><input type="checkbox" class="checkrow" id="record<%=dtGridData.Rows[i]["CMSAds_Ky"].ToString()%>" data-value="<%=dtGridData.Rows[i]["CMSAds_Ky"].ToString()%>" /></td>
	          <td>
             <%
             if (dtGridData.Rows[i]["CMSAds_Foto"].ToString().Length>0){
                Response.Write("<img src=\"" + dtGridData.Rows[i]["CMSAds_Foto"].ToString() + "\" height=\"75\" width=\"75\">");
             }
             %>
            </td>
	          <td><%=dtGridData.Rows[i]["CMSAds_Ky"].ToString()%></td>
	          <td><a href="/admin/app/contenuti/scheda-cmsads.aspx?CMSAds_Ky=<%=dtGridData.Rows[i]["CMSAds_Ky"].ToString()%>"><%=dtGridData.Rows[i]["CMSAds_Titolo"].ToString()%></a></td>
	          <td><i class="fa-duotone fa-language fa-fw"></i><%=dtGridData.Rows[i]["Lingue_Titolo"].ToString()%></td>
	          <td><%=Smartdesk.Functions.getTags(dtGridData.Rows[i]["CMSAds_Zone"].ToString())%></td>
			  <td><span class="badge" id="messageCount"><%=dtGridData.Rows[i]["CMSAds_Click"].ToString()%></span></td>
	          <td class="text-center">
							<% if (dtGridData.Rows[i]["CMSAds_PubblicaWEB"].Equals(true)){ %>
								<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
							<% }else{  %>
								<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
							<% } %>
						</td>
	          <td><a href="/admin/app/contenuti/crud/elimina-cmsads.aspx?azione=delete&CMSAds_Ky=<%=dtGridData.Rows[i]["CMSAds_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
	        </tr>
		    <% } %>
    	</tbody>
    </table>
    <div class="paginazione">
    		<asp:Label ID="PaginaSotto" runat="server" class="paginazione"></asp:Label>
				<span class="pagination_info">
				&nbsp;&nbsp;<%=intNumRecords%> elementi
				</span>
    </div>
  </div>
 </div>
</div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
