<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="scheda-documenticorpo-aggiungiservizio.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Documenti > Aggiungi servizio</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<h1><i class="fa-duotone fa-cube fa-lg fa-fw"></i><%=strH1%></h1>
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
			<div class="stacked-for-small button-group small hide-for-print align-right">
				<a href="/admin/app/catalogo/elenco-Servizi.aspx" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
				<a href="/admin/app/catalogo/scheda-servizi.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a> 
			</div>
      <!--#include file=/admin/forms_messaggi.inc -->
	    <p>
	      La particolarit&agrave; dei servizi &egrave; che si rinnovano di periodicamente come un'assistenza annuale, una revisione annuale, hosting.
	      I servizi vanno inseriti nell'anagrafica dei clienti per il rinnovo.<br>
	    </p>
    <table class="toolbar">
    <tr>
	      <td class="lbl" width="60">Titolo</td>
	      <td>
					<form id="form-documentocorpo-aggiungiservizio" action="/admin/app/documenti/scheda-documenticorpo-aggiungiservizio.aspx">
		        <div class="grid-x grid-padding-x">
		        	<div class="large-10 medium-10 small-10 cell">
								<input type="text" name="ricercatitolo">
							</div>
							<div class="small-1 cell left">
								<button type="submit" value="cerca" name="cerca" class="tiny button postfix secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
			        </div>
			      </div>
					</form>
				</td>
	      <td class="lbl" width="60">Codice</td>
	      <td>
					<form id="form-documentocorpo-aggiungiservizio" action="/admin/app/documenti/scheda-documenticorpo-aggiungiservizio.aspx">
		        <div class="grid-x grid-padding-x">
		        	<div class="large-10 medium-10 small-10 cell">
								<input type="text" name="ricercacodice">
							</div>
							<div class="small-1 cell left">
								<button type="submit" value="cerca" name="cerca" class="tiny button postfix secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
			        </div>
			      </div>
					</form>
				</td>
	      <td>&nbsp;|&nbsp;</td>
	      <td><a href="/admin/app/documenti/scheda-documenticorpo-aggiungiservizio.aspx?tutti=tutti">TUTTI</a></td>
    </tr>
    </table>
    
    <table class="grid hover scroll" border="0" width="100%">
    	<thead>
	      <tr>
	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	        <th width="40">Cod.</th>
	        <th width="120">Abbreviazione</th>
	        <th width="200">Titolo</th>
	        <th width="150">Categoria</th>
	        <th width="100">Prezzo</th>
	        <th width="100">Prezzo al rinnovo</th>
	        <th width="60">IVA</th>
	        <th width="70">Attributi</th>
	        <th width="50">Ordine</th>
	        <th width="12" class="nowrap"></th>
	      </tr>
    	</thead>
    	<tbody>
		    <%for (int i = 0; i < dtServizi.Rows.Count; i++){ %>
		        <tr class="riga<%=i%2%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtServizi.Rows[i]["Servizi_Ky"].ToString()%>" data-value="<%=dtServizi.Rows[i]["Servizi_Ky"].ToString()%>" /></td>
		          <td><%=dtServizi.Rows[i]["Servizi_Ky"].ToString()%></td>
		          <td><%=dtServizi.Rows[i]["Servizi_Codice"].ToString()%></td>
		          <td><div class="width200"><a href="/admin/app/catalogo/scheda-servizi.aspx?Servizi_Ky=<%=dtServizi.Rows[i]["Servizi_Ky"].ToString()%>"><%=dtServizi.Rows[i]["Servizi_Titolo"].ToString()%></a></div></td>
		          <td><%=dtServizi.Rows[i]["ServiziCategorie_Descrizione"].ToString()%></td>
		          <td class="large-text-right small-text-left"><%=dtServizi.Rows[i]["Servizi_Prezzo"].ToString()%></td>
		          <td class="large-text-right small-text-left"><%=dtServizi.Rows[i]["Servizi_PrezzoRinnovo"].ToString()%></td>
		          <td class="large-text-right small-text-left"><%=dtServizi.Rows[i]["AliquoteIVA_Descrizione"].ToString()%></td>
		          <td class="large-text-right small-text-left"><%=dtServizi.Rows[i]["AttributiGruppi_Titolo"].ToString()%></td>
		          <td class="large-text-right small-text-left"><%=dtServizi.Rows[i]["Servizi_Ordine"].ToString()%></td>
			        <td><a href="/admin/app/documenti/scheda-documenticorpo.aspx?azione=new&tipo=3&sorgente=scheda-documenti&Anagrafiche_Ky=<%=strAnagrafiche_Ky%>&Documenti_Ky=<%=strDocumenti_Ky%>&Servizi_Ky=<%=dtServizi.Rows[i]["Servizi_Ky"].ToString()%>" data-tooltip class="has-tip" title="aggiungi al documento"><i class="fa-duotone fa-square-plus fa-fw fa-xl"></i></a></td>
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
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
