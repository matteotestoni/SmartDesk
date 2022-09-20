<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/view.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Forms > Avanzamento forms</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
	<div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
		<div class="grid-x grid-padding-x">
			<div class="large-4 medium-6 small-12 cell">
        <h1><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i><%=strH1%> (<%=dtGridData.Rows.Count%>)</h1>
        <!--#include file=/admin/view-inc-grids.aspx --> 
      </div>
			<div class="large-8 medium-6 small-12 cell float-right">
    		<div class="stacked-for-small button-group small hide-for-print align-right">
    			<a class="button clear" data-toggle="filtri"><i class="fa-duotone fa-magnifying-glass fa-lg fa-fw"></i>Cerca valori</a>
        	<a href="/admin/view.aspx?CoreModules_Ky=16&CoreEntities_Ky=146&CoreGrids_Ky=96" class="button clear"><i class="fa-duotone fa-table fa-fw"></i>Elenco sondaggi</a>
        	<a href="/admin/app/forms/elenco-forms-valori.aspx?CoreModules_Ky=16&CoreEntities_Ky=149" class="button clear"><i class="fa-duotone fa-keyboard fa-fw"></i>Valori sondaggi</a>
        	<a href="/admin/app/forms/invia-forms.aspx?CoreModules_Ky=16" class="button clear"><i class="fa-duotone fa-envelope fa-fw"></i>Invia sondaggi</a>
          <a class="button dropdown clear" data-toggle="filtri-dropdown"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Filtri</a>
          <div class="dropdown-pane" id="filtri-dropdown" data-dropdown data-auto-focus="true">
       	    <a href="/admin/app/forms/elenco-forms-avanzamento.aspx?CoreModules_Ky=16&CoreEntities_Ky=147&CoreGrids_Ky=97&tutti=tutti" class="button clear"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Tutto</a>
      	    <a href="/admin/app/forms/elenco-forms-avanzamento.aspx?CoreModules_Ky=16&CoreEntities_Ky=147&CoreGrids_Ky=97&FormsAvanzamento_Stato=1" class="button clear"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Email inviata</a>
      	    <a href="/admin/app/forms/elenco-forms-avanzamento.aspx?CoreModules_Ky=16&CoreEntities_Ky=147&CoreGrids_Ky=97&FormsAvanzamento_Stato=2" class="button clear"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>In fase compilazione</a>
      	    <a href="/admin/app/forms/elenco-forms-avanzamento.aspx?CoreModules_Ky=16&CoreEntities_Ky=147&CoreGrids_Ky=97&FormsAvanzamento_Stato=3" class="button clear"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Completamento</a>
          </div>   
    		</div>
			</div>
		</div>
	</div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
    <!--#include file=/admin/app/forms/where/where-forms-avanzamento.inc --> 
    <% if (dtGridData.Rows.Count>0){ %>
      <div class="divgrid">
	    <div class="grid-x grid-padding-x">
        <div class="large-9 medium-9 small-12 cell">
  			    <asp:Label ID="PaginaSotto" runat="server" class="paginazione align-middle"></asp:Label>
        </div>
	      <div class="large-3 medium-3 small-8 cell end">
	        <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
	        <div class="input-group">
	          <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
	            <option value="">Azioni di gruppo</option>
	            <option value="delete" data-action="/admin/app/forms/crud/elimina-formsavanzamento.aspx">Elimina</option>
	          </select>
	          <div class="input-group-button">
	            <input type="hidden" id="sorgente" name="sorgente" value="elenco-formsavanzamento">
	            <input type="hidden" id="azione" name="azione" value="">
	            <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
	            <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
	            <input type="submit" id="doaction" class="button secondary" value="Applica">
	          </div>
	        </div>
	        </form>
	      </div>
	    </div>
	    
      <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
	        <tr>
      			<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	        	<th width="50">Codice</th>
	          <th width="200" align="left">Anagrafica</th>
	          <th width="150" align="left">Titolo Modulo</th>
    			  <th width="110" class="text-center date">Data</th>
    			  <th width="120" align="left">Stato</th>
    			  <th width="200" align="left">Descrizione</th>
	          <th width="80" align="left"></th>
	        </tr>
	      </thead>
	   		<tbody>
        <%for (int i = 0; i < dtGridData.Rows.Count; i++){ %>
            <tr>
		          <td><input type="checkbox" class="checkrow" id="record<%=dtGridData.Rows[i]["FormsAvanzamento_Ky"].ToString()%>" data-value="<%=dtGridData.Rows[i]["FormsAvanzamento_Ky"].ToString()%>" /></td>
		          <td><%=dtGridData.Rows[i]["FormsAvanzamento_Ky"].ToString()%></td>
              <td class="text-left"><a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtGridData.Rows[i]["Anagrafiche_Ky"].ToString()%>&sorgente=elenco-forms"><i class="fa-duotone fa-users fa-fw"></i><%=dtGridData.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a></td>
              <td class="text-left"><%=dtGridData.Rows[i]["Forms_Titolo"].ToString()%></td>
              <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtGridData.Rows[i]["FormsAvanzamento_Data"].ToString()%></a></td>
              <td class="text-left">
                <%
                switch(dtGridData.Rows[i]["FormsAvanzamento_Stato"].ToString()){
                  case "1":
                    Response.Write("<span class=\"label success tiny\"><i class=\"fa-duotone fa-paper-plane fa-fw\"></i>Inviata email</span>");
                    break;
                  case "2":
                    Response.Write("<span class=\"label warning tiny\"><i class=\"fa-duotone fa-check fa-fw\"></i>Compilazione modulo</span>");
                    break;
                  case "3":
                    Response.Write("<span class=\"label success tiny\"><i class=\"fa-duotone fa-check-circle fa-fw\"></i>Chiusura modulo</span>");
                    break;
                }
                %></td>
              <td class="text-left"><%=dtGridData.Rows[i]["FormsAvanzamento_Descrizione"].ToString()%></td>
              <td class="text-left"><a href="/admin/app/forms/elenco-forms-valori.aspx?CoreModules_Ky=16&CoreEntities_Ky=149&Anagrafiche_Ky=<%=dtGridData.Rows[i]["Anagrafiche_Ky"].ToString()%>&Forms_Ky=<%=dtGridData.Rows[i]["Forms_Ky"].ToString()%>"><i class="fa-duotone fa-eye fa-fw"></i>Visualizza valori</a></td>
            </tr>
        <% } %>
	   		</tbody>
      </table>
      </div>
    <% }else{
      	Response.Write("<div class=\"grid-x grid-padding-x\"><div class=\"small-12 large-12 medium-12 cell\"><div class=\"messaggio\">Nessun dato</div></div></div>");
    } %>

  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
