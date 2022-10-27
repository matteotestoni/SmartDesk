<div class="card">
<div class="card-divider">
	<h2><i class="fa-duotone fa-euro-sign fa-fw"></i>Pagamenti in entrata Prossimi 40 gg (<%=dtPagamentiFuturi.Rows.Count%>)</h2> 
	<div class="button-group tiny">
			<a href="/admin/app/pagamenti/elenco-pagamenti.aspx" class="button small clear"><i class="fa-duotone fa-eye fa-fw fa-lg"></i> Visualizza tutti</a>
	</div>
</div>
<div class="card-section" style="height:450px;max-height:450px;overflow:auto;">
	<div class="divgridcard">
	<table class="grid hover scroll" border="0" width="100%">
	<thead>
		<tr>
      <th width="150" class="text-left">Anagrafica</th>
      <th width="110" class="text-center date">Data</th>
      <th width="80" class="text-center hide-for-small-only">Promemoria</th>
      <th width="40" class="text-center number">gg</th>
      <th width="80" class="text-center number">Importo</th>
      <th width="12" class="nowrap"></th>
    </tr>
	</thead>
  <%
    decTot=0;
    decTotMese=0;
    if (dtPagamentiFuturi!=null){
      for (int i = 0; i < dtPagamentiFuturi.Rows.Count; i++){
        if (intMese!=Convert.ToDateTime(dtPagamentiFuturi.Rows[i]["Pagamenti_Data"]).Month && i>1){
          if (intMese<dt.Month || intAnno<dt.Year){
            strColor="#ff0000";
          }else{
            strColor="#009933";
          }
        %>
          <%
          decTotMese=0;
      }
      intMese=Convert.ToDateTime(dtPagamentiFuturi.Rows[i]["Pagamenti_Data"]).Month;
      intAnno=Convert.ToDateTime(dtPagamentiFuturi.Rows[i]["Pagamenti_Data"]).Year;
     	%>
        <tr class="riga<%=i%2%>">
          <td>
            <div>
							<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtPagamentiFuturi.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="Fattura <%=dtPagamentiFuturi.Rows[i]["Pagamenti_Riferimenti"].ToString()%>"><i class="fa-duotone fa-users fa-fw"></i><%=dtPagamentiFuturi.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
          	</div>
          </a>
          </td>
          <td class="small-text-left large-text-center date"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtPagamentiFuturi.Rows[i]["Pagamenti_Data_IT"].ToString()%></td>
          <td class="small-text-left large-text-right hide-for-small-only shrink"><span class="hide-for-large left">Numero promemoria:</span><strong><%=dtPagamentiFuturi.Rows[i]["Pagamenti_NumeroPromemoria"].ToString()%> <i class="fa-duotone fa-envelope fa-fw"></i></strong></td>
          <td class="small-text-left large-text-right number shrink"><%=Smartdesk.Functions.getGG(dtPagamentiFuturi.Rows[i]["ggTrascorsi"].ToString())%></td>
          <td class="small-text-left large-text-right number shrink" style="padding-right:5px"><strong>&euro; <%=dtPagamentiFuturi.Rows[i]["Pagamenti_Importo_IT"].ToString()%></strong></td>
          <td class="show-for-medium-up small-text-left large-text-center nowrap"><a href="/admin/app/pagamenti/actions/pagamento-pagato.aspx?Anagrafiche_Ky=<%=dtPagamentiFuturi.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiFuturi.Rows[i]["Pagamenti_Ky"].ToString()%>&Pagamenti_Pagato=1&sorgente=home" title="Segna come pagato"><i class="fa-duotone fa-check fa-lg"></i></a></td>
        </tr>
      <%
        decTotMese+=Convert.ToDecimal(dtPagamentiFuturi.Rows[i]["Pagamenti_Importo"]);
        decTot+=Convert.ToDecimal(dtPagamentiFuturi.Rows[i]["Pagamenti_Importo"]);
        intAnagrafiche_Ky=Convert.ToInt32(dtPagamentiFuturi.Rows[i]["Anagrafiche_Ky"].ToString());
      } %>
    	</table>
    	</div>
    	<% } %>
	</div>
  <div class="card-divider">
    <div class="text-right" style="width:100%;padding-right:4rem;">Totale: <strong>&euro; <%=decTot.ToString("N2", ci)%></strong></div>
  </div>
</div>
