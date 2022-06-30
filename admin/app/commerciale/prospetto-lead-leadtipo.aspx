<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/commerciale/prospetto-lead-leadtipo.aspx.cs" Inherits="_Default" Debug="true"%>
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
	                text: 'Prospetto lead per tipo <%=Smartdesk.Functions.GetMese(strMese)%> <%=strAnno%>' 
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
									<% for (int i = 0; i < dtLeadTipo.Rows.Count; i++){ %>
                        {
                          name: '<%=dtLeadTipo.Rows[i]["LeadTipo_Titolo"].ToString()%>',
                          data: [
                          <% for (int j = 1; j <= intGiorni; j++){
                              strWHERENet="LeadTipo_Ky=" + dtLeadTipo.Rows[i]["LeadTipo_Ky"].ToString() + " AND YEAR(Lead_Data)=" + strAnno + " AND MONTH(Lead_Data)=" + strMese + " AND DAY(Lead_Data)=" + j;
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
	                text: 'Prospetto lead per tipo <%=strAnno%>'
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
									<% for (int i = 0; i < dtLeadTipo.Rows.Count; i++){ %>
                        {
                          name: '<%=dtLeadTipo.Rows[i]["LeadTipo_Titolo"].ToString()%>',
                          data: [
                          <% for (int j = 1; j < 13; j++){
                              strWHERENet="LeadTipo_Ky=" + dtLeadTipo.Rows[i]["LeadTipo_Ky"].ToString() + " AND YEAR(Lead_Data)=" + strAnno + " AND MONTH(Lead_Data)=" + j;
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
		
    <div class="divgridfilter">
    	<% for (int i = intYear-1; i <= intYear; i++){ %>
    		<div class="stacked-for-small button-group tiny hide-for-print">
    		<% for (int j = 1; j <= 12; j++){ %>		
    			<a href="/admin/app/commerciale/prospetto-lead-leadtipo.aspx?anno=<%=i%>&mese=<%=j%>" class="tiny button secondary"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=Smartdesk.Functions.GetMese(j.ToString())%>/<%=i%></a>
    		<% } %>
    		</div>
    	<% } %>
    </div>
		<div class="divgrid">
		<h2>Prospetto lead per Categoria <%=Smartdesk.Functions.GetMese(strMese)%> <%=strAnno%></h2>
		<table id="grid1" class="grid">
		<thead>
        <tr>
	        <th class="text-left">Categoria</th>
	        <th class="text-left">Periodo</th>
	        <th class="large-text-right small-text-left">Numero Lead</th>
	        <th></th>
        </tr>
		</thead>
	   <tbody>
		  <% for (int i = 0; i < dtProspettoLead.Rows.Count; i++){ %>
	     <tr>
				<td><a href="/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&LeadTipo_Ky=<%=dtProspettoLead.Rows[i]["LeadTipo_Ky"].ToString()%>"><%=dtProspettoLead.Rows[i]["LeadTipo_Titolo"].ToString()%></a></td>
				<td><%=Smartdesk.Functions.GetMese(dtProspettoLead.Rows[i]["Mese"].ToString())%> / <%=dtProspettoLead.Rows[i]["Anno"].ToString()%></td>
				<td class="large-text-right small-text-left"><strong></strong><%=dtProspettoLead.Rows[i]["Conteggio"].ToString()%></strong></td>
				<td><a href="/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&LeadTipo_Ky=<%=dtProspettoLead.Rows[i]["LeadTipo_Ky"].ToString()%>&Year(Lead_Data)=<%=strAnno%>&Month(Lead_Data)=<%=strMese%>">Vedi lead<i class="fa-duotone fa-angle-right fa-fw"></i></a></td>
      </tr>
			<% 
				intTotLead=intTotLead+((int)dtProspettoLead.Rows[i]["conteggio"]);
			} %>
		 </tbody>
		 <tfoot>
        <tr>
	        <td colspan="3"></td>
	        <td class="large-text-right small-text-left">Totale Lead: <%=intTotLead.ToString("N0", ciit)%></td>
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
