<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/officina/report/rpt-scheda-officina.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title><%=Smartdesk.Data.Field(dtOfficina, "Officina_Nominativo")%></title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <link rel="preconnect" href="https://fonts.gstatic.com">
  <link type="text/css" rel="stylesheet" href="/fonts/Geomanist/Geomanist.css" media="screen, print" />
  <link rel="stylesheet" type="text/css" href="/admin/rswcrm-print.css" media="screen, print" />
  <link rel="shortcut icon" href="/img/favicon/favicon.ico">
  <link rel="apple-touch-icon" sizes="57x57" href="/img/favicon/apple-icon-57x57.png">
  <link rel="apple-touch-icon" sizes="60x60" href="/img/favicon/apple-icon-60x60.png">
  <link rel="apple-touch-icon" sizes="72x72" href="/img/favicon/apple-icon-72x72.png">
  <link rel="apple-touch-icon" sizes="76x76" href="/img/favicon/apple-icon-76x76.png">
  <link rel="apple-touch-icon" sizes="114x114" href="/img/favicon/apple-icon-114x114.png">
  <link rel="apple-touch-icon" sizes="120x120" href="/img/favicon/apple-icon-120x120.png">
  <link rel="apple-touch-icon" sizes="144x144" href="/img/favicon/apple-icon-144x144.png">
  <link rel="apple-touch-icon" sizes="152x152" href="/img/favicon/apple-icon-152x152.png">
  <link rel="apple-touch-icon" sizes="180x180" href="/img/favicon/apple-icon-180x180.png">
  <link rel="icon" type="image/png" sizes="192x192" href="/img/favicon/android-icon-192x192.png">
  <link rel="icon" type="image/png" sizes="32x32" href="/img/favicon/favicon-32x32.png">
  <link rel="icon" type="image/png" sizes="96x96" href="/img/favicon/favicon-96x96.png">
  <link rel="icon" type="image/png" sizes="16x16" href="/img/favicon/favicon-16x16.png">
  <link rel="manifest" href="/img/favicon/manifest.json">
  <meta name="msapplication-TileColor" content="#ffffff">
  <meta name="msapplication-TileImage" content="/img/favicon/ms-icon-144x144.png">
  <meta name="theme-color" content="#ffffff">  
  <link rel="stylesheet" href="/lib/fontawesome6/css/all.min.css" />
</head>
<body>
  <table border="0" cellpadding="0" cellspacing="0" class="header">
  <tr>
    <td width="40%" align="left">
        <img src="<%=dtAzienda.Rows[0]["Aziende_Logo"].ToString()%>?id=<%=DateTime.Now.Month.ToString("00")%>" border="0" width="260" style="max-height:60px;max-width:200px;width:auto;padding-top:10px;" />
    </td>
    <td width="60%" align="right">
      <div style="border:0;padding:20px;width:7cm;text-align:left">
        <div class="tipodocumento">Scheda Officina</div>
          <div class="riferimenti">Numero: </div><strong><%=dtOfficina.Rows[0]["Officina_Ky"].ToString()%></strong>
					<br style="clear:both">
        </div>
    </td>
  </tr>
  </table>
	
  <div class="corpodocumento">
	<h1 style="text-align:center;text-transform:uppercase"><%=Smartdesk.Data.Field(dtOfficina, "Officina_Nominativo")%> - <%=Smartdesk.Data.Field(dtOfficina, "Officina_Vettura")%><br><%=Smartdesk.Data.Field(dtOfficina, "Officina_TargaVettura")%> - <%=Smartdesk.Data.Field(dtOfficina, "OfficinaTipoauto_Titolo")%></h1>
    <fieldset class="fieldset">
      <legend>Dati vettura</legend>
      	<table border="0" style="width:100%" class="corpo">
          <tr>
            <td class="labelField" width="100">Tipo auto <i class="fa-duotone fa-car fa-fw"></i></td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtOfficina, "OfficinaTipoauto_Titolo")%>
            </td>
            <td class="labelField" width="100">Colore <i class="fa-duotone fa-palette fa-fw"></i></td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtOfficina, "Colori_Titolo")%>
            </td>
          </tr>
          <tr>
            <td class="labelField" width="100">Vettura</td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtOfficina, "Officina_Vettura")%>
            </td>
            <td class="labelField" width="100">Targa</td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtOfficina, "Officina_TargaVettura")%>
            </td>
          </tr>
          <tr>
            <td class="labelField" width="100">Stato</td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtOfficina, "OfficinaStati_Titolo")%>
            </td>
            <td class="labelField" width="100">Numero Telaio</td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtOfficina, "Officina_NumeroTelaio")%>
            </td>
          </tr>
        </table>
    </fieldset>

    <fieldset class="fieldset">
      <legend>Dati proprietario</legend>
      	<table border="0" style="width:100%" class="corpo">
          <tr>
            <td class="labelField" width="100">Nominativo <i class="fa-duotone fa-user fa-fw"></i></td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtOfficina, "Officina_Nominativo")%>
            </td>
            <td class="labelField" width="100">Email <i class="fa-duotone fa-envelope fa-fw"></i></td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtOfficina, "Officina_Email")%>
            </td>
            <td class="labelField" width="100">Telefono <i class="fa-duotone fa-phone fa-fw"></i></td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtOfficina, "Officina_Telefono")%>
            </td>
          </tr>
        </table>
    </fieldset>

    <fieldset class="fieldset">
      <legend>Dati officina</legend>
      	<table border="0" style="width:100%" class="corpo">
          <tr>
            <td class="labelField" width="100">Accettazione <i class="fa-duotone fa-calendar-days fa-fw"></i></td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtOfficina, "Officina_DataAccettazione")%>
            </td>
            <td class="labelField" width="100">Priorit&agrave;</td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtOfficina, "Priorita_Descrizione")%>
            </td>
          </tr>
          <tr>
            <td class="labelField" width="100">Data Consegna <i class="fa-duotone fa-calendar-days fa-fw"></i></td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtOfficina, "Officina_DataConsegna")%>
            </td>
            <td class="labelField" width="100">Ora Consegna <i class="fa-duotone fa-clock fa-fw"></i></td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtOfficina, "OfficinaOrari_Orario")%>
            </td>
          </tr>
          <tr>
            <td class="labelField" width="100">Venditore <i class="fa-duotone fa-user fa-fw"></i></td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtOfficina, "Officina_Venditore")%>
            </td>
          </tr>
          <tr>
            <td class="labelField" width="100">Marchiatura</td>
            <td class="ValueField">
              <%=GetCheckValueSiNo(dtOfficina, "Officina_Marchiatura")%>
            </td>
            <td class="labelField" width="100">Mapo</td>
            <td class="ValueField">
              <%=GetCheckValueSiNo(dtOfficina, "Officina_Mapo")%>
            </td>
          </tr>
          <tr>
            <td class="labelField" width="100">Accessori</td>
            <td class="ValueField">
              <%=Smartdesk.Data.Field(dtOfficina, "Officina_AccessoriOfficina")%>
            </td>
          </tr>
        </table>
    </fieldset>
    
    <fieldset class="fieldset">
      <legend>Preparazione</legend>
      	<table border="0" style="width:100%" class="corpo">
          <tr>
            <td class="labelField" width="100">Preparatore <i class="fa-duotone fa-user fa-fw"></i></td>
            <td class="ValueField" colspan="3">
              <%=Smartdesk.Data.Field(dtOfficina, "OfficinaPreparatori_Nominativo")%>
            </td>
          </tr>
          <tr>
            <td class="labelField" width="100">Telaio</td>
            <td class="ValueField">
              <%=GetCheckValue(dtOfficina, "Officina_Telaio")%>
            </td>
            <td class="labelField" width="100">Targa</td>
            <td class="ValueField">
              <%=GetCheckValue(dtOfficina, "Officina_Targa")%>
            </td>
            <td class="labelField" width="100">Doppie Chiavi</td>
            <td class="ValueField">
              <%=GetCheckValue(dtOfficina, "Officina_DoppieChiavi")%>
            </td>
          </tr>
          <tr>
            <td class="labelField" width="100">Manuali</td>
            <td class="ValueField">
              <%=GetCheckValue(dtOfficina, "Officina_Manuali")%>
            </td>
            <td class="labelField" width="100">Accessori</td>
            <td class="ValueField">
              <%=GetCheckValue(dtOfficina, "Officina_Accessori")%>
            </td>
            <td class="labelField" width="100">Controllo livelli</td>
            <td class="ValueField">
              <%=GetCheckValue(dtOfficina, "Officina_ControlloLivelli")%>
            </td>
          </tr>
          <tr>
            <td class="labelField" width="100">Controllo batteria</td>
            <td class="ValueField">
              <%=GetCheckValue(dtOfficina, "Officina_ControlloBatteria")%>
            </td>
            <td class="labelField" width="100">Vetrofania</td>
            <td class="ValueField">
              <%=GetCheckValue(dtOfficina, "Officina_Vetrofania")%>
            </td>
            <td class="labelField" width="100">Spie</td>
            <td class="ValueField">
              <%=GetCheckValue(dtOfficina, "Officina_Spie")%>
            </td>
          </tr>
          <tr>
            <td class="labelField" width="100">Data e ora</td>
            <td class="ValueField">
              <%=GetCheckValue(dtOfficina, "Officina_DataOra")%>
            </td>
            <td class="labelField" width="100">Tappeti</td>
            <td class="ValueField">
              <%=GetCheckValue(dtOfficina, "Officina_Tappeti")%>
            </td>
            <td class="labelField" width="100">Pressione gomma</td>
            <td class="ValueField">
              <%=GetCheckValue(dtOfficina, "Officina_PressioneGomme")%>
            </td>
          </tr>
          <tr>
            <td class="labelField" width="100">Carburante</td>
            <td class="ValueField">
              <%=GetCheckValue(dtOfficina, "Officina_Carburante")%>
            </td>
            <td class="labelField" width="100">Carrozzeria</td>
            <td class="ValueField">
              <%=GetCheckValue(dtOfficina, "Officina_Carrozzeria")%>
            </td>
            <td class="labelField" width="100">Kit fix & go ruotino</td>
            <td class="ValueField">
              <%=GetCheckValue(dtOfficina, "Officina_Kitfixgoruotino")%>
            </td>
          </tr>
          <tr>
            <td class="labelField" width="100">Portatarghe</td>
            <td class="ValueField" colspan="3">
              <%=GetCheckValue(dtOfficina, "Officina_Portatarghe")%>
            </td>
          </tr>
          <tr>
            <td class="labelField" width="100">Note</td>
            <td class="ValueField" colspan="3">
              <%=Smartdesk.Data.Field(dtOfficina, "Officina_Note")%>
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
