<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/commerciale/prospetto-lead-lead-orario.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Commerciale > Prospetto lead per marca veicoli</title>
	<!--#include file="/admin/inc-head.aspx"-->
	<script src="https://cdnjs.cloudflare.com/ajax/libs/highcharts/10.1.0/highcharts.min.js" integrity="sha512-SogfwUFpH9rofYV9j8NNbDSOuFOBvaVR86iNy3RblVGzRBMPWLA8es+P3JrfvRLNgCZLFK3SmnTddImp3UK0pQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/highcharts/10.1.0/highcharts-3d.min.js" integrity="sha512-uqz7yyIqQbcbaO6gmrXtJ+HMbXFX7YlsVG+S7Mqoq9bjSWhWhRGCCRiYgloJvntEf1r0bsRivm6BUaCWgv3TIA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/highcharts/10.1.0/modules/exporting.min.js" integrity="sha512-a65yKVWaMTqOJbXD+fkCsv8ENApqxchdbBW8+PpUbPPSgTVSwJFKG3TnKfqz4p3GRHiY0fnRyjLoFMN0jyM6Sw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
  <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/js-cookie@3.0.1/dist/js.cookie.min.js" integrity="sha256-0H3Nuz3aug3afVbUlsu12Puxva3CP4EhJtPExqs54Vg=" crossorigin="anonymous"></script>
  <script type="text/javascript" src="https://cdn.jsdelivr.net/momentjs/latest/moment.min.js"></script>
  <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js"></script>
  <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css" />
	<script>
		jQuery(function() {
	    var chart;
	    jQuery(document).ready(function() {
	        
					//grafico1 giorni
					chart = new Highcharts.Chart({
	            chart: {
	                renderTo: 'grafico1',
	                type: 'column'
	            },
	            title: {
	                text: 'Prospetto orario lead per categoria <%=Smartdesk.Functions.GetMese(strMese)%> <%=strAnno%>' 
	            },
	            xAxis: {
                  min: 0,
                  max: 23,
	                categories: [
                  <% for (int j = 0; j < 24; j++){       
                      Response.Write("'" + j + "',");
                    } %>
	                ]
              },
	            yAxis: {
	                type: 'linear',
                  gridLineWidth: 1,
                  min: 0,
	                title: {
	                    text: 'Numero lead'
	                },
                  tickInterval: 1,                 
	                plotLines: [{
	                    value: 0,
	                    width: 1,
	                    color: '#808080'
	                }]
	            },
	            legend: {
	                layout: 'horizontal',
	                backgroundColor: '#FFFFFF',
	                align: 'left',
	                verticalAlign: 'top',
	                x: 50,
	                y: 20,
	                floating: true,
	                shadow: true
	            },
	            tooltip: {
	                formatter: function() {
	                    return ' giorno:' + this.x +'- lead:'+ this.y;
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
                      dataLabels: {
                          enabled: true
                      },
	                    pointPadding: 0.2,
	                    borderWidth: 0
	                },
                  line: {
                      dataLabels: {
                          enabled: true
                      }
                  },
                  bar: {
                      dataLabels: {
                          enabled: true
                      }
                  }


	            },
	                series: [
									<% for (int i = 0; i < dtLeadCategorie.Rows.Count; i++){ %>
                        {
                          name: '<%=dtLeadCategorie.Rows[i]["LeadCategorie_Titolo"].ToString()%>',
                          data: [
                          <% for (int j = 0; j <= 23; j++){
                              strWHERENet="LeadCategorie_Ky=" + dtLeadCategorie.Rows[i]["LeadCategorie_Ky"].ToString() + " AND YEAR(Lead_Data)=" + strAnno + " AND MONTH(Lead_Data)=" + strMese + " AND DATEPART(hour,Lead_Data)=" + j;
                  	          strFROMNet = "Lead";
                              strORDERNet = "Lead_Ky DESC";
                              dtConteggioLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
                              Response.Write(intNumRecords + ",");
                            } %>
                          ]
                        },
							    <% } %>
                  
                  
									]
	        });
					//grafico2 andamento annuale
					chart = new Highcharts.Chart({
	            chart: {
	                renderTo: 'grafico2',
	                type: 'area',
			            options3d: {
			                enabled: false,
			                alpha: 15,
			                beta: 15,
			                depth: 50,
			                viewDistance: 25
			            }
	            },
	            title: {
	                text: 'Orario lead <%=strAnno%>'
	            },
	            xAxis: {
                  min: 0,
                  max: 23,
	                categories: [
                  <% for (int j = 0; j < 24; j++){       
                      Response.Write("'" + j + "',");
                    } %>
	                ]
	            },
	            yAxis: {
	                type: 'linear',
                  gridLineWidth: 1,
                  min: 0,
	                title: {
	                    text: 'Numero lead'
	                },
                  tickInterval: 1,                 
	                plotLines: [{
	                    value: 0,
	                    width: 1,
	                    color: '#808080'
	                }]
	            },
	            legend: {
	                layout: 'horizontal',
	                backgroundColor: '#FFFFFF',
	                align: 'left',
	                verticalAlign: 'top',
	                x: 50,
	                y: 20,
	                floating: true,
	                shadow: true
	            },
	            tooltip: {
	                formatter: function() {
	                    return ' ora:' + this.x +'- lead:'+ this.y;
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
                      dataLabels: {
                          enabled: true
                      },
	                    pointPadding: 0.2,
	                    borderWidth: 0
	                },
                  line: {
                      dataLabels: {
                          enabled: true
                      }
                  },
                  bar: {
                      dataLabels: {
                          enabled: true
                      }
                  }


	            },
	                series: [
                        {
                          name: 'Orario lead <%=strAnno%>',
                          data: [
                          <% for (int j = 0; j < 24; j++){
                              strWHERENet="YEAR(Lead_Data)=" + strAnno + " AND DATEPART(hour,Lead_Data)=" + j;
                  	          strFROMNet = "Lead";
                              strORDERNet = "Lead_Ky DESC";
                              dtConteggioLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
                              Response.Write(intNumRecords + ",");
                          
                            } %>
                          ]
                        },
                  
                  
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
		<div class="grid-x grid-padding-x">
			<div class="large-7 medium-6 small-12 cell">
          <h1><i class="fa-duotone fa-bullhorn fa-fw"></i><%=strH1%></h1>
      </div>
			<div class="large-5 medium-6 small-12 cell float-right">
        <!--#include file=/admin/app/commerciale/inc-reportdatarange.aspx --> 
			</div>
		</div>
	</div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
		
    <div class="divgridfilter">
    	<% for (int i = intYear-1; i <= intYear; i++){ %>
    		<div class="stacked-for-small button-group tiny hide-for-print">
    		<% for (int j = 1; j <= 12; j++){ %>		
    			<a href="/admin/app/commerciale/prospetto-lead-lead-orario.aspx?anno=<%=i%>&mese=<%=j%>" class="tiny button secondary"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=Smartdesk.Functions.GetMese(j.ToString())%>/<%=i%></a>
    		<% } %>
    		</div>
    	<% } %>
    </div>
		<div class="divgrid">
  		<div class="grid-x grid-padding-x">
  		  <div class="small-12 medium-12 large-12 cell">
          <h2>Grafico andamento del mese <%=Smartdesk.Functions.GetMese(strMese)%> <%=strAnno%></h2>
      		<div id="grafico1" style="min-width:100%;height:250px;margin: 0 auto;"></div>    
      	</div>
      </div>
    </div>

		<div class="divgrid">
  		<div class="grid-x grid-padding-x">
  		  <div class="small-12 medium-12 large-12 cell">
          <h2>Grafico orario lead andamento annuale <%=strAnno%></h2>
      		<div id="grafico2" style="min-width:100%;height:250px;margin: 0 auto;"></div>    
      	</div>
      </div>
    </div>

  </div>
 </div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
