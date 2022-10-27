<div class="card">
<div class="card-divider">
		<h2><i class="fa-duotone fa-euro-sign fa-fw"></i>Pagamenti in entrata Scaduti (<%=dtPagamentiScaduti.Rows.Count%>)</h2> 
		<div class="button-group tiny">
			<a href="/admin/app/pagamenti/elenco-pagamenti.aspx" class="button small clear"><i class="fa-duotone fa-eye fa-fw fa-lg button-icon"></i> <span class="button-text">Visualizza tutti</a></a>
		</div>
</div>
<div class="card-section" style="height:450px;max-height:450px;overflow:auto;">
	<div class="divgridcard">
	<table class="grid hover scroll" border="0">
	<thead>
		<tr>
      <th width="150">Anagrafica</th>
      <th width="110" class="text-center date">Data</th>
      <th width="120" class="text-center number hide-for-small-only">Promemoria</th>
      <th width="40" class="text-center">gg</th>
      <th width="80" class="text-center number">Importo</th>
      <th width="12" class="text-center nowrap hide-for-small-only"></th>
    </tr>
	</thead>
  <%
    decTot=0;
    decTotMese=0;
    if (dtPagamentiScaduti!=null){
			for (int i = 0; i < dtPagamentiScaduti.Rows.Count; i++){
        if (intMese!=Convert.ToDateTime(dtPagamentiScaduti.Rows[i]["Pagamenti_Data"]).Month && i>0){
          if (intMese<dt.Month || intAnno<dt.Year){
            strColor="alert";
          }else{
            strColor="success";
          }
        %>
          <%
          decTotMese=0;
      }
      intMese=Convert.ToDateTime(dtPagamentiScaduti.Rows[i]["Pagamenti_Data"]).Month;
      intAnno=Convert.ToDateTime(dtPagamentiScaduti.Rows[i]["Pagamenti_Data"]).Year;
			%>
      <tr class="riga<%=i%2%>">
        <td>
          <div>
						<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtPagamentiScaduti.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="Fattura <%=dtPagamentiScaduti.Rows[i]["Pagamenti_Riferimenti"].ToString()%>"><i class="fa-duotone fa-users fa-fw"></i><%=dtPagamentiScaduti.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
        	</div>
        </td>
        <td class="small-text-left large-text-center td-date"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtPagamentiScaduti.Rows[i]["Pagamenti_Data_IT"].ToString()%></td>
        <td class="small-text-left large-text-center hide-for-small-only">
				<span class="show-for-small-only left">Promemoria:</span><strong><%=dtPagamentiScaduti.Rows[i]["Pagamenti_NumeroPromemoria"].ToString()%> <i class="fa-duotone fa-envelope fa-fw"></i> - <strong><%=dtPagamentiScaduti.Rows[i]["Pagamenti_NumeroChiamate"].ToString()%></strong> <i class="fa-duotone fa-phone fa-fw"></i></strong>
				<a href="/admin/app/attivita/actions/segna-chiamata-pagamenti.aspx?sorgente=home&Pagamenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>&Documenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Documenti_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtPagamentiScaduti.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="Segna una chiamata in pi&ugrave;" class="alert">
					<span class="fa-layers fa-fw">				
						<i class="fa-duotone fa-phone-plus fa-fw"></i>
					</span>
				</a>
				</td>
        <td class="small-text-left large-text-right number shrink"><%=Smartdesk.Functions.getGG(dtPagamentiScaduti.Rows[i]["ggTrascorsi"].ToString())%></td>
        <td class="small-text-left large-text-right number shrink" style="padding-right:5px"><strong>&euro; <%=dtPagamentiScaduti.Rows[i]["Pagamenti_Importo_IT"].ToString()%></strong></td>
        <td class="show-for-medium-up small-text-left large-text-center nowrap hide-for-small-only"><a href="/admin/app/pagamenti/actions/pagamento-pagato.aspx?Anagrafiche_Ky=<%=dtPagamentiScaduti.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString()%>&Pagamenti_Pagato=1&sorgente=home" title="Segna come pagato"><i class="fa-duotone fa-check fa-lg"></i></a></td>
      </tr>
      <%
        decTotMese+=Convert.ToDecimal(dtPagamentiScaduti.Rows[i]["Pagamenti_Importo"]);
        decTot+=Convert.ToDecimal(dtPagamentiScaduti.Rows[i]["Pagamenti_Importo"]);
        intAnagrafiche_Ky=Convert.ToInt32(dtPagamentiScaduti.Rows[i]["Anagrafiche_Ky"].ToString());
      }
      %>
    <% } %>
    </table>
    </div>
  </div>
  <div class="card-divider">
    <div class="text-right" style="width:100%;padding-right:4rem;">Totale: <strong>&euro; <%=decTot.ToString("N2", ci)%></strong></div>
  </div>
</div>
