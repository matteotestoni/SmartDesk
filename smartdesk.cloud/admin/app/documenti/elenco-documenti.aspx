<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/documenti/elenco-documenti.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Documenti > Elenco documenti</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx -->
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-5 medium-5 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-file fa-lg fa-fw"></i><%=strH1%></h1> 
          </div>
          <div class="large-7 medium-7 small-12 cell float-right align-middle">
        		<div class="stacked-for-small button-group small hide-for-print align-right">
        			<a class="button clear" data-toggle="filtri"><i class="fa-duotone fa-magnifying-glass fa-lg fa-fw"></i>Cerca</a>
        			<a href="/admin/app/documenti/report/rpt-elenco-documenti.aspx?sorgente=elenco-documenti" class="tiny button clear" target="_blank"><i class="fa-duotone fa-print fa-lg fa-fw"></i>stampa elenco</a>
        			<a href="/admin/app/documenti/actions/aggiorna-documenti.aspx?sorgente=elenco-documenti" class="tiny button clear"><i class="fa-duotone fa-sync fa-lg fa-fw"></i>aggiorna stato</a>
        			<a href="/admin/app/documenti/actions/genera-pdf.aspx?sorgente=elenco-documenti" class="tiny button clear"><i class="fa-duotone fa-file-pdf fa-lg fa-fw"></i>genera PDF</a>
        			<a href="#" class="tiny button dropdown" data-toggle="dropdowntipodocumenti"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
        			<div class="dropdown-pane" id="dropdowntipodocumenti" data-dropdown data-hover="true" data-hover-pane="true">
        			  <ul class="no-bullet">
        		      	<% for (int i = 0; i < dtDocumentiTipo.Rows.Count; i++){ %>
          			  	<li><a href="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&azione=new&DocumentiTipo_Ky=<%=dtDocumentiTipo.Rows[i]["DocumentiTipo_Ky"].ToString()%>" class="tiny"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i><%=dtDocumentiTipo.Rows[i]["DocumentiTipo_Descrizione"].ToString()%></a></li>
                  		<% } %>
        			  </ul>
        			</div>
        		</div>
  	      </div>
      </div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
    <!--#include file=/admin/app/documenti/where/where-documenti.inc --> 
    <div class="divgrid">
    <div class="grid-x grid-padding-x">
      <div class="large-3 medium-3 small-8 cell end">
        <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
        <div class="input-group">
          <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
            <option value="">Azioni di gruppo</option>
            <option value="delete" data-action="/admin/app/documenti/crud/elimina-documenti.aspx">Elimina</option>
          </select>
          <div class="input-group-button">
            <input type="hidden" id="sorgente" name="sorgente" value="elenco-documenti">
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
	        <th width="30">Cod</th>
	        <th width="40" class="text-left">Tipo</th>
	        <th width="40" class="text-center">N&deg;</th>
	        <th width="120" class="text-center date">Data</th>
	        <th width="200" class="text-left">Anagrafica</th>
	        <th width="70" class="text-center">Stato</th>
	        <th width="110" class="text-center">Imponibile &euro;</th>
	        <th width="90" class="text-center">IVA &euro;</th>
	        <th width="110" class="text-center">Totale &euro;</th>
	        <th width="120" data-orderable="false">Oggetto</th>
	        <th width="180" class="text-center" data-orderable="false">Assegnato a</th>
	        <th width="100" class="text-center nowrap" data-orderable="false"></th>
	      </tr>
    	</thead>
    	<tbody>
		    <%for (int i = 0; i < dtDocumenti.Rows.Count; i++){ %>
		        <tr class="riga<%=i%2%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>" data-value="<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>" /></td>
		          <td>
		            <a href="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>&azione=modifica"><%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%></a> 
		          </td>
		          <td class="text-left"><strong><%=dtDocumenti.Rows[i]["DocumentiTipo_Codice"].ToString()%></strong></td>
		          <td class="large-text-center small-text-left"><a href="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>&azione=modifica"><strong><%=dtDocumenti.Rows[i]["Documenti_Numero"].ToString()%></strong></a></td>
		          <td class="large-text-center small-text-left"><a href="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>&azione=modifica"><i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtDocumenti.Rows[i]["Documenti_Data_IT"].ToString()%></strong></a></td>
		          <td>
		          	<div class="width300">
		            <a href="/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=<%=dtDocumenti.Rows[i]["Anagrafiche_Ky"].ToString()%>&Documenti_Ky=<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>&azione=modifica" title="Telefono: <%=dtDocumenti.Rows[i]["Anagrafiche_Telefono"].ToString()%>"><i class="fa-duotone fa-users fa-fw"></i><%=dtDocumenti.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
								</div> 
		          </td>
		          <td class="large-text-center small-text-left"><%=getStato(dtDocumenti.Rows[i]["DocumentiStato_Ky"].ToString(), dtDocumenti.Rows[i]["DocumentiStato_Descrizione"].ToString())%></td>
		          <td class="large-text-right small-text-left" style="padding-right:5px" class="segno<%=dtDocumenti.Rows[i]["DocumentiTipo_Segno"].ToString()%>"><small>&euro; <%=((decimal)dtDocumenti.Rows[i]["Documenti_TotaleRighe"]).ToString("N2", ci)%></small></td>
		          <td class="large-text-right small-text-left" style="padding-right:5px" class="segno<%=dtDocumenti.Rows[i]["DocumentiTipo_Segno"].ToString()%>"><small>&euro; <%=((decimal)dtDocumenti.Rows[i]["Documenti_TotaleIVA"]).ToString("N2", ci)%></small></td>
		          <td class="large-text-right small-text-left" style="padding-right:5px" class="segno<%=dtDocumenti.Rows[i]["DocumentiTipo_Segno"].ToString()%>"><strong>&euro; <%=((decimal)dtDocumenti.Rows[i]["Documenti_Totale"]).ToString("N2", ci)%></strong></td>
		          <td class="text-left">
								<div class="width300">
								<small>
								<%=dtDocumenti.Rows[i]["Documenti_Riferimenti"].ToString()%>
								<% if (dtDocumenti.Rows[i]["Commesse_Ky"].ToString().Length>0){ %>
									| Progetto:<a href="/admin/app/progetti/scheda-commesse.aspx?Commesse_Ky=<%=dtDocumenti.Rows[i]["Commesse_Ky"].ToString()%>&sorgente=elenco-documenti" title="<%=dtDocumenti.Rows[i]["Commesse_Titolo"].ToString()%>"><i class="fa-duotone fa-circle-info fa-fw"></i><%=dtDocumenti.Rows[i]["Commesse_Riferimenti"].ToString()%></a>
								<% } %>
								</small><br>
								<small><%=dtDocumenti.Rows[i]["Documenti_Descrizione"].ToString()%></small>
								</div>
							</td>
		          <td class="large-text-center small-text-left"><i class="fa-duotone fa-user fa-fw"></i><%=dtDocumenti.Rows[i]["Utenti_Nominativo"].ToString()%></strong></td>
		          <td class="text-center nowrap">
		          	<% if (dtDocumenti.Rows[i]["Documenti_PDF"].ToString().Length>0){ %>
								<a href="/uploads/documenti<%=dtDocumenti.Rows[i]["Documenti_PDF"].ToString()%>" target="_blank"><i class="fa-duotone fa-file-pdf fa-fw"></i></a>
		          	<% } %>
								<a href="/admin/app/documenti/crud/elimina-documento.aspx?azione=delete&Documenti_Ky=<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i>
		          	<a href="/admin/app/documenti/actions/aggiorna-documenti.aspx?azione=update&Anagrafiche_Ky=<%=dtDocumenti.Rows[i]["Anagrafiche_Ky"].ToString()%>&Documenti_Ky=<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>&DocumentiStato_Ky=6&sorgente=elenco-documenti" title="Segna come chiuso"><i class="fa-duotone fa-check fa-fw"></i></a>
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
