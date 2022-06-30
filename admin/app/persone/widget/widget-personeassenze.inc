 <%
	System.Data.DataTable dtPersoneAssenze;
	int intOreFerie;
	decimal decSaldo;
	decimal decTotAssenze = 0;
	decimal decTotPresenzeOrdinarie = 0;
	decimal decTotPresenzeStraordinarie = 0;
	decimal decTotRecuperi = 0;
	decimal decTotMalattia = 0;
	decimal decTotCassaIntegrazione = 0;
	decimal decTotProgressivo = 0;

	string strWHERENet="";
	strWHERENet="Persone_Ky=" + dtLogin.Rows[0]["Persone_Ky"].ToString() + " AND PersoneAssenze_Anno=" + DateTime.Now.Year + " AND Month(PersoneAssenze_Data)=" + DateTime.Now.Month;
	string strFROMNet = "PersoneAssenze_Vw";
	string strORDERNet = "Persone_Cognome, PersoneAssenze_Data ASC";
	dtPersoneAssenze = new System.Data.DataTable("PersoneAssenze");
	dtPersoneAssenze = Smartdesk.Sql.getTablePage(strFROMNet, null, "PersoneAssenze_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
%>
		<div id="divgrid" class="divgrid">
		<table class="grid hover scroll" border="0" width="100%">
			<thead>
				<tr>
	        	<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
				<th width="110" class="text-center date">Data</th>
				<th width="80">Giorno</th>
				<th width="100">Settimana</th>
				<th width="130">Anno compentenza</th>
				<th align="left" width="250">Descrizione</th>
				<th width="70" class="text-right">Ore</th>
				<th width="120" class="text-center">Tipo</th>
				<th width="12" class="nowrap" data-orderable="false"></th>
				<th width="12" class="nowrap" data-orderable="false"></th>
				</tr>
			</thead>
    		<tbody>
              <%
			  for (int j = 0; j < dtPersoneAssenze.Rows.Count; j++){
			  %>

		        <tr class="riga<%=i%2%>" id="<%=dtPersoneAssenze.Rows[j]["PersoneAssenze_Ky"].ToString()%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtPersoneAssenze.Rows[j]["PersoneAssenze_Ky"].ToString()%>" data-value="<%=dtPersoneAssenze.Rows[j]["PersoneAssenze_Ky"].ToString()%>" /></td>
		          <td>
		            <i class="fa-duotone fa-calendar-days fa-fw"></i>
					  <% if (dtPersoneAssenze.Rows[j]["PersoneAssenze_Lock"].Equals(false)){ %>
					  <a href="/admin/form.aspx?CoreModules_Ky=22&CoreEntities_Ky=39&CoreForms_Ky=106&PersoneAssenze_Ky=<%=dtPersoneAssenze.Rows[j]["PersoneAssenze_Ky"].ToString()%>">
					  <% } %>
							<%=dtPersoneAssenze.Rows[j]["PersoneAssenze_Data_IT"].ToString()%>
					  <% if (dtPersoneAssenze.Rows[j]["PersoneAssenze_Lock"].Equals(false)){ %>
						</a> 
					  <% } %>

		          </td>
		          <td class="large-text-center small-text-left date"><%=Smartdesk.Functions.GetGiorno(dtPersoneAssenze.Rows[j]["PersoneAssenze_Data"].ToString())%></td>
		          <td class="large-text-center small-text-left date"><%=Smartdesk.Functions.GetSettimana(dtPersoneAssenze.Rows[j]["PersoneAssenze_Data"].ToString())%></td>
		          <td class="large-text-center small-text-left number"><%=dtPersoneAssenze.Rows[j]["PersoneAssenze_Anno"].ToString()%></td>
		          <td><div class="width300"><%=dtPersoneAssenze.Rows[j]["PersoneAssenze_Descrizione"].ToString()%></div></td>
		          <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=dtPersoneAssenze.Rows[j]["PersoneAssenzeTipo_Segno"].ToString()%><%=dtPersoneAssenze.Rows[j]["PersoneAssenze_Ore"].ToString()%></strong></td>
		          <td class="large-text-center small-text-left"><strong><%=dtPersoneAssenze.Rows[j]["PersoneAssenzeTipo_Descrizione"].ToString()%></strong></td>
		          <td>
					<% if (dtPersoneAssenze.Rows[j]["PersoneAssenze_Lock"].Equals(false)){ %>
						<a href="/admin/app/persone/actions/conferma-assenza.aspx?PersoneAssenze_Ky=<%=dtPersoneAssenze.Rows[j]["PersoneAssenze_Ky"].ToString()%>&Persone_Ky=<%=dtPersoneAssenze.Rows[j]["Persone_Ky"].ToString()%>&sorgente=elenco-personeassenze" title="conferma assenza pianificata"><i class="fa-duotone fa-check success"></i></a>
					<% } %>
				  </td>
				<td>
					<% if (dtPersoneAssenze.Rows[j]["PersoneAssenze_Lock"].Equals(false)){ %>
						<a href="/admin/app/persone/crud/elimina-personeassenze.aspx?azione=delete&PersoneAssenze_Ky=<%=dtPersoneAssenze.Rows[j]["PersoneAssenze_Ky"].ToString()%>&Persone_Ky=<%=dtPersoneAssenze.Rows[j]["Persone_Ky"].ToString()%>&sorgente=elenco-personeassenze" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
					<% } %>
				</td>
		        </tr>
		    <%
					switch (Convert.ToInt32(dtPersoneAssenze.Rows[j]["PersoneAssenzeTipo_Ky"])){
						case 1:
							decTotAssenze+=Convert.ToDecimal(dtPersoneAssenze.Rows[j]["PersoneAssenze_Ore"]);
							break;
						case 2:
							decTotRecuperi+=Convert.ToDecimal(dtPersoneAssenze.Rows[j]["PersoneAssenze_Ore"]);
							break;
						case 3:
							decTotMalattia+=Convert.ToDecimal(dtPersoneAssenze.Rows[j]["PersoneAssenze_Ore"]);
							break;
						case 4:
							decTotCassaIntegrazione+=Convert.ToDecimal(dtPersoneAssenze.Rows[j]["PersoneAssenze_Ore"]);
							break;					
						case 5:
							decTotPresenzeOrdinarie+=Convert.ToDecimal(dtPersoneAssenze.Rows[j]["PersoneAssenze_Ore"]);
							break;
						case 6:
							decTotPresenzeStraordinarie+=Convert.ToDecimal(dtPersoneAssenze.Rows[j]["PersoneAssenze_Ore"]);
							break;
					}
		      		intPersone_Ky=Convert.ToInt32(dtPersoneAssenze.Rows[j]["Persone_Ky"].ToString());
					intAnno=Convert.ToInt32(dtPersoneAssenze.Rows[j]["PersoneAssenze_Anno"].ToString());			
				}
				%>
		<tr class="totale">
	        <td bgcolor="#ffffff" colspan="5"></td>
            <td class="large-text-right small-text-left">Assenze <%=intAnno%>:</td>
            <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=decTotAssenze.ToString("N2", ci)%></strong></td>
            <td colspan="2">| circa <%=(decTotAssenze/8).ToString("N2", ci)%> giorni</td>
	        <td bgcolor="#ffffff"></td>
        </tr>
		<tr class="totale">
	        <td bgcolor="#ffffff" colspan="5"></td>
            <td class="large-text-right small-text-left">Recuperi <%=intAnno%>:</td>
            <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=decTotRecuperi.ToString("N2", ci)%></strong></td>
            <td colspan="2">| circa <%=(decTotRecuperi/8).ToString("N2", ci)%> giorni</td>
	        <td bgcolor="#ffffff"></td>
         </tr>
		<tr class="totale">
	        <td bgcolor="#ffffff" colspan="5"></td>
            <td class="large-text-right small-text-left">Presenze ordinarie <%=intAnno%>:</td>
            <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=decTotPresenzeOrdinarie.ToString("N2", ci)%></strong></td>
            <td colspan="2">| circa <%=(decTotPresenzeOrdinarie/8).ToString("N2", ci)%> giorni</td>
	        <td bgcolor="#ffffff"></td>
         </tr>
		<tr class="totale">
	        <td bgcolor="#ffffff" colspan="5"></td>
            <td class="large-text-right small-text-left">Presenze straordinarie <%=intAnno%>:</td>
            <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=decTotPresenzeStraordinarie.ToString("N2", ci)%></strong></td>
            <td colspan="2">| circa <%=(decTotPresenzeStraordinarie/8).ToString("N2", ci)%> giorni</td>
	        <td bgcolor="#ffffff"></td>
         </tr>
		<tr class="totale">
	        <td bgcolor="#ffffff" colspan="5"></td>
            <td class="large-text-right small-text-left">Malattia <%=intAnno%>:</td>
            <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=decTotMalattia.ToString("N2", ci)%></strong></td>
            <td colspan="2">| circa <%=(decTotMalattia/8).ToString("N2", ci)%> giorni</td>
	        <td bgcolor="#ffffff"></td>
        </tr>
		<tr class="totale">
	        <td bgcolor="#ffffff" colspan="5"></td>
            <td class="large-text-right small-text-left">Cassa integrazione <%=intAnno%>:</td>
            <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=decTotCassaIntegrazione.ToString("N2", ci)%></strong></td>
            <td colspan="2">| circa <%=(decTotCassaIntegrazione/8).ToString("N2", ci)%> giorni</td>
	        <td bgcolor="#ffffff"></td>
        </tr>
    </table>

	</div>
