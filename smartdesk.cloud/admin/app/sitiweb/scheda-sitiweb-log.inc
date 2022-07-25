<% if (strAzione!="new"){ %>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<a name="log"></a>
		<div class="card">
		  <div class="card-divider">
					<h2><i class="fa-duotone fa-table fa-lg fa-fw"></i>Log del sito (<%=dtSitiWebLog.Rows.Count%>)</h2>
			</div>        
	  	<div class="card-section">
				<div class="grid-x grid-padding-x">
    		<% 
				if (dtSitiWebLog!=null && dtSitiWebLog.Rows.Count>0){ 
 					j=1;
					for (int i = 0; i < dtSitiWebLog.Rows.Count; i++){
						if (strSitiWebLog_Descrizione!=dtSitiWebLog.Rows[i]["SitiWebLog_Descrizione"].ToString()){
							if (i>0){
								j=j+1;
								Response.Write("</tbody></table></div>");
							}
							%>
				      <div class="small-12 large-6 medium-6 cell">
							<% if (dtSitiWebLog.Rows[i]["SitiWebLog_Descrizione"].ToString()=="PageSpeed Score"){ %>
							<table class="highchart grid stack" border="0" data-graph-container="#<%=dtSitiWebLog.Rows[i]["SitiWebLog_Descrizione"].ToString().Replace(" ","-")%>" data-graph-type="area" data-graph-area-fillOpacity="0.75" id="<%=dtSitiWebLog.Rows[i]["SitiWebLog_Descrizione"].ToString().Replace(" ","-")%>">
							<% }else{ %>
							<table class="grid stack" border="0" data-graph-container="#grafico<%=j.ToString()%>" data-graph-type="line">
							<% } %>
								<caption><%=dtSitiWebLog.Rows[i]["SitiWebLog_Descrizione"].ToString()%></caption>
					    	<thead>
				        <tr>
				          <th width="110" class="text-center date">Data</th>
						  <th class="text-center" width="60">Desktop</th>
                          <th class="text-center" width="60">Mobile</th>
				        </tr>
					    	</thead>
					    	<tbody>
					<%
							}
					%>
						<tr>
              <td class="text-left"><%=dtSitiWebLog.Rows[i]["SitiWebLog_Data"].ToString()%></td>
              <td class="large-text-center small-text-left"><%=dtSitiWebLog.Rows[i]["SitiWebLog_Valore"].ToString()%></td>
              <td class="large-text-center small-text-left"><%=dtSitiWebLog.Rows[i]["SitiWebLog_Valore"].ToString()%></td>
            </tr>
	        <%
						strSitiWebLog_Descrizione=dtSitiWebLog.Rows[i]["SitiWebLog_Descrizione"].ToString();
					}
					Response.Write("</tbody></table></div>");
					%>
	    	
						<div class="small-6 large-2 medium-2 cell">
						</div>
					</div>        
			    <% }else{
			      Response.Write("<span class=\"messaggio\">Nessun log</span>");
			    } %>
        </div>
    	</div>
  </div>
</div>
<% } %>
