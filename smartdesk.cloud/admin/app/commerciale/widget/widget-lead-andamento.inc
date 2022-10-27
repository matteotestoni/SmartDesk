 <%
	System.Data.DataTable dtLead;
	System.Data.DataTable dtLeadxCategorie;
	System.Data.DataTable dtLeadxSorgenti;
	System.Data.DataTable dtLeadxTipo;
	System.Data.DataTable dtLeadxSource;
	System.Data.DataTable dtLeadxMedium;
	System.Data.DataTable dtLeadxCampaign;
  string strSQLLead;
  System.Data.SqlClient.SqlConnection connLead;
  System.Data.SqlClient.SqlCommand cmdLead;
  string strWHERENet="";
	string strFROMNet = "";
	string strORDERNet = "";

  connLead = new System.Data.SqlClient.SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
  connLead.Open();
  
  switch (Convert.ToInt32(dtLogin.Rows[0]["UtentiGruppi_CommercialeQuali"].ToString())){
    case 1:
      //Lead
      strSQLLead = "SELECT COUNT(Lead_Ky) AS NumeroLead, CONVERT(DATE, Lead_Data) AS Lead_Data, MAX(Lead_Ky) AS Lead_Ky FROM Lead";
      strSQLLead+= " WHERE Lead_Data>=GETDATE()-90";
      strSQLLead+= " GROUP BY CONVERT(DATE, Lead_Data)";
      strSQLLead+= " ORDER BY CONVERT(DATE, Lead_Data)";
      break;
    case 2:
      //Lead
      strSQLLead = "SELECT COUNT(Lead_Ky) AS NumeroLead, CONVERT(DATE, Lead_Data) AS Lead_Data, MAX(Lead_Ky) AS Lead_Ky FROM Lead INNER JOIN Utenti ON Lead.Utenti_Ky = Utenti.Utenti_Ky";
      strSQLLead+= " WHERE (Lead_Data>=GETDATE()-90) AND (Utenti.UtentiGruppi_Ky = " + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString() + ")";
      strSQLLead+= " GROUP BY CONVERT(DATE, Lead_Data)";
      strSQLLead+= " ORDER BY CONVERT(DATE, Lead_Data)";
      break;
    case 3:
      //Lead
      strSQLLead = "SELECT COUNT(Lead_Ky) AS NumeroLead, CONVERT(DATE, Lead_Data) AS Lead_Data, MAX(Lead_Ky) AS Lead_Ky FROM Lead";
      strSQLLead+= " WHERE Lead_Data>=GETDATE()-90 AND Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString();
      strSQLLead+= " GROUP BY CONVERT(DATE, Lead_Data)";
      strSQLLead+= " ORDER BY CONVERT(DATE, Lead_Data)";
      break;
    default:
      //Lead
      strSQLLead = "SELECT COUNT(Lead_Ky) AS NumeroLead, CONVERT(DATE, Lead_Data) AS Lead_Data, MAX(Lead_Ky) AS Lead_Ky FROM Lead";
      strSQLLead+= " WHERE Lead_Data>=GETDATE()-90";
      strSQLLead+= " GROUP BY CONVERT(DATE, Lead_Data)";
      strSQLLead+= " ORDER BY CONVERT(DATE, Lead_Data)";
      break;
  }
  cmdLead = new System.Data.SqlClient.SqlCommand(strSQLLead, connLead);
  dtLead = new System.Data.DataTable("AndamentoLead");
  dtLead.Load(cmdLead.ExecuteReader());
  
  strWHERENet="Anno=" + DateTime.Now.Year + " AND mese=" + DateTime.Now.Month;
  strFROMNet = "Lead_Prospetto_LeadCategorie_Vw";
  strORDERNet = "Anno, Mese";
  dtLeadxCategorie = new System.Data.DataTable("Lead_Prospetto_LeadCategorie_Vw");
  dtLeadxCategorie = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
  
  strWHERENet="Anno=" + DateTime.Now.Year + " AND mese=" + DateTime.Now.Month;
  strFROMNet = "Lead_Prospetto_LeadTipo_Vw";
  strORDERNet = "Anno, Mese";
  dtLeadxTipo = new System.Data.DataTable("Lead_Prospetto_LeadTipo_Vw");
  dtLeadxTipo = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
  
  strWHERENet="Anno=" + DateTime.Now.Year + " AND mese=" + DateTime.Now.Month;
  strFROMNet = "Lead_Prospetto_LeadSorgenti_Vw";
  strORDERNet = "Anno, Mese";
  dtLeadxSorgenti = new System.Data.DataTable("Lead_Prospetto_LeadSorgenti_Vw");
  dtLeadxSorgenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         

  strWHERENet="Anno=" + DateTime.Now.Year + " AND mese=" + DateTime.Now.Month;
  strFROMNet = "Lead_Prospetto_utm_medium_Vw";
  strORDERNet = "Anno, utm_medium";
  dtLeadxMedium = new System.Data.DataTable("Lead_Prospetto_utm_medium_Vw");
  dtLeadxMedium = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         

  strWHERENet="Anno=" + DateTime.Now.Year + " AND mese=" + DateTime.Now.Month;
  strFROMNet = "Lead_Prospetto_utm_campaign_Vw";
  strORDERNet = "Anno, utm_campaign";
  dtLeadxCampaign = new System.Data.DataTable("Lead_Prospetto_utm_campaign_Vw");
  dtLeadxCampaign = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         

  strWHERENet="Anno=" + DateTime.Now.Year + " AND mese=" + DateTime.Now.Month;
  strFROMNet = "Lead_Prospetto_Utm_source_Vw";
  strORDERNet = "Anno, utm_source";
  dtLeadxSource = new System.Data.DataTable("Lead_Prospetto_Utm_source_Vw");
  dtLeadxSource = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
%>

  	<div class="divgridcard">
	   	<div id="graficoandamento1" style="width:100%;height:250px;margin: 0 auto;"></div>    
      <div class="text-center"><a href="/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175" class="button small warning">Vai al dettaglio <i class="fa-duotone fa-angle-right fa-fw"></i></a></div>  
      <hr>
  
        <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
	   	       <div id="graficoleadsorgenti" style="width:100%;height:500px;margin: 0 auto;"></div>
             <hr>
          </div>  
          <div class="large-4 medium-4 small-12 cell align-middle">
	   	       <div id="graficoleadcategorie" style="width:100%;height:500px;margin: 0 auto;"></div>  
             <hr>
          </div>  
          <div class="large-4 medium-4 small-12 cell align-middle">
	   	       <div id="graficoleadtipo" style="width:100%;height:500px;margin: 0 auto;"></div>  
             <hr>
          </div>  
        </div> 
                
        <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
	   	       <div id="graficoleadutmsource" style="width:100%;height:500px;margin: 0 auto;"></div>    
             <hr>
             <div class="text-center"><a href="/admin/app/commerciale/prospetto-lead-utm_source.aspx" class="button small warning">Vai al dettaglio <i class="fa-duotone fa-angle-right fa-fw"></i></a></div>  
          </div> 
          <div class="large-4 medium-4 small-12 cell align-middle">
	   	       <div id="graficoleadutmmedium" style="width:100%;height:500px;margin: 0 auto;"></div>    
             <hr>
             <div class="text-center"><a href="/admin/app/commerciale/prospetto-lead-utm_medium.aspx" class="button small warning">Vai al dettaglio <i class="fa-duotone fa-angle-right fa-fw"></i></a></div>  
          </div> 
          <div class="large-4 medium-4 small-12 cell align-middle">
	   	       <div id="graficoleadutmcampaign" style="width:100%;height:500px;margin: 0 auto;"></div>    
             <hr>
             <div class="text-center"><a href="/admin/app/commerciale/prospetto-lead-utm_campaign.aspx" class="button small warning">Vai al dettaglio <i class="fa-duotone fa-angle-right fa-fw"></i></a></div>  
          </div> 
        </div> 
	  </div>
	<script>
		jQuery(function() {
	    var chart;
	    jQuery(document).ready(function() {
	        
          //grafico 1
          chart = new Highcharts.Chart({
	            chart: {
	                renderTo: 'graficoandamento1',
	                type: 'areaspline',
	            },
	            title: {
	                text: 'Andamento Lead'
	            },
	            subtitle: {
	                text: 'Ultimi 90 giorni'
	            },
              xAxis: {
                  categories: [
                  <% for (int j = 0; j < dtLead.Rows.Count; j++){
  					            	Response.Write("'" + ((DateTime)dtLead.Rows[j]["Lead_Data"]).ToString("dd/M/yyyy") + "',");
  									 } %>
                  ]
              },
	            yAxis: {
	                min: 0,
	                title: {
	                    text: 'Numero Lead'
	                }
	            },
              plotOptions: {
                      line: {
                          dataLabels: {
                              enabled: true
                          },
                          enableMouseTracking: false
                      }
              },              
              series: [{
                name: '<%=DateTime.Now.Year%>',
                data: [<% for (int j = 0; j < dtLead.Rows.Count; j++){
					           Response.Write(dtLead.Rows[j]["NumeroLead"].ToString() + ",");
							   } %>]},

							]
	        });
                    
          //grafico categorie
          chart = new Highcharts.Chart({
              chart: {
	                renderTo: 'graficoleadcategorie',
                  plotBackgroundColor: null,
                  plotBorderWidth: null,
                  plotShadow: false,
                  type: 'pie'
              },
	            title: {
	                text: 'Lead per Categoria'
	            },
	            subtitle: {
	                text: 'Mese corrente: <%=DateTime.Now.Month%>'
	            },
	            yAxis: {
	                min: 0,
	                title: {
	                    text: 'Numero Lead'
	                }
	            },
              plotOptions: {
                     pie: {
                          allowPointSelect: true,
                          cursor: 'pointer',
                          dataLabels: {
                              enabled: true,
                              format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                          }
                      },
                      line: {
                          dataLabels: {
                              enabled: true
                          },
                          enableMouseTracking: false
                      }
              },              
              series: [{
                name: '<%=DateTime.Now.Year%>',
                colorByPoint: true,
                data: [<%
	                 for (int j = 0; j < dtLeadxCategorie.Rows.Count; j++){
					            	Response.Write("{name: '" + dtLeadxCategorie.Rows[j]["LeadCategorie_Titolo"].ToString() + "',y:" + dtLeadxCategorie.Rows[j]["Conteggio"].ToString() + "},");
										} %>]
                },]
	        });
          
          //grafico sorgenti
          chart = new Highcharts.Chart({
              chart: {
	                renderTo: 'graficoleadsorgenti',
                  plotBackgroundColor: null,
                  plotBorderWidth: null,
                  plotShadow: false,
                  type: 'pie'
              },
	            title: {
	                text: 'Lead per Sorgenti'
	            },
	            subtitle: {
	                text: 'Mese corrente: <%=DateTime.Now.Month%>'
	            },
	            yAxis: {
	                min: 0,
	                title: {
	                    text: 'Numero Lead'
	                }
	            },
              plotOptions: {
                     pie: {
                          allowPointSelect: true,
                          cursor: 'pointer',
                          dataLabels: {
                              enabled: true,
                              format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                          }
                      },
                      line: {
                          dataLabels: {
                              enabled: true
                          },
                          enableMouseTracking: false
                      }
              },              
              series: [{
                name: '<%=DateTime.Now.Year%>',
                colorByPoint: true,
                data: [<%
	                 for (int j = 0; j < dtLeadxSorgenti.Rows.Count; j++){
					            	Response.Write("{name: '" + dtLeadxSorgenti.Rows[j]["LeadSorgenti_Titolo"].ToString() + "',y:" + dtLeadxSorgenti.Rows[j]["Conteggio"].ToString() + "},");
										} %>]
                },]
	        });

          //grafico tipo
          chart = new Highcharts.Chart({
              chart: {
	                renderTo: 'graficoleadtipo',
                  plotBackgroundColor: null,
                  plotBorderWidth: null,
                  plotShadow: false,
                  type: 'pie'
              },
	            title: {
	                text: 'Lead per Tipo'
	            },
	            subtitle: {
	                text: 'Mese corrente: <%=DateTime.Now.Month%>'
	            },
	            yAxis: {
	                min: 0,
	                title: {
	                    text: 'Numero Lead'
	                }
	            },
              plotOptions: {
                     pie: {
                          allowPointSelect: true,
                          cursor: 'pointer',
                          dataLabels: {
                              enabled: true,
                              format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                          }
                      },
                      line: {
                          dataLabels: {
                              enabled: true
                          },
                          enableMouseTracking: false
                      }
              },              
              series: [{
                name: '<%=DateTime.Now.Year%>',
                colorByPoint: true,
                data: [<%
	                 for (int j = 0; j < dtLeadxTipo.Rows.Count; j++){
					            	Response.Write("{name: '" + dtLeadxTipo.Rows[j]["LeadTipo_Titolo"].ToString() + "',y:" + dtLeadxTipo.Rows[j]["Conteggio"].ToString() + "},");
										} %>]
                },]
	        });

          //grafico utm_source
          chart = new Highcharts.Chart({
              chart: {
	                renderTo: 'graficoleadutmsource',
                  plotBackgroundColor: null,
                  plotBorderWidth: null,
                  plotShadow: false,
                  type: 'pie'
              },
	            title: {
	                text: 'Lead per UTM Source'
	            },
	            subtitle: {
	                text: 'Mese corrente <%=DateTime.Now.Month%>'
	            },
	            yAxis: {
	                min: 0,
	                title: {
	                    text: 'Numero Lead'
	                }
	            },
              plotOptions: {
                     pie: {
                          allowPointSelect: true,
                          cursor: 'pointer',
                          dataLabels: {
                              enabled: true,
                              format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                          }
                      },
                      line: {
                          dataLabels: {
                              enabled: true
                          },
                          enableMouseTracking: false
                      }
              },              
              series: [{
                name: '<%=DateTime.Now.Month%>/<%=DateTime.Now.Year%>',
                colorByPoint: true,
                data: [<%
	                 for (int j = 0; j < dtLeadxSource.Rows.Count; j++){
					            	Response.Write("{name: '" + dtLeadxSource.Rows[j]["utm_source"].ToString() + "',y:" + dtLeadxSource.Rows[j]["Conteggio"].ToString() + "},");
										} %>]
                },]
	        });
      
           
          //grafico utm_medium
          chart = new Highcharts.Chart({
              chart: {
	                renderTo: 'graficoleadutmmedium',
                  plotBackgroundColor: null,
                  plotBorderWidth: null,
                  plotShadow: false,
                  type: 'pie'
              },
	            title: {
	                text: 'Lead per UTM Medium'
	            },
	            subtitle: {
	                text: 'Mese corrente: <%=DateTime.Now.Month%>'
	            },
	            yAxis: {
	                min: 0,
	                title: {
	                    text: 'Numero Lead'
	                }
	            },
              plotOptions: {
                     pie: {
                          allowPointSelect: true,
                          cursor: 'pointer',
                          dataLabels: {
                              enabled: true,
                              format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                          }
                      },
                      line: {
                          dataLabels: {
                              enabled: true
                          },
                          enableMouseTracking: false
                      }
              },              
              series: [{
                name: '<%=DateTime.Now.Month%>/<%=DateTime.Now.Year%> ',
                colorByPoint: true,
                data: [<%
	                 for (int j = 0; j < dtLeadxMedium.Rows.Count; j++){
					            	Response.Write("{name: '" + dtLeadxMedium.Rows[j]["utm_medium"].ToString() + "',y:" + dtLeadxMedium.Rows[j]["Conteggio"].ToString() + "},");
										} %>]
                },]
	        });
           
          //grafico utm_campaign
          chart = new Highcharts.Chart({
              chart: {
	                renderTo: 'graficoleadutmcampaign',
                  plotBackgroundColor: null,
                  plotBorderWidth: null,
                  plotShadow: false,
                  type: 'pie'
              },
	            title: {
	                text: 'Lead per UTM Campaign'
	            },
	            subtitle: {
	                text: 'Mese corrente: <%=DateTime.Now.Month%>'
	            },
	            yAxis: {
	                min: 0,
	                title: {
	                    text: 'Numero Lead'
	                }
	            },
              plotOptions: {
                     pie: {
                          allowPointSelect: true,
                          cursor: 'pointer',
                          dataLabels: {
                              enabled: true,
                              format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                          }
                      },
                      line: {
                          dataLabels: {
                              enabled: true
                          },
                          enableMouseTracking: false
                      }
              },              
              series: [{
                name: '<%=DateTime.Now.Month%>/<%=DateTime.Now.Year%> ',
                colorByPoint: true,
                data: [<%
	                 for (int j = 0; j < dtLeadxCampaign.Rows.Count; j++){
					            	Response.Write("{name: '" + dtLeadxCampaign.Rows[j]["utm_campaign"].ToString() + "',y:" + dtLeadxCampaign.Rows[j]["Conteggio"].ToString() + "},");
										} %>]
                },]
	        });
      
      
      
      });
		});
	</script>




		<div class="divgridcard hide">
		<table class="grid hover scroll" border="0" width="100%">
			<thead>
				<tr>
      	<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
				<th width="110" class="text-center date">Data</th>
				<th align="left" width="250">Numero Lead</th>
				</tr>
			</thead>
    		<tbody>
        <%
			  for (int j = 0; j < dtLead.Rows.Count; j++){
			  %>

		        <tr class="riga<%=i%2%>" id="<%=dtLead.Rows[j]["Lead_Ky"].ToString()%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtLead.Rows[j]["Lead_Ky"].ToString()%>" data-value="<%=dtLead.Rows[j]["Lead_Ky"].ToString()%>" /></td>
		          <td><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtLead.Rows[j]["Lead_Data"].ToString()%></td>
		          <td class="text-left"><%=dtLead.Rows[i]["NumeroLead"].ToString()%></td>
		        </tr>
		    <%
				}
				%>
    </table>

	</div>
