<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="rpt-asteesperimenti.aspx.cs" Inherits="_Default" Debug="true"%>
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
		@import url(https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Condensed:300,400,700|Open+Sans:300,400,700);

		body, table, tbody, th, td, tr, p, label, div, legend{
			font-size:9pt !important;
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

	<div class="corporeport">
	<fieldset class="fieldset">
		<legend>Esperimento</legend>
  	<div class="row">
    	<div class="large-2 medium-2 small-12 columns"><label>Esperimento</label></div>
    	<div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAsteEsperimenti, "AsteEsperimenti_Numero")%></div>
    	<div class="large-2 medium-2 small-12 columns"><label>Esito</label></div>
    	<div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAsteEsperimenti, "AsteEsperimentiEsiti_Titolo")%></div>
    </div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Ribasso</label></div>
      <div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAsteEsperimenti, "AsteEsperimenti_PercentualeRibasso")%></div>
      <div class="large-2 medium-2 small-12 columns"><label>Inizio</label></div>
      <div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAsteEsperimenti, "AsteEsperimenti_DataInizio")%></div>
    </div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Termine</label></div>
      <div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAsteEsperimenti, "AsteEsperimenti_DataTermine")%></div>
      <div class="large-2 medium-2 small-12 columns"><label>Pubblicazione</label></div>
      <div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAsteEsperimenti, "AsteEsperimenti_DataPubblicazione")%></div>
    </div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Chiusura</label></div>
      <div class="large-10 medium-10 small-12 columns">
        <%=Smartdesk.Data.Field(dtAsteEsperimenti, "AsteEsperimenti_DataChiusura")%>
      </div>
    </div>
	</fieldset>
	<fieldset class="fieldset">
		<legend>Asta</legend>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Titolo</label></div>
			<div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "Aste_Titolo")%></div>
      <div class="large-2 medium-2 small-12 columns"><label>Numero</label></div>
			<div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "Aste_Numero")%></div>
    </div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Anagrafica</label></div>
			<div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "Anagrafiche_RagioneSociale")%></div>
      <div class="large-2 medium-2 small-12 columns"><label>Categoria</label></div>
			<div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "AsteCategorie_Titolo")%></div>
    </div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Indirizzo</label></div>
      <div class="large-10 medium-10 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "Aste_Indirizzo")%>,<%=Smartdesk.Data.Field(dtAste, "Comuni_Comune")%>, <%=Smartdesk.Data.Field(dtAste, "Province_Provincia")%>, <%=Smartdesk.Data.Field(dtAste, "Regioni_Regione")%>, <%=Smartdesk.Data.Field(dtAste, "Nazioni_Nazione")%></div></div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Referente</label></div>
      <div class="large-10 medium-10 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "Aste_Referente")%>,<i class="fa-duotone fa-phone fa-fw"></i><%=Smartdesk.Data.Field(dtAste, "Aste_CellulareReferente")%>, <i class="fa-duotone fa-envelope fa-fw"></i><%=Smartdesk.Data.Field(dtAste, "Aste_EmailReferente")%></div>
    </div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Provvigione</label></div>
			<div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "Aste_Provvigione")%></div>
      <div class="large-2 medium-2 small-12 columns"><label>Cauzione</label></div>
			<div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "Aste_Cauzione")%></div>
    </div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Rilancio</label></div>
			<div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "Aste_Rilancio")%></div>
      <div class="large-2 medium-2 small-12 columns"><label>Pagamento</label></div>
			<div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "PagamentiMetodo_Descrizione")%></div>
    </div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Pagamento</label></div>
			<div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "Aste_DataPagamento")%></div>
      <div class="large-2 medium-2 small-12 columns"><label>Ritiro</label></div>
			<div class="large-4 medium-4 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "AsteRitiri_Titolo")%></div>
    </div>
    <div class="row">
      <div class="large-2 medium-2 small-12 columns"><label>Descrizione</label></div>
      <div class="large-10 medium-10 small-12 columns"><%=Smartdesk.Data.Field(dtAste, "Aste_Descrizione")%></div>
    </div>
	</fieldset>
  
  
  <h2>Lotti</h2>
	<table border="0" width="100%">
  	<thead>
      <tr>
        <th width="30">Cod.</label></div>
  			<th width="100">Titolo</label></div>
  			<th width="80">Stato</label></div>
  			<th width="80">Categoria</label></div>
  			<th width="80">Valore</label></div>
  			<th width="80">Cauzione</label></div>
  			<th width="80">Rilancio</label></div>
      </tr>
  	</thead>
  	<tbody>
	    <%for (int i = 0; i < dtAnnunci.Rows.Count; i++){ %>
	        <tr class="riga<%=i%2%>">
      			<td><%=dtAnnunci.Rows[i]["Annunci_Numero"].ToString()%></td>
	          <td><%=dtAnnunci.Rows[i]["Annunci_Titolo"].ToString()%></td>
	          <td><%=dtAnnunci.Rows[i]["AnnunciStato_Titolo"].ToString()%></td>
	          <td><%=dtAnnunci.Rows[i]["AnnunciCategorie_Titolo"].ToString()%></td>
	          <td><%=dtAnnunci.Rows[i]["Annunci_Valore"].ToString()%></td>
	          <td><%=dtAnnunci.Rows[i]["Annunci_Cauzione"].ToString()%></td>
	          <td><%=dtAnnunci.Rows[i]["Annunci_Rilancio"].ToString()%></td>
	        </tr>
	    <% } %>
    	</tbody>
		  <% if (dtAnnunci.Rows.Count<1){
		      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
			} %> 
  </table>
  
  <h2>Documenti</h2>
  <table class="grid hover scroll" border="0" width="100%">
  	<thead>
      <tr>
				<th width="100">File</label></div>
				<th width="40">Cod.</label></div>
  			<th width="300">Titolo</label></div>
				<th width="40" class="large-text-center small-text-left">Tipo</label></div>
				<th width="60" class="large-text-center small-text-left">Estensione</label></div>
				<th width="60" class="large-text-center small-text-left">Content Type</label></div>
				<th width="60">Lingua</label></div>
      </tr>
  	</thead>
  	<tbody>
	    <%for (int i = 0; i < dtFiles.Rows.Count; i++){ %>
	    <tr class="riga<%=i%2%>">
		  <td>
			<% if (dtFiles.Rows[i]["FilesTipo_Ky"].ToString()=="1"){ %>
				<img src="<%=dtFiles.Rows[i]["Files_Path"].ToString()%>" width="75" height="50" />
			<% }else{ %>
				<i class="fa-duotone fa-up-right-from-square fa-fw"></i><%=dtFiles.Rows[i]["Files_Extension"].ToString()%>
			<% } %>
          
		  </td>
	      <td><%=dtFiles.Rows[i]["Files_Ky"].ToString()%></td>
	      <td><%=dtFiles.Rows[i]["Files_Titolo"].ToString()%></td>
      	<td class="large-text-center small-text-left"><%=dtFiles.Rows[i]["FilesTipo_Titolo"].ToString()%></td>
			  <td class="large-text-center small-text-left"><%=dtFiles.Rows[i]["Files_Extension"].ToString()%></td>
			  <td class="large-text-center small-text-left"><%=dtFiles.Rows[i]["Files_ContentType"].ToString()%></td>
			  <td><i class="fa-duotone fa-language fa-fw"></i><%=dtFiles.Rows[i]["Lingue_Titolo"].ToString()%></td>
	    </tr>
	    <% } %>
    	</tbody>
		  <% if (dtFiles.Rows.Count<1){
		      	Response.Write("<tfoot><tr><td colspan=\"8\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
			} %> 
  </table>
  
  <h2>Cauzioni</h2>
  <table class="grid hover scroll" border="0" width="100%">
  	<thead>
      <tr>
        <th width="30">Cod.</label></div>
  			<th width="40">Anagrafica</label></div>
  			<th width="40">Data</label></div>
  			<th width="40">Valore</label></div>
  			<th width="40">Metodo</label></div>
  			<th width="40">Riferimenti</label></div>
  			<th width="40">Autorizzata</label></div>
      </tr>
  	</thead>
  	<tbody>
	    <%for (int i = 0; i < dtAsteCauzioni.Rows.Count; i++){ %>
	        <tr class="riga<%=i%2%>">
	          <td><%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Ky"].ToString()%></td>
      			<td class="text-left"><%=dtAsteCauzioni.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></td>
      			<td class="text-left"><%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Data"].ToString()%></td>
      			<td class="text-left"><%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Valore"].ToString()%></td>
            <td class="text-left">
							<i class="fa-duotone <%=dtAsteCauzioni.Rows[i]["PagamentiMetodo_Icona"].ToString()%> fa-fw" style="color:<%=dtAsteCauzioni.Rows[i]["PagamentiMetodo_Colore"].ToString()%>"></i><%=dtAsteCauzioni.Rows[i]["PagamentiMetodo_Titolo"].ToString()%> su <%=dtAsteCauzioni.Rows[i]["Conti_Titolo"].ToString()%><br>
	          </td>
      			<td class="text-left"><%=dtAsteCauzioni.Rows[i]["AsteCauzioni_Riferimenti"].ToString()%></td>
      			<td class="text-left">
							<% if (dtAsteCauzioni.Rows[i]["AsteCauzioni_Autorizzata"].Equals(true)){ %>
								<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
							<% }else{  %>
								<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
							<% } %>
            </td>
	        </tr>
	    <% } %>
    	</tbody>
		  <% if (dtAsteCauzioni.Rows.Count<1){
		      	Response.Write("<tfoot><tr><td colspan=\"7\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
			} %> 
  </table>
  
  
  <h2>Offerte</h2>
	<table class="grid hover scroll" border="0" width="100%">
		<thead>
	    <tr>
	      <th width="30">Cod.</label></div>
				<th width="40" class="large-text-center small-text-left">Anagrafica</label></div>
				<th width="40" class="large-text-center small-text-left">Asta</label></div>
				<th width="40" class="large-text-center small-text-left">Esperimento</label></div>
				<th width="40" class="large-text-center small-text-left">Lotto</label></div>
				<th width="40" class="large-text-center small-text-left">Data</label></div>
				<th width="40" class="large-text-center small-text-left">Ora</label></div>
				<th width="40" class="large-text-center small-text-left">Millisecondi</label></div>
				<th width="40" class="large-text-center small-text-left">Valore</label></div>
	    </tr>
		</thead>
		<tbody>
	    <%for (int i = 0; i < dtAnnunciOfferte.Rows.Count; i++){ %>
	        <tr class="riga<%=i%2%>">
	          <td><%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Ky"].ToString()%></td>
	    			<td class="large-text-center small-text-left"><%=dtAnnunciOfferte.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></td>
	    			<td class="large-text-center small-text-left"><%=dtAnnunciOfferte.Rows[i]["Aste_Numero"].ToString()%></td>
	    			<td class="large-text-center small-text-left"><%=dtAnnunciOfferte.Rows[i]["AsteEsperimenti_Numero"].ToString()%></td>
	    			<td class="large-text-center small-text-left"><%=dtAnnunciOfferte.Rows[i]["Annunci_Ky"].ToString()%></td>
	    			<td class="large-text-center small-text-left"><%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Data"].ToString()%></td>
	    			<td class="large-text-center small-text-left"><%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Ora"].ToString()%></td>
	    			<td class="large-text-center small-text-left"><%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Millisecondi"].ToString()%></td>
	    			<td class="large-text-center small-text-left"><%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Valore"].ToString()%></td>
	        </tr>
	    <% } %>
	  	</tbody>
		  <% if (dtAnnunciOfferte.Rows.Count<1){
		      	Response.Write("<tfoot><tr><td colspan=\"9\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
			} %> 
	</table>
  
  
  
  
  </div>
  
    
</body>
</html>
