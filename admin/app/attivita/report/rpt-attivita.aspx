<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/attivita/report/rpt-attivita.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title>Trasferte-<%=GetFieldValue("Utenti_Nominativo")%></title>
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
  <style>
			a {
			  text-decoration : underline;
			  color : #000000;
			} 
			table.header{
			  width:19cm;
			  border-bottom:1px solid #a9a9a9;
			}
			div.titoloriga{
			  font-size:16px;
			  font-weight:700;
			}
			span.testoriga{
			  font-size:14px;
			  font-weight:700;
			}
			span.prezzo{
			  font-size:17px;
			  font-weight:700;
			}
			div.slogan{
				font-size:13px;
			  font-weight:400;
			}
			td.totale{
			  padding:0 5px 0 0;
			  margin:0;
				font-weight:700;
			  background-color:#D5D5D5;
			}
			td.titolo{
			  border-width:1px;
			  border-style:solid;
			  border-color:#ffffff #ffffff #666666 #666666;
			}
			div.corpodocumento{
			  border-width:0px;
			  border-style:solid;
			  border-color:#ffffff #666666 #666666 #666666;
			  width:19cm;
			  padding:0;
			  margin:0.2cm 0 0 0;
			}
			table.corpo{
			  margin:0.2cm 0 0 0;
			  width:19cm;
			  border-collapse:collapse;
			}
			table.corpo td.riga{
			  padding:15px 5px 15px 5px;
			}
			table.corpo td.rigaprezzo{
			  padding:15px 5px 15px 5px;
			}
			table.corpo td.titolo1{
			  font-weight:700;
			  font-size:14px;
			}
			table.corpo td.titololast{
			  font-weight:700;
			  border-top:0;
			  border-bottom:1px solid #666666;
			  font-size:14px;
			  color:#f15a29;
			}
			table.corpo td.rigadocumento{
			  border-bottom:1px solid #666666;
			  border-right:1px solid #666666;
			  border-left:1px solid #666666;
			  padding:15px 5px 15px 5px;
			}
			
			table.standard{
			  width:19cm;
			}
			
			table.standard td{
			  border:1px solid #666666;
			  padding:1px;
			  margin:0px;
			}
			
			table.totali{
			  width:7cm;
			  border: 1px solid #666666;
			  margin-left:12cm;
			  margin-top:1cm;
			  margin-bottom:0.5cm;
			  border-collapse:collapse;
			}
			table.pagamenti{
			  width:19cm;
			  border-top: 1px solid #666666;
			  border-bottom: 1px solid #666666;
			  margin-top:0.2cm;
			}
			div.titolopagamento{
			  font-size:14px;
			  font-weight:700;
			}
			div.infopagamento{
			  font-size:14px;
			  font-weight:700;
			  margin-left:2cm;
			  line-height:1.5em;
			}
			div.titoloappoggio{
			  font-size:14px;
			  font-weight:700;
			  margin-top:0.5cm;
			}
			div.infoappoggio{
			  font-size:14px;
			  font-weight:700;
			  margin-left:2cm;
			}
			div.pagamenti{
			  width:19cm;
			  border-top:4px solid #666666;
			  border-bottom:4px solid #666666;
			  padding:0.2cm 0 0.2cm 0;
			}
			
			div.privacy{
			  margin-top:0.1cm;
			  width:19cm;
			  font-size:10px;
			  font-weight:700;
			  text-align:left;
			}
			
  </style>
</head>
<body style="margin:0;padding:0;background : #ffffff;color : #000000;border:0;font-size:13px;">
  <table border="0" cellpadding="0" cellspacing="0" class="header">
  <tr>
    <td width="40%" align="left">
        <img src="<%=dtAzienda.Rows[0]["Aziende_Logo"].ToString()%>" border="0" style="max-height:70px;max-width:250px;padding-top:10px;" />
    </td>
    <td width="60%" align="right">
      <div style="border:0;padding:20px;width:7cm;text-align:left">
        <div class="tipodocumento">Attivita</div>
          <table border="0" width="100%">
          <tr>
          	<td>Utente:</td>
          	<td><strong><%=GetFieldValue("Utenti_Nominativo")%></strong></td>
          </tr>
          <tr>
          	<td>Data:</td>
          	<td><strong><%=DateTime.Now%></strong></td>
          </tr>
				</table>
      </div>
    </td>
  </tr>
  </table>

  <table border="1" cellpadding="4" cellspacing="0" class="corpo" style="margin:0.2cm 0 0 0;width:19cm;border-collapse:collapse;">
    <tr class="intestazionecorpo">
      <th width="100" class="titololast" align="center">Entro il</th>
      <th>Descrizione</th>
    </tr>
    <%
			for (int i = 0; i < dtAttivita.Rows.Count; i++){ %>
      <tr>
        <td align="center">
					<i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivita.Rows[i]["Attivita_Scadenza_IT"].ToString()%><br>
				</td>
        <td style="padding:5px">
					<i class="fa-duotone <%=dtAttivita.Rows[i]["AttivitaTipo_Icona"].ToString()%> fa-fw "></i>
				 	<% if (dtAttivita.Rows[i]["Attivita_Trasferta"].Equals(true)){ %>
						<i class="fa-duotone fa-car fa-fw"></i>
				 		<br><i class="fa-duotone fa-location-dot fa-fw"></i><%=dtAttivita.Rows[i]["Comuni_Comune"].ToString()%> (<%=dtAttivita.Rows[i]["Province_Provincia"].ToString()%>)</strong>
				 	<% } %>
          <%=dtAttivita.Rows[i]["Attivita_Descrizione"].ToString()%>
          <% if (dtAttivita.Rows[i]["Commesse_Titolo"].ToString().Length>1){ %>
						<br><strong>Progetto: <%=dtAttivita.Rows[i]["Commesse_Titolo"].ToString()%></strong>
					<% } %>
				 	<br><strong><i class="fa-duotone fa-users fa-fw"></i><%=dtAttivita.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></strong> - <%=dtAttivita.Rows[i]["Anagrafiche_SitoWeb"].ToString()%>
        </td>
      </tr>
    <%
			}
		%>
  </table>

  <div class="footer">
    <%=dtAzienda.Rows[0]["Aziende_Footer"].ToString()%>
  </div>
</body>
</html>
