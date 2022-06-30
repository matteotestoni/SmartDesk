<% if (dtAnagraficheServizi!=null && dtAnagraficheServizi.Rows.Count>0){ %>
<div class="card">
  <div class="card-divider">
			<h2><i class="fa-duotone fa-euro-sign fa-fw"></i>Servizi da fatturare</h2>
			<div class="button-group tiny">
				<a href="/admin/app/anagrafiche/elenco-anagrafiche-da-fatturare.aspx" class="button small clear"><i class="fa-duotone fa-eye fa-fw"></i> Visualizza tutti</a>
			</div>
	</div>
	<div class="card-section">
		<div class="divgridcard">
		<table class="grid hover scroll" border="0" width="100%">
   	<thead>
      <tr>
        <th width="200" class="text-left">Anagrafica</th>
        <th width="50" class="text-left"></th>
        <th width="110" class="text-center date">Scadenza</th>
        <th width="40" class="text-center number">gg</th>
        <th width="80" class="text-right number shrink">Importo</th>
        <th width="12" class="nowrap"></th>
      </tr>
   	</thead>
   	<tbody>
    <%
      decTot=0;
      for (int i = 0; i < dtAnagraficheServizi.Rows.Count; i++){
      %>
        <tr class="riga<%=i%2%>">
          <td class="text-left">
            <div>
							<a href="/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=<%=dtAnagraficheServizi.Rows[i]["Anagrafiche_Ky"].ToString()%>" title="<%=dtAnagraficheServizi.Rows[i]["Anagrafiche_Note"].ToString()%>"><i class="fa-duotone fa-users fa-fw"></i><%=dtAnagraficheServizi.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
          	</div>
          </td>
          <td class="small-text-left large-text-left number"><i class="fa-duotone fa-circle-info fa-fw fa-lg" data-tooltip title="<%=dtAnagraficheServizi.Rows[i]["Servizi_Codice"].ToString()%>" style="z-index:999;--fa-primary-color: white;--fa-secondary-color: blue;"></i></td>
          <td class="small-text-left large-text-center date"><i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Scadenza_IT"].ToString()%></strong></td>
          <td class="small-text-left large-text-right number shrink"><%=Smartdesk.Functions.getGGDaFare(dtAnagraficheServizi.Rows[i]["ggTrascorsi"].ToString())%></td>
          <td class="small-text-left large-text-right number shrink"><strong>&euro; <%=dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Importo"].ToString()%></strong></td>
          <td class="show-for-medium-up small-text-left large-text-center nowrap"><a href="/admin/app/amministrazione/servizio-fatturato.aspx?Anagrafiche_Ky=<%=dtAnagraficheServizi.Rows[i]["Anagrafiche_Ky"].ToString()%>&AnagraficheServizi_Ky=<%=dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Ky"].ToString()%>&sorgente=home" title="Segna come fattura emessa"><i class="fa-duotone fa-check fa-lg"></i></a></td>
        </tr>
    <%
      decTot+=Convert.ToDecimal(dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Importo"]);
      intAnagrafiche_Ky=Convert.ToInt32(dtAnagraficheServizi.Rows[i]["Anagrafiche_Ky"].ToString());
    } %>
    </tbody>  
		<tfoot>
      <tr class="totale">
        <td bgcolor="#ffffff" colspan="3"></td>
				<td colspan="2" class="text-right">Totale: <strong>&euro; <%=decTot.ToString("N2", ci)%></strong></td>
        <td bgcolor="#ffffff"></td>
      </tr>
    </tfoot>
    </table>
    </div>
	</div>
</div>
<% } %>
