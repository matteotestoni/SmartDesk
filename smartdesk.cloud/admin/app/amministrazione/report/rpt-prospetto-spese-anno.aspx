<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/amministrazione/report/rpt-prospetto-spese-anno.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
	<title>Spese > Prospetto spese</title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <link rel="preconnect" href="https://fonts.gstatic.com">
  <link type="text/css" rel="stylesheet" href="/fonts/Geomanist/Geomanist.css" media="screen, print" />
  <link rel="stylesheet" type="text/css" href="/admin/rswcrm-print.css" media="screen, print" />
  <link rel="stylesheet" href="https://cdn.smartdesk.cloud/lib/fontawesome6/css/all.min.css" />
  <link rel="shortcut icon" href="https://cdn.smartdesk.cloud/img/favicon/favicon.ico">
  <link rel="apple-touch-icon" sizes="57x57" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-57x57.png">
  <link rel="apple-touch-icon" sizes="60x60" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-60x60.png">
  <link rel="apple-touch-icon" sizes="72x72" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-72x72.png">
  <link rel="apple-touch-icon" sizes="76x76" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-76x76.png">
  <link rel="apple-touch-icon" sizes="114x114" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-114x114.png">
  <link rel="apple-touch-icon" sizes="120x120" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-120x120.png">
  <link rel="apple-touch-icon" sizes="144x144" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-144x144.png">
  <link rel="apple-touch-icon" sizes="152x152" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-152x152.png">
  <link rel="apple-touch-icon" sizes="180x180" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-180x180.png">
  <link rel="icon" type="image/png" sizes="192x192" href="https://cdn.smartdesk.cloud/img/favicon/android-icon-192x192.png">
  <link rel="icon" type="image/png" sizes="32x32" href="https://cdn.smartdesk.cloud/img/favicon/favicon-32x32.png">
  <link rel="icon" type="image/png" sizes="96x96" href="https://cdn.smartdesk.cloud/img/favicon/favicon-96x96.png">
  <link rel="icon" type="image/png" sizes="16x16" href="https://cdn.smartdesk.cloud/img/favicon/favicon-16x16.png">
  <link rel="manifest" href="https://cdn.smartdesk.cloud/img/favicon/manifest.json">
  <meta name="msapplication-TileColor" content="#ffffff">
  <meta name="msapplication-TileImage" content="https://cdn.smartdesk.cloud/img/favicon/ms-icon-144x144.png">
  <meta name="theme-color" content="#ffffff">  
</head>
<body style="margin-left:5px;">
  
  <table border="0" cellpadding="0" cellspacing="0" class="headerhor">
  <tr>
    <td width="40%" align="left">
        <img src="<%=dtAzienda.Rows[0]["Aziende_Logo"].ToString()%>" border="0" style="max-height:70px;max-width:250px;padding-top:10px;" />
    </td>
    <td width="60%" align="right">
      <div style="border:0;padding:20px;width:10cm;text-align:left">
        <div class="tipodocumento">Prospetto per centri di costo</div>
        <div class="riferimenti">Data: </div><i class="fa-duotone fa-calendar-days fa-fw"></i><%Response.Write(DateTime.Now.ToString("d"));%>
      </div>
    </td>
  </tr>
  </table>
  <br>


	<table id="grid2" class="grid">
		<thead>
      <tr>
        <th class="large-text-left small-text-left" width="250">Centro di costo</th>
        <th align="right">gennaio</th>
        <th align="right">febbraio</th>
        <th align="right">marzo</th>
        <th align="right">aprile</th>
        <th align="right">maggio</th>
        <th align="right">giugno</th>
        <th align="right">luglio</th>
        <th align="right">agosto</th>
        <th align="right">settembre</th>
        <th align="right">ottobre</th>
        <th align="right">novembre</th>
        <th align="right">dicembre</th>
        <th align="right">Totale</th>
      </tr>
   </thead>
   <tbody>
	  <% for (int i = 0; i < dtCentridiCR.Rows.Count; i++){ 
	      
       decTotTemp=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],1])+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],2])+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],3])+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],4])+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],5])+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],6])+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],7])+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],8])+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],9])+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],10])+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],11])+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],12]);
			 decTotCol1=decTotCol1+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],1]);
			 decTotCol2=decTotCol2+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],2]);
			 decTotCol3=decTotCol3+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],3]);
			 decTotCol4=decTotCol4+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],4]);
			 decTotCol5=decTotCol5+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],5]);
			 decTotCol6=decTotCol6+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],6]);
			 decTotCol7=decTotCol7+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],7]);
			 decTotCol8=decTotCol8+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],8]);
			 decTotCol9=decTotCol9+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],9]);
			 decTotCol10=decTotCol10+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],10]);
			 decTotCol11=decTotCol11+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],11]);
			 decTotCol12=decTotCol12+Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],12]);
			 %>
        <tr>
         	<td class="large-text-left small-text-left">
          <strong><%=dtCentridiCR.Rows[i]["CentridiCR_Titolo"].ToString()%></strong></td>
          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],1]).ToString("N2", ciit)%></td>
          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],2]).ToString("N2", ciit)%></td>
          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],3]).ToString("N2", ciit)%></td>
          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],4]).ToString("N2", ciit)%></td>
          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],5]).ToString("N2", ciit)%></td>
          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],6]).ToString("N2", ciit)%></td>
          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],7]).ToString("N2", ciit)%></td>
          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],8]).ToString("N2", ciit)%></td>
          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],9]).ToString("N2", ciit)%></td>
          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],10]).ToString("N2", ciit)%></td>
          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],11]).ToString("N2", ciit)%></td>
          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],12]).ToString("N2", ciit)%></td>
          <td align="right"><%=decTotTemp.ToString("N2", ciit)%></td>
        </tr>
        <%
        strWHERENet="CentridiCR_Attivo=1 AND CentridiCR_Padre=" + dtCentridiCR.Rows[i]["CentridiCR_Ky"].ToString();
        strFROMNet = "CentridiCR";
        strORDERNet = "CentridiCR_Padre, CentridiCR_Titolo";
        dtCentridiCRFigli = new System.Data.DataTable("CentridiCRFigli");
        dtCentridiCRFigli = Smartdesk.Sql.getTablePage(strFROMNet, null, "CentridiCR_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);     
        if (dtCentridiCRFigli.Rows.Count>0){
          for (int x = 0; x < dtCentridiCRFigli.Rows.Count; x++){ 
             decTotTemp=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],1])+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],2])+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],3])+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],4])+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],5])+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],6])+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],7])+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],8])+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],9])+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],10])+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],11])+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],12]);
  					 decTotCol1=decTotCol1+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],1]);
  					 decTotCol2=decTotCol2+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],2]);
  					 decTotCol3=decTotCol3+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],3]);
  					 decTotCol4=decTotCol4+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],4]);
  					 decTotCol5=decTotCol5+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],5]);
  					 decTotCol6=decTotCol6+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],6]);
  					 decTotCol7=decTotCol7+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],7]);
  					 decTotCol8=decTotCol8+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],8]);
  					 decTotCol9=decTotCol9+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],9]);
  					 decTotCol10=decTotCol10+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],10]);
  					 decTotCol11=decTotCol11+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],11]);
  					 decTotCol12=decTotCol12+Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],12]);

  					 %>
  	          <tr>
               	<td class="large-text-left small-text-left">
                <i class="fa-duotone fa-angle-right fa-fw"></i><%=dtCentridiCRFigli.Rows[x]["CentridiCR_Titolo"].ToString()%></td>
  		          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],1]).ToString("N2", ciit)%></td>
  		          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],2]).ToString("N2", ciit)%></td>
  		          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],3]).ToString("N2", ciit)%></td>
  		          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],4]).ToString("N2", ciit)%></td>
  		          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],5]).ToString("N2", ciit)%></td>
  		          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],6]).ToString("N2", ciit)%></td>
  		          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],7]).ToString("N2", ciit)%></td>
  		          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],8]).ToString("N2", ciit)%></td>
  		          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],9]).ToString("N2", ciit)%></td>
  		          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],10]).ToString("N2", ciit)%></td>
  		          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],11]).ToString("N2", ciit)%></td>
  		          <td align="right"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],12]).ToString("N2", ciit)%></td>
  		          <td align="right"><%=decTotTemp.ToString("N2", ciit)%></td>
              </tr>
            <%
          }
        }  %> 

         
         
         
		<% } %>
	 </tbody>
	 <tfoot class="hide" style="display:none">
      <tr>
        <td align="right"><strong>Totali <%=intAnnoCorrente%></strong></td>
        <td align="right"><strong><%=decTotCol1.ToString("N2", ciit)%></strong></td>
        <td align="right"><strong><%=decTotCol2.ToString("N2", ciit)%></strong></td>
        <td align="right"><strong><%=decTotCol3.ToString("N2", ciit)%></strong></td>
        <td align="right"><strong><%=decTotCol4.ToString("N2", ciit)%></strong></td>
        <td align="right"><strong><%=decTotCol5.ToString("N2", ciit)%></strong></td>
        <td align="right"><strong><%=decTotCol6.ToString("N2", ciit)%></strong></td>
        <td align="right"><strong><%=decTotCol7.ToString("N2", ciit)%></strong></td>
        <td align="right"><strong><%=decTotCol8.ToString("N2", ciit)%></strong></td>
        <td align="right"><strong><%=decTotCol9.ToString("N2", ciit)%></strong></td>
        <td align="right"><strong><%=decTotCol10.ToString("N2", ciit)%></strong></td>
        <td align="right"><strong><%=decTotCol11.ToString("N2", ciit)%></strong></td>
        <td align="right"><strong><%=decTotCol12.ToString("N2", ciit)%></strong></td>
        <% 
					decTotTemp=decTotCol1+decTotCol2+decTotCol3+decTotCol4+decTotCol5+decTotCol6+decTotCol7+decTotCol8+decTotCol9+decTotCol10+decTotCol11+decTotCol12;
				%>
				<td align="right"><strong><%=decTotTemp.ToString("N2", ciit)%></strong></td>
      </tr>
	 </tfoot>
	</table>

  <div class="footerhor">
    <%=dtAzienda.Rows[0]["Aziende_Footer"].ToString()%>
  </div>
</body>
</html>
