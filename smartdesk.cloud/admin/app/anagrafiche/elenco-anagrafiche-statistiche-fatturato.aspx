<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/anagrafiche/elenco-anagrafiche-statistiche-fatturato.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Anagrafiche > Statistiche fatturato</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<h1><i class="fa-duotone fa-chart-mixed fa-lg fa-fw"></i><%=strH1%></h1>	
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
	    <div class="divgrid">
      <table class="grid table-scroll hover" id="griddatatables">
		    	<thead>
	        <tr>
	          <th width="30">Cod.</th>
	          <th width="500">Ragione Sociale</th>
	          <th>Anno</th>
	          <th>N&deg; Documenti</th>
	          <th>Tot Documenti</th>
	        </tr>
		   </thead>
		   <tbody>
	    <%for (int i = 0; i < dtAnagrafiche.Rows.Count; i++){ %>
	        <tr>
	          <td><%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%></td>
	          <td>
							<div class="width250">
			            <% if (dtAnagrafiche.Rows[i]["Anagrafiche_Disdetto"].Equals(true)){ %>
		            <i class="fa-duotone fa-circle-info fa-fw" style="color:#ec5840" title="chiuso"></i>
			            <% } %>
									<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>"><i class="fa-duotone fa-users fa-fw"></i><%=dtAnagrafiche.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
							</div>
						</td>
	          <td><%=dtAnagrafiche.Rows[i]["Anno"].ToString()%></td>
	          <td>n&deg; <%=dtAnagrafiche.Rows[i]["NumeroDocumenti"].ToString()%></td>
	          <td class="large-text-right small-text-left">&euro;
	          <%
						if (dtAnagrafiche.Rows[i]["TotaleDocumenti"]!=DBNull.Value){
							Response.Write(Convert.ToDecimal(dtAnagrafiche.Rows[i]["TotaleDocumenti"]).ToString("N2", cien).Replace(",",""));
						}else{
							Response.Write("0");
						}
						%>
						</td>
	        </tr>
	    <%
	      intAnagrafiche_Ky=Convert.ToInt32(dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
	      decTot=decTot+Convert.ToDecimal(dtAnagrafiche.Rows[i]["TotaleDocumenti"]);
	    } %>
        <tr>
          <td colspan="4" class="text-right">Totale</td>
	        <td><%=decTot.ToString("N2", cien)%></td>
	      </tr>
		    </tbody>
		  </table>
      </div>
 </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
