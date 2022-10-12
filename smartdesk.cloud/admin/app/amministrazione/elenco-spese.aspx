<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/view.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Spese > Elenco spese</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
    <div class="grid-x grid-padding-x align-middle">
        <div class="large-5 medium-5 small-12 cell align-middle">
          	<h1><i class="fa-duotone fa-inbox fa-lg fa-fw"></i><%=strH1%></h1>
            <!--#include file=/admin/view-inc-grids.aspx --> 
        </div>
        <div class="large-7 medium-7 small-12 cell float-right align-middle">
        		<div class="button-group small hide-for-print align-right">
        			<a class="button clear" data-toggle="filtri"><i class="fa-duotone fa-magnifying-glass fa-lg fa-fw"></i>Cerca spese</a>
        			<a href="/admin/app/amministrazione/prospetto-spese.aspx" class="tiny button clear"><i class="fa-duotone fa-chart-mixed fa-lg fa-fw"></i>Prospetto spese</a>
        			<a href="/admin/app/amministrazione/scheda-spese.aspx?CoreModules_Ky=2&CoreEntities_Ky=1&CoreForms_Ky=211&azione=new" class="tiny button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
        		</div>
	      </div>
    </div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
    <!--#include file=/admin/app/amministrazione/where/where-spese.inc --> 
    <div class="divgrid">
    <div class="grid-x grid-padding-x">
      <div class="large-9 medium-9 small-12 cell">
			    <asp:Label ID="PaginaSotto" runat="server" class="paginazione align-middle"></asp:Label>
      </div>
      <div class="large-3 medium-3 small-12 cell">
        <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
        <div class="input-group">
          <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
            <option value="">Azioni di gruppo</option>
            <option value="delete" data-action="/admin/crud/elimina.aspx">Elimina</option>
          </select>
          <div class="input-group-button">
            <input type="hidden" name="grid" value="elencospese">
            <input type="hidden" id="sorgente" name="sorgente" value="view-1">
            <input type="hidden" id="azione" name="azione" value="">
            <input type="hidden" name="ajax" value="">
            <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
            <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
            <input type="submit" id="doaction" class="button secondary" value="Applica">
          </div>
        </div>
        </form>
      </div>
    </div>
    
    <table id="elencospese" class="grid hover scroll" border="0" width="100%">
    	<thead>
	      <tr>
	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	        <th width="50">Codice</th>
        	<th width="110" class="text-center date">Data</th>
	        <th width="400" align="left">Titolo</th>
        	<th width="250" class="text-left">Anagrafiche</th>
        	<th width="200" class="text-left">Pagamento e Centro di costo</th>
 	        <th width="120" class="text-center number">Imponibile</th>
	        <th width="100" class="text-center number">IVA</th>
	        <th width="120" class="text-center number">Totale</th>
	        <th width="12" class="nowrap" data-orderable="false"></th>
	      </tr>
    	</thead>
    	<tbody>
		    <%for (int i = 0; i < dtGridData.Rows.Count; i++){ %>
		        <tr class="riga<%=i%2%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtGridData.Rows[i]["Spese_Ky"].ToString()%>" data-value="<%=dtGridData.Rows[i]["Spese_Ky"].ToString()%>" /></td>
		          <td><a href="/admin/app/amministrazione/scheda-spese.aspx?CoreModules_Ky=2&CoreEntities_Ky=1&CoreForms_Ky=211&Spese_Ky=<%=dtGridData.Rows[i]["Spese_Ky"].ToString()%>"><%=dtGridData.Rows[i]["Spese_Ky"].ToString()%></a></td>
		          <td class="date"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtGridData.Rows[i]["Spese_Data_IT"].ToString()%></td>
		          <td>
								<a href="/admin/app/amministrazione/scheda-spese.aspx?CoreModules_Ky=2&CoreEntities_Ky=1&CoreForms_Ky=211&Spese_Ky=<%=dtGridData.Rows[i]["Spese_Ky"].ToString()%>"><i class="fa-duotone fa-file-lines fa-fw"></i><%=dtGridData.Rows[i]["Spese_Titolo"].ToString()%></a><br>
								<small><i class="fa-duotone fa-file-lines fa-fw"></i><%=dtGridData.Rows[i]["CentridiCR_Titolo"].ToString()%></small>
								<small>
									doc. n&deg; <%=dtGridData.Rows[i]["Spese_DocumentoNumero"].ToString()%> del <%=dtGridData.Rows[i]["Spese_DocumentoData_IT"].ToString()%>
								</small>
							</td>
		          <td>
								<div class="width350">
		            	Fornitore: <a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtGridData.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="Email: <%=dtGridData.Rows[i]["Anagrafiche_EmailAmministrazione"].ToString()%> - Telefono: <%=dtGridData.Rows[i]["Anagrafiche_Telefono"].ToString()%>">
                  <% if (dtGridData.Rows[i]["Anagrafiche_SitoWeb"].ToString().Length>1){ %>
                  <img src="https://www.google.com/s2/favicons?domain=<%=dtGridData.Rows[i]["Anagrafiche_SitoWeb"].ToString()%>" width="16" height="16" border="0">
                  <% }else{ %>
                  <i class="fa-duotone fa-user fa-fw"></i>
                  <% } %>  
									<%=dtGridData.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
								</div> 
								<div class="width350">
		            	Cliente:&nbsp;&nbsp;&nbsp;&nbsp;<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtGridData.Rows[i]["Anagrafiche_ClienteKy"].ToString()%>">
                  <% if (dtGridData.Rows[i]["Anagrafiche_ClienteSitoWeb"].ToString().Length>1){ %>
                  <img src="https://www.google.com/s2/favicons?domain=<%=dtGridData.Rows[i]["Anagrafiche_ClienteSitoWeb"].ToString()%>" width="16" height="16" border="0">
                  <% }else{ %>
                  <i class="fa-duotone fa-user fa-fw"></i>
                  <% } %>  
									<%=dtGridData.Rows[i]["Anagrafiche_ClienteRagioneSociale"].ToString()%></a>
								</div> 
		          </td>
		          <td>
									<%=dtGridData.Rows[i]["Conti_Titolo"].ToString()%><br>
								  <i class="fa-duotone fa-file-lines fa-fw"></i><%=dtGridData.Rows[i]["CentridiCR_Titolo"].ToString()%>
							</td>
		          <td class="large-text-right small-text-left number" style="padding-right:5px"><strong>&euro; <%=((decimal)dtGridData.Rows[i]["Spese_TotaleRighe"]).ToString("N2", ci)%></strong></td>
		          <td class="large-text-right small-text-left number" style="padding-right:5px"><strong>&euro; <%=((decimal)dtGridData.Rows[i]["Spese_TotaleIVA"]).ToString("N2", ci)%></strong></td>
		          <td class="large-text-right small-text-left number" style="padding-right:5px"><strong>&euro; <%=((decimal)dtGridData.Rows[i]["Spese_Totale"]).ToString("N2", ci)%></strong></td>
		          <td><a href="/admin/crud/elimina.aspx?azione=delete&ajax=&CoreGrids_Ky=1&sorgente=view-1&Spese_Ky=<%=dtGridData.Rows[i]["Spese_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
		        </tr>
		    <% } %>
    	</tbody>
    </table>
    </div>
  </div>
 </div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
