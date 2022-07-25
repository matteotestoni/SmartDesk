<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/core/contenuti.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<h1><i class="fa-duotone fa-user fa-lg fa-fw"></i>Vendite</h1>
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
				<% if (dtLogin.Rows[0]["UtentiGruppi_Vendite"].Equals(true)){ %>
				<div class="grid-x grid-padding-x" data-equalizer>
					<% if (dtLogin.Rows[0]["UtentiGruppi_Opportunita"].Equals(true)){ %>
				  <div class="small-4 medium-4 large-4 cell" id="<%=i%>" data-equalizer-watch>
						<div data-animate="fade-in fade-out" class="callout">
			  			<i class="fa-duotone fa-pen-to-square fa-fw fa-3x pull-left"></i>
							<p> 
					  		<a href="/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=138&CoreGrids_Ky=107">Trattative</a><br>
								Elenco trattative di vendita
							</p>
						</div>
				  </div>
					<%
						i++;
					} %>
					<% if (dtLogin.Rows[0]["UtentiGruppi_Fatture"].Equals(true) && dtLogin.Rows[0]["UtentiGruppi_Notedicredito"].Equals(true)){ %>
				  <div class="small-4 medium-4 large-4 cell" id="<%=i%>" data-equalizer-watch>
						<div data-animate="fade-in fade-out" class="callout">
		  			<i class="fa-duotone fa-file fa-fw fa-3x pull-left"></i>
						<p> 
				  		<a href="/admin/app/documenti/elenco-documenti.aspx?DocumentiTipo_Ky=1,2">Fatture e Note di credito</a><br>
							Elenco di fatture e note di credito. Hanno una numerazione consecutiva.
						</p>
						</div>
				  </div>
					<%
						i++;
					} %>
					<% if (dtLogin.Rows[0]["UtentiGruppi_Fatture"].Equals(true)){ %>
				  <div class="small-4 medium-4 large-4 cell" id="<%=i%>" data-equalizer-watch>
						<div data-animate="fade-in fade-out" class="callout">
			  			<i class="fa-duotone fa-file fa-fw fa-3x pull-left"></i>
							<p> 
			  				<a href="/admin/app/documenti/elenco-documenti.aspx?DocumentiTipo_Ky=1">Fatture</a><br>
								Elenco di fatture. Hanno una numerazione consecutiva.
							</p>
						</div>
				  </div>
					<%
						i++;
					} %>
					<% if (i==3 || i==6 || i==9){
						Response.Write("</div><div class=\"grid-x grid-padding-x\" data-equalizer>");
					} %>
					<% if (dtLogin.Rows[0]["UtentiGruppi_Notedicredito"].Equals(true)){ %>
				  <div class="small-4 medium-4 large-4 cell" id="<%=i%>" data-equalizer-watch>
						<div data-animate="fade-in fade-out" class="callout">
			  			<i class="fa-duotone fa-file fa-fw fa-3x pull-left"></i>
							<p> 
					  		<a href="/admin/app/documenti/elenco-documenti.aspx?DocumentiTipo_Ky=2">Note di credito</a><br>
								Elenco di Note di credito emesse per stornare le fatture. Hanno una numerazione consecutiva.
							</p>
						</div>
				  </div>
					<%
						i++;
					} %>
					<% if (i==3 || i==6 || i==9){
						Response.Write("</div><div class=\"grid-x grid-padding-x\" data-equalizer>");
					} %>
					<% if (dtLogin.Rows[0]["UtentiGruppi_Preventivi"].Equals(true)){ %>
				  <div class="small-4 medium-4 large-4 cell" id="<%=i%>" data-equalizer-watch>
						<div data-animate="fade-in fade-out" class="callout">
			  			<i class="fa-duotone fa-file fa-fw fa-3x pull-left"></i>
							<p> 
			  				<a href="/admin/app/documenti/elenco-documenti.aspx?DocumentiTipo_Ky=4">Preventivi</a><br>
								Elenco dei preventivi a clienti.
							</p>
						</div>
				  </div>
					<%
						i++;
					} %>
					<% if (i==3 || i==6 || i==9){
						Response.Write("</div><div class=\"grid-x grid-padding-x\" data-equalizer>");
					} %>
					<% if (dtLogin.Rows[0]["UtentiGruppi_Ordini"].Equals(true)){ %>
				  <div class="small-4 medium-4 large-4 cell" id="<%=i%>" data-equalizer-watch>
						<div data-animate="fade-in fade-out" class="callout">
			  			<i class="fa-duotone fa-file fa-fw fa-3x pull-left"></i>
							<p> 
			  				<a href="/admin/app/documenti/elenco-documenti.aspx?DocumentiTipo_Ky=3">Ordini</a><br>
								Elenco degli ordini da clienti.
							</p>
						</div>
				  </div>
					<%
						i++;
					} %>
					<% if (i==3 || i==6 || i==9){
						Response.Write("</div>");
					} %>
				<% } %>
		</div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
