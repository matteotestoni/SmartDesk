<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/veicoli/report/rpt-VeicoliPrenotazioni.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title><%=Smartdesk.Data.Field(dtVeicoliPrenotazioni, "VeicoliPrenotazioni_Nominativo")%></title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <link rel="preconnect" href="https://fonts.gstatic.com">
  <link type="text/css" rel="stylesheet" href="/fonts/Geomanist/Geomanist.css" media="screen, print" />
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
        <div class="tipodocumento">Prenotazione auto</div>
          <div class="riferimenti">Numero: </div><strong><%=dtVeicoliPrenotazioni.Rows[0]["VeicoliPrenotazioni_Ky"].ToString()%></strong>
					<br style="clear:both">
        </div>
    </td>
  </tr>
  </table>
	
  <div class="corpodocumento">
	<h1 style="text-align:center;text-transform:uppercase">Targa <%=Smartdesk.Data.Field(dtVeicoliPrenotazioni, "Veicoli_Targa")%> dal <%=Smartdesk.Data.Field(dtVeicoliPrenotazioni, "VeicoliPrenotazioni_DataInizio")%> al <%=Smartdesk.Data.Field(dtVeicoliPrenotazioni, "VeicoliPrenotazioni_DataFine")%></h1>
    <fieldset class="fieldset">
      <legend>Prenotazione</legend>
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
      <legend>Dati vettura</legend>
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
      <legend>Dati anagrafica</legend>
      	<table border="0" style="width:100%" class="corpo">
          <tr>
            <td class="labelField" width="100">Nominativo <i class="fa-duotone fa-user fa-fw"></i></td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_RagioneSociale")%>
            </td>
            <td class="labelField" width="100">Email <i class="fa-duotone fa-envelope fa-fw"></i></td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_EmailContatti")%>
            </td>
            <td class="labelField" width="100">Telefono <i class="fa-duotone fa-phone fa-fw"></i></td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Telefono")%>
            </td>
          </tr>
        </table>
    </fieldset>
    
  </div>

	  

  <div class="footer">
    <%=dtAzienda.Rows[0]["Aziende_Footer"].ToString()%>
  </div>
</body>
</html>
