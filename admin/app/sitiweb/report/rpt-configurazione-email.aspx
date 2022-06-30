<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/sitiweb/report/rpt-configurazione-email.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title>configurazione-email-<%=dtAnagrafiche.Rows[0]["Anagrafiche_RagioneSociale"].ToString().ToLower().Replace(" ","-")%>-<%=strDominio%></title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <link rel="preconnect" href="https://fonts.gstatic.com">
  <link type="text/css" rel="stylesheet" href="/fonts/Geomanist/Geomanist.css" media="screen, print" />
  <link rel="stylesheet" type="text/css" href="/admin/rswcrm-print.css" media="screen, print" />
  <link rel="stylesheet" href="/lib/fontawesome6/css/all.min.css" />
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
</head>
<body style="margin-left:5px;">
  <table border="0" cellpadding="0" cellspacing="0" class="header">
  <tr>
    <td width="40%" align="left">
        <img src="<%=dtAzienda.Rows[0]["Aziende_Logo"].ToString()%>" border="0" style="max-height:70px;max-width:250px;padding-top:10px;" />
    </td>
    <td width="60%" align="right">
      <div style="border:0;padding:20px;width:7cm;text-align:left">
        <div class="tipodocumento">Configurazione email</div>
        <div class="riferimenti">Data: </div><i class="fa-duotone fa-calendar-days fa-fw"></i><%Response.Write(DateTime.Now.ToString("d"));%>
      </div>
    </td>
  </tr>
  </table>

  <table border="0" cellpadding="0" cellspacing="0" class="intestazione">
  <tr>
    <td valign="top" width="120" align="left"><strong style="margin-right:10px">Destinatario:</strong></td>
    <td valign="top">
      <div class="spettabile">Spettabile</div>
      <div class="ragionesociale"><%=dtAnagrafiche.Rows[0]["Anagrafiche_RagioneSociale"].ToString()%></div>
        <%=dtAnagrafiche.Rows[0]["Anagrafiche_Indirizzo"].ToString()%><br /> 
        <%=dtAnagrafiche.Rows[0]["Comuni_Comune"].ToString()%> (<%=dtAnagrafiche.Rows[0]["Province_Provincia"].ToString()%>)<br />
        <strong>Partita IVA: <%=dtAnagrafiche.Rows[0]["Anagrafiche_PartitaIVA"].ToString()%></strong><br />
        <% if (dtAnagrafiche.Rows[0]["Anagrafiche_CodiceFiscale"].ToString().Length>0){ %>
          <strong>Codice Fiscale: <%=dtAnagrafiche.Rows[0]["Anagrafiche_CodiceFiscale"].ToString()%></strong><br />
        <% } %>
        <% if (dtAnagrafiche.Rows[0]["Anagrafiche_CodiceDestinatario"].ToString().Length>0){ %>
          <strong>Codice destinatario: <%=dtAnagrafiche.Rows[0]["Anagrafiche_CodiceDestinatario"].ToString()%></strong><br />
        <% } %>
        <% if (dtAnagrafiche.Rows[0]["Anagrafiche_PEC"].ToString().Length>0){ %>
          <strong>PEC: <%=dtAnagrafiche.Rows[0]["Anagrafiche_PEC"].ToString()%></strong><br />
        <% } %>
    </td>
  </tr>
  </table>


  <h1>Attivazione dominio e servizi di posta elettronica per il dominio <%=strDominio%></h1>
  <div>
  <p>
    Vi informiamo che tutti i servizi in relazione al vostro dominio sono attivi.<br>
    Di seguito trovate tutte le configurazioni necessarie per le caselle di posta.
  </p>
  </div>

  <h2><i class="fa-duotone fa-gear fa-fw"></i>Configurazioni con certificazione SSL per dispositivi che richiedono una connessione criptata</h2> 
	<table class="standard" cellpadding="4" cellspacing="0">
    <tr>
      <td width="220" align="right" class="text-right">Dominio:<i class="fa-duotone fa-globe fa-fw fa-lg"></i></td><td><strong><%=strDominio%></strong></td>
    </tr>
    <% if (strPop3s.Length>0){ %>
    <tr>
      <td width="220" align="right" class="text-right">Posta in arrivo (pop3) con SSL:<i class="fa-brands fa-expeditedssl fa-fw fa-lg"></i></td><td><strong><%=strPop3s%></strong> - Porta: <strong><%=strPop3sporta%></strong></td>
    </tr>
    <% } %>
    <% if (strSmtps.Length>0){ %>
    <tr>
      <td width="220" align="right" class="text-right">Posta in uscita (smtp) con SSL:<i class="fa-brands fa-expeditedssl fa-fw fa-lg"></i></td><td><strong><%=strSmtps%></strong> - Porta: <strong><%=strSmtpsporta%></strong> - 'Autenticazione server necessaria: utilizzare i dati indicati'</td>
    </tr>
    <% } %>
    <% if (strImap.Length>0){ %>
    <tr>
      <td width="200" align="right" class="text-right">Server Imap (imap) con SSL:<i class="fa-brands fa-expeditedssl fa-fw fa-lg"></i></td><td><strong><%=strImap%></strong> - Porta <strong><%=strImapPorta%></strong></td>
    </tr>
    <% } %>
    <% if (strWebmail1.Length>0){ %>
    <tr>
      <td width="200" align="right" class="text-right">Webmail:<i class="fa-duotone fa-inbox fa-fw fa-lg"></i></td><td><strong><%=strWebmail1%></strong></strong></td>
    </tr>
    <% } %>
    <% if (strWebmail2.Length>0){ %>
    <tr>
      <td width="200" align="right" class="text-right">Webmail alternativo:<i class="fa-duotone fa-inbox fa-fw fa-lg"></i></td><td><strong><%=strWebmail2%></strong></strong></td>
    </tr>
    <% } %>
  </table>  
	
  <% if (dtAnagraficheContatti.Rows.Count>0){ %>
	<h2><i class="fa-duotone fa-envelope fa-fw"></i>Caselle di posta attive</h2>
	<table class="standard" cellpadding="4" cellspacing="0">
    <tr class="intestazionecorpo">
      <td class="titolo1">Email</td>
      <td width="100" class="titololast" align="center">Password</td>
    </tr>
    <%for (int i = 0; i < dtAnagraficheContatti.Rows.Count; i++){ %>
      <tr>
        <td class="rigadocumento">
          <div class="titoloriga"><%=dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Email"].ToString()%>
          	<% if (dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Alias"].ToString().Length>0){
          		Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;&nbsp;&nbsp;" + dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Alias"].ToString());
          	} %>
          	<% if (dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Inoltro"].ToString().Length>0){
          		Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;&nbsp;&nbsp;" + dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Inoltro"].ToString());
          	} %>
          </div>
        </td>
        <td class="riga">
        	<% if (dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Alias"].ToString().Length<2){ %>
          <div class="titoloriga"><span style="font-family:Fira Code, Lucida Console,Courier New;font-size:20px;font-weight:300;"><%=dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Password"].ToString()%></span></div>
        	<% } %>
        </td>
      </tr>
    <% } %>
  </table>
  <% } %>

  <% if (dtAnagraficheContattiAlias.Rows.Count>0){ %>
	<h2><i class="fa-duotone fa-directions fa-fw"></i>Reindirizzamenti attivi</h2>
	<table class="standard" cellpadding="4" cellspacing="0">
    <tr class="intestazionecorpo">
      <td class="titolo1">Email</td>
      <td class="titololast" align="center">Reindirizzatamento</td>
    </tr>
    <%for (int i = 0; i < dtAnagraficheContattiAlias.Rows.Count; i++){ %>
      <tr>
        <td class="rigadocumento">
          <div class="titoloriga"><%=dtAnagraficheContattiAlias.Rows[i]["AnagraficheContatti_Email"].ToString()%></div>
        </td>
        <td class="riga">
          <div class="titoloriga"><%=dtAnagraficheContattiAlias.Rows[i]["AnagraficheContatti_Alias"].ToString()%></div>
        </td>
      </tr>
    <% } %>
  </table>
  <% } %>

  <% if (dtAnagraficheContattiPEC.Rows.Count>0){ %>
	<h2><i class="fa-duotone fa-envelope fa-fw"></i>Caselle di posta certificata (PEC) attive</h2>
  <table class="standard" cellpadding="4" cellspacing="0">
    <tr>
      <td width="200">Dominio certificato:</td><td><strong>pec.<%=strDominio%></strong></td>
    </tr>
    <tr>
      <td width="200">Posta in arrivo (pop3):</td><td><strong><%=dtProviders.Rows[0]["Providers_pop3s"].ToString()%></strong> - Connessione SSL porta <%=dtProviders.Rows[0]["Providers_pop3sporta"].ToString()%></td>
    </tr>
    <tr>
      <td width="200">Posta in uscita (smtp):</td><td><strong><%=dtProviders.Rows[0]["Providers_smtps"].ToString()%></strong> - Connessione SSL porta <%=dtProviders.Rows[0]["Providers_smtpsporta"].ToString()%></td>
    </tr>
    <tr>
      <td width="200">Webmail:</td><td><strong>webmail.pec.it</strong></td>
    </tr>
  </table>
  <br>
  <table class="standard" cellpadding="4" cellspacing="0">
    <tr class="intestazionecorpo">
      <td class="titolo1">Email</td>
      <td width="100" class="titololast" align="center">Password</td>
    </tr>
    <%for (int i = 0; i < dtAnagraficheContattiPEC.Rows.Count; i++){ %>
      <tr>
        <td class="rigadocumento">
          <div class="titoloriga"><%=dtAnagraficheContattiPEC.Rows[i]["AnagraficheContatti_Email"].ToString()%></div>
        </td>
        <td class="riga">
          <div class="titoloriga"><span style="font-family:Fira Code, Lucida Console,Courier New;font-size:20px;font-weight:300;"><%=dtAnagraficheContattiPEC.Rows[i]["AnagraficheContatti_Password"].ToString()%></span></div>
        </td>
      </tr>
    <% } %>
  </table>
  <% } %>
    
    <p>Le caselle sono tutte protette dai servizi di antispam e antivirus.</p>     
    
    <p>
    <strong>Attenzione:</strong><br> 
    Per quanto rigurda il Server della posta in uscita (SMTP) &egrave; necessario selezionare la voce 'Autenticazione del server necessaria',utilizzando come impostazioni le stesse della posta in arrivo.
    </p>     
    
    <p>Distinti Saluti<br>
    <strong>Staff RSW Studio</strong>
    </p>     
  
  <div class="privacy">I dati personali forniti dal Cliente sono tutelati dal GPDR recante disposizioni a tutela delle persone e degli altri soggetti rispetto al trattamento dei dati personali, e pertanto saranno utilizzati in relazione alle esigenze contrattuali e di Legge.</div>
  <div class="footer">
    <%=dtAzienda.Rows[0]["Aziende_Footer"].ToString()%>
  </div>
</body>
</html>
