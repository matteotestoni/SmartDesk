<%
	        System.Data.DataTable dtDocumenti;
            strWHERENet="(Documenti_Anno=2018) AND (Anagrafiche_Ky=" + strAnagrafiche_Ky + ")";
            strFROMNet = "Documenti_Vw";
            strORDERNet = "Documenti_Data DESC";
            dtDocumenti = new System.Data.DataTable("Documenti");
            dtDocumenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
 %>            
<%if (dtDocumenti.Rows.Count>0){%>
    <div class="card" id="sectiondocumenti">
      <div class="card-divider">
        <h2>I tuoi documenti</h2>
      </div>		  
    	<div class="card-section">
				<%if (dtDocumenti.Rows.Count>0){%>
		    <table id="rswgrid" class="grid stack hover" border="0" style="width:100%">
		    	<thead>
			      <tr>
			        <th width="80">Tipo</th>
			        <th width="150">Stato</th>
			        <th width="160">Oggetto</th>
			        <th width="80">Numero</th>
			        <th width="80" align="center">Data</th>
			        <th width="80" class="text-right">Totale servizi</th>
			        <th width="80" class="text-right">Totale IVA</th>
			        <th width="80" class="text-right">Totale</th>
			      </tr>
		    	</thead>
		    	<tbody>
				    <%for (int i = 0; i < dtDocumenti.Rows.Count; i++){ %>
				        <tr class="riga<%=i%2%>">
				          <td class="text-left"><%=dtDocumenti.Rows[i]["DocumentiTipo_Descrizione"].ToString()%></td>
				          <td class="text-left"><b><%=dtDocumenti.Rows[i]["DocumentiStato_Descrizione"].ToString()%></b></td>
				          <td class="text-left"><b><%=dtDocumenti.Rows[i]["Documenti_Descrizione"].ToString()%></b></td>
				          <td class="text-center"><%=dtDocumenti.Rows[i]["Documenti_Numero"].ToString()%></td>
				          <td class="text-center"><i class="fa-duotone fa-calendar fa-fw"></i><%=dtDocumenti.Rows[i]["Documenti_Data_IT"].ToString()%></td>
				          <td class="text-right"><%=((decimal)dtDocumenti.Rows[i]["Documenti_TotaleRighe"]).ToString("N2", ci)%></td>
				          <td class="text-right"><%=((decimal)dtDocumenti.Rows[i]["Documenti_TotaleIVA"]).ToString("N2", ci)%></td>
				          <td class="text-right"><%=((decimal)dtDocumenti.Rows[i]["Documenti_Totale"]).ToString("N2", ci)%></td>
				        </tr>
				    <%
				    }%>
			    	</tbody>
		    </table>
		 	  <%}else{
			    Response.Write("<span class=\"messaggio\">Nessun documento emesso</span>");
			  }%>
        </div>
    </div>
<% } %>
