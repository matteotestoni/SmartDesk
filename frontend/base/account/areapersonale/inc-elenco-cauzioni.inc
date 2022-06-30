<% if (dtAsteCauzioni.Rows.Count>0){ %>
<h2>Cauzioni pagate</h2>
<hr>
<table class="hover stack">
<thead>
  <tr>
    <th>Asta</th>
    <th>Pagata il</th>
    <th>Valore</th>
    <th>Tramite</th>
    <th>Riferimenti</th>
    <th class="text-center">Autorizzata</th>
  </tr>
</thead>
<tbody>
	<% for (int i = 0; i < dtAsteCauzioni.Rows.Count; i++){%>
  <tr>
    <td class="large-text-left small-text-left"><%=dtAsteCauzioni.Rows[i]["Aste_Titolo"].ToString()%></td>
    <td class="large-text-left small-text-left"><%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Data"].ToString()%></td>
    <td class="large-text-left small-text-left"><%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Valore"].ToString()%></td>
    <td class="large-text-left small-text-left"><%=dtAsteCauzioni.Rows[i]["PagamentiMetodo_Descrizione"].ToString()%></td>
    <td class="large-text-left small-text-left"><%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Riferimenti"].ToString()%></td>
		<td class="text-center">
			<% if (dtAsteCauzioni.Rows[i]["AsteCauzioni_Autorizzata"].Equals(true)){ %>
				<i class="fa-duotone fa-check-square-o fa-fw"></i>
			<% }else{  %>
				<i class="fa-duotone fa-square-o fa-fw"></i>
			<% } %>
    </td>
  </tr>
	<% } %>
</tbody>
</table>
<% } %>
