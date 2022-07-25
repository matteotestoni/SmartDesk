<table class="hover stack">
<thead>
  <tr>
    <th>Data</th>
    <th>Valore</th>
    <th>Tramite</th>
  </tr>
</thead>
<tbody>
	<% for (int i = 0; i < dtAsteCauzioni.Rows.Count; i++){%>
  <tr>
    <td><%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Data"].ToString()%></td>
    <td><%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Valore"].ToString()%></td>
    <td><%=dtAsteCauzioni.Rows[i]["PagamentiMetodo_Descrizione"].ToString()%></td>
  </tr>
	<% } %>
</tbody>
</table>
