<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/commerciale/prospetto-lead-leadcategorie.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Commerciale > Prospetto lead per marca veicoli</title>
	<!--#include file="/admin/inc-head.aspx"-->
	<!--#include file="/admin/inc-head-highcharts.aspx"-->
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
	                text: 'Prospetto lead per categoria' 
	            },
	            xAxis: {
                  min: 0,
                  max: <%=intGiorni%>,
	                categories: [
                  <% for (int j = 1; j <= intGiorni; j++){       
                      Response.Write("'" + j + " " + new DateTime(Convert.ToInt32(strAnno), Convert.ToInt32(strMese), j).ToString("ddd") + "',");
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
                          <% for (int j = 1; j <= intGiorni; j++){
                              strWHERENet="LeadCategorie_Ky=" + dtLeadCategorie.Rows[i]["LeadCategorie_Ky"].ToString() + " AND (Lead.Lead_Data >= CONVERT(DATETIME, '" + strReportdatarangestart + "', 102)) AND (Lead.Lead_Data <= CONVERT(DATETIME, '" + strReportdatarangeend + "', 102)) AND DAY(Lead_Data)=" + j;
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
	                type: 'column',
			            options3d: {
			                enabled: false,
			                alpha: 15,
			                beta: 15,
			                depth: 50,
			                viewDistance: 25
			            }
	            },
	            title: {
	                text: 'Prospetto lead per categoria <%=strAnno%>'
	            },
	            xAxis: {
                  min: 0,
                  max: 12,
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
	                    return ' mese:' + this.x +'- lead:'+ this.y;
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
                          <% for (int j = 1; j < 13; j++){
                              strWHERENet="LeadCategorie_Ky=" + dtLeadCategorie.Rows[i]["LeadCategorie_Ky"].ToString() + " AND YEAR(Lead_Data)=" + strAnno + " AND MONTH(Lead_Data)=" + j;
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
		<div class="divgrid">
		<h2>Prospetto lead per Categoria</h2>
		<table id="grid1" class="grid">
		<thead>
        <tr>
	        <th class="text-left">Categoria</th>
	        <th class="large-text-right small-text-left">Numero Lead</th>
	        <th></th>
        </tr>
		</thead>
	   <tbody>
		  <% for (int i = 0; i < dtProspettoLead.Rows.Count; i++){ %>
	     <tr>
				<td><a href="/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&LeadCategorie_Ky=<%=dtProspettoLead.Rows[i]["LeadCategorie_Ky"].ToString()%>"><%=dtProspettoLead.Rows[i]["LeadCategorie_Titolo"].ToString()%></a></td>
				<td class="large-text-right small-text-left"><strong></strong><%=dtProspettoLead.Rows[i]["Conteggio"].ToString()%></strong></td>
				<td><a href="/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&LeadCategorie_Ky=<%=dtProspettoLead.Rows[i]["LeadCategorie_Ky"].ToString()%>&Year(Lead_Data)=<%=strAnno%>&Month(Lead_Data)=<%=strMese%>">Vedi lead<i class="fa-duotone fa-angle-right fa-fw"></i></a></td>
      </tr>
			<% 
				intTotLead=intTotLead+((int)dtProspettoLead.Rows[i]["conteggio"]);
			} %>
		 </tbody>
		 <tfoot>
        <tr>
	        <td class="text-right">Totale Lead:</td>
	        <td class="large-text-right small-text-left"><%=intTotLead.ToString("N0", ciit)%></td>
	        <td class="text-right"></td>
        </tr>
		 </tfoot>
		</table>
    </div>
    
		<div class="grid-x grid-padding-x">
		  <div class="small-12 medium-12 large-12 cell">
    		<div class="divgrid">
      		<div id="grafico1" style="min-width:100%;height:250px;margin: 0 auto;"></div> 
        </div>   
    	</div>
    </div>

		<div class="grid-x grid-padding-x">
		  <div class="small-12 medium-12 large-12 cell">
    		<div class="divgrid">
      		<div id="grafico2" style="min-width:100%;height:250px;margin: 0 auto;"></div>    
    	  </div>
      </div>
    </div>
    
  </div>
 </div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
