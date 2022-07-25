<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/pagamenti/elenco-pagamenti-da-fare.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title><%=strH1%></title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-5 medium-5 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i><%=strH1%></h2>
          </div>
          <div class="large-7 medium-7 small-12 cell float-right align-middle">
  	      </div>
      </div>
  </div>
</div>

<div class="grid-container fluid">
	<div class="divgrid">
  <div class="grid-x grid-padding-x">
    <div class="large-9 medium-9 small-8 cell"><h2><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i>Scaduti</h2></div>
		<div class="large-3 medium-3 small-4 cell">
      <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
      <div class="input-group">
        <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
          <option value="">Azioni di gruppo</option>
          <option value="delete" data-action="/admin/app/pagamenti/crud/elimina-pagamento.aspx">Elimina</option>
        </select>
        <div class="input-group-button">
          <input type="hidden" id="sorgente" name="sorgente" value="elenco-pagamenti-da-fare">
          <input type="hidden" id="azione" name="azione" value="">
          <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
          <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
          <input type="submit" id="doaction" class="button secondary" value="Applica">
        </div>
      </div>
      </form>
    </div>
  </div>
    
  <div class="grid-x grid-padding-x">
    <div class="large-12 medium-12 small-12 cell">
      <table class="grid hover scroll" border="0" width="100%">
  		<thead>
        <tr>
	       <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
          <th width="266">Fornitore</th>
          <th width="110" class="text-center">Scadenza</th>
          <th width="40" class="text-center">gg</th>
          <th width="90" class="text-center">Importo</th>
          <th width="200" class="text-center">Tramite</th>
          <th width="250" class="text-left">Riferimenti della fattura</th>
          <th width="200" class="text-left nowrap" data-orderable="false"></th>
        </tr>
  		</thead>
      <tbody>
  		    <%
  					decTot=0;
  		    	decTotAttivi=0;
  					decTotNonAttivi=0;
  					intMese=0;
  					intAnno=0;
  					for (int i = 0; i < dtPagamentiScaduti.Rows.Count; i++){
            if (intMese!=Convert.ToDateTime(dtPagamentiScaduti.Rows[i]["Pagamenti_Data"]).Month && i>0){
                if (intMese<dt.Month || intAnno<dt.Year){
                  strColor="#ff0000";
                }else{
                  strColor="#009933";
                }
              %>
                  <tr class="totale">
                    <td colspan="2" bgcolor="#ffffff"></td>
                    <td colspan="2" class="text-right" style="padding-right:5px">Totale mese <%=intMese%>/<%=intAnno%></td>
                    <td class="large-text-right small-text-left" style="padding-right:5px"><font color="<%=strColor%>"><strong>&euro; <%=decTotMese.ToString("N2", ci)%></strong></font></td>
                    <td colspan="3" bgcolor="#ffffff"></td>
                  </tr>
                <%
                decTotMese=0;
            }
            intMese=Convert.ToDateTime(dtPagamentiScaduti.Rows[i]["Pagamenti_Data"]).Month;
            intAnno=Convert.ToDateTime(dtPagamentiScaduti.Rows[i]["Pagamenti_Data"]).Year;
  		      %>
  		        <tr class="riga<%=i%2%>">
		            <td><input type="checkbox" class="checkrow" id="record<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>" data-value="<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>" /></td>
  		          <td>
  								<div class="width250">
  		            	<a href="/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=<%=dtPagamentiScaduti.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="Email: <%=dtPagamentiScaduti.Rows[i]["Anagrafiche_EmailAmministrazione"].ToString()%> - Telefono: <%=dtPagamentiScaduti.Rows[i]["Anagrafiche_Telefono"].ToString()%>">
	                  <% if (dtPagamentiScaduti.Rows[i]["Anagrafiche_SitoWeb"].ToString().Length>1){ %>
	                  <img src="https://www.google.com/s2/favicons?domain=<%=dtPagamentiScaduti.Rows[i]["Anagrafiche_SitoWeb"].ToString()%>" width="16" height="16" border="0">
	                  <% }else{ %>
	                  <i class="fa-duotone fa-user fa-fw"></i>
	                  <% } %>  
										<%=dtPagamentiScaduti.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
  								</div> 
  		          </td>
  		          <td>
  								<i class="fa-duotone fa-calendar-days fa-fw"></i><a href="/admin/app/pagamenti/scheda-pagamenti.aspx?Pagamenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>&sorgente=elenco-pagamenti-da-fare"><%=dtPagamentiScaduti.Rows[i]["Pagamenti_Data_IT"].ToString()%></a>
  							</td>
  		          <td class="large-text-right small-text-left"><%=Smartdesk.Functions.getGG(dtPagamentiScaduti.Rows[i]["ggTrascorsi"].ToString())%></td>
  		          <td class="large-text-right small-text-left" style="padding-right:5px"><strong>&euro; <%=dtPagamentiScaduti.Rows[i]["Pagamenti_Importo"].ToString()%></strong></td>
                <td class="text-left"><i class="fa-duotone <%=dtPagamentiScaduti.Rows[i]["PagamentiMetodo_icona"].ToString()%> fa-fw" style="color:<%=dtPagamentiScaduti.Rows[i]["PagamentiMetodo_Colore"].ToString()%>"></i><%=dtPagamentiScaduti.Rows[i]["PagamentiMetodo_Titolo"].ToString()%> su <%=dtPagamentiScaduti.Rows[i]["Conti_Titolo"].ToString()%></td>
  		          <td class="text-left"><div class="divwidth250"><small><%=dtPagamentiScaduti.Rows[i]["Pagamenti_Riferimenti"].ToString()%></strong></small></td>
  		          <td><a href="/admin/app/pagamenti/actions/pagamento-pagato.aspx?Anagrafiche_Ky=<%=dtPagamentiScaduti.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>&Pagamenti_Pagato=1&sorgente=elenco-pagamenti-da-fare" title="Segna come pagato"><i class="fa-duotone fa-check fa-fw"></i>segna come pagato</a></td>
  		        </tr>
  		    <%
  		      intAnagrafiche_Ky=Convert.ToInt32(dtPagamentiScaduti.Rows[i]["Anagrafiche_Ky"].ToString());
  		      if (dtPagamentiScaduti.Rows[i]["Pagamenti_AttivaPromemoria"].Equals(true)){
            	decTotAttivi+=Convert.ToDecimal(dtPagamentiScaduti.Rows[i]["Pagamenti_Importo"]);
            }else{
            	decTotNonAttivi+=Convert.ToDecimal(dtPagamentiScaduti.Rows[i]["Pagamenti_Importo"]);
  					}
  					decTot+=Convert.ToDecimal(dtPagamentiScaduti.Rows[i]["Pagamenti_Importo"]);
            decTotMese+=Convert.ToDecimal(dtPagamentiScaduti.Rows[i]["Pagamenti_Importo"]);
  		    }
  				%>
      	</tbody>
      	<tfoot>
  	      <tr class="totale">
            <td colspan="2" bgcolor="#ffffff"></td>
  	        <td colspan="2" class="text-right">Totale pagamenti</td>
  	        <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTot.ToString("N2", ci)%></td>
  	        <td colspan="3" bgcolor="#ffffff"></td>
  	      </tr>
  	      <tr class="totale">
            <td colspan="2" bgcolor="#ffffff"></td>
  	        <td colspan="2" class="text-right">Totale attivi</td>
  	        <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTotAttivi.ToString("N2", ci)%></td>
  	        <td colspan="3" bgcolor="#ffffff"></td>
  	      </tr>
  	      <tr class="totale">
            <td colspan="2" bgcolor="#ffffff"></td>
  	        <td colspan="2" class="text-right">Totale non attivi</td>
  	        <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTotNonAttivi.ToString("N2", ci)%></td>
  	        <td colspan="3" bgcolor="#ffffff"></td>
  	      </tr>
      	</tfoot>
      </table>
  	</div>
  </div>
</div>
</div>

<div class="grid-container fluid">
	<div class="divgrid">
		<div class="grid-x grid-padding-x">
			<div class="large-9 medium-9 small-8 cell"><h2><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i>Futuri</h2></div>
			<div class="large-3 medium-3 small-4 cell">
				<form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
				<div class="input-group">
					<select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
						<option value="">Azioni di gruppo</option>
						<option value="delete" data-action="/admin/app/pagamenti/crud/elimina-pagamento.aspx">Elimina</option>
					</select>
					<div class="input-group-button">
						<input type="hidden" id="sorgente" name="sorgente" value="elenco-pagamenti-da-fare">
						<input type="hidden" id="azione" name="azione" value="">
						<input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
						<input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
						<input type="submit" id="doaction" class="button secondary" value="Applica">
					</div>
				</div>
				</form>
			</div>
		</div>
		
		<div class="grid-x grid-padding-x">
			<div class="small-12 medium-12 large-12 cell">
				<table class="grid hover scroll" border="0" width="100%">
				<thead>
					<tr>
						<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
						<th width="266">Fornitore</th>
						<th width="110" class="text-center">Scadenza</th>
						<th width="40" class="text-center">gg</th>
						<th width="90" class="text-center">Importo</th>
						<th width="200" class="text-center">Tramite</th>
						<th width="250" class="text-left">Riferimenti della fattura</th>
						<th width="200" class="text-left nowrap" data-orderable="false"></th>
					</tr>
				</thead>
				<tbody>
						<%
							for (int i = 0; i < dtPagamentiFuturi.Rows.Count; i++){
							if (intMese!=Convert.ToDateTime(dtPagamentiFuturi.Rows[i]["Pagamenti_Data"]).Month && i>0){
									if (intMese<dt.Month || intAnno<dt.Year){
										strColor="#ff0000";
									}else{
										strColor="#009933";
									}
								%>
										<tr class="totale">
											<td colspan="2" bgcolor="#ffffff"></td>
											<td colspan="2" class="text-right" style="padding-right:5px">Totale mese</td>
											<td class="large-text-right small-text-left" style="padding-right:5px"><font color="<%=strColor%>"><strong>&euro; <%=decTotMese.ToString("N2", ci)%></strong></font></td>
											<td colspan="3" bgcolor="#ffffff"></td>
										</tr>
									<%
									decTotMese=0;
							}
							intMese=Convert.ToDateTime(dtPagamentiFuturi.Rows[i]["Pagamenti_Data"]).Month;
							intAnno=Convert.ToDateTime(dtPagamentiFuturi.Rows[i]["Pagamenti_Data"]).Year;
							%>
								<tr class="riga<%=i%2%>">
									<td><input type="checkbox" class="checkrow" id="record<%=dtPagamentiFuturi.Rows[i]["Pagamenti_Ky"].ToString()%>" data-value="<%=dtPagamentiFuturi.Rows[i]["Pagamenti_Ky"].ToString()%>" /></td>
									<td>
										<div class="width250">
											<a href="/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=<%=dtPagamentiFuturi.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="Email: <%=dtPagamentiFuturi.Rows[i]["Anagrafiche_EmailAmministrazione"].ToString()%> - Telefono: <%=dtPagamentiFuturi.Rows[i]["Anagrafiche_Telefono"].ToString()%>">
											<% if (dtPagamentiFuturi.Rows[i]["Anagrafiche_SitoWeb"].ToString().Length>1){ %>
											<img src="https://www.google.com/s2/favicons?domain=<%=dtPagamentiFuturi.Rows[i]["Anagrafiche_SitoWeb"].ToString()%>" width="16" height="16" border="0">
											<% }else{ %>
											<i class="fa-duotone fa-user fa-fw"></i>
											<% } %>  
											<%=dtPagamentiFuturi.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
										</div> 
									</td>
									<td>
										<i class="fa-duotone fa-calendar-days fa-fw"></i><a href="/admin/app/pagamenti/scheda-pagamenti.aspx?Pagamenti_Ky=<%=dtPagamentiFuturi.Rows[i]["Pagamenti_Ky"].ToString()%>&sorgente=elenco-pagamenti-da-fare"><%=dtPagamentiFuturi.Rows[i]["Pagamenti_Data_IT"].ToString()%></a>
									</td>
									<td class="large-text-right small-text-left"><%=Smartdesk.Functions.getGG(dtPagamentiFuturi.Rows[i]["ggTrascorsi"].ToString())%></td>
									<td class="large-text-right small-text-left" style="padding-right:5px"><strong>&euro; <%=((decimal)dtPagamentiFuturi.Rows[i]["Pagamenti_Importo"]).ToString("N2", ci)%></strong></td>
									<td class="text-left"><i class="fa-duotone <%=dtPagamentiFuturi.Rows[i]["PagamentiMetodo_icona"].ToString()%> fa-fw" style="color:<%=dtPagamentiFuturi.Rows[i]["PagamentiMetodo_Colore"].ToString()%>"></i><%=dtPagamentiFuturi.Rows[i]["PagamentiMetodo_Descrizione"].ToString()%> su <%=dtPagamentiFuturi.Rows[i]["Conti_Titolo"].ToString()%></td>
									<td class="text-left"><div class="divwidth250"><small><%=dtPagamentiFuturi.Rows[i]["Pagamenti_Riferimenti"].ToString()%></strong></small></td>
									<td><a href="/admin/app/pagamenti/actions/pagamento-pagato.aspx?Anagrafiche_Ky=<%=dtPagamentiFuturi.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiFuturi.Rows[i]["Pagamenti_Ky"].ToString()%>&Pagamenti_Pagato=1&sorgente=elenco-pagamenti-da-fare" title="Segna come pagato"><i class="fa-duotone fa-check fa-fw"></i>segna come pagato</a></td>
								</tr>
						<%
							intAnagrafiche_Ky=Convert.ToInt32(dtPagamentiFuturi.Rows[i]["Anagrafiche_Ky"].ToString());
							if (dtPagamentiFuturi.Rows[i]["Pagamenti_AttivaPromemoria"].Equals(true)){
								decTotAttivi+=Convert.ToDecimal(dtPagamentiFuturi.Rows[i]["Pagamenti_Importo"]);
							}else{
								decTotNonAttivi+=Convert.ToDecimal(dtPagamentiFuturi.Rows[i]["Pagamenti_Importo"]);
							}
							decTot+=Convert.ToDecimal(dtPagamentiFuturi.Rows[i]["Pagamenti_Importo"]);
							decTotMese+=Convert.ToDecimal(dtPagamentiFuturi.Rows[i]["Pagamenti_Importo"]);
						}
						%>
					</tbody>
					<tfoot>
						<tr class="totale">
							<td colspan="2" bgcolor="#ffffff"></td>
							<td colspan="2" class="text-right">Totale pagamenti</td>
							<td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTot.ToString("N2", ci)%></td>
							<td colspan="3" bgcolor="#ffffff"></td>
						</tr>
						<tr class="totale">
							<td colspan="2" bgcolor="#ffffff"></td>
							<td colspan="2" class="text-right">Totale attivi</td>
							<td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTotAttivi.ToString("N2", ci)%></td>
							<td colspan="3" bgcolor="#ffffff"></td>
						</tr>
						<tr class="totale">
							<td colspan="2" bgcolor="#ffffff"></td>
							<td colspan="2" class="text-right">Totale non attivi</td>
							<td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTotNonAttivi.ToString("N2", ci)%></td>
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
