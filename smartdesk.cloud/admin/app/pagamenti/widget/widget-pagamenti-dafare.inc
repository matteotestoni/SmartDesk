<div class="card">
<div class="card-divider">
	<h2><i class="fa-duotone fa-euro-sign fa-fw"></i>Pagamenti in uscita (<%=dtPagamentiDaFare.Rows.Count%>)</h2>
	<div class="button-group tiny">
		<a href="/admin/app/pagamenti/elenco-pagamenti-da-fare.aspx" class="button small clear"><i class="fa-duotone fa-eye fa-fw fa-lg"></i>Visualizza tutti</a>
	</div>
</div>
<div class="card-section">
<div class="divgridcard">
<table class="grid hover scroll" border="0" width="100%">
<thead>
	<tr>
    <th width="200" class="text-left">Fornitore</th>
    <th width="50" class="text-left hide-for-small-only"></th>
    <th width="110" class="text-center date">Scadenza</th>
    <th width="40" class="text-center number">gg</th>
    <th width="80" class="text-center number">Importo</th>
    <th width="12" class="nowrap"></th>
  </tr>
</thead>
<%
  decTot=0;
  decTotMese=0;
  if (dtPagamentiDaFare!=null){
    for (int i = 0; i < dtPagamentiDaFare.Rows.Count; i++){
      if (intMese!=Convert.ToDateTime(dtPagamentiDaFare.Rows[i]["Pagamenti_Data"]).Month && i>0){
        if (intMese<dt.Month || intAnno<dt.Year){
          strColor="#ff0000";
        }else{
          strColor="#009933";
        }
      %>
        <%
        decTotMese=0;
    }
    intMese=Convert.ToDateTime(dtPagamentiDaFare.Rows[i]["Pagamenti_Data"]).Month;
    intAnno=Convert.ToDateTime(dtPagamentiDaFare.Rows[i]["Pagamenti_Data"]).Year;
   	%>
      <tr class="riga<%=i%2%>">
        <td>
          <div class=" expand">
						<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtPagamentiDaFare.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="Fattura <%=dtPagamentiDaFare.Rows[i]["Pagamenti_Riferimenti"].ToString()%>"><i class="fa-duotone fa-users fa-fw"></i><%=dtPagamentiDaFare.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
        	</div>
        </td>
      	<td class="small-text-left large-text-left hide-for-small-only"><i class="fa-duotone fa-circle-info fa-fw fa-lg" data-tooltip title="<%=dtPagamentiDaFare.Rows[i]["Pagamenti_Riferimenti"].ToString()%>" style="z-index:999;--fa-primary-color: white;--fa-secondary-color: blue;"></i></td>
        <td class="small-text-left large-text-center date"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtPagamentiDaFare.Rows[i]["Pagamenti_Data_IT"].ToString()%></td>
        <td class="small-text-left large-text-right number shrink"><%=Smartdesk.Functions.getGGDaFare(dtPagamentiDaFare.Rows[i]["ggTrascorsi"].ToString())%></td>
        <td class="small-text-left large-text-right number shrink"><strong>&euro; <%=dtPagamentiDaFare.Rows[i]["Pagamenti_Importo_IT"].ToString()%></strong></td>
        <td class="show-for-medium-up small-text-left large-text-center nowrap"><a href="/admin/app/pagamenti/actions/pagamento-pagato.aspx?Anagrafiche_Ky=<%=dtPagamentiDaFare.Rows[i]["Anagrafiche_Ky"].ToString()%>&Pagamenti_Ky=<%=dtPagamentiDaFare.Rows[i]["Pagamenti_Ky"].ToString()%>&Pagamenti_Pagato=1&sorgente=home" title="Segna come pagato"><i class="fa-duotone fa-check fa-lg"></i></a></td>
      </tr>
    <%
      decTotMese+=Convert.ToDecimal(dtPagamentiDaFare.Rows[i]["Pagamenti_Importo"]);
      decTot+=Convert.ToDecimal(dtPagamentiDaFare.Rows[i]["Pagamenti_Importo"]);
      intAnagrafiche_Ky=Convert.ToInt32(dtPagamentiDaFare.Rows[i]["Anagrafiche_Ky"].ToString());
    } %>
    <tfoot>
      <tr class="totale">
        <td bgcolor="#ffffff" colspan="3"></td>
				<td colspan="2" class="text-right">Totale: <strong>&euro; <%=decTot.ToString("N2", ci)%></strong></td>
        <td bgcolor="#ffffff"></td>
      </tr>
    </tfoot>
  	</table>
  	</div>
  <% } %>
  </div>
</div>
