<% if (strAzione!="new" && dtLogin.Rows[0]["UtentiGruppi_Commerciale"].Equals(true) && dtLogin.Rows[0]["UtentiGruppi_Preventivi"].Equals(true)){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
  	<a name="documenti"></a>
		<div class="divgrid" id="divgrid">
		  <h2><i class="fa-duotone fa-file fa-lg fa-fw" style="--fa-primary-color:red;--fa-primary-opacity: 1.0"></i> Documenti (<%=dtDocumenti.Rows.Count%>)</h2> 
    <% if (dtDocumenti.Rows.Count>0){ %>
			<table class="grid hover scroll" border="0" width="100%">
	    	<thead>
        <tr>
          <th width="40" class="text-left">Cod.</th>
          <th width="80" align="left">Tipo</th>
          <th width="40" align="left">Numero</th>
          <th width="80" align="left">Data</th>
          <th width="300" align="left">Descrizione</th>
	        <th width="90" class="text-center">Imponibile &euro;</th>
	        <th width="90" class="text-center">IVA &euro;</th>
	        <th width="110" class="text-center">Totale &euro;</th>
					<th width="60" class="text-center nowrap"></th>
        </tr>
	    	</thead>
	    	<tbody>
        <%for (int i = 0; i < dtDocumenti.Rows.Count; i++){ %>
            <tr>
	            <td class="text-left nowrap"><a href="/admin/app/documenti/scheda-documenti.aspx?Documenti_Ky=<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>&sorgente=scheda-opportunita"><%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%></a></td>
              <td class="text-left nowrap"><%=dtDocumenti.Rows[i]["DocumentiTipo_Descrizione"].ToString()%></td>
              <td class="text-left nowrap"><%=dtDocumenti.Rows[i]["Documenti_Numero"].ToString()%></td>
              <td class="text-left nowrap"><%=dtDocumenti.Rows[i]["Documenti_Data"].ToString()%></td>
              <td class="text-left nowrap"><div class="width500"><%=dtDocumenti.Rows[i]["Documenti_Descrizione"].ToString()%></div></td>
		          <td class="large-text-right small-text-left" style="padding-right:5px" class="segno<%=dtDocumenti.Rows[i]["DocumentiTipo_Segno"].ToString()%>"><small>&euro; <%=((decimal)dtDocumenti.Rows[i]["Documenti_TotaleRighe"]).ToString("N2", ci)%></small></td>
		          <td class="large-text-right small-text-left" style="padding-right:5px" class="segno<%=dtDocumenti.Rows[i]["DocumentiTipo_Segno"].ToString()%>"><small>&euro; <%=((decimal)dtDocumenti.Rows[i]["Documenti_TotaleIVA"]).ToString("N2", ci)%></small></td>
		          <td class="large-text-right small-text-left" style="padding-right:5px" class="segno<%=dtDocumenti.Rows[i]["DocumentiTipo_Segno"].ToString()%>"><strong>&euro; <%=((decimal)dtDocumenti.Rows[i]["Documenti_Totale"]).ToString("N2", ci)%></strong></td>
              <td class="text-center nowrap">
              	<a href="/admin/app/documenti/crud/elimina-documenti.aspx?azione=delete&Opportunita_Ky=<%=dtDocumenti.Rows[i]["Opportunita_Ky"].ToString()%>&Documenti_Ky=<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>&sorgente=scheda-opportunita" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
							</td>
            </tr>
        <% } %>
	    	</tbody>
      </table>
    <% }else{
			Response.Write("<div class=\"messaggio\"><i class=\"fa-duotone fa-circle-info fa-fw\"></i>Nessun documento<br><br></div>");
    } %>
    </div>
	</div>
</div>
<% } %>
