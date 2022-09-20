<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/anagrafiche/elenco-anagrafiche-da-fatturare.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Anagrafiche > Elenco anagrafiche da fatturare</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx -->
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
    <div class="grid-x grid-padding-x align-middle">
        <div class="large-5 medium-5 small-12 cell align-middle">
          	<h1><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i><%=strH1%></h1>
        </div>
        <div class="large-7 medium-7 small-12 cell float-right align-middle">
	      </div>
    </div>
  </div>
</div>


<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
		<div class="card">
			<div class="card-section">
					<ul class="stats-list">
					  <li>
					    <i class="fa-duotone fa-signal fa-fw"></i>
							<%=intNumeroServizi%> <span class="stats-list-label">Servizi totali</span>
					  </li>
					  <li>
					    <i class="fa-duotone fa-calendar-days fa-fw"></i>
							<%=intNumeroServizi1%> <span class="stats-list-label">gennaio</span>
					  </li>
					  <li>
					    <i class="fa-duotone fa-calendar-days fa-fw"></i>
							<%=intNumeroServizi2%> <span class="stats-list-label">febbraio</span>
					  </li>
					  <li>
					    <i class="fa-duotone fa-calendar-days fa-fw"></i>
							<%=intNumeroServizi3%> <span class="stats-list-label">marzo</span>
					  </li>
					  <li>
					    <i class="fa-duotone fa-calendar-days fa-fw"></i>
							<%=intNumeroServizi4%> <span class="stats-list-label">aprile</span>
					  </li>
					  <li>
					    <i class="fa-duotone fa-calendar-days fa-fw"></i>
							<%=intNumeroServizi5%> <span class="stats-list-label">maggio</span>
					  </li>
					  <li>
					    <i class="fa-duotone fa-calendar-days fa-fw"></i>
							<%=intNumeroServizi6%> <span class="stats-list-label">giugno</span>
					  </li>
					  <li>
					    <i class="fa-duotone fa-calendar-days fa-fw"></i>
							<%=intNumeroServizi7%> <span class="stats-list-label">luglio</span>
					  </li>
					  <li>
					    <i class="fa-duotone fa-calendar-days fa-fw"></i>
							<%=intNumeroServizi8%> <span class="stats-list-label">agosto</span>
					  </li>
					  <li>
					    <i class="fa-duotone fa-calendar-days fa-fw"></i>
							<%=intNumeroServizi9%> <span class="stats-list-label">settembre</span>
					  </li>
					  <li>
					    <i class="fa-duotone fa-calendar-days fa-fw"></i>
							<%=intNumeroServizi10%> <span class="stats-list-label">ottobre</span>
					  </li>
					  <li>
					    <i class="fa-duotone fa-calendar-days fa-fw"></i>
							<%=intNumeroServizi11%> <span class="stats-list-label">novembre</span>
					  </li>
					  <li>
					    <i class="fa-duotone fa-calendar-days fa-fw"></i>
							<%=intNumeroServizi12%> <span class="stats-list-label">dicembre</span>
					  </li>
					</ul>	
			</div>			
		</div>

    <!-- #include file=/admin/app/anagrafiche/where/where-anagrafiche-da-fatturare.inc -->
    <div class="divgrid">
    <table class="grid hover scroll" border="0" width="100%">
    	<thead>
      <tr>
        <th width="30">Cod</th>
        <th width="250" class="text-left">Anagrafica</th>
        <th width="80" class="text-left nowrap">Fattura</th>
        <th width="400">Servizio</th>
        <th width="110" class="text-right">Importo</th>
        <th width="130" class="text-center">Validit&agrave; dal al</th>
        <th width="130" class="text-center">gg Scadenza</th>
        <th width="12" class="nowrap" data-orderable="false"></th>
      </tr>
    	</thead>
    	<tbody>
		    <%for (int i = 0; i < dtAnagrafiche.Rows.Count; i++){
		      if ((dtAnagrafiche.Rows[i]["AnagraficheServizi_MeseScadenza"]!=System.DBNull.Value) && (intMese!=Convert.ToInt32(dtAnagrafiche.Rows[i]["AnagraficheServizi_MeseScadenza"].ToString()) && i>1)){
		      %>
		        <tr class="totale">
		          <td class="large-text-right small-text-left" colspan="2" bgcolor="#ffffff"></td>
		          <td class="large-text-right small-text-left" colspan="2">Totale mese</td>
		          <td class="large-text-right small-text-left">&euro; <%=decTotMese.ToString("N2", ci)%></td>
		          <td colspan="3" bgcolor="#ffffff"></td>
		        </tr>
					<%						
						decTotMese=0;
					}
		      if (intAnagrafiche_Ky==Convert.ToInt32(dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString())){ %>
		        <tr class="riga<%=i%2%>" rel="<%=Convert.ToInt32(dtAnagrafiche.Rows[i]["AnagraficheServizi_MeseScadenza"].ToString())%>-<%=Convert.ToInt32(dtAnagrafiche.Rows[i]["AnagraficheServizi_AnnoScadenza"].ToString())%>">
		          <td colspan="3">
		          </td>
		          <td>
								<div class="width300">
									<a href="/admin/app/anagrafiche/scheda-anagraficheservizi.aspx?AnagraficheServizi_Ky=<%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Ky"].ToString()%>&sorgente=dafatturare"><i class="fa-duotone fa-pen-to-square fa-fw"></i></a><%=dtAnagrafiche.Rows[i]["Servizi_Titolo"].ToString()%><br>
								</div>
								<small>
								<% if (dtAnagrafiche.Rows[i]["SitiWeb_Dominio"].ToString().Length>0){ %>
                <a href="http://www.<%=dtAnagrafiche.Rows[i]["SitiWeb_Dominio"].ToString()%>" target="_blank"><i class="fa-duotone fa-up-right-from-square fa-fw"></i><%=dtAnagrafiche.Rows[i]["SitiWeb_Dominio"].ToString()%></a> -
                <% } %> 
								<%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Descrizione"].ToString()%>
								</small>
							</td>
		          <td class="large-text-right small-text-left">
								<strong>&euro; <%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Importo"].ToString()%></strong><br>
								<small><%=GetTipoRinnovo(dtAnagrafiche.Rows[i]["AnagraficheServizi_Rinnovo"].ToString())%></small>
							</td>
		          <td class="large-text-center small-text-left">
								<i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Inizio_IT"].ToString()%><br>
								<i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Scadenza_IT"].ToString()%></strong>
							</td>
		          <td class="large-text-center small-text-left">
								<%=Smartdesk.Functions.getGGDaFare(dtAnagrafiche.Rows[i]["ggTrascorsi"].ToString())%>
							</td>
		          <td>
                <a href="/admin/app/amministrazione/servizio-fatturato.aspx?Anagrafiche_Ky=<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>&AnagraficheServizi_Ky=<%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Ky"].ToString()%>&sorgente=dafatturare" title="Segna come fattura emessa"><i class="fa-duotone fa-check success"></i></a>
                <a href="/admin/app/amministrazione/servizio-non-fatturato.aspx?Anagrafiche_Ky=<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>&AnagraficheServizi_Ky=<%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Ky"].ToString()%>&sorgente=dafatturare" title="Segna come fattura emessa"><i class="fa-duotone fa-undo success"></i></a>
              </td>
		        </tr>
		      <% }else{ %>
		        <tr class="riga<%=i%2%>" rel="<%=getMese(dtAnagrafiche.Rows[i]["AnagraficheServizi_MeseScadenza"].ToString())%>-<%=getAnno(dtAnagrafiche.Rows[i]["AnagraficheServizi_AnnoScadenza"].ToString())%>">
		          <td>
			            <a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="Telefono: <%=dtAnagrafiche.Rows[i]["Anagrafiche_Telefono"].ToString()%>"><%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%></a> 
							</td>
		          <td>
								<div class="width200">
			            <a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="Telefono: <%=dtAnagrafiche.Rows[i]["Anagrafiche_Telefono"].ToString()%>">
                  <% if (dtAnagrafiche.Rows[i]["Anagrafiche_SitoWeb"].ToString().Length>1){ %>
                  <img src="https://www.google.com/s2/favicons?domain=<%=dtAnagrafiche.Rows[i]["Anagrafiche_SitoWeb"].ToString()%>" width="16" height="16" border="0">
                  <% }else{ %>
                  <i class="fa-duotone fa-user fa-fw"></i>
                  <% } %>  
									<%=dtAnagrafiche.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a> 
			          </div>
		          </td>
              <td class="text-left nowrap">
                <a href="/admin/app/anagrafiche/actions/rinnova-servizi.aspx?Anagrafiche_Ky=<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>&mese=<%=Request["mese"]%>" title="crea la fattura di rinnovo per i servizi in essere"><i class="fa-duotone fa-square-plus fa-fw"></i>Crea</a>
              </td>
		          <td>
								<div class="width400">
									<a href="/admin/app/anagrafiche/scheda-anagraficheservizi.aspx?AnagraficheServizi_Ky=<%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Ky"].ToString()%>&sorgente=dafatturare"><i class="fa-duotone fa-pen-to-square fa-fw"></i></a><%=dtAnagrafiche.Rows[i]["Servizi_Titolo"].ToString()%><br>
								</div>
								<small>
								<% if (dtAnagrafiche.Rows[i]["SitiWeb_Dominio"].ToString().Length>0){ %>
								<a href="http://www.<%=dtAnagrafiche.Rows[i]["SitiWeb_Dominio"].ToString()%>" target="_blank"><i class="fa-duotone fa-up-right-from-square fa-fw"></i><%=dtAnagrafiche.Rows[i]["SitiWeb_Dominio"].ToString()%></a> -
                <% } %> 
								<%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Descrizione"].ToString()%>
								</small>
							</td>
		          <td class="large-text-right small-text-left">
								<strong>&euro; <%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Importo"].ToString()%></strong><br>
								<small><%=GetTipoRinnovo(dtAnagrafiche.Rows[i]["AnagraficheServizi_Rinnovo"].ToString())%></small>
							</td>
		          <td class="large-text-center small-text-left">
								<i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Inizio_IT"].ToString()%><br>
								<i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Scadenza_IT"].ToString()%></strong>
							</td>
		          <td class="large-text-center small-text-left">
					    	<%=Smartdesk.Functions.getGGDaFare(dtAnagrafiche.Rows[i]["ggTrascorsi"].ToString())%>
							</td>
		          <td>
                <a href="/admin/app/amministrazione/servizio-fatturato.aspx?Anagrafiche_Ky=<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>&AnagraficheServizi_Ky=<%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Ky"].ToString()%>&sorgente=dafatturare" title="Segna come fattura emessa"><i class="fa-duotone fa-check success"></i></a>
                <a href="/admin/app/amministrazione/servizio-non-fatturato.aspx?Anagrafiche_Ky=<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>&AnagraficheServizi_Ky=<%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Ky"].ToString()%>&sorgente=dafatturare" title="Segna come fattura emessa"><i class="fa-duotone fa-undo success"></i></a>
              </td>
		        </tr>
		      <% } %>
		    <%
		      decTotMese+=Convert.ToDecimal(dtAnagrafiche.Rows[i]["AnagraficheServizi_Importo"]);
		      decTot+=Convert.ToDecimal(dtAnagrafiche.Rows[i]["AnagraficheServizi_Importo"]);
		      intMese=Convert.ToInt32(dtAnagrafiche.Rows[i]["AnagraficheServizi_MeseScadenza"].ToString());
		      intAnno=Convert.ToInt32(dtAnagrafiche.Rows[i]["AnagraficheServizi_AnnoScadenza"].ToString());
		      intAnagrafiche_Ky=Convert.ToInt32(dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
		    } %>
        <tr class="totale">
		      <td colspan="2" bgcolor="#ffffff"></td>
          <td class="large-text-right small-text-left" colspan="2">Totale mese</td>
          <td class="large-text-right small-text-left">&euro; <%=decTotMese.ToString("N2", ci)%></td>
          <td colspan="3" bgcolor="#ffffff"></td>
        </tr>
		  </tbody>
		  <tfoot>
		    <tr class="totale">
		      <td colspan="2" bgcolor="#ffffff"></td>
		      <td class="large-text-right small-text-left" colspan="2">Totale generale</td>
		      <td class="large-text-right small-text-left">&euro; <%=decTot.ToString("N2", ci)%></td>
		      <td colspan="3" bgcolor="#ffffff"></td>
		    </tr>
		  </tfoot>
    </table>
    </div>
 </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
