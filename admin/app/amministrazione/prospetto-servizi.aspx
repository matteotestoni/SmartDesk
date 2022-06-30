<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/amministrazione/prospetto-servizi.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Amministrazione > prospetto servizi</title>
  <!--#include file="/admin/inc-head.aspx"-->  
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<h1><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i>Prospetto fatturato e previsionale</h1>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
			<ul>
				<li>Mese corrente:<%=intMonth%></li>
				<li>Anno corrente:<%=intYear%></li>
			</ul>
			<div class="divgrid">
			<table id="grid2" class="grid" style="width:auto;">
				<thead>
	        <tr>
		        <th scope="col" width="200"class="text-right">Mese</th>
		        <th scope="col" class="text-right">Servizi</th>
	        </tr>
		   </thead>
		   <tbody>
	      <%for (int i = 1; i <= 12; i++){ %>
	          <tr>
	            <th class="text-right" width="200"><%=Smartdesk.Functions.GetMese(i.ToString())%></th>
          		<td class="large-text-right small-text-left"><%=GetValore(servizi1[i])%></td>
	          </tr>
	      <% } %>
	          <tr>
	            <th class="text-right" width="200">Totale</th>
          		<td class="large-text-right small-text-left"><%=GetValore(servizi1[13])%></td>
	          </tr>
		   </tbody>
	    </table>
		</div>
  </div>
 </div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
