<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/veicoli/report/rpt-VeicoliPrenotazioni.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title><%=Smartdesk.Data.Field(dtVeicoliPrenotazioni, "VeicoliPrenotazioni_Nominativo")%></title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <link rel="preconnect" href="https://fonts.gstatic.com">
  <link type="text/css" rel="stylesheet" href="https://cdn.smartdesk.cloud/fonts/Geomanist/Geomanist.css" media="screen, print" />
  <link rel="stylesheet" type="text/css" href="/admin/rswcrm-print.css" media="screen, print" />
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
  <link rel="stylesheet" href="https://cdn.smartdesk.cloud/lib/fontawesome6/css/all.min.css" />
</head>
<body>
  <table border="0" cellpadding="0" cellspacing="0" class="header">
  <tr>
    <td width="40%" align="left">
        <img src="<%=dtAzienda.Rows[0]["Aziende_Logo"].ToString()%>?id=<%=DateTime.Now.Month.ToString("00")%>" border="0" width="260" style="max-height:60px;max-width:200px;width:auto;padding-top:10px;" />
    </td>
    <td width="60%" align="right">
      <div style="border:0;padding:20px;width:7cm;text-align:left">
        <div class="tipodocumento"></div>
          <div class="riferimenti">Numero: </div><strong><%=dtVeicoliPrenotazioni.Rows[0]["VeicoliPrenotazioni_Ky"].ToString()%></strong>
					<br style="clear:both">
        </div>
    </td>
  </tr>
  </table>
	
  <div class="corpodocumento">
	<h1 style="text-align:center;text-transform:uppercase">Concessione in comodato di AUTOVETTURA</h1>
    <fieldset class="fieldset">
      <legend><i class="fa-duotone fa-user fa-fw"></i>Dati anagrafica</legend>
    	      <div class="ragionesociale"><%=dtAnagrafiche.Rows[0]["Anagrafiche_RagioneSociale"].ToString()%><br>
    	      <% if (dtAnagrafiche.Rows[0]["Anagrafiche_Cognome"].ToString().Length>0){ %>
    	       <%=dtAnagrafiche.Rows[0]["Anagrafiche_Cognome"].ToString()%> 
    	      <% } %>
    	      <% if (dtAnagrafiche.Rows[0]["Anagrafiche_Nome"].ToString().Length>0){ %>
    	       <%=dtAnagrafiche.Rows[0]["Anagrafiche_Nome"].ToString()%><br />
    	      <% } %>
            </div>
    	      <% if (dtAnagrafiche.Rows[0]["Anagrafiche_Indirizzo"].ToString().Length>0){ %>
    	       <%=dtAnagrafiche.Rows[0]["Anagrafiche_Indirizzo"].ToString()%><br />
    	      <% } %>
    	      <% if (dtAnagrafiche.Rows[0]["Comuni_Comune"].ToString().Length>0){ %>
    	       <%=dtAnagrafiche.Rows[0]["Anagrafiche_CAP"].ToString()%> <%=dtAnagrafiche.Rows[0]["Comuni_Comune"].ToString()%> 
    	      <% } %>
    	      <% if (dtAnagrafiche.Rows[0]["Province_Provincia"].ToString().Length>0){ %>
            (<%=dtAnagrafiche.Rows[0]["Province_Provincia"].ToString()%>)<br />
    	      <% } %>
    	      <% if (dtAnagrafiche.Rows[0]["Anagrafiche_PartitaIVA"].ToString().Length>0){ %>
    		      <strong>Partita IVA: <%=dtAnagrafiche.Rows[0]["Anagrafiche_PartitaIVA"].ToString()%></strong><br />
    	      <% } %>
    	      <% if (dtAnagrafiche.Rows[0]["Anagrafiche_CodiceFiscale"].ToString().Length>0){ %>
    	        <strong>Codice Fiscale: <%=dtAnagrafiche.Rows[0]["Anagrafiche_CodiceFiscale"].ToString()%></strong><br />
    	      <% } %>
    	      <i class="fa-duotone fa-envelope fa-fw"></i><%=dtAnagrafiche.Rows[0]["Anagrafiche_EmailContatti"].ToString()%><br />
    	      <i class="fa-duotone fa-phone fa-fw"></i><%=dtAnagrafiche.Rows[0]["Anagrafiche_Telefono"].ToString()%><br />
          	<table border="0" cellpadding="10" cellspacing="10" style="width:100%" class="corpo">
              <tr>
                <td width="140" align="left">Nato/a</td>
                <td><div style="width:100%;border-bottom:1px solid #000000"></div></td>
              </tr>
              <tr>
                <td width="140" align="left">Patente n&deg;</td>
                <td><div style="width:100%;border-bottom:1px solid #000000"></div></td>
              </tr>
              <tr>
                <td width="140" align="left">Rilasciata il</td>
                <td><div style="width:100%;border-bottom:1px solid #000000"></div></td>
              </tr>
              <tr>
                <td width="140" align="left">Dalla prefettura di</td>
                <td><div style="width:100%;border-bottom:1px solid #000000"></div></td>
              </tr>
            </table>
    </fieldset>
    <fieldset class="fieldset">
      <legend><i class="fa-duotone fa-calendar fa-fw"></i>Prenotazione</legend>
      	<table border="0" style="width:100%" class="corpo">
          <tr>
            <td class="labelField" width="110">Prenotazione del <i class="fa-duotone fa-calendar-days fa-fw"></i></td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtVeicoliPrenotazioni, "VeicoliPrenotazioni_Data")%>
            </td>
            <td class="labelField" width="40">Dal <i class="fa-duotone fa-calendar-days fa-fw"></i></td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtVeicoliPrenotazioni, "VeicoliPrenotazioni_DataInizio")%>
            </td>
            <td class="labelField" width="40">Al <i class="fa-duotone fa-calendar-days fa-fw"></i></td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtVeicoliPrenotazioni, "VeicoliPrenotazioni_DataFine")%>
            </td>
          </tr>
        </table>
    </fieldset>

    <fieldset class="fieldset">
      <legend><i class="fa-duotone fa-car fa-fw"></i>Dati vettura</legend>
      	<table border="0" style="width:100%" class="corpo">
          <tr>
            <td class="labelField" width="100">Tipo auto <i class="fa-duotone fa-car fa-fw"></i></td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtVeicoli, "VeicoliTipo_Titolo")%>
            </td>
            <td class="labelField" width="100">Vettura</td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtVeicoli, "VeicoliMarca_Titolo")%> <%=Smartdesk.Data.Field(dtVeicoli, "VeicoliModello_Titolo")%>
            </td>
            <td class="labelField" width="100">Targa</td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtVeicoli, "Veicoli_Targa")%>
            </td>
          </tr>
        </table>
    </fieldset>
    <fieldset class="fieldset">
      <legend><i class="fa-duotone fa-shield-check fa-fw"></i>Polizze</legend>
      	<table border="0" style="width:100%" class="corpo">
          <tr>
            <td class="labelField" width="100">Collisione</td>
            <td class="ValueField">
              <%=GetCheckValueSiNo(dtVeicoliPrenotazioni, "VeicoliPrenotazioni_Collisione")%>
            </td>
            <td class="labelField" width="100">Polizza RC</td>
            <td class="ValueField">
              <%=GetCheckValueSiNo(dtVeicoliPrenotazioni, "VeicoliPrenotazioni_Polizzarc")%>
            </td>
            <td class="labelField" width="100">Infortuni conducente</td>
            <td class="ValueField">
              <%=GetCheckValueSiNo(dtVeicoliPrenotazioni, "VeicoliPrenotazioni_Infortuniconducente")%>
            </td>
          </tr>
        </table>
    </fieldset>

    <fieldset class="fieldset">
      <legend><i class="fa-duotone fa-gavel fa-fw"></i>Condizioni</legend>
      <% Response.Write(Smartdesk.Functions.getOption("Veicoli_Condizioniprenotazione")); %>
    </fieldset>
    
      	<table border="0" cellspacing="10" cellpadding="10" style="width:100%" class="corpo">
          <tr>
            <td width="50%" align="center" style="text-align:center">Firma comodatario al ritiro</td>
            <td width="50%" align="center" style="text-align:center">Firma comodatario alla riconsegna</td>
          </tr>
          <tr>
            <td><div style="border:1px solid #000000;width:100%;height:35px;"></div></td>
            <td><div style="border:1px solid #000000;width:100%;height:35px;"></div></td>
          </tr>
        </table>
    
  </div>

	  

  <div class="footer">
    <%=dtAzienda.Rows[0]["Aziende_Footer"].ToString()%>
  </div>
</body>
</html>
