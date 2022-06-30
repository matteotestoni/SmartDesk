<% if (strAzione!="new"){ %>
<div class="grid-x grid-padding-x hide">
  <div class="small-12 medium-12 large-12 cell">
		<a name="log"></a>
		<div class="titolotabella">
			<div class="grid-x grid-padding-x">
				<div class="small-12 medium-12 large-12 cell">
					<h2><i class="fa-duotone fa-table fa-lg fa-fw"></i>Log Google Page Speed (<%=dtSitiWebPageSpeedLog.Rows.Count%>)</h2>
				</div>
			</div>        
		</div>
        <% if (dtSitiWebPageSpeedLog!=null && dtSitiWebPageSpeedLog.Rows.Count>0){ %>
    		<div class="grid-x grid-padding-x">
		    <div class="small-12 large-12 medium-12 cell">
		            <table class="highchart grid" border="0" data-graph-container="#PageSpeed-Score" data-graph-type="area" data-graph-area-fillOpacity="0.75" id="PageSpeed-Score">
		            <caption>PageSpeed Score ultime 30 rilevazioni</caption>
		            <thead>
		            <tr>
			            <th width="110" class="text-center date">Data</th>
			            <th class="text-center" width="60">Score Desktop</th>
			            <th class="text-center" width="60">Score Mobile</th>
		            </tr>
		            </thead>
		            <tbody>
                    <%for (int j = 0; j < dtSitiWebPageSpeedLog.Rows.Count; j++){ %>
			            <tr>
                          <td class="text-left"><%=dtSitiWebPageSpeedLog.Rows[j]["SitiWebPageSpeedLog_Data"].ToString()%></td>
                          <td class="large-text-center small-text-left"><%=dtSitiWebPageSpeedLog.Rows[j]["SitiWebPageSpeedLog_ScoreDesktop"].ToString()%></td>
                          <td class="large-text-center small-text-left"><%=dtSitiWebPageSpeedLog.Rows[j]["SitiWebPageSpeedLog_ScoreMobile"].ToString()%></td>
                        </tr>
                    <% } %>
		            </tbody></table>
		    </div>			    	
			<div class="small-6 large-2 medium-2 cell">
			</div>
		</div>        
    <% }else{
      Response.Write("<span class=\"messaggio\">Nessun log Google Page Speed</span>");
    } %>
        </div>
    </div>
</div>
<% } %>
