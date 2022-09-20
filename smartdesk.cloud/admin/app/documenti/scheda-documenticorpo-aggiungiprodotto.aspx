<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="scheda-documenticorpo-aggiungiprodotto.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Documenti > Aggiungi prodotto</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx -->
<h1><i class="fa-duotone fa-cube fa-lg fa-fw"></i><%=strH1%></h1> 
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
			<div class="stacked-for-small button-group small hide-for-print align-right">
				<a href="/admin/app/catalogo/elenco-prodotti.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a> 
				<a href="/admin/app/catalogo/scheda-prodotto.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66&azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
			</div>
      <!--#include file=/admin/forms_messaggi.inc -->
	    <table class="toolbar">
	    <tr>
	      <td><a href="/admin/app/documenti/scheda-documenticorpo-aggiungiprodotto.aspx?invetrina=1">Vetrina</a></td>
	      <td>&nbsp;|&nbsp;</td>
	      <td><a href="/admin/app/documenti/scheda-documenticorpo-aggiungiprodotto.aspx?inofferta=1">Offerte</a></td>
	      <td>&nbsp;|&nbsp;</td>
	      <td><a href="/admin/app/documenti/scheda-documenticorpo-aggiungiprodotto.aspx?inpromozione=1">Promozioni</a></td>
	      <td>&nbsp;|&nbsp;</td>
	      <td><a href="/admin/app/documenti/scheda-documenticorpo-aggiungiprodotto.aspx?outlet=1">Outlet</a></td>
	      <td>&nbsp;|&nbsp;</td>
	      <td class="lbl" width="60">Titolo</td>
	      <td>
					<form id="form-documentocorpo-aggiungiprodotto" action="/admin/app/documenti/scheda-documenticorpo-aggiungiprodotto.aspx">
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
	      <td>&nbsp;|&nbsp;</td>
	      <td class="lbl" width="60">Codice</td>
	      <td>
					<form id="form-documentocorpo-aggiungiprodotto" action="/admin/app/documenti/scheda-documenticorpo-aggiungiprodotto.aspx">
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
	      <td><a href="/admin/app/documenti/scheda-documenticorpo-aggiungiprodotto.aspx?tutti=tutti">TUTTI</a></td>
	    </tr>
	    </table>
	    
	    <table class="grid hover scroll" border="0" width="100%">
	    	<thead>
		      <tr>
		        <th width="30">ID</th>
		        <th width="40">Cod.</th>
		        <th width="250">Prodotto</th>
		        <th width="80">Categoria</th>
		        <th width="140">Anagrafica</th>
		        <th width="160">Stato</th>
		        <th width="30">visite</th>
		        <th width="70">Prezzo</th>
		        <th data-property="Utenti_Iniziali" width="50">Utente</th>
		        <th width="12" class="nowrap"></th>
		      </tr>
	    	</thead>
	    	<tbody>
			    <%for (int i = 0; i < dtProdotti.Rows.Count; i++){ %>
			        <tr class="riga<%=i%2%>">
			          <td><%=dtProdotti.Rows[i]["Prodotti_Ky"].ToString()%></td>
			          <td><%=dtProdotti.Rows[i]["Prodotti_Codice"].ToString()%></td>
			          <td><div class="width200"><a href="/admin/app/catalogo/scheda-prodotto.aspx?Prodotti_Ky=<%=dtProdotti.Rows[i]["Prodotti_Ky"].ToString()%>"><%=dtProdotti.Rows[i]["Prodotti_Titolo"].ToString()%></a></div></td>
			          <td><%=dtProdotti.Rows[i]["ProdottiCategorie_Titolo"].ToString()%></td>
			          <td><a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtProdotti.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="Telefono: <%=dtProdotti.Rows[i]["Anagrafiche_Telefono"].ToString()%>"><i class="fa-duotone fa-users fa-fw"></i><%=dtProdotti.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a></td>
			          <td>
									<%=getStato(dtProdotti.Rows[i]["Prodotti_InPromozione"].Equals(true), "Promozione", "red",dtProdotti.Rows[i]["Prodotti_Ky"].ToString())%> 
									<%=getStato(dtProdotti.Rows[i]["Prodotti_InVetrina"].Equals(true), "Vetrina","blue",dtProdotti.Rows[i]["Prodotti_Ky"].ToString())%> 
									<%=getStato(dtProdotti.Rows[i]["Prodotti_InOfferta"].Equals(true), "Offerta","green",dtProdotti.Rows[i]["Prodotti_Ky"].ToString())%> 
									<%=getStato(dtProdotti.Rows[i]["Prodotti_Outlet"].Equals(true), "Outlet","yellow",dtProdotti.Rows[i]["Prodotti_Ky"].ToString())%>
								</td>
			          <td class="large-text-center small-text-left"><%=dtProdotti.Rows[i]["Prodotti_Visite"].ToString()%></td>
			          <td class="large-text-right small-text-left"><%=((decimal)dtProdotti.Rows[i]["Prodotti_Prezzo"]).ToString("N2", ci)%></td>
		          	<td class="large-text-center small-text-left"><%=dtProdotti.Rows[i]["Utenti_Iniziali"].ToString()%></td>
			          <td><a href="/admin/app/documenti/scheda-documenticorpo.aspx?azione=new&tipo=2&sorgente=scheda-documenti&Anagrafiche_Ky=<%=strAnagrafiche_Ky%>&Documenti_Ky=<%=strDocumenti_Ky%>&Prodotti_Ky=<%=dtProdotti.Rows[i]["Prodotti_Ky"].ToString()%>" data-tooltip class="has-tip" title="aggiungi al documento"><i class="fa-duotone fa-square-plus fa-fw fa-xl"></i></a></td>
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
