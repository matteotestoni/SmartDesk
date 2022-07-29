<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/progetti/report/rpt-commesse-elenco.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title>Progetti > Elenco progetti</title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <link rel="preconnect" href="https://fonts.gstatic.com">
  <link type="text/css" rel="stylesheet" href="/fonts/Geomanist/Geomanist.css" media="screen, print" />
  <link rel="stylesheet" type="text/css" href="/admin/rswcrm-print.css" media="screen, print" />
  <link rel="stylesheet" href="https://cdn.smartdesk.cloud/lib/fontawesome6/css/all.min.css" />
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
  <style>
			a {
			  text-decoration : underline;
			  color : #000000;
			} 
			h1{
				font-size:1.1rem;
			}
			h2{
				font-size:0.925rem;
			}
  </style>
</head>
<body style="margin:0;padding:0;background : #ffffff;color : #000000;border:0;font-size:13px;">
	<table border="0" cellpadding="0" cellspacing="0" class="header">
  <tr>
    <td width="100%" align="left">
        <img src="<%=dtAzienda.Rows[0]["Aziende_Logo"].ToString()%>" border="0" style="max-height:70px;max-width:250px;padding-top:10px;" />
    </td>
    <td width="60%" align="right">
      <div style="border:0;padding:10px;width:8cm;text-align:left">
        <div class="tipodocumento">Elenco progetti</div>
        <div class="riferimenti">Data: </div><%=DateTime.Now%><br />
      </div>
    </td>
  </tr>
  </table>
	<table border="0" cellpadding="4" cellspacing="0" class="corpo" style="margin:0.2cm 0 0 0;width:19cm;border-collapse:collapse;"">
    <tr>
      <th align="left">Progetto</td>
      <th align="left" width="150">Note</td>
      <th width="110" class="text-center date">Data</th>
      <th align="center">Ore previste</th>
      <th align="center">Ore impiegate</th>
    </tr>
    <%
			for (int i = 0; i < dtCommesse.Rows.Count; i++){ %>
		      <tr style="padding:3px;border-bottom:1px solid #ededed;">
		        <td style="padding:5px;border-bottom:1px solid #ededed;">
              <% if (dtCommesse.Rows[i]["Anagrafiche_SitoWeb"].ToString().Length>1){ %>
              <img src="https://www.google.com/s2/favicons?domain=<%=dtCommesse.Rows[i]["Anagrafiche_SitoWeb"].ToString()%>" width="16" height="16" border="0">
              <% }else{ %>
              <i class="fa-duotone fa-users fa-fw"></i>
              <% } %>  
		          
              <strong><%=dtCommesse.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></strong><br>
		          <i class="fa-duotone fa-file-lines fa-fw"></i><%=dtCommesse.Rows[i]["Commesse_Titolo"].ToString()%><br>
		        </td>
		        <td style="padding:3px;border-bottom:1px solid #ededed;"><%=dtCommesse.Rows[i]["Commesse_Note"].ToString()%></td>
		        <td style="padding:3px;border-bottom:1px solid #ededed;"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtCommesse.Rows[i]["Commesse_Data_IT"].ToString()%></td>
		        <td style="padding:3px;border-bottom:1px solid #ededed;" align="center"><i class="fa-duotone fa-clock fa-fw"></i><%=dtCommesse.Rows[i]["Commesse_OrePreviste"].ToString()%></td>
		        <td style="padding:3px;border-bottom:1px solid #ededed;" align="center"><i class="fa-duotone fa-clock fa-fw"></i><%=dtCommesse.Rows[i]["Commesse_OreImpiegate"].ToString()%></td>
		      </tr>
		      <%
			}
		%>
  </table>
</body>
</html>
