<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="rpt-annunci.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title><%=dtAnnunci.Rows[0]["Annunci_Titolo"]%></title>
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
	<link type="text/css" rel="stylesheet" href="/lib/foundation6.7.5/css/app.css">
  <meta name="msapplication-TileColor" content="#ffffff">
  <meta name="msapplication-TileImage" content="https://cdn.smartdesk.cloud/img/favicon/ms-icon-144x144.png">
  <meta name="theme-color" content="#ffffff">  
  <link rel="stylesheet" href="https://cdn.smartdesk.cloud/lib/fontawesome6/css/all.min.css" />
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
		.tableofferte tr:first-child td{
			font-weight:700;
			color:green;
		}
	</style>
</head>
<body class="reporta4verticale" style="margin-left:5px;">
  <div class="grid-x grid-padding-x">
    <div class="large-4 medium-4 small-12 cell">
      <img src="<%=dtAzienda.Rows[0]["Aziende_Logo"].ToString()%>" border="0" style="max-height:70px;max-width:250px;padding-top:10px;" />
    </div>
    <div class="large-8 medium-8 small-12 cell">
      <div style="border:0;padding:10px;width:7cm;text-align:left">
      </div>
    </div>
  </div>
  <hr>

	<div class="corporeport">
	
	
	<fieldset class="fieldset">
		<legend>Annuncio</legend>
  	<div class="grid-x grid-padding-x">
    	<div class="large-2 medium-2 small-12 cell"><label>Numero</label></div>
    	<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAnnunci, "Annunci_Ky")%></div>
    	<div class="large-2 medium-2 small-12 cell"><label>Titolo</label></div>
    	<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAnnunci, "Annunci_Titolo")%></div>
    </div>
  	<div class="grid-x grid-padding-x">
    	<div class="large-2 medium-2 small-12 cell"><label>Stato</label></div>
    	<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAnnunci, "AnnunciStato_Titolo")%></div>
    	<div class="large-2 medium-2 small-12 cell"><label>Categoria</label></div>
    	<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAnnunci, "AnnunciCategorie_Titolo")%></div>
    </div>
  	<div class="grid-x grid-padding-x">
    	<div class="large-2 medium-2 small-12 cell"><label>Valore</label></div>
    	<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAnnunci, "Annunci_Valore")%></div>
    </div>
  	<div class="grid-x grid-padding-x">
    	<div class="large-2 medium-2 small-12 cell"><label>Cauzione</label></div>
    	<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAnnunci, "Annunci_Cauzione")%></div>
    	<div class="large-2 medium-2 small-12 cell"><label>Rilancio</label></div>
    	<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAnnunci, "Annunci_Rilancio")%></div>
    </div>
  	<div class="grid-x grid-padding-x">
    	<div class="large-2 medium-2 small-12 cell"><label>Visite</label></div>
    	<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAnnunci, "Annunci_Visite")%></div>
    </div>
  	<div class="grid-x grid-padding-x">
    	<div class="large-2 medium-2 small-12 cell"><label>Note</label></div>
    	<div class="large-10 medium-10 small-12 cell"><%=Smartdesk.Data.Field(dtAnnunci, "Annunci_Note")%></div>
    </div>
  	<div class="grid-x grid-padding-x">
    	<div class="large-2 medium-2 small-12 cell"><label>Note pubblicit&agrave;</label></div>
    	<div class="large-10 medium-10 small-12 cell"><%=Smartdesk.Data.Field(dtAnnunci, "Annunci_NotePubblicita")%></div>
    </div>
	</fieldset>

	
  <% if (dtAsteEsperimenti!=null && dtAsteEsperimenti.Rows.Count>0){ %>
	<fieldset class="fieldset">
		<legend>Esperimento</legend>
  	<div class="grid-x grid-padding-x">
    	<div class="large-2 medium-2 small-12 cell"><label>Esperimento</label></div>
    	<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAsteEsperimenti, "AsteEsperimenti_Numero")%></div>
    	<div class="large-2 medium-2 small-12 cell"><label>Esito</label></div>
    	<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAsteEsperimenti, "AsteEsperimentiEsiti_Titolo")%></div>
    </div>
    <div class="grid-x grid-padding-x">
      <div class="large-2 medium-2 small-12 cell"><label>Ribasso</label></div>
      <div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAsteEsperimenti, "AsteEsperimenti_PercentualeRibasso")%></div>
      <div class="large-2 medium-2 small-12 cell"><label>Inizio</label></div>
      <div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAsteEsperimenti, "AsteEsperimenti_DataInizio")%></div>
    </div>
    <div class="grid-x grid-padding-x">
      <div class="large-2 medium-2 small-12 cell"><label>Termine</label></div>
      <div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAsteEsperimenti, "AsteEsperimenti_DataTermine")%></div>
      <div class="large-2 medium-2 small-12 cell"><label>Pubblicazione</label></div>
      <div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAsteEsperimenti, "AsteEsperimenti_DataPubblicazione")%></div>
    </div>
    <div class="grid-x grid-padding-x">
      <div class="large-2 medium-2 small-12 cell"><label>Chiusura</label></div>
      <div class="large-10 medium-10 small-12 cell">
        <%=Smartdesk.Data.Field(dtAsteEsperimenti, "AsteEsperimenti_DataChiusura")%>
      </div>
    </div>
	</fieldset>
	<fieldset class="fieldset">
		<legend>Asta</legend>
    <div class="grid-x grid-padding-x">
      <div class="large-2 medium-2 small-12 cell"><label>Titolo</label></div>
			<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAste, "Aste_Titolo")%></div>
      <div class="large-2 medium-2 small-12 cell"><label>Numero</label></div>
			<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAste, "Aste_Numero")%></div>
    </div>
    <div class="grid-x grid-padding-x">
      <div class="large-2 medium-2 small-12 cell"><label>Anagrafica</label></div>
			<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAste, "Anagrafiche_RagioneSociale")%></div>
      <div class="large-2 medium-2 small-12 cell"><label>Categoria</label></div>
			<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAste, "AsteCategorie_Titolo")%></div>
    </div>
    <div class="grid-x grid-padding-x">
      <div class="large-2 medium-2 small-12 cell"><label>Indirizzo</label></div>
      <div class="large-10 medium-10 small-12 cell"><%=Smartdesk.Data.Field(dtAste, "Aste_Indirizzo")%>,<%=Smartdesk.Data.Field(dtAste, "Comuni_Comune")%>, <%=Smartdesk.Data.Field(dtAste, "Province_Provincia")%>, <%=Smartdesk.Data.Field(dtAste, "Regioni_Regione")%>, <%=Smartdesk.Data.Field(dtAste, "Nazioni_Nazione")%></div></div>
    <div class="grid-x grid-padding-x">
      <div class="large-2 medium-2 small-12 cell"><label>Referente</label></div>
      <div class="large-10 medium-10 small-12 cell"><%=Smartdesk.Data.Field(dtAste, "Aste_Referente")%>,<i class="fa-duotone fa-phone fa-fw"></i><%=Smartdesk.Data.Field(dtAste, "Aste_CellulareReferente")%>, <i class="fa-duotone fa-envelope fa-fw"></i><%=Smartdesk.Data.Field(dtAste, "Aste_EmailReferente")%></div>
    </div>
    <div class="grid-x grid-padding-x">
      <div class="large-2 medium-2 small-12 cell"><label>Provvigione</label></div>
			<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAste, "Aste_Provvigione")%></div>
      <div class="large-2 medium-2 small-12 cell"><label>Cauzione</label></div>
			<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAste, "Aste_Cauzione")%></div>
    </div>
    <div class="grid-x grid-padding-x">
      <div class="large-2 medium-2 small-12 cell"><label>Rilancio</label></div>
			<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAste, "Aste_Rilancio")%></div>
      <div class="large-2 medium-2 small-12 cell"><label>Pagamento</label></div>
			<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAste, "PagamentiMetodo_Descrizione")%></div>
    </div>
    <div class="grid-x grid-padding-x">
      <div class="large-2 medium-2 small-12 cell"><label>Pagamento</label></div>
			<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAste, "Aste_DataPagamento")%></div>
      <div class="large-2 medium-2 small-12 cell"><label>Ritiro</label></div>
			<div class="large-4 medium-4 small-12 cell"><%=Smartdesk.Data.Field(dtAste, "AsteRitiri_Titolo")%></div>
    </div>
    <div class="grid-x grid-padding-x">
      <div class="large-2 medium-2 small-12 cell"><label>Descrizione</label></div>
      <div class="large-10 medium-10 small-12 cell"><%=Smartdesk.Data.Field(dtAste, "Aste_Descrizione")%></div>
    </div>
	</fieldset>
  <% } %>
    
  <% if (dtFiles!=null && dtFiles.Rows.Count>0){ %>
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
  </table>
  <% } %>
  
  <% if (dtAsteCauzioni!=null && dtAsteCauzioni.Rows.Count>0){ %>
  <h2>Cauzioni</h2>
  <table class="grid hover scroll" border="0" width="100%">
  	<thead>
      <tr>
        <th width="30">Cod.</label></div>
  			<th width="150">Anagrafica</label></div>
  			<th width="80">Data</label></div>
  			<th width="40">Valore</label></div>
  			<th width="120">Metodo</label></div>
  			<th width="40">Riferimenti</label></div>
  			<th width="40">Aut.</label></div>
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
      			<td class="text-center">
							<% if (dtAsteCauzioni.Rows[i]["AsteCauzioni_Autorizzata"].Equals(true)){ %>
								<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
							<% }else{  %>
								<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
							<% } %>
            </td>
	        </tr>
	    <% } %>
    	</tbody>
  </table>
	<% } %> 

  <% if (dtAnnunciOfferte!=null && dtAnnunciOfferte.Rows.Count>0){ %>
  <h2>Offerte</h2>
	<table class="grid hover stack tableofferte" border="0" width="100%">
		<thead>
	    <tr>
	      <th width="30">Cod.</label></div>
				<th width="150" class="text-left">Anagrafica</label></div>
				<th width="40" class="large-text-center small-text-left">Esp.</label></div>
				<th width="80" class="large-text-center small-text-left">Data</label></div>
				<th width="40" class="large-text-center small-text-left">Sec.Millis.</label></div>
				<th width="40" class="large-text-center small-text-left">Valore</label></div>
	    </tr>
		</thead>
		<tbody>
	    <%for (int i = 0; i < dtAnnunciOfferte.Rows.Count; i++){ %>
	        <tr class="riga<%=i%>">
	          <td><%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Ky"].ToString()%></td>
	    			<td class="text-left"><%=dtAnnunciOfferte.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></td>
	    			<td class="large-text-center small-text-left"><%=dtAnnunciOfferte.Rows[i]["AsteEsperimenti_Numero"].ToString()%></td>
	    			<td class="large-text-center small-text-left"><%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Data"].ToString()%></td>
	    			<td class="large-text-center small-text-left"><%=dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Millisecondi"].ToString()%></td>
	    			<td class="large-text-center small-text-left">
						<%
						if (dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Valore"]!=DBNull.Value && dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Valore"].ToString().Length>0){
							Response.Write(dtAnnunciOfferte.Rows[i]["AnnunciOfferte_Valore"].ToString());
						}
						%>
						</td>
	        </tr>
	    <% } %>
	  	</tbody>
	</table>
	<% } %> 

  
  
  
  </div>
  
    
</body>
</html>
