 <%
	System.Data.DataTable dtPreventiviAuto;
	System.Data.DataTable dtPreventiviAutoStati;
  System.Data.SqlClient.SqlConnection connPreventiviAuto;
  System.Data.SqlClient.SqlCommand cmdPreventiviAuto;
  string strSQLPreventiviAuto;
  string strSQLPreventiviAutoStati;
  string strWherePreventiviAuto;

    connPreventiviAuto = new System.Data.SqlClient.SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
    connPreventiviAuto.Open();
    switch (Convert.ToInt32(dtLogin.Rows[0]["UtentiGruppi_CommercialeQuali"].ToString())){
      case 1:
        //PreventiviAuto
        strSQLPreventiviAuto = "SELECT COUNT(PreventiviAuto_Ky) AS NumeroPreventivi, CONVERT(DATE, PreventiviAuto_Data) AS PreventiviAuto_Data, MAX(PreventiviAuto_Ky) AS PreventiviAuto_Ky FROM PreventiviAuto";
        strSQLPreventiviAuto+= " WHERE PreventiviAuto_Data>=GETDATE()-90";
        strSQLPreventiviAuto+= " GROUP BY CONVERT(DATE, PreventiviAuto_Data)";
        //PreventiviAutoStati
        strSQLPreventiviAutoStati = "SELECT COUNT(PreventiviAuto.PreventiviAuto_Ky) AS NumeroPreventivi, MAX(PreventiviAuto.PreventiviAuto_Ky) AS PreventiviAuto_Ky, PreventiviAutoStati.PreventiviAutoStati_Titolo, PreventiviAuto.PreventiviAutoStati_Ky";
        strSQLPreventiviAutoStati+= " FROM PreventiviAuto INNER JOIN PreventiviAutoStati ON PreventiviAuto.PreventiviAutoStati_Ky = PreventiviAutoStati.PreventiviAutoStati_Ky";
        strSQLPreventiviAutoStati+= " WHERE PreventiviAuto_Data>=GETDATE()-90";
        strSQLPreventiviAutoStati+= " GROUP BY dbo.PreventiviAutoStati.PreventiviAutoStati_Titolo, dbo.PreventiviAuto.PreventiviAutoStati_Ky";
        break;
      case 2:
        //PreventiviAuto
        strSQLPreventiviAuto = "SELECT COUNT(PreventiviAuto.PreventiviAuto_Ky) AS NumeroPreventivi, TRY_CONVERT(DATE, PreventiviAuto.PreventiviAuto_Data) AS PreventiviAuto_Data, MAX(PreventiviAuto.PreventiviAuto_Ky) AS PreventiviAuto_Ky";
        strSQLPreventiviAuto+= " FROM PreventiviAuto INNER JOIN Utenti ON PreventiviAuto.Utenti_Ky = Utenti.Utenti_Ky";
        strSQLPreventiviAuto+= " WHERE (Utenti.UtentiGruppi_Ky = " + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString() + ")";
        strSQLPreventiviAuto+= " GROUP BY TRY_CONVERT(DATE, PreventiviAuto.PreventiviAuto_Data)";
        //PreventiviAutoStati
        strSQLPreventiviAutoStati = "SELECT COUNT(PreventiviAuto.PreventiviAuto_Ky) AS NumeroPreventivi, MAX(PreventiviAuto.PreventiviAuto_Ky) AS PreventiviAuto_Ky, PreventiviAutoStati.PreventiviAutoStati_Titolo, PreventiviAuto.PreventiviAutoStati_Ky";
        strSQLPreventiviAutoStati+= " FROM PreventiviAuto INNER JOIN PreventiviAutoStati ON PreventiviAuto.PreventiviAutoStati_Ky = PreventiviAutoStati.PreventiviAutoStati_Ky";
        strSQLPreventiviAutoStati+= " WHERE PreventiviAuto_Data>=GETDATE()-90";
        strSQLPreventiviAutoStati+= " GROUP BY dbo.PreventiviAutoStati.PreventiviAutoStati_Titolo, dbo.PreventiviAuto.PreventiviAutoStati_Ky";
        break;
      case 3:
        //PreventiviAuto
        strSQLPreventiviAuto = "SELECT COUNT(PreventiviAuto_Ky) AS NumeroPreventivi, CONVERT(DATE, PreventiviAuto_Data) AS PreventiviAuto_Data, MAX(PreventiviAuto_Ky) AS PreventiviAuto_Ky FROM PreventiviAuto";
        strSQLPreventiviAuto+= " WHERE PreventiviAuto_Data>=GETDATE()-90 AND Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString();
        strSQLPreventiviAuto+= " GROUP BY CONVERT(DATE, PreventiviAuto_Data)";
        //PreventiviAutoStati
        strSQLPreventiviAutoStati = "SELECT COUNT(PreventiviAuto.PreventiviAuto_Ky) AS NumeroPreventivi, MAX(PreventiviAuto.PreventiviAuto_Ky) AS PreventiviAuto_Ky, PreventiviAutoStati.PreventiviAutoStati_Titolo, PreventiviAuto.PreventiviAutoStati_Ky";
        strSQLPreventiviAutoStati+= " FROM PreventiviAuto INNER JOIN PreventiviAutoStati ON PreventiviAuto.PreventiviAutoStati_Ky = PreventiviAutoStati.PreventiviAutoStati_Ky";
        strSQLPreventiviAutoStati+= " WHERE PreventiviAuto_Data>=GETDATE()-90";
        strSQLPreventiviAutoStati+= " GROUP BY dbo.PreventiviAutoStati.PreventiviAutoStati_Titolo, dbo.PreventiviAuto.PreventiviAutoStati_Ky";
        break;
      default:
        //PreventiviAuto
        strSQLPreventiviAuto = "SELECT COUNT(PreventiviAuto_Ky) AS NumeroPreventivi, CONVERT(DATE, PreventiviAuto_Data) AS PreventiviAuto_Data, MAX(PreventiviAuto_Ky) AS PreventiviAuto_Ky FROM PreventiviAuto";
        strSQLPreventiviAuto+= " WHERE PreventiviAuto_Data>=GETDATE()-90";
        strSQLPreventiviAuto+= " GROUP BY CONVERT(DATE, PreventiviAuto_Data)";
        //PreventiviAutoStati
        strSQLPreventiviAutoStati = "SELECT COUNT(PreventiviAuto.PreventiviAuto_Ky) AS NumeroPreventivi, MAX(PreventiviAuto.PreventiviAuto_Ky) AS PreventiviAuto_Ky, PreventiviAutoStati.PreventiviAutoStati_Titolo, PreventiviAuto.PreventiviAutoStati_Ky";
        strSQLPreventiviAutoStati+= " FROM PreventiviAuto INNER JOIN PreventiviAutoStati ON PreventiviAuto.PreventiviAutoStati_Ky = PreventiviAutoStati.PreventiviAutoStati_Ky";
        strSQLPreventiviAutoStati+= " WHERE PreventiviAuto_Data>=GETDATE()-90";
        strSQLPreventiviAutoStati+= " GROUP BY dbo.PreventiviAutoStati.PreventiviAutoStati_Titolo, dbo.PreventiviAuto.PreventiviAutoStati_Ky";
        break;
    }
    cmdPreventiviAuto = new System.Data.SqlClient.SqlCommand(strSQLPreventiviAuto, connPreventiviAuto);
    dtPreventiviAuto = new System.Data.DataTable("AndamentoPreventiviAuto");
    dtPreventiviAuto.Load(cmdPreventiviAuto.ExecuteReader());
    
    cmdPreventiviAuto = new System.Data.SqlClient.SqlCommand(strSQLPreventiviAutoStati, connPreventiviAuto);
    dtPreventiviAutoStati = new System.Data.DataTable("AndamentoPreventiviAutoStati");
    dtPreventiviAutoStati.Load(cmdPreventiviAuto.ExecuteReader());

    
%>

  	<div class="divgridcard">
	   	<div id="graphpreventiviauto" style="width:100%;height:250px;margin: 0 auto;"></div>
      <div id="graphpreventiviautostati" style="width:100%;height:500px;margin: 0 auto;"></div>    
      <hr>
  
	<script>
		jQuery(function() {
	    var chart;
	    jQuery(document).ready(function() {
	        
          //grafico PreventiviAuto
          chart = new Highcharts.Chart({
	            chart: {
	                renderTo: 'graphpreventiviauto',
	                type: 'areaspline',
	            },
	            title: {
	                text: 'Preventivi'
	            },
	            subtitle: {
	                text: 'Ultimi 90 giorni'
	            },
              xAxis: {
                  categories: [
                  <% for (int j = 0; j < dtPreventiviAuto.Rows.Count; j++){
  					            	Response.Write("'" + ((DateTime)dtPreventiviAuto.Rows[j]["PreventiviAuto_Data"]).ToString("dd/M/yyyy") + "',");
  									 } %>
                  ]
              },
	            yAxis: {
	                min: 0,
	                title: {
	                    text: 'Numero preventivi'
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
                name: 'Numero preventivi',
                data: [<% for (int j = 0; j < dtPreventiviAuto.Rows.Count; j++){
					           Response.Write(dtPreventiviAuto.Rows[j]["NumeroPreventivi"].ToString() + ",");
							   } %>]},

							]
	        });
          
          
          //grafico PreventiviAutoStati
          chart = new Highcharts.Chart({
              chart: {
	                renderTo: 'graphpreventiviautostati',
                  plotBackgroundColor: null,
                  plotBorderWidth: null,
                  plotShadow: false,
                  type: 'pie'
              },
	            title: {
	                text: 'Stato preventivi'
	            },
	            subtitle: {
	                text: 'Ultimi 90 giorni'
	            },
	            yAxis: {
	                min: 0,
	                title: {
	                    text: 'Numero preventivi'
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
                name: 'Numero preventivi',
                colorByPoint: true,
                data: [<%
	                 for (int j = 0; j < dtPreventiviAutoStati.Rows.Count; j++){
					            	Response.Write("{name: '" + dtPreventiviAutoStati.Rows[j]["PreventiviAutoStati_Titolo"].ToString() + "',y:" + dtPreventiviAutoStati.Rows[j]["NumeroPreventivi"].ToString() + "},");
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
				<th align="left" width="250">Numero Preventivi</th>
				</tr>
			</thead>
    		<tbody>
        <%
			  for (int j = 0; j < dtPreventiviAuto.Rows.Count; j++){
			  %>

		        <tr class="riga<%=i%2%>" id="<%=dtPreventiviAuto.Rows[j]["PreventiviAuto_Ky"].ToString()%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtPreventiviAuto.Rows[j]["PreventiviAuto_Ky"].ToString()%>" data-value="<%=dtPreventiviAuto.Rows[j]["PreventiviAuto_Ky"].ToString()%>" /></td>
		          <td><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtPreventiviAuto.Rows[j]["PreventiviAuto_Data"].ToString()%></td>
		          <td class="text-left"><%=dtPreventiviAuto.Rows[i]["NumeroPreventivi"].ToString()%></td>
		        </tr>
		    <%
				}
				%>
    </table>

	</div>
