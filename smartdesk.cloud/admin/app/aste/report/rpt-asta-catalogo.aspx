<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="rpt-asta.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title><%=dtAste.Rows[0]["Aste_Titolo"]%></title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
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
  <link type="text/css" rel="stylesheet" href="/fonts/Geomanist/Geomanist.css" media="screen, print" />
  <link rel="stylesheet" type="text/css" href="/admin/rswcrm-print.css" media="screen, print" />
  <meta name="msapplication-TileColor" content="#ffffff">
  <meta name="msapplication-TileImage" content="https://cdn.smartdesk.cloud/img/favicon/ms-icon-144x144.png">
  <meta name="theme-color" content="#ffffff">  
  <link rel="stylesheet" href="/lib/fontawesome6/css/all.min.css" />
	<style>
		body, table, tbody, th, td, tr, p, label, div, legend{
			font-size:10pt !important;
		}
		.reporta4verticale{
			width:19cm;
			background-color:#ffffff;
		}
		.corporeport{
			width:19cm;
		}
	</style>
</head>
<body class="reporta4verticale" style="margin-left:5px;">
  <div class="row">
    <div class="large-4 medium-4 small-12 columns">
        <img src="<%=dtAzienda.Rows[0]["Aziende_Logo"].ToString()%>" border="0" style="max-height:70px;max-width:250px;padding-top:10px;" />
    </div>
    <div class="large-8 medium-8 small-12 columns">
      <div style="border:0;padding:10px;width:7cm;text-align:left">
      </div>
    </div>
  </div>
  <hr>

	<fieldset class="fieldset">
		<legend>Asta</legend>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Titolo</label></div>
			<div class="large-10 medium-10 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "Aste_Titolo")%></div>
    </div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Procedura</label></div>
			<div class="large-10 medium-10 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "Aste_Procedura")%></div>
    </div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Cauzione</label></div>
			<div class="large-4 medium-4 small-12 columns">&euro; <%=Smartdesk.Data.Field(dtAste, "Aste_Cauzione")%></div>
      <div class="large-2 medium-2 small-12 columns"><label>Numero</label></div>
			<div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "Aste_Numero")%></div>
    </div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Anagrafica</label></div>
			<div class="large-10 medium-10 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "Anagrafiche_RagioneSociale")%></div>
    </div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Indirizzo</label></div>
      <div class="large-10 medium-10 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "Aste_Indirizzo")%> <%=Smartdesk.Data.Field(dtAste, "Comuni_Comune")%>, <%=Smartdesk.Data.Field(dtAste, "Province_Provincia")%>, <%=Smartdesk.Data.Field(dtAste, "Regioni_Regione")%>, <%=Smartdesk.Data.Field(dtAste, "Nazioni_Nazione")%></div></div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Referente</label></div>
      <div class="large-10 medium-10 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "Aste_Referente")%> <i class="fa-duotone fa-phone fa-fw"></i><%=Smartdesk.Data.Field(dtAste, "Aste_CellulareReferente")%> <i class="fa-duotone fa-envelope fa-fw"></i><%=Smartdesk.Data.Field(dtAste, "Aste_EmailReferente")%></div>
    </div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Pagamento</label></div>
			<div class="large-4 medium-4 small-12 columns"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=Smartdesk.Data.Field(dtAste, "Aste_DataPagamento")%></div>
      <div class="large-2 medium-2 small-12 columns"><label>Tramite</label></div>
			<div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "PagamentiMetodo_Descrizione")%></div>
    </div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Ritiro</label></div>
			<div class="large-10 medium-10 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "AsteRitiri_Titolo")%></div>
    </div>
	</fieldset>  
  
  <h2>Lotti</h2>
	<table border="0" width="100%">
  	<thead>
      <tr>
        <th width="30">Cod.</th>
        <th width="100">Foto</th>
  			<th width="100">Titolo</th>
  			<th width="80">Valore</th>
      </tr>
  	</thead>
  	<tbody>
	    <%for (int i = 0; i < dtAnnunci.Rows.Count; i++){ %>
	        <tr class="riga<%=i%>">
      			<td><%=dtAnnunci.Rows[i]["Annunci_Numero"].ToString()%></td>
      			<td><img src="<%=dtAnnunci.Rows[i]["Annunci_Foto1"].ToString()%>" width="150" height="100"></td>
	          <td>
							<%=dtAnnunci.Rows[i]["Annunci_Titolo"].ToString()%><br>
							<% Response.Write(getAttributi(i)); %>
						</td>
	          <td><strong style="font-size:14pt">&euro; <%=Convert.ToDecimal(dtAnnunci.Rows[i]["Annunci_Valore"]).ToString("N2", ci)%></strong></td>
	        </tr>
	    <% } %>
    	</tbody>
		  <% if (dtAnnunci.Rows.Count<1){
		      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
			} %> 
  </table>
    
  </div>
  
    
</body>
</html>
