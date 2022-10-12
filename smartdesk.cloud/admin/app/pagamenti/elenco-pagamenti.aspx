<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/pagamenti/elenco-pagamenti.aspx.cs" Inherits="_Default" Debug="true"%>
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
          <div class="large-4 medium-5 small-12 cell align-middle">
              <h1><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i><%=strH1%></h1>
          </div>
          <div class="large-8 medium-7 small-12 cell float-right align-middle">
        			<div class="stacked-for-small button-group small hide-for-print align-right">
  		            <a href="/admin/app/pagamenti/invia-promemoria-pagamenti.aspx?tipo=1&tutti=tutti&livello=1" class="button alert"><i class="fa-duotone fa-share fa-fw"></i>Invia promemoria massivo</a>
          		</div>
        </div>
  	</div>
  </div>
</div>

  <div class="grid-x grid-padding-x">
    <div class="large-3 medium-3 small-8 cell end">
      <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
      <div class="input-group">
        <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
          <option value="">Azioni di gruppo</option>
          <option value="delete" data-action="/admin/app/pagamenti/crud/elimina-pagamento.aspx">Elimina</option>
        </select>
        <div class="input-group-button">
          <input type="hidden" name="grid" value="elencopagamenti">
          <input type="hidden" id="sorgente" name="sorgente" value="elenco-pagamenti">
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
      <div class="divgrid">
  		<table id="elencopagamenti" class="grid hover scroll" border="0" width="100%">
  		<thead>
        <tr>
	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
          <th width="150" class="text-left">Anagrafica</th>
          <th width="110" class="text-center">Scadenza</th>
          <th width="40" class="text-center">gg</th>
          <th width="80" class="text-center">Importo</th>
          <th width="200">Tramite e Riferimenti</th>
          <th width="100">Solleciti <i class="fa-duotone fa-envelope fa-fw"></i><i class="fa-duotone fa-phone-square fa-fw"></i></th>
          <th width="110">Ultimo sollecito</th>
          <th width="35" data-orderable="false">Invia?</th>
          <th width="100" data-orderable="false"></th>
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
                  strColor="alert";
                }else{
                  strColor="success";
                }
              %>
                  <tr class="totale">
                    <td colspan="4" class="text-right" style="padding-right:5px">Totale mese <%=intMese%>/<%=intAnno%></td>
                    <td class="large-text-right small-text-left" style="padding-right:5px"><span class="label <%=strColor%>"><strong>&euro; <%=decTotMese.ToString("N2", ci)%></strong></td>
                    <td colspan="5" bgcolor="#ffffff"></td>
                  </tr>
                <%decTotMese=0;%>
  					<%
            }
            intMese=Convert.ToDateTime(dtPagamentiScaduti.Rows[i]["Pagamenti_Data"]).Month;
            intAnno=Convert.ToDateTime(dtPagamentiScaduti.Rows[i]["Pagamenti_Data"]).Year;
          	%>
  		        <tr class="riga<%=i%2%>">
		            <td><input type="checkbox" class="checkrow" id="record<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>" data-value="<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>" /></td>
  		          <td>
  								<div class="width100percent">
  		            	<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtPagamentiScaduti.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="Email: <%=dtPagamentiScaduti.Rows[i]["Anagrafiche_EmailAmministrazione"].ToString()%> - Telefono: <%=dtPagamentiScaduti.Rows[i]["Anagrafiche_Telefono"].ToString()%>">
	                  <% if (dtPagamentiScaduti.Rows[i]["Anagrafiche_SitoWeb"].ToString().Length>1){ %>
	                  <img src="https://www.google.com/s2/favicons?domain=<%=dtPagamentiScaduti.Rows[i]["Anagrafiche_SitoWeb"].ToString()%>" width="16" height="16" border="0">
	                  <% }else{ %>
	                  <i class="fa-duotone fa-user fa-fw"></i>
	                  <% } %>  
										<%=dtPagamentiScaduti.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
  								</div> 
  		          </td>
  		          <td>
  								<i class="fa-duotone fa-calendar-days fa-fw"></i><a href="/admin/app/pagamenti/scheda-pagamenti.aspx?Pagamenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>&sorgente=elenco-pagamenti"><%=dtPagamentiScaduti.Rows[i]["Pagamenti_Data_IT"].ToString()%></a>
  							</td>
  		          <td class="large-text-right small-text-left"><%=Smartdesk.Functions.getGG(dtPagamentiScaduti.Rows[i]["ggTrascorsi"].ToString())%></td>
  		          <td class="large-text-right small-text-left" style="padding-right:5px"><strong>&euro; <%=((decimal)dtPagamentiScaduti.Rows[i]["Pagamenti_Importo"]).ToString("N2", ci)%></strong></td>
                <td class="text-left">
									<i class="fa-duotone <%=dtPagamentiScaduti.Rows[i]["PagamentiMetodo_icona"].ToString()%> fa-fw" style="color:<%=dtPagamentiScaduti.Rows[i]["PagamentiMetodo_Colore"].ToString()%>"></i><%=dtPagamentiScaduti.Rows[i]["PagamentiMetodo_Titolo"].ToString()%> su <%=dtPagamentiScaduti.Rows[i]["Conti_Titolo"].ToString()%><br>
  		          	<div class="divwidth250"><a href="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Documenti_Ky"].ToString()%>"><i class="fa-duotone fa-pen-to-square fa-fw"></i></a> <small><%=dtPagamentiScaduti.Rows[i]["Pagamenti_Riferimenti"].ToString()%></small></div>
  		          </td>
  		          <td class="large-text-center small-text-left">
  								<i class="fa-duotone fa-envelope fa-fw" style="color:#999999"></i><strong><%=dtPagamentiScaduti.Rows[i]["Pagamenti_NumeroPromemoria"].ToString()%></strong>
  								- <i class="fa-duotone fa-phone-square fa-fw" style="color:#999999"></i><strong><%=dtPagamentiScaduti.Rows[i]["Pagamenti_NumeroChiamate"].ToString()%></strong>&nbsp;&nbsp;<a href="/admin/app/attivita/actions/segna-chiamata-pagamenti.aspx?sorgente=elenco-pagamenti&Pagamenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>&Documenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Documenti_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtPagamentiScaduti.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="Segna una chiamata in pi&ugrave;" class="alert"><i class="fa-duotone fa-phone-plus fa-fw"></i></a>
  							</td>
  		          <td class="large-text-center small-text-left"><i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtPagamentiScaduti.Rows[i]["Pagamenti_UltimoPromemoria_IT"].ToString()%></strong></td>
  		          <td class="large-text-center small-text-left">
  								<% if (dtPagamentiScaduti.Rows[i]["statopromemoria"].ToString()=="si"){ %>
  									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
  								<% }else{ %>
  									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
  								<% } %>
  							</td>
  		          <td class="large-text-right small-text-left">
  								<a class="button tiny dropdown" data-toggle="dropsollecito<%=i%>" aria-controls="dropsollecito<%=i%>" aria-expanded="false">Azioni<i class="fa-duotone fa-arrow-down fa-fw"></i></a>
  								<ul id="dropsollecito<%=i%>" class="dropdown-pane no-bullet" data-dropdown data-auto-focus="true" aria-hidden="true" tabindex="-1">
  									<% if (dtPagamentiScaduti.Rows[i]["Pagamenti_AttivaPromemoria"].Equals(true)){ %>
  			            <li><a href="/admin/app/pagamenti/pagamento-promemoria.aspx?Anagrafiche_Ky=<%=dtPagamentiScaduti.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>&Pagamenti_AttivaPromemoria=0&sorgente=elenco-pagamenti" class="success" title="disattiva promemoria"><i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i> disattiva sollecito</a></li>
  			            <% }else{ %>
  			            <li><a href="/admin/app/pagamenti/pagamento-promemoria.aspx?Anagrafiche_Ky=<%=dtPagamentiScaduti.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>&Pagamenti_AttivaPromemoria=1&sorgente=elenco-pagamenti" class="alert" title="attiva promemoria"><i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i> attiva sollecito</a></li>
  			            <% } %>
  									<li class="divider"><hr></li>
  									<li><a href="/admin/app/pagamenti/actions/pagamento-pagato.aspx?Documenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Documenti_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtPagamentiScaduti.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>&Pagamenti_Pagato=1&sorgente=elenco-pagamenti" title="Segna come pagato"><i class="fa-duotone fa-check success"></i> Segna come PAGATO <i class="fa-duotone fa-smile fa-fw"></i></a></li>
  									<li class="divider"><hr></li>
  								  <li><a href="/admin/app/pagamenti/invia-promemoria-pagamenti.aspx?tipo=1&livello=1&Pagamenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>"><i class="fa-duotone fa-envelope success fa-fw"></i>Invia promemoria <i class="fa-duotone fa-play fa-fw"></i></a></li>
  								  <li><a href="/admin/app/pagamenti/invia-promemoria-pagamenti.aspx?tipo=1&livello=1&Pagamenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>&anteprima=anteprima" target="blank"><i class="fa-duotone fa-file-lines fa-fw"></i> anteprima</a></li>
  									<li class="divider"><hr></li>
  								  <li><a href="/admin/app/pagamenti/invia-promemoria-pagamenti.aspx?tipo=1&livello=2&Pagamenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>"><i class="fa-duotone fa-envelope alert fa-fw"></i>Invia sollecito <i class="fa-duotone fa-forward fa-fw"></i></a></li>
  								  <li><a href="/admin/app/pagamenti/invia-promemoria-pagamenti.aspx?tipo=1&livello=2&Pagamenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>&anteprima=anteprima" target="blank"><i class="fa-duotone fa-file-lines fa-fw"></i> anteprima</a></li>
  									<li class="divider"><hr></li>
  								  <li><a href="/admin/app/pagamenti/invia-promemoria-pagamenti.aspx?tipo=1&livello=3&Pagamenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>"><i class="fa-duotone fa-envelope alert fa-fw"></i>Invia preavviso <i class="fa-duotone fa-forward fa-fw"></i></a></li>
  								  <li><a href="/admin/app/pagamenti/invia-promemoria-pagamenti.aspx?tipo=1&livello=3&Pagamenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>&anteprima=anteprima" target="blank"><i class="fa-duotone fa-file-lines fa-fw"></i> anteprima</a></li>
  								</ul>		          
  		          </td>
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
  				<%
          if (intMese<dt.Month || intAnno<dt.Year){
            strColor="alert";
          }else{
            strColor="success";
          }
        	%>
  				<tfoot>
  	        <tr class="totale">
              <td colspan="4" class="text-right" style="padding-right:5px">Totale mese <%=intMese%>/<%=intAnno%></td>
              <td class="large-text-right small-text-left" style="padding-right:5px"><span class="label <%=strColor%>"><strong>&euro; <%=decTotMese.ToString("N2", ci)%></strong></td>
              <td colspan="5" bgcolor="#ffffff"></td>
  	        </tr>
  		      <tr class="totale">
  		        <td colspan="4" class="text-right">Totale pagamenti</td>
  		        <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTot.ToString("N2", ci)%></td>
  		        <td colspan="5" bgcolor="#ffffff"></td>
  		      </tr>
  		      <tr class="totale">
  		        <td colspan="4" class="text-right">Totale attivi</td>
  		        <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTotAttivi.ToString("N2", ci)%></td>
  		        <td colspan="5" bgcolor="#ffffff"></td>
  		      </tr>
  		      <tr class="totale">
  		        <td colspan="4" class="text-right">Totale non attivi</td>
  		        <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTotNonAttivi.ToString("N2", ci)%></td>
  		        <td colspan="5" bgcolor="#ffffff"></td>
  		      </tr>
      	</tfoot>
      </table>
      </div>
  	</div>
  </div>
  
  
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-5 small-12 cell align-middle">
              <h1><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i>Pagamenti in entrata futuri</h1>	
          </div>
          <div class="large-8 medium-7 small-12 cell float-right align-middle">
        			<div class="stacked-for-small button-group small hide-for-print align-right">
  		          <a href="/admin/app/pagamenti/invia-promemoria-pagamenti.aspx?tipo=2&tutti=tutti&livello=1" class="button alert"><i class="fa-duotone fa-share fa-fw"></i>Invia Promemoria pagamenti PROSSIMO MESE ora</a>
          		</div>
        </div>
  	</div>
  </div>
</div>
  
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
      <div class="divgrid">
			<table class="grid hover scroll" border="0" width="100%">
			<thead>
	      <tr>
	        <th width="150" class="text-left">Anagrafica</th>
	        <th width="110" class="text-center">Scadenza</th>
	        <th width="40" class="text-center">gg</th>
	        <th width="80" class="text-center">Importo</th>
       		<th width="250" class="text-center">Tramite e Riferimenti</th>
	        <th width="110">Promemoria <i class="fa-duotone fa-envelope fa-fw"></i></th>
	        <th width="35" data-orderable="false">Invia?</th>
	        <th width="100" data-orderable="false"></th>
	      </tr>
			</thead>
	    <tbody>
			    <%
						decTot=0;
			    	decTotAttivi=0;
						decTotNonAttivi=0;
						decTotMese=0;
						intMese=0;
						intAnno=0;
						for (int i = 0; i < dtPagamentiFuturi.Rows.Count; i++){
	          if (intMese!=Convert.ToDateTime(dtPagamentiFuturi.Rows[i]["Pagamenti_Data"]).Month && i>0){
	              if (intMese<dt.Month || intAnno<dt.Year){
	                strColor="alert";
	              }else{
	                strColor="success";
	              }
	            %>
	                <tr class="totale">
	                  <td colspan="3" class="text-right" style="padding-right:5px">Totale mese <%=intMese%>/<%=intAnno%></td>
	                  <td class="large-text-right small-text-left" style="padding-right:5px"><span class="label <%=strColor%>"><strong>&euro; <%=decTotMese.ToString("N2", ci)%></strong></span></td>
	                  <td colspan="4" bgcolor="#ffffff"></td>
	                </tr>
	              <%
	              decTotMese=0;
	          }
	          intMese=Convert.ToDateTime(dtPagamentiFuturi.Rows[i]["Pagamenti_Data"]).Month;
	          intAnno=Convert.ToDateTime(dtPagamentiFuturi.Rows[i]["Pagamenti_Data"]).Year;
	          %>
			        <tr class="riga<%=i%2%>">
			          <td>
									<div class="width100percent">
				            <a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtPagamentiFuturi.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="Email: <%=dtPagamentiFuturi.Rows[i]["Anagrafiche_EmailAmministrazione"].ToString()%> - Telefono: <%=dtPagamentiFuturi.Rows[i]["Anagrafiche_Telefono"].ToString()%>">
	                  <% if (dtPagamentiFuturi.Rows[i]["Anagrafiche_SitoWeb"].ToString().Length>1){ %>
	                  <img src="https://www.google.com/s2/favicons?domain=<%=dtPagamentiFuturi.Rows[i]["Anagrafiche_SitoWeb"].ToString()%>" width="16" height="16" border="0">
	                  <% }else{ %>
	                  <i class="fa-duotone fa-user fa-fw"></i>
	                  <% } %>  
										<%=dtPagamentiFuturi.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
									</div> 
			          </td>
			          <td>
									<i class="fa-duotone fa-calendar-days fa-fw"></i><a href="/admin/app/pagamenti/scheda-pagamenti.aspx?Pagamenti_Ky=<%=dtPagamentiFuturi.Rows[i]["Pagamenti_Ky"].ToString()%>&sorgente=elenco-pagamenti"><%=dtPagamentiFuturi.Rows[i]["Pagamenti_Data_IT"].ToString()%></a>
								</td>
			          <td class="large-text-right small-text-left"><%=Smartdesk.Functions.getGG(dtPagamentiFuturi.Rows[i]["ggTrascorsi"].ToString())%></td>
			          <td class="large-text-right small-text-left" style="padding-right:5px"><strong>&euro; <%=((decimal)dtPagamentiFuturi.Rows[i]["Pagamenti_Importo"]).ToString("N2", ci)%></strong></td>
                <td class="text-left">
									<i class="fa-duotone <%=dtPagamentiFuturi.Rows[i]["PagamentiMetodo_icona"].ToString()%> fa-fw" style="color:<%=dtPagamentiFuturi.Rows[i]["PagamentiMetodo_Colore"].ToString()%>"></i><%=dtPagamentiFuturi.Rows[i]["PagamentiMetodo_Titolo"].ToString()%> su <%=dtPagamentiFuturi.Rows[i]["Conti_Titolo"].ToString()%><br>
									<div class="divwidth250"><a href="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=<%=dtPagamentiFuturi.Rows[i]["Documenti_Ky"].ToString()%>"><i class="fa-duotone fa-pen-to-square fa-fw"></i></a> <small><%=dtPagamentiFuturi.Rows[i]["Pagamenti_Riferimenti"].ToString()%></small></div>
								</td>
			          <td class="large-text-center small-text-left">
									<strong><%=dtPagamentiFuturi.Rows[i]["Pagamenti_NumeroPromemoria"].ToString()%></strong>
			          	<% if (dtPagamentiFuturi.Rows[i]["Pagamenti_UltimoPromemoria_IT"]!=null && dtPagamentiFuturi.Rows[i]["Pagamenti_UltimoPromemoria_IT"].ToString().Length>0){ %>
									il <i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtPagamentiFuturi.Rows[i]["Pagamenti_UltimoPromemoria_IT"].ToString()%></strong>
									<% } %>
								</td>
			          <td class="large-text-center small-text-left">
									<% if (dtPagamentiFuturi.Rows[i]["statopromemoria"].ToString()=="si"){ %>
										<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i><%=dtPagamentiFuturi.Rows[i]["statopromemoria"].ToString()%>
									<% }else{ %>
										<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i><%=dtPagamentiFuturi.Rows[i]["statopromemoria"].ToString()%>
									<% } %>
								</td>
			          <td class="large-text-right small-text-left">
									<a class="button tiny" data-toggle="droppromemoria<%=i%>" aria-controls="droppromemoria<%=i%>" aria-expanded="false">Azioni <i class="fa-duotone fa-arrow-down fa-fw"></i></a>
									<ul id="droppromemoria<%=i%>" class="dropdown-pane no-bullet" data-dropdown data-auto-focus="true" aria-hidden="true" tabindex="-1">
				            <% if (dtPagamentiFuturi.Rows[i]["Pagamenti_AttivaPromemoria"].Equals(true)){ %>
				            <li><a href="/admin/app/pagamenti/pagamento-promemoria.aspx?Anagrafiche_Ky=<%=dtPagamentiFuturi.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiFuturi.Rows[i]["Pagamenti_Ky"].ToString()%>&Pagamenti_AttivaPromemoria=0&sorgente=elenco-pagamenti" class="success" title="disattiva promemoria"><i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i> disattiva promemoria</a></li>
				            <% }else{ %>
				            <li><a href="/admin/app/pagamenti/pagamento-promemoria.aspx?Anagrafiche_Ky=<%=dtPagamentiFuturi.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiFuturi.Rows[i]["Pagamenti_Ky"].ToString()%>&Pagamenti_AttivaPromemoria=1&sorgente=elenco-pagamenti" class="alert" title="attiva promemoria"><i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i> attiva promemoria</a></li>
				            <% } %>
										<li class="divider"><hr></li>
										<li><a href="/admin/app/pagamenti/actions/pagamento-pagato.aspx?Documenti_Ky=<%=dtPagamentiFuturi.Rows[i]["Documenti_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtPagamentiFuturi.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiFuturi.Rows[i]["Pagamenti_Ky"].ToString()%>&Pagamenti_Pagato=1&sorgente=elenco-pagamenti" title="Segna come pagato"><i class="fa-duotone fa-check success fa-fw"></i> segna come PAGATO <i class="fa-duotone fa-smile fa-fw"></i></a></li>
										<li class="divider"><hr></li>
								  	<li><a href="/admin/app/pagamenti/invia-promemoria-pagamenti.aspx?tipo=2&Pagamenti_Ky=<%=dtPagamentiFuturi.Rows[i]["Pagamenti_Ky"].ToString()%>"><i class="fa-duotone fa-envelope success fa-fw"></i>Invia promemoria</a></li>
								  	<li><a href="/admin/app/pagamenti/invia-promemoria-pagamenti.aspx?tipo=2&Pagamenti_Ky=<%=dtPagamentiFuturi.Rows[i]["Pagamenti_Ky"].ToString()%>&anteprima=anteprima" target="blank"><i class="fa-duotone fa-file-lines fa-fw"></i> anteprima</a></li>
									</ul>		          
			          </td>
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
            if (intMese<dt.Month || intAnno<dt.Year){
              strColor="alert";
            }else{
              strColor="success";
            }
          %>
         </tbody> 
		    	<tfoot>
			      <tr class="totale">
	            <td colspan="3" class="text-right" style="padding-right:5px">Totale mese <%=intMese%>/<%=intAnno%></td>
	            <td class="large-text-right small-text-left" style="padding-right:5px"><span class="label <%=strColor%>"><strong>&euro; <%=decTotMese.ToString("N2", ci)%></strong></span></td>
	            <td colspan="4" bgcolor="#ffffff"></td>
	          </tr>  
			      <tr class="totale">
			        <td colspan="3"  class="text-right">Totale pagamenti</td>
			        <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTot.ToString("N2", ci)%></td>
			        <td colspan="4" bgcolor="#ffffff"></td>
			      </tr>
			      <tr class="totale">
			        <td colspan="3"  class="text-right">Totale attivi</td>
			        <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTotAttivi.ToString("N2", ci)%></td>
			        <td colspan="4" bgcolor="#ffffff"></td>
			      </tr>
			      <tr class="totale">
			        <td colspan="3"  class="text-right">Totale non attivi</td>
			        <td class="large-text-right small-text-left" style="padding-right:5px">&euro; <%=decTotNonAttivi.ToString("N2", ci)%></td>
			        <td colspan="4" bgcolor="#ffffff"></td>
			      </tr>
		    	</tfoot>
		    </table>
        </div>
  </div> 
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
