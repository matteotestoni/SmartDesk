<% if (dtAsteCommissioni!=null && dtAsteCommissioni.Rows.Count>0){%>
<table class="grid hover stack" style="width:auto;">
	<thead>
    <tr>
			<th width="200" class="text-right">Da  &euro;</th>
			<th width="200" class="text-right">A  &euro;</th>
			<th width="160" class="text-right">Commissione %</th>
    </tr>
	</thead>
	<tbody>
    <%for (int i = 0; i < dtAsteCommissioni.Rows.Count; i++){ %>
        <tr class="riga<%=i%2%>">
    			<td class="text-right"><%=((decimal)dtAsteCommissioni.Rows[i]["AsteCommissioni_Da"]).ToString("N2",ci)%> &euro;</td>
    			<td class="text-right">
						<%
						if (Convert.ToDecimal(dtAsteCommissioni.Rows[i]["AsteCommissioni_A"]).ToString("N2",ci)=="99.999.999.999,00"){
							Response.Write("oltre");
						}else{
							Response.Write(((decimal)dtAsteCommissioni.Rows[i]["AsteCommissioni_A"]).ToString("N2",ci));
						}
						%>
					</td>
    			<td class="text-right">
					<%
					if (dtAsteCommissioni.Rows[i]["AsteCommissioni_Commissione"].ToString().Length>0){
						Response.Write(Convert.ToDecimal(dtAsteCommissioni.Rows[i]["AsteCommissioni_Commissione"]).ToString("N2",ci));
					}else{
						Response.Write("0");
					}
					%>%</td>
        </tr>
    <% } %>
  	</tbody>
</table>
<%} %> 
