<%
	System.Data.DataTable dtCommesse;
  strWHERENet="(Anagrafiche_Ky=" + strAnagrafiche_Ky + ")";
	strFROMNet = "Commesse_Vw";
	strORDERNet = "Commesse_Data DESC";
	dtCommesse = new System.Data.DataTable("Commesse");
	dtCommesse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
 %>            
<% if (dtCommesse.Rows.Count>0){ %>
<div class="card" id="sectionprogetti">
	<div class="card-divider">
    <h2>I tuoi progetti e contratti ad ore</h2>
  </div>		  
	<div class="card-section">
      <table class="grid stack hover" border="0" style="width:100%">
      	<thead>
  	      <tr>
  	        <th width="30">Codice</th>
  	        <th width="120">Data</th>
  	        <th width="400">Titolo</th>
  	        <th width="160">Stato</th>
  	        <th width="160">Riferimenti</th>
  	        <th></th>
  	      </tr>
      	</thead>
      	<tbody>
  		    <% for (int i = 0; i < dtCommesse.Rows.Count; i++){ %>
  		        <tr class="riga<%=i%2%>">
  		          <td><a href="/area-clienti/app/progetti/scheda-progetti.aspx?Commesse_Ky=<%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%>"><%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%></a></td>
  		          <td><%=dtCommesse.Rows[i]["Commesse_Data_IT"].ToString()%></td>
  		          <td><div class="Titologrid"><%=dtCommesse.Rows[i]["Commesse_Titolo"].ToString()%></div></td>
  				      <td class="text-left"><i class="fa-duotone <%=dtCommesse.Rows[i]["CommesseStato_Icona"].ToString()%>"></i><%=dtCommesse.Rows[i]["CommesseStato_Descrizione"].ToString()%></td>
  		          <td class="text-left"><%=dtCommesse.Rows[i]["Commesse_Riferimenti"].ToString()%></td>
                  <td class="text-left hide">
                    <a href="/area-clienti/app/progetti/report/rpt-commesse.aspx?Commesse_Ky=<%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%>" target="_blank"><i class="fa-duotone fa-print fa-fw"></i>Stampa rapporto</a>
                  </td>
  		        </tr>
  		    <% } %>
      	</tbody>
      </table>
  </div>		  
</div>
<% } %>

