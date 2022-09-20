<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/anagrafiche/elenco-anagrafiche-statistiche.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Anagrafiche > Elenco anagrafiche statistiche</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx -->
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
        <div class="large-5 medium-5 small-12 cell align-middle">
          <h1><i class="fa-duotone fa-chart-mixed fa-lg fa-fw"></i><%=strH1%></h1> 
        </div>
        <div class="large-7 medium-7 small-12 cell float-right align-middle">
        </div>
      </div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
			<div class="divgrid">
      <p><i class="fa-duotone fa-info fa-fw fa-lg"></i>Statistiche sulle anagrafiche calcolate sulla base dei dati inseriti come Fatture, Note di Credito, ore di attivit&agrave; ecc.</p>			    
	    <table class="grid table-scroll hover" id="griddatatables">
		    	<thead>
	        <tr>
	          <th width="30">Cod.</th>
	          <th width="270">Ragione Sociale</th>
	          <th width="120">Provincia</th>
	          <th width="80">Tipo</th>
	          <th width="140">N&deg; Attivit&agrave;</th>
	          <th width="120">N&deg; Doc.</th>
	          <th width="120">N&deg; Servizi</th>
	          <th width="120">N&deg; Pag.</th>
	          <th width="140">GG Ritardo</th>
	          <th width="120">Tot Pag. &euro;</th>
	          <th width="140">Tot Servizi &euro;</th>
	          <th width="120">Tot Doc. &euro;</th>
	          <th width="120">Tot Ore</th>
	        </tr>
		   </thead>
		   <tbody>
	    <%for (int i = 0; i < dtAnagrafiche.Rows.Count; i++){ %>
	        <tr>
	          <td><%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%></td>
	          <td>
							<div class="width250">
			            <% if (dtAnagrafiche.Rows[i]["Anagrafiche_Disdetto"].Equals(true)){ %>
			            <strong>>>DISDETTA<<</strong>
			            <% } %>
									<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>"><i class="fa-duotone fa-users fa-fw"></i><%=dtAnagrafiche.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
							</div>
						</td>
	          <td><%=dtAnagrafiche.Rows[i]["Province_Provincia"].ToString()%></td>
	          <td><%=dtAnagrafiche.Rows[i]["AnagraficheTipo_Descrizione"].ToString()%></td>
	          <td><%=dtAnagrafiche.Rows[i]["NumeroAttivita"].ToString()%></td>
	          <td><%=dtAnagrafiche.Rows[i]["NumeroDocumenti"].ToString()%></td>
	          <td><%=dtAnagrafiche.Rows[i]["NumeroServizi"].ToString()%></td>
	          <td><%=dtAnagrafiche.Rows[i]["NumeroPagamenti"].ToString()%></td>
	          <td><%=Smartdesk.Functions.getGG(dtAnagrafiche.Rows[i]["GGRitardo"].ToString())%></td>
	          <td class="large-text-right small-text-left">&euro; 
	          <%
						if (dtAnagrafiche.Rows[i]["TotalePagamenti"]!=DBNull.Value){
							Response.Write(Convert.ToDecimal(dtAnagrafiche.Rows[i]["TotalePagamenti"]).ToString("N2", cien).Replace(",",""));
						}else{
							Response.Write("0.00");
						}
						%>
						</td>
	          <td class="large-text-right small-text-left">&euro; 
	          <%
						if (dtAnagrafiche.Rows[i]["TotaleServizi"]!=DBNull.Value){
							Response.Write(Convert.ToDecimal(dtAnagrafiche.Rows[i]["TotaleServizi"]).ToString("N2", cien).Replace(",",""));
						}else{
							Response.Write("0.00");
						}
						%>
						</td>
	          <td class="large-text-right small-text-left">&euro; 
	          <%
						if (dtAnagrafiche.Rows[i]["TotaleDocumenti"]!=DBNull.Value){
							Response.Write(Convert.ToDecimal(dtAnagrafiche.Rows[i]["TotaleDocumenti"]).ToString("N2", cien).Replace(",",""));
						}else{
							Response.Write("0.00");
						}
						%>
						</td>
	          <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i>
	          <%
						if (dtAnagrafiche.Rows[i]["TotaleOre"]!=DBNull.Value){
							Response.Write(Convert.ToDecimal(dtAnagrafiche.Rows[i]["TotaleOre"]).ToString("N2", cien).Replace(",",""));
						}else{
							Response.Write("0.00");
						}
						%>
						</td>
	        </tr>
	    <%
	      intAnagrafiche_Ky=Convert.ToInt32(dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
	    } %>
		    </tbody>
		  </table>
      </div>
 </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
