<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/view.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Progetti > Elenco progetti</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
    <div class="grid-x grid-padding-x align-middle">
        <div class="large-4 medium-4 small-12 cell align-middle">
          <h1><i class="fa-duotone fa-buildings fa-lg fa-fw"></i><%=strH1%></h1>
          <!--#include file=/admin/view-inc-grids.aspx --> 
        </div>
        <div class="large-8 medium-8 small-12 cell float-right align-middle">
      		<div class="stacked-for-small button-group small hide-for-print align-right">
      			<a class="button clear" data-toggle="filtri"><i class="fa-duotone fa-magnifying-glass fa-lg fa-fw"></i>Cerca</a>
            <a class="button dropdown secondary" data-toggle="filtri-dropdown"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Filtri</a>
            <div class="dropdown-pane" id="filtri-dropdown" data-dropdown data-auto-focus="true">
              <a href="/admin/app/progetti/elenco-progetti.aspx?CommesseStato_Ky=6"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Progetti Conclusi</a><br>
        			<a href="/admin/app/progetti/elenco-progetti.aspx?CommesseStato_Ky=4"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Progetti In lavorazione</a><br>
        			<a href="/admin/app/progetti/elenco-progetti.aspx?tutti=tutti"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Tutti i progetti</a>
            </div>   
            <a class="button dropdown secondary" data-toggle="print-dropdown"><i class="fa-duotone fa-print fa-lg fa-fw"></i>Stampa</a>
            <div class="dropdown-pane" id="print-dropdown" data-dropdown data-auto-focus="true">
        			<a href="/admin/app/attivita/report/rpt-attivita-planning.aspx?sorgente=elenco-progetti" target="_blank"><i class="fa-duotone fa-print fa-lg fa-fw"></i>Stampa planning</a><br> 
        			<a href="/admin/app/progetti/report/rpt-commesse-elenco.aspx?sorgente=elenco-progetti" target="_blank"><i class="fa-duotone fa-print fa-lg fa-fw"></i>Stampa elenco</a>
            </div>      
      			<a href="/admin/app/progetti/actions/aggiorna-commesse.aspx?sorgente=elenco-progetti" class="button secondary"><i class="fa-duotone fa-sync fa-lg fa-fw"></i>Aggiorna stato progetti</a>
      			<a href="/admin/goto-form.aspx?CoreEntities_Ky=107&azione=new&sorgente=elenco-progetti" class=" button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
      		</div>
        </div>
	 </div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
    <!--#include file=/admin/app/progetti/where/where-commesse.inc --> 
    <div class="divgrid">
    <div class="grid-x grid-padding-x">
      <div class="large-9 medium-9 small-12 cell">
  			<asp:Label ID="PaginaSotto" runat="server" class="paginazione"></asp:Label>
      </div>
      <div class="large-3 medium-3 small-8 cell end">
        <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
        <div class="input-group">
          <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
            <option value="">Azioni di gruppo</option>
            <option value="delete" data-action="/admin/app/progetti/crud/elimina-commesse.aspx">Elimina</option>
          </select>
          <div class="input-group-button">
            <input type="hidden" name="grid" value="elencoprogetti">
            <input type="hidden" id="sorgente" name="sorgente" value="elenco-progetti">
            <input type="hidden" id="azione" name="azione" value="">
            <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
            <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
            <button id="doaction" class="button secondary">Applica</button>
          </div>
        </div>
        </form>
      </div>
    </div>

    <table id="elencoprogetti" class="grid hover scroll" border="0" width="100%">
    	<thead>
	      <tr>
	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	        <th width="100">Codice</th>
	        <th width="220">Date</th>
	        <th width="400">Progetto</th>
	        <th width="250">Stato</th>
	        <th width="120">Ore</th>
	      	<% if (boolAdmin && dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(true)){ %>
	        <th width="100" class="text-right">Valore</th>
	        <% } %>
	        <th width="60" class="nowrap" data-orderable="false"></th>
	      </tr>
    	</thead>
    	<tbody>
		    <%
					for (int i = 0; i < dtGridData.Rows.Count; i++){ %>
		        <tr class="riga<%=i%2%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtGridData.Rows[i]["Commesse_Ky"].ToString()%>" data-value="<%=dtGridData.Rows[i]["Commesse_Ky"].ToString()%>" /></td>
		          <td class="show-for-medium-up text-center nowrap">
								<div class="width100"><%=dtGridData.Rows[i]["Commesse_Riferimenti"].ToString()%></div>
							</td>
		          <td>
								<div style="float:left;width:70px;text-align:right">Inserita:</div><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtGridData.Rows[i]["Commesse_Data_IT"].ToString()%><br>
								<% if (dtGridData.Rows[i]["Commesse_DataConsegna_IT"].ToString().Length>0){ %>
                <div style="float:left;width:70px;text-align:right">Consegna:</div><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtGridData.Rows[i]["Commesse_DataConsegna_IT"].ToString()%>
                <% } %>
							</td>
		          <td>
								<div class="width400">
									<a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtGridData.Rows[i]["Commesse_Ky"].ToString()%>"><i class="fa-duotone fa-building fa-fw"></i><strong><%=dtGridData.Rows[i]["Commesse_Titolo"].ToString()%></strong></a><br>
								</div>
	            	<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtGridData.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="Telefono: <%=dtGridData.Rows[i]["Anagrafiche_Telefono"].ToString()%>"><i class="fa-duotone fa-user fa-fw"></i><%=dtGridData.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
							</td>
							<td>
									<span class="label" style="background-color:<%=dtGridData.Rows[i]["CommesseStato_Colore"].ToString()%>"><i class="<%=dtGridData.Rows[i]["CommesseStato_Icona"].ToString()%> fa-fw"></i><%=dtGridData.Rows[i]["CommesseStato_Titolo"].ToString()%></span><br>
									<div style="margin-top:5px" class="progress success" role="progressbar" tabindex="0" aria-valuenow="<%=dtGridData.Rows[i]["Commesse_Avanzamento"].ToString()%>" aria-valuemin="0" aria-valuetext="<%=dtGridData.Rows[i]["Commesse_Avanzamento"].ToString()%>%" aria-valuemax="100">
									  <span class="progress-meter" style="width:<%=dtGridData.Rows[i]["Commesse_Avanzamento"].ToString()%>%">
									    <p class="progress-meter-text"><%=dtGridData.Rows[i]["Commesse_Avanzamento"].ToString()%>%</p>
									  </span>
									</div>
							</td>
							<td class="large-text-right small-text-left">
								previste: <i class="fa-duotone fa-clock fa-fw"></i> <%=dtGridData.Rows[i]["Commesse_OrePreviste"].ToString()%><br>
								impiegate: <i class="fa-duotone fa-clock fa-fw"></i> <%=dtGridData.Rows[i]["Commesse_OreImpiegate"].ToString()%>
							</td>
			      	<% if (boolAdmin && dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(true)){ %>
		          <td class="large-text-right small-text-left" style="padding-right:4px">&euro; <%=dtGridData.Rows[i]["Commesse_Valore_IT"].ToString()%></td>
	        		<% } %>
		          <td class="show-for-medium-up text-center nowrap">
                <a href="/admin/app/progetti/scheda-progetti.aspx?Commesse_Ky=<%=dtGridData.Rows[i]["Commesse_Ky"].ToString()%>" title="modifica" class="edit"><i class="fa-duotone fa-pen-to-square fa-fw"></i></a>
                <a href="/admin/app/progetti/crud/elimina-commesse.aspx?azione=delete&Commesse_Ky=<%=dtGridData.Rows[i]["Commesse_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
              </td>
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
