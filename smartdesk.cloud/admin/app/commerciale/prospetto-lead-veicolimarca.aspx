<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/commerciale/prospetto-lead-veicolimarca.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Commerciale > Prospetto lead per marca veicoli</title>
	<!--#include file="/admin/inc-head.aspx"-->
  <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/js-cookie@3.0.1/dist/js.cookie.min.js" integrity="sha256-0H3Nuz3aug3afVbUlsu12Puxva3CP4EhJtPExqs54Vg=" crossorigin="anonymous"></script>
  <script type="text/javascript" src="https://cdn.jsdelivr.net/momentjs/latest/moment.min.js"></script>
  <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js"></script>
  <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css" />
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
	<div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
		<div class="grid-x grid-padding-x">
			<div class="large-7 medium-8 small-12 cell">
          <h1><i class="fa-duotone fa-bullhorn fa-fw"></i><%=strH1%></h1>
      </div>
			<div class="large-5 medium-4 small-12 cell float-right">
        <!--#include file=/admin/app/commerciale/inc-reportdatarange.aspx --> 
			</div>
		</div>
	</div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
		<div class="divgrid">
      <table id="grid1" class="grid">
  		<thead>
          <tr>
  	        <th class="text-left" width="130">Codice Marca</th>
  	        <th class="text-left">Marca</th>
  	        <th class="large-text-right small-text-left">Numero Lead</th>
  	        <th></th>
          </tr>
  		</thead>
  	   <tbody>
  		  <% for (int i = 0; i < dtProspettoLead.Rows.Count; i++){ %>
  	    <tr>
  				<td><a href="/admin/app/commerciale/prospetto-lead-veicolimodello.aspx?VeicoliMarca_Ky=<%=dtProspettoLead.Rows[i]["VeicoliMarca_Ky"].ToString()%>"><%=dtProspettoLead.Rows[i]["VeicoliMarca_Ky"].ToString()%></a></td>
  				<td><a href="/admin/app/commerciale/prospetto-lead-veicolimodello.aspx?VeicoliMarca_Ky=<%=dtProspettoLead.Rows[i]["VeicoliMarca_Ky"].ToString()%>"><%=dtProspettoLead.Rows[i]["VeicoliMarca_Titolo"].ToString()%></a></td>
  				<td class="large-text-right small-text-left"><strong></strong><%=dtProspettoLead.Rows[i]["Conteggio"].ToString()%></strong></td>
  				<td><a href="/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175&VeicoliMarca_Ky=<%=dtProspettoLead.Rows[i]["VeicoliMarca_Ky"].ToString()%>">Vedi lead <i class="fa-duotone fa-angle-right fa-fw"></i></a></td>
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
  </div>
 </div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
