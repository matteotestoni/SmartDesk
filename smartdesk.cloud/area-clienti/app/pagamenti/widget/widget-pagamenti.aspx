<%
  System.Data.DataTable dtPagamenti;
    strWHERENet="(PagamentiTipo_Ky=1) AND (Anagrafiche_Ky=" + strAnagrafiche_Ky + ")";
    strFROMNet = "Pagamenti_Vw";
    strORDERNet = "Pagamenti_Data";
    dtPagamenti = new System.Data.DataTable("Pagamenti");
    dtPagamenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
if (dtPagamenti.Rows.Count>0){%>
    <div class="card" id="sectionpagamenti">
      <div class="card-divider">
        <h2>I tuoi pagamenti</h2>
      </div>		  
    	<div class="card-section">        
        <%if (dtPagamenti.Rows.Count>0){%>
        <table class="grid stack hover" border="0" style="width:100%;">
        	<thead>
              <tr>
                <th class="text-center" width="70">Scadenza</th>
            	<th class="text-right" width="90">Importo &euro;</th>
            	<th width="50">Pagato</th>
                <th class="text-center" width="80">GG Ritardo</th>
            	<th width="300">Riferimenti</th>
                <th width="80">Promemoria</th>
                <th width="80">Ultimo</th>
              </tr>
        	</thead>
        	<tbody>
          <%
        		for (int i = 0; i < dtPagamenti.Rows.Count; i++){%>
              <tr>
                <td class="text-center"><i class="fa-duotone fa-calendar fa-fw"></i><%=dtPagamenti.Rows[i]["Pagamenti_Data_IT"].ToString()%></td>
                <td class="text-right" style="padding-right:5px">&euro; <%=dtPagamenti.Rows[i]["Pagamenti_Importo_IT"].ToString()%></td>
                <td class="text-center"><%=dtPagamenti.Rows[i]["Pagamenti_Pagato"].ToString()%></td>
                <td class="text-center"><%=dtPagamenti.Rows[i]["ggRitardoDaScadenza"].ToString()%></td>
                <td><div class="width250">Fattura <%=dtPagamenti.Rows[i]["Pagamenti_Riferimenti"].ToString()%></div></td>
                <td class="text-center"><b><%=dtPagamenti.Rows[i]["Pagamenti_NumeroPromemoria"].ToString()%></b></td>
                <td class="text-center"><b><%=dtPagamenti.Rows[i]["Pagamenti_UltimoPromemoria_IT"].ToString()%></b></td>
              </tr>
          <%
        		}%>
        	</tbody>
        </table>
        <%}else{
          Response.Write("<span class=\"messaggio\">Nessun pagamento da ricevere</span>");
        }%>
        </div>
    </div>
<% } %>
