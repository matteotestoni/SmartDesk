<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="rpt-attivita-planning.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title>Attivit&agrave; > Planning attivit&agrave;</title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <link rel="preconnect" href="https://fonts.gstatic.com">
  <link type="text/css" rel="stylesheet" href="/fonts/Geomanist/Geomanist.css" media="screen, print" />
  <link rel="stylesheet" type="text/css" href="/admin/rswcrm-print.css" media="screen, print" />
  <link rel="stylesheet" href="/lib/fontawesome6/css/all.min.css" />
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
				font-size:1.25rem;
			}
			h2{
				font-size:1rem;
        font-weight:700;
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
        <div class="tipodocumento">Planning attivit&agrave;</div>
        <div class="riferimenti">Data: </div><i class="fa-duotone fa-calendar-days fa-fw"></i><%=DateTime.Now%><br />
      </div>
    </td>
  </tr>
  </table>
	<table border="0" cellpadding="4" cellspacing="0" class="corpo" style="margin:0.2cm 0 0 0;width:20cm;border-collapse:collapse;"">
    <%
			for (int i = 0; i < dtAttivita.Rows.Count; i++){
		      if (strAnagrafiche_Ky!=dtAttivita.Rows[i]["Anagrafiche_Ky"].ToString()){ %>
						<tr>
							<td colspan="5">
								<h3>
								<i class="fa-duotone fa-users fa-fw"></i><%=dtAttivita.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%><br>
								</h3>
							</td>
						</tr>
					<% } %>
		      <tr style="padding:3px;border-bottom:1px solid #ededed;">
		        <td width="90" style="padding:3px;border-bottom:1px solid #ededed;">
		          <i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtAttivita.Rows[i]["Attivita_Scadenza_IT"].ToString()%></strong>
		        </td>
		        <td width="25" style="padding:3px;border-bottom:1px solid #ededed;">
							<% 
              if (dtLogin.Rows[0]["Utenti_Ky"].ToString()==dtAttivita.Rows[i]["Utenti_Ky"].ToString()){
                //Response.Write("-->");
              }
              %>
		        </td>
		        <td style="padding:3px;border-bottom:1px solid #ededed;">
							<i class="<%=dtAttivita.Rows[i]["AttivitaTipo_Icona"].ToString()%> fa-fw "></i><%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%> <%=dtAttivita.Rows[i]["Attivita_Descrizione"].ToString()%>
		          <%
								if (dtAttivita.Rows[i]["Anagrafiche_Ky"].ToString()!=dtAttivita.Rows[i]["Anagrafiche_Ky"].ToString()){
									Response.Write("- <strong>" + dtAttivita.Rows[i]["Anagrafiche_RagioneSociale"].ToString() + "</strong>");
								}
							
							%>
		        </td>
		        <td width="80" style="padding:3px;border-bottom:1px solid #ededed;">
							Ore: <i class="fa-duotone fa-clock fa-fw"></i><strong><%=dtAttivita.Rows[i]["Attivita_Ore"].ToString()%></strong>
		        </td>
		        <td width="120" style="padding:3px;border-bottom:1px solid #ededed;">
							<i class="fa-duotone fa-user fa-fw"></i><strong><%=dtAttivita.Rows[i]["Utenti_Nome"].ToString()%> <%=dtAttivita.Rows[i]["Utenti_Cognome"].ToString()%></strong>
		        </td>

            
            
            
            
		      </tr>
		      <%
					strAnagrafiche_Ky=dtAttivita.Rows[i]["Anagrafiche_Ky"].ToString();
			}
		%>
  </table>
</body>
</html>
