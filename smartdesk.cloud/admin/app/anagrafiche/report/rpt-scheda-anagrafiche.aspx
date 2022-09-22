<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/anagrafiche/report/rpt-scheda-anagrafiche.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title><%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_RagioneSociale")%></title>
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
        <img src="<%=dtAzienda.Rows[0]["Aziende_Logo"].ToString()%>" border="0" width="260" style="padding-top:10px;" />
    </td>
    <td width="60%" align="right">
      <div style="border:0;padding:20px;width:7cm;text-align:left">
        <div class="tipodocumento">Scheda Anagrafica</div>
          <div class="riferimenti">Numero: </div><strong><%=dtAnagrafiche.Rows[0]["Anagrafiche_Ky"].ToString()%></strong>
					<br style="clear:both">
      </div>
    </td>
  </tr>
  </table>
	
	<h1><%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_RagioneSociale")%></h1>
	<% if (Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Logo").Length>0){ %>
	<img src="<%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Logo")%>" height="40" style="max-height:40px;max-width:120px;">
	<% } %>

	<table class="form" border="0" style="width:19cm">
    <tr>
      <td class="lbl">Nome</td>
      <td>
        <%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Nome")%>
      </td>
      <td class="lbl">Cognome</td>
      <td>
        <%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Cognome")%>
      </td>
    </tr>
    <tr>
      <td class="lbl">Tipo *</td>
      <td>
        <%=Smartdesk.Data.Field(dtAnagrafiche, "AnagraficheTipo_Descrizione")%>
      </td>
      <td class="lbl">Categoria</td>
      <td>
        <%=Smartdesk.Data.Field(dtAnagrafiche, "AnagraficheCategorie_Descrizione")%>
      </td>
    </tr>
        <tr>
          <td class="lbl">Indirizzo</td>
          <td><%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Indirizzo")%></td>
          <td class="lbl">CAP</td>
          <td>
            <%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_CAP")%>
            <span class="lbl">Comune</span>
            <%=Smartdesk.Data.Field(dtAnagrafiche, "Comuni_Comune")%>
          </td>
        </tr>
        <tr>
          <td class="lbl">Nazione</td>
          <td>
            <%=Smartdesk.Data.Field(dtAnagrafiche, "Nazioni_Nazione")%>
          </td>
          <td class="lbl">Provincia</td>
          <td>
            <%=Smartdesk.Data.Field(dtAnagrafiche, "Province_Provincia")%>
          </td>
        </tr>
    <tr>
      <td class="lbl">Telefono *</td>
      <td>
        <%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Telefono")%>
      </td>
      <td class="lbl">FAX</td>
      <td><%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_FAX")%></td>
    </tr>
    <tr>
      <td class="lbl">Partita IVA</td>
      <td>
        <%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_PartitaIVA")%>
      </td>
      <td class="lbl">Cod. Fiscale</td>
      <td><%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_CodiceFiscale")%></td>
    </tr>
    <tr>
      <td class="lbl">Email *</td>
      <td>
        <%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_CodiceFiscale")%>
      </td>
      <td class="lbl">Email fatture *</td>
      <td>
        <%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_EmailAmministrazione")%>
      </td>
    </tr>
    <tr>
      <td class="lbl">Sito Web</td>
      <td>
        <%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_SitoWeb")%>
      </td>
      <td class="lbl">Password</td>
      <td>
        <%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Password")%>
      </td>
    </tr>
    <tr>
      <td class="lbl">Note</td>
      <td colspan="3">
        <%=Smartdesk.Data.Field(dtAnagrafiche, "Anagrafiche_Note")%>
      </td>
    </tr>
  </table>
	  
		<% if (strAzione!="new"){ %>
	  <h2>Contatti (<%=dtAnagraficheContatti.Rows.Count%>)</h2>
	  <% if (dtAnagraficheContatti.Rows.Count>0){ %>
	    <table class="grid stac" border="0" style="width:19cm">
	      <tr>
	        <th align="left" width="450">Email</th>
	        <th align="left">Tipo</th>
	      </tr>
	      <%for (int i = 0; i < dtAnagraficheContatti.Rows.Count; i++){ %>
	          <tr>
	            <td><%=dtAnagraficheContatti.Rows[i]["AnagraficheContatti_Email"].ToString()%></td>
	            <td><%=dtAnagraficheContatti.Rows[i]["AnagraficheContattiTipo_Descrizione"].ToString()%></td>
	          </tr>
	      <% } %>
	    </table>
	  <% }else{
			Response.Write("<span class=\"messaggio\">Nessun contatto</span>");
			}
		} %>

	  <% if (strAzione!="new"){ %>
	  <h2>Servizi da rinnovare (<%=dtAnagraficheServizi.Rows.Count%>)</h2>
	  <% if (dtAnagraficheServizi.Rows.Count>0){ %>
	    <table class="grid" border="0" style="width:19cm">
	      <tr>
	        <th class="ui-state-default" width="350">Servizio</th>
					<th class="ui-state-default" width="80">Importo</th>
					<th class="ui-state-default" width="130" align="center">Scadenza</th>
					<th class="ui-state-default" width="250">Descrizione</th>
	      </tr>
	      <%for (int i = 0; i < dtAnagraficheServizi.Rows.Count; i++){ %>
	          <tr>
	            <td><%=dtAnagraficheServizi.Rows[i]["Servizi_Titolo"].ToString()%></td>
	            <td align="center"><%=dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Importo"].ToString()%></td>
	            <td align="center"><strong><%=Smartdesk.Functions.GetMese(dtAnagraficheServizi.Rows[i]["AnagraficheServizi_MeseScadenza"].ToString())%> / <%=dtAnagraficheServizi.Rows[i]["AnagraficheServizi_AnnoScadenza"].ToString()%></strong></td>
	            <td><%=dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Descrizione"].ToString()%></td>
	          </tr>
	      <% } %>
	    </table>
	  <% }else{
			Response.Write("<span class=\"messaggio\">Nessun servizio da rinnovare</span>");
			}
		} %>

    <% if (strAzione!="new"){ %>
    <a name="SitiWeb"></a>
    <h2>Siti Web gestiti (<%=dtSitiWeb.Rows.Count%>)</h2>
    <% if (dtSitiWeb.Rows.Count>0){ %>
      <table class="grid" border="0" style="width:19cm">
	    	<thead>
        <tr>
          <th class="ui-state-default" align="left" width="40">Codice</th>
          <th class="ui-state-default" align="left" width="350">Dominio</th>
					<th class="ui-state-default" align="left" width="100">Tipo</th>
					<th class="ui-state-default" align="center" width="40">Provider</th>
					<th class="ui-state-default" align="center" width="70">PageSpeed</th>
        </tr>
	    	</thead>
	    	<tbody>
        <%for (int i = 0; i < dtSitiWeb.Rows.Count; i++){ %>
            <tr>
              <td align="left"><a href="/admin/app/sitiweb/scheda-SitiWeb.aspx?SitiWeb_Ky=<%=dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtSitiWeb.Rows[i]["Anagrafiche_Ky"].ToString()%>&sorgente=anagrafica" class="funzione"><%=dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString()%></a></td>
              <td align="left"><a href="/admin/app/sitiweb/scheda-SitiWeb.aspx?SitiWeb_Ky=<%=dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtSitiWeb.Rows[i]["Anagrafiche_Ky"].ToString()%>&sorgente=anagrafica" class="funzione"><%=dtSitiWeb.Rows[i]["SitiWeb_Dominio"].ToString()%></a></td>
              <td align="left"><%=dtSitiWeb.Rows[i]["SitiWebTipo_Titolo"].ToString()%></td>
              <td align="center"><%=dtSitiWeb.Rows[i]["Providers_Descrizione"].ToString()%></td>
              <td align="center">
								<i class="fa-duotone fa-signal fa-fw"></i>
								<%=dtSitiWeb.Rows[i]["SitiWeb_PageSpeedScore"].ToString()%>
							</td>
             </tr>
        <% } %>
	    	</tbody>
      </table>
    <% }else{
      Response.Write("<span class=\"messaggio\">Nessun sito web</span>");
    } %>
    <% } %>

  <div class="footer">
    <%=dtAzienda.Rows[0]["Aziende_Footer"].ToString()%>
  </div>
</body>
</html>
