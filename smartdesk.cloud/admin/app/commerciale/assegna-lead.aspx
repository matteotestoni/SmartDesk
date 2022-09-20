<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/commerciale/assegna-lead.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Lead > Elenco documenti</title>
	<!--#include file="/admin/inc-head.aspx"-->
	<script src="/admin/app/commerciale/Commerciale.js"></script>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx -->
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-5 medium-5 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-money-bill-1-wave fa-fw"></i>Commerciale > <%=strH1%></h1> 
          </div>
          <div class="large-7 medium-7 small-12 cell float-right align-middle">
        		<div class="stacked-for-small button-group small hide-for-print align-right">
        			<a class="button clear" data-toggle="filtri"><i class="fa-duotone fa-magnifying-glass fa-lg fa-fw"></i>Cerca</a>
        			<a href="/admin/app/commerciale/report/rpt-elenco-preventivi.aspx?sorgente=elenco-preventivi" class="tiny button clear" target="_blank"><i class="fa-duotone fa-print fa-lg fa-fw"></i>stampa elenco</a>
        			<a href="/admin/form.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&CoreForms_Ky=66&azione=new&LeadTipo_Ky=4" class="tiny button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
        		</div>
  	      </div>
      </div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
    <div class="divgrid">

    <table class="grid hover scroll" border="0" width="100%">
    	<thead>
	      <tr>
	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	        <th width="30">Id</th>
	        <th width="80" class="text-left">Codice</th>
	        <th width="120" class="text-center date">Data</th>
	        <th width="200" class="text-left">Anagrafica</th>
	        <th width="70" class="text-center">Stato</th>
	        <th width="120" data-orderable="false">Oggetto</th>
	        <th width="180" class="text-center" data-orderable="false">Assegna</th>
	        <th width="100" class="text-center nowrap" data-orderable="false">Oppure</th>
	      </tr>
    	</thead>
    	<tbody>
		    <%for (int i = 0; i < dtLead.Rows.Count; i++){ %>
		        <tr class="riga<%=i%2%>" id="trLead<%=dtLead.Rows[i]["Lead_Ky"].ToString()%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtLead.Rows[i]["Lead_Ky"].ToString()%>" data-value="<%=dtLead.Rows[i]["Lead_Ky"].ToString()%>" /></td>
		          <td>
		            <a href="/admin/form.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&CoreForms_Ky=66&Lead_Ky=<%=dtLead.Rows[i]["Lead_Ky"].ToString()%>&azione=modifica"><%=dtLead.Rows[i]["Lead_Ky"].ToString()%></a> 
		          </td>
		          <td class="text-left"><strong><%=dtLead.Rows[i]["Lead_Titolo"].ToString()%></strong></td>
		          <td class="large-text-center small-text-left"><a href="/admin/form.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&CoreForms_Ky=66&Lead_Ky=<%=dtLead.Rows[i]["Lead_Ky"].ToString()%>&azione=modifica"><i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtLead.Rows[i]["Lead_Data_IT"].ToString()%></strong></a></td>
		          <td>
		          	<div class="width200">
		            <a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtLead.Rows[i]["Anagrafiche_Ky"].ToString()%>&Lead_Ky=<%=dtLead.Rows[i]["Lead_Ky"].ToString()%>&azione=modifica" title="<%=dtLead.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%>"><i class="fa-duotone fa-users fa-fw"></i><%=dtLead.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
								</div> 
		          </td>
		          <td class="large-text-center small-text-left"><%=getStato(dtLead.Rows[i]["LeadStato_Ky"].ToString(), dtLead.Rows[i]["LeadStato_Titolo"].ToString(),dtLead.Rows[i]["LeadStato_Icona"].ToString())%></td>
		          <td class="text-left">
								<div class="width200">
								<small>
								<%=dtLead.Rows[i]["Lead_Titolo"].ToString()%>
								<% if (dtLead.Rows[i]["Commesse_Ky"].ToString().Length>0){ %>
									| Progetto:<a href="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=<%=dtLead.Rows[i]["Commesse_Ky"].ToString()%>&sorgente=elenco-documenti" title="<%=dtLead.Rows[i]["Commesse_Titolo"].ToString()%>"><i class="fa-duotone fa-circle-info fa-fw"></i><%=dtLead.Rows[i]["Commesse_Riferimenti"].ToString()%></a>
								<% } %>
								</small><br>
								<small><%=dtLead.Rows[i]["Lead_Titolo"].ToString()%></small>
								</div>
							</td>
		          <td class="large-text-center small-text-left">
              <select name="Utenti_Ky" id="Utenti_Ky-<%=dtLead.Rows[i]["Lead_Ky"].ToString()%>" onchange="assegnaLead(<%=dtLead.Rows[i]["Lead_Ky"].ToString()%>)">
								<option value="""></option>
            		<%
            		for (int iUtenti = 0; iUtenti < dtUtenti.Rows.Count; iUtenti++){
            			Response.Write("<option value=\"" + dtUtenti.Rows[iUtenti]["Utenti_Ky"].ToString() + "\">" + dtUtenti.Rows[iUtenti]["Utenti_Nominativo"].ToString() + "</option>");
            		}
            		%>
              </select>
              
              
              </td>
		          <td class="text-center nowrap">
								<a href="/admin/app/commerciale/crud/elimina-lead.aspx?azione=delete&Lead_Ky=<%=dtLead.Rows[i]["Lead_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i>Elimina</a>
		          	<a href="/admin/app/commerciale/actions/lead-cambiastato.aspx?azione=update&Lead_Ky=<%=dtLead.Rows[i]["Lead_Ky"].ToString()%>&LeadStato_Ky=1&sorgente=assegna-lead" title="Segna come chiuso"><i class="fa-duotone fa-check fa-fw"></i>Fallito</a>
							</td>
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
