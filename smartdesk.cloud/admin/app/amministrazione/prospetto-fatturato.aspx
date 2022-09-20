<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/amministrazione/prospetto-fatturato.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Amministrazione > prospetto fatturato</title>
	<!--#include file="/admin/inc-head.aspx"--> 
	<!--#include file="/admin/inc-head-highcharts.aspx"-->
	<script>
		jQuery(function() {
	    var chart;
	    jQuery(document).ready(function() {
	        
					//grafico1
					chart = new Highcharts.Chart({
	            chart: {
	                renderTo: 'grafico1',
	                type: 'column',
			            options3d: {
			                enabled: true,
			                alpha: 15,
			                beta: 15,
			                depth: 50,
			                viewDistance: 25
			            }
	            },
	            title: {
	                text: 'Prospetto fatturato in euro'
	            },
	            subtitle: {
	                text: 'dal <%=intAnnoIniziale%> al <%=intYear%>'
	            },
	            xAxis: {
	                categories: [
	                    'Gen',
	                    'Feb',
	                    'Mar',
	                    'Apr',
	                    'Mag',
	                    'Giu',
	                    'Lug',
	                    'Ago',
	                    'Set',
	                    'Ott',
	                    'Nov',
	                    'Dic'
	                ]
	            },
	            yAxis: {
	                min: 0,
	                title: {
	                    text: 'Fatturato (euro)'
	                },
	                plotLines: [{
	                    value: 0,
	                    width: 1,
	                    color: '#808080'
	                }]
	            },
	            legend: {
	                layout: 'vertical',
	                backgroundColor: '#FFFFFF',
	                align: 'left',
	                verticalAlign: 'top',
	                x: 100,
	                y: 70,
	                floating: true,
	                shadow: true
	            },
	            tooltip: {
	                formatter: function() {
	                    return ''+
	                        this.x +': '+ this.y +' euro';
	                }
	            },
	            plotOptions: {
									area: {
													lineColor: '#ffffff',
													lineWidth: 1,
													marker: {
														lineWidth: 1,
														lineColor: '#ffffff'
													}
												},
	                column: {
	                    pointPadding: 0.2,
	                    borderWidth: 0
	                }
	            },
	                series: [
								<%
							      for (int i = intAnnoFinale-2; i <= intAnnoFinale; i++){
							          Response.Write("\n{\n");
							          Response.Write("name: '" + GetAnno(i) + "',\n");
							          Response.Write("data: [");
							      		for (int j = 1; j <= 12; j++){
							            	Response.Write(GetValoreGrafico(fatturato1[j,i]));
							            	if (j!=12){
								            	Response.Write(",");
														}
												}
							          Response.Write("]\n");
							          if (i!=intAnnoFinale){
								          Response.Write("},\n");
												}else{
							          	Response.Write("}\n");
												}
							      }
							    %>
									]
	        });
					//grafico2
	        chart = new Highcharts.Chart({
	            chart: {
	                renderTo: 'grafico2',
	                type: 'areaspline',
			            options3d: {
			                enabled: true,
			                alpha: 15,
			                beta: 15,
			                depth: 50,
			                viewDistance: 25
			            }
	            },
	            title: {
	                text: 'Prospetto fatturato in euro'
	            },
	            subtitle: {
	                text: 'Ultimi 3 anni'
	            },
	            xAxis: {
	                categories: [
	                    'Gen',
	                    'Feb',
	                    'Mar',
	                    'Apr',
	                    'Mag',
	                    'Giu',
	                    'Lug',
	                    'Ago',
	                    'Set',
	                    'Ott',
	                    'Nov',
	                    'Dic'
	                ]
	            },
	            yAxis: {
	                min: 0,
	                title: {
	                    text: 'Fatturato (euro)'
	                },
	                plotLines: [{
	                    value: 0,
	                    width: 1,
	                    color: '#808080'
	                }]
	            },
	            legend: {
	                layout: 'vertical',
	                backgroundColor: '#FFFFFF',
	                align: 'left',
	                verticalAlign: 'top',
	                x: 100,
	                y: 70,
	                floating: true,
	                shadow: true
	            },
	            tooltip: {
	                formatter: function() {
	                    return ''+
	                        this.x +': '+ this.y +' euro';
	                }
	            },
	            plotOptions: {
									area: {
													lineColor: '#ffffff',
													lineWidth: 1,
													marker: {
														lineWidth: 1,
														lineColor: '#ffffff'
													}
												},
	                column: {
	                    pointPadding: 0.2,
	                    borderWidth: 0
	                }
	            },
	                series: [
									<%
							      for (int i = intAnnoFinale-2; i <= intAnnoFinale; i++){
							          Response.Write("\n{\n");
							          Response.Write("name: '" + GetAnno(i) + "',\n");
							          Response.Write("data: [");
							      		for (int j = 1; j <= 12; j++){
							            	Response.Write(GetValoreGrafico(fatturato1[j,i]));
							            	if (j!=12){
								            	Response.Write(",");
														}
												}
							          Response.Write("]\n");
							          if (i!=intAnnoFinale){
								          Response.Write("},\n");
												}else{
							          	Response.Write("}\n");
												}
							      }
							    %>
									]
	        });
					//grafico3
	        chart = new Highcharts.Chart({
	            chart: {
	                type: 'pie',
			            options3d: {
			                enabled: true,
			                alpha: 45,
			                beta: 0
			            },
									renderTo: 'grafico3',
									plotBackgroundColor: null,
			            plotBorderWidth: null,
			            plotShadow: false
	            },
	            title: {
	                text: 'Prospetto fatturato in euro'
	            },
	            subtitle: {
	                text: 'Ultimo anno'
	            },
							plotOptions: {
				            pie: {
				                allowPointSelect: true,
				                cursor: 'pointer',
				                depth: 35,
				                dataLabels: {
				                    enabled: true,
				                    format: '<strong>{point.name}</strong>: {point.percentage:.1f} %'
				                }
				            }
				      },
	            xAxis: {
	                categories: [
	                    'Gen',
	                    'Feb',
	                    'Mar',
	                    'Apr',
	                    'Mag',
	                    'Giu',
	                    'Lug',
	                    'Ago',
	                    'Set',
	                    'Ott',
	                    'Nov',
	                    'Dic'
	                ]
	            },
	            yAxis: {
	                min: 0,
	                title: {
	                    text: 'Fatturato (euro)'
	                },
	                plotLines: [{
	                    value: 0,
	                    width: 1,
	                    color: '#808080'
	                }]
	            },
	            legend: {
	                layout: 'vertical',
	                backgroundColor: '#FFFFFF',
	                align: 'left',
	                verticalAlign: 'top',
	                x: 100,
	                y: 70,
	                floating: true,
	                shadow: true
	            },
	            tooltip: {
	                pointFormat: '{series.name}: <strong>{point.percentage:.1f}%</strong>'
	            },
	            plotOptions: {
									area: {
													lineColor: '#ffffff',
													lineWidth: 1,
													marker: {
														lineWidth: 1,
														lineColor: '#ffffff'
													}
												},
	                column: {
	                    pointPadding: 0.2,
	                    borderWidth: 0
	                }
	            },
	                series: [
									<%
							      for (int i = intAnnoFinale; i <= intAnnoFinale; i++){
							          Response.Write("\n{\n");
							          Response.Write("name: '" + GetAnno(i) + "',\n");
							          Response.Write("type: 'pie',\n");
							          Response.Write("data: [");
							      		for (int j = 1; j <= 12; j++){
														Response.Write("['" + Smartdesk.Functions.GetMese(j.ToString()) + " " + GetAnno(i) + "'," + GetValoreGrafico(fatturato1[j,i]) + "]");
							            	if (j!=12){
								            	Response.Write(",");
														}
												}
							          Response.Write("]\n");
							          if (i!=intAnnoFinale){
								          Response.Write("},\n");
												}else{
							          	Response.Write("}\n");
												}
							      }
							    %>
									]
	        });


	    });



		});
	</script>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-5 small-12 cell align-middle">
              <h1><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i><%=strH1%></h1>
          </div>
          <div class="large-8 medium-7 small-12 cell float-right align-middle">
          		<div class="button-group small hide-for-print align-right">
                <% for (int i = intYear-5; i <= intYear; i++){ %>
		            <a href="prospetto-fatturato.aspx?annoiniziale=<%=i%>" class="tiny button clear"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=i%></a>
                <% } %>
             	</div>
        </div>
  	</div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
	<p>Il prospetto rappresenta il fatturato mese per mese degli ultimi anni selezionati. Puoi selezionare l'anno di partenza dall'apposito filtro.</p>
			<div class="divgrid">
			<table id="grid2" class="grid stack" style="table-layout:auto;">
				<thead>
	        <tr>
		        <td></td>
		        <%
		          for (int i = intAnnoIniziale; i <= intYear; i++){
		            Response.Write("<th scope=\"col\" align=\"right\" width=\"70\">" + i + "</th>");
		            if (i>intAnnoIniziale){
		              Response.Write("<th scope=\"col\" align=\"right\" width=\"70\">diff. &euro;</th>");
		            }
		            intNumeroAnni=intNumeroAnni+1;
		          }
		        %>
	        </tr>
		   </thead>
		   <tbody>
	      <%for (int i = 1; i <= 12; i++){ %>
	          <tr>
	            <th class="text-right"><%=Smartdesk.Functions.GetMese(i.ToString())%></th>
	      			<%for (int j = 0; j < intNumeroAnni; j++){ %>
		            <td class="large-text-right small-text-left"><%=GetValore(fatturato2[i,j])%></td>
		            <%
		              if (j>0){ %>
		              	<td class="large-text-right small-text-left">
										<%
										if (fatturato2[i,j-1]!="0,00"){
			                decTemp=Convert.ToDecimal(fatturato2[i,j])-Convert.ToDecimal(fatturato2[i,j-1]);
			                Response.Write(GetDifferenza(decTemp.ToString("N2", ciit)));
			              } %>
			              </td>
		              <% }
		            %>
		            
							<% } %>
	          </tr>
	      <% } %>
	        <tr class="totale">
	          <th class="text-right">Totale consolidato</th>
	    			<%for (int j = 0; j < intNumeroAnni; j++){ %>
	            <td class="large-text-right small-text-left"><%=GetValore(fatturato2[13,j])%></td>
	            <%
	              if (j>0){ %>
	    		        <td class="large-text-right small-text-left">
									<% if (fatturato2[13,j-1]!="0,00"){
		                decTemp=Convert.ToDecimal(fatturato2[13,j])-Convert.ToDecimal(fatturato2[13,j-1]);
		                Response.Write(GetDifferenza(decTemp.ToString("N2", ciit)));
		              } %>
			            </td>
	              <% }
	            %>
						<% } %>
	        </tr>
	        <tr class="totale">
	          <th class="text-right">Media mensile consolidata</th>
	    			<%for (int j = 0; j < intNumeroAnni; j++){
						  if (fatturato3[14,j]>0){
								strTemp=(fatturato3[13,j]/fatturato3[14,j]).ToString("N2", ciit);
							}else{
								strTemp="0";
							}
							%>
	            <td class="large-text-right small-text-left"><%=strTemp%></td>
	            <%
	              if (j>0){ %>
	    		        <td class="large-text-right small-text-left">
									<% if (fatturato2[13,j-1]!="0,00"){
		                decTemp=Convert.ToDecimal(fatturato2[13,j])-Convert.ToDecimal(fatturato2[13,j-1]);
		                //Response.Write(GetDifferenza((decTemp/fatturato3[14,j]).ToString("N2", ciit)));
		              } %>
			            </td>
	              <% }
	            %>
						<% } %>
	        </tr>
		   </tbody>
	    </table>
			</div>
			<div class="grid-x grid-padding-x">
			  <div class="small-12 medium-6 large-6 cell">
	    		<div id="grafico1" style="min-width:50%;height:250px;margin: 0 auto;"></div>    
	    	</div>
			  <div class="small-12 medium-6 large-6 cell">
	   			<div id="grafico2" style="min-width:50%;height:250px;margin: 0 auto;"></div>    
	    	</div>
	    </div>
			<div class="grid-x grid-padding-x">
			  <div class="small-12 medium-6 large-6 cell">
			    <div id="grafico3" style="min-width:100%;height:250px;margin: 0 auto;"></div> 
				</div>
			</div>   
  </div>
 </div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
