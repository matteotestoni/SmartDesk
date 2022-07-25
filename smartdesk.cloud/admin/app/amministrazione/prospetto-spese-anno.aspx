<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/amministrazione/prospetto-spese-anno.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>

<html class="no-js" lang="it">
<head>
	<title>Spese > Prospetto spese</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-5 small-12 cell align-middle">
              <h1><i class="fa-duotone fa-inbox fa-lg fa-fw"></i><%=strH1%></h1>	
          </div>
          <div class="large-8 medium-7 small-12 cell float-right align-middle">
          		<div class="stacked-for-small button-group small hide-for-print align-right">
          			<a href="/admin/app/amministrazione/report/rpt-prospetto-spese-anno.aspx" class="tiny button secondary" target="_blank"><i class="fa-duotone fa-print fa-fw"></i>Stampa</a>
                <% for (int i = intYear-5; i <= intYear; i++){ %>
          			<a href="/admin/app/amministrazione/prospetto-spese-anno.aspx?anno=<%=i%>" class="tiny button secondary"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=i%></a>
                <% } %>
             	</div>
        </div>
  	</div>
  </div>
</div>
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
		<div class="divgrid">
		<h2>Prospetto per centri di costo</h2>
		<table id="grid2" class="grid">
			<thead>
        <tr>
	        <th class="large-text-left small-text-left" width="350">Centro di costo</th>
	        <th class="large-text-right small-text-left">gennaio</th>
	        <th class="large-text-right small-text-left">febbraio</th>
	        <th class="large-text-right small-text-left">marzo</th>
	        <th class="large-text-right small-text-left">aprile</th>
	        <th class="large-text-right small-text-left">maggio</th>
	        <th class="large-text-right small-text-left">giugno</th>
	        <th class="large-text-right small-text-left">luglio</th>
	        <th class="large-text-right small-text-left">agosto</th>
	        <th class="large-text-right small-text-left">settembre</th>
	        <th class="large-text-right small-text-left">ottobre</th>
	        <th class="large-text-right small-text-left">novembre</th>
	        <th class="large-text-right small-text-left">dicembre</th>
	        <th class="large-text-right small-text-left">Totale</th>
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
            <a href="/admin/app/amministrazione/elenco-spese.aspx?CoreModules_Ky=2&CoreEntities_Ky=1&CoreGrids_Ky=1&CentridiCR_Ky=<%=dtCentridiCR.Rows[i]["CentridiCR_Ky"].ToString()%>"><strong><i class="<%=dtCentridiCR.Rows[i]["CentridiCR_Icona"].ToString()%> fa-fw"></i><%=dtCentridiCR.Rows[i]["CentridiCR_Titolo"].ToString()%></strong></a>
            <a data-tooltip title="<%=dtCentridiCR.Rows[i]["CentridiCR_Descrizione"].ToString()%>"><i class="fa-duotone fa-circle-info fa-fw"></i></a>
            </td>
	          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],1]).ToString("N2", ciit)%></td>
	          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],2]).ToString("N2", ciit)%></td>
	          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],3]).ToString("N2", ciit)%></td>
	          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],4]).ToString("N2", ciit)%></td>
	          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],5]).ToString("N2", ciit)%></td>
	          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],6]).ToString("N2", ciit)%></td>
	          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],7]).ToString("N2", ciit)%></td>
	          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],8]).ToString("N2", ciit)%></td>
	          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],9]).ToString("N2", ciit)%></td>
	          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],10]).ToString("N2", ciit)%></td>
	          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],11]).ToString("N2", ciit)%></td>
	          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCR.Rows[i]["CentridiCR_Ky"],12]).ToString("N2", ciit)%></td>
	          <td class="large-text-right small-text-left"><%=decTotTemp.ToString("N2", ciit)%></td>
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
                  <i class="fa-duotone fa-angle-right fa-fw"></i><a href="/admin/app/amministrazione/elenco-spese.aspx?CoreModules_Ky=2&CoreEntities_Ky=1&CoreGrids_Ky=1&CentridiCR_Ky=<%=dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"].ToString()%>&Year(Spese_Data)=<%=intAnnoCorrente%>"><i class="<%=dtCentridiCRFigli.Rows[x]["CentridiCR_Icona"].ToString()%> fa-fw"></i><%=dtCentridiCRFigli.Rows[x]["CentridiCR_Titolo"].ToString()%> <%=intAnnoCorrente%></a>
                  <a data-tooltip title="<%=dtCentridiCRFigli.Rows[x]["CentridiCR_Descrizione"].ToString()%>"><i class="fa-duotone fa-circle-info fa-fw"></i></a>
                  
                  </td>
    		          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],1]).ToString("N2", ciit)%></td>
    		          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],2]).ToString("N2", ciit)%></td>
    		          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],3]).ToString("N2", ciit)%></td>
    		          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],4]).ToString("N2", ciit)%></td>
    		          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],5]).ToString("N2", ciit)%></td>
    		          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],6]).ToString("N2", ciit)%></td>
    		          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],7]).ToString("N2", ciit)%></td>
    		          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],8]).ToString("N2", ciit)%></td>
    		          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],9]).ToString("N2", ciit)%></td>
    		          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],10]).ToString("N2", ciit)%></td>
    		          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],11]).ToString("N2", ciit)%></td>
    		          <td class="large-text-right small-text-left"><%=Convert.ToDecimal(arrayspese[(int)dtCentridiCRFigli.Rows[x]["CentridiCR_Ky"],12]).ToString("N2", ciit)%></td>
    		          <td class="large-text-right small-text-left"><%=decTotTemp.ToString("N2", ciit)%></td>
                </tr>
              <%
            }
          }  %> 
			<% } %>
		 </tbody>
		 <tfoot>
        <tr>
	        <td class="large-text-right small-text-left">Totali <%=intAnnoCorrente%></td>
	        <td class="large-text-right small-text-left"><%=decTotCol1.ToString("N2", ciit)%></td>
	        <td class="large-text-right small-text-left"><%=decTotCol2.ToString("N2", ciit)%></td>
	        <td class="large-text-right small-text-left"><%=decTotCol3.ToString("N2", ciit)%></td>
	        <td class="large-text-right small-text-left"><%=decTotCol4.ToString("N2", ciit)%></td>
	        <td class="large-text-right small-text-left"><%=decTotCol5.ToString("N2", ciit)%></td>
	        <td class="large-text-right small-text-left"><%=decTotCol6.ToString("N2", ciit)%></td>
	        <td class="large-text-right small-text-left"><%=decTotCol7.ToString("N2", ciit)%></td>
	        <td class="large-text-right small-text-left"><%=decTotCol8.ToString("N2", ciit)%></td>
	        <td class="large-text-right small-text-left"><%=decTotCol9.ToString("N2", ciit)%></td>
	        <td class="large-text-right small-text-left"><%=decTotCol10.ToString("N2", ciit)%></td>
	        <td class="large-text-right small-text-left"><%=decTotCol11.ToString("N2", ciit)%></td>
	        <td class="large-text-right small-text-left"><%=decTotCol12.ToString("N2", ciit)%></td>
	        <% 
						decTotTemp=decTotCol1+decTotCol2+decTotCol3+decTotCol4+decTotCol5+decTotCol6+decTotCol7+decTotCol8+decTotCol9+decTotCol10+decTotCol11+decTotCol12;
					%>
					<td class="large-text-right small-text-left"><%=decTotTemp.ToString("N2", ciit)%></td>
        </tr>
		 </tfoot>
		</table>
	</div>
  </div>
 </div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
