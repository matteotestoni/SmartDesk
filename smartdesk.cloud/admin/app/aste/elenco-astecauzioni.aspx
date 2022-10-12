<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/view.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Aste > Elenco cauzioni</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
	<div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
		<div class="grid-x grid-padding-x">
			<div class="large-4 medium-6 small-12 cell">
        <h1><i class="fa-duotone fa-table fa-lg fa-fw"></i><%=strH1%></h1>
        <!--#include file=/admin/view-inc-grids.aspx --> 
      </div>
			<div class="large-8 medium-6 small-12 cell float-right">
			</div>
		</div>
	</div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell contenuto">

    <div class="divgrid">
    <div class="grid-x grid-padding-x">
      <div class="large-3 medium-3 small-8 cell end">
        <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
        <div class="input-group">
          <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
            <option value="">Azioni di gruppo</option>
            <option value="delete" data-action="/admin/app/aste/crud/elimina-astecauzioni.aspx">Elimina</option>
          </select>
          <div class="input-group-button">
            <input type="hidden" name="grid" value="elencoastecauzioni">
            <input type="hidden" id="sorgente" name="sorgente" value="elenco-astecauzioni">
            <input type="hidden" id="azione" name="azione" value="">
            <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
            <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
            <button id="doaction" class="button secondary">Applica</button>
          </div>
        </div>
        </form>
      </div>
    </div>

    <table id="elencoastecauzioni" class="grid hover scroll" border="0" width="100%" id="griddatatables">
    	<thead>
	      <tr>
	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	        <th width="40">Cod.</th>
	        <th width="250">Anagrafica</th>
	        <th width="110" class="text-center date">Data</th>
	        <th width="80" class="text-right">Valore</th>
	        <th width="200">Tramite</th>
	        <th width="40">Autorizzata</th>
	        <th width="200">Asta</th>
	        <th width="50">Esperimento</th>
	        <th width="50">Stato</th>
	        <th width="12" class="nowrap" data-orderable="false"></th>
	      </tr>
    	</thead>
    	<tbody>
		    <%for (int i = 0; i < dtGridData.Rows.Count; i++){ %>
		        <tr class="riga<%=i%2%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtGridData.Rows[i]["AsteCauzioni_Ky"].ToString()%>" data-value="<%=dtGridData.Rows[i]["AsteCauzioni_Ky"].ToString()%>" /></td>
		          <td><a href="/admin/app/aste/scheda-astecauzioni.aspx?AsteEsperimenti_Ky=<%=dtGridData.Rows[i]["AsteEsperimenti_Ky"].ToString()%>&Aste_Ky=<%=dtGridData.Rows[i]["Aste_Ky"].ToString()%>&AsteCauzioni_Ky=<%=dtGridData.Rows[i]["AsteCauzioni_Ky"].ToString()%>"><%=dtGridData.Rows[i]["AsteCauzioni_Ky"].ToString()%></a></td>
		          <td><a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtGridData.Rows[i]["Anagrafiche_Ky"].ToString()%>"><i class="fa-duotone fa-tag fa-fw"></i><%=dtGridData.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a></td>
		          <td><a href="/admin/app/aste/scheda-astecauzioni.aspx?AsteEsperimenti_Ky=<%=dtGridData.Rows[i]["AsteEsperimenti_Ky"].ToString()%>&Aste_Ky=<%=dtGridData.Rows[i]["Aste_Ky"].ToString()%>&AsteCauzioni_Ky=<%=dtGridData.Rows[i]["AsteCauzioni_Ky"].ToString()%>"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtGridData.Rows[i]["AsteCauzioni_Data"].ToString()%></a></td>
		          <td class="text-right"><%=((decimal)dtGridData.Rows[i]["AsteCauzioni_Valore"]).ToString("N2",ci)%></td>
              <td class="text-left">
								<i class="fa-duotone <%=dtGridData.Rows[i]["PagamentiMetodo_Icona"].ToString()%> fa-fw" style="color:<%=dtGridData.Rows[i]["PagamentiMetodo_Colore"].ToString()%>"></i><%=dtGridData.Rows[i]["PagamentiMetodo_Titolo"].ToString()%> su <%=dtGridData.Rows[i]["Conti_Titolo"].ToString()%><br>
		          	<div class="divwidth250"><small><%=dtGridData.Rows[i]["AsteCauzioni_Riferimenti"].ToString()%></small></div>
		          </td>
        			<td class="text-center">
								<% if (dtGridData.Rows[i]["AsteCauzioni_Autorizzata"].Equals(true)){ %>
									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
								<% }else{  %>
									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
								<% } %>
              </td>
		          <td><a href="/admin/app/aste/scheda-aste.aspx?Aste_Ky=<%=dtGridData.Rows[i]["Aste_Ky"].ToString()%>"><i class="fa-duotone fa-tag fa-fw"></i><%=dtGridData.Rows[i]["Aste_Titolo"].ToString()%></a></td>
		          <td class="text-center"><%=dtGridData.Rows[i]["AsteEsperimenti_Numero"].ToString()%></td>
		          <td class="text-left"><span class="label" style="background-color:<%=dtGridData.Rows[i]["AsteEsperimentiEsiti_Colore"].ToString()%>"><i class="<%=dtGridData.Rows[i]["AsteEsperimentiEsiti_Icona"].ToString()%> fa-fw"></i><%=dtGridData.Rows[i]["AsteEsperimentiEsiti_Titolo"].ToString()%></span></td>
							<td><a href="/admin/app/aste/crud/elimina-astecauzioni.aspx?azione=delete&AsteCauzioni_Ky=<%=dtGridData.Rows[i]["AsteCauzioni_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
		        </tr>
		    <% } %>
    	</tbody>
    </table>
    </div>
    <div class="paginazione">
    		<asp:Label ID="PaginaSotto" runat="server" class="paginazione"></asp:Label>
				<span class="pagination_info">
				&nbsp;&nbsp;<%=intNumRecords%> elementi
				</span>
    </div>

  </div>
 </div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
